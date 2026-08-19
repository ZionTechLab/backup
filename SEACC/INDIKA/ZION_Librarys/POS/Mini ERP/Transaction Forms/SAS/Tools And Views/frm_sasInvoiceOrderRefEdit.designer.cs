namespace Digiteq
{
    partial class frm_sasInvoiceOrderRefEdit
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
            this.xSetting = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.txtProductJobID = new System.Windows.Forms.TextBox();
            this.lblProductionJobCodeID = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtOrderRefNo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrnNo = new System.Windows.Forms.TextBox();
            this.xSetting.SuspendLayout();
            this.zpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.label12);
            this.xSetting.Controls.Add(this.txtInvoiceID);
            this.xSetting.Controls.Add(this.lblInvoiceID);
            this.xSetting.Location = new System.Drawing.Point(8, 8);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(484, 59);
            this.xSetting.TabIndex = 536;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(-1, -1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(484, 21);
            this.label12.TabIndex = 561;
            this.label12.Text = "SELECT THE CUSTOMER ORDER TO EDIT DETAILS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceID.Location = new System.Drawing.Point(104, 28);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(120, 22);
            this.txtInvoiceID.TabIndex = 2;
            this.txtInvoiceID.DoubleClick += new System.EventHandler(this.txtCustomerOrderID_DoubleClick);
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblInvoiceID.Location = new System.Drawing.Point(10, 32);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(62, 14);
            this.lblInvoiceID.TabIndex = 1;
            this.lblInvoiceID.Text = "Invoice No.";
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.zpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel1.Controls.Add(this.label1);
            this.zpanel1.Controls.Add(this.txtGrnNo);
            this.zpanel1.Controls.Add(this.txtProductJobID);
            this.zpanel1.Controls.Add(this.lblProductionJobCodeID);
            this.zpanel1.Controls.Add(this.txtRemarks);
            this.zpanel1.Controls.Add(this.dtpInvoiceDate);
            this.zpanel1.Controls.Add(this.label24);
            this.zpanel1.Controls.Add(this.label3);
            this.zpanel1.Controls.Add(this.label2);
            this.zpanel1.Controls.Add(this.lblOrderRefNo);
            this.zpanel1.Controls.Add(this.txtCustomerName);
            this.zpanel1.Controls.Add(this.txtOrderRefNo);
            this.zpanel1.Location = new System.Drawing.Point(8, 73);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(484, 157);
            this.zpanel1.TabIndex = 537;
            // 
            // txtProductJobID
            // 
            this.txtProductJobID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtProductJobID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductJobID.Location = new System.Drawing.Point(373, 64);
            this.txtProductJobID.Name = "txtProductJobID";
            this.txtProductJobID.ReadOnly = true;
            this.txtProductJobID.Size = new System.Drawing.Size(100, 22);
            this.txtProductJobID.TabIndex = 460;
            this.txtProductJobID.Text = "GN005";
            this.txtProductJobID.DoubleClick += new System.EventHandler(this.txtProductJobID_DoubleClick);
            this.txtProductJobID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductJobID_KeyDown);
            // 
            // lblProductionJobCodeID
            // 
            this.lblProductionJobCodeID.AutoSize = true;
            this.lblProductionJobCodeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionJobCodeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProductionJobCodeID.Location = new System.Drawing.Point(279, 67);
            this.lblProductionJobCodeID.Name = "lblProductionJobCodeID";
            this.lblProductionJobCodeID.Size = new System.Drawing.Size(90, 14);
            this.lblProductionJobCodeID.TabIndex = 459;
            this.lblProductionJobCodeID.Text = "Product Job Code";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Enabled = false;
            this.txtRemarks.Location = new System.Drawing.Point(104, 91);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(369, 56);
            this.txtRemarks.TabIndex = 458;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd/MMMM/yyyy";
            this.dtpInvoiceDate.Enabled = false;
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(104, 31);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(99, 22);
            this.dtpInvoiceDate.TabIndex = 455;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(10, 37);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 14);
            this.label24.TabIndex = 453;
            this.label24.Text = "CO Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(10, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 457;
            this.label3.Text = "Remarks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 456;
            this.label2.Text = "Customer Name\r\n";
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.AutoSize = true;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOrderRefNo.Location = new System.Drawing.Point(10, 67);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(77, 14);
            this.lblOrderRefNo.TabIndex = 451;
            this.lblOrderRefNo.Text = "Order Ref. No.";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(104, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(369, 22);
            this.txtCustomerName.TabIndex = 454;
            // 
            // txtOrderRefNo
            // 
            this.txtOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderRefNo.Location = new System.Drawing.Point(104, 63);
            this.txtOrderRefNo.Name = "txtOrderRefNo";
            this.txtOrderRefNo.Size = new System.Drawing.Size(128, 22);
            this.txtOrderRefNo.TabIndex = 452;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(417, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 454;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(336, 236);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 453;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(279, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 461;
            this.label1.Text = "Grn No";
            // 
            // txtGrnNo
            // 
            this.txtGrnNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrnNo.Location = new System.Drawing.Point(373, 34);
            this.txtGrnNo.Name = "txtGrnNo";
            this.txtGrnNo.Size = new System.Drawing.Size(100, 22);
            this.txtGrnNo.TabIndex = 462;
            // 
            // frm_sasInvoiceOrderRefEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 266);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.xSetting);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frm_sasInvoiceOrderRefEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Order Edit";
            this.Load += new System.EventHandler(this.frm_sasInvoiceOrderRefEdit_Load);
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.TextBox txtOrderRefNo;
        private System.Windows.Forms.TextBox txtProductJobID;
        private System.Windows.Forms.Label lblProductionJobCodeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrnNo;
    }
}