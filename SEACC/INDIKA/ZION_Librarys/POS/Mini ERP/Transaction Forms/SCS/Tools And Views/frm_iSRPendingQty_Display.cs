using Digiteq_Logic;
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
    public partial class frm_iSRPendingQty_Display : Form
    {
        public frm_iSRPendingQty_Display()
        {
            InitializeComponent();
        }

        private void frm_iSRPendingQty_Display_Load(object sender, EventArgs e)
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorStock1, clsFormatter.colorDigiteqTheamColorStockForColour, clsFormatter.colorDigiteqTheamColorStockBackColour);
        }

        public void ShowDetails(DataTable dt)
        {
            dgvDetail.DataSource = dt.DefaultView;
            this.Show();
        }
    }
}
