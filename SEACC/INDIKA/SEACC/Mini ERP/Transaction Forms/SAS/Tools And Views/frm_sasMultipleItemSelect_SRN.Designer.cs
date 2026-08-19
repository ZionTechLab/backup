namespace Digiteq
{
    partial class frm_sasMultipleItemSelect_SRN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new SEACC_DataGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gDONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gDODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gQty_Returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gQty_Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gQty_SRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gSalesNoteTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gOrderRefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.gDONo,
            this.gDODate,
            this.gQty,
            this.gQty_Returned,
            this.gQty_Available,
            this.gUnitPrice,
            this.gQty_SRN,
            this.gWeight,
            this.gInvoiceNo,
            this.gJobNo,
            this.gSalesNoteTypeID,
            this.gOrderRefID,
            this.gRemarks});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 12);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(583, 334);
            this.dgvDetail.TabIndex = 452;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(94, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 25);
            this.btnSave.TabIndex = 487;
            this.btnSave.Text = "  Select (F10)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(10, 352);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 25);
            this.btnNew.TabIndex = 488;
            this.btnNew.Text = "  New (F9)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(514, 355);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(77, 23);
            this.txtSubTotal.TabIndex = 489;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(441, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 490;
            this.label9.Text = "Total Qty";
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "#";
            this.LineNo.Name = "LineNo";
            this.LineNo.Visible = false;
            this.LineNo.Width = 40;
            // 
            // gDONo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gDONo.DefaultCellStyle = dataGridViewCellStyle1;
            this.gDONo.HeaderText = "DO #";
            this.gDONo.Name = "gDONo";
            this.gDONo.ReadOnly = true;
            this.gDONo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gDODate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gDODate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gDODate.HeaderText = "DO Date";
            this.gDODate.Name = "gDODate";
            this.gDODate.ReadOnly = true;
            this.gDODate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gDODate.Width = 80;
            // 
            // gQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.gQty.HeaderText = "DO Qty";
            this.gQty.Name = "gQty";
            this.gQty.ReadOnly = true;
            this.gQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gQty.Width = 80;
            // 
            // gQty_Returned
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gQty_Returned.DefaultCellStyle = dataGridViewCellStyle4;
            this.gQty_Returned.HeaderText = "Returned Qty";
            this.gQty_Returned.Name = "gQty_Returned";
            this.gQty_Returned.ReadOnly = true;
            this.gQty_Returned.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gQty_Returned.Width = 80;
            // 
            // gQty_Available
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gQty_Available.DefaultCellStyle = dataGridViewCellStyle5;
            this.gQty_Available.HeaderText = "Balanced Qty";
            this.gQty_Available.Name = "gQty_Available";
            this.gQty_Available.ReadOnly = true;
            this.gQty_Available.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gQty_Available.Width = 80;
            // 
            // gUnitPrice
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gUnitPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.gUnitPrice.HeaderText = "Unit Price";
            this.gUnitPrice.Name = "gUnitPrice";
            this.gUnitPrice.ReadOnly = true;
            this.gUnitPrice.Width = 80;
            // 
            // gQty_SRN
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gQty_SRN.DefaultCellStyle = dataGridViewCellStyle7;
            this.gQty_SRN.HeaderText = "SRN Qty";
            this.gQty_SRN.Name = "gQty_SRN";
            this.gQty_SRN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gQty_SRN.Width = 80;
            // 
            // gWeight
            // 
            this.gWeight.HeaderText = "Weight";
            this.gWeight.Name = "gWeight";
            this.gWeight.Visible = false;
            // 
            // gInvoiceNo
            // 
            this.gInvoiceNo.HeaderText = "Invoice No";
            this.gInvoiceNo.Name = "gInvoiceNo";
            this.gInvoiceNo.Visible = false;
            // 
            // gJobNo
            // 
            this.gJobNo.HeaderText = "Job No";
            this.gJobNo.Name = "gJobNo";
            this.gJobNo.Visible = false;
            // 
            // gSalesNoteTypeID
            // 
            this.gSalesNoteTypeID.HeaderText = "SalesNoteType Code";
            this.gSalesNoteTypeID.Name = "gSalesNoteTypeID";
            this.gSalesNoteTypeID.Visible = false;
            // 
            // gOrderRefID
            // 
            this.gOrderRefID.HeaderText = "OrderRef ID";
            this.gOrderRefID.Name = "gOrderRefID";
            this.gOrderRefID.Visible = false;
            // 
            // gRemarks
            // 
            this.gRemarks.HeaderText = "Remarks";
            this.gRemarks.Name = "gRemarks";
            this.gRemarks.Visible = false;
            // 
            // frm_sasMultipleItemSelect_SRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 392);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasMultipleItemSelect_SRN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_sasOpeningBalance";
            this.Load += new System.EventHandler(this.frm_sasOpeningBalance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasMultipleItemSelect_SRN_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gDONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gDODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gQty_Returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn gQty_Available;
        private System.Windows.Forms.DataGridViewTextBoxColumn gUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn gQty_SRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn gWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn gInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gSalesNoteTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gOrderRefID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRemarks;
    }
}