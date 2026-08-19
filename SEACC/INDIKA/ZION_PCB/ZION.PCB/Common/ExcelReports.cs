using Digiteq_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.PCB.Common
{
    public class ExcelReports
    {
        public void GenerateReport(DataTable dt_result, string sReportTitle_Main, string sFilter)
        {
            var dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.DefaultExt = ".xls";
            dlg.Filter = "Text documents (.xls)|*.xlsx";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileInfo files = new FileInfo(dlg.FileName);

                    string filename = dlg.FileName;
                    using (ExcelPackage pck = new ExcelPackage(files))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");

                        ws.Cells[1, 1, 1, 6].Merge = true;
                        ws.Cells[3, 1, 3, 6].Merge = true;
                        ws.Cells[4, 1, 4, 6].Merge = true;
                        ws.Cells[5, 1, 5, 6].Merge = true;

                        ws.Cells["A1"].Value = clsSecurity.CompanyName;
                        ws.Cells["A1"].Style.Font.Size = 14;

                        ws.Cells["A2"].Style.Font.Size = 1;

                        ws.Cells["A3"].Value = sReportTitle_Main;
                        ws.Cells["A3"].Style.Font.Size = 20;

                        ws.Cells["A4"].Value = sFilter;
                        ws.Cells["A4"].Style.Font.Size = 12;

                        ws.Cells["A5"].Value = "Printed By : " + clsSecurity.UserNameLoged + " Date : " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
                        ws.Cells["A5"].Style.Font.Size = 7;

                        ws.Cells["A7"].LoadFromDataTable(dt_result, true);
                        ExcelRange range = ws.Cells[7, 1, dt_result.Rows.Count + 7, (dt_result.Columns.Count)];
                        ExcelTable Table = ws.Tables.Add(range, "Table1");

                        range.Style.Font.Size = 8;
                        ws.Cells["7:7"].Style.WrapText = true;

                        Table.ShowFilter = true;
                        Table.ShowTotal = true;

                        var style = pck.Workbook.Styles.CreateNamedStyle("Tot");

                        style.Style.Font.Size = 8;
                        Table.TotalsRowCellStyle = "Tot";

                        int i = 0;
                        foreach (DataColumn dtRow in dt_result.Columns)
                        {
                            var x = dtRow.DataType.Name.ToString();

                            if (dtRow.DataType == typeof(decimal))
                            {
                                ws.Column(i + 1).Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";
                                ws.Column(i + 1).Width = 9;
                                Table.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                            }
                            else if (dtRow.DataType == typeof(Double))
                            {
                                Table.Columns[i + 1].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                            }
                            else if (dtRow.DataType == typeof(string))
                            {
                                ws.Column(i + 1).AutoFit();
                            }
                            i++;
                        }

                        Table.Columns[0].TotalsRowLabel = "Total ";
                        Table.TableStyle = TableStyles.Light1;
                        var cel = "A" + (dt_result.Rows.Count + 9);
                        pck.Save();

                        System.Diagnostics.Process.Start(dlg.FileName);
                    }
                }
                catch (Exception ex)
                {
                    
                    SEACCMessageBox.Show("Oops.... ",ex.Message, System.Windows.MessageBoxButton.OK);
                }
            }
        }
    }
}
