using SEACC.WinFormControls.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Components
{
    public class xCheckComboBox : UserControl
    {
        public delegate void CheckedChangedEventHandler(bool value);

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void SelectionChangedEventHandler(DataView value, List<SelectionList> Data);

        public event SelectionChangedEventHandler SelectionChanged;
        protected CheckComboBox combo;
        protected TextBox textBox1;
        protected Panel panel1;
        protected Panel panel2;
        private CheckBox checkBox1;
        protected Label label2;

        public xCheckComboBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.combo = new CheckComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(49, 0);
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
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox1.Location = new System.Drawing.Point(294, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(44, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // combo
            // 
            this.combo._DisplayMember = "Name";
            this.combo._ValueMember = "ID";
            this.combo.DataSource = null;
            this.combo.Dock = System.Windows.Forms.DockStyle.Right;
            this.combo.Enabled = false;
            this.combo.Location = new System.Drawing.Point(114, 0);
            this.combo.Margin = new System.Windows.Forms.Padding(0);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(180, 21);
            this.combo.TabIndex = 0;
            this.combo.Text_ = "";
            this.combo.SelectionChanged += Combo_SelectionChanged1;
            // 
            // xCheckComboBox
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.checkBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "xCheckComboBox";
            this.Size = new System.Drawing.Size(338, 21);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Combo_SelectionChanged1(DataView value)
        {
            try
            {
                var emp = (from DataRow row in value.ToTable().Rows

                           select new SelectionList
                           {
                               Type = DisplayText,
                               DisplayMember = row[DisplayMember].ToString(),
                               ValueMember = row[ValueMember].ToString()

                           }).ToList();

                //   List< xList> c= value.ToTable().AsEnumerable().Select(x => x[DisplayMember].ToString()).ToList();
                ////     List<string> D = value.ToTable().AsEnumerable().Select(x => x[DisplayMember].ToString()).ToList();
                List<string> V = value.ToTable().AsEnumerable().Select(x => x[ValueMember].ToString()).ToList();
                //   string joined = string.Join(",", emp.Select(x => x.ValueMember));
                combo.Text_ = string.Join(",", emp.Select(x => x.DisplayMember));
                textBox1.Text = string.Join(",", emp.Select(x => x.ValueMember));
                SelectionChanged(value, emp);
            }
            catch (Exception)
            {

                //   throw;
            }
        }

        //private void Combo_SelectionChanged(System.Data.DataView value)
        //{
        //    try
        //    {
        //        var emp = (from DataRow row in value.ToTable().Rows

        //                   select new xList
        //                   {
        //                       DisplayMember = row[DisplayMember].ToString(),
        //                       ValueMember = row[ValueMember].ToString()

        //                   }).ToList();

        //        //   List< xList> c= value.ToTable().AsEnumerable().Select(x => x[DisplayMember].ToString()).ToList();
        //        ////     List<string> D = value.ToTable().AsEnumerable().Select(x => x[DisplayMember].ToString()).ToList();
        //        List<string> V = value.ToTable().AsEnumerable().Select(x => x[ValueMember].ToString()).ToList();
        //        //   string joined = string.Join(",", emp.Select(x => x.ValueMember));
        //        combo.Text_ = string.Join(",", emp.Select(x => x.DisplayMember));
        //        textBox1.Text = string.Join(",", emp.Select(x => x.ValueMember));
        //        SelectionChanged(value, emp);
        //    }
        //    catch (Exception)
        //    {

        //     //   throw;
        //    }
        //}

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
                if (combo.DataSource != null)
                    //   combo.SelectedIndex = -1;
                    combo.Check_Uncheck_All(false);
                textBox1.Text = "";
            }
        }
        public string DisplayMember
        {
            get { return combo._DisplayMember; }
            set { combo._DisplayMember = value; }
        }
        public string ValueMember
        {
            get { return combo._ValueMember; }
            set { combo._ValueMember = value; }
        }
        public int SelectedIndex
        {
            get
            {
                return 0;// combo.SelectedIndex;
            }
            set
            {
                // combo.SelectedIndex = value;

                if (SelectedIndex == -1)
                    textBox1.Text = "";
            }
        }
        //public object SelectedItem
        //{
        //    get { return combo.SelectedItem; }
        //    set { combo.SelectedItem = value; }
        //}
        //public object SelectedValue
        //{
        //    get
        //    {
        //        string val = "";

        //        if (combo.SelectedValue != null)
        //            val = combo.SelectedValue.ToString().Trim();

        //        return textBox1.Text;
        //    }
        //    set { combo.SelectedValue = value; }
        //}
        //public int getSelectedValue(int var)
        //{
        //    if (combo.SelectedValue != null)
        //        int.TryParse(combo.SelectedValue.ToString(), out var);
        //    return var;
        //}
        //public string getSelectedValue(string var)
        //{
        //    if (combo.SelectedValue != null)
        //        var = combo.SelectedValue.ToString();
        //    return var;
        //}
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
        //public bool ValidateValue()
        //{
        //    if (combo.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Please Select " + this.DisplayText.Replace(" :", ""));
        //        combo.Focus();
        //        return false;
        //    }

        //    return true;
        //}
        //private void combo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string val = "";

        //    if (combo.SelectedValue != null)
        //        val = combo.SelectedValue.ToString();

        //    textBox1.Text = val;

        //    try
        //    {
        //        SelectedIndexChanged(sender, e);
        //    }
        //    catch (Exception)
        //    {
        //    }

        //    try
        //    {
        //        IndexChanged(val);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}


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
                combo.Check_Uncheck_All(false);
                if (checkBox1.Checked)
                {
                    combo.Enabled = false;
                }
                else
                {
                    combo.Enabled = true;
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Select one or more " + this.DisplayText.Replace(" :", ""));
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
                S = this.DisplayText + " " + combo.Text_;
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
