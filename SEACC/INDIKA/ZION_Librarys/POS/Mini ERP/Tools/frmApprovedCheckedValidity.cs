using DataTire;
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
    public partial class frmApprovedCheckedValidity : Form
    {      
        public frmApprovedCheckedValidity()
        {
            InitializeComponent();
        }

        public void ShowWindow(int x,int y,DataTable dt)
        {
            this.Show();
            this.Location= new System.Drawing.Point(x, y-this.Height-75);
            dgvUserDetails.DataSource = dt.DefaultView;
        }
      
        private void frmApprovedCheckedValidity_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
