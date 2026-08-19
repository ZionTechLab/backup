using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.Report
{
    public partial class ReportPreviewWinView : Form
    {
        public ReportPreviewWinView(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para)
        {
            InitializeComponent();

            try
            {
                //this.Title = rptTitle;
                this.Text = rptTitle;
                ReportContext.SetReportDataSource(rptDocument, Report_Data);
                ReportContext.SetReportParameter(rptDocument, Report_Para);

               ////// reportViewer.ViewerCore.ReportSource = rptDocument;
               ////// reportViewer.ToggleSidePanel = win
               reportViewer.ReportSource = rptDocument;
                reportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SetReportViewer(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, object reportPrv)
        {
            try
            {
                //this.Title = rptTitle;

                //ReportContext.SetReportDataSource(rptDocument, Report_Data);
                //ReportContext.SetReportParameter(rptDocument, Report_Para);
                ///// reportViewer.Owner =(ReportPreviewView)reportPrv;
                //reportViewer.ViewerCore.ReportSource = rptDocument;
                //reportViewer.ToggleSidePanel = SAPBusinessObjects.WPF.Viewer.Constants.SidePanelKind.None;




            }
            catch (Exception)
            {
                throw;
            }



        }
    }
}
