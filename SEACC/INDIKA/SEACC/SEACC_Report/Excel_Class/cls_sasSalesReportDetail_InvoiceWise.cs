using DataTire;
using Digiteq_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Table.PivotTable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_Report
{
    public class cls_sasSalesReportDetail_InvoiceWise
    {
        #region Report Generate
        public static void Run_SalesReportDetail_InvoiceWise(List<cls_sasSalesReportDetail_InvoiceWise_DTO> lstSalesDetail, DateTime dtFrmDate, DateTime dtToDate, string sReportName)
        {
            try
            {
                string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReportDetail_InvoiceWise.xlsx");
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
                                if (lstSalesDetail.Count > 0)
                                {
                                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                    ExcelWorksheet vWS_Data = excelWorkBook.Worksheets.First();
                                    vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();

                                    var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                                          (from oRecord in lstSalesDetail
                                           orderby oRecord.TxType, oRecord.TxDate, oRecord.Tx_ID
                                           select oRecord,
                                           true,
                                           OfficeOpenXml.Table.TableStyles.Medium2);

                                    //Set up Cell formattings in "Raw_Data" sheet
                                    vWS_Data.Cells[2, 4, dataRange.End.Row, 4].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                                    vWS_Data.Cells[2, 9, dataRange.End.Row, 16].Style.Numberformat.Format = "#,##0.00";
                                    dataRange.AutoFitColumns();

                                    vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                    ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                    wsPivot.Cells[1, 1, 1, 5].Value = clsSecurity.CompanyName;
                                    wsPivot.Cells[2, 1, 2, 5].Value = clsSecurity.CompanyAddress1;
                                    wsPivot.Cells[3, 1, 3, 5].Value = clsSecurity.CompanyAddress2;
                                    wsPivot.Cells[5, 1, 5, 5].Value = sReportName;
                                    wsPivot.Cells[6, 1, 6, 5].Value = "From : " + dtFrmDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();
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
            }
            catch (Exception ex)
            {
                //clsValidate.WriteErrorLog("", -1,ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}