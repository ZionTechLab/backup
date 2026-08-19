using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using Digiteq_Logic;
using DataTire;
using Digiteq.DataSets;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_ReportViwer.xaml
    /// </summary>
    public partial class frm_ReportViwerTest : Window
    {
        public frm_ReportViwerTest()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        public void Print(string path, DataSet ReportDataset, DataTable ParamerterData)
        {
            try
            {
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();
                s_Path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataset);
                int exportFormatFlags = (int)(CrystalDecisions.Shared.ViewerExportFormats.PdfFormat);
                crystalReportsViewer.ViewerCore.AllowedExportFormats = exportFormatFlags;
                //crystalReportsViewer.ViewerCore.ex
                crystalReportsViewer.ViewerCore.ReportSource = objRpt;
                // crystalReportsViewer.refre
                // crystalReportsViewer_MasterData.ViewerCore = true;
                crystalReportsViewer.ViewerCore.CloseView(false);
                // WindowState = WindowState.Maximized;
                ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
