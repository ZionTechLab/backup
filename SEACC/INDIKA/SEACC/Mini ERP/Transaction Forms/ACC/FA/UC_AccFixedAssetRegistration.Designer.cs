namespace Digiteq
{
    partial class UC_AccFixedAssetRegistration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDebitNoteID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFixedAssetD = new System.Windows.Forms.TextBox();
            this.dtpAquisitionDate = new System.Windows.Forms.DateTimePicker();
            this.txtLifeTime = new System.Windows.Forms.TextBox();
            this.txtDepRate = new System.Windows.Forms.TextBox();
            this.txtBarcodeNo = new System.Windows.Forms.TextBox();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.fixedAssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aquisitionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lifeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depreciationRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(815, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 564;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblDebitNoteID
            // 
            this.lblDebitNoteID.AutoSize = true;
            this.lblDebitNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDebitNoteID.Location = new System.Drawing.Point(857, 9);
            this.lblDebitNoteID.Name = "lblDebitNoteID";
            this.lblDebitNoteID.Size = new System.Drawing.Size(91, 14);
            this.lblDebitNoteID.TabIndex = 567;
            this.lblDebitNoteID.Text = "Fixed Asset Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(857, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 568;
            this.label1.Text = "Depreciation Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(857, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 14);
            this.label2.TabIndex = 569;
            this.label2.Text = "Useful life Time (Years)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(857, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 570;
            this.label3.Text = "Acquisition Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(865, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 571;
            this.label4.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(865, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 14);
            this.label5.TabIndex = 572;
            this.label5.Text = "Item Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(865, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 573;
            this.label6.Text = "Item Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(865, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 574;
            this.label7.Text = "Item ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(865, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 575;
            this.label8.Text = "Serial No.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(857, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 576;
            this.label9.Text = "Barcode No.";
            // 
            // txtFixedAssetD
            // 
            this.txtFixedAssetD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtFixedAssetD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFixedAssetD.Location = new System.Drawing.Point(994, 5);
            this.txtFixedAssetD.Name = "txtFixedAssetD";
            this.txtFixedAssetD.ReadOnly = true;
            this.txtFixedAssetD.Size = new System.Drawing.Size(136, 22);
            this.txtFixedAssetD.TabIndex = 577;
            this.txtFixedAssetD.DoubleClick += new System.EventHandler(this.txtFixedAssetD_DoubleClick);
            // 
            // dtpAquisitionDate
            // 
            this.dtpAquisitionDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAquisitionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAquisitionDate.Location = new System.Drawing.Point(994, 140);
            this.dtpAquisitionDate.Name = "dtpAquisitionDate";
            this.dtpAquisitionDate.Size = new System.Drawing.Size(136, 22);
            this.dtpAquisitionDate.TabIndex = 578;
            // 
            // txtLifeTime
            // 
            this.txtLifeTime.BackColor = System.Drawing.Color.White;
            this.txtLifeTime.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLifeTime.Location = new System.Drawing.Point(994, 167);
            this.txtLifeTime.Name = "txtLifeTime";
            this.txtLifeTime.Size = new System.Drawing.Size(136, 22);
            this.txtLifeTime.TabIndex = 579;
            this.txtLifeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLifeTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLifeTime_KeyPress);
            // 
            // txtDepRate
            // 
            this.txtDepRate.BackColor = System.Drawing.Color.White;
            this.txtDepRate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepRate.Location = new System.Drawing.Point(994, 192);
            this.txtDepRate.Name = "txtDepRate";
            this.txtDepRate.Size = new System.Drawing.Size(136, 22);
            this.txtDepRate.TabIndex = 580;
            this.txtDepRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDepRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepRate_KeyPress);
            // 
            // txtBarcodeNo
            // 
            this.txtBarcodeNo.BackColor = System.Drawing.Color.LightGray;
            this.txtBarcodeNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeNo.Location = new System.Drawing.Point(994, 30);
            this.txtBarcodeNo.Name = "txtBarcodeNo";
            this.txtBarcodeNo.ReadOnly = true;
            this.txtBarcodeNo.Size = new System.Drawing.Size(136, 22);
            this.txtBarcodeNo.TabIndex = 581;
            this.txtBarcodeNo.DoubleClick += new System.EventHandler(this.txtBarcodeNo_DoubleClick);
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSerialNo.Location = new System.Drawing.Point(994, 55);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(136, 14);
            this.lblSerialNo.TabIndex = 582;
            this.lblSerialNo.Text = "Serial No.";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplier.Location = new System.Drawing.Point(994, 115);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(136, 14);
            this.lblSupplier.TabIndex = 583;
            this.lblSupplier.Text = "supplier";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemDescription.Location = new System.Drawing.Point(994, 100);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(136, 14);
            this.lblItemDescription.TabIndex = 584;
            this.lblItemDescription.Text = "Des.";
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemName.Location = new System.Drawing.Point(994, 85);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(136, 14);
            this.lblItemName.TabIndex = 585;
            this.lblItemName.Text = "name";
            // 
            // lblItemID
            // 
            this.lblItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemID.Location = new System.Drawing.Point(994, 70);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(136, 14);
            this.lblItemID.TabIndex = 586;
            this.lblItemID.Text = "Item ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.lblItemID);
            this.panel2.Controls.Add(this.lblItemName);
            this.panel2.Controls.Add(this.lblItemDescription);
            this.panel2.Controls.Add(this.lblSupplier);
            this.panel2.Controls.Add(this.lblSerialNo);
            this.panel2.Controls.Add(this.txtBarcodeNo);
            this.panel2.Controls.Add(this.txtDepRate);
            this.panel2.Controls.Add(this.txtLifeTime);
            this.panel2.Controls.Add(this.dtpAquisitionDate);
            this.panel2.Controls.Add(this.txtFixedAssetD);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblDebitNoteID);
            this.panel2.Controls.Add(this.dgvDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1151, 358);
            this.panel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1132, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(16, 22);
            this.textBox1.TabIndex = 587;
            this.textBox1.Text = "%";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeight = 30;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fixedAssetCode,
            this.barcodeNo,
            this.serialNo,
            this.itemID,
            this.itemName,
            this.itemDes,
            this.supplier,
            this.aquisitionDate,
            this.lifeTime,
            this.depreciationRate});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(848, 338);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // fixedAssetCode
            // 
            this.fixedAssetCode.DataPropertyName = "fixedAssetCode";
            this.fixedAssetCode.HeaderText = "Fixed Asset Code";
            this.fixedAssetCode.Name = "fixedAssetCode";
            this.fixedAssetCode.ReadOnly = true;
            this.fixedAssetCode.Width = 76;
            // 
            // barcodeNo
            // 
            this.barcodeNo.DataPropertyName = "barcodeNo";
            this.barcodeNo.HeaderText = "Barcode No";
            this.barcodeNo.Name = "barcodeNo";
            this.barcodeNo.ReadOnly = true;
            this.barcodeNo.Width = 80;
            // 
            // serialNo
            // 
            this.serialNo.DataPropertyName = "serialNo";
            this.serialNo.HeaderText = "Serial No";
            this.serialNo.Name = "serialNo";
            this.serialNo.ReadOnly = true;
            this.serialNo.Width = 70;
            // 
            // itemID
            // 
            this.itemID.DataPropertyName = "itemID";
            this.itemID.HeaderText = "Item ID";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            // 
            // itemName
            // 
            this.itemName.DataPropertyName = "itemName";
            this.itemName.HeaderText = "Item Name";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            // 
            // itemDes
            // 
            this.itemDes.DataPropertyName = "itemDes";
            this.itemDes.HeaderText = "Item Description";
            this.itemDes.Name = "itemDes";
            this.itemDes.ReadOnly = true;
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "Supplier";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            // 
            // aquisitionDate
            // 
            this.aquisitionDate.DataPropertyName = "aquisitionDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aquisitionDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.aquisitionDate.HeaderText = "Aquisition Date";
            this.aquisitionDate.Name = "aquisitionDate";
            this.aquisitionDate.ReadOnly = true;
            this.aquisitionDate.Width = 72;
            // 
            // lifeTime
            // 
            this.lifeTime.DataPropertyName = "lifeTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.lifeTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.lifeTime.HeaderText = "Life Time";
            this.lifeTime.Name = "lifeTime";
            this.lifeTime.ReadOnly = true;
            this.lifeTime.Width = 54;
            // 
            // depreciationRate
            // 
            this.depreciationRate.DataPropertyName = "depreciationRate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.depreciationRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.depreciationRate.HeaderText = "Depreciation Rate %";
            this.depreciationRate.Name = "depreciationRate";
            this.depreciationRate.ReadOnly = true;
            this.depreciationRate.Width = 75;
            // 
            // UC_AccFixedAssetRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "UC_AccFixedAssetRegistration";
            this.Size = new System.Drawing.Size(1153, 406);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccFixedAssetRegistration_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccFixedAssetRegistration_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccFixedAssetRegistration_SF_cancelButton_Click);
            this.Load += new System.EventHandler(this.UC_AccFixedAssetRegistration_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDebitNoteID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFixedAssetD;
        private System.Windows.Forms.DateTimePicker dtpAquisitionDate;
        private System.Windows.Forms.TextBox txtLifeTime;
        private System.Windows.Forms.TextBox txtDepRate;
        private System.Windows.Forms.TextBox txtBarcodeNo;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Panel panel2;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixedAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn aquisitionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lifeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn depreciationRate;

    }
}
