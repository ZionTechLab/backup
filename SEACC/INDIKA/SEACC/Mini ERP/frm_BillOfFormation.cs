using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using SEACC.DATA.Data;
using System.Reflection;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.CustomerWisePricing;
using SEACC.WinFormControls.Forms;
using SEACC.DATA.Data.MAS;
using SEACC.DATA.Data.SCS;

namespace Digiteq
{
    public partial class frm_BillOfFormation : MettroForm
    {
        #region Variables   

        List<rowMeterials> GridData = new List<rowMeterials>();
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        ProductionData dataObject = new ProductionData();
        #endregion

        #region Form Load
        public frm_BillOfFormation()
        {
            iFormID = clsSecurity.getFormID(FormName.Prod_BOMDetails_Production);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masItemMasterFinance_Load(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            var FG = dataObject.get_all_FinishGoods();
            gridFG.DataSource = FG;

            GridData.Clear();
            dgvDetail.DataSource = Cast.ToDataTables(GridData);

            txtFGItem.Tag = null;
            txtFGItem.Clear();
            txtFGStore.Tag = null;
            txtFGStore.Clear();
            txtFGPresentage.Clear();
            txtWItem.Tag = null;
            txtWItem.Clear();
            txtWStore.Tag = null;
            txtWStore.Clear();
            txtWPresentage.Clear();
        }
        #endregion


        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (CheckValidity())
            //{
            //    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
            //    {
            //        try
            //        {
            //            Cursor = Cursors.WaitCursor;
            //            var List = new List<masCustomerWiseItemPricing_Save>();
            //            var Customer_ID = txtFGItem.Tag.ToString();
            //            string sitem_ID = "";
            //            decimal dIsVATInclusive = 0, dMaxDisc = 0;
            //            bool Active = false;

            //            foreach (DataGridViewRow row in dgvDetail.Rows)
            //            {
            //                sitem_ID = clsValidate.ValidateGridValue(dgvDetail, "item_ID", row.Index, "");
            //                dIsVATInclusive = clsValidate.ValidateGridValue(dgvDetail, "SellingPrice", row.Index, 0M);
            //                dMaxDisc = clsValidate.ValidateGridValue(dgvDetail, "maxDiscount", row.Index, 0M);
            //                Active = clsValidate.ValidateGridValue(dgvDetail, "Active", row.Index, false);

            //                var item = new masCustomerWiseItemPricing_Save();
            //                item.item_ID = sitem_ID;
            //                item.customer_ID = Customer_ID;
            //                item.SellingPrice = dIsVATInclusive;
            //                item.maxDiscount = Active ? dMaxDisc : -1;

            //                List.Add(item);
            //            }

            //            var result = dataObject.SaveDetails(List, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.getServerDateTime());
            //            if (result.IsSuccess)
            //            {
            //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        catch (Exception ex)
            //        {
            //            clsValidate.WriteErrorLog("", iFormID, ex);
            //            SEACCException.Show(ex);
            //        }
            //        finally
            //        {
            //            Cursor = Cursors.Default;
            //            RefreshGrid();
            //        }
            //    }
            //}
        }
        #endregion

        #region Btn close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtAllRecodes.Rows.Clear();
                sFilteQuary = "";

                var CustomerId = txtFGItem.Tag.ToString();
                //   dtAllRecodes = Cast.ToDataTables(dataObject.GetDetails(CustomerId));

                source.DataSource = dtAllRecodes;
                source.Filter = sFilteQuary;
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
            dtAllRecodes.Columns.Add("Customer_ID", typeof(int));
            dtAllRecodes.Columns.Add("SellingPrice", typeof(string));
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtFGItem.Tag == null)
            {
                bStatus = false;
                strMessage = "Customer";
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Binding Source Filtering
        private void createFilterQuary()
        {
            try
            {
                sFilteQuary = " item_ID LIKE '%" + txtFGPresentage.Text.Trim() + "%'";
                //     sFilteQuary += ((sFilteQuary.Trim().Length > 0) ? " AND " : "") + " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";

                source.Filter = sFilteQuary;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion



        #region Event Double Click
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion


        #region Event KeyUp
        private void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary();
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary();
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sColName = "";
            if (e.ColumnIndex >= 0)
                sColName = dgvDetail.Columns[e.ColumnIndex].Name;

            if (sColName == "Active")
            {
                var Selected = !clsValidate.ValidateGridValue(dgvDetail, "Active", e.RowIndex, false);
                dgvDetail["Active", e.RowIndex].Value = Selected;

                if (!Selected)
                {
                    dgvDetail["maxDiscount", e.RowIndex].Value = "0.000";
                }
            }

        }

        private void dgvDetail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {


        }

        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal Disc = 0;
            bool Selected = false;

            try
            {
                //  var i = dgvDetail.SelectedRows[0].Index;
                Disc = clsValidate.ValidateGridValue(dgvDetail, "maxDiscount", e.RowIndex, 0m);
                Selected = clsValidate.ValidateGridValue(dgvDetail, "Active", e.RowIndex, false);

                if (!Selected)
                {
                    Disc = 0;
                }
            }
            catch (Exception)
            {

                // -- throw;
            }
            dgvDetail["maxDiscount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(Disc);
        }
        private void LoadFG(string item_ID)
        {
            var FG = dataObject.get_FinishGood(item_ID);
        }
        private void gridFG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item_ID = gridFG.SelectedRows[0].Cells["item_ID"].ToString();
                if (item_ID == "")
                    return;

                LoadFG(item_ID);

            }
        }

        private void txtFGItem_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ItemMaster_FinishGoods(ref txtFGItem);
        }

        private void txtWItem_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ItemMasterByBranch(ref txtWItem);
        }

        private void txtFGStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore_GTN(ref txtFGStore, true);
        }

        private void txtWStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore_GTN(ref txtWStore, true);
        }

        private void txtFGPresentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void txtWPresentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ItemMasterByBranch(ref txtRMitem);
        }

        private void txtRMStore_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore_GTN(ref txtRMStore, true);
        }

        private void txtRMPresentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtRMitem.Tag ==null)
            {
                MessageBox.Show("Row Meterial cannot be blank");
                return;
            }
            if (txtRMStore.Tag == null)
            {
                MessageBox.Show("Row Meterial store cannot be blank");
                return;
            }
            decimal present;
            decimal.TryParse(txtRMPresentage.Text, out  present);
            if (present<=0)
            {
                MessageBox.Show("invalied presentage");
                return;
            }
            var rm = new rowMeterials
            {
                item_ID = txtRMitem.Tag.ToString(),
                itemName = txtRMitem.Text,
                Presenage = txtRMPresentage.Text,
                Store = txtRMStore.Tag.ToString(),
            };
            GridData.Add(rm);
            dgvDetail.DataSource =Cast.ToDataTables( GridData);


            txtRMitem.Clear();
            txtRMitem.Tag = null;
            txtRMStore.Clear();
            txtRMStore.Tag = null;
            txtRMPresentage.Clear();
        }
    }
    public class rowMeterials
    {
        public string item_ID { get; set; }
        public string itemName { get; set; }
        public string Presenage { get; set; }
        public string Store { get; set; }
    }
}