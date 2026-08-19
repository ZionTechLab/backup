using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Components
{
    public class xComboBox : UserControl
    {
        protected ComboBox combo;
        protected TextBox textBox1;
        protected Panel panel1;
        protected Panel panel2;
        protected Label label2;

        public xComboBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.combo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo
            // 
            this.combo.Dock = System.Windows.Forms.DockStyle.Right;
            this.combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(158, 0);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(180, 21);
            this.combo.TabIndex = 0;
            this.combo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(1, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(58, 15);
            this.textBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(93, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1, 0, 2, 0);
            this.panel1.Size = new System.Drawing.Size(65, 21);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.panel2.Size = new System.Drawing.Size(62, 21);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xComboBox
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.combo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "xComboBox";
            this.Size = new System.Drawing.Size(338, 21);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }


        public string DisplayText
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
        public int WidthText
        {
            get { return panel1.Width; }
            set { panel1.Width = value; }
        }
        public int WidthCombo
        {
            get { return combo.Width; }
            set { combo.Width = value; }
        }
        public object DataSource
        {
            get { return combo.DataSource; }
            set
            {
                combo.DataSource = value;
                combo.SelectedIndex = -1;
                textBox1.Text = "";
            }
        }
        public string DisplayMember
        {
            get { return combo.DisplayMember; }
            set { combo.DisplayMember = value; }
        }
        public string ValueMember
        {
            get { return combo.ValueMember; }
            set { combo.ValueMember = value; }
        }
        public int SelectedIndex
        {
            get { return combo.SelectedIndex; }
            set
            {
                combo.SelectedIndex = value;

                if (SelectedIndex == -1)
                    textBox1.Text = "";
            }
        }
        public object SelectedItem
        {
            get { return combo.SelectedItem; }
            set { combo.SelectedItem = value; }
        }
        public object SelectedValue
        {
            get
            {
                string val = "";

                if (combo.SelectedValue != null)
                    val = combo.SelectedValue.ToString().Trim();

                return textBox1.Text;
            }
            set { combo.SelectedValue = value; }
        }
        public int getSelectedValue(int var)
        {
            if (combo.SelectedValue != null)
                int.TryParse(combo.SelectedValue.ToString(), out var);
            return var;
        }
        public string getSelectedValue(string var)
        {
            if (combo.SelectedValue != null)
                var = combo.SelectedValue.ToString();
            return var;
        }
        public string ComboBoxText
        {
            get
            {
                return combo.Text;
            }
            set { }
        }

        public delegate void ComboBovEventHandler(string value);

        public event ComboBovEventHandler IndexChanged;

        public event EventHandler SelectedIndexChanged;
        public bool ValidateValue()
        {
            if (combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select " + this.DisplayText.Replace(" :", ""));
                combo.Focus();
                return false;
            }

            return true;
        }
        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = "";

            if (combo.SelectedValue != null)
                val = combo.SelectedValue.ToString();

            textBox1.Text = val;

            try
            {
                SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
            }

            try
            {
                IndexChanged(val);
            }
            catch (Exception)
            {
            }
        }
    }
}
