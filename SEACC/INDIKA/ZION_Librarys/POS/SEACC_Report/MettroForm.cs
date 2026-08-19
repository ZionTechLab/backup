using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_Report
{
    public partial class MettroForm : Form
    {
        public delegate void dBtnClick(object sender, EventArgs e);
        public event dBtnClick Settings_Click;

        private const int CS_DROPSHADOW = 0x20000;
        public MettroForm()
        {
            InitializeComponent();
            ucTittleBar1.DisplayName = this.Text;
        }
        public System.Drawing.Color ThemeColor
        {
            get
            {
                return this.ucTittleBar1.BackColor;
            }
            set
            {
                this.ucTittleBar1.BackColor = value;
                this.pnlRight.BackColor = value;
                this.pnlLeft.BackColor = value;
                this.pnlBottom.BackColor = value;

                this.btn_Close.BackColor = value;
                this.btn_minimize.BackColor = value;
                this.btnSettings.BackColor = value;

                this.btnSettings.FlatAppearance.MouseDownBackColor = ControlPaint.Light(value);
                this.btnSettings.FlatAppearance.MouseOverBackColor = ControlPaint.Light(value);
                this.btn_minimize.FlatAppearance.MouseDownBackColor = ControlPaint.Light(value);
                this.btn_minimize.FlatAppearance.MouseOverBackColor = ControlPaint.Light(value);
                this.btn_Close.FlatAppearance.MouseDownBackColor = ControlPaint.Light(value);
                this.btn_Close.FlatAppearance.MouseOverBackColor = ControlPaint.Light(value);
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucTittleBar1.DisplayName = this.Text;
        }
     
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Settings_Click(sender, e);
            }
            catch (Exception)
            {
            }
        }
    }
}
