using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Components
{
    public class xComboBox_Check : xComboBox
    {
        private System.Windows.Forms.CheckBox checkBox1;

        public delegate void CheckedChangedEventHandler(bool value);

        public event CheckedChangedEventHandler CheckedChanged;
        public xComboBox_Check()
        {
            InitializeComponent();
        }
        public void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo
            // 
            this.combo.Location = new System.Drawing.Point(192, 0);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(127, 0);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(127, 21);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox1.Location = new System.Drawing.Point(372, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(44, 21);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // xComboBox_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.checkBox1);
            this.Name = "xComboBox_Check";
            this.Size = new System.Drawing.Size(416, 21);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.combo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public bool Checked
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
            }
        }
        public string DisplayText_All
        {
            get
            {
                return checkBox1.Text;
            }
            set
            {
                checkBox1.Text = value;
            }
        }
        public bool EnableCheckBox
        {
            get
            {
                return checkBox1.Enabled;
            }
            set
            {
                checkBox1.Enabled = value;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (checkBox1.Checked)
                {
                    combo.SelectedIndex = -1;
                    combo.Enabled = false;
                    textBox1.Enabled = false;
                }
                else
                {
                    combo.Enabled = true;
                    textBox1.Enabled = true;
                }
                CheckedChanged(checkBox1.Checked);
            }
            catch (Exception)
            {

                //  throw;
            }
        }

        public bool ValidateValue()
        {
            if (!checkBox1.Checked)
            {
                if (combo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select " + this.DisplayText.Replace(" :", ""));
                    combo.Focus();
                    return false;
                }
            }
            return true;
        }

        public string SelctionQuary()
        {
            string S = "";
            if (!checkBox1.Checked)
            {
                S = this.DisplayText + " " + combo.Text;
            }
            else
                S = "All " + this.DisplayText.Replace(" :", "");

            return S;
        }

        public void SelctionQuary(ref StringBuilder sb)
        {
            string S = "";
            if (!checkBox1.Checked)
            {
                S = this.DisplayText + " " + combo.Text;
            }
            else
                S = "All " + this.DisplayText.Replace(" :", "");

            sb.Append((sb.Length == 0 ? "" : " | ") + S);
        }
    }
}
