namespace Digiteq
{
    partial class frm_LoanSettlemnet
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSettle = new System.Windows.Forms.Button();
            this.lblAllocationID = new System.Windows.Forms.Label();
            this.lblAllocationDate = new System.Windows.Forms.Label();
            this.txtAllocationID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoPriceAllocation = new System.Windows.Forms.RadioButton();
            this.rdoQtyAllocation = new System.Windows.Forms.RadioButton();
            this.lblPriceAllocation = new System.Windows.Forms.Label();
            this.lblQtyAllocation = new System.Windows.Forms.Label();
            this.dtmAllocationDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkisSettle = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(118, 165);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSettle
            // 
            this.btnSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettle.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSettle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettle.Location = new System.Drawing.Point(193, 165);
            this.btnSettle.Name = "btnSettle";
            this.btnSettle.Size = new System.Drawing.Size(75, 25);
            this.btnSettle.TabIndex = 32;
            this.btnSettle.Text = "Settle";
            this.btnSettle.UseVisualStyleBackColor = true;
            this.btnSettle.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblAllocationID
            // 
            this.lblAllocationID.AutoSize = true;
            this.lblAllocationID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocationID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAllocationID.Location = new System.Drawing.Point(7, 10);
            this.lblAllocationID.Name = "lblAllocationID";
            this.lblAllocationID.Size = new System.Drawing.Size(70, 14);
            this.lblAllocationID.TabIndex = 72;
            this.lblAllocationID.Text = "Allocation ID";
            // 
            // lblAllocationDate
            // 
            this.lblAllocationDate.AutoSize = true;
            this.lblAllocationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAllocationDate.Location = new System.Drawing.Point(7, 37);
            this.lblAllocationDate.Name = "lblAllocationDate";
            this.lblAllocationDate.Size = new System.Drawing.Size(83, 14);
            this.lblAllocationDate.TabIndex = 104;
            this.lblAllocationDate.Text = "Allocation Date";
            // 
            // txtAllocationID
            // 
            this.txtAllocationID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAllocationID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocationID.Location = new System.Drawing.Point(95, 7);
            this.txtAllocationID.Name = "txtAllocationID";
            this.txtAllocationID.Size = new System.Drawing.Size(104, 22);
            this.txtAllocationID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkisSettle);
            this.panel2.Controls.Add(this.rdoPriceAllocation);
            this.panel2.Controls.Add(this.rdoQtyAllocation);
            this.panel2.Controls.Add(this.lblPriceAllocation);
            this.panel2.Controls.Add(this.lblQtyAllocation);
            this.panel2.Controls.Add(this.dtmAllocationDate);
            this.panel2.Controls.Add(this.lblAllocationID);
            this.panel2.Controls.Add(this.lblAllocationDate);
            this.panel2.Controls.Add(this.txtAllocationID);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 156);
            this.panel2.TabIndex = 31;
            // 
            // rdoPriceAllocation
            // 
            this.rdoPriceAllocation.AutoSize = true;
            this.rdoPriceAllocation.Location = new System.Drawing.Point(97, 100);
            this.rdoPriceAllocation.Name = "rdoPriceAllocation";
            this.rdoPriceAllocation.Size = new System.Drawing.Size(14, 13);
            this.rdoPriceAllocation.TabIndex = 109;
            this.rdoPriceAllocation.TabStop = true;
            this.rdoPriceAllocation.UseVisualStyleBackColor = true;
            // 
            // rdoQtyAllocation
            // 
            this.rdoQtyAllocation.AutoSize = true;
            this.rdoQtyAllocation.Location = new System.Drawing.Point(97, 72);
            this.rdoQtyAllocation.Name = "rdoQtyAllocation";
            this.rdoQtyAllocation.Size = new System.Drawing.Size(14, 13);
            this.rdoQtyAllocation.TabIndex = 108;
            this.rdoQtyAllocation.TabStop = true;
            this.rdoQtyAllocation.UseVisualStyleBackColor = true;
            // 
            // lblPriceAllocation
            // 
            this.lblPriceAllocation.AutoSize = true;
            this.lblPriceAllocation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceAllocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPriceAllocation.Location = new System.Drawing.Point(7, 100);
            this.lblPriceAllocation.Name = "lblPriceAllocation";
            this.lblPriceAllocation.Size = new System.Drawing.Size(83, 14);
            this.lblPriceAllocation.TabIndex = 107;
            this.lblPriceAllocation.Text = "Price Allocation";
            // 
            // lblQtyAllocation
            // 
            this.lblQtyAllocation.AutoSize = true;
            this.lblQtyAllocation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyAllocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblQtyAllocation.Location = new System.Drawing.Point(7, 72);
            this.lblQtyAllocation.Name = "lblQtyAllocation";
            this.lblQtyAllocation.Size = new System.Drawing.Size(77, 14);
            this.lblQtyAllocation.TabIndex = 106;
            this.lblQtyAllocation.Text = "Qty Allocation";
            // 
            // dtmAllocationDate
            // 
            this.dtmAllocationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmAllocationDate.Location = new System.Drawing.Point(97, 37);
            this.dtmAllocationDate.Name = "dtmAllocationDate";
            this.dtmAllocationDate.Size = new System.Drawing.Size(102, 20);
            this.dtmAllocationDate.TabIndex = 105;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Digiteq.Properties.Resources.delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(268, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkisSettle
            // 
            this.chkisSettle.AutoSize = true;
            this.chkisSettle.Location = new System.Drawing.Point(244, 133);
            this.chkisSettle.Name = "chkisSettle";
            this.chkisSettle.Size = new System.Drawing.Size(83, 17);
            this.chkisSettle.TabIndex = 110;
            this.chkisSettle.Text = "Fully Settled";
            this.chkisSettle.UseVisualStyleBackColor = true;
            // 
            // frm_LoanSettlemnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(348, 193);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSettle);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_LoanSettlemnet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pattern Length Master";
            this.Load += new System.EventHandler(this.frm_masDesignPattern_Length_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSettle;
        private System.Windows.Forms.Label lblAllocationID;
        private System.Windows.Forms.Label lblAllocationDate;
        private System.Windows.Forms.TextBox txtAllocationID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoPriceAllocation;
        private System.Windows.Forms.RadioButton rdoQtyAllocation;
        private System.Windows.Forms.Label lblPriceAllocation;
        private System.Windows.Forms.Label lblQtyAllocation;
        private System.Windows.Forms.DateTimePicker dtmAllocationDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkisSettle;
    }
}