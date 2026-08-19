namespace SEACC_PTS
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnTaskmaster = new System.Windows.Forms.Button();
            this.btnTimeSheet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_TimeSheetReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.ucUserIndicator1 = new SEACC_PTS.ucUserIndicator();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTaskmaster
            // 
            this.btnTaskmaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskmaster.Location = new System.Drawing.Point(10, 104);
            this.btnTaskmaster.Name = "btnTaskmaster";
            this.btnTaskmaster.Size = new System.Drawing.Size(160, 23);
            this.btnTaskmaster.TabIndex = 0;
            this.btnTaskmaster.Text = "Task Management";
            this.btnTaskmaster.UseVisualStyleBackColor = true;
            this.btnTaskmaster.Click += new System.EventHandler(this.btnTaskmaster_Click);
            // 
            // btnTimeSheet
            // 
            this.btnTimeSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeSheet.Location = new System.Drawing.Point(10, 133);
            this.btnTimeSheet.Name = "btnTimeSheet";
            this.btnTimeSheet.Size = new System.Drawing.Size(160, 23);
            this.btnTimeSheet.TabIndex = 1;
            this.btnTimeSheet.Text = "Time Sheet";
            this.btnTimeSheet.UseVisualStyleBackColor = true;
            this.btnTimeSheet.Click += new System.EventHandler(this.btnTimeSheet_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time Management";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(10, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 1);
            this.panel1.TabIndex = 5;
            // 
            // btn_TimeSheetReport
            // 
            this.btn_TimeSheetReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TimeSheetReport.Location = new System.Drawing.Point(10, 162);
            this.btn_TimeSheetReport.Name = "btn_TimeSheetReport";
            this.btn_TimeSheetReport.Size = new System.Drawing.Size(160, 23);
            this.btn_TimeSheetReport.TabIndex = 9;
            this.btn_TimeSheetReport.Text = "Reports";
            this.btn_TimeSheetReport.UseVisualStyleBackColor = true;
            this.btn_TimeSheetReport.Click += new System.EventHandler(this.btn_TimeSheetReport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(260, 299);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(27, 23);
            this.btnBackup.TabIndex = 12;
            this.btnBackup.Text = "button2";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task_ID,
            this.Task});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(9, 428);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(161, 141);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Task_ID
            // 
            this.Task_ID.DataPropertyName = "Task_ID";
            dataGridViewCellStyle1.NullValue = null;
            this.Task_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.Task_ID.HeaderText = "Task_ID";
            this.Task_ID.Name = "Task_ID";
            this.Task_ID.ReadOnly = true;
            this.Task_ID.Width = 35;
            // 
            // Task
            // 
            this.Task.DataPropertyName = "Task";
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            this.Task.Width = 120;
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeColumns = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            this.dgvSummary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.ColumnHeadersVisible = false;
            this.dgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.Status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSummary.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSummary.Location = new System.Drawing.Point(9, 191);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.Size = new System.Drawing.Size(161, 202);
            this.dgvSummary.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(48, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ucUserIndicator1
            // 
            this.ucUserIndicator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ucUserIndicator1.DisplayName = "User :";
            this.ucUserIndicator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ucUserIndicator1.Location = new System.Drawing.Point(12, 12);
            this.ucUserIndicator1.Name = "ucUserIndicator1";
            this.ucUserIndicator1.Padding = new System.Windows.Forms.Padding(5);
            this.ucUserIndicator1.Picture = null;
            this.ucUserIndicator1.Size = new System.Drawing.Size(159, 58);
            this.ucUserIndicator1.TabIndex = 13;
            this.ucUserIndicator1.UserName = "label1";
            this.ucUserIndicator1.Selection += new SEACC_PTS.ucUserIndicator.ResultString(this.ucUserIndicator1_Selection);
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 40;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 120;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(183, 581);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgvSummary);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ucUserIndicator1);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_TimeSheetReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimeSheet);
            this.Controls.Add(this.btnTaskmaster);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(584, 456);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTaskmaster;
        private System.Windows.Forms.Button btnTimeSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_TimeSheetReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBackup;
        private ucUserIndicator ucUserIndicator1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}