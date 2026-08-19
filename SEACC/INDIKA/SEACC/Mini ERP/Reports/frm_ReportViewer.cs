using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;

namespace Digiteq
{
    public partial class frm_ReportViewer : Form
    {
        private int sReportID;
        public frm_ReportViewer()
        {
            InitializeComponent();

            foreach (Control control in crystalReportViewer1.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {
                    ToolStripItem tsItem = ((ToolStrip)control).Items[1];
                    tsItem.Click += new EventHandler(tsItem_Click);

                    ToolStripItem tsItems = ((ToolStrip)control).Items[0];
                    tsItems.Click += new EventHandler(tsItems_Click);
                }
            }
        }

        private void tsItems_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Export");
        }

        private void tsItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Print");
            //if (sReportID != null)
            //{
            //    tbl_atlProcess_Print detail = new tbl_atlProcess_Print(sReportID, 0, "default", "1", clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //    detail.Insert();
            //}
        }

        public void Process_Print(int sReport_ID)
        {
            //MessageBox.Show("Print  ", sForm_ID.ToString());
            this.sReportID = sReport_ID;
        }

        private void frm_ReportViewer_Load(object sender, EventArgs e)
        {
            //if (sReportID != null)
            //{
            //    tbl_atlProcess_Print detail = new tbl_atlProcess_Print(sReportID, 0, "default", "1", clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //    detail.Insert();
            //}

            if (!(clsConfig.sRemortDesktopExportPath.Length > 0))
                btnPrint.Visible = false;
            else
            {
                string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                if (clsHelpMethods_Local.GetHostName() == Split[0])
                {
                    btnPrint.Visible = true;
                    if (!crystalReportViewer1.ShowExportButton)
                        btnPrint.Location = new System.Drawing.Point(3, 3);
                    else
                        btnPrint.Location = new System.Drawing.Point(29, 3);
                }
                else
                    btnPrint.Visible = false;
            }

            clsFormatter.setFormatForm(this, "Report Viewer", 2, 0);
        }

        public void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();
            string sFilePath = clsConfig.sRemortDesktopExportPath + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
            ReportDocument rDoc = (ReportDocument)crystalReportViewer1.ReportSource;
            rDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFilePath);
        }
    }
}