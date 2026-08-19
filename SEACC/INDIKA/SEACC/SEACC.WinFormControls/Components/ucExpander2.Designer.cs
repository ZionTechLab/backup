namespace SEACC.WinFormControls.Components
{
    partial class ucExpander2
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAmount = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlHeader.CausesValidation = false;
            this.pnlHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlHeader.Controls.Add(this.flowLayoutPanel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(386, 26);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Click += new System.EventHandler(this.pnlHeader_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblIcon);
            this.flowLayoutPanel2.Controls.Add(this.lblDisplayName);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(274, 26);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.Click += new System.EventHandler(this.pnlHeader_Click);
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(3, 6);
            this.lblIcon.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(21, 14);
            this.lblIcon.TabIndex = 3;
            this.lblIcon.Text = "";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIcon.Visible = false;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.White;
            this.lblDisplayName.Location = new System.Drawing.Point(24, 3);
            this.lblDisplayName.Margin = new System.Windows.Forms.Padding(0);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(103, 19);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "Cash Payments";
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDisplayName.Click += new System.EventHandler(this.pnlHeader_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lblAmount);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(168, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(218, 26);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.pnlHeader_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.White;
            this.lblAmount.Location = new System.Drawing.Point(109, 3);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(106, 19);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "100,000,000.00";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAmount.Click += new System.EventHandler(this.pnlHeader_Click);
            // 
            // ucExpander2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucExpander2";
            this.Size = new System.Drawing.Size(386, 150);
            this.Load += new System.EventHandler(this.ucExpander_Load);
            this.pnlHeader.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
