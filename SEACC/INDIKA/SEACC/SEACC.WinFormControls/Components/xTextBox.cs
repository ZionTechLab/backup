using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Components
{
    public enum TextBxType
    { Standerd, Numaric, Decimal }
    public class xTextBox : UserControl
    {
        public delegate void ComboBovEventHandler(string value);

        public event ComboBovEventHandler IndexChanged;

        public event EventHandler SelectedIndexChanged;

        TextBxType TBT = TextBxType.Standerd;

        private TextBox textBox1;
        private Panel panel1;
        private Label label2;

        #region Init
        public xTextBox()
        {
            AllowSpecialCaractors = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(93, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 21);
            this.panel1.TabIndex = 5;
            // 
            // xTextBox
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "xTextBox";
            this.Size = new System.Drawing.Size(338, 21);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Propertice
        public bool Enabled
        {
            get { return textBox1.ReadOnly; }
            set
            {
                label2.Enabled = true;
                textBox1.ReadOnly = !value;
                textBox1.BackColor = !Enabled ? System.Drawing.Color.FromArgb(255, 255, 255) : System.Drawing.Color.FromArgb(228, 244, 251);
            }
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
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set
            {
                textBox1.Multiline = value;

            }
        }
        public int MaxLength
        {
            get { return textBox1.MaxLength; }
            set { textBox1.MaxLength = value; }
        }
        public TextBxType TextBoxtype
        {
            get
            {
                return TBT;
            }
            set
            {
                TBT = value;

                //switch (TBT)
                //{
                //    case TextBxType.Standerd:
                //        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                //        break;
                //    case TextBxType.Numaric:
                //        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                //        break;
                //    case TextBxType.Decimal:
                //        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                //        break;
                //    default:
                //        break;
                //}
            }
        }
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return textBox1.TextAlign;
            }
            set
            {
                textBox1.TextAlign = value;
            }
        }
        public bool AllowSpecialCaractors
        {
            get;
            set;
        }
        #endregion


        public string SelctionQuary()
        {
            string S = "";
            if (textBox1.Text != "")
                S = this.DisplayText + " " + textBox1.Text;

            return S;
        }
        public bool ValidateValue()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter " + this.DisplayText.Replace(" :", "").Replace("*", ""));
                textBox1.Focus();
                return false;
            }

            return true;
        }
        public int getValue(int var)
        {
            if (textBox1.Text != "")
                int.TryParse(textBox1.Text, out var);

            return var;
        }
        public decimal getValue(decimal var)
        {
            if (textBox1.Text != "")
                decimal.TryParse(textBox1.Text, out var);

            return var;
        }
        public string getValue(string var)
        {
            return textBox1.Text.Trim();
        }
        public void SetValue(string var)
        {
            textBox1.Text = var;
        }
        public void SetValue(decimal var)
        {
            textBox1.Text = var.ToString();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (TBT)
            {
                case TextBxType.Standerd:
                    break;
                case TextBxType.Numaric:
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                case TextBxType.Decimal:
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
                    break;
                default:
                    break;
            }

            if (!AllowSpecialCaractors)
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]");
                if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

            }
        }
    }
}
