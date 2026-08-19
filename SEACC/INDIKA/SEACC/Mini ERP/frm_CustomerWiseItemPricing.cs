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
using SEACC.DATA.Data;
using System.Reflection;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.CustomerWisePricing;
using SEACC.WinFormControls.Forms;
using SEACC.DATA.Data.MAS;

namespace Digiteq
{
    public partial class frm_CustomerWiseItemPricing : MettroForm
    {
        #region Variables   


        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        masCustomerWiseItemPricingData dataObject = new masCustomerWiseItemPricingData();
        #endregion

        #region Form Load
        public frm_CustomerWiseItemPricing()
        {
            iFormID = clsSecurity.getFormID(FormName.CustomerWiseItemPricing);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masItemMasterFinance_Load(object sender, EventArgs e)
        {
            dgvDetail.DataSource = source;
            CreateDataTable();

            ClearFields();
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            txtCustomer.Tag = null;
            txtCustomer.Clear();
            txtItemCode.Clear();
            txtItemName.Clear();
        }
        #endregion


        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        var List = new List<masCustomerWiseItemPricing_Save>();
                        var Customer_ID = txtCustomer.Tag.ToString();
                        string sitem_ID = "";
                        decimal dIsVATInclusive = 0,dMaxDisc=0;
                        bool Active = false;

                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            sitem_ID = clsValidate.ValidateGridValue(dgvDetail, "item_ID", row.Index, "");
                            dIsVATInclusive = clsValidate.ValidateGridValue(dgvDetail, "SellingPrice", row.Index, 0M);
                            dMaxDisc = clsValidate.ValidateGridValue(dgvDetail, "maxDiscount", row.Index, 0M);
                            Active = clsValidate.ValidateGridValue(dgvDetail, "Active", row.Index, false);

                            var item = new masCustomerWiseItemPricing_Save();
                            item.item_ID = sitem_ID;
                            item.customer_ID = Customer_ID;
                            item.SellingPrice = dIsVATInclusive;
                            item.maxDiscount = Active? dMaxDisc:-1;

                            List.Add(item);
                        }

                    var    result= dataObject.SaveDetails(List, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.getServerDateTime());
                        if (result.IsSuccess)
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var CustomerId = txtCustomer.Tag.ToString();
                dtAllRecodes=Cast.ToDataTables( dataObject.GetDetails(CustomerId));
             
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

            if (txtCustomer.Tag == null)
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
                sFilteQuary = " item_ID LIKE '%" + txtItemCode.Text.Trim() + "%'";
                sFilteQuary += ((sFilteQuary.Trim().Length > 0)?" AND ":"")+ " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";

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
            clsSearch.Search_MasterCustomer(ref txtCustomer, false);
            if (txtCustomer.Tag != null)
                RefreshGrid();
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
    }
}