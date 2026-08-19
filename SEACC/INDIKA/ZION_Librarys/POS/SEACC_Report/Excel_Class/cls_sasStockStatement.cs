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
    class cls_sasStockStatement
    {
        #region Report Generate
        public static void Run_StockStatement(List<cls_scsStockStatement_DTO> lstSales, DateTime dtFrmDate, DateTime dtToDate, string sReportName, bool bHideSales, bool bHideStock, bool bHideProd)
        {
            try
            {
                string s_Path = System.Windows.Forms.Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");
                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\StockStatement.xlsx");
                    if (TempFile.Exists)
                    {
                        string sUserName = clsSecurity.UserNameLoged.Replace(" ", "_");
                        //@"" + s_Path + "\\Excel_Reports\\SalesReportDetail_InvoiceItemWise"

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
                                       orderby oRecord.ItemID
                                       select oRecord,
                                       true,
                                       OfficeOpenXml.Table.TableStyles.Medium2);

                                //Set up Cell formattings in "Raw_Data" sheet
                                //vWS_Data.Cells[2, 4, dataRange.End.Row, 4].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                                vWS_Data.Cells[2, 5, dataRange.End.Row, 22].Style.Numberformat.Format = "#,##0.00";//Amounts
                                dataRange.AutoFitColumns();
                               
                                vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();

                                wsPivot.Column(8).Hidden = bHideStock;
                                wsPivot.Column(9).Hidden = bHideStock;
                                wsPivot.Column(10).Hidden = bHideStock;
                                wsPivot.Column(11).Hidden = bHideStock;
                                wsPivot.Column(12).Hidden = bHideStock;
                                wsPivot.Column(13).Hidden = bHideStock;
                                wsPivot.Column(14).Hidden = bHideStock;
                                wsPivot.Column(15).Hidden = bHideStock;
                                wsPivot.Column(16).Hidden = bHideStock;
                                wsPivot.Column(17).Hidden = bHideStock;
                                wsPivot.Column(18).Hidden = bHideStock;
                                wsPivot.Column(19).Hidden = bHideStock;

                                wsPivot.Column(20).Hidden = bHideSales;
                                wsPivot.Column(21).Hidden = bHideSales;

                                wsPivot.Column(22).Hidden = bHideProd;
                                wsPivot.Column(23).Hidden = bHideProd;
                                wsPivot.Column(24).Hidden = bHideProd;
                                wsPivot.Column(25).Hidden = bHideProd;
                                wsPivot.Column(26).Hidden = bHideProd;
                                wsPivot.Column(27).Hidden = bHideProd;
                                wsPivot.Column(28).Hidden = bHideProd;
                                wsPivot.Column(29).Hidden = bHideProd;
                                wsPivot.Column(30).Hidden = bHideProd;
                                wsPivot.Column(31).Hidden = bHideProd;
                                wsPivot.Column(32).Hidden = bHideProd;
                                wsPivot.Column(33).Hidden = bHideProd;
                                wsPivot.Column(34).Hidden = bHideProd;
                                wsPivot.Column(35).Hidden = bHideProd;
                                wsPivot.Column(36).Hidden = bHideProd;
                                wsPivot.Column(37).Hidden = bHideProd;
                                //wsPivot.Column(38).Hidden = bHideProd;

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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
