using Digiteq_Logic;
using OfficeOpenXml;
using SEACC_Report.Excel_DataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_Report.Excel_Class
{
    class cls_sasPendingOrders
    {
        #region Report Generate
        public static void Run_SalesReport_PendingOrder(List<cls_sasPendingOrders_DTO> lstSales, DateTime dtFrmDate, DateTime dtToDate, string sReportName)
        {
            try
            {
                string s_Path = System.Windows.Forms.Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");
                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReport_PendingOrders.xlsm");
                    if (TempFile.Exists)
                    {
                        string sUserName = clsSecurity.UserNameLoged.Replace(" ", "_");

                        string sOutPutPath = @"" + s_Path + "\\Excel_Reports\\" + Path.GetFileNameWithoutExtension(TempFile.Name) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + "_" + sUserName + TempFile.Extension; //clsSecurity.UserNameLoged   
                        File.Copy(TempFile.FullName, sOutPutPath, false);

                        FileInfo OutputFile = new FileInfo(sOutPutPath);
                        if (OutputFile.Exists)
                        {
                            using (ExcelPackage excelPackage = new ExcelPackage(OutputFile))
                            {
                                ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                ExcelWorksheet vWS_Data = excelWorkBook.Worksheets.First();
                                vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();

                                var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                                      (from oRecord in lstSales
                                       orderby oRecord.CODate
                                       select oRecord,
                                       true,
                                       OfficeOpenXml.Table.TableStyles.Medium2);

                                //Set up Cell formattings in "Raw_Data" sheet
                                vWS_Data.Cells[2,1, dataRange.End.Row, 1].Style.Numberformat.Format = "dd-MM-yyyy";//CO Date
                                vWS_Data.Cells[2, 10, dataRange.End.Row, 17].Style.Numberformat.Format = "#,##0.00";//Amounts
                                vWS_Data.Cells[2, 18, dataRange.End.Row, 18].Style.Numberformat.Format = "dd-MM-yyyy";//DO Date From Date

                                dataRange.AutoFitColumns();

                                vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                wsPivot.Cells[1, 1, 1, 8].Value = clsSecurity.CompanyName;
                                wsPivot.Cells[2, 1, 2, 8].Value = clsSecurity.CompanyAddress1;
                                wsPivot.Cells[3, 1, 3, 8].Value = clsSecurity.CompanyAddress2;
                                wsPivot.Cells[5, 1, 5, 8].Value = sReportName;
                                wsPivot.Cells[6, 1, 6, 8].Value = "From : " + dtFrmDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();
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
                clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
