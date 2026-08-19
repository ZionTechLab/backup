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
using SEACC.DATA.Data.MAS;

namespace Digiteq
{
    public partial class frm_routeWiseItemPricing : MettroForm
    {
        #region Variables   


        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        masRouteWiseItemPricingData dataObject = new masRouteWiseItemPricingData();
        #endregion

        #region Form Load
        public frm_routeWiseItemPricing()
        {
            iFormID = clsSecurity.getFormID(FormName.RouteWiseItemPricing);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;


                InitializeComponent();
        }
        public frm_routeWiseItemPricing(FormName enm)
        {
            iFormID = clsSecurity.getFormID(enm);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

          

            InitializeComponent();
            if (enm != FormName.RouteWiseItemPricing)
                dgvDetail.Columns["maxDiscount"].Visible = false;
            else
            {
                dgvDetail.Columns["SellingPrice"].Visible = false;
                this.Text = "Route Wise Item Discount";
            }
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
            txtRoute.Tag = null;
            txtRoute.Clear();
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
                        var List = new List<masRouteWiseItemPricing_Save>();
                        var route_ID = int.Parse(txtRoute.Tag.ToString());
                        string sitem_ID = "";
                        decimal dIsVATInclusive = 0,dMaxDisc=0;

                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            sitem_ID = clsValidate.ValidateGridValue(dgvDetail, "item_ID", row.Index, "");
                            dIsVATInclusive = clsValidate.ValidateGridValue(dgvDetail, "SellingPrice", row.Index, 0M);
                            dMaxDisc = clsValidate.ValidateGridValue(dgvDetail, "maxDiscount", row.Index, 0M);

                            var item = new masRouteWiseItemPricing_Save();
                            item.item_ID = sitem_ID;
                            item.route_ID = route_ID;
                            item.SellingPrice = dIsVATInclusive;
                            item.maxDiscount = dMaxDisc;

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

                int RouteId = int.Parse(txtRoute.Tag.ToString());
                dtAllRecodes=Cast.ToDataTables( dataObject.GetDetails(RouteId));
             
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
            dtAllRecodes.Columns.Add("route_ID", typeof(int));
            dtAllRecodes.Columns.Add("SellingPrice", typeof(string));
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtRoute.Tag == null)
            { 
                bStatus = false;
                strMessage = "Route";
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
            clsSearch.Search_MasterRoute(ref txtRoute);
            if (txtRoute.Tag != null)

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

    }
}