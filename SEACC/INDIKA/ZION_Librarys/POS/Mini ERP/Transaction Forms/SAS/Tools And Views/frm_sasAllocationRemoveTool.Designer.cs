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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCreaditNoteNo = new System.Windows.Forms.TextBox();
            this.lblCreaditNoteNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtAllocationID = new System.Windows.Forms.TextBox();
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.lblAlocationID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.allocationiD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sattledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAdvancePayment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isOverPayment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCreaditNoteNo);
            this.panel1.Controls.Add(this.lblCreaditNoteNo);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.lblInvoiceNo);
            this.panel1.Controls.Add(this.txtAllocationID);
            this.panel1.Controls.Add(this.txtReceiptID);
            this.panel1.Controls.Add(this.lblReceiptID);
            this.panel1.Controls.Add(this.lblAlocationID);
            this.panel1.Location = new System.Drawing.Point(7, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 70);
            this.panel1.TabIndex = 0;
            // 
            // txtCreaditNoteNo
            // 
            this.txtCreaditNoteNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCreaditNoteNo.Enabled = false;
            this.txtCreaditNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreaditNoteNo.Location = new System.Drawing.Point(510, 42);
            this.txtCreaditNoteNo.Name = "txtCreaditNoteNo";
            this.txtCreaditNoteNo.Size = new System.Drawing.Size(120, 22);
            this.txtCreaditNoteNo.TabIndex = 7;
            // 
            // lblCreaditNoteNo
            // 
            this.lblCreaditNoteNo.AutoSize = true;
            this.lblCreaditNoteNo.Enabled = false;
            this.lblCreaditNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreaditNoteNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCreaditNoteNo.Location = new System.Drawing.Point(408, 45);
            this.lblCreaditNoteNo.Name = "lblCreaditNoteNo";
            this.lblCreaditNoteNo.Size = new System.Drawing.Size(80, 14);
            this.lblCreaditNoteNo.TabIndex = 6;
            this.lblCreaditNoteNo.Text = "Credit Note No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtInvoiceNo.Enabled = false;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(510, 16);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(120, 22);
            this.txtInvoiceNo.TabIndex = 5;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Enabled = false;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblInvoiceNo.Location = new System.Drawing.Point(408, 19);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(59, 14);
            this.lblInvoiceNo.TabIndex = 4;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // txtAllocationID
            // 
            this.txtAllocationID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAllocationID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocationID.Location = new System.Drawing.Point(121, 16);
            this.txtAllocationID.Name = "txtAllocationID";
            this.txtAllocationID.Size = new System.Drawing.Size(120, 22);
            this.txtAllocationID.TabIndex = 3;
            this.txtAllocationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsettelment_KeyDown);
            this.txtAllocationID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtsettelment_MouseDoubleClick);
            // 
            // txtReceiptID
            // 
            this.txtReceiptID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtReceiptID.Enabled = false;
            this.txtReceiptID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptID.Location = new System.Drawing.Point(121, 42);
            this.txtReceiptID.Name = "txtReceiptID";
            this.txtReceiptID.Size = new System.Drawing.Size(120, 22);
            this.txtReceiptID.TabIndex = 2;
            this.txtReceiptID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptID_KeyDown);
            this.txtReceiptID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtReceiptID_MouseDoubleClick);
            // 
            // lblReceiptID
            // 
            this.lblReceiptID.AutoSize = true;
            this.lblReceiptID.Enabled = false;
            this.lblReceiptID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblReceiptID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReceiptID.Location = new System.Drawing.Point(18, 45);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(61, 14);
            this.lblReceiptID.TabIndex = 1;
            this.lblReceiptID.Text = "Receipt No";
            // 
            // lblAlocationID
            // 
            this.lblAlocationID.AutoSize = true;
            this.lblAlocationID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlocationID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAlocationID.Location = new System.Drawing.Point(18, 19);
            this.lblAlocationID.Name = "lblAlocationID";
            this.lblAlocationID.Size = new System.Drawing.Size(73, 14);
            this.lblAlocationID.TabIndex = 0;
            this.lblAlocationID.Text = "Allocation No";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(7, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 37);
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
            this.allocationiD,
            this.invoiceid,
            this.AllocationDate,
            this.SettledDate,
            this.receiptid,
            this.sattledAmount,
            this.isAdvancePayment,
            this.isOverPayment});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 109);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(665, 334);
            this.dgvDetail.TabIndex = 463;
            // 
            // allocationiD
            // 
            this.allocationiD.HeaderText = "Allocation ID";
            this.allocationiD.Name = "allocationiD";
            // 
            // invoiceid
            // 
            this.invoiceid.HeaderText = "Invoice NO";
            this.invoiceid.Name = "invoiceid";
            // 
            // AllocationDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.AllocationDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.AllocationDate.HeaderText = "Allocation Date";
            this.AllocationDate.Name = "AllocationDate";
            this.AllocationDate.ReadOnly = true;
            // 
            // SettledDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.SettledDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.SettledDate.HeaderText = "Settled Date";
            this.SettledDate.Name = "SettledDate";
            this.SettledDate.ReadOnly = true;
            // 
            // receiptid
            // 
            this.receiptid.HeaderText = "Receipt NO";
            this.receiptid.Name = "receiptid";
            // 
            // sattledAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.sattledAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.sattledAmount.HeaderText = "Settled Amount";
            this.sattledAmount.Name = "sattledAmount";
            // 
            // isAdvancePayment
            // 
            this.isAdvancePayment.HeaderText = "Adv";
            this.isAdvancePayment.Name = "isAdvancePayment";
            this.isAdvancePayment.ReadOnly = true;
            this.isAdvancePayment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isAdvancePayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isAdvancePayment.Width = 31;
            // 
            // isOverPayment
            // 
            this.isOverPayment.HeaderText = "Ovr";
            this.isOverPayment.Name = "isOverPayment";
            this.isOverPayment.ReadOnly = true;
            this.isOverPayment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isOverPayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isOverPayment.Width = 31;
            // 
            // frm_sasAllocationRemoveTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(678, 492);
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
        private System.Windows.Forms.Label lblAlocationID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReceiptID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtCreaditNoteNo;
        private System.Windows.Forms.Label lblCreaditNoteNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn allocationiD;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sattledAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAdvancePayment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOverPayment;
        private System.Windows.Forms.TextBox txtAllocationID;
    }
}