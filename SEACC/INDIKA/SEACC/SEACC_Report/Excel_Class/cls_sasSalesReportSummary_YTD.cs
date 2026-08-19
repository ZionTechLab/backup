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

namespace SEACC_Report
{
    public class cls_sasSalesReportSummary_YTD
    {

        #region Report Generate
        public static void SalesReportSummary_YTD(List<cls_sasSalesReportSummaryYTD_DTO> lstSales, DateTime dtFrmDate, DateTime dtToDate, string sReportName)
        {
            try
            {
                string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReportSummary_YTD.xlsx");
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
                                       orderby oRecord.CustomerClass, oRecord.CustomerType, oRecord.SalesRep
                                       select oRecord,
                                       true,
                                       OfficeOpenXml.Table.TableStyles.Medium2);

                                //Set up Cell formattings in "Raw_Data" sheet
                                vWS_Data.Cells[2, 4, dataRange.End.Row, 16].Style.Numberformat.Format = "#,##0.00";
                                vWS_Data.Cells[2, 18, dataRange.End.Row, 22].Style.Numberformat.Format = "#,##0.00";
                                dataRange.AutoFitColumns();


                                ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                wsPivot.Cells[1, 1, 1, 6].Value = clsSecurity.CompanyName;
                                wsPivot.Cells[2, 1, 2, 6].Value = clsSecurity.CompanyAddress1;
                                wsPivot.Cells[3, 1, 3, 6].Value = clsSecurity.CompanyAddress2;
                                wsPivot.Cells[5, 1, 5, 6].Value = sReportName;
                                wsPivot.Cells[6, 1, 6, 6].Value = "From : " + dtFrmDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();
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
                //clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


    }
}







#region Report Generate
//public static void SalesReportSummary_YTD(List<cls_sasSalesReportSummaryYTD_DTO_Temp> lstSales, DateTime dtFrmDate, DateTime dtToDate)
//{
//    string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

//    if (s_Path != "")
//    {
//        FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReportSummary_YTD_Blank.xlsx");
//        if (TempFile.Exists)
//        {
//            string sUserName = clsSecurity.UserNameLoged.Replace(" ", "_");

//            string sOutPutPath = @"" + s_Path + "\\Excel_Reports\\" + Path.GetFileNameWithoutExtension(TempFile.Name) + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + "_" + sUserName + TempFile.Extension;
//            File.Copy(TempFile.FullName, sOutPutPath, false);

//            FileInfo OutputFile = new FileInfo(sOutPutPath);
//            if (OutputFile.Exists)
//            {
//                using (ExcelPackage excelPackage = new ExcelPackage(OutputFile))
//                {
//                    #region Raw Data Worksheet
//                    //Create an Excel Worksheet called "Raw_Data"
//                    var vWS_Data = excelPackage.Workbook.Worksheets.Add("Raw_Data");

//                    //Load Raw data in to "Raw_Data" sheet
//                    var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
//                        (from oRecord in lstSales
//                         orderby oRecord.CustomerClass, oRecord.CustomerType, oRecord.SalesRep
//                         select oRecord,
//                        true,
//                        OfficeOpenXml.Table.TableStyles.Medium2);

//                    //Set up Cell formattings in "Raw_Data" sheet
//                    vWS_Data.Cells[2, 5, dataRange.End.Row, 5].Style.Numberformat.Format = "#,##0.00";
//                    vWS_Data.Cells[2, 7, dataRange.End.Row, 11].Style.Numberformat.Format = "#,##0.00";
//                    vWS_Data.Hidden = eWorkSheetHidden.Hidden;

//                    //Setup Column width in "Raw_Data" sheet
//                    dataRange.AutoFitColumns();
//                    #endregion

//                    #region Pivot Table Worksheet
//                    //Create a new excel worksheet for "Pivot Table Creation"
//                    var wsPivot = excelPackage.Workbook.Worksheets.Add("Pivot_SalaryRegister");

//                    //Setup the starting point and data for the Pivot Table 
//                    var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");

//                    #region Pivot Table - Raw Arrangement
//                    var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
//                    vDataCol_1.Outline = true;
//                    vDataCol_1.Compact = true;
//                    vDataCol_1.ShowAll = false;
//                    vDataCol_1.SubtotalTop = false;

//                    var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[2]);
//                    vDataCol_2.Outline = true;
//                    vDataCol_2.Compact = true;
//                    vDataCol_2.ShowAll = false;
//                    vDataCol_2.SubtotalTop = false;
//                    vDataCol_2.ShowInFieldList = false;
//                    //vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                    var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[3]);
//                    vDataCol_3.Outline = false;
//                    vDataCol_3.Compact = true;
//                    vDataCol_3.ShowAll = false;
//                    vDataCol_3.SubtotalTop = false;
//                    vDataCol_3.ShowInFieldList = false;

//                    var vDataCol_4 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[4]);
//                    vDataCol_4.Outline = false;
//                    vDataCol_4.Compact = false;
//                    vDataCol_4.ShowAll = false;
//                    vDataCol_4.SubtotalTop = false;
//                    vDataCol_4.ShowInFieldList = false;

//                    var vDataCol_5 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[6]);
//                    vDataCol_5.Outline = false;
//                    vDataCol_5.Compact = false;
//                    vDataCol_5.ShowAll = false;
//                    vDataCol_5.SubtotalTop = false;
//                    vDataCol_5.ShowInFieldList = false;

//                    var vDataCol_6 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[7]);
//                    vDataCol_6.Outline = false;
//                    vDataCol_6.Compact = false;
//                    vDataCol_6.ShowAll = false;
//                    vDataCol_6.SubtotalTop = false;
//                    vDataCol_6.ShowInFieldList = false;

//                    var vDataCol_7 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[8]);
//                    vDataCol_7.Outline = false;
//                    vDataCol_7.Compact = false;
//                    vDataCol_7.ShowAll = false;
//                    vDataCol_7.SubtotalTop = false;
//                    vDataCol_7.ShowInFieldList = false;

//                    var vDataCol_8 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[9]);
//                    vDataCol_8.Outline = false;
//                    vDataCol_8.Compact = false;
//                    vDataCol_8.ShowAll = false;
//                    vDataCol_8.SubtotalTop = false;
//                    vDataCol_8.ShowInFieldList = false;

//                    var vDataCol_9 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[10]);
//                    vDataCol_9.Outline = false;
//                    vDataCol_9.Compact = false;
//                    vDataCol_9.ShowAll = false;
//                    vDataCol_9.SubtotalTop = false;
//                    vDataCol_9.ShowInFieldList = false;

//                    var vDataCol_10 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[11]);
//                    vDataCol_10.Outline = false;
//                    vDataCol_10.Compact = false;
//                    vDataCol_10.ShowAll = false;
//                    vDataCol_10.SubtotalTop = false;
//                    vDataCol_10.ShowInFieldList = false;
//                    #endregion

//                    #region Pivot Table - Column Arrangement
//                    pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[0]);
//                    #endregion

//                    #region Pivot Table - Data Value Arrangement
//                    var dPayslipAmount = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[5]);
//                    dPayslipAmount.Format = "#,##0.00";
//                    #endregion

//                    //var vFilter_Field_1 = pivot_DataTable.Fields[6];
//                    //pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place

//                    #region Pivot Table Formattings
//                    pivot_DataTable.ShowDrill = false;
//                    pivot_DataTable.Compact = false;
//                    ///*
//                    //pivot_DataTable.Compact = false;
//                    //pivot_DataTable.CompactData = false;
//                    //pivot_DataTable.Indent = 0;
//                    //pivot_DataTable.RowGrandTotals = false;
//                    //pivot_DataTable.UseAutoFormatting = true;
//                    //pivot_DataTable.ShowMemberPropertyTips = false;
//                    //pivot_DataTable.DataOnRows = false;
//                    //*/
//                    #endregion
//                    #endregion

//                    #region Report Header
//                    #region Top Left
//                    //using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
//                    //{
//                    //    Title.Style.Font.Size = 18;
//                    //    Title.Style.Font.Bold = true;
//                    //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                    //    Title.Value = "Printed Date : " + DateTime.Now.Date.ToString("dd-mmm-yyyy") + " " + DateTime.Now.TimeOfDay.ToString("hh:mm");
//                    //}
//                    //using (ExcelRange Title = wsPivot.Cells[2, 1, 2, 1])
//                    //{
//                    //    Title.Style.Font.Size = 18;
//                    //    Title.Style.Font.Bold = true;
//                    //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                    //    Title.Value = "Sales Summary Report YTD";
//                    //}
//                    //using (ExcelRange Title = wsPivot.Cells[3, 1, 3, 1])
//                    //{
//                    //    Title.Style.Font.Size = 18;
//                    //    Title.Style.Font.Bold = true;
//                    //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                    //    Title.Value = "From : " + dtFrmDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();
//                    //}
//                    #endregion

//                    #region Top Right
//                    //using (ExcelRange Company_Name = wsPivot.Cells[1, 17, 1, 17])
//                    //{
//                    //    Company_Name.Style.Font.Size = 14;
//                    //    Company_Name.Style.Font.Bold = true;
//                    //    Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                    //    Company_Name.Value = clsSecurity.CompanyName;
//                    //}
//                    //using (ExcelRange Company_Address1 = wsPivot.Cells[2, 17, 2, 17])
//                    //{
//                    //    Company_Address1.Style.Font.Size = 12;
//                    //    Company_Address1.Style.Font.Bold = true;
//                    //    Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                    //    Company_Address1.Value = clsSecurity.CompanyAddress1;
//                    //}
//                    //using (ExcelRange Company_Address2 = wsPivot.Cells[3, 17, 3, 17])
//                    //{
//                    //    Company_Address2.Style.Font.Size = 12;
//                    //    Company_Address2.Style.Font.Bold = true;
//                    //    Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                    //    Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                    //    Company_Address2.Value = clsSecurity.CompanyAddress2;
//                    //}

//                    ////Report Image
//                    //using (var ms = new MemoryStream(clsCommon.getCompanyImage()))
//                    //{
//                    //    int rowIndex = wsPivot.Dimension.Start.Row;
//                    //    int colIndex = wsPivot.Dimension.End.Column;
//                    //    int iWidth = 150;
//                    //    int iHeight = 75;

//                    //    Image img = Image.FromStream(ms);
//                    //    OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("CompanyImage", img);
//                    //    pic.SetPosition(0, 0, 18, 0);
//                    //    pic.SetSize(iWidth, iHeight);
//                    //}
//                    #endregion
//                    #endregion

//                    wsPivot.Calculate();
//                    //Excel File Save
//                    excelPackage.Save();
//                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    if (System.IO.File.Exists(OutputFile.FullName))
//                        System.Diagnostics.Process.Start(OutputFile.FullName);

//                }
//            }
//        }
//    }
//}
#endregion