namespace Digiteq
{
    partial class frm_scsAddNewBarcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlGRN = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCopytoNext = new System.Windows.Forms.CheckBox();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.dtpOEMDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpLocalDate = new System.Windows.Forms.DateTimePicker();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBarcode = new System.Windows.Forms.DataGridView();
            this.barcode_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryOEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteIc = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.pnlGRN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlGRN);
            this.panel1.Controls.Add(this.txtSerialNo);
            this.panel1.Controls.Add(this.txtTransactionID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 95);
            this.panel1.TabIndex = 0;
            // 
            // pnlGRN
            // 
            this.pnlGRN.Controls.Add(this.label2);
            this.pnlGRN.Controls.Add(this.chkCopytoNext);
            this.pnlGRN.Controls.Add(this.txtBatchNo);
            this.pnlGRN.Controls.Add(this.dtpOEMDate);
            this.pnlGRN.Controls.Add(this.label4);
            this.pnlGRN.Controls.Add(this.label3);
            this.pnlGRN.Controls.Add(this.dtpLocalDate);
            this.pnlGRN.Location = new System.Drawing.Point(349, -1);
            this.pnlGRN.Name = "pnlGRN";
            this.pnlGRN.Size = new System.Drawing.Size(380, 95);
            this.pnlGRN.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch No.";
            // 
            // chkCopytoNext
            // 
            this.chkCopytoNext.AutoSize = true;
            this.chkCopytoNext.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkCopytoNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCopytoNext.Location = new System.Drawing.Point(267, 61);
            this.chkCopytoNext.Name = "chkCopytoNext";
            this.chkCopytoNext.Size = new System.Drawing.Size(98, 19);
            this.chkCopytoNext.TabIndex = 10;
            this.chkCopytoNext.Text = "Copy to Next";
            this.chkCopytoNext.UseVisualStyleBackColor = true;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(77, 5);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(174, 20);
            this.txtBatchNo.TabIndex = 3;
            // 
            // dtpOEMDate
            // 
            this.dtpOEMDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOEMDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOEMDate.Location = new System.Drawing.Point(77, 31);
            this.dtpOEMDate.Name = "dtpOEMDate";
            this.dtpOEMDate.Size = new System.Drawing.Size(174, 22);
            this.dtpOEMDate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Expiry Local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Expiry OEM";
            // 
            // dtpLocalDate
            // 
            this.dtpLocalDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLocalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLocalDate.Location = new System.Drawing.Point(78, 60);
            this.dtpLocalDate.Name = "dtpLocalDate";
            this.dtpLocalDate.Size = new System.Drawing.Size(174, 22);
            this.dtpLocalDate.TabIndex = 8;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(82, 60);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(174, 22);
            this.txtSerialNo.TabIndex = 0;
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNo_KeyPress);
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTransactionID.Enabled = false;
            this.txtTransactionID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionID.Location = new System.Drawing.Point(82, 5);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(174, 22);
            this.txtTransactionID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(3, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serial No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transction ID";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemID,
            this.itemDescription,
            this.itemQty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItem.Location = new System.Drawing.Point(3, 105);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(345, 238);
            this.dgvItem.TabIndex = 2;
            this.dgvItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellClick);
            // 
            // itemID
            // 
            this.itemID.HeaderText = "Item Code";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            this.itemID.Width = 85;
            // 
            // itemDescription
            // 
            this.itemDescription.HeaderText = "Description";
            this.itemDescription.Name = "itemDescription";
            this.itemDescription.ReadOnly = true;
            this.itemDescription.Width = 205;
            // 
            // itemQty
            // 
            this.itemQty.HeaderText = "Qty";
            this.itemQty.Name = "itemQty";
            this.itemQty.ReadOnly = true;
            this.itemQty.Width = 50;
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            this.dgvBarcode.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBarcode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcode_ID,
            this.serialNo,
            this.barcode,
            this.batchNo,
            this.expiryOEM,
            this.expiryLocal,
            this.deleteIc});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcode.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBarcode.Location = new System.Drawing.Point(354, 105);
            this.dgvBarcode.MultiSelect = false;
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarcode.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBarcode.RowHeadersVisible = false;
            this.dgvBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBarcode.Size = new System.Drawing.Size(388, 238);
            this.dgvBarcode.TabIndex = 3;
            this.dgvBarcode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellContentClick);
            // 
            // barcode_ID
            // 
            this.barcode_ID.DataPropertyName = "barcode_ID";
            this.barcode_ID.HeaderText = "Barcode ID";
            this.barcode_ID.Name = "barcode_ID";
            this.barcode_ID.ReadOnly = true;
            this.barcode_ID.Visible = false;
            this.barcode_ID.Width = 90;
            // 
            // serialNo
            // 
            this.serialNo.DataPropertyName = "serialNo";
            this.serialNo.HeaderText = "Serial No.";
            this.serialNo.Name = "serialNo";
            this.serialNo.ReadOnly = true;
            this.serialNo.Width = 90;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Visible = false;
            this.barcode.Width = 5;
            // 
            // batchNo
            // 
            this.batchNo.DataPropertyName = "batchNo";
            this.batchNo.HeaderText = "Batch No.";
            this.batchNo.Name = "batchNo";
            this.batchNo.ReadOnly = true;
            this.batchNo.Width = 85;
            // 
            // expiryOEM
            // 
            this.expiryOEM.DataPropertyName = "expiryOEM";
            this.expiryOEM.HeaderText = "Exp. OEM";
            this.expiryOEM.Name = "expiryOEM";
            this.expiryOEM.ReadOnly = true;
            this.expiryOEM.Width = 80;
            // 
            // expiryLocal
            // 
            this.expiryLocal.DataPropertyName = "expiryLocal";
            this.expiryLocal.HeaderText = "Exp. Local";
            this.expiryLocal.Name = "expiryLocal";
            this.expiryLocal.ReadOnly = true;
            this.expiryLocal.Width = 80;
            // 
            // deleteIc
            // 
            this.deleteIc.DataPropertyName = "deleteIc";
            this.deleteIc.HeaderText = "Delete";
            this.deleteIc.Image = global::Digiteq.Properties.Resources.delete;
            this.deleteIc.Name = "deleteIc";
            this.deleteIc.ReadOnly = true;
            this.deleteIc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteIc.Width = 50;
            // 
            // frm_scsAddNewBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(747, 348);
            this.Controls.Add(this.dgvBarcode);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_scsAddNewBarcode";
            this.Text = "frm_scsAddNewBarcode";
            this.Load += new System.EventHandler(this.frm_scsAddNewBarcode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGRN.ResumeLayout(false);
            this.pnlGRN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCopytoNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpLocalDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOEMDate;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridView dgvBarcode;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryOEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryLocal;
        private System.Windows.Forms.DataGridViewImageColumn deleteIc;
        private System.Windows.Forms.Panel pnlGRN;
    }
}