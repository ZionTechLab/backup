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

namespace Digiteq
{
    public class cls_SalaryRegister
    {
        #region Report Data Strcture
        //Data Object Strcture
        //Data set for the report
        public class cls_SalaryRegister_DTO
        {
            public string sEmployee_ID { get; set; }
            public string sEmployee_Name { get; set; }
            public string dPayslip_ItemID { get; set; }
            public string dPayslip_Item { get; set; }
            public decimal dSlary_Amount { get; set; }
            public DateTime dtmFrom_Date { get; set; }
            public DateTime dtmTo_Date { get; set; }
            public string dDepatment_Name { get; set; }
        }
        #endregion

        #region Report Generation
        //Report Generating Method
        public static string Run_SalaryRegister(DateTime dtmFrm, DateTime dtmTo)
        {
            //Create list of Data Ojects
            var lstEmp_SalaryRows = new List<cls_SalaryRegister_DTO>();

            #region Fill Data Object List
            //Fill the data object list
            foreach (tbl_payTxSIPRawData oPayroll_Record in tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFrm.Date, dtmTo.Date))
            {
                foreach (tbl_payTxSIPRawData_PaySlipItems oPayslip_ITem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oPayroll_Record.SIP_ID).OrderBy(r => r.PayItem_ID))
                {
                    lstEmp_SalaryRows.Add(
                        new cls_SalaryRegister_DTO()
                        {
                            sEmployee_ID = oPayroll_Record.Employee_ID,
                            sEmployee_Name = clsRef_Name.get_EmployeeName(oPayroll_Record.Employee_ID),
                            dPayslip_ItemID = oPayslip_ITem.PayItem_ID,
                            dPayslip_Item = clsRef_Name.get_PaySlipItem_Title(oPayslip_ITem.PayItem_ID),
                            dSlary_Amount = oPayslip_ITem.Amount,
                            dtmFrom_Date = oPayroll_Record.ProcessPeriod_Sub_startDate.Date,
                            dtmTo_Date = oPayroll_Record.ProcessPeriod_Sub_endDate,
                            dDepatment_Name = clsRef_Name.get_Department_Name(oPayroll_Record.Department_ID)
                        }
                        );
                }
            }
            #endregion

            //Excel File creation Process Starting
            FileInfo inf_file = cls_ReportUtils.GetFileInfo("salary_register.xlsx");
            using (ExcelPackage pckFile = new ExcelPackage(inf_file))
            {
                #region Raw Data Worksheet
                //Create an Excel Worksheet called "Raw_Data"
                var vWS_Data = pckFile.Workbook.Worksheets.Add("Raw_Data");

                //Load Raw data in to "Raw_Data" sheet
                var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                    (from oPaslip_Record in lstEmp_SalaryRows
                     orderby oPaslip_Record.sEmployee_ID, oPaslip_Record.sEmployee_Name
                     select oPaslip_Record, true, OfficeOpenXml.Table.TableStyles.Medium2);

                //Set up Cell formattings in "Raw_Data" sheet
                vWS_Data.Cells[2, 6, dataRange.End.Row, 6].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                vWS_Data.Cells[2, 7, dataRange.End.Row, 7].Style.Numberformat.Format = "dd-mmm-yyyy";//Period To Date
                vWS_Data.Cells[2, 5, dataRange.End.Row, 5].Style.Numberformat.Format = "#,##0.00";//Amount

                //Setup Column width in "Raw_Data" sheet
                dataRange.AutoFitColumns();
                #endregion

                #region Pivot Table Worksheet
                //Create a new excel worksheet for "Pivot Table Creation"
                var wsPivot = pckFile.Workbook.Worksheets.Add("Pivot_SalaryRegister");

                //Setup the starting point and data for the Pivot Table 
                var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");

                #region Pivot Table - Raw Arrangement
                var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[7]);
                vDataCol_1.Outline = false;
                vDataCol_1.Compact = false;
                vDataCol_1.ShowAll = false;
                vDataCol_1.SubtotalTop = false;

                var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[0]);
                vDataCol_2.Outline = false;
                vDataCol_2.Compact = false;
                vDataCol_2.ShowAll = false;
                vDataCol_2.SubtotalTop = false;
                vDataCol_2.ShowInFieldList = false;
                vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

                var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
                vDataCol_3.Outline = false;
                vDataCol_3.Compact = false;
                vDataCol_3.ShowAll = false;
                vDataCol_3.SubtotalTop = false;
                vDataCol_3.ShowInFieldList = false;
                #endregion

                #region Pivot Table - Column Arrangement
                pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[3]);
                #endregion

                #region Pivot Table - Data Value Arrangement
                var dPayslipAmount = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[4]);
                dPayslipAmount.Format = "#,##0.00";
                #endregion

                var vFilter_Field_1 = pivot_DataTable.Fields[6];
                pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place


                #region Pivot Table Formattings
                pivot_DataTable.ShowDrill = false;
                /*
                pivot_DataTable.Compact = false;
                pivot_DataTable.CompactData = false;
                pivot_DataTable.Indent = 0;
                pivot_DataTable.RowGrandTotals = false;
                pivot_DataTable.UseAutoFormatting = true;
                pivot_DataTable.ShowMemberPropertyTips = false;
                pivot_DataTable.DataOnRows = false;
                */
                #endregion

                #endregion

                #region Report Header

                #region Top Left
                using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
                {
                    //Title.Merge = true;
                    Title.Style.Font.Size = 18;
                    Title.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    //Title.Style.TextRotation = 90;
                    Title.Value = "Employee Salary Register";
                }
                #endregion

                #region Top Right
                using (ExcelRange Company_Name = wsPivot.Cells[1, 23, 1, 23])
                {
                    //Title.Merge = true;
                    Company_Name.Style.Font.Size = 14;
                    Company_Name.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Name.Value = clsSecurity.CompanyName;
                }
                using (ExcelRange Company_Address1 = wsPivot.Cells[2, 23, 2, 23])
                {
                    //Title.Merge = true;
                    Company_Address1.Style.Font.Size = 12;
                    Company_Address1.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Address1.Value = clsSecurity.CompanyAddress1;
                }
                using (ExcelRange Company_Address2 = wsPivot.Cells[3, 23, 3, 23])
                {
                    //Title.Merge = true;
                    Company_Address2.Style.Font.Size = 12;
                    Company_Address2.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Address2.Value = clsSecurity.CompanyAddress2;
                }

                //Report Image
                using (var ms = new MemoryStream(clsCommon.getCompanyImage()))
                {
                    int rowIndex = wsPivot.Dimension.Start.Row;
                    int colIndex = wsPivot.Dimension.End.Column;
                    //int PixelTop = 88;
                    //int PixelLeft = 129;
                    int iWidth = 150;
                    int iHeight = 75;

                    Image img = Image.FromStream(ms);
                    OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("Sample", img);
                    pic.SetPosition(0, 0, 23, 0);
                    //pic.SetPosition(PixelTop, PixelLeft);  
                    pic.SetSize(iWidth, iHeight);
                    //pic.SetSize(40);
                }
                #endregion

                #endregion

                //Excel File Save
                pckFile.Save();
            }

            return inf_file.FullName;
        }

        public static string Run_SalaryRegister_New(DateTime dtmFrm, DateTime dtmTo)
        {
            //Create list of Data Ojects
            var lstEmp_SalaryRows = new List<cls_SalaryRegister_DTO>();

            #region Fill Data Object List
            //Fill the data object list
            foreach (tbl_payTxSIPRawData oPayroll_Record in tbl_payTxSIPRawData.SelectPeriod_ByDateRange(dtmFrm.Date, dtmTo.Date))
            {
                foreach (tbl_payTxSIPRawData_PaySlipItems oPayslip_ITem in tbl_payTxSIPRawData_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(clsSecurity.CompanyID, clsSecurity.BranchID, oPayroll_Record.SIP_ID).OrderBy(r => r.PayItem_ID))
                {
                    lstEmp_SalaryRows.Add(
                        new cls_SalaryRegister_DTO()
                        {
                            sEmployee_ID = oPayroll_Record.Employee_ID,
                            sEmployee_Name = clsRef_Name.get_EmployeeName(oPayroll_Record.Employee_ID),
                            dPayslip_ItemID = oPayslip_ITem.PayItem_ID,
                            dPayslip_Item = clsRef_Name.get_PaySlipItem_Title(oPayslip_ITem.PayItem_ID),
                            dSlary_Amount = oPayslip_ITem.Amount,
                            dtmFrom_Date = oPayroll_Record.ProcessPeriod_Sub_startDate.Date,
                            dtmTo_Date = oPayroll_Record.ProcessPeriod_Sub_endDate,
                            dDepatment_Name = clsRef_Name.get_Department_Name(oPayroll_Record.Department_ID)
                        }
                        );
                }
            }
            #endregion

            //Excel File creation Process Starting
            FileInfo inf_file = cls_ReportUtils.GetFileInfo("salary_register.xlsx");
            using (ExcelPackage pckFile = new ExcelPackage(inf_file))
            {
                #region Raw Data Worksheet
                //Create an Excel Worksheet called "Raw_Data"
                var vWS_Data = pckFile.Workbook.Worksheets.Add("Raw_Data");

                //Load Raw data in to "Raw_Data" sheet
                var dataRange = vWS_Data.Cells["A1"].LoadFromCollection
                    (from oPaslip_Record in lstEmp_SalaryRows
                     orderby oPaslip_Record.sEmployee_ID, oPaslip_Record.sEmployee_Name
                     select oPaslip_Record, true, OfficeOpenXml.Table.TableStyles.Medium2);

                //Set up Cell formattings in "Raw_Data" sheet
                vWS_Data.Cells[2, 6, dataRange.End.Row, 6].Style.Numberformat.Format = "dd-mmm-yyyy";//Period From Date
                vWS_Data.Cells[2, 7, dataRange.End.Row, 7].Style.Numberformat.Format = "dd-mmm-yyyy";//Period To Date
                vWS_Data.Cells[2, 5, dataRange.End.Row, 5].Style.Numberformat.Format = "#,##0.00";//Amount

                //Setup Column width in "Raw_Data" sheet
                dataRange.AutoFitColumns();
                #endregion

                #region Pivot Table Worksheet
                //Create a new excel worksheet for "Pivot Table Creation"
                var wsPivot = pckFile.Workbook.Worksheets.Add("Pivot_SalaryRegister");

                //Setup the starting point and data for the Pivot Table 
                var pivot_DataTable = wsPivot.PivotTables.Add(wsPivot.Cells["A8"], dataRange, "Pivot_Table");

                #region Pivot Table - Raw Arrangement
                var vDataCol_1 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[7]);
                vDataCol_1.Outline = false;
                vDataCol_1.Compact = false;
                vDataCol_1.ShowAll = false;
                vDataCol_1.SubtotalTop = false;

                var vDataCol_2 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[0]);
                vDataCol_2.Outline = false;
                vDataCol_2.Compact = false;
                vDataCol_2.ShowAll = false;
                vDataCol_2.SubtotalTop = false;
                vDataCol_2.ShowInFieldList = false;
                vDataCol_2.SubTotalFunctions = OfficeOpenXml.Table.PivotTable.eSubTotalFunctions.None;

                var vDataCol_3 = pivot_DataTable.RowFields.Add(pivot_DataTable.Fields[1]);
                vDataCol_3.Outline = false;
                vDataCol_3.Compact = false;
                vDataCol_3.ShowAll = false;
                vDataCol_3.SubtotalTop = false;
                vDataCol_3.ShowInFieldList = false;
                #endregion

                #region Pivot Table - Column Arrangement
                pivot_DataTable.ColumnFields.Add(pivot_DataTable.Fields[3]);
                #endregion

                #region Pivot Table - Data Value Arrangement
                var dPayslipAmount = pivot_DataTable.DataFields.Add(pivot_DataTable.Fields[4]);
                dPayslipAmount.Format = "#,##0.00";
                #endregion

                var vFilter_Field_1 = pivot_DataTable.Fields[6];
                pivot_DataTable.PageFields.Add(vFilter_Field_1); // should add field into desired place


                #region Pivot Table Formattings
                pivot_DataTable.ShowDrill = false;
                /*
                pivot_DataTable.Compact = false;
                pivot_DataTable.CompactData = false;
                pivot_DataTable.Indent = 0;
                pivot_DataTable.RowGrandTotals = false;
                pivot_DataTable.UseAutoFormatting = true;
                pivot_DataTable.ShowMemberPropertyTips = false;
                pivot_DataTable.DataOnRows = false;
                */
                #endregion

                #endregion

                #region Report Header

                #region Top Left
                using (ExcelRange Title = wsPivot.Cells[1, 1, 1, 1])
                {
                    //Title.Merge = true;
                    Title.Style.Font.Size = 18;
                    Title.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Title.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Title.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    //Title.Style.TextRotation = 90;
                    Title.Value = "Employee Salary Register";
                }
                #endregion

                #region Top Right
                using (ExcelRange Company_Name = wsPivot.Cells[1, 23, 1, 23])
                {
                    //Title.Merge = true;
                    Company_Name.Style.Font.Size = 14;
                    Company_Name.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Name.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Name.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Name.Value = clsSecurity.CompanyName;
                }
                using (ExcelRange Company_Address1 = wsPivot.Cells[2, 23, 2, 23])
                {
                    //Title.Merge = true;
                    Company_Address1.Style.Font.Size = 12;
                    Company_Address1.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Address1.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Address1.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Address1.Value = clsSecurity.CompanyAddress1;
                }
                using (ExcelRange Company_Address2 = wsPivot.Cells[3, 23, 3, 23])
                {
                    //Title.Merge = true;
                    Company_Address2.Style.Font.Size = 12;
                    Company_Address2.Style.Font.Bold = true;
                    //Title.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //Title.Style.Fill.BackgroundColor.SetColor(systemColor);
                    Company_Address2.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Company_Address2.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    //Title.Style.TextRotation = 90;
                    Company_Address2.Value = clsSecurity.CompanyAddress2;
                }

                //Report Image
                using (var ms = new MemoryStream(clsCommon.getCompanyImage()))
                {
                    int rowIndex = wsPivot.Dimension.Start.Row;
                    int colIndex = wsPivot.Dimension.End.Column;
                    //int PixelTop = 88;
                    //int PixelLeft = 129;
                    int iWidth = 150;
                    int iHeight = 75;

                    Image img = Image.FromStream(ms);
                    OfficeOpenXml.Drawing.ExcelPicture pic = wsPivot.Drawings.AddPicture("Sample", img);
                    pic.SetPosition(0, 0, 23, 0);
                    //pic.SetPosition(PixelTop, PixelLeft);  
                    pic.SetSize(iWidth, iHeight);
                    //pic.SetSize(40);
                }
                #endregion

                #endregion

                //Excel File Save
                pckFile.Save();
            }

            return inf_file.FullName;
        }
        #endregion
    }
}
