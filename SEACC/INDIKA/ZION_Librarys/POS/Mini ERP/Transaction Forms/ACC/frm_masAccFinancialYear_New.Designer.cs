namespace Digiteq
{
    partial class frm_masAccFinancialYear_New
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
            this.dgvFinancialYear = new System.Windows.Forms.DataGridView();
            this.FinancialYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFinancialMonth = new System.Windows.Forms.DataGridView();
            this.MonthID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthClosedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthClosedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFinYear = new System.Windows.Forms.Label();
            this.lblFinancialYearMonth = new System.Windows.Forms.Label();
            this.btnCloseMonth = new System.Windows.Forms.Button();
            this.btnCloseYear = new System.Windows.Forms.Button();
            this.pnlBottomLine = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNewFinancialYear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialMonth)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dgvFinancialYear
            // 
            this.dgvFinancialYear.AllowUserToAddRows = false;
            this.dgvFinancialYear.AllowUserToDeleteRows = false;
            this.dgvFinancialYear.AllowUserToResizeRows = false;
            this.dgvFinancialYear.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvFinancialYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFinancialYear.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFinancialYear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFinancialYear.ColumnHeadersHeight = 30;
            this.dgvFinancialYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FinancialYear,
            this.Title,
            this.startDate,
            this.endDate,
            this.status,
            this.ClosedBy,
            this.ClosedDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFinancialYear.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFinancialYear.EnableHeadersVisualStyles = false;
            this.dgvFinancialYear.Location = new System.Drawing.Point(9, 37);
            this.dgvFinancialYear.MultiSelect = false;
            this.dgvFinancialYear.Name = "dgvFinancialYear";
            this.dgvFinancialYear.ReadOnly = true;
            this.dgvFinancialYear.RowHeadersVisible = false;
            this.dgvFinancialYear.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFinancialYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinancialYear.Size = new System.Drawing.Size(667, 184);
            this.dgvFinancialYear.TabIndex = 7;
            this.dgvFinancialYear.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinancialYear_CellClick);
            // 
            // FinancialYear
            // 
            this.FinancialYear.DataPropertyName = "FinancialYear";
            this.FinancialYear.HeaderText = "Financial Year";
            this.FinancialYear.Name = "FinancialYear";
            this.FinancialYear.ReadOnly = true;
            this.FinancialYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FinancialYear.Width = 92;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Title.Width = 140;
            // 
            // startDate
            // 
            this.startDate.DataPropertyName = "startDate";
            this.startDate.HeaderText = "Start Date";
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.startDate.Width = 76;
            // 
            // endDate
            // 
            this.endDate.DataPropertyName = "endDate";
            this.endDate.HeaderText = "End Date";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.endDate.Width = 75;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 65;
            // 
            // ClosedBy
            // 
            this.ClosedBy.DataPropertyName = "ClosedBy";
            this.ClosedBy.HeaderText = "Closed By";
            this.ClosedBy.Name = "ClosedBy";
            this.ClosedBy.ReadOnly = true;
            this.ClosedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClosedDate
            // 
            this.ClosedDate.DataPropertyName = "ClosedDate";
            this.ClosedDate.HeaderText = "Closed Date";
            this.ClosedDate.Name = "ClosedDate";
            this.ClosedDate.ReadOnly = true;
            this.ClosedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvFinancialMonth
            // 
            this.dgvFinancialMonth.AllowUserToAddRows = false;
            this.dgvFinancialMonth.AllowUserToDeleteRows = false;
            this.dgvFinancialMonth.AllowUserToResizeRows = false;
            this.dgvFinancialMonth.BackgroundColor = System.Drawing.Color.White;
            this.dgvFinancialMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFinancialMonth.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFinancialMonth.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFinancialMonth.ColumnHeadersHeight = 25;
            this.dgvFinancialMonth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonthID,
            this.monthStartDate,
            this.monthEndDate,
            this.monthStatus,
            this.monthClosedBy,
            this.monthClosedDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFinancialMonth.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFinancialMonth.EnableHeadersVisualStyles = false;
            this.dgvFinancialMonth.Location = new System.Drawing.Point(12, 321);
            this.dgvFinancialMonth.MultiSelect = false;
            this.dgvFinancialMonth.Name = "dgvFinancialMonth";
            this.dgvFinancialMonth.ReadOnly = true;
            this.dgvFinancialMonth.RowHeadersVisible = false;
            this.dgvFinancialMonth.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFinancialMonth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinancialMonth.Size = new System.Drawing.Size(667, 269);
            this.dgvFinancialMonth.TabIndex = 8;
            // 
            // MonthID
            // 
            this.MonthID.DataPropertyName = "MonthID";
            this.MonthID.HeaderText = "Month ID";
            this.MonthID.Name = "MonthID";
            this.MonthID.ReadOnly = true;
            this.MonthID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // monthStartDate
            // 
            this.monthStartDate.DataPropertyName = "monthStartDate";
            this.monthStartDate.HeaderText = "Start Date";
            this.monthStartDate.Name = "monthStartDate";
            this.monthStartDate.ReadOnly = true;
            this.monthStartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monthStartDate.Width = 95;
            // 
            // monthEndDate
            // 
            this.monthEndDate.DataPropertyName = "monthEndDate";
            this.monthEndDate.HeaderText = "End Date";
            this.monthEndDate.Name = "monthEndDate";
            this.monthEndDate.ReadOnly = true;
            this.monthEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monthEndDate.Width = 95;
            // 
            // monthStatus
            // 
            this.monthStatus.DataPropertyName = "monthStatus";
            this.monthStatus.HeaderText = "Status";
            this.monthStatus.Name = "monthStatus";
            this.monthStatus.ReadOnly = true;
            this.monthStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // monthClosedBy
            // 
            this.monthClosedBy.DataPropertyName = "monthClosedBy";
            this.monthClosedBy.HeaderText = "Closed By";
            this.monthClosedBy.Name = "monthClosedBy";
            this.monthClosedBy.ReadOnly = true;
            this.monthClosedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monthClosedBy.Width = 145;
            // 
            // monthClosedDate
            // 
            this.monthClosedDate.DataPropertyName = "monthClosedDate";
            this.monthClosedDate.HeaderText = "Closed Date";
            this.monthClosedDate.Name = "monthClosedDate";
            this.monthClosedDate.ReadOnly = true;
            this.monthClosedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monthClosedDate.Width = 110;
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.lblFinYear.Location = new System.Drawing.Point(5, 11);
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(118, 23);
            this.lblFinYear.TabIndex = 9;
            this.lblFinYear.Text = "Financial Year";
            // 
            // lblFinancialYearMonth
            // 
            this.lblFinancialYearMonth.AutoSize = true;
            this.lblFinancialYearMonth.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblFinancialYearMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.lblFinancialYearMonth.Location = new System.Drawing.Point(9, 295);
            this.lblFinancialYearMonth.Name = "lblFinancialYearMonth";
            this.lblFinancialYearMonth.Size = new System.Drawing.Size(176, 23);
            this.lblFinancialYearMonth.TabIndex = 10;
            this.lblFinancialYearMonth.Text = "Financial Year Month";
            // 
            // btnCloseMonth
            // 
            this.btnCloseMonth.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseMonth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnCloseMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMonth.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnCloseMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseMonth.Location = new System.Drawing.Point(592, 596);
            this.btnCloseMonth.Name = "btnCloseMonth";
            this.btnCloseMonth.Size = new System.Drawing.Size(87, 25);
            this.btnCloseMonth.TabIndex = 14;
            this.btnCloseMonth.Text = "Close Month";
            this.btnCloseMonth.UseVisualStyleBackColor = false;
            this.btnCloseMonth.Click += new System.EventHandler(this.btnCloseMonth_Click);
            // 
            // btnCloseYear
            // 
            this.btnCloseYear.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseYear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnCloseYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnCloseYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseYear.Location = new System.Drawing.Point(589, 227);
            this.btnCloseYear.Name = "btnCloseYear";
            this.btnCloseYear.Size = new System.Drawing.Size(87, 25);
            this.btnCloseYear.TabIndex = 15;
            this.btnCloseYear.Text = "Close Year";
            this.btnCloseYear.UseVisualStyleBackColor = false;
            this.btnCloseYear.Click += new System.EventHandler(this.btnCloseYear_Click);
            // 
            // pnlBottomLine
            // 
            this.pnlBottomLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.pnlBottomLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomLine.Location = new System.Drawing.Point(0, 261);
            this.pnlBottomLine.Name = "pnlBottomLine";
            this.pnlBottomLine.Size = new System.Drawing.Size(683, 2);
            this.pnlBottomLine.TabIndex = 16;
            this.pnlBottomLine.Visible = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlHeader.Controls.Add(this.btnNewFinancialYear);
            this.pnlHeader.Controls.Add(this.pnlBottomLine);
            this.pnlHeader.Controls.Add(this.lblFinYear);
            this.pnlHeader.Controls.Add(this.btnCloseYear);
            this.pnlHeader.Controls.Add(this.dgvFinancialYear);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(3, 29);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(683, 263);
            this.pnlHeader.TabIndex = 17;
            // 
            // btnNewFinancialYear
            // 
            this.btnNewFinancialYear.BackColor = System.Drawing.Color.Transparent;
            this.btnNewFinancialYear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnNewFinancialYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFinancialYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFinancialYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnNewFinancialYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFinancialYear.Location = new System.Drawing.Point(522, 6);
            this.btnNewFinancialYear.Name = "btnNewFinancialYear";
            this.btnNewFinancialYear.Size = new System.Drawing.Size(154, 25);
            this.btnNewFinancialYear.TabIndex = 17;
            this.btnNewFinancialYear.Text = "Add Next Financial year";
            this.btnNewFinancialYear.UseVisualStyleBackColor = false;
            this.btnNewFinancialYear.Click += new System.EventHandler(this.btnNewFinancialYear_Click);
            // 
            // frm_masAccFinancialYear_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 630);
            this.Controls.Add(this.btnCloseMonth);
            this.Controls.Add(this.lblFinancialYearMonth);
            this.Controls.Add(this.dgvFinancialMonth);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frm_masAccFinancialYear_New";
            this.Text = "Financial Year Configuration";
            this.Load += new System.EventHandler(this.frm_accMasFinancialYear_New_Load);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.dgvFinancialMonth, 0);
            this.Controls.SetChildIndex(this.lblFinancialYearMonth, 0);
            this.Controls.SetChildIndex(this.btnCloseMonth, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialMonth)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFinancialYear;
        private System.Windows.Forms.DataGridView dgvFinancialMonth;
        private System.Windows.Forms.Label lblFinYear;
        private System.Windows.Forms.Label lblFinancialYearMonth;
        private System.Windows.Forms.Button btnCloseMonth;
        private System.Windows.Forms.Button btnCloseYear;
        private System.Windows.Forms.Panel pnlBottomLine;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthID;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthClosedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthClosedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosedDate;
        private System.Windows.Forms.Button btnNewFinancialYear;
    }
}