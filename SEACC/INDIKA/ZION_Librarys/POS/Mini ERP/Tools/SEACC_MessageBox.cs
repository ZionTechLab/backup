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
    public partial class SEACC_MessageBox : Form
    {
        public SEACC_MessageBox()
        {
            InitializeComponent();
        }

        public SEACC_MessageBox(string title, string description, string header)
        {
            InitializeComponent(); 

            this.lblTitle.Text = title;
            this.lblDescription.Text = description;
            this.Text = header;
        }

        private void SEACC_MessageBox_Load(object sender, EventArgs e)
        {
            //if (lblTitle.Text.Length > 100)
            //    tableLayoutPanel1.Width = lblTitle.Text.Length + 30;
            //else if (lblDescription.Text.Length > 100)
            //    tableLayoutPanel1.Width = lblDescription.Text.Length + 30;

            //this.Width = 15 + tableLayoutPanel1.Width + 30;

            tableLayoutPanel1.Height = lblTitle.Height + lblDescription.Height + 30;
            this.Height = 35 + tableLayoutPanel1.Height + 40;
        }

        public void btnLater_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmLogin frm = new frmLogin();
            //frm.bStatusTrasfer = true;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //frm2.bStatusTrasfer = false;
            //frmMyPortal frm = new frmMyPortal();
            //this.Hide();
            //frm.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SEACC_MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.Cancel;
        }
    }

    #region Class Exception
    public static class SEACCReminderMessageBox
    {
        public static DialogResult Show(string title, string description, string header)
        {
            SEACC_MessageBox oReminder = new SEACC_MessageBox(title, description, header);
            oReminder.ShowDialog();
            return oReminder.DialogResult;
        }
        //public static bool Show(string title, string description, string header)
        //{
        //    SEACC_MessageBox oReminder = new SEACC_MessageBox(title, description, header);
        //    oReminder.ShowDialog();
        //    return (bool)oReminder.DialogResult;
        //}
    }
    #endregion
}
