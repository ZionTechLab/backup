namespace Digiteq
{
    partial class frm_masAccCreateFinancialYear_New
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
            this.lblFinYear = new System.Windows.Forms.Label();
            this.dgvFinancialYear = new SEACC_DataGrid();
            this.FinancialYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewFinancialYear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.lblFinYear.Location = new System.Drawing.Point(9, 36);
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(118, 23);
            this.lblFinYear.TabIndex = 11;
            this.lblFinYear.Text = "Financial Year";
            // 
            // dgvFinancialYear
            // 
            this.dgvFinancialYear.AllowUserToAddRows = false;
            this.dgvFinancialYear.AllowUserToDeleteRows = false;
            this.dgvFinancialYear.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvFinancialYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFinancialYear.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFinancialYear.EnableHeadersVisualStyles = false;
            this.dgvFinancialYear.Location = new System.Drawing.Point(9, 62);
            this.dgvFinancialYear.MultiSelect = false;
            this.dgvFinancialYear.Name = "dgvFinancialYear";
            this.dgvFinancialYear.ReadOnly = true;
            this.dgvFinancialYear.RowHeadersVisible = false;
            this.dgvFinancialYear.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFinancialYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinancialYear.Size = new System.Drawing.Size(473, 401);
            this.dgvFinancialYear.TabIndex = 10;
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
            this.ClosedBy.Visible = false;
            // 
            // ClosedDate
            // 
            this.ClosedDate.DataPropertyName = "ClosedDate";
            this.ClosedDate.HeaderText = "Closed Date";
            this.ClosedDate.Name = "ClosedDate";
            this.ClosedDate.ReadOnly = true;
            this.ClosedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClosedDate.Visible = false;
            // 
            // btnNewFinancialYear
            // 
            this.btnNewFinancialYear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnNewFinancialYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFinancialYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFinancialYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.btnNewFinancialYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFinancialYear.Location = new System.Drawing.Point(328, 469);
            this.btnNewFinancialYear.Name = "btnNewFinancialYear";
            this.btnNewFinancialYear.Size = new System.Drawing.Size(154, 25);
            this.btnNewFinancialYear.TabIndex = 16;
            this.btnNewFinancialYear.Text = "Add Next Financial year";
            this.btnNewFinancialYear.UseVisualStyleBackColor = true;
            this.btnNewFinancialYear.Click += new System.EventHandler(this.btnNewFinancialYear_Click);
            // 
            // frm_masAccCreateFinancialYear_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(493, 513);
            this.Controls.Add(this.btnNewFinancialYear);
            this.Controls.Add(this.lblFinYear);
            this.Controls.Add(this.dgvFinancialYear);
            this.Name = "frm_masAccCreateFinancialYear_New";
            this.Text = "Create Financial Year";
            this.ThemeColor = System.Drawing.Color.SlateGray;
            this.Load += new System.EventHandler(this.frm_masAccCreateFinancialYear_New_Load);
            this.Controls.SetChildIndex(this.dgvFinancialYear, 0);
            this.Controls.SetChildIndex(this.lblFinYear, 0);
            this.Controls.SetChildIndex(this.btnNewFinancialYear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinancialYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFinYear;
        private SEACC_DataGrid dgvFinancialYear;
        private System.Windows.Forms.Button btnNewFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosedDate;
    }
}