using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_WPFControls.Logic
{
 public   class clsExport_EP
    {
        public void Export_To_Excel(string Filter, DataTable dt)
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

                    //DataTable dt;

                    //if (this.DataSource is BindingSource)
                    //    dt = Table(((BindingSource)this.DataSource)).Copy();
                    //else if (this.DataSource is DataSet)
                    //    dt = ((DataSet)this.DataSource).Tables[this.DataMember].Copy();
                    //else if (this.DataSource is DataTable)
                    //    dt = ((DataTable)this.DataSource).Copy();
                    //else if (this.DataSource is DataView)
                    //    dt = ((DataView)this.DataSource).ToTable().Copy();
                    //else
                    //    dt = WithoutDatasource();

                    if (dt != null)
                    {
                        using (ExcelPackage pck = new ExcelPackage(files))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet 1");

                          //  ws.Cells["A2"].Value = clsSecurity.CompanyName;
                        //    ws.Cells["A3"].Value = this.Tag != null ? this.Tag.ToString() : "-";
                            ws.Cells["A4"].Value = "Selection - " + Filter;
                       //     ws.Cells["A5"].Value = "Printed by - " + clsSecurity.UserName + " Date/Time - " + clsSecurity.getServerDateTime().ToString("yyyy-MM-dd hh:mm tt");

                            ws.Cells["A7"].LoadFromDataTable(dt, true);
                            ExcelRange range = ws.Cells[7, 1, dt.Rows.Count + 7, (dt.Columns.Count)];
                            ExcelTable tab = ws.Tables.Add(range, "Table1");

                            tab.ShowFilter = true;
                            tab.ShowTotal = true;

                            int i = 0;
                            foreach (DataColumn dtRow in dt.Columns)
                            {
                                var x = dtRow.DataType.Name.ToString();

                                tab.Columns[i].Name = dtRow.ColumnName.Replace("_", " ");
                                if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                {
                                    tab.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                }
                                i++;
                            }

                            tab.Columns[0].TotalsRowLabel = "Total ";
                            tab.TableStyle = TableStyles.Medium2;

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
    }
}
