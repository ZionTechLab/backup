namespace Digiteq
{
    partial class frm_AlertShedules
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoYear = new System.Windows.Forms.RadioButton();
            this.rdoWeek = new System.Windows.Forms.RadioButton();
            this.rdoMonth = new System.Windows.Forms.RadioButton();
            this.rdoDay = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dtpShedule = new System.Windows.Forms.DateTimePicker();
            this.lblSedTim = new System.Windows.Forms.Label();
            this.lblAlertID = new System.Windows.Forms.Label();
            this.LblAlertname = new System.Windows.Forms.Label();
            this.txtAlertName = new System.Windows.Forms.TextBox();
            this.txtAlertID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.AlertId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheduledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheduledtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdoYear);
            this.panel2.Controls.Add(this.rdoWeek);
            this.panel2.Controls.Add(this.rdoMonth);
            this.panel2.Controls.Add(this.rdoDay);
            this.panel2.Controls.Add(this.chkActive);
            this.panel2.Controls.Add(this.dtpShedule);
            this.panel2.Controls.Add(this.lblSedTim);
            this.panel2.Controls.Add(this.lblAlertID);
            this.panel2.Controls.Add(this.LblAlertname);
            this.panel2.Controls.Add(this.txtAlertName);
            this.panel2.Controls.Add(this.txtAlertID);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 87);
            this.panel2.TabIndex = 1;
            // 
            // rdoYear
            // 
            this.rdoYear.AutoSize = true;
            this.rdoYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoYear.Location = new System.Drawing.Point(431, 38);
            this.rdoYear.Name = "rdoYear";
            this.rdoYear.Size = new System.Drawing.Size(66, 18);
            this.rdoYear.TabIndex = 7;
            this.rdoYear.TabStop = true;
            this.rdoYear.Text = "Is Yearly";
            this.rdoYear.UseVisualStyleBackColor = true;
            this.rdoYear.CheckedChanged += new System.EventHandler(this.rdoYear_CheckedChanged);
            // 
            // rdoWeek
            // 
            this.rdoWeek.AutoSize = true;
            this.rdoWeek.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoWeek.Location = new System.Drawing.Point(271, 38);
            this.rdoWeek.Name = "rdoWeek";
            this.rdoWeek.Size = new System.Drawing.Size(74, 18);
            this.rdoWeek.TabIndex = 7;
            this.rdoWeek.TabStop = true;
            this.rdoWeek.Text = "Is Weekly";
            this.rdoWeek.UseVisualStyleBackColor = true;
            this.rdoWeek.CheckedChanged += new System.EventHandler(this.rdoWeek_CheckedChanged);
            // 
            // rdoMonth
            // 
            this.rdoMonth.AutoSize = true;
            this.rdoMonth.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoMonth.Location = new System.Drawing.Point(350, 38);
            this.rdoMonth.Name = "rdoMonth";
            this.rdoMonth.Size = new System.Drawing.Size(77, 18);
            this.rdoMonth.TabIndex = 7;
            this.rdoMonth.TabStop = true;
            this.rdoMonth.Text = "Is Monthly";
            this.rdoMonth.UseVisualStyleBackColor = true;
            this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
            // 
            // rdoDay
            // 
            this.rdoDay.AutoSize = true;
            this.rdoDay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDay.Location = new System.Drawing.Point(205, 38);
            this.rdoDay.Name = "rdoDay";
            this.rdoDay.Size = new System.Drawing.Size(62, 18);
            this.rdoDay.TabIndex = 7;
            this.rdoDay.TabStop = true;
            this.rdoDay.Text = "Is Daily";
            this.rdoDay.UseVisualStyleBackColor = true;
            this.rdoDay.CheckedChanged += new System.EventHandler(this.rdoDay_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(97, 38);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 6;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // dtpShedule
            // 
            this.dtpShedule.CustomFormat = "MM/dd/yy H:mm:ss ";
            this.dtpShedule.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtpShedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShedule.Location = new System.Drawing.Point(97, 58);
            this.dtpShedule.Name = "dtpShedule";
            this.dtpShedule.ShowUpDown = true;
            this.dtpShedule.Size = new System.Drawing.Size(119, 22);
            this.dtpShedule.TabIndex = 4;
            this.dtpShedule.Value = new System.DateTime(2013, 2, 20, 16, 32, 10, 0);
            // 
            // lblSedTim
            // 
            this.lblSedTim.AutoSize = true;
            this.lblSedTim.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSedTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSedTim.Location = new System.Drawing.Point(7, 62);
            this.lblSedTim.Name = "lblSedTim";
            this.lblSedTim.Size = new System.Drawing.Size(80, 14);
            this.lblSedTim.TabIndex = 0;
            this.lblSedTim.Text = "Sheduled Time";
            // 
            // lblAlertID
            // 
            this.lblAlertID.AutoSize = true;
            this.lblAlertID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAlertID.Location = new System.Drawing.Point(7, 13);
            this.lblAlertID.Name = "lblAlertID";
            this.lblAlertID.Size = new System.Drawing.Size(58, 14);
            this.lblAlertID.TabIndex = 0;
            this.lblAlertID.Text = "Alert Code";
            // 
            // LblAlertname
            // 
            this.LblAlertname.AutoSize = true;
            this.LblAlertname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlertname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LblAlertname.Location = new System.Drawing.Point(7, 39);
            this.LblAlertname.Name = "LblAlertname";
            this.LblAlertname.Size = new System.Drawing.Size(49, 14);
            this.LblAlertname.TabIndex = 2;
            this.LblAlertname.Text = "Is Active";
            // 
            // txtAlertName
            // 
            this.txtAlertName.BackColor = System.Drawing.SystemColors.Control;
            this.txtAlertName.Enabled = false;
            this.txtAlertName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlertName.Location = new System.Drawing.Point(173, 10);
            this.txtAlertName.Name = "txtAlertName";
            this.txtAlertName.Size = new System.Drawing.Size(339, 22);
            this.txtAlertName.TabIndex = 1;
            this.txtAlertName.DoubleClick += new System.EventHandler(this.txtAlertID_DoubleClick);
            this.txtAlertName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAlertID_KeyDown);
            // 
            // txtAlertID
            // 
            this.txtAlertID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAlertID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlertID.Location = new System.Drawing.Point(97, 10);
            this.txtAlertID.Name = "txtAlertID";
            this.txtAlertID.Size = new System.Drawing.Size(70, 22);
            this.txtAlertID.TabIndex = 1;
            this.txtAlertID.DoubleClick += new System.EventHandler(this.txtAlertID_DoubleClick);
            this.txtAlertID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAlertID_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(437, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlertId,
            this.AlertName,
            this.sheduledDate,
            this.sheduledtime});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 132);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(504, 179);
            this.dgvDetail.TabIndex = 7;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAlert_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAlert_CellContentClick);
            // 
            // AlertId
            // 
            this.AlertId.HeaderText = "Alert Code";
            this.AlertId.Name = "AlertId";
            // 
            // AlertName
            // 
            this.AlertName.HeaderText = "Alert Name";
            this.AlertName.Name = "AlertName";
            this.AlertName.Width = 200;
            // 
            // sheduledDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = "r";
            this.sheduledDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.sheduledDate.HeaderText = "sheduled Date";
            this.sheduledDate.Name = "sheduledDate";
            this.sheduledDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sheduledDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sheduledtime
            // 
            dataGridViewCellStyle2.Format = "T";
            dataGridViewCellStyle2.NullValue = null;
            this.sheduledtime.DefaultCellStyle = dataGridViewCellStyle2;
            this.sheduledtime.HeaderText = "sheduled time";
            this.sheduledtime.Name = "sheduledtime";
            this.sheduledtime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sheduledtime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frm_AlertShedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(519, 320);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_AlertShedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert Shedule";
            this.Load += new System.EventHandler(this.frm_Alert_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Alert_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAlertID;
        private System.Windows.Forms.Label LblAlertname;
        private System.Windows.Forms.TextBox txtAlertID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DateTimePicker dtpShedule;
        private System.Windows.Forms.Label lblSedTim;
        private System.Windows.Forms.TextBox txtAlertName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.RadioButton rdoYear;
        private System.Windows.Forms.RadioButton rdoWeek;
        private System.Windows.Forms.RadioButton rdoMonth;
        private System.Windows.Forms.RadioButton rdoDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheduledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheduledtime;
    }
}