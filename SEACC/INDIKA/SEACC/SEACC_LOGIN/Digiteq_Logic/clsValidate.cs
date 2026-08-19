using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_LOGIN.Digiteq_Logic
{
  public  class clsValidate
    {
        public static string ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, string sDefaultValue)
        {
            string value = sDefaultValue;
            if (dgvDataGrid.Columns.Contains(sColumname))
                if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                    value = dgvDataGrid[sColumname, iRowIndex].Value.ToString();
            return value;
        }
        public static bool ValidateTextBox_EmptyValue(TextBox txtBox, string sMessage)
        {
            bool bValue = true;
            Color colBack = txtBox.BackColor;
            if (txtBox.Text.Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BackColor = Color.FromArgb(250, 244, 133);
            }

            if (bValue == false)
            {
                MessageBox.Show("ERROR");
                txtBox.BackColor = colBack;
            }
            return bValue;
        }
    }
}
