namespace SEACC_PTS
{
    partial class frmTimeSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_NoOfDays = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_EstimatedHr = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelActualHr = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.TS_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TS_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimate_Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accumulated_Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TS_Activity_Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TS_Activity_Minutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTSID = new System.Windows.Forms.TextBox();
            this.To = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.dtpActivityHours = new System.Windows.Forms.DateTimePicker();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRem = new System.Windows.Forms.TextBox();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.dtpTSDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucTittleBar1 = new SEACC_PTS.ucTittleBar();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.ucTittleBar1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(901, 41);
            this.panel3.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(9, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(825, 1);
            this.panel5.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(11, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Time Sheet";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_minimize);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(837, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 41);
            this.panel1.TabIndex = 6;
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(112)))), ((int)(((byte)(148)))));
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(112)))), ((int)(((byte)(148)))));
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_minimize.Location = new System.Drawing.Point(4, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 41);
            this.btn_minimize.TabIndex = 49;
            this.btn_minimize.Text = "";
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(112)))), ((int)(((byte)(148)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(112)))), ((int)(((byte)(148)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(34, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 41);
            this.btn_Close.TabIndex = 47;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_NoOfDays,
            this.toolStripStatusLabel_EstimatedHr,
            this.toolStripStatusLabelActualHr});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(901, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_NoOfDays
            // 
            this.toolStripStatusLabel_NoOfDays.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel_NoOfDays.Name = "toolStripStatusLabel_NoOfDays";
            this.toolStripStatusLabel_NoOfDays.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_NoOfDays.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel_EstimatedHr
            // 
            this.toolStripStatusLabel_EstimatedHr.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel_EstimatedHr.Name = "toolStripStatusLabel_EstimatedHr";
            this.toolStripStatusLabel_EstimatedHr.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_EstimatedHr.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelActualHr
            // 
            this.toolStripStatusLabelActualHr.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelActualHr.Name = "toolStripStatusLabelActualHr";
            this.toolStripStatusLabelActualHr.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelActualHr.Text = "toolStripStatusLabel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTasks);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(9, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 346);
            this.panel2.TabIndex = 19;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToResizeColumns = false;
            this.dgvTasks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(182)))), ((int)(((byte)(175)))));
            this.dgvTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TS_Date,
            this.TS_ID,
            this.Task_ID,
            this.Estimate_Hours,
            this.Accumulated_Hours,
            this.TS_Activity_Hours,
            this.TS_Activity_Minutes,
            this.Task,
            this.Remarks});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(81)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.Location = new System.Drawing.Point(0, 35);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(575, 311);
            this.dgvTasks.TabIndex = 17;
            this.dgvTasks.VirtualMode = true;
            this.dgvTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellClick);
            // 
            // TS_Date
            // 
            this.TS_Date.DataPropertyName = "TS_Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.TS_Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.TS_Date.HeaderText = "Date";
            this.TS_Date.Name = "TS_Date";
            this.TS_Date.ReadOnly = true;
            this.TS_Date.Width = 70;
            // 
            // TS_ID
            // 
            this.TS_ID.DataPropertyName = "TS_ID";
            this.TS_ID.HeaderText = "TS_ID";
            this.TS_ID.Name = "TS_ID";
            this.TS_ID.ReadOnly = true;
            this.TS_ID.Visible = false;
            // 
            // Task_ID
            // 
            this.Task_ID.DataPropertyName = "Task_ID";
            this.Task_ID.HeaderText = "#";
            this.Task_ID.Name = "Task_ID";
            this.Task_ID.ReadOnly = true;
            this.Task_ID.Width = 40;
            // 
            // Estimate_Hours
            // 
            this.Estimate_Hours.DataPropertyName = "Estimate_Hours";
            this.Estimate_Hours.HeaderText = "Estim. Hr.";
            this.Estimate_Hours.Name = "Estimate_Hours";
            this.Estimate_Hours.ReadOnly = true;
            this.Estimate_Hours.Width = 42;
            // 
            // Accumulated_Hours
            // 
            this.Accumulated_Hours.DataPropertyName = "Accumulated_Hours";
            this.Accumulated_Hours.HeaderText = "Accum. Hr.";
            this.Accumulated_Hours.Name = "Accumulated_Hours";
            this.Accumulated_Hours.ReadOnly = true;
            this.Accumulated_Hours.Width = 42;
            // 
            // TS_Activity_Hours
            // 
            this.TS_Activity_Hours.DataPropertyName = "TS_Activity_Hours";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TS_Activity_Hours.DefaultCellStyle = dataGridViewCellStyle3;
            this.TS_Activity_Hours.HeaderText = "Utill. Hr.";
            this.TS_Activity_Hours.Name = "TS_Activity_Hours";
            this.TS_Activity_Hours.ReadOnly = true;
            this.TS_Activity_Hours.Width = 42;
            // 
            // TS_Activity_Minutes
            // 
            this.TS_Activity_Minutes.DataPropertyName = "TS_Activity_Minutes";
            this.TS_Activity_Minutes.HeaderText = "TS_Activity_Minutes";
            this.TS_Activity_Minutes.Name = "TS_Activity_Minutes";
            this.TS_Activity_Minutes.ReadOnly = true;
            this.TS_Activity_Minutes.Visible = false;
            // 
            // Task
            // 
            this.Task.DataPropertyName = "Task";
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            this.Task.Width = 200;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 300;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtTSID);
            this.panel6.Controls.Add(this.To);
            this.panel6.Controls.Add(this.dtpFrom);
            this.panel6.Controls.Add(this.dtpTo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(575, 35);
            this.panel6.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "TS Id";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From";
            // 
            // txtTSID
            // 
            this.txtTSID.Location = new System.Drawing.Point(432, 5);
            this.txtTSID.Name = "txtTSID";
            this.txtTSID.ReadOnly = true;
            this.txtTSID.Size = new System.Drawing.Size(100, 22);
            this.txtTSID.TabIndex = 16;
            this.txtTSID.Visible = false;
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Location = new System.Drawing.Point(159, 11);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(18, 13);
            this.To.TabIndex = 11;
            this.To.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(47, 7);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(106, 22);
            this.dtpFrom.TabIndex = 14;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(183, 7);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(107, 22);
            this.dtpTo.TabIndex = 13;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtProgress);
            this.panel4.Controls.Add(this.txtStatus);
            this.panel4.Controls.Add(this.dtpActivityHours);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.txtRem);
            this.panel4.Controls.Add(this.txtTask);
            this.panel4.Controls.Add(this.txtTaskID);
            this.panel4.Controls.Add(this.dtpTSDate);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(590, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(301, 346);
            this.panel4.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Description";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(91, 246);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(200, 22);
            this.txtProgress.TabIndex = 30;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(91, 222);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(200, 22);
            this.txtStatus.TabIndex = 31;
            this.txtStatus.DoubleClick += new System.EventHandler(this.txtStatus_DoubleClick);
            // 
            // dtpActivityHours
            // 
            this.dtpActivityHours.Checked = false;
            this.dtpActivityHours.CustomFormat = "HH:mm";
            this.dtpActivityHours.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpActivityHours.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActivityHours.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActivityHours.Location = new System.Drawing.Point(91, 180);
            this.dtpActivityHours.Name = "dtpActivityHours";
            this.dtpActivityHours.ShowUpDown = true;
            this.dtpActivityHours.Size = new System.Drawing.Size(130, 35);
            this.dtpActivityHours.TabIndex = 23;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(113, 287);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 29;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(194, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Tag = "0";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRem
            // 
            this.txtRem.Location = new System.Drawing.Point(91, 121);
            this.txtRem.Multiline = true;
            this.txtRem.Name = "txtRem";
            this.txtRem.Size = new System.Drawing.Size(200, 53);
            this.txtRem.TabIndex = 27;
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(91, 65);
            this.txtTask.Multiline = true;
            this.txtTask.Name = "txtTask";
            this.txtTask.ReadOnly = true;
            this.txtTask.Size = new System.Drawing.Size(200, 53);
            this.txtTask.TabIndex = 26;
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(91, 39);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.ReadOnly = true;
            this.txtTaskID.Size = new System.Drawing.Size(200, 22);
            this.txtTaskID.TabIndex = 25;
            this.txtTaskID.DoubleClick += new System.EventHandler(this.txtTaskID_DoubleClick);
            this.txtTaskID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaskID_KeyDown);
            // 
            // dtpTSDate
            // 
            this.dtpTSDate.Location = new System.Drawing.Point(91, 13);
            this.dtpTSDate.Name = "dtpTSDate";
            this.dtpTSDate.Size = new System.Drawing.Size(200, 22);
            this.dtpTSDate.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Activity Hours";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Progress";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Remarks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Task Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "TS Date";
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(837, 41);
            this.ucTittleBar1.TabIndex = 6;
            // 
            // frmTimeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 439);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimeSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimeSheet";
            this.Load += new System.EventHandler(this.frmTimeSheet_Load);
            this.SizeChanged += new System.EventHandler(this.frmTimeSheet_SizeChanged);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_NoOfDays;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_EstimatedHr;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelActualHr;
        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn TS_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TS_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimate_Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accumulated_Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TS_Activity_Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TS_Activity_Minutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTSID;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.DateTimePicker dtpActivityHours;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRem;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.DateTimePicker dtpTSDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}