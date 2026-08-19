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
    public partial class frm_ReportViwer : Window
    {
        public frm_ReportViwer()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        public void Print(string path, DataSet ReportDataset, DataTable ParamerterData)
        {
            try
            {

                //DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();
                //if (!clsConfig.bProductActivated)
                //{
                //    SEACCMessageBox.Show("Software has been expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButton.OK, "Red");
                //}
                //else
                //{
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();
                s_Path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataset);

                #region Add FormulaFields
                foreach (dts_ReportExport.dt_rptParameterRow details in ParamerterData.Rows)
                {
                    //Error handle
                    //if (details.isFormulaField)
                    //{
                    //    objRpt.DataDefinition.FormulaFields[details.FormulaFieldsName].Text = clsHelpMethods.fncsetstring(details.FormulaFieldsvalue);
                    //}
                    if (details.isFormulaField)
                        try
                        {
                            objRpt.DataDefinition.FormulaFields[details.FormulaFieldsName].Text = cls_Formater.fncsetstring(details.FormulaFieldsvalue);
                        }
                        catch { }

                }
                #endregion

                string[] Split = clsSecurity.DB_Server.Split(new Char[] { '\\' });
                if ((Digiteq_Logic.clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods.GetHostName() == Split[0]))
                {
                    #region Remort Desktop Login
                    DateTime dtmSvrDate = clsSecurity.getServerDateTime();

                    string path1 = "ReportExportTemp";
                    if (!System.IO.Directory.Exists(path1))
                        System.IO.Directory.CreateDirectory(path1);

                    string sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".rpt";
                    objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, sFilePath);
                    System.IO.File.Move(sFilePath, sFilePath.Replace("ReportExportTemp\\", clsConfig.sRemortDesktopExportPath));
                    #endregion
                }
                else
                {
                    #region Normal Login
                    int exportFormatFlags = (int)(CrystalDecisions.Shared.ViewerExportFormats.PdfFormat);
                    crystalReportsViewer.ViewerCore.AllowedExportFormats = exportFormatFlags;
                    //crystalReportsViewer.ViewerCore.ex
                    crystalReportsViewer.ViewerCore.ReportSource = objRpt;
                    // crystalReportsViewer.refre
                    // crystalReportsViewer_MasterData.ViewerCore = true;
                    crystalReportsViewer.ViewerCore.CloseView(false);
                    // WindowState = WindowState.Maximized;
                    ShowDialog();

                    //Show();
                    #endregion
                }
                objRpt.Close();
                objRpt.Dispose();
                // }
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

        private void SEACC_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
