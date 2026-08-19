using DataTire;
using Digiteq_Logic;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using SEACC_Report.Excel_DataTable;

namespace SEACC_Report
{
    public class cls_sasMonthlyReturnsAgainst_Sales
    {

        #region Report Generate
        public static void MonthlyReturnsAgainst_Sales(List<cls_sasMonthlyReturnsAgainst_Sales_DTO_Temp> lstSales, DateTime dtFrmDate, DateTime dtToDate, string sReportName, List<string> dateList)
        {
            try
            {
                string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\MonthlyReturnsAgainst_Sales.xlsx");
                    if (TempFile.Exists)
                    {
                        string sUserName = clsSecurity.UserNameLoged.Replace(" ", "_");

                        string sOutPutPath = @"" + s_Path + "\\Excel_Reports\\" + Path.GetFileNameWithoutExtension(TempFile.Name) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + "_" + sUserName + TempFile.Extension;
                        File.Copy(TempFile.FullName, sOutPutPath, false);

                        FileInfo OutputFile = new FileInfo(sOutPutPath);
                        if (OutputFile.Exists)
                        {
                            using (ExcelPackage excelPackage = new ExcelPackage(OutputFile))
                            {
                                ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                ExcelWorksheet vWS_Data = excelWorkBook.Worksheets.First();
                                vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();
                                vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                                      (from oRecord in lstSales
                                       orderby oRecord.SalesRep
                                       select oRecord,
                                       true,
                                       OfficeOpenXml.Table.TableStyles.Medium2);

                                //Set up Cell formattings in "Raw_Data" sheet
                                vWS_Data.Cells[2, 12, dataRange.End.Row, 12].Style.Numberformat.Format = "#,##0.00";
                                dataRange.AutoFitColumns();


                                ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                wsPivot.Cells[1, 1, 1, 6].Value = clsSecurity.CompanyName;
                                wsPivot.Cells[2, 1, 2, 6].Value = clsSecurity.CompanyAddress1;
                                wsPivot.Cells[3, 1, 3, 6].Value = clsSecurity.CompanyAddress2;
                                wsPivot.Cells[5, 1, 5, 6].Value = sReportName + " (" + dtFrmDate.Date.ToString("MMMM yy") + " - " + dtToDate.Date.ToString("MMMM yy") + ")";

                                wsPivot.Cells[7, 3, 7, 6].Value = dateList[0].ToString();
                                wsPivot.Cells[7, 7, 7, 10].Value = dateList[1].ToString();
                                wsPivot.Cells[7, 11, 7, 14].Value = dateList[2].ToString();
                                wsPivot.Cells[7, 15, 7, 18].Value = dateList[3].ToString();
                                wsPivot.Cells[7, 19, 7, 22].Value = dateList[4].ToString();
                                wsPivot.Calculate();

                                excelPackage.Save();
                                MessageBox.Show("Data Generated Successfully...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (System.IO.File.Exists(OutputFile.FullName))
                                    System.Diagnostics.Process.Start(OutputFile.FullName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


    }
}
