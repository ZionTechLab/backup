namespace Digiteq
{
    partial class frm_AccountsOpeningBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AccountsOpeningBalance));
            this.pnlEditArea = new System.Windows.Forms.Panel();
            this.txtAcctType = new System.Windows.Forms.TextBox();
            this.lblPeriodName = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFilters = new System.Windows.Forms.Button();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lablToDate = new System.Windows.Forms.Label();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeriodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPeriodClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEditArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // pnlEditArea
            // 
            this.pnlEditArea.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlEditArea.Controls.Add(this.dateTimePicker1);
            this.pnlEditArea.Controls.Add(this.lablToDate);
            this.pnlEditArea.Controls.Add(this.dtpInvoiceDate);
            this.pnlEditArea.Controls.Add(this.lblFromDate);
            this.pnlEditArea.Controls.Add(this.txtAcctType);
            this.pnlEditArea.Controls.Add(this.lblPeriodName);
            this.pnlEditArea.Location = new System.Drawing.Point(9, 10);
            this.pnlEditArea.Name = "pnlEditArea";
            this.pnlEditArea.Size = new System.Drawing.Size(615, 110);
            this.pnlEditArea.TabIndex = 0;
            // 
            // txtAcctType
            // 
            this.txtAcctType.BackColor = System.Drawing.SystemColors.Window;
            this.txtAcctType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctType.Location = new System.Drawing.Point(125, 18);
            this.txtAcctType.Name = "txtAcctType";
            this.txtAcctType.Size = new System.Drawing.Size(179, 22);
            this.txtAcctType.TabIndex = 596;
            this.txtAcctType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAcctType_KeyUp);
            // 
            // lblPeriodName
            // 
            this.lblPeriodName.AutoSize = true;
            this.lblPeriodName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblPeriodName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPeriodName.Location = new System.Drawing.Point(33, 21);
            this.lblPeriodName.Name = "lblPeriodName";
            this.lblPeriodName.Size = new System.Drawing.Size(73, 14);
            this.lblPeriodName.TabIndex = 579;
            this.lblPeriodName.Text = "Account Type";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(468, 126);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 599;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(549, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 568;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.DateFrom,
            this.DateTo,
            this.PeriodName,
            this.IsPeriodClose});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 168);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(614, 301);
            this.dgvDetail.TabIndex = 567;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btnFilters);
            this.panel5.Controls.Add(this.btnNew);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.pnlEditArea);
            this.panel5.Controls.Add(this.dgvDetail);
            this.panel5.Location = new System.Drawing.Point(3, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(633, 488);
            this.panel5.TabIndex = 601;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // btnFilters
            // 
            this.btnFilters.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilters.Location = new System.Drawing.Point(379, 126);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(83, 25);
            this.btnFilters.TabIndex = 616;
            this.btnFilters.Text = "Clear Filters";
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(125, 57);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(120, 22);
            this.dtpInvoiceDate.TabIndex = 598;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFromDate.Location = new System.Drawing.Point(33, 60);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 14);
            this.lblFromDate.TabIndex = 599;
            this.lblFromDate.Text = "Invoice Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(414, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 22);
            this.dateTimePicker1.TabIndex = 600;
            // 
            // lablToDate
            // 
            this.lablToDate.AutoSize = true;
            this.lablToDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lablToDate.Location = new System.Drawing.Point(322, 63);
            this.lablToDate.Name = "lablToDate";
            this.lablToDate.Size = new System.Drawing.Size(69, 14);
            this.lablToDate.TabIndex = 601;
            this.lablToDate.Text = "Invoice Date";
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "#";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 50;
            // 
            // DateFrom
            // 
            this.DateFrom.HeaderText = "Date From";
            this.DateFrom.Name = "DateFrom";
            // 
            // DateTo
            // 
            this.DateTo.HeaderText = "Date To";
            this.DateTo.Name = "DateTo";
            // 
            // PeriodName
            // 
            this.PeriodName.HeaderText = "Period Name";
            this.PeriodName.Name = "PeriodName";
            this.PeriodName.Width = 180;
            // 
            // IsPeriodClose
            // 
            this.IsPeriodClose.HeaderText = "Is Period Close";
            this.IsPeriodClose.Name = "IsPeriodClose";
            // 
            // frm_AccountsOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(639, 520);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AccountsOpeningBalance";
            this.Text = "Accounts Opening Balance";
            this.Load += new System.EventHandler(this.frm_AccountsOpeningBalance_Load);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.pnlEditArea.ResumeLayout(false);
            this.pnlEditArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEditArea;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPeriodName;
        private System.Windows.Forms.TextBox txtAcctType;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lablToDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeriodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPeriodClose;
    }
}