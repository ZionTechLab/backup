namespace Digiteq
{
    partial class frm_sasCustomerOrder_EditPO
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
            this.txtProductionJobID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerOrderID = new System.Windows.Forms.TextBox();
            this.lblCustomerOrderID = new System.Windows.Forms.Label();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.txtPurchaseOrderID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCoID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.xSetting.SuspendLayout();
            this.zpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.label12);
            this.xSetting.Controls.Add(this.txtProductionJobID);
            this.xSetting.Controls.Add(this.label1);
            this.xSetting.Controls.Add(this.txtCustomerOrderID);
            this.xSetting.Controls.Add(this.lblCustomerOrderID);
            this.xSetting.Location = new System.Drawing.Point(8, 8);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(479, 59);
            this.xSetting.TabIndex = 536;
            // 
            // txtProductionJobID
            // 
            this.txtProductionJobID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtProductionJobID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionJobID.Location = new System.Drawing.Point(364, 29);
            this.txtProductionJobID.Name = "txtProductionJobID";
            this.txtProductionJobID.Size = new System.Drawing.Size(100, 22);
            this.txtProductionJobID.TabIndex = 4;
            this.txtProductionJobID.DoubleClick += new System.EventHandler(this.txtProductionJobID_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(283, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = " Job No.";
            // 
            // txtCustomerOrderID
            // 
            this.txtCustomerOrderID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCustomerOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerOrderID.Location = new System.Drawing.Point(134, 28);
            this.txtCustomerOrderID.Name = "txtCustomerOrderID";
            this.txtCustomerOrderID.Size = new System.Drawing.Size(120, 22);
            this.txtCustomerOrderID.TabIndex = 2;
            this.txtCustomerOrderID.DoubleClick += new System.EventHandler(this.txtCustomerOrderID_DoubleClick);
            // 
            // lblCustomerOrderID
            // 
            this.lblCustomerOrderID.AutoSize = true;
            this.lblCustomerOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerOrderID.Location = new System.Drawing.Point(16, 32);
            this.lblCustomerOrderID.Name = "lblCustomerOrderID";
            this.lblCustomerOrderID.Size = new System.Drawing.Size(105, 14);
            this.lblCustomerOrderID.TabIndex = 1;
            this.lblCustomerOrderID.Text = "Customer Order No.";
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.zpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel1.Controls.Add(this.dtpDeliveryDate);
            this.zpanel1.Controls.Add(this.label5);
            this.zpanel1.Controls.Add(this.txtCoID);
            this.zpanel1.Controls.Add(this.label4);
            this.zpanel1.Controls.Add(this.txtRemarks);
            this.zpanel1.Controls.Add(this.label3);
            this.zpanel1.Controls.Add(this.label2);
            this.zpanel1.Controls.Add(this.dtpOrderDate);
            this.zpanel1.Controls.Add(this.label24);
            this.zpanel1.Controls.Add(this.lblOrderRefNo);
            this.zpanel1.Controls.Add(this.txtCustomerName);
            this.zpanel1.Controls.Add(this.txtPurchaseOrderID);
            this.zpanel1.Location = new System.Drawing.Point(8, 73);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(479, 157);
            this.zpanel1.TabIndex = 537;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(134, 91);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(328, 56);
            this.txtRemarks.TabIndex = 458;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(13, 94);
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
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 456;
            this.label2.Text = "Customer Name\r\n";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CustomFormat = "dd/MMMM/yyyy";
            this.dtpOrderDate.Enabled = false;
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(364, 8);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(99, 22);
            this.dtpOrderDate.TabIndex = 455;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(134, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(328, 22);
            this.txtCustomerName.TabIndex = 454;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(283, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 14);
            this.label24.TabIndex = 453;
            this.label24.Text = "CO Date";
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.AutoSize = true;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOrderRefNo.Location = new System.Drawing.Point(13, 67);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(102, 14);
            this.lblOrderRefNo.TabIndex = 451;
            this.lblOrderRefNo.Text = "Purchase Order No.";
            // 
            // txtPurchaseOrderID
            // 
            this.txtPurchaseOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseOrderID.Location = new System.Drawing.Point(134, 63);
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.Size = new System.Drawing.Size(119, 22);
            this.txtPurchaseOrderID.TabIndex = 452;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(412, 236);
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
            this.btnNew.Location = new System.Drawing.Point(331, 236);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 453;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(-1, -1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(479, 21);
            this.label12.TabIndex = 561;
            this.label12.Text = "SELECT THE CUSTOMER ORDER TO EDIT DETAILS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCoID
            // 
            this.txtCoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtCoID.Enabled = false;
            this.txtCoID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoID.Location = new System.Drawing.Point(134, 8);
            this.txtCoID.Name = "txtCoID";
            this.txtCoID.Size = new System.Drawing.Size(120, 22);
            this.txtCoID.TabIndex = 563;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 562;
            this.label4.Text = "Customer Order Code";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "dd/MMMM/yyyy";
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(364, 63);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(99, 22);
            this.dtpDeliveryDate.TabIndex = 565;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(283, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 14);
            this.label5.TabIndex = 564;
            this.label5.Text = "Delivery Date";
            // 
            // frm_sasCustomerOrder_EditPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 266);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.xSetting);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_sasCustomerOrder_EditPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Order Edit";
            this.Load += new System.EventHandler(this.frm_sasCustomerOrder_EditPO_Load);
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.Label lblCustomerOrderID;
        private System.Windows.Forms.TextBox txtProductionJobID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerOrderID;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.TextBox txtPurchaseOrderID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCoID;
        private System.Windows.Forms.Label label4;
    }
}