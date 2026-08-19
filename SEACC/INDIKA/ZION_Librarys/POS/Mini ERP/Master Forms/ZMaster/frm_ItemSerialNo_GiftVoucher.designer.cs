namespace Digiteq
{
    partial class frm_ItemSerialNo_GiftVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.itemSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateValidFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateValidTill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voucherAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1 = new System.Windows.Forms.Panel();
            this.lblPrifix = new System.Windows.Forms.Label();
            this.txtVoucherAmount = new System.Windows.Forms.TextBox();
            this.dtpDateValidTill = new System.Windows.Forms.DateTimePicker();
            this.dtpDateValidFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDateValidTill = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemSerialNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.lblHighestReceiptNo = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemSerialNo,
            this.item_ID,
            this.description,
            this.dateValidFrom,
            this.dateValidTill,
            this.voucherAmount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 219);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(654, 322);
            this.dgvDetail.TabIndex = 15;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // itemSerialNo
            // 
            this.itemSerialNo.DataPropertyName = "itemSerialNo";
            this.itemSerialNo.HeaderText = "Item Serial No";
            this.itemSerialNo.Name = "itemSerialNo";
            this.itemSerialNo.Width = 90;
            // 
            // item_ID
            // 
            this.item_ID.DataPropertyName = "item_ID";
            this.item_ID.HeaderText = "Item ID";
            this.item_ID.Name = "item_ID";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.Width = 170;
            // 
            // dateValidFrom
            // 
            this.dateValidFrom.DataPropertyName = "dateValidFrom";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dateValidFrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateValidFrom.HeaderText = "Date Valid From";
            this.dateValidFrom.Name = "dateValidFrom";
            // 
            // dateValidTill
            // 
            this.dateValidTill.DataPropertyName = "dateValidTill";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dateValidTill.DefaultCellStyle = dataGridViewCellStyle2;
            this.dateValidTill.HeaderText = "Date Valid Till";
            this.dateValidTill.Name = "dateValidTill";
            this.dateValidTill.Width = 90;
            // 
            // voucherAmount
            // 
            this.voucherAmount.DataPropertyName = "voucherAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "System.Drawing.Bitmap";
            this.voucherAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.voucherAmount.HeaderText = "Voucher Amount";
            this.voucherAmount.Name = "voucherAmount";
            this.voucherAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.lblPrifix);
            this.z1.Controls.Add(this.txtVoucherAmount);
            this.z1.Controls.Add(this.dtpDateValidTill);
            this.z1.Controls.Add(this.dtpDateValidFrom);
            this.z1.Controls.Add(this.label2);
            this.z1.Controls.Add(this.lblDateValidTill);
            this.z1.Controls.Add(this.txtDescription);
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.lblItemSerialNo);
            this.z1.Controls.Add(this.label3);
            this.z1.Controls.Add(this.lblItemName);
            this.z1.Controls.Add(this.txtItemName);
            this.z1.Controls.Add(this.txtItemSerialNo);
            this.z1.Controls.Add(this.lblHighestReceiptNo);
            this.z1.Location = new System.Drawing.Point(9, 33);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(654, 147);
            this.z1.TabIndex = 12;
            // 
            // lblPrifix
            // 
            this.lblPrifix.AutoSize = true;
            this.lblPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrifix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPrifix.Location = new System.Drawing.Point(448, 53);
            this.lblPrifix.Name = "lblPrifix";
            this.lblPrifix.Size = new System.Drawing.Size(88, 14);
            this.lblPrifix.TabIndex = 419;
            this.lblPrifix.Text = "Voucher Amount";
            // 
            // txtVoucherAmount
            // 
            this.txtVoucherAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherAmount.Location = new System.Drawing.Point(542, 49);
            this.txtVoucherAmount.Name = "txtVoucherAmount";
            this.txtVoucherAmount.Size = new System.Drawing.Size(96, 22);
            this.txtVoucherAmount.TabIndex = 418;
            this.txtVoucherAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVoucherAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherAmount_KeyPress);
            // 
            // dtpDateValidTill
            // 
            this.dtpDateValidTill.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateValidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateValidTill.Location = new System.Drawing.Point(542, 21);
            this.dtpDateValidTill.Name = "dtpDateValidTill";
            this.dtpDateValidTill.Size = new System.Drawing.Size(96, 22);
            this.dtpDateValidTill.TabIndex = 417;
            // 
            // dtpDateValidFrom
            // 
            this.dtpDateValidFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateValidFrom.Location = new System.Drawing.Point(336, 19);
            this.dtpDateValidFrom.Name = "dtpDateValidFrom";
            this.dtpDateValidFrom.Size = new System.Drawing.Size(96, 22);
            this.dtpDateValidFrom.TabIndex = 417;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(243, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 411;
            this.label2.Text = "Date Valid From";
            // 
            // lblDateValidTill
            // 
            this.lblDateValidTill.AutoSize = true;
            this.lblDateValidTill.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValidTill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDateValidTill.Location = new System.Drawing.Point(448, 25);
            this.lblDateValidTill.Name = "lblDateValidTill";
            this.lblDateValidTill.Size = new System.Drawing.Size(76, 14);
            this.lblDateValidTill.TabIndex = 411;
            this.lblDateValidTill.Text = "Date Valid Till";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(96, 79);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(542, 56);
            this.txtDescription.TabIndex = 408;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 107;
            this.label1.Text = "Description";
            // 
            // lblItemSerialNo
            // 
            this.lblItemSerialNo.AutoSize = true;
            this.lblItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemSerialNo.Location = new System.Drawing.Point(10, 25);
            this.lblItemSerialNo.Name = "lblItemSerialNo";
            this.lblItemSerialNo.Size = new System.Drawing.Size(88, 14);
            this.lblItemSerialNo.TabIndex = 72;
            this.lblItemSerialNo.Text = "Gift Voucher No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(96, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "MAX No. Used:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemName.Location = new System.Drawing.Point(10, 53);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(63, 14);
            this.lblItemName.TabIndex = 104;
            this.lblItemName.Text = "Item Name";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(96, 49);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(346, 22);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtGroupName_DoubleClick);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.Location = new System.Drawing.Point(96, 21);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.Size = new System.Drawing.Size(136, 22);
            this.txtItemSerialNo.TabIndex = 0;
            this.txtItemSerialNo.TextChanged += new System.EventHandler(this.txtItemSerialNo_TextChanged);
            this.txtItemSerialNo.DoubleClick += new System.EventHandler(this.txtUserID_DoubleClick);
            this.txtItemSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemSerialNo_KeyDown);
            this.txtItemSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemSerialNo_KeyPress);
            // 
            // lblHighestReceiptNo
            // 
            this.lblHighestReceiptNo.AutoSize = true;
            this.lblHighestReceiptNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestReceiptNo.ForeColor = System.Drawing.Color.Black;
            this.lblHighestReceiptNo.Location = new System.Drawing.Point(179, 4);
            this.lblHighestReceiptNo.Name = "lblHighestReceiptNo";
            this.lblHighestReceiptNo.Size = new System.Drawing.Size(63, 14);
            this.lblHighestReceiptNo.TabIndex = 104;
            this.lblHighestReceiptNo.Text = "Item Name";
            this.lblHighestReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHighestReceiptNo.Click += new System.EventHandler(this.lblHighestReceiptNo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(513, 191);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(435, 191);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(589, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_ItemSerialNo_GiftVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(673, 548);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_ItemSerialNo_GiftVoucher";
            this.Text = "Item Serial No - Gift Voucher";
            this.Load += new System.EventHandler(this.frm_ItemSerialNo_GiftVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrUser_KeyDown);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label lblItemSerialNo;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDateValidTill;
        private System.Windows.Forms.DateTimePicker dtpDateValidFrom;
        private System.Windows.Forms.Label lblDateValidTill;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrifix;
        private System.Windows.Forms.TextBox txtVoucherAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHighestReceiptNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateValidFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateValidTill;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucherAmount;



    }
}