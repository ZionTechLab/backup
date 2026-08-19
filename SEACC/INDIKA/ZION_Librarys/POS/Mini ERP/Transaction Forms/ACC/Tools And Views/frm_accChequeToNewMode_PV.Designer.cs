namespace Digiteq
{
    partial class frm_accChequeToNewMode_PV
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
            this.btnNewMode = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.lblWip = new System.Windows.Forms.Label();
            this.btnUnlockPV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewMode
            // 
            this.btnNewMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewMode.Location = new System.Drawing.Point(96, 65);
            this.btnNewMode.Name = "btnNewMode";
            this.btnNewMode.Size = new System.Drawing.Size(98, 25);
            this.btnNewMode.TabIndex = 11;
            this.btnNewMode.Text = "Unlock Cheque";
            this.btnNewMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewMode.UseVisualStyleBackColor = true;
            this.btnNewMode.Click += new System.EventHandler(this.btnNewMode_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(246, 96);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 25);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtPV
            // 
            this.txtPV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtPV.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPV.Location = new System.Drawing.Point(96, 37);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(202, 22);
            this.txtPV.TabIndex = 14;
            this.txtPV.DoubleClick += new System.EventHandler(this.txtPV_DoubleClick);
            // 
            // lblWip
            // 
            this.lblWip.AutoSize = true;
            this.lblWip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWip.Location = new System.Drawing.Point(12, 40);
            this.lblWip.Name = "lblWip";
            this.lblWip.Size = new System.Drawing.Size(43, 13);
            this.lblWip.TabIndex = 13;
            this.lblWip.Text = "PV No.";
            // 
            // btnUnlockPV
            // 
            this.btnUnlockPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlockPV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlockPV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlockPV.Location = new System.Drawing.Point(200, 65);
            this.btnUnlockPV.Name = "btnUnlockPV";
            this.btnUnlockPV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUnlockPV.Size = new System.Drawing.Size(98, 25);
            this.btnUnlockPV.TabIndex = 15;
            this.btnUnlockPV.Text = "Unlock PV";
            this.btnUnlockPV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUnlockPV.UseVisualStyleBackColor = true;
            this.btnUnlockPV.Click += new System.EventHandler(this.btnUnlockPV_Click);
            // 
            // frm_accChequeToNewMode_PV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(323, 138);
            this.Controls.Add(this.btnUnlockPV);
            this.Controls.Add(this.btnNewMode);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.lblWip);
            this.Name = "frm_accChequeToNewMode_PV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock [PV]";
            this.Load += new System.EventHandler(this.frm_accChequeToNewMode_PV_Load);
            this.Controls.SetChildIndex(this.lblWip, 0);
            this.Controls.SetChildIndex(this.txtPV, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnNewMode, 0);
            this.Controls.SetChildIndex(this.btnUnlockPV, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewMode;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label lblWip;
        private System.Windows.Forms.Button btnUnlockPV;
    }
}