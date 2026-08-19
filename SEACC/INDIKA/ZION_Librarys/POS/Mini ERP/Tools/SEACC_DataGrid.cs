using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Digiteq
{
   public class SEACC_DataGrid : System.Windows.Forms.DataGridView
    {
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmi_Excel;
      //  private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
       // private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
      //  private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
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

        void tsmi_Excel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application WsObj = new Microsoft.Office.Interop.Excel.Application();
            WsObj.Application.Workbooks.Add(Type.Missing);
            WsObj.Visible = false;
            WsObj.Cells[1, 1] = "Created Date & Time : " + DateTime.Now.ToString();
            WsObj.Range[WsObj.Cells[1, 1], WsObj.Cells[1, 5]].Merge();
            try
            {
                int row = 2; int col = 1;
                DataTable dt = ((DataTable)this.DataSource);
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
                      //  WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;
                        col++;
                    }
                    col = 1;
                    row++;
                }

                WsObj.Columns.AutoFit();

               SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Text documents (.xls)|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filename = dlg.FileName;
                    WsObj.ActiveWorkbook.SaveCopyAs(filename);

                    MessageBox.Show("done");
                  //  SEACCMessageBox.Show("successfully Created", "Excel File is successfully created", MessageBoxButton.OK);
                }
                WsObj.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             //   SEACCExeption.Show(ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                Marshal.FinalReleaseComObject(WsObj);
            }
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
