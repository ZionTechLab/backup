using DataTire;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SAS;
using Digiteq_Logic;
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
using ZION.ERP.Reports.DataSets.SAS;

namespace Digiteq
{
    public partial class frm_DOBulkPrint : MettroForm
    {
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;
        dts_sasInvoice glb_dtsSalesInvoice = new dts_sasInvoice();
        dts_Unspecified glb_dts_sasDeliveryOrder = new dts_Unspecified();

        public frm_DOBulkPrint()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusDeliveryOrder_BulkPrint);
            iFormID = clsSecurity.getFormID(FormName.CusDeliveryOrder_BulkPrint);
           
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
    private void frm_DOBulkPrint_Load(object sender, EventArgs e)
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

                dgvMain.DataSource = DBHandling.ExecQuery("Exec sp_Get_DeleveryOrders '" + dtpCashFrom.Value.Date + "','" + dtpCashTo.Value.Date + "','"+ RouteList + "'," + (chkNotDeliverd.Checked?"1":"0") ).Tables[0];
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            glb_dts_sasDeliveryOrder.Clear();
            string DoList = "", InvList="";
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                var IsSelect = clsValidate.ValidateGridValue(dgvMain, "select", row.Index, false);
             
                if (IsSelect)
                {
                    DoList += (DoList != "" ? "," : "") + clsValidate.ValidateGridValue(dgvMain, "deliveryOrder_ID", row.Index, "");
                      InvList += (InvList != "" ? "," : "") + clsValidate.ValidateGridValue(dgvMain, "Invoice_ID", row.Index, "");
                }
            }

            int iReport = 20003;
            enum_ReportName Report = (enum_ReportName)iReport;
            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            {
                Cursor = Cursors.WaitCursor; 
                string sQuary2 = "exec sp_Getrpt_Invoice_S '" + InvList + "'";
                var x = DBHandling.ExecQuery_ReturnString(sQuary2);
                string sDaterange = "From  : " + dtpCashFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO : " + dtpCashTo.Value.Date.ToString("dd-MMM-yyyy");
                glb_dts_sasDeliveryOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, x);

                dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                string sQuary = "exec sp_GetRPT_sasDeliveryOrder_BulkPrint '" + DoList + "'";
              

                glb_dts_sasDeliveryOrder.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                CRViwer.print(sReportPath, glb_dts_sasDeliveryOrder, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));

                Cursor = Cursors.Default;
            }
            btnRefresh_Click(null, null);
        }

    

        private void btnSummary_Click(object sender, EventArgs e)
        {
            glb_dtsSalesInvoice.Clear();

            string InvList = "";
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                var IsSelect = clsValidate.ValidateGridValue(dgvMain, "select", row.Index, false);
                if (IsSelect)
                {
                    InvList += (InvList != "" ? "," : "") + clsValidate.ValidateGridValue(dgvMain, "Invoice_ID", row.Index, "");
                }
            }
            int iReport = 20004;
            enum_ReportName Report = (enum_ReportName)iReport;
            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";

            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            {
                string sDaterange = "From  : " + dtpCashFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO : " + dtpCashTo.Value.Date.ToString("dd-MMM-yyyy");
                Cursor = Cursors.WaitCursor;

                glb_dtsSalesInvoice.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDaterange, clsSecurity.UserNameLoged, "Delevery order list : " + InvList);

                dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                string sQuary = "exec sp_Getrpt_Invoice '" + InvList + "'";

                glb_dtsSalesInvoice.dt_sasInvoice.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                CRViwer.print(sReportPath, glb_dtsSalesInvoice, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));

                Cursor = Cursors.Default;
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