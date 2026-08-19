using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.SCS.Tools_And_Views
{
    public partial class frm_scsMultipleItemSelect_SplitNote : Form
    {
        #region Variables
        public List<clsTmpMultipleSelectedItems_ItemSplit> lstclsTmpMultipleSelectedItems = new List<clsTmpMultipleSelectedItems_ItemSplit>();
        public string glb_sItemPriceCategory;
        public string glb_sStoreID = "";
        public bool glb_bStockValidate_ManuallyDisable = false;
        int glb_iLeavingCell_RowIndex = 0;
        bool bIsAddEmptyRow = true;
        #endregion

        #region Form
        public frm_scsMultipleItemSelect_SplitNote()
        {
            InitializeComponent();
        }
        private void frm_scsMultipleItemSelect_SplitNote_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "QCE Screen", 2, 0);
            CusDataGridViewFormat();

            dgvDetail.Focus();
            dgvDetail.Rows.Add();
            dgvDetail["ItemCode", 0].Selected = true;
        }
        private void frm_scsMultipleItemSelect_SplitNote_KeyDown(object sender, KeyEventArgs e)
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

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        #region Action Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvDetail_KeyUp(dgvDetail, new KeyEventArgs(Keys.Return));
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
                decimal dInputQty = clsValidate.ValidateGridValue(dgvDetail, "InputQuantity", row.Index, decimal.Parse("0.00"));
                decimal dInputWeight = clsValidate.ValidateGridValue(dgvDetail, "InputWeight", row.Index, decimal.Parse("0.0000"));
                decimal dOutputQty = clsValidate.ValidateGridValue(dgvDetail, "OutputQuantity", row.Index, decimal.Parse("0.00"));
                decimal dOutputWeight = clsValidate.ValidateGridValue(dgvDetail, "OutputWeight", row.Index, decimal.Parse("0.0000"));
                bool bIsNewItem = true;
                foreach (clsTmpMultipleSelectedItems_ItemSplit repeat_Item in lstclsTmpMultipleSelectedItems)
                {
                    if (repeat_Item.sItemID == sItemCode)
                    {
                        bIsNewItem = false;
                        repeat_Item.dQty_Input += dInputQty;
                        repeat_Item.dWeight_Input += dInputWeight;
                        repeat_Item.dQty_Output += dOutputQty;
                        repeat_Item.dWeight_Output += dOutputWeight;
                    }
                }


                if (sItemName.Length > 0 && bIsNewItem)
                {
                    clsTmpMultipleSelectedItems_ItemSplit oclsTmpMultipleSelectedItems = new clsTmpMultipleSelectedItems_ItemSplit();
                    oclsTmpMultipleSelectedItems.sItemID = sItemCode;
                    oclsTmpMultipleSelectedItems.sItemSubCategoryID = sItemSubCategoryID1;
                    oclsTmpMultipleSelectedItems.sItemSubCategoryID2 = sItemSubCategoryID2;
                    oclsTmpMultipleSelectedItems.sItemSerialNo = sItemSerialNo1;
                    oclsTmpMultipleSelectedItems.sItemSerialNo2 = sItemSerialNo2;
                    oclsTmpMultipleSelectedItems.dQty_Input = dInputQty;
                    oclsTmpMultipleSelectedItems.dWeight_Input = dInputWeight;
                    oclsTmpMultipleSelectedItems.dQty_Output = dOutputQty;
                    oclsTmpMultipleSelectedItems.dWeight_Output = dOutputWeight;
                    oclsTmpMultipleSelectedItems.sUOMID = sUOMID;
                    lstclsTmpMultipleSelectedItems.Add(oclsTmpMultipleSelectedItems);
                }

            }
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTotalQty_input.Text = "0.00";
            txtTotalQty_Output.Text = "0.00";
            txtTotalWeight_Input.Text = "0.0000";
            txtTotalWeight_Output.Text = "0.0000";

            lstclsTmpMultipleSelectedItems.Clear();
            dgvDetail.Rows.Clear();
            dgvDetail.Rows.Add();
        }
        #endregion

        #region Grid Event
        private void dgvDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetail.IsCurrentCellDirty)
            {
                dgvDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dgvDetail.CurrentCell.Value != null)
                {
                    int iRowIndex = dgvDetail.CurrentCell.RowIndex;
                    int iColIndex = dgvDetail.CurrentCell.ColumnIndex;
                    string sColName = dgvDetail.Columns[iColIndex].Name;
                    if (sColName == "InputQuantity" || sColName == "InputWeight" || sColName == "OutputQuantity" || sColName == "OutputWeight")
                    {
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", iRowIndex, "default");

                        decimal dQty_Input = clsValidate.ValidateGridValue(dgvDetail, "InputQuantity", iRowIndex, decimal.Parse("0.00"));
                        decimal dWeight_Input = clsValidate.ValidateGridValue(dgvDetail, "InputWeight", iRowIndex, decimal.Parse("0.0000"));
                        decimal dQty_Output = clsValidate.ValidateGridValue(dgvDetail, "OutputQuantity", iRowIndex, decimal.Parse("0.00"));
                        decimal dWeight_Output = clsValidate.ValidateGridValue(dgvDetail, "OutputWeight", iRowIndex, decimal.Parse("0.0000"));

                        bool bStockValidated = false;

                        if (dQty_Input != 0 || dWeight_Input != 0)
                        {
                            if (clsConfig.bValidateStock_WhenAddingMultipleItems && !glb_bStockValidate_ManuallyDisable)
                            {
                                if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                {
                                    tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                    if (oStock != null)
                                    {
                                        if (dQty_Input <= oStock.Qty)
                                            bStockValidated = true;
                                        else if (dWeight_Input <= oStock.Weight)
                                            bStockValidated = true;
                                    }
                                }
                            }
                            else
                                bStockValidated = true;

                            if (bStockValidated)
                            {
                                dgvDetail["InputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQty_Input);
                                dgvDetail["InputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Input);
                                dgvDetail["OutputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQty_Output);
                                dgvDetail["OutputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Output);
                            }
                            else
                            {
                                dgvDetail["InputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                dgvDetail["InputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);
                                dgvDetail["OutputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                dgvDetail["OutputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);
                                MessageBox.Show("Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(glb_sStoreID) + " Stock\n", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    CalculateTotals();
                }
            }
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
                                    dgvDetail["UOMID", iRowIndex].Value = clsGenaralName.getName_Uom(oItem.Uom_ID);

                                    decimal dStockQty = 0;
                                    if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                    {
                                        tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                        if (oStock != null)
                                        {
                                            dStockQty = oStock.Qty;
                                        }
                                    }

                                    dgvDetail["AvailableQty", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dStockQty);
                                    dgvDetail["InputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                    dgvDetail["InputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);
                                    dgvDetail["OutputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                    dgvDetail["OutputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);

                                    dgvDetail["InputQuantity", iRowIndex].Selected = true;
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
                    else if (sColName == "InputQuantity" || sColName == "InputWeight" || sColName == "OutputQuantity" || sColName == "OutputWeight")
                    {
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", iRowIndex, "default");

                        decimal dQty_Input = clsValidate.ValidateGridValue(dgvDetail, "InputQuantity", iRowIndex, decimal.Parse("0.00"));
                        decimal dWeight_Input = clsValidate.ValidateGridValue(dgvDetail, "InputWeight", iRowIndex, decimal.Parse("0.0000"));
                        decimal dQty_Output = clsValidate.ValidateGridValue(dgvDetail, "OutputQuantity", iRowIndex, decimal.Parse("0.00"));
                        decimal dWeight_Output = clsValidate.ValidateGridValue(dgvDetail, "OutputWeight", iRowIndex, decimal.Parse("0.0000"));

                        bool bStockValidated = false;

                        if (dQty_Input != 0 || dWeight_Input != 0)
                        {
                            if (clsConfig.bValidateStock_WhenAddingMultipleItems && !glb_bStockValidate_ManuallyDisable)
                            {
                                if (glb_sStoreID.Length > 0 && glb_sStoreID != "default" && sItemCode != "default")
                                {
                                    tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(glb_sStoreID, sItemCode, "default", "default", "default", "0", "0");
                                    if (oStock != null)
                                    {
                                        if (dQty_Input <= oStock.Qty)
                                            bStockValidated = true;
                                        else if (dWeight_Input <= oStock.Weight)
                                            bStockValidated = true;
                                    }
                                }
                            }
                            else
                                bStockValidated = true;

                            if (bStockValidated)
                            {
                                dgvDetail["InputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQty_Input);
                                dgvDetail["InputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Input);
                                dgvDetail["OutputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQty_Output);
                                dgvDetail["OutputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Output);

                                if (bIsAddEmptyRow && sColName == "OutputWeight")
                                {
                                    dgvDetail.Rows.Add();
                                    dgvDetail["ItemCode", (iRowIndex + 1)].Selected = true;
                                    bIsAddEmptyRow = false;
                                }
                            }
                            else
                            {
                                dgvDetail["InputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                dgvDetail["InputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);
                                dgvDetail["OutputQuantity", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(0);
                                dgvDetail["OutputWeight", iRowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(0);
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
        #endregion

        private void CalculateTotals()
        {
            decimal dQuantity_Input = 0, dWeight_Input = 0;
            decimal dQuantity_Output = 0, dWeight_Output = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dQuantity_Input += clsValidate.ValidateGridValue(dgvDetail, "InputQuantity", row.Index, decimal.Parse("0.00"));
                dWeight_Input += clsValidate.ValidateGridValue(dgvDetail, "InputWeight", row.Index, decimal.Parse("0.0000"));
                dQuantity_Output += clsValidate.ValidateGridValue(dgvDetail, "OutputQuantity", row.Index, decimal.Parse("0.00"));
                dWeight_Output += clsValidate.ValidateGridValue(dgvDetail, "OutputWeight", row.Index, decimal.Parse("0.0000"));
            }
            txtTotalQty_input.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity_Input);
            txtTotalWeight_Input.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Input);
            txtTotalQty_Output.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity_Output);
            txtTotalWeight_Output.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeight_Output);
        }

        private void label9_Click(object sender, EventArgs e)
        { }
    }

    public class clsTmpMultipleSelectedItems_ItemSplit
    {
        public string sItemID;
        public string sItemSubCategoryID;
        public string sItemSubCategoryID2;
        public string sItemSerialNo;
        public string sItemSerialNo2;
        public string sUOMID;
        public decimal dQty_Input;
        public decimal dWeight_Input;
        public decimal dQty_Output;
        public decimal dWeight_Output;
    }
}
