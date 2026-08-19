namespace Digiteq.Transaction_Forms.COM
{
    partial class frm_masComComissionPeriod
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblPeriodClosingData = new System.Windows.Forms.Label();
            this.lblNoOfProcessedReps = new System.Windows.Forms.Label();
            this.txtNoOfProcessedEmp = new System.Windows.Forms.TextBox();
            this.lblPeriodName = new System.Windows.Forms.Label();
            this.txtPeriodName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPeriods = new SEACC_DataGrid();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeriodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPeriodClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPeriodClosed = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(591, 398);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 454;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblPeriodClosingData
            // 
            this.lblPeriodClosingData.AutoSize = true;
            this.lblPeriodClosingData.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodClosingData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPeriodClosingData.Location = new System.Drawing.Point(575, 203);
            this.lblPeriodClosingData.Name = "lblPeriodClosingData";
            this.lblPeriodClosingData.Size = new System.Drawing.Size(163, 14);
            this.lblPeriodClosingData.TabIndex = 453;
            this.lblPeriodClosingData.Text = "Risk Allowance Period Closing...";
            // 
            // lblNoOfProcessedReps
            // 
            this.lblNoOfProcessedReps.AutoSize = true;
            this.lblNoOfProcessedReps.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfProcessedReps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNoOfProcessedReps.Location = new System.Drawing.Point(579, 234);
            this.lblNoOfProcessedReps.Name = "lblNoOfProcessedReps";
            this.lblNoOfProcessedReps.Size = new System.Drawing.Size(121, 14);
            this.lblNoOfProcessedReps.TabIndex = 452;
            this.lblNoOfProcessedReps.Text = "Processed No. Of Reps ";
            // 
            // txtNoOfProcessedEmp
            // 
            this.txtNoOfProcessedEmp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfProcessedEmp.Location = new System.Drawing.Point(706, 230);
            this.txtNoOfProcessedEmp.Name = "txtNoOfProcessedEmp";
            this.txtNoOfProcessedEmp.Size = new System.Drawing.Size(117, 22);
            this.txtNoOfProcessedEmp.TabIndex = 451;
            // 
            // lblPeriodName
            // 
            this.lblPeriodName.AutoSize = true;
            this.lblPeriodName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPeriodName.Location = new System.Drawing.Point(579, 57);
            this.lblPeriodName.Name = "lblPeriodName";
            this.lblPeriodName.Size = new System.Drawing.Size(71, 14);
            this.lblPeriodName.TabIndex = 446;
            this.lblPeriodName.Text = "Period Name";
            // 
            // txtPeriodName
            // 
            this.txtPeriodName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodName.Location = new System.Drawing.Point(667, 53);
            this.txtPeriodName.Name = "txtPeriodName";
            this.txtPeriodName.Size = new System.Drawing.Size(156, 22);
            this.txtPeriodName.TabIndex = 445;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(758, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 442;
            this.btnCancel.Text = "     Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(675, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 441;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPeriods
            // 
            this.dgvPeriods.AllowUserToAddRows = false;
            this.dgvPeriods.AllowUserToDeleteRows = false;
            this.dgvPeriods.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvPeriods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPeriods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPeriods.ColumnHeadersHeight = 27;
            this.dgvPeriods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.DateFrom,
            this.DateTo,
            this.PeriodName,
            this.IsPeriodClosed});
            this.dgvPeriods.EnableHeadersVisualStyles = false;
            this.dgvPeriods.Location = new System.Drawing.Point(9, 36);
            this.dgvPeriods.MultiSelect = false;
            this.dgvPeriods.Name = "dgvPeriods";
            this.dgvPeriods.ReadOnly = true;
            this.dgvPeriods.RowHeadersVisible = false;
            this.dgvPeriods.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriods.Size = new System.Drawing.Size(560, 392);
            this.dgvPeriods.TabIndex = 440;
            this.dgvPeriods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriods_CellContentClick);
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.LineNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.LineNo.HeaderText = "Line No";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 75;
            // 
            // DateFrom
            // 
            this.DateFrom.DataPropertyName = "DateFrom";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateFrom.DefaultCellStyle = dataGridViewCellStyle7;
            this.DateFrom.HeaderText = "Date From";
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ReadOnly = true;
            // 
            // DateTo
            // 
            this.DateTo.DataPropertyName = "DateTo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateTo.DefaultCellStyle = dataGridViewCellStyle8;
            this.DateTo.HeaderText = "Date To";
            this.DateTo.Name = "DateTo";
            this.DateTo.ReadOnly = true;
            // 
            // PeriodName
            // 
            this.PeriodName.DataPropertyName = "PeriodName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.PeriodName.DefaultCellStyle = dataGridViewCellStyle9;
            this.PeriodName.HeaderText = "Period Name";
            this.PeriodName.Name = "PeriodName";
            this.PeriodName.ReadOnly = true;
            this.PeriodName.Width = 170;
            // 
            // IsPeriodClosed
            // 
            this.IsPeriodClosed.DataPropertyName = "IsPeriodClosed";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IsPeriodClosed.DefaultCellStyle = dataGridViewCellStyle10;
            this.IsPeriodClosed.HeaderText = "Is Period Closed";
            this.IsPeriodClosed.Name = "IsPeriodClosed";
            this.IsPeriodClosed.ReadOnly = true;
            this.IsPeriodClosed.Width = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(576, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 14);
            this.label1.TabIndex = 455;
            this.label1.Text = "_________________________________________";
            // 
            // btnPeriodClosed
            // 
            this.btnPeriodClosed.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPeriodClosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnPeriodClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeriodClosed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodClosed.Image = global::Digiteq.Properties.Resources.accept;
            this.btnPeriodClosed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPeriodClosed.Location = new System.Drawing.Point(706, 269);
            this.btnPeriodClosed.Name = "btnPeriodClosed";
            this.btnPeriodClosed.Size = new System.Drawing.Size(117, 25);
            this.btnPeriodClosed.TabIndex = 456;
            this.btnPeriodClosed.Text = "    Period Closing...";
            this.btnPeriodClosed.UseVisualStyleBackColor = true;
            this.btnPeriodClosed.Click += new System.EventHandler(this.btnPeriodClosed_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(667, 91);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(115, 22);
            this.dtpFromDate.TabIndex = 457;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDateFrom.Location = new System.Drawing.Point(579, 97);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(60, 14);
            this.lblDateFrom.TabIndex = 458;
            this.lblDateFrom.Text = "Date From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(667, 131);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(115, 22);
            this.dtpToDate.TabIndex = 459;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDateTo.Location = new System.Drawing.Point(579, 137);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(45, 14);
            this.lblDateTo.TabIndex = 460;
            this.lblDateTo.Text = "Date To";
            // 
            // frm_masComComissionPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 438);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.btnPeriodClosed);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblPeriodClosingData);
            this.Controls.Add(this.lblNoOfProcessedReps);
            this.Controls.Add(this.txtNoOfProcessedEmp);
            this.Controls.Add(this.lblPeriodName);
            this.Controls.Add(this.txtPeriodName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPeriods);
            this.Controls.Add(this.label1);
            this.Name = "frm_masComComissionPeriod";
            this.Text = "Sales Rep Risk Allowance Periods";
            this.Load += new System.EventHandler(this.frm_masComComissionPeriod_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvPeriods, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtPeriodName, 0);
            this.Controls.SetChildIndex(this.lblPeriodName, 0);
            this.Controls.SetChildIndex(this.txtNoOfProcessedEmp, 0);
            this.Controls.SetChildIndex(this.lblNoOfProcessedReps, 0);
            this.Controls.SetChildIndex(this.lblPeriodClosingData, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnPeriodClosed, 0);
            this.Controls.SetChildIndex(this.lblDateFrom, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.lblDateTo, 0);
            this.Controls.SetChildIndex(this.dtpToDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblPeriodClosingData;
        private System.Windows.Forms.Label lblNoOfProcessedReps;
        private System.Windows.Forms.TextBox txtNoOfProcessedEmp;
        private System.Windows.Forms.Label lblPeriodName;
        private System.Windows.Forms.TextBox txtPeriodName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvPeriods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPeriodClosed;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeriodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPeriodClosed;
    }
}