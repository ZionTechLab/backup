using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class frm_PickBox_Mini : frm_PickBox
    {
     
        public frm_PickBox_Mini()
        {
            InitializeComponent();
            dgv1.RowTemplate.Height = 15;
        }
        public frm_PickBox_Mini(ref TextBox txtbox)
        {
            InitializeComponent();
            dgv1.RowTemplate.Height = 15;
            Point locationOnForm = txtbox.PointToScreen(Point.Empty);
            this.Location = new System.Drawing.Point(locationOnForm.X, locationOnForm.Y + txtbox.Height);
            this.Width = txtbox.Width;
        }
        public void Pick(string PickID, ref TextBox tbx)
        {
            strPickId = PickID;
            this.Show();
            Tbx = tbx;
           // this.Deactivate += frm_PickBox_Mini_Deactivate;
            //this.clic
           // tbx.Tag = lstReturn[0];
           // tbx.Text = lstReturn[1];

            Resize_Grid();
        }

        void frm_PickBox_Mini_Deactivate(object sender, EventArgs e)
        {
            this.Close();

            //throw new NotImplementedException();
        }
        private void frm_PickBox_Mini_Load(object sender, EventArgs e)
        {
            statusStrip1.Enabled = false;
            statusStrip1.Visible = false;

            Resize_Grid();

           // this.dgv1.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
           // this.dgv1.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
        }
        private void Resize_Grid()
        {
            dgv1.ColumnHeadersVisible = false;
            this.Height = dgv1.RowCount >= 16 ? 15 * 15 : (dgv1.RowCount + 1) * 15;

            dgv1.ScrollBars = dgv1.RowCount >= 16 ? ScrollBars.Vertical : ScrollBars.None;
            dgv1.BackgroundColor = Color.White;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
            this.Opacity = 0.7;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Opacity = 1;
            i = 0;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 15)
                this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
