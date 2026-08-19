namespace Digiteq
{
    partial class frm_masFinanceMaster
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xpanel3 = new System.Windows.Forms.Panel();
            this.btnCurrencyMaster = new System.Windows.Forms.Button();
            this.btnTax = new System.Windows.Forms.Button();
            this.btnBranch = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.xpanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.btnCurrencyMaster);
            this.xpanel3.Controls.Add(this.btnTax);
            this.xpanel3.Controls.Add(this.btnBranch);
            this.xpanel3.Controls.Add(this.btnBank);
            this.xpanel3.Location = new System.Drawing.Point(8, 32);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(281, 159);
            this.xpanel3.TabIndex = 19;
            // 
            // btnCurrencyMaster
            // 
            this.btnCurrencyMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnCurrencyMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrencyMaster.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrencyMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrencyMaster.Location = new System.Drawing.Point(142, 81);
            this.btnCurrencyMaster.Name = "btnCurrencyMaster";
            this.btnCurrencyMaster.Size = new System.Drawing.Size(128, 67);
            this.btnCurrencyMaster.TabIndex = 17;
            this.btnCurrencyMaster.Text = "Currency Master";
            this.btnCurrencyMaster.UseVisualStyleBackColor = false;
            this.btnCurrencyMaster.Click += new System.EventHandler(this.btnCurrencyMaster_Click);
            // 
            // btnTax
            // 
            this.btnTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTax.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTax.Location = new System.Drawing.Point(8, 81);
            this.btnTax.Name = "btnTax";
            this.btnTax.Size = new System.Drawing.Size(128, 67);
            this.btnTax.TabIndex = 16;
            this.btnTax.Text = "Tax Master";
            this.btnTax.UseVisualStyleBackColor = false;
            this.btnTax.Click += new System.EventHandler(this.btnTax_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnBranch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBranch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBranch.Location = new System.Drawing.Point(142, 8);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(128, 67);
            this.btnBranch.TabIndex = 15;
            this.btnBranch.Text = "Branch Master";
            this.btnBranch.UseVisualStyleBackColor = false;
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // btnBank
            // 
            this.btnBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnBank.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBank.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBank.Location = new System.Drawing.Point(8, 8);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(128, 67);
            this.btnBank.TabIndex = 13;
            this.btnBank.Text = "Bank Master";
            this.btnBank.UseVisualStyleBackColor = false;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // frm_masFinanceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 198);
            this.Controls.Add(this.xpanel3);
            this.Location = new System.Drawing.Point(8, 8);
            this.Name = "frm_masFinanceMaster";
            this.Text = "FinanceMaster";
            this.Load += new System.EventHandler(this.frm_masFinanceMaster_Load);
            this.Controls.SetChildIndex(this.xpanel3, 0);
            this.xpanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btnBranch;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button btnTax;
        private System.Windows.Forms.Button btnCurrencyMaster;
    }
}