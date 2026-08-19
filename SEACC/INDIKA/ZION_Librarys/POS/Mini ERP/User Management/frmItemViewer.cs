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
    public partial class frmItemViewer : Form
    {

        #region Variables
    
           public int iFormID;
        public bool bNoAccess;
        public string glbItemID = "", glbItemSubCategoryID1 = "", glbItemSubCategoryID2 = "", glbItemSerialNo1 = "", glbItemSerialNo2 = "";

        int iRow;
        #endregion

        #region Form Load
        public frmItemViewer()
        {
            //this.MdiParent = frmMain.ActiveForm;
            //this.MdiParent = frmMain.ActiveForm;
            iFormID = clsSecurity.getFormID(FormName.ViewerRawMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();

        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            ClearFields();
            if (glbItemID.Length > 0 && glbItemSubCategoryID1.Length > 0 && glbItemSubCategoryID2.Length > 0 && glbItemSerialNo1.Length > 0 && glbItemSerialNo2.Length > 0)
            {
                FillDetails(glbItemID, glbItemSubCategoryID1, glbItemSubCategoryID2, glbItemSerialNo1, glbItemSerialNo2);
               
            }
            CusDataGridViewFormat();
            lblSubCategory1.Text = clsConfig.sItemSubCategory;
            lblSubCategory2.Text = clsConfig.sItemSubCategory2;
            try
            {                
                clsHelpMethods_Local.SetItemImage(glbItemID, ref pbxImage);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
            if (glbItemID.Length > 0 && glbItemSubCategoryID1.Length > 0 && glbItemSubCategoryID2.Length > 0 && glbItemSerialNo1.Length > 0 && glbItemSerialNo2.Length > 0)
            {
                FillDetails(glbItemID, glbItemSubCategoryID1, glbItemSubCategoryID2, glbItemSerialNo1, glbItemSerialNo2);

            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailStore, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            dgvDetailStore.Columns["ActualQuantity"].DefaultCellStyle.ForeColor = Color.Red;
            dgvDetailStore.Columns["WasteageQuantity"].DefaultCellStyle.ForeColor = Color.Red;
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
            lblSubCategory.Text = "";
            txtSerialNo1.Text = "";
            txtSerialNo2.Text = "";
            txtSubCategory1.Text = "";
            txtSubCategory2.Text = "";           
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode, string sSubCategoryID1, string sSubCategoryID2, string sSerial1, string sSerial2)
        {
            tbl_genItemMaster Details = tbl_genItemMaster.Select(sItemCode);
            if (Details != null)
            {
                RefreshGridStoreStock(sItemCode, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);
                RefreshGridSectionStock(sItemCode, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);
                RefreshGridDepartmentStock(sItemCode, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);

                lblReOrderLevel.Text = clsFormatter.FormatDecimalPlaces_Quantity(Details.ReReoverLevel);
                lblReOrderQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(Details.ReOrderQty);
                lblAllStoreBalance.Text = clsFormatter.FormatDecimalPlaces_Quantity(clsHelpMethods.GetQty_AllStoresBalance(Details.Item_ID, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2));
                lblMinPRQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(clsHelpMethods.GetQty_MinimumPR(Details.Item_ID, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2));

                if (sSerial1 == "0")
                    sSerial1 = "N/A";
                if (sSerial2 == "0")
                    sSerial2 = "N/A";
                if (sSubCategoryID1 == "default")
                    sSubCategoryID1 = "N/A";
                else
                    sSubCategoryID1 = clsGenaralName.getName_ItemSubCategory(sSubCategoryID1);
                if (sSubCategoryID2 == "default")
                    sSubCategoryID2 = "N/A";
                else
                    sSubCategoryID2 = clsGenaralName.getName_ItemSubCategory(sSubCategoryID2);

                lblMaterialCategory.Text = clsGenaralName.getName_ItemCategory(Details.ItemCategory_ID);
                lblMaterialClass.Text = clsGenaralName.getName_ItemClass(Details.ItemClass_ID);
                lblMaterialID.Text = Details.Item_ID;
                lblMaterialName.Text = clsGenaralName.getName_Item(Details.Item_ID);
                lblMaterialType.Text = clsGenaralName.getName_ItemType(Details.ItemType_ID);               
                lblSubCategory.Text = Details.ItemCategorySub_ID;
                
                txtSerialNo1.Text =  clsCommon.GetForeignKeyValue(sSerial1);
                txtSerialNo2.Text = clsCommon.GetForeignKeyValue(sSerial2);
                txtSubCategory1.Text = sSubCategoryID1;
                txtSubCategory2.Text = sSubCategoryID2;

               

            
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridStoreStock(string sItemID, string sSubCategoryID1, string sSubCategoryID2, string sSerialNo1, string sSerialNo2)
        {
            try
            {
                string sBranchName = "";
                dgvDetailStore.Rows.Clear();
                foreach (tbl_genStore_Stock detail in tbl_genStore_Stock.SelectAllByItem_ID(sItemID))
                {
                    if (detail.Store_ID != "default" && detail.ItemSubCategory_ID == sSubCategoryID1 && detail.ItemSubCategory2_ID == sSubCategoryID2
                        && detail.ItemSerialNo == sSerialNo1 && detail.ItemSerialNo2 == sSerialNo2)
                    {
                        tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(detail.Store_ID);
                        if (oStore != null)
                            sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                        

                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Store_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Store(detail.Store_ID);
                        dgvDetailStore["Branch", iRow].Value = sBranchName;
                        dgvDetailStore["AvailableQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.AvailableQty);
                        dgvDetailStore["ActualQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                        dgvDetailStore["DamagedQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.AvailableWeight);
                        dgvDetailStore["WasteageQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.Weight);
                    }
                }

                //dgvDetailStore.Columns["StoreID"].Width = 90;
                //dgvDetailStore.Columns["StoreName"].Width = 177;
                //if (dgvDetailStore.Rows.Count > 8)
                //{
                //    dgvDetailStore.Columns["StoreID"].Width -= 6;
                //    dgvDetailStore.Columns["StoreName"].Width -= 10;
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridSectionStock(string sItemID, string sSubCategoryID1, string sSubCategoryID2, string sSerialNo1, string sSerialNo2)
        {
            try
            {
                //dgvDetailStore.Columns["StoreID"].Width = 90;
                //dgvDetailStore.Columns["StoreName"].Width = 177;
                List<tbl_genSection_Stock> SoreStokeDetails = tbl_genSection_Stock.SelectAllByItem_ID(glbItemID);
                foreach (tbl_genSection_Stock detail in SoreStokeDetails)
                {
                    if (detail.Section_ID != "default")
                    {
                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Section_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Section(detail.Section_ID);
                        dgvDetailStore["AvailableQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                        dgvDetailStore["ActualQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.Weight);
                        dgvDetailStore["DamagedQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.DamageWeight);
                        dgvDetailStore["WasteageQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.WasteageWeight);
                    }
                }
                //if (dgvDetailStore.Rows.Count > 8)
                //{
                //    dgvDetailStore.Columns["StoreID"].Width -= 6;
                //    dgvDetailStore.Columns["StoreName"].Width -= 10;
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridDepartmentStock(string sItemID, string sSubCategoryID1, string sSubCategoryID2, string sSerialNo1, string sSerialNo2)
        {
            try
            {
                //dgvDetailStore.Columns["StoreID"].Width = 90;
                //dgvDetailStore.Columns["StoreName"].Width = 177;
                List<tbl_genDepartment_Stock> SoreStokeDetails = tbl_genDepartment_Stock.SelectAllByItem_ID(glbItemID);
                foreach (tbl_genDepartment_Stock detail in SoreStokeDetails)
                {
                    if (detail.Department_ID != "default")
                    {
                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Department_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Department(detail.Department_ID);
                        dgvDetailStore["AvailableQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                        dgvDetailStore["ActualQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.Weight);
                        dgvDetailStore["DamagedQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.DamageWeight);
                        dgvDetailStore["WasteageQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(detail.WasteageWeight);
                    }
                }
                //if (dgvDetailStore.Rows.Count > 8)
                //{
                //    dgvDetailStore.Columns["StoreID"].Width -= 6;
                //    dgvDetailStore.Columns["StoreName"].Width -= 10;
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void tbItemTracking_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                LoadItemTackingData(tbItemTracking.SelectedIndex);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally 
            {
                Cursor = Cursors.Default;
            }
        }
        private void tbItemTracking_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;                
                LoadItemTackingData(tbItemTracking.SelectedIndex);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadItemTackingData(int SelectedIndex)
        {
            string sSerial1 = "", sSerial2 = "", sSubCategoryID1 = "", sSubCategoryID2 = "";
            dgvPurchase.Rows.Clear();
            dgvStock.Rows.Clear();
            dgvSalling.Rows.Clear();

            SetItemInfor(ref sSerial1, ref sSerial2, ref sSubCategoryID1, ref sSubCategoryID2);
            switch (SelectedIndex)
            {
                case 0: RefreshPurchaseGrid(ref sSerial1, ref sSerial2, ref sSubCategoryID1, ref sSubCategoryID2);
                    break;
                case 1: RefreshStockGrid(ref sSerial1, ref sSerial2, ref sSubCategoryID1, ref sSubCategoryID2);
                    break;
                case 2: RefreshSellingGrid(ref sSerial1, ref sSerial2, ref sSubCategoryID1, ref sSubCategoryID2);
                    break;
            }

        }

        private void SetItemInfor(ref string sSerial1,ref string sSerial2,ref string sSubCategoryID1,ref string sSubCategoryID2)
        {  
            if (txtSerialNo1.Text == "N/A")
                sSerial1 = "0";
            else
                sSerial1 = txtSerialNo1.Text;
            if (txtSerialNo2.Text == "N/A")
                sSerial2 = "0";
            else
                sSerial2 = txtSerialNo2.Text;
            if (txtSubCategory1.Text == "N/A")
                sSubCategoryID1 = "default";
            else
                sSubCategoryID1 = txtSubCategory1.Text;
            if (txtSubCategory2.Text == "N/A")
                sSubCategoryID2 = "default";
            else
                sSubCategoryID2 = txtSubCategory2.Text;
        }

        private void RefreshPurchaseGrid(ref string sSerial1, ref string sSerial2, ref string sSubCategoryID1, ref string sSubCategoryID2)
        {           
            clsPurches objPurches = new clsPurches(lblMaterialID.Text, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);            
            foreach (DataRow row in clsPurches.dt_Purchase.Rows)
            {
                dgvPurchase.Rows.Add(row["TransectionID"], row["Date"], row["StoreName"], row["BranchName"], row["Qty"], row["Weight"]);
            }
        }
        private void RefreshStockGrid(ref string sSerial1, ref string sSerial2, ref string sSubCategoryID1, ref string sSubCategoryID2)
        {            
            clsStock objStore = new clsStock(lblMaterialID.Text, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);            
            foreach (DataRow row in clsStock.dt_Stock.Rows)
            {
                dgvStock.Rows.Add(row["TransectionID"], row["Date"], row["StoreName"], row["BranchName"], row["Qty"], row["Weight"]);
            }
        }
        private void RefreshSellingGrid(ref string sSerial1, ref string sSerial2, ref string sSubCategoryID1, ref string sSubCategoryID2)
        {
            clsSelling objSelling = new clsSelling(lblMaterialID.Text, sSubCategoryID1, sSubCategoryID2, sSerial1, sSerial2);            
            foreach (DataRow row in clsSelling.dt_Selling.Rows)
            {
                dgvSalling.Rows.Add(row["TransectionID"], row["Date"], row["StoreName"], row["BranchName"], row["Qty"], row["Weight"]);
            }
        }
    }

    public class clsPurches : frmItemViewer
    {
        public static DataTable dt_Purchase = new DataTable("tbl_Purchase");
        public string sItemID, sItemSubCategory_ID, sItemSubCategory_ID2, sItemSerialNo, sItemSerialNo2;
        public clsPurches(string sIncommingItemID, string sIncommingItemSubCategory_ID, string sIncommingItemSubCategory_ID2, string sIncommingItemSerialNo, string sIncommingItemSerialNo2)
        {
            sItemID = sIncommingItemID; sItemSubCategory_ID = sIncommingItemSubCategory_ID; sItemSubCategory_ID2 = sIncommingItemSubCategory_ID2;
            sItemSerialNo = sIncommingItemSerialNo; sItemSerialNo2 = sIncommingItemSerialNo2;
            Addtbl_PurchaseColumns();
            FilltableByGRN();
        }

        private void Addtbl_PurchaseColumns()
        {
            if (dt_Purchase.Columns.Count == 0)
            {
                dt_Purchase.Columns.Add("TransectionID", typeof(string));
                dt_Purchase.Columns.Add("Date", typeof(string));
                dt_Purchase.Columns.Add("StoreName", typeof(string));
                dt_Purchase.Columns.Add("BranchName", typeof(string));
                dt_Purchase.Columns.Add("Qty", typeof(decimal));
                dt_Purchase.Columns.Add("Weight", typeof(decimal));
            }
        }
        private void FilltableByGRN()
        {           
            dt_Purchase.Rows.Clear();
            foreach (tbl_scsExternalGoodReceivedNote oGRN in tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID != "default" && !p.IsDeleted))
            {

                //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                //{
                //    //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem oDetail in tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByItem_ID(sItemID).Where(p => p.ExternalGoodReceivedNote_ID == oGRN.ExternalGoodReceivedNote_ID
                //    //    && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                //    //{
                //    //    string sBranchName = "";
                //    //    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oGRN.Store_ID);
                //    //    if (oStore != null)
                //    //        sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                //    //    dt_Purchase.Rows.Add(oDetail.ExternalGoodReceivedNote_ID, clsFormatter.FormatDate_Short(oGRN.ExternalGoodReceivedNoteDate), clsGenaralName.getName_Store(oGRN.Store_ID), sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.GemQty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.MetalWeight));
                //    //}
                //}
               // else
                    foreach (tbl_scsExternalGoodReceivedNote_Detail oDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByItem_ID(sItemID).Where(p => p.ExternalGoodReceivedNote_ID == oGRN.ExternalGoodReceivedNote_ID
                     && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                    {
                        string sBranchName = "";
                        tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oGRN.Store_ID);
                        if (oStore != null)
                            sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                        dt_Purchase.Rows.Add(oDetail.ExternalGoodReceivedNote_ID, clsFormatter.FormatDate_Short(oGRN.ExternalGoodReceivedNoteDate), clsGenaralName.getName_Store(oGRN.Store_ID), sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.Weight));
                    }
            }
        }
    }

    public class clsStock : frmItemViewer
    {
        public static DataTable dt_Stock = new DataTable("tbl_Stock");
        public string sItemID, sItemSubCategory_ID, sItemSubCategory_ID2, sItemSerialNo, sItemSerialNo2;
        public clsStock(string sIncommingItemID, string sIncommingItemSubCategory_ID, string sIncommingItemSubCategory_ID2, string sIncommingItemSerialNo, string sIncommingItemSerialNo2)
        {
            sItemID = sIncommingItemID; sItemSubCategory_ID = sIncommingItemSubCategory_ID; sItemSubCategory_ID2 = sIncommingItemSubCategory_ID2;
            sItemSerialNo = sIncommingItemSerialNo; sItemSerialNo2 = sIncommingItemSerialNo2;
            Addtbl_PurchaseColumns();
            FilltableByiGIN();
            FilltableByiGRN();
        }

        private void Addtbl_PurchaseColumns()
        {
            if (dt_Stock.Columns.Count == 0)
            {
                dt_Stock.Columns.Add("TransectionID", typeof(string));
                dt_Stock.Columns.Add("Date", typeof(string));
                dt_Stock.Columns.Add("StoreName", typeof(string));
                dt_Stock.Columns.Add("BranchName", typeof(string));
                dt_Stock.Columns.Add("Qty", typeof(decimal));
                dt_Stock.Columns.Add("Weight", typeof(decimal));
            }
        }
        //tbl_scsStoreGoodIssueNote
        private void FilltableByiGIN()
        {           
            dt_Stock.Rows.Clear();
            foreach (tbl_scsStoreGoodIssueNote oiGIN in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreGoodIssueNote_ID != "default" && !p.IsDeleted))
            {
                foreach (tbl_scsStoreGoodIssueNote_Detail oDetail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByItem_ID(sItemID).Where(p => p.StoreGoodIssueNote_ID == oiGIN.StoreGoodIssueNote_ID
                    && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                {
                    string sBranchName = "";
                    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oiGIN.ToStore_ID);
                    if (oStore != null)
                        sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                    dt_Stock.Rows.Add(oDetail.StoreGoodIssueNote_ID, clsFormatter.FormatDate_Short(oiGIN.StoreGoodIssueNoteDate), clsGenaralName.getName_Store(oiGIN.ToStore_ID), sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.Weight));
                }
            }
        }
        //tbl_scsStoreGoodReceiveNote
        private void FilltableByiGRN()
        {            
            foreach (tbl_scsStoreGoodReceiveNote oiGRN in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => p.StoreGoodReceiveNote_ID != "default" && !p.IsDeleted))
            {
                foreach (tbl_scsStoreGoodReceiveNote_Detail oDetail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByItem_ID(sItemID).Where(p => p.StoreGoodReceiveNote_ID == oiGRN.StoreGoodReceiveNote_ID
                    && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                {
                    string sBranchName = "";
                    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oiGRN.ToStore_ID);
                    if (oStore != null)
                        sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                    dt_Stock.Rows.Add(oDetail.StoreGoodReceiveNote_ID, clsFormatter.FormatDate_Short(oiGRN.StoreGoodReceiveNoteDate), clsGenaralName.getName_Store(oiGRN.ToStore_ID), sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.Weight));
                }
            }
        }
    }

    public class clsSelling : frmItemViewer
    {
        public static DataTable dt_Selling = new DataTable("tbl_Selling");
        public string sItemID, sItemSubCategory_ID, sItemSubCategory_ID2, sItemSerialNo, sItemSerialNo2;
        public clsSelling(string sIncommingItemID, string sIncommingItemSubCategory_ID, string sIncommingItemSubCategory_ID2, string sIncommingItemSerialNo, string sIncommingItemSerialNo2)
        {
            sItemID = sIncommingItemID; sItemSubCategory_ID = sIncommingItemSubCategory_ID; sItemSubCategory_ID2 = sIncommingItemSubCategory_ID2;
            sItemSerialNo = sIncommingItemSerialNo; sItemSerialNo2 = sIncommingItemSerialNo2;
            Addtbl_PurchaseColumns();
            FilltableByDO();
        }

        private void Addtbl_PurchaseColumns()
        {
            if (dt_Selling.Columns.Count == 0)
            {
                dt_Selling.Columns.Add("TransectionID", typeof(string));
                dt_Selling.Columns.Add("Date", typeof(string));
                dt_Selling.Columns.Add("StoreName", typeof(string));
                dt_Selling.Columns.Add("BranchName", typeof(string));
                dt_Selling.Columns.Add("Qty", typeof(decimal));
                dt_Selling.Columns.Add("Weight", typeof(decimal));
            }
        }
        //tbl_sasDeliveryOrder
        private void FilltableByDO()
        {
            dt_Selling.Rows.Clear();
            foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAll().Where(p => p.DeliveryOrder_ID != "default" && !p.IsDeleted))
            {
                foreach (tbl_sasDeliveryOrder_Detail oDetail in tbl_sasDeliveryOrder_Detail.SelectAllByItem_ID(sItemID).Where(p => p.DeliveryOrder_ID == oDO.DeliveryOrder_ID
                    && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                {
                    string sBranchName = "";
                    tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oDO.Store_ID);
                    if (oStore != null)
                        sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                    dt_Selling.Rows.Add(oDetail.DeliveryOrder_ID, clsFormatter.FormatDate_Short(oDO.DeliveryOrderDate), clsGenaralName.getName_Store(oDO.Store_ID), sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.Weight));
                }
            }
        }
        //tbl_sasInvoice
        private void FilltableByInvoice()
        {
            dt_Selling.Rows.Clear();
            foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => p.Invoice_ID != "default" && !p.IsDeleted))
            {
                foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByItem_ID(sItemID).Where(p => p.Invoice_ID == oInvoice.Invoice_ID
                    && p.ItemSubCategory_ID == sItemSubCategory_ID && p.ItemSubCategory2_ID == sItemSubCategory_ID2 && p.ItemSerialNo == sItemSerialNo && p.ItemSerialNo2 == sItemSerialNo2))
                {
                    string sBranchName = "";
                    //tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oiGIN.ToStore_ID);
                    //if (oStore != null)
                    //    sBranchName = clsGenaralName.getName_CompanyBranchMaster(oStore.CompanyBranch_ID);
                    dt_Selling.Rows.Add(oDetail.Invoice_ID, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), ""/* clsGenaralName.getName_Store(oInvoice.Store_ID)*/, sBranchName, clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty), clsFormatter.FormatDecimalPlaces_Weight(oDetail.Weight));
                }
            }
        }
    }
}