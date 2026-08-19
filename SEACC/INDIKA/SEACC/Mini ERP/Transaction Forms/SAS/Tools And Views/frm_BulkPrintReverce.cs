using DataTire;
using Digiteq_Logic;
using SEACC.DATA.Data.SAS;
using SEACC.DATA.Domain;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.SAS.Tools_And_Views
{
    public partial class frm_BulkPrintReverce : MettroForm
    {
        SasDeliveryOrder_data data = new SasDeliveryOrder_data();



        public frm_BulkPrintReverce()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusDeliveryOrder_BulkPrint_Reverce);
            iFormID = clsSecurity.getFormID(FormName.CusDeliveryOrder_BulkPrint_Reverce);

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_BulkPrintReverce_Load(object sender, EventArgs e)
        {
            gridRoute.AutoGenerateColumns = false;
            var oRoute = tbl_genRoute.SelectAll().Where(p => p.Route_ID != -1).ToList();
            gridRoute.DataSource = oRoute;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string RouteList = "";
                foreach (DataGridViewRow row in gridRoute.Rows)
                {
                    var IsSelect = clsValidate.ValidateGridValue(gridRoute, "select1", row.Index, false);
                    if (IsSelect)
                    {
                        RouteList += (RouteList != "" ? "," : "") + clsValidate.ValidateGridValue(gridRoute, "route_ID", row.Index, "");
                    }
                }

                dgvMain.DataSource = DBHandling.ExecQuery("Exec sp_Get_DeleveryOrders '" + dtpCashFrom.Value.Date + "','" + dtpCashTo.Value.Date + "','" + RouteList + "'," + 2).Tables[0];
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }

        private void btnReverce_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Are you sure to reverce the transaction?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (msgResult == DialogResult.Yes)
            {
                var str = new List<StringArray>();

                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    var IsSelect = clsValidate.ValidateGridValue(dgvMain, "select", row.Index, false);

                    if (IsSelect)
                        str.Add(new StringArray { S = clsValidate.ValidateGridValue(dgvMain, "Invoice_ID", row.Index, "") });
                }

                var x = data.Reverce_BulkPrint(str, iFormID, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                MessageBox.Show(x.OutMsg);
                if (x.IsSuccess)
                {
                    btnRefresh_Click(null, null);
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoute.Rows)
            {
                row.Cells["Select1"].Value = chkAll.Checked;
            }
        }

        private void chkAll_Inv_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                row.Cells["Select"].Value = chkAll_Inv.Checked;
            }
        }
    }
}
