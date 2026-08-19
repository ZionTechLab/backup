using System;
using System.Collections.Generic;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasMultipleItemSelect : Form
    {
        #region Variables
        public List<clsTmpMultipleSelectedItems> lstclsTmpMultipleSelectedItems = new List<clsTmpMultipleSelectedItems>();
        public string glb_sItemPriceCategory;
        public string glb_sStoreID = "";        
        public bool glb_bStockValidate_ManuallyDisable = false;
        int glb_iLeavingCell_RowIndex = 0;
        bool bIsAddEmptyRow = true;
        #endregion

        #region Form Load
        public frm_sasMultipleItemSelect()
        {
            InitializeComponent();
        }

        private void frm_sasOpeningBalance_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "QCE Screen", 2, 0);
            CusDataGridViewFormat();

          
            dgvDetail.Focus();
            dgvDetail.Rows.Add();        
            dgvDetail["ItemCode", 0].Selected = true;         
        } 
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvDetail_KeyUp(dgvDetail , new KeyEventArgs(Keys.Return));

            if (Validate_SRNQty())
            {
                lstclsTmpMultipleSelectedItems.Clear();
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dgvDetail.Rows[row.Index].Selected = true;
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                    string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                    string sItemSubCategoryID1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    string sItemSubCategoryID2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    string sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    string sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                    string sUOMID = clsValidate.ValidateGridValue(dgvDetail, "UOMID", row.Index, "");
                    decimal dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                    decimal dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    decimal dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                    decimal dItemTotalValue = clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));
                    bool bIsNewItem = true;
                    foreach (clsTmpMultipleSelectedItems repeat_Item in lstclsTmpMultipleSelectedItems)
                    {
                        if (repeat_Item.sItemID == sItemCode)
                        {
                            bIsNewItem = false;
                            repeat_Item.dWeight += dWeight;
                            repeat_Item.dQty += dQuantity;
                            repeat_Item.dTotalAmount += dItemTotalValue;
                        }
                    }


                    if (sItemName.Length > 0 && bIsNewItem)
                    {
                        clsTmpMultipleSelectedItems oclsTmpMultipleSelectedItems = new clsTmpMultipleSelectedItems();                        
                        oclsTmpMultipleSelectedItems.sItemID = sItemCode;
                        oclsTmpMultipleSelectedItems.sItemSubCategoryID = sItemSubCategoryID1;
                        oclsTmpMultipleSelectedItems.sItemSubCategoryID2 = sItemSubCategoryID2;
                        oclsTmpMultipleSelectedItems.sItemSerialNo = sItemSerialNo1;
                        oclsTmpMultipleSelectedItems.sItemSerialNo2 = sItemSerialNo2;
                        oclsTmpMultipleSelectedItems.dWeight = dWeight;
                        oclsTmpMultipleSelectedItems.dQty = dQuantity;                        
                        oclsTmpMultipleSelectedItems.dUnitPrice = dUnitPrice;
                        oclsTmpMultipleSelectedItems.dWeight = dWeightPrice;
                        oclsTmpMultipleSelectedItems.dTotalAmount = dItemTotalValue;
                        oclsTmpMultipleSelectedItems.sUOMID = sUOMID;
                        lstclsTmpMultipleSelectedItems.Add(oclsTmpMultipleSelectedItems);
                    }
                    
                }
                
                this.Close(); 
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTotalQty.Text = "0";
            txtTotalAmount.Text = "0";

            lstclsTmpMultipleSelectedItems.Clear();
            dgvDetail.Rows.Clear();
            dgvDetail.Rows.Add();
        }
        #endregion     


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);            
        }
        #endregion    

        private bool Validate_SRNQty()
        {
            bool bValue = true;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                //decimal dAvailableQty = clsValidate.ValidateGridValue(dgvDetail, "gQty_Available", row.Index, decimal.Parse("0.00"));
                //decimal dSRNQty = clsValidate.ValidateGridValue(dgvDetail, "gQty_SRN", row.Index, decimal.Parse("0.00"));

                //if (dAvailableQty < dSRNQty)
                //{
                //    bValue = false;
                //    MessageBox.Show("SRN Qty Cannot Be Greater Than Available Qty", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    break;
                //}

            }
            return bValue;
        }
       

        #region Events KeyDown
        private void frm_sasMultipleItemSelect_SRN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnNew_Click(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnSave_Click(sender, new EventArgs());
            }
        } 
        #endregion

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int iRowIndex = dgvDetail.CurrentCell.RowIndex;
                int iColIndex = dgvDetail.CurrentCell.ColumnIndex;                
                if (iRowIndex >= 0)
                {
                    string sColName = "";
                    DataGridView dgv = (DataGridView)sender;
                    sColName = dgv.Columns[iColIndex].Name;

                    if (sColName == "ItemCode")
                    {
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", iRowIndex, "default");
                        if (sItemCode != "default" && sItemCode != "")
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemCode);
                            if (oItem != null && oItem.Item_ID != "default" && !oItem.IsDeleted)
                            {
                                //validate duplicate Items
                                bool bItemDuplicateValidateValid = true;
                                if (clsConfig.bItemSearch_ValidateAddingDuplicateItem)
                                {
                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                    {
                                        if (iRowIndex != row.Index)
                                        {
                                            string sTmpItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                                            if (sTmpItemCode == oItem.Item_ID)
                                            {
                                                bItemDuplicateValidateValid = false;
                                                MessageBox.Show("Duplicate Item Code, Please Enter Different Item Code", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                dgvDetail["ItemCode", iRowIndex].Selected = true;
                                                dgvDetail["ItemCode", iRowIndex].Value = "";
                                            }
                                        }
                                    }
                                }
                                if (bItemDuplicateValidateValid)
                                {
                                    dgvDetail["ItemCode", iRowIndex].Value = oItem.Item_ID;
                                    dgvDetail["ItemName", iRowIndex].Value = oItem.ItemName;
                                    dgvDetail["ItemSerialNo1", iRowIndex].Value = "0";
                                    dgvDetail["ItemSerialNo2", iRowIndex].Value = "0";
                                    dgvDetail["ItemSubCategoryID1", iRowIndex].Value = "default";
                                    dgvDetail["ItemSubCategoryID2", iRowIndex].Value = "default";
                                    dgvDetail["UOMID", iRowIndex].Value = oItem.Uom_ID;

                                    decimal dStockQty = 0;
                                    if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                    {
                                        tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                        if (oStock != null)
                                        {
                                            dStockQty = oStock.Qty;
                                        }
                                    }
                                    dgvDetail["QuantityAvailable", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dStockQty);
                                    dgvDetail["Quantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                    dgvDetail["Weight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);

                                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Basic(oItem.Item_ID, glb_sItemPriceCategory);
                                    dgvDetail["UnitPrice", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                                    dgvDetail["WeightPrice", iRowIndex].Value = 0;
                                    dgvDetail["ItemTotalValue", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Price(dUnitPrice);

                                    dgvDetail["Quantity", iRowIndex].Selected = true;
                                    bIsAddEmptyRow = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Item Code, Please A Valid Item Code", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDetail["ItemCode", iRowIndex].Selected = true;
                                dgvDetail["ItemCode", iRowIndex].Value = "";
                            }
                        }
                    }
                    else if (sColName == "Quantity")
                    {
                        //dgvDetail.Refresh();
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", iRowIndex, "default");
                        decimal dQuentity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", iRowIndex, decimal.Parse("0.00"));
                        decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", iRowIndex, decimal.Parse("0.00"));
                        decimal dTotalAmount = dQuentity * dUnitPrice;
                       
                        //Validate Stock
                        bool bStockValidated = false;
                        if (dQuentity != 0)
                        {
                            if (clsConfig.bValidateStock_WhenAddingMultipleItems && !glb_bStockValidate_ManuallyDisable)
                            {
                                if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                {
                                    tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                    if (oStock != null)
                                    {
                                        if (dQuentity <= oStock.Qty)
                                            bStockValidated = true;
                                    }
                                }
                            }
                            else
                                bStockValidated = true;

                            if (bStockValidated)
                            {
                                dgvDetail["ItemTotalValue", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);

                                if (bIsAddEmptyRow)
                                {
                                    dgvDetail.Rows.Add();
                                    dgvDetail["ItemCode", (iRowIndex + 1)].Selected = true;
                                    bIsAddEmptyRow = false;
                                }
                            }
                            else
                            {
                                dgvDetail["Quantity", iRowIndex].Value = 0;
                                MessageBox.Show("Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(glb_sStoreID) + " Stock\n", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                e.Handled = true;
                            }
                        }
                    }
                }
                CalculateTotals();
            }

            if (e.KeyData == Keys.Tab)
                dgvDetail.CurrentCell.Selected = true;
        }

        private void CalculateTotals()
        {
            decimal dQuantity = 0, dTotalAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dQuantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                dTotalAmount += clsValidate.ValidateGridValue(dgvDetail, "ItemTotalValue", row.Index, decimal.Parse("0.00"));                
            }
            txtTotalQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
            txtTotalAmount.Text = clsFormatter.FormatDecimalPlaces_Quantity(dTotalAmount);
        }
       
        private void dgvDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetail.IsCurrentCellDirty)
            {
                dgvDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dgvDetail.CurrentCell.Value != null && dgvDetail.CurrentCell.Value.ToString() != "-")
                {
                    int iRowIndex = dgvDetail.CurrentCell.RowIndex;
                    int iColIndex = dgvDetail.CurrentCell.ColumnIndex;
                    string sColName = dgvDetail.Columns[iColIndex].Name;
                    if (sColName == "Quantity")
                    {                       
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", iRowIndex, "default");
                        decimal dQuentity = decimal.Parse(dgvDetail.CurrentCell.Value.ToString());
                        decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", iRowIndex, decimal.Parse("0.00"));
                        decimal dTotalAmount = dQuentity * dUnitPrice;

                        bool bStockValidated = false;
                        if (dQuentity != 0)
                        {
                            if (clsConfig.bValidateStock_WhenAddingMultipleItems && !glb_bStockValidate_ManuallyDisable)
                            {
                                if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                {
                                    tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                    if (oStock != null)
                                    {
                                        if (dQuentity <= oStock.Qty)
                                            bStockValidated = true;
                                    }
                                }
                            }
                            else
                                bStockValidated = true;

                            if (bStockValidated)
                            {
                                dgvDetail["ItemTotalValue", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);
                            }
                            else
                            {
                                dgvDetail["Quantity", iRowIndex].Value = 0;
                                MessageBox.Show("Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(glb_sStoreID) + " Stock\n", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                        }
                    }
                    CalculateTotals();
                }
            }
        }
    }

    public class clsTmpMultipleSelectedItems
    {
        public int iLineNo;
        public string sItemID;
        public string sItemSubCategoryID;
        public string sItemSubCategoryID2;
        public string sItemSerialNo;
        public string sItemSerialNo2;
        public string sUOMID;       
        public decimal dQty;
        public decimal dUnitPrice;
        public decimal dWeight;
        public decimal dWeightPrice;
        public decimal dTotalAmount;
    }
}