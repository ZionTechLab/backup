using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frmTransactionList : MettroForm
    {
        public delegate void ResultString(string sResult);
        public event ResultString Selection;

        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
            frmTransactionList.ActiveForm.Focus();
        }

        private void frmTransactionList_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public frmTransactionList(DataTable _dt,string[] cloumnHeaders,String sUiHeader )
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _dt;
           
            dataGridView1.Columns[0].HeaderText = cloumnHeaders[0];
            dataGridView1.Columns[1].HeaderText = cloumnHeaders[1];
            dataGridView1.Columns[2].HeaderText = cloumnHeaders[2];

            this.Text = sUiHeader;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sTxnID = dataGridView1[0, e.RowIndex].Value.ToString();
                if (sTxnID != "")
                {
                    Selection(sTxnID);
                    Close();
                }
            }

        }

    }
}
