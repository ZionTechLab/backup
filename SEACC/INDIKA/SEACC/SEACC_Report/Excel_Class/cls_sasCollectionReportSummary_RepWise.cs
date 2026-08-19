using Digiteq_Logic;
using OfficeOpenXml;
using SEACC_Report.Excel_DataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SEACC_Report.Excel_Class
{
    public class cls_sasCollectionReportSummary_RepWise
    {
        public static void Run_CollectionReportSummary(List<cls_sasCollectionReportSummary_RepWise_DTO> lstCollections,
            DateTime dtFrmDate, DateTime dtToDate)
        {

            try
            {
                string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\CollectionReportSummary_RepWise.xlsx");
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
                                if (lstCollections.Count > 0)
                                {
                                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                    ExcelWorksheet vWS_Data = excelWorkBook.Worksheets.First();
                                    vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();
                                    vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                    var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                                          (from oRecord in lstCollections
                                           orderby oRecord.SalesRep
                                           select oRecord,
                                           true,
                                           OfficeOpenXml.Table.TableStyles.Medium2);

                                    //Set up Cell formattings in "Raw_Data" sheet
                                    //vWS_Data.Cells[2, 2, dataRange.End.Row, 2].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                                    vWS_Data.Cells[2, 10, dataRange.End.Row, 18].Style.Numberformat.Format = "#,##0.00";
                                    dataRange.AutoFitColumns();


                                    ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                    wsPivot.Cells[7, 1, 7, 3].Value = "From : " + dtFrmDate.Date.ToString("yyyy MMMM dd") + " - To :" + dtToDate.Date.ToString("yyyy MMMM dd");
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
               // clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
