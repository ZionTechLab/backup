using DataTire;
using Digiteq_Logic;
//using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_Report
{
    public class cls_sasSalesReportDetail_InvoiceItemWise
    {
        #region Report Generate
        public static void Run_SalesDetail_InvoiceItemWise(List<cls_sasSalesReportDetail_InvoiceItemWise_DTO> lstSales, DateTime dtFrmDate, DateTime dtToDate, string sReportName)
        {
            try
            {
                string s_Path = System.Windows.Forms.Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");
                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReportDetail_InvoiceItemWise.xlsx");
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
                                       orderby oRecord.TxType, oRecord.TxDate, oRecord.Tx_ID
                                       select oRecord,
                                       true,
                                       OfficeOpenXml.Table.TableStyles.Medium2);

                                //Set up Cell formattings in "Raw_Data" sheet
                                vWS_Data.Cells[2, 4, dataRange.End.Row, 4].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                                vWS_Data.Cells[2, 11, dataRange.End.Row, 19].Style.Numberformat.Format = "#,##0.00";//Amounts
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
            catch (Exception ex)
            {
               // clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}

//Excel File creation Process Starting
#region MyRegion
//if (false)
//{
//    FileInfo inf_file = cls_ReportUtils.GetFileInfo("SalesReportDetail_InvoiceWise.xlsx");
//    using (ExcelPackage pckFile = new ExcelPackage(inf_file))
//    {
//        if (lstSalesDetail.Count > 0)
//        {
//            #region Raw Data Worksheet
//            //Create an Excel Worksheet called "Raw_Data"
//            var vWS_Data = pckFile.Workbook.Worksheets.Add("Raw_Data");

//            //Load Raw data in to "Raw_Data" sheet
//            var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
//                (from oSalesRecord in lstSalesDetail
//                 orderby oSalesRecord.TxDate, oSalesRecord.Tx_ID
//                 select oSalesRecord,
//                 true,
//                 OfficeOpenXml.Table.TableStyles.Medium2);

//            //Set up Cell formattings in "Raw_Data" sheet
//            vWS_Data.Cells[2, 3, dataRange.End.Row, 3].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
//            vWS_Data.Cells[2, 8, dataRange.End.Row, 16].Style.Numberformat.Format = "#,##0.00";

//            //Setup Column width in "Raw_Data" sheet
//            dataRange.AutoFitColumns();
//            #endregion

//            #region Pivot Table Worksheet
//            //Create a new excel worksheet for "Pivot Table Creation"
//            var wsPivot = pckFile.Workbook.Worksheets.Add("Pivot_SalaryRegister");

//            //Setup the starting point and data for the Pivot Table 
//            var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");

//            #region Pivot Table - Raw Arrangement
//            var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[0]);
//            vDataCol_1.Outline = false;
//            vDataCol_1.Compact = false;
//            vDataCol_1.ShowAll = false;
//            vDataCol_1.SubtotalTop = false;

//            var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[2]);
//            vDataCol_2.Outline = false;
//            vDataCol_2.Compact = false;
//            vDataCol_2.ShowAll = false;
//            vDataCol_2.SubtotalTop = false;
//            vDataCol_2.ShowInFieldList = false;
//            vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//            var vDataCol_4 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[3]);
//            vDataCol_4.Outline = false;
//            vDataCol_4.Compact = false;
//            vDataCol_4.ShowAll = false;
//            vDataCol_4.SubtotalTop = false;
//            vDataCol_4.ShowInFieldList = false;

//            var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
//            vDataCol_3.Outline = false;
//            vDataCol_3.Compact = false;
//            vDataCol_3.ShowAll = false;
//            vDataCol_3.SubtotalTop = false;
//            vDataCol_3.ShowInFieldList = false;


//            var vDataCol_5 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[4]);
//            vDataCol_5.Outline = false;
//            vDataCol_5.Compact = false;
//            vDataCol_5.ShowAll = false;
//            vDataCol_5.SubtotalTop = false;
//            vDataCol_5.ShowInFieldList = false;

//            var vDataCol_6 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[5]);
//            vDataCol_6.Outline = false;
//            vDataCol_6.Compact = false;
//            vDataCol_6.ShowAll = false;
//            vDataCol_6.SubtotalTop = false;
//            vDataCol_6.ShowInFieldList = false;

//            var vDataCol_7 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[6]);
//            vDataCol_7.Outline = false;
//            vDataCol_7.Compact = false;
//            vDataCol_7.ShowAll = false;
//            vDataCol_7.SubtotalTop = false;
//            vDataCol_7.ShowInFieldList = false;
//            #endregion

//            #region Pivot Table - Column Arrangement
//            //pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[3]);
//            #endregion

//            #region Pivot Table - Data Value Arrangement
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[7]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[8]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[9]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[10]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[11]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[12]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[13]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[14]).Format = "#,##0.00";
//            pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[15]).Format = "#,##0.00";

//            //var dPayslipAmount = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[4]);
//            //dPayslipAmount.Format = "#,##0.00";
//            #endregion

//            //var vFilter_Field_1 = pivot_DataTable.Fields[6];
//            //pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place



//            #region Pivot Table Formattings
//            pivot_DataTable.ShowDrill = false;
//            /*
//            pivot_DataTable.Compact = false;
//            pivot_DataTable.CompactData = false;
//            pivot_DataTable.Indent = 0;
//            pivot_DataTable.RowGrandTotals = false;
//            pivot_DataTable.UseAutoFormatting = true;
//            pivot_DataTable.ShowMemberPropertyTips = false;
//            pivot_DataTable.DataOnRows = false;
//            */
//            #endregion

//            #endregion

//            #region Report Header

//            #region Top Left
//            using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
//            {
//                //Title.Merge = true;
//                Title.Style.Font.Size = 18;
//                Title.Style.Font.Bold = true;
//                //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                //Title.Style.TextRotation = 90;
//                Title.Value = "Printed Date : " + DateTime.Now.Date.ToString("dd-mmm-yyyy") + " " + DateTime.Now.Date.ToString("hh:mm");
//            }
//            using (ExcelRange Title = wsPivot.Cells[2, 1, 2, 1])
//            {
//                //Title.Merge = true;
//                Title.Style.Font.Size = 18;
//                Title.Style.Font.Bold = true;
//                //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                //Title.Style.TextRotation = 90;
//                Title.Value = "Sales Detail Report (Invoice  Wise)";
//            }
//            //using (ExcelRange Title = wsPivot.Cells[3, 1, 3, 1])
//            //{
//            //    //Title.Merge = true;
//            //    Title.Style.Font.Size = 18;
//            //    Title.Style.Font.Bold = true;
//            //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//            //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//            //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//            //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//            //    //Title.Style.TextRotation = 90;
//            //    Title.Value = "From : " + dtmFrm.Date + " - To :" + dtmTo.Date;
//            //}
//            #endregion

//            #region Top Right
//            using (ExcelRange Company_Name = wsPivot.Cells[1, 17, 1, 17])
//            {
//                //Title.Merge = true;
//                Company_Name.Style.Font.Size = 14;
//                Company_Name.Style.Font.Bold = true;
//                //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                //Title.Style.TextRotation = 90;
//                Company_Name.Value = clsSecurity.CompanyName;
//            }
//            using (ExcelRange Company_Address1 = wsPivot.Cells[2, 17, 2, 17])
//            {
//                //Title.Merge = true;
//                Company_Address1.Style.Font.Size = 12;
//                Company_Address1.Style.Font.Bold = true;
//                //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                //Title.Style.TextRotation = 90;
//                Company_Address1.Value = clsSecurity.CompanyAddress1;
//            }
//            using (ExcelRange Company_Address2 = wsPivot.Cells[3, 17, 3, 17])
//            {
//                //Title.Merge = true;
//                Company_Address2.Style.Font.Size = 12;
//                Company_Address2.Style.Font.Bold = true;
//                //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                //Title.Style.TextRotation = 90;
//                Company_Address2.Value = clsSecurity.CompanyAddress2;
//            }
//            #endregion

//            //Image img = Image.FromStream(ms);
//            //OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("CompanyImage", img);
//            //pic.SetPosition(0, 0, 18, 0);
//            ////pic.SetPosition(PixelTop, PixelLeft);  
//            //pic.SetSize(iWidth, iHeight);
//            ////pic.SetSize(40);
//            #endregion

//            pckFile.Save();
//        }
//    }
//}
#endregion
#region MyRegion
//            if (false)
//            {
//                //Excel File creation Process Starting
//                FileInfo inf_file = new FileInfo(@"D:\Projects\SEACC Version Control\DEV\SEACC\SEACC_Report\Excel_Reports\SalesReportDetail_InvoiceItemWise.xlsx");
//                using (ExcelPackage pckFile = new ExcelPackage(inf_file))
//                {
//                    if (lstSales.Count > 0)
//                    {
//                        #region Raw Data Worksheet
//                        //Create an Excel Worksheet called "Raw_Data"
//                        var vWS_Data = pckFile.Workbook.Worksheets.Add("Raw_Data");
////var vWS_Data = pckFile.Workbook.Worksheets["Raw_Data"];
////vWS_Data.DeleteRow(vWS_Data.Dimension.Start.Row +1 , vWS_Data.Dimension.End.Row);

////vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();
////var v = vWS_Data.Tables["Table1"].Address;
////var address = vWS_Data.Tables[1].Address;

////vWS_Data.DeleteRow(, worksheet.Dimension.End.Row - lastRow - 1);

////Load Raw data in to "Raw_Data" sheet
//var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
//    (from oSalesRecord in lstSales orderby oSalesRecord.TxDate, oSalesRecord.Tx_ID select oSalesRecord,
//    true,
//    OfficeOpenXml.Table.TableStyles.Medium2);


////Set up Cell formattings in "Raw_Data" sheet
////vWS_Data.Cells[2, 3, dataRange.End.Row, 3].Style.Numberformat.Format = "dd-mmm-yyyy";
////vWS_Data.Cells[2, 11, dataRange.End.Row, 11].Style.Numberformat.Format = "#,##0.00";

//vWS_Data.Cells[2, 3, dataRange.End.Row, 3].Style.Numberformat.Format = "dd-mmm-yyyy";
//                        vWS_Data.Cells[2, 10, dataRange.End.Row, 19].Style.Numberformat.Format = "#,##0.00";

//                        //vWS_Data.Cells[2, 11, dataRange.End.Row, 11].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 12, dataRange.End.Row, 12].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 13, dataRange.End.Row, 13].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 14, dataRange.End.Row, 14].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 15, dataRange.End.Row, 15].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 16, dataRange.End.Row, 16].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 17, dataRange.End.Row, 17].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 18, dataRange.End.Row, 18].Style.Numberformat.Format = "#,##0.00";
//                        //vWS_Data.Cells[2, 19, dataRange.End.Row, 19].Style.Numberformat.Format = "#,##0.00";

//                        //Setup Column width in "Raw_Data" sheet
//                        dataRange.AutoFitColumns();
//                        #endregion



//                        #region Pivot Table Worksheet
//                        //Create a new excel worksheet for "Pivot Table Creation"
//                        //var wsPivot = pckFile.Workbook.Worksheets["SalesReportDetail_InvoiceItemWise"];
//                        //wsPivot.PivotTables.RefreshDataFlag = true;
//                        //wsPivot.PivotTables.RefreshData();

//                        var wsPivot = pckFile.Workbook.Worksheets.Add("SalesReportDetail_InvoiceItemWise");
////pckFile.Workbook.Worksheets.Add("SalesReportDetail_InvoiceItemWise");

////wsPivot.PivotTables["Pivot_Table"].DataFields[dataRange].Index = 1;

////Setup the starting point and data for the Pivot Table 
//var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");
////wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");
////wsPivot.PivotTables["Pivot_Table"].Address;

//#region Pivot Table - Raw Arrangement
//var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[0]);
//vDataCol_1.Outline = false;
//                        vDataCol_1.Compact = false;
//                        vDataCol_1.ShowAll = false;
//                        vDataCol_1.SubtotalTop = false;
//                        vDataCol_1.ShowInFieldList = true;

//                        var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[2]);
//vDataCol_2.Outline = false;
//                        vDataCol_2.Compact = false;
//                        vDataCol_2.ShowAll = false;
//                        vDataCol_2.SubtotalTop = false;
//                        vDataCol_2.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
//vDataCol_3.Outline = false;
//                        vDataCol_3.Compact = false;
//                        vDataCol_3.ShowAll = false;
//                        vDataCol_3.SubtotalTop = false;
//                        vDataCol_3.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_4 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[3]);
//vDataCol_4.Outline = false;
//                        vDataCol_4.Compact = false;
//                        vDataCol_4.ShowAll = false;
//                        vDataCol_4.SubtotalTop = false;
//                        vDataCol_4.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_5 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[4]);
//vDataCol_5.Outline = false;
//                        vDataCol_5.Compact = false;
//                        vDataCol_5.ShowAll = false;
//                        vDataCol_5.SubtotalTop = false;
//                        vDataCol_5.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_6 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[5]);
//vDataCol_6.Outline = false;
//                        vDataCol_6.Compact = false;
//                        vDataCol_6.ShowAll = false;
//                        vDataCol_6.SubtotalTop = false;
//                        vDataCol_6.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_7 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[6]);
//vDataCol_7.Outline = false;
//                        vDataCol_7.Compact = false;
//                        vDataCol_7.ShowAll = false;
//                        vDataCol_7.SubtotalTop = false;
//                        vDataCol_7.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

//                        var vDataCol_8 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[7]);
//vDataCol_8.Outline = false;
//                        vDataCol_8.Compact = false;
//                        vDataCol_8.ShowAll = false;
//                        vDataCol_8.SubtotalTop = false;
//                        vDataCol_8.ShowInFieldList = true;
//                        vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;
//                        #endregion

//                        #region Pivot Table - Column Arrangement
//                        //pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[3]);
//                        #endregion

//                        #region Pivot Table - Data Value Arrangement
//                        var vSellingPrice = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[9]);
//vSellingPrice.Format = "#,##0.00";
//                        vSellingPrice.Name = "Selling Price Tax Eclusive";
//                        vSellingPrice.BaseField = 1;

//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[10]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[11]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[12]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[13]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[14]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[15]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[16]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[17]).Format = "#,##0.00";
//                        pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[18]).Format = "#,##0.00";
//                        #endregion

//                        //pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[19]);

//                        //var vFilter_Field_1 = pivot_DataTable.Fields[6];
//                        //var vFilter_Field_2 = pivot_DataTable.Fields[7];
//                        //pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place
//                        //pivot_DataTable.PageFields.Add(vFilter_Field_2);

//                        #region Pivot Table Formattings
//                        pivot_DataTable.ShowDrill = false;
//                        /*
//                        pivot_DataTable.Compact = false;
//                        pivot_DataTable.CompactData = false;
//                        pivot_DataTable.Indent = 0;
//                        pivot_DataTable.RowGrandTotals = false;
//                        pivot_DataTable.UseAutoFormatting = true;
//                        pivot_DataTable.ShowMemberPropertyTips = false;
//                        pivot_DataTable.DataOnRows = false;
//                        */
//                        #endregion

//                        #endregion

//                        #region Report Header

//                        //#region Top Left
//                        //using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
//                        //{
//                        //    //Title.Merge = true;
//                        //    Title.Style.Font.Size = 18;
//                        //    Title.Style.Font.Bold = true;
//                        //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                        //    //Title.Style.TextRotation = 90;
//                        //    Title.Value = "Printed Date : " + DateTime.Now.Date.ToString("dd-mmm-yyyy") + " " + DateTime.Now.Date.ToString("hh:mm");
//                        //}
//                        //using (ExcelRange Title = wsPivot.Cells[2, 1, 2, 1])
//                        //{
//                        //    //Title.Merge = true;
//                        //    Title.Style.Font.Size = 18;
//                        //    Title.Style.Font.Bold = true;
//                        //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        //    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        //    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                        //    //Title.Style.TextRotation = 90;
//                        //    Title.Value = "Sales Detail Report (Invoice  & Item Wise)";
//                        //}
//                        ////using (ExcelRange Title = wsPivot.Cells[3, 1, 3, 1])
//                        ////{
//                        ////    //Title.Merge = true;
//                        ////    Title.Style.Font.Size = 18;
//                        ////    Title.Style.Font.Bold = true;
//                        ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        ////    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        ////    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
//                        ////    //Title.Style.TextRotation = 90;
//                        ////    Title.Value = "From : " + dtmFrm.Date + " - To :" + dtmTo.Date;
//                        ////}
//                        //#endregion

//                        //#region Top Right
//                        //using (ExcelRange Company_Name = wsPivot.Cells[1, 17, 1, 17])
//                        //{
//                        //    //Title.Merge = true;
//                        //    Company_Name.Style.Font.Size = 14;
//                        //    Company_Name.Style.Font.Bold = true;
//                        //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        //    Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        //    Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                        //    //Title.Style.TextRotation = 90;
//                        //    Company_Name.Value = clsSecurity.CompanyName;
//                        //}
//                        //using (ExcelRange Company_Address1 = wsPivot.Cells[2, 17, 2, 17])
//                        //{
//                        //    //Title.Merge = true;
//                        //    Company_Address1.Style.Font.Size = 12;
//                        //    Company_Address1.Style.Font.Bold = true;
//                        //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        //    Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        //    Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                        //    //Title.Style.TextRotation = 90;
//                        //    Company_Address1.Value = clsSecurity.CompanyAddress1;
//                        //}
//                        //using (ExcelRange Company_Address2 = wsPivot.Cells[3, 17, 3, 17])
//                        //{
//                        //    //Title.Merge = true;
//                        //    Company_Address2.Style.Font.Size = 12;
//                        //    Company_Address2.Style.Font.Bold = true;
//                        //    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                        //    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
//                        //    Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                        //    Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
//                        //    //Title.Style.TextRotation = 90;
//                        //    Company_Address2.Value = clsSecurity.CompanyAddress2;
//                        //}

//                        ////Report Image
//                        //using (var ms = new MemoryStream(clsCommon.getCompanyImage()))
//                        //{
//                        //    int rowIndex = wsPivot.Dimension.Start.Row;
//                        //    int colIndex = wsPivot.Dimension.End.Column;
//                        //    //int PixelTop = 88;
//                        //    //int PixelLeft = 129;
//                        //    int iWidth = 150;
//                        //    int iHeight = 75;

//                        //    Image img = Image.FromStream(ms);
//                        //    OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("CompanyImage", img);
//                        //    pic.SetPosition(0, 0, 18, 0);
//                        //    //pic.SetPosition(PixelTop, PixelLeft);  
//                        //    pic.SetSize(iWidth, iHeight);
//                        //    //pic.SetSize(40);
//                        //}
//                        //#endregion

//                        #endregion

//                        //Excel File Save
//                        pckFile.Save();

//                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    }
//                }
//            }
#endregion