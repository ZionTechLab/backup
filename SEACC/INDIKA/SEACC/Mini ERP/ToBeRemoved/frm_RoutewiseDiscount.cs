using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using SEACC.DATA.Data;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEACC.DATA.Data.MAS;

namespace Digiteq
{
    public partial class frm_RoutewiseDiscount : MettroForm
    {
        #region Variables   
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;

        //   private BindingSource source = new BindingSource();
        //   public DataTable dtAllRecodes = new DataTable();
        //    private string sFilteQuary = "";

        RouteWiseItemDiscData dataObject = new RouteWiseItemDiscData();
        #endregion
        public frm_RoutewiseDiscount()
        {
            iFormID = clsSecurity.getFormID(FormName.RouteWiseDiscount);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_RoutewiseDiscount_Load(object sender, EventArgs e)
        {
            RefreshGrid();
       //     dgvDetail.DataSource = source;
       //     CreateDataTable();

            //       ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshGrid()
        {
            try
            {
                // dtAllRecodes.Rows.Clear();
                //   sFilteQuary = "";

                //    int RouteId = int.Parse(txtRoute.Tag.ToString());
                dgvDetail.DataSource = Cast.ToDataTables(dataObject.GetDetails());

                //   source.DataSource = dtAllRecodes;
                //    source.Filter = sFilteQuary;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (dgvDetail.Rows.Count==0)
            {
                MessageBox.Show("There is no records to update..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bStatus = false;
            }

            return bStatus;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        var List = new List<RouteWiseItemDisc_Save>();
                        int route_ID = 0;
                     //   string sitem_ID = "";
                       decimal dMaxDiscount = 0;

                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            route_ID = clsValidate.ValidateGridValue(dgvDetail, "route_ID", row.Index, route_ID);
                            dMaxDiscount = clsValidate.ValidateGridValue(dgvDetail, "MaxDisc", row.Index, 0M);

                            var item = new RouteWiseItemDisc_Save();
                         
                            item.route_ID = route_ID;
                            item.MaxDisc = dMaxDiscount;

                            List.Add(item);
                        }

                        var result = dataObject.SaveDetails(List, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.getServerDateTime());
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
