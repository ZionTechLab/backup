using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Report
{
    public class ReportContext
    {


        /// <summary>
        /// report viewer pop up
        /// </summary>
        /// <param name="rptTitle">Name of report</param>       
        /// <param name="dataTable">Datable dictionary</param>
        /// <param name="Report_Para">Report parameter dictionary , if there are no paremeter send NULL </param>
        ////public static void ViewReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para)
        ////{
        ////    ReportPreviewView reportPrv = new ReportPreviewView(rptTitle, rptDocument, Report_Data, Report_Para);
        ////     reportPrv.ShowDialog();


        ////}

        public static void ShowDialogReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para)
        {
            //// ReportPreviewView reportPrv = new ReportPreviewView(rptTitle, rptDocument, Report_Data, Report_Para);
            ReportPreviewWinView reportPrv = new ReportPreviewWinView(rptTitle, rptDocument, Report_Data, Report_Para);
            reportPrv.ShowDialog();

        }

        public static void ShowReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para)
        {
            //// ReportPreviewView reportPrv = new ReportPreviewView(rptTitle, rptDocument, Report_Data, Report_Para);
            ReportPreviewWinView reportPrv = new ReportPreviewWinView(rptTitle, rptDocument, Report_Data, Report_Para);
            reportPrv.Show();
        }

        /// <summary>
        /// report print directly without preview
        /// </summary>
        /// <param name="rptTitle">Name of report</param>
        /// <param name="rptDocument">report document</param>
        /// <param name="Report_Data">report data</param>
        /// <param name="Report_Para">report paramenter</param>
        public static void PrintReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId /*_printSource = "A"*/)
        {
            ////SetReportDataSource(rptDocument, Report_Data);
            ////SetReportParameter(rptDocument, Report_Para);
            ////rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            ////rptDocument.PrintOptions.PaperSource = PaperSource.Auto;
            ////rptDocument.PrintToPrinter(1, false, 0, 0);

            ////////SetReportDataSource(rptDocument, Report_Data);
            ////////SetReportParameter(rptDocument, Report_Para);
            ////////rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            ////////rptDocument.PrintOptions.PaperSource = PaperSource.Lower;
            ////////rptDocument.PrintToPrinter(1, false, 0, 0);

            //if (_printSource == "A")
            //{
            //    SetReportDataSource(rptDocument, Report_Data);
            //    SetReportParameter(rptDocument, Report_Para);
            //    rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            //    rptDocument.PrintOptions.PaperSource = PaperSource.Auto;
            //    rptDocument.PrintToPrinter(1, false, 0, 0);


            //}
            //else if (_printSource == "U")
            //{
            //    SetReportDataSource(rptDocument, Report_Data);
            //    SetReportParameter(rptDocument, Report_Para);
            //    rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            //    rptDocument.PrintOptions.PaperSource = PaperSource.Upper;
            //    rptDocument.PrintToPrinter(1, false, 0, 0);
            //}
            //else if (_printSource == "M")
            //{
            //    SetReportDataSource(rptDocument, Report_Data);
            //    SetReportParameter(rptDocument, Report_Para);
            //    rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            //    rptDocument.PrintOptions.PaperSource = PaperSource.Middle;
            //    rptDocument.PrintToPrinter(1, false, 0, 0);
            //}

            //rptDocument.Dispose();


            string DutyPath = Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            //System.IO.Directory.CreateDirectory(@"C:\TLM\Duty\");
            //string filePath = DutyPath + "AirWayBill Details" + ".pdf";
            string filePath = DutyPath + invId + "_Details.pdf";
            rptFileDestOption.DiskFileName = filePath;
            SetReportDataSource2(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();


        }

        public static string SelectTray(int agencyID, string spsTray = "")
        {
            ////string _printSource = "A";
            ////if (agencyID == 20102 || agencyID == 20104)
            ////{
            ////    _printSource = "M";
            ////}
            ////else if (agencyID == 20101 || agencyID == 20103)
            ////{
            ////    _printSource = "U";
            ////}
            ////else
            ////{
            ////    _printSource = "A";
            ////}
            ////return _printSource;

            string _printSource = "A";


            //if (spsTray == "")
            //{
            //    if (agencyID == 20102 || agencyID == 20104)
            //    {
            //        _printSource = "M";
            //    }
            //    else if (agencyID == 20101 || agencyID == 20103)
            //    {
            //        _printSource = "U";
            //    }
            //    else
            //    {
            //        _printSource = "A";
            //    }
            //}
            //else
            //{
            //    _printSource = spsTray;
            //}


            return _printSource;
        }


        /// <summary>
        /// Convert list to perticular datatable
        /// </summary>
        /// <typeparam name="T">generic list</typeparam>
        /// <param name="items">List</param>
        /// <returns>Datatable</returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Set report parameter
        /// </summary>
        /// <param name="rptDocument">Report document</param>
        /// <param name="Report_Para">Report parameters</param>
        public static void SetReportParameter(ReportDocument rptDocument, Dictionary<string, string> Report_Para)
        {
            if (Report_Para != null)
            {
                foreach (string key in Report_Para.Keys)
                {
                    rptDocument.SetParameterValue(key, Report_Para[key]);
                }
            }
        }

        /// <summary>
        /// Set data source to report
        /// </summary>
        /// <param name="rptDocument">Report document instance </param>
        /// <param name="_report_data">Report datasource  </param>
        public static void SetReportDataSource(ReportDocument rptDocument, Dictionary<string, DataTable> _report_data)
        {
            if (_report_data != null)
            {
                int dataCount = _report_data.Count;
                foreach (string key in _report_data.Keys)
                {
                    if (dataCount > 1)
                    {
                        rptDocument.Database.Tables[key].SetDataSource(_report_data[key]);
                    }
                    else
                    {
                        rptDocument.SetDataSource(_report_data[key]);
                    }
                }
            }
        }
        public static void SetReportDataSource2(ReportDocument rptDocument, Dictionary<string, DataTable> _report_data)
        {
            if (_report_data != null)
            {
                int dataCount = _report_data.Count;
                string key = _report_data.First().Key;
                {
                    if (dataCount > 1)
                    {
                        rptDocument.Database.Tables[key].SetDataSource(_report_data[key]);
                    }
                    else
                    {
                        rptDocument.SetDataSource(_report_data[key]);
                    }
                }
            }
        }
        public static void EmailReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            System.IO.Directory.CreateDirectory(@"C:\TLM\Freight\");
            string reportFileName = @"C:\TLM\Freight\" + invId + ".pdf";
            rptFileDestOption.DiskFileName = reportFileName;
            SetReportDataSource(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();


        }
        public static void EmailBulkReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            string filePath = "\\\\186.100.100.232\\Freight\\" + invId + ".pdf";
            rptFileDestOption.DiskFileName = filePath;
            SetReportDataSource(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();


        }

        public static void ExportDutyReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId)
        {
            string DutyPath = Path.Combine(Environment.CurrentDirectory, @"ExportItems\Duty\");
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            //System.IO.Directory.CreateDirectory(@"C:\TLM\Duty\");
            string filePath = DutyPath + invId + ".pdf";
            rptFileDestOption.DiskFileName = filePath;
            SetReportDataSource(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();
        }
        public static void ExportFrtReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId)
        {
            string FrtPath = Path.Combine(Environment.CurrentDirectory, @"ExportItems\Freight\");

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            //System.IO.Directory.CreateDirectory(@"C:\TLM\Freight\");
            string filePath = FrtPath + invId + ".pdf";
            rptFileDestOption.DiskFileName = filePath;
            SetReportDataSource(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();
        }

        public static void MHEReport(string rptTitle, ReportDocument rptDocument, Dictionary<string, DataTable> Report_Data, Dictionary<string, string> Report_Para, string invId)
        {
            string DutyPath = Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();
            //System.IO.Directory.CreateDirectory(@"C:\TLM\Duty\");
            string filePath = DutyPath + invId + ".pdf";
            rptFileDestOption.DiskFileName = filePath;
            SetReportDataSource(rptDocument, Report_Data);
            SetReportParameter(rptDocument, Report_Para);
            rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4;
            rptExportOption = rptDocument.ExportOptions;
            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            rptDocument.Export();
        }
           
        
    }
}
