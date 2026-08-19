using Digiteq_Logic; 
using SEACC.WinFormControls.Forms;
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
    public partial class MettroForm : Form
    {
        public delegate void dBtnClick(object sender, EventArgs e);
        public event dBtnClick Settings_Click;
        public bool bMaximizeButtonVisible = false;
        public int DefaultWidth = 100, DefaultHight = 100;
        public string sFormConfigCode;
        public bool IsUpdate = false;

        public int iFormID;
        public bool bNoAccess;
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
                //  this.ucTittleBar1.BackColor = value;
                //    this.pnlRight.BackColor = value;
                //    this.pnlLeft.BackColor = value;
                //    this.pnlBottom.BackColor = value;

                //    this.btn_Close.BackColor = value;
                //    this.btn_minimize.BackColor = value;
                //     this.btnSettings.BackColor = value;

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
            btnReSize.Visible = bMaximizeButtonVisible;

            var textBoxes = GetAll(this, typeof(TextBox));
            var DataGrid = GetAll(this, typeof(DataGridView));
            var Panels = GetAll(this, typeof(Panel));
            var Seacc_DataGrid = GetAll(this, typeof(SEACC_DataGrid));

            foreach (TextBox c in textBoxes)
            {
                c.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular);
            }

            foreach (DataGridView c in DataGrid)
            {
                clsFormatter.ApplyGridFormat_New2(c, clsFormatter.colorGrid, Color.White);
            }
            foreach (DataGridView c in DataGrid)
            {
                clsFormatter.ApplyGridFormat_New2(c, clsFormatter.colorGrid, Color.White);
            }
            foreach (DataGridView c in Seacc_DataGrid)
            {
                clsFormatter.ApplyGridFormat_New2(c, clsFormatter.colorGrid, Color.White);
            }
            foreach (Panel c in Panels)
            {
                if (c.Name == "z2")
                    c.BackColor = Color.DimGray;
            }
        }
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
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

        private void MettroForm_Leave(object sender, EventArgs e)
        {
            this.lineT.BackColor = System.Drawing.Color.Black;
            this.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void MettroForm_Enter(object sender, EventArgs e)
        {
            this.lineT.BackColor = Color.FromArgb(0, 160, 153);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void btnReSize_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
            if (Width == DefaultWidth)
            {
                Width = Scr.WorkingArea.Width - 80;
                Height = Scr.WorkingArea.Height - 70;
                //    this.pnlRight.Location = new System.Drawing.Point(0, 0);
            }
            else
            {
                Width = DefaultWidth;
                Height = DefaultHight;

            }
        }
    }
}