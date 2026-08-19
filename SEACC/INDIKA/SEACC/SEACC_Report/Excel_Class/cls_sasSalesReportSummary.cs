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

namespace SEACC_Report
{
    public class cls_sasSalesReportSummary
    {
        #region Report Generate
        public static void SalesReportSummary(List<cls_sasSalesReportSummary_DTO> lstSalesSummary, DateTime dtFrmDate, DateTime dtToDate, string sReportName)
        {
            try
            {
                string s_Path = Application.StartupPath.Replace(@"Mini ERP\bin\Debug", @"SEACC_Report");

                if (s_Path != "")
                {
                    FileInfo TempFile = new FileInfo(@"" + s_Path + "\\Excel_Templates\\SalesReportSummary.xlsx");
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
                                if (lstSalesSummary.Count > 0)
                                {
                                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                    ExcelWorksheet vWS_Data = excelWorkBook.Worksheets.First();
                                    vWS_Data.Cells[vWS_Data.Dimension.Address].Clear();
                                    vWS_Data.Hidden = eWorkSheetHidden.Hidden;

                                    var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                                          (from oRecord in lstSalesSummary
                                           orderby oRecord.TxDate, oRecord.Tx_ID, oRecord.CustomerClass
                                           select oRecord,
                                           true,
                                           OfficeOpenXml.Table.TableStyles.Medium2);

                                    //Set up Cell formattings in "Raw_Data" sheet
                                    vWS_Data.Cells[2, 4, dataRange.End.Row, 4].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                                    vWS_Data.Cells[2, 9, dataRange.End.Row, 14].Style.Numberformat.Format = "#,##0.00";
                                    dataRange.AutoFitColumns();
                                    

                                    ExcelWorksheet wsPivot = excelWorkBook.Worksheets.Last();
                                    wsPivot.Cells[1, 1, 1, 7].Value = clsSecurity.CompanyName;
                                    wsPivot.Cells[2, 1, 2, 7].Value = clsSecurity.CompanyAddress1;
                                    wsPivot.Cells[3, 1, 3, 7].Value = clsSecurity.CompanyAddress2;
                                    wsPivot.Cells[5, 1, 5, 7].Value = sReportName;
                                    wsPivot.Cells[6, 1, 6, 7].Value = "From : " + dtFrmDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();
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


            //#region MyRegion
            //if (false)
            //{
            //    //Excel File creation Process Starting
            //    FileInfo inf_file = cls_ReportUtils.GetFileInfo("SalesReportDetail_InvoiceItemWise.xlsx");
            //    using (ExcelPackage pckFile = new ExcelPackage(inf_file))
            //    {
            //        if (lstSales.Count > 0)
            //        {
            //            #region Raw Data Worksheet
            //            //Create an Excel Worksheet called "Raw_Data"
            //            //var vWS_Data = pckFile.Workbook.Worksheets.Add("Raw_Data");

            //            ////Load Raw data in to "Raw_Data" sheet
            //            //var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
            //            //    (from oPaslip_Record in lstSales orderby oPaslip_Record.SalesRep select oPaslip_Record,
            //            //    true,
            //            //    OfficeOpenXml.Table.TableStyles.Medium2);

            //            ////Set up Cell formattings in "Raw_Data" sheet
            //            //vWS_Data.Cells[3, 2, dataRange.End.Row, 2].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
            //            //vWS_Data.Cells[3, 9, dataRange.End.Row, 9].Style.Numberformat.Format = "#,##0.00";//SellingPrice
            //            //vWS_Data.Cells[3, 10, dataRange.End.Row, 10].Style.Numberformat.Format = "#,##0.00";//TotalQty
            //            //vWS_Data.Cells[3, 11, dataRange.End.Row, 11].Style.Numberformat.Format = "#,##0.00";//SubTotal
            //            //vWS_Data.Cells[3, 12, dataRange.End.Row, 12].Style.Numberformat.Format = "#,##0.00";//Discount
            //            //vWS_Data.Cells[3, 13, dataRange.End.Row, 13].Style.Numberformat.Format = "#,##0.00";//NetAmount
            //            //vWS_Data.Cells[3, 14, dataRange.End.Row, 14].Style.Numberformat.Format = "#,##0.00";//AvgPrice
            //            //vWS_Data.Cells[3, 15, dataRange.End.Row, 15].Style.Numberformat.Format = "#,##0.00";//NBTAmount
            //            //vWS_Data.Cells[3, 16, dataRange.End.Row, 16].Style.Numberformat.Format = "#,##0.00";//VATAmount
            //            //vWS_Data.Cells[3, 17, dataRange.End.Row, 17].Style.Numberformat.Format = "#,##0.00";//InvoiceAmount
            //            //vWS_Data.Cells[3, 18, dataRange.End.Row, 18].Style.Numberformat.Format = "#,##0.00";//SVATAmount

            //            ////Setup Column width in "Raw_Data" sheet
            //            //dataRange.AutoFitColumns();
            //            #endregion

            //            #region Pivot Table Worksheet
            //            ////Create a new excel worksheet for "Pivot Table Creation"
            //            //var wsPivot = pckFile.Workbook.Worksheets.Add("Pivot_SalaryRegister");

            //            ////Setup the starting point and data for the Pivot Table 
            //            //var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");

            //            //#region Pivot Table - Raw Arrangement
            //            //var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[7]);
            //            //vDataCol_1.Outline = false;
            //            //vDataCol_1.Compact = false;
            //            //vDataCol_1.ShowAll = false;
            //            //vDataCol_1.SubtotalTop = false;

            //            //var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[0]);
            //            //vDataCol_2.Outline = false;
            //            //vDataCol_2.Compact = false;
            //            //vDataCol_2.ShowAll = false;
            //            //vDataCol_2.SubtotalTop = false;
            //            //vDataCol_2.ShowInFieldList = false;
            //            //vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

            //            //var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
            //            //vDataCol_3.Outline = false;
            //            //vDataCol_3.Compact = false;
            //            //vDataCol_3.ShowAll = false;
            //            //vDataCol_3.SubtotalTop = false;
            //            //vDataCol_3.ShowInFieldList = false;
            //            #endregion

            //            //#region Pivot Table - Column Arrangement
            //            //pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[3]);
            //            //#endregion

            //            //#region Pivot Table - Data Value Arrangement
            //            //var dPayslipAmount = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[4]);
            //            //dPayslipAmount.Format = "#,##0.00";
            //            //#endregion

            //            //var vFilter_Field_1 = pivot_DataTable.Fields[6];
            //            //pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place


            //            //#region Pivot Table Formattings
            //            //pivot_DataTable.ShowDrill = false;
            //            ///*
            //            //pivot_DataTable.Compact = false;
            //            //pivot_DataTable.CompactData = false;
            //            //pivot_DataTable.Indent = 0;
            //            //pivot_DataTable.RowGrandTotals = false;
            //            //pivot_DataTable.UseAutoFormatting = true;
            //            //pivot_DataTable.ShowMemberPropertyTips = false;
            //            //pivot_DataTable.DataOnRows = false;
            //            //*/
            //            //#endregion

            //            //#endregion

            //            #region Report Header

            //            //#region Top Left
            //            ////using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Title.Style.Font.Size = 18;
            //            ////    Title.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Title.Value = "Printed Date : " + DateTime.Now.Date.ToString("dd-mmm-yyyy") + " " + DateTime.Now.TimeOfDay.ToString("hh:mm");
            //            ////}
            //            ////using (ExcelRange Title = wsPivot.Cells[2, 1, 2, 1])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Title.Style.Font.Size = 18;
            //            ////    Title.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Title.Value = "Sales Detail Report (Invoice  & Item Wise)";
            //            ////}
            //            ////using (ExcelRange Title = wsPivot.Cells[3, 1, 3, 1])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Title.Style.Font.Size = 18;
            //            ////    Title.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Title.Value = "From : " + dtmFrm.Date + " - To :" + dtmTo.Date;
            //            ////}
            //            //#endregion

            //            //#region Top Right
            //            ////using (ExcelRange Company_Name = wsPivot.Cells[1, 17, 1, 17])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Company_Name.Style.Font.Size = 14;
            //            ////    Company_Name.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Company_Name.Value = clsSecurity.CompanyName;
            //            ////}
            //            ////using (ExcelRange Company_Address1 = wsPivot.Cells[2, 17, 2, 17])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Company_Address1.Style.Font.Size = 12;
            //            ////    Company_Address1.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Company_Address1.Value = clsSecurity.CompanyAddress1;
            //            ////}
            //            ////using (ExcelRange Company_Address2 = wsPivot.Cells[3, 17, 3, 17])
            //            ////{
            //            ////    //Title.Merge = true;
            //            ////    Company_Address2.Style.Font.Size = 12;
            //            ////    Company_Address2.Style.Font.Bold = true;
            //            ////    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            ////    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
            //            ////    Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            //            ////    Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            //            ////    //Title.Style.TextRotation = 90;
            //            ////    Company_Address2.Value = clsSecurity.CompanyAddress2;
            //            ////}

            //            //////Report Image
            //            ////using (var ms = new MemoryStream(clsCommon.getCompanyImage()))
            //            ////{
            //            ////    int rowIndex = wsPivot.Dimension.Start.Row;
            //            ////    int colIndex = wsPivot.Dimension.End.Column;
            //            ////    //int PixelTop = 88;
            //            ////    //int PixelLeft = 129;
            //            ////    int iWidth = 150;
            //            ////    int iHeight = 75;

            //            ////    Image img = Image.FromStream(ms);
            //            ////    OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("CompanyImage", img);
            //            ////    pic.SetPosition(0, 0, 18, 0);
            //            ////    //pic.SetPosition(PixelTop, PixelLeft);  
            //            ////    pic.SetSize(iWidth, iHeight);
            //            ////    //pic.SetSize(40);
            //            ////}
            //            //#endregion

            //            #endregion

            //            //Excel File Save
            //            pckFile.Save();
            //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //} 
            //#endregion

        }
        #endregion
    }
}
