using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class MessegeBox : Form
    {
        public MessegeBox()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void ShowMessege(string Header,string messege)
        {
            lblHeader.Text = Header;
            lblMessege.Text = messege;

            this.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
