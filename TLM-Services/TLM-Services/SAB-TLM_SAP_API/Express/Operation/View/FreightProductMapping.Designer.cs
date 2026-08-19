namespace Express.UI.Operation.View
{
    partial class FreightProductMapping
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.txtInvoiceTypeCode = new System.Windows.Forms.TextBox();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.txtAgencyCode = new System.Windows.Forms.TextBox();
            this.cmbAgency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdFreightProductMappings = new System.Windows.Forms.DataGridView();
            this.SvcTypeN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SvcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackTypeN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WgtFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WgtTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgncyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPackType = new System.Windows.Forms.ComboBox();
            this.cmbSvcType = new System.Windows.Forms.ComboBox();
            this.rdNonDoc = new System.Windows.Forms.RadioButton();
            this.rdDoc = new System.Windows.Forms.RadioButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtWeight_To = new System.Windows.Forms.TextBox();
            this.txtWeight_From = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataManipulate1 = new Express.UI.Common.CustomControl.DataManipulate();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightProductMappings)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.cmbProduct);
            this.groupBox1.Controls.Add(this.txtInvoiceTypeCode);
            this.groupBox1.Controls.Add(this.cmbInvoiceType);
            this.groupBox1.Controls.Add(this.txtAgencyCode);
            this.groupBox1.Controls.Add(this.cmbAgency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtProductCode.Location = new System.Drawing.Point(90, 57);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(53, 22);
            this.txtProductCode.TabIndex = 27;
            // 
            // cmbProduct
            // 
            this.cmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(144, 58);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(191, 21);
            this.cmbProduct.TabIndex = 26;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // txtInvoiceTypeCode
            // 
            this.txtInvoiceTypeCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtInvoiceTypeCode.Location = new System.Drawing.Point(90, 34);
            this.txtInvoiceTypeCode.Name = "txtInvoiceTypeCode";
            this.txtInvoiceTypeCode.Size = new System.Drawing.Size(53, 22);
            this.txtInvoiceTypeCode.TabIndex = 27;
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoiceType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(144, 35);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(191, 21);
            this.cmbInvoiceType.TabIndex = 26;
            this.cmbInvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceType_SelectedIndexChanged);
            // 
            // txtAgencyCode
            // 
            this.txtAgencyCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAgencyCode.Location = new System.Drawing.Point(90, 11);
            this.txtAgencyCode.Name = "txtAgencyCode";
            this.txtAgencyCode.Size = new System.Drawing.Size(53, 22);
            this.txtAgencyCode.TabIndex = 27;
            // 
            // cmbAgency
            // 
            this.cmbAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAgency.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbAgency.FormattingEnabled = true;
            this.cmbAgency.Location = new System.Drawing.Point(144, 12);
            this.cmbAgency.Name = "cmbAgency";
            this.cmbAgency.Size = new System.Drawing.Size(191, 21);
            this.cmbAgency.TabIndex = 26;
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Product :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Invoice Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Agency :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(9, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 277);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Agency :";
            // 
            // grdFreightProductMappings
            // 
            this.grdFreightProductMappings.AllowUserToAddRows = false;
            this.grdFreightProductMappings.AllowUserToDeleteRows = false;
            this.grdFreightProductMappings.AllowUserToResizeColumns = false;
            this.grdFreightProductMappings.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.grdFreightProductMappings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFreightProductMappings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdFreightProductMappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFreightProductMappings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SvcTypeN,
            this.PackType,
            this.SvcType,
            this.PackTypeN,
            this.DocNDoc,
            this.WgtFrom,
            this.WgtTo,
            this.Remarks,
            this.AgncyCode,
            this.ProductM,
            this.ProductS});
            this.grdFreightProductMappings.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFreightProductMappings.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdFreightProductMappings.EnableHeadersVisualStyles = false;
            this.grdFreightProductMappings.Location = new System.Drawing.Point(17, 98);
            this.grdFreightProductMappings.MultiSelect = false;
            this.grdFreightProductMappings.Name = "grdFreightProductMappings";
            this.grdFreightProductMappings.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.grdFreightProductMappings.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdFreightProductMappings.RowTemplate.Height = 20;
            this.grdFreightProductMappings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdFreightProductMappings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFreightProductMappings.Size = new System.Drawing.Size(606, 255);
            this.grdFreightProductMappings.TabIndex = 6;
            this.grdFreightProductMappings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFreightProductMappings_CellClick);
            // 
            // SvcTypeN
            // 
            this.SvcTypeN.DataPropertyName = "SvcTypeN";
            this.SvcTypeN.HeaderText = "Service Type";
            this.SvcTypeN.Name = "SvcTypeN";
            this.SvcTypeN.ReadOnly = true;
            this.SvcTypeN.Width = 120;
            // 
            // PackType
            // 
            this.PackType.DataPropertyName = "PackType";
            this.PackType.HeaderText = "PackTypeCode";
            this.PackType.Name = "PackType";
            this.PackType.Visible = false;
            // 
            // SvcType
            // 
            this.SvcType.DataPropertyName = "SvcType";
            this.SvcType.HeaderText = "SvcTypeCode";
            this.SvcType.Name = "SvcType";
            this.SvcType.Visible = false;
            // 
            // PackTypeN
            // 
            this.PackTypeN.DataPropertyName = "PackTypeN";
            this.PackTypeN.HeaderText = "Pack Type";
            this.PackTypeN.Name = "PackTypeN";
            this.PackTypeN.ReadOnly = true;
            this.PackTypeN.Width = 120;
            // 
            // DocNDoc
            // 
            this.DocNDoc.DataPropertyName = "DocNDoc";
            this.DocNDoc.HeaderText = "D/N";
            this.DocNDoc.Name = "DocNDoc";
            this.DocNDoc.Width = 35;
            // 
            // WgtFrom
            // 
            this.WgtFrom.DataPropertyName = "WgtFrom";
            this.WgtFrom.HeaderText = "Weight From";
            this.WgtFrom.Name = "WgtFrom";
            // 
            // WgtTo
            // 
            this.WgtTo.DataPropertyName = "WgtTo";
            this.WgtTo.HeaderText = "Weight To";
            this.WgtTo.Name = "WgtTo";
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 136;
            // 
            // AgncyCode
            // 
            this.AgncyCode.DataPropertyName = "AgncyCode";
            this.AgncyCode.HeaderText = "AgncyCode";
            this.AgncyCode.Name = "AgncyCode";
            this.AgncyCode.Visible = false;
            // 
            // ProductM
            // 
            this.ProductM.DataPropertyName = "ProductM";
            this.ProductM.HeaderText = "ProductM";
            this.ProductM.Name = "ProductM";
            this.ProductM.Visible = false;
            // 
            // ProductS
            // 
            this.ProductS.DataPropertyName = "ProductS";
            this.ProductS.HeaderText = "ProductS";
            this.ProductS.Name = "ProductS";
            this.ProductS.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cmbPackType);
            this.groupBox3.Controls.Add(this.cmbSvcType);
            this.groupBox3.Controls.Add(this.rdNonDoc);
            this.groupBox3.Controls.Add(this.rdDoc);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(this.txtWeight_To);
            this.groupBox3.Controls.Add(this.txtWeight_From);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(9, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(621, 89);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(522, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "To";
            // 
            // cmbPackType
            // 
            this.cmbPackType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPackType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPackType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbPackType.FormattingEnabled = true;
            this.cmbPackType.Location = new System.Drawing.Point(170, 30);
            this.cmbPackType.Name = "cmbPackType";
            this.cmbPackType.Size = new System.Drawing.Size(160, 21);
            this.cmbPackType.TabIndex = 30;
            this.cmbPackType.SelectedIndexChanged += new System.EventHandler(this.cmbPackType_SelectedIndexChanged);
            this.cmbPackType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPackType_KeyDown);
            // 
            // cmbSvcType
            // 
            this.cmbSvcType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSvcType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSvcType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbSvcType.FormattingEnabled = true;
            this.cmbSvcType.Location = new System.Drawing.Point(7, 30);
            this.cmbSvcType.Name = "cmbSvcType";
            this.cmbSvcType.Size = new System.Drawing.Size(160, 21);
            this.cmbSvcType.TabIndex = 29;
            this.cmbSvcType.SelectedIndexChanged += new System.EventHandler(this.cmbSvcType_SelectedIndexChanged);
            this.cmbSvcType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSvcType_KeyDown);
            // 
            // rdNonDoc
            // 
            this.rdNonDoc.AutoSize = true;
            this.rdNonDoc.Location = new System.Drawing.Point(345, 34);
            this.rdNonDoc.Name = "rdNonDoc";
            this.rdNonDoc.Size = new System.Drawing.Size(68, 17);
            this.rdNonDoc.TabIndex = 28;
            this.rdNonDoc.TabStop = true;
            this.rdNonDoc.Text = "Non Doc";
            this.rdNonDoc.UseVisualStyleBackColor = true;
            this.rdNonDoc.CheckedChanged += new System.EventHandler(this.rdNonDoc_CheckedChanged);
            // 
            // rdDoc
            // 
            this.rdDoc.AutoSize = true;
            this.rdDoc.Location = new System.Drawing.Point(345, 17);
            this.rdDoc.Name = "rdDoc";
            this.rdDoc.Size = new System.Drawing.Size(45, 17);
            this.rdDoc.TabIndex = 28;
            this.rdDoc.TabStop = true;
            this.rdDoc.Text = "Doc";
            this.rdDoc.UseVisualStyleBackColor = true;
            this.rdDoc.CheckedChanged += new System.EventHandler(this.rdDoc_CheckedChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtRemarks.Location = new System.Drawing.Point(90, 59);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(523, 22);
            this.txtRemarks.TabIndex = 27;
            // 
            // txtWeight_To
            // 
            this.txtWeight_To.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtWeight_To.Location = new System.Drawing.Point(545, 29);
            this.txtWeight_To.Name = "txtWeight_To";
            this.txtWeight_To.Size = new System.Drawing.Size(68, 22);
            this.txtWeight_To.TabIndex = 27;
            this.txtWeight_To.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_To_KeyPress);
            // 
            // txtWeight_From
            // 
            this.txtWeight_From.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtWeight_From.Location = new System.Drawing.Point(450, 29);
            this.txtWeight_From.Name = "txtWeight_From";
            this.txtWeight_From.Size = new System.Drawing.Size(68, 22);
            this.txtWeight_From.TabIndex = 27;
            this.txtWeight_From.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_From_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Weight Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Remarks :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Pack Type *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Service Type *";
            // 
            // dataManipulate1
            // 
            this.dataManipulate1.Location = new System.Drawing.Point(203, 454);
            this.dataManipulate1.Name = "dataManipulate1";
            this.dataManipulate1.Size = new System.Drawing.Size(623, 46);
            this.dataManipulate1.TabIndex = 14;
            // 
            // FreightProductMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 502);
            this.Controls.Add(this.grdFreightProductMappings);
            this.Controls.Add(this.dataManipulate1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FreightProductMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Freight Product Mapping";
            this.Load += new System.EventHandler(this.FreightProductMapping_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightProductMappings)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAgency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAgencyCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.TextBox txtInvoiceTypeCode;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdFreightProductMappings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtWeight_To;
        private System.Windows.Forms.TextBox txtWeight_From;
        private System.Windows.Forms.RadioButton rdNonDoc;
        private System.Windows.Forms.RadioButton rdDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private Common.CustomControl.DataManipulate dataManipulate1;
        private System.Windows.Forms.ComboBox cmbPackType;
        private System.Windows.Forms.ComboBox cmbSvcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SvcTypeN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SvcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackTypeN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn WgtFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn WgtTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgncyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductS;
    }
}