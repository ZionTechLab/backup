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

namespace MHE_Api.Report
{
    public class ReportContext
    {
      
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
        
        
    }
}
