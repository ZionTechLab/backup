using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using System.IO;
using Digiteq_Logic;
using OfficeOpenXml.Table;

namespace Digiteq
{
    public class SEACC_DataGrid : System.Windows.Forms.DataGridView
    {
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmi_Excel;


        public SEACC_DataGrid()
        {
            contextMenuStrip1 = new ContextMenuStrip();
            tsmi_Excel = new ToolStripMenuItem();

            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Excel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);

            this.tsmi_Excel.Text = "Export to Excel";
            this.tsmi_Excel.Click += tsmi_Excel_Click;

            this.MouseUp += SEACC_DataGrid_MouseUp;
        }
        public void PrintReport(string Filter)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Text documents (.xls)|*.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileInfo files = new FileInfo(dlg.FileName);

                    string filename = dlg.FileName;

                    DataTable dt;

                    if (this.DataSource is BindingSource)
                        dt = Table(((BindingSource)this.DataSource)).Copy();
                    else if (this.DataSource is DataSet)
                        dt = ((DataSet)this.DataSource).Tables[this.DataMember].Copy();
                    else if (this.DataSource is DataTable)
                        dt = ((DataTable)this.DataSource).Copy();
                    else if (this.DataSource is DataView)
                        dt = ((DataView)this.DataSource).ToTable().Copy();
                    else
                        dt = WithoutDatasource();

                    if (dt != null)
                    {
                        using (ExcelPackage pck = new ExcelPackage(files))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet 1");

                            ws.Cells["A2"].Value = clsSecurity.CompanyName;
                            ws.Cells["A3"].Value = this.Tag != null ? this.Tag.ToString() : "-";
                            ws.Cells["A4"].Value = "Selection - " + Filter;
                            ws.Cells["A5"].Value = "Printed by - " + clsSecurity.UserName + " Date/Time - " + clsSecurity.getServerDateTime().ToString("yyyy-MM-dd hh:mm tt");

                            ws.Cells["A7"].LoadFromDataTable(dt, true);
                            ExcelRange range = ws.Cells[7, 1, dt.Rows.Count + 7, (dt.Columns.Count)];
                            ExcelTable Table = ws.Tables.Add(range, "Table1");

                            Table.ShowFilter = true;
                            Table.ShowTotal = true;

                            int i = 0;
                            foreach (DataColumn dtRow in dt.Columns)
                            {
                                var x = dtRow.DataType.Name.ToString();

                                Table.Columns[i].Name = dtRow.ColumnName.Replace("_", " ");
                                if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                {
                                    Table.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                              
                                }
                                i++;
                            }

                            Table.Columns[0].TotalsRowLabel = "Total ";
                            Table.TableStyle = TableStyles.Medium2;

                            pck.Save();
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void tsmi_Excel_Click(object sender, EventArgs e)
        {
            PrintReport("");
        }
        private DataTable Table(BindingSource bs)
        {
            var bsFirst = bs;
            while (bsFirst.DataSource is BindingSource)
                bsFirst = (BindingSource)bsFirst.DataSource;

            DataTable dt;
            if (bsFirst.DataSource is DataSet)
                dt = ((DataSet)bsFirst.DataSource).Tables[bsFirst.DataMember];
            else if (bsFirst.DataSource is DataTable)
                dt = (DataTable)bsFirst.DataSource;
            else
                return null;

            if (bsFirst != bs)
            {
                if (dt.DataSet == null) return null;
                dt = dt.DataSet.Relations[bs.DataMember].ChildTable;
            }

            return dt;
        }
        private DataTable WithoutDatasource()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in this.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in this.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }

        void SEACC_DataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(this.PointToScreen(e.Location));
            }
        }
    }
}
