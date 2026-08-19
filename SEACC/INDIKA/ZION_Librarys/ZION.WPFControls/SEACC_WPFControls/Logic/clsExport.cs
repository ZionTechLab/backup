using System;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;

namespace SEACC_WPFControls
{
    public class clsExport
    {
        #region Export to Text
        public void ExportToText(DataTable dt)
        {
            try
            {
                int[] maxLengths = new int[dt.Columns.Count];
                string filename = "";

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    maxLengths[i] = dt.Columns[i].ColumnName.Length;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (!row.IsNull(i))
                        {
                            int length = row[i].ToString().Length;

                            if (length > maxLengths[i])
                            {
                                maxLengths[i] = length;
                            }
                        }
                    }
                }

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    filename = dlg.FileName;
                    using (StreamWriter sw = new StreamWriter(filename, false))
                    {
                        sw.WriteLine("Created Date & Time : "+ DateTime.Now.ToString());

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                        }

                        sw.WriteLine();

                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (!row.IsNull(i))
                                {
                                    sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                                }
                                else
                                {
                                    sw.Write(new string(' ', maxLengths[i] + 2));
                                }
                            }
                            sw.WriteLine();
                        }
                        sw.Close();
                        SEACCMessageBox.Show("successfully Created", "Text File is successfully created", MessageBoxButton.OK);
                    }
                }
                Process.Start(filename);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Export to Word
        public void ExportToWord(DataTable dt)
        {
            //Create an instance for word app
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                document.Paragraphs.SpaceAfter = 0;
                document.Paragraphs.LineSpacing = 12;

                //Add header into the document
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Created Date & Time : "+DateTime.Now.ToString();
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Digiteq";
                }

                //adding text to document
                document.Content.SetRange(0, 0);
                //document.Content.Text = "This is test document " + Environment.NewLine;

                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                //Create a  table and insert some records
                Microsoft.Office.Interop.Word.Table firstTable = document.Tables.Add(para1.Range, dt.Rows.Count, dt.Columns.Count, ref missing, ref missing);

                firstTable.Borders.Enable = 1;

                int rowCount = 0;
                foreach (Microsoft.Office.Interop.Word.Row row in firstTable.Rows)
                {
                    int columnCount = 0;
                    foreach (Microsoft.Office.Interop.Word.Cell cell in row.Cells)
                    {
                        //Header row
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = dt.Columns[columnCount].ColumnName;// "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                            cell.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray25;
                            //Center alignment for the Header cells
                            cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        //Data row
                        else
                        {
                            cell.Range.Text = dt.Rows[rowCount][columnCount].ToString();  //(cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                        columnCount++;
                    }
                    rowCount++;
                }

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".doc";
                dlg.Filter = "Text documents (.doc)|*.docx";
                if (dlg.ShowDialog() == true)
                {
                    object filename = dlg.FileName;
                    document.SaveAs(ref filename);
                    SEACCMessageBox.Show("successfully Created", "Word File is successfully created", MessageBoxButton.OK);
                    //document.Close(ref missing, ref missing, ref missing);
                    //document = null;
                    //winword.Quit(ref missing, ref missing, ref missing);
                }
                winword.Visible = true;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                Marshal.FinalReleaseComObject(winword);
            }
        } 
        #endregion

        #region Export to HTML
        public void ExportToHtml(DataTable dt)
        {
            string html = "<p>Created Date & Time : "+DateTime.Now.ToString()+"</p> <br>";
            html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".html";
            dlg.Filter = "Html documents (.html)|*.html|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;
                try
                {
                    using (StreamWriter oWbObj = new StreamWriter(filename, false))
                    {
                        oWbObj.Write(html);
                    }

                    SEACCMessageBox.Show("successfully Created", "HTML File is successfully created", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Not Saved", ex.Message);
                }
            }

            #region OLD Code
            //List<emailLine> lstEData = new List<emailLine>();
            //EmailLineformating oEmailLineFormat = new EmailLineformating();
            //string sBodyHTML = "<html><head><title>Page Title</title></head><body>";
            //#endregion

            //#region Header
            //lstEData.Add(new emailLine(LineType.H1, "Test Html Export"));
            //lstEData.Add(new emailLine(LineType.H6, clsSecurity.UserNameLoged));
            //lstEData.Add(new emailLine(LineType.H6, clsSecurity.getServerDateTime().ToString()));
            //lstEData.Add(new emailLine(LineType.Line1));
            //#endregion

            //#region Detail
            //lstEData.Add(new emailLine(LineType.DataTable, dt, null));
            //sBodyHTML += SEACC_Alert_Engine.clsEmailEngine.CreateEmailBody(lstEData);
            //sBodyHTML += "</body></html>";
            //#endregion

            //#region File Save
            //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.DefaultExt = ".html";
            //dlg.Filter = "Html documents (.html)|*.html|All files (*.*)|*.*";
            //if (dlg.ShowDialog() == true)
            //{
            //    string filename = dlg.FileName;
            //    try
            //    {
            //        using (StreamWriter oWbObj = new StreamWriter(filename, false))
            //        {
            //            oWbObj.Write(sBodyHTML);
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            #endregion
        } 
        #endregion

        #region Export to Excel
        public void ExportToExcel(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application WsObj = new Microsoft.Office.Interop.Excel.Application();
            WsObj.Application.Workbooks.Add(Type.Missing);
            WsObj.Visible = false;
            WsObj.Cells[1, 1] = "Created Date & Time : "+ DateTime.Now.ToString();
            WsObj.Range[WsObj.Cells[1, 1], WsObj.Cells[1, 5]].Merge();
            try
            {
                int row = 2; int col = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    WsObj.Cells[row, col] = column.ColumnName;
                    WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;
                    WsObj.Cells[row, col].Interior.Color = System.Drawing.Color.LightGray;
                    col++;
                }

                col = 1;
                row++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (var cell in dt.Rows[i].ItemArray)
                    {
                        WsObj.Cells[row, col] = cell;
                        WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;  
                        col++;
                    }
                    col = 1;
                    row++;
                }

                WsObj.Columns.AutoFit();

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Text documents (.xls)|*.xlsx";
                if (dlg.ShowDialog() == true)
                {
                    string filename = dlg.FileName;
                    WsObj.ActiveWorkbook.SaveCopyAs(filename);
                    SEACCMessageBox.Show("successfully Created", "Excel File is successfully created", MessageBoxButton.OK);
                }
                WsObj.Visible = true;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                Marshal.FinalReleaseComObject(WsObj);
            }
        }
        #endregion

        public void ExportToCSV(DataTable dt)
        {
            StringBuilder fileContent = new StringBuilder();
            string filename = "";

            try
            {
                foreach (var col in dt.Columns)
                {
                    fileContent.Append(col.ToString() + ",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

                foreach (DataRow dr in dt.Rows)
                {

                    foreach (var column in dr.ItemArray)
                    {
                        fileContent.Append("\"" + column.ToString() + "\",");
                    }

                    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
                }

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".csv";
                dlg.Filter = "CSV documents (.csv)|*.csv|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    filename = dlg.FileName;
                    System.IO.File.WriteAllText(filename, "Created Date & Time : "+ DateTime.Now.ToString()+"\n"+ fileContent.ToString());
                }
                Process.Start(filename);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

        }
    }
}