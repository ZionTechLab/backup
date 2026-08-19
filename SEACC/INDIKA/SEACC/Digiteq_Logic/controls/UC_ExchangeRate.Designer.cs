namespace Digiteq
{
    partial class UC_ExchangeRate
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
            this.chkSettings2 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.txtCurCode = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkSettings2
            // 
            this.chkSettings2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSettings2.Enabled = false;
            this.chkSettings2.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSettings2.Image = global::Digiteq.Properties.Resources.settings;
            this.chkSettings2.Location = new System.Drawing.Point(0, 0);
            this.chkSettings2.Name = "chkSettings2";
            this.chkSettings2.Size = new System.Drawing.Size(25, 25);
            this.chkSettings2.TabIndex = 591;
            this.chkSettings2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSettings2.UseVisualStyleBackColor = true;
            this.chkSettings2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(207, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(20, 22);
            this.textBox3.TabIndex = 495;
            this.textBox3.Text = "Rs.";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.BackColor = System.Drawing.SystemColors.Control;
            this.txtCurrencyRate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyRate.Location = new System.Drawing.Point(233, 0);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.ReadOnly = true;
            this.txtCurrencyRate.Size = new System.Drawing.Size(70, 22);
            this.txtCurrencyRate.TabIndex = 494;
            this.txtCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurCode
            // 
            this.txtCurCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCurCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurCode.Location = new System.Drawing.Point(117, 1);
            this.txtCurCode.Name = "txtCurCode";
            this.txtCurCode.ReadOnly = true;
            this.txtCurCode.Size = new System.Drawing.Size(86, 22);
            this.txtCurCode.TabIndex = 3;
            this.txtCurCode.Text = "GN005";
            this.txtCurCode.DoubleClick += new System.EventHandler(this.txtCurCode_DoubleClick);
            this.txtCurCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurCode_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label23.Location = new System.Drawing.Point(31, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 14);
            this.label23.TabIndex = 2;
            this.label23.Text = "Exchange Rate";
            // 
            // UC_ExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.chkSettings2);
            this.Controls.Add(this.txtCurrencyRate);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtCurCode);
            this.Name = "UC_ExchangeRate";
            this.Size = new System.Drawing.Size(308, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSettings2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.TextBox txtCurCode;
        private System.Windows.Forms.Label label23;
    }
}
