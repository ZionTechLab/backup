namespace SEACC.WinFormControls.Components
{
    partial class CheckComboBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDropDown = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnDropDown
            // 
            this.btnDropDown.BackColor = System.Drawing.Color.White;
            this.btnDropDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDropDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropDown.Location = new System.Drawing.Point(340, 0);
            this.btnDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDropDown.Name = "btnDropDown";
            this.btnDropDown.Size = new System.Drawing.Size(29, 20);
            this.btnDropDown.TabIndex = 7;
            this.btnDropDown.Text = "▽";
            this.btnDropDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDropDown.UseVisualStyleBackColor = false;
            this.btnDropDown.Click += new System.EventHandler(this.btnDropDown_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(369, 20);
            this.textBox1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 20);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(369, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 20);
            this.panel2.TabIndex = 9;
            // 
            // CheckComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDropDown);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CheckComboBox";
            this.Size = new System.Drawing.Size(369, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDropDown;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
    }
}
