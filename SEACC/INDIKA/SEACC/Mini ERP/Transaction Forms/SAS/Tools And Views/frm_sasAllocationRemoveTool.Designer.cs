namespace Digiteq
{
    partial class frm_sasAllocationRemoveTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoIntariam = new System.Windows.Forms.RadioButton();
            this.rdoSales = new System.Windows.Forms.RadioButton();
            this.txtCreaditNoteNo = new System.Windows.Forms.TextBox();
            this.lblCreaditNoteNo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtJE_CR = new System.Windows.Forms.TextBox();
            this.txtJE_DR = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.settled_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalEntry_ID_DR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditNote_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalEntry_ID_CR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdoIntariam);
            this.panel1.Controls.Add(this.rdoSales);
            this.panel1.Controls.Add(this.txtCreaditNoteNo);
            this.panel1.Controls.Add(this.lblCreaditNoteNo);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txtJE_CR);
            this.panel1.Controls.Add(this.txtJE_DR);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInvoiceNo);
            this.panel1.Controls.Add(this.txtReceiptID);
            this.panel1.Controls.Add(this.lblReceiptID);
            this.panel1.Location = new System.Drawing.Point(7, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 79);
            this.panel1.TabIndex = 0;
            // 
            // rdoIntariam
            // 
            this.rdoIntariam.AutoSize = true;
            this.rdoIntariam.Location = new System.Drawing.Point(804, 9);
            this.rdoIntariam.Name = "rdoIntariam";
            this.rdoIntariam.Size = new System.Drawing.Size(68, 17);
            this.rdoIntariam.TabIndex = 8;
            this.rdoIntariam.Text = "Intarium";
            this.rdoIntariam.UseVisualStyleBackColor = true;
            // 
            // rdoSales
            // 
            this.rdoSales.AutoSize = true;
            this.rdoSales.Checked = true;
            this.rdoSales.Location = new System.Drawing.Point(747, 9);
            this.rdoSales.Name = "rdoSales";
            this.rdoSales.Size = new System.Drawing.Size(51, 17);
            this.rdoSales.TabIndex = 8;
            this.rdoSales.TabStop = true;
            this.rdoSales.Text = "Sales";
            this.rdoSales.UseVisualStyleBackColor = true;
            // 
            // txtCreaditNoteNo
            // 
            this.txtCreaditNoteNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCreaditNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreaditNoteNo.Location = new System.Drawing.Point(121, 28);
            this.txtCreaditNoteNo.Name = "txtCreaditNoteNo";
            this.txtCreaditNoteNo.Size = new System.Drawing.Size(120, 22);
            this.txtCreaditNoteNo.TabIndex = 7;
            this.txtCreaditNoteNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCreaditNoteNo_MouseDoubleClick);
            // 
            // lblCreaditNoteNo
            // 
            this.lblCreaditNoteNo.AutoSize = true;
            this.lblCreaditNoteNo.Enabled = false;
            this.lblCreaditNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreaditNoteNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCreaditNoteNo.Location = new System.Drawing.Point(19, 32);
            this.lblCreaditNoteNo.Name = "lblCreaditNoteNo";
            this.lblCreaditNoteNo.Size = new System.Drawing.Size(80, 14);
            this.lblCreaditNoteNo.TabIndex = 6;
            this.lblCreaditNoteNo.Text = "Credit Note No";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(621, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // txtJE_CR
            // 
            this.txtJE_CR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtJE_CR.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJE_CR.Location = new System.Drawing.Point(398, 27);
            this.txtJE_CR.Name = "txtJE_CR";
            this.txtJE_CR.Size = new System.Drawing.Size(120, 22);
            this.txtJE_CR.TabIndex = 5;
            this.txtJE_CR.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtJE_CR_MouseDoubleClick);
            // 
            // txtJE_DR
            // 
            this.txtJE_DR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtJE_DR.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJE_DR.Location = new System.Drawing.Point(398, 7);
            this.txtJE_DR.Name = "txtJE_DR";
            this.txtJE_DR.Size = new System.Drawing.Size(120, 22);
            this.txtJE_DR.TabIndex = 5;
            this.txtJE_DR.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtJE_DR_MouseDoubleClick);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(121, 7);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(120, 22);
            this.txtInvoiceNo.TabIndex = 5;
            this.txtInvoiceNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtInvoiceNo_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(551, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cheque";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(303, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Journal Entry CR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(303, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Journal Entry DR";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Enabled = false;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblInvoiceNo.Location = new System.Drawing.Point(19, 11);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(59, 14);
            this.lblInvoiceNo.TabIndex = 4;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // txtReceiptID
            // 
            this.txtReceiptID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtReceiptID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptID.Location = new System.Drawing.Point(621, 7);
            this.txtReceiptID.Name = "txtReceiptID";
            this.txtReceiptID.Size = new System.Drawing.Size(120, 22);
            this.txtReceiptID.TabIndex = 2;
            this.txtReceiptID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtReceiptID_MouseDoubleClick);
            // 
            // lblReceiptID
            // 
            this.lblReceiptID.AutoSize = true;
            this.lblReceiptID.Enabled = false;
            this.lblReceiptID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblReceiptID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReceiptID.Location = new System.Drawing.Point(551, 11);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(61, 14);
            this.lblReceiptID.TabIndex = 1;
            this.lblReceiptID.Text = "Receipt No";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(7, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 37);
            this.panel2.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(439, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 462;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(520, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 25);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Remove Allocation";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.settled_ID,
            this.SettledDate,
            this.settledAmount,
            this.invoice_ID,
            this.journalEntry_ID_DR,
            this.receipt_ID,
            this.creditNote_ID,
            this.journalEntry_ID_CR,
            this.chequeNumber});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 116);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(910, 334);
            this.dgvDetail.TabIndex = 463;
            // 
            // settled_ID
            // 
            this.settled_ID.DataPropertyName = "settled_ID";
            this.settled_ID.HeaderText = "Settlement ID";
            this.settled_ID.Name = "settled_ID";
            // 
            // SettledDate
            // 
            this.SettledDate.DataPropertyName = "SettledDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.SettledDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.SettledDate.HeaderText = "Settlement Date";
            this.SettledDate.Name = "SettledDate";
            this.SettledDate.ReadOnly = true;
            // 
            // settledAmount
            // 
            this.settledAmount.DataPropertyName = "settledAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.settledAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.settledAmount.HeaderText = "Amount";
            this.settledAmount.Name = "settledAmount";
            // 
            // invoice_ID
            // 
            this.invoice_ID.DataPropertyName = "invoice_ID";
            this.invoice_ID.HeaderText = "Invoice NO";
            this.invoice_ID.Name = "invoice_ID";
            // 
            // journalEntry_ID_DR
            // 
            this.journalEntry_ID_DR.DataPropertyName = "journalEntry_ID_DR";
            this.journalEntry_ID_DR.HeaderText = "JE DR";
            this.journalEntry_ID_DR.Name = "journalEntry_ID_DR";
            // 
            // receipt_ID
            // 
            this.receipt_ID.DataPropertyName = "receipt_ID";
            this.receipt_ID.HeaderText = "Receipt NO";
            this.receipt_ID.Name = "receipt_ID";
            // 
            // creditNote_ID
            // 
            this.creditNote_ID.DataPropertyName = "creditNote_ID";
            this.creditNote_ID.HeaderText = "CreditNote ID";
            this.creditNote_ID.Name = "creditNote_ID";
            // 
            // journalEntry_ID_CR
            // 
            this.journalEntry_ID_CR.DataPropertyName = "journalEntry_ID_CR";
            this.journalEntry_ID_CR.HeaderText = "JE CR";
            this.journalEntry_ID_CR.Name = "journalEntry_ID_CR";
            // 
            // chequeNumber
            // 
            this.chequeNumber.DataPropertyName = "chequeNumber";
            this.chequeNumber.HeaderText = "Cheque Number";
            this.chequeNumber.Name = "chequeNumber";
            // 
            // frm_sasAllocationRemoveTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(929, 492);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasAllocationRemoveTool";
            this.Text = "Allocation  Remove ";
            this.Load += new System.EventHandler(this.frm_sasAllocationRemoveTool_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReceiptID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReceiptID;
        private System.Windows.Forms.Button btnClear;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtCreaditNoteNo;
        private System.Windows.Forms.Label lblCreaditNoteNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtJE_CR;
        private System.Windows.Forms.TextBox txtJE_DR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn settled_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn settledAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalEntry_ID_DR;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditNote_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalEntry_ID_CR;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNumber;
        private System.Windows.Forms.RadioButton rdoIntariam;
        private System.Windows.Forms.RadioButton rdoSales;
    }
}