namespace SEACC_PTS
{
    partial class frmReports
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.rbtTimeSheet = new System.Windows.Forms.RadioButton();
            this.rbtTask = new System.Windows.Forms.RadioButton();
            this.rbtTaskRegister = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTaskType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAssignedTo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpReportedDate = new System.Windows.Forms.DateTimePicker();
            this.rbtTimeSheetRegister = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ucTittleBar1 = new SEACC_PTS.ucTittleBar();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button1.Location = new System.Drawing.Point(195, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(104, 37);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(166, 23);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(104, 65);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(166, 23);
            this.dtpToDate.TabIndex = 2;
            // 
            // rbtTimeSheet
            // 
            this.rbtTimeSheet.AutoSize = true;
            this.rbtTimeSheet.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.rbtTimeSheet.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtTimeSheet.Location = new System.Drawing.Point(15, 18);
            this.rbtTimeSheet.Name = "rbtTimeSheet";
            this.rbtTimeSheet.Size = new System.Drawing.Size(84, 19);
            this.rbtTimeSheet.TabIndex = 7;
            this.rbtTimeSheet.TabStop = true;
            this.rbtTimeSheet.Text = "Time Sheet";
            this.rbtTimeSheet.UseVisualStyleBackColor = true;
            this.rbtTimeSheet.CheckedChanged += new System.EventHandler(this.rbtTimeSheet_CheckedChanged);
            // 
            // rbtTask
            // 
            this.rbtTask.AutoSize = true;
            this.rbtTask.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.rbtTask.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtTask.Location = new System.Drawing.Point(161, 18);
            this.rbtTask.Name = "rbtTask";
            this.rbtTask.Size = new System.Drawing.Size(48, 19);
            this.rbtTask.TabIndex = 8;
            this.rbtTask.TabStop = true;
            this.rbtTask.Text = "Task";
            this.rbtTask.UseVisualStyleBackColor = true;
            this.rbtTask.CheckedChanged += new System.EventHandler(this.rbtTask_CheckedChanged);
            // 
            // rbtTaskRegister
            // 
            this.rbtTaskRegister.AutoSize = true;
            this.rbtTaskRegister.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.rbtTaskRegister.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtTaskRegister.Location = new System.Drawing.Point(161, 41);
            this.rbtTaskRegister.Name = "rbtTaskRegister";
            this.rbtTaskRegister.Size = new System.Drawing.Size(93, 19);
            this.rbtTaskRegister.TabIndex = 9;
            this.rbtTaskRegister.TabStop = true;
            this.rbtTaskRegister.Text = "Task Register";
            this.rbtTaskRegister.UseVisualStyleBackColor = true;
            this.rbtTaskRegister.CheckedChanged += new System.EventHandler(this.rbtTaskRegister_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtCustomer.Location = new System.Drawing.Point(103, 132);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(166, 23);
            this.txtCustomer.TabIndex = 11;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtProduct.Location = new System.Drawing.Point(103, 159);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(166, 23);
            this.txtProduct.TabIndex = 13;
            this.txtProduct.DoubleClick += new System.EventHandler(this.txtProduct_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Product";
            // 
            // txtTaskType
            // 
            this.txtTaskType.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtTaskType.Location = new System.Drawing.Point(103, 186);
            this.txtTaskType.Name = "txtTaskType";
            this.txtTaskType.Size = new System.Drawing.Size(166, 23);
            this.txtTaskType.TabIndex = 15;
            this.txtTaskType.DoubleClick += new System.EventHandler(this.txtTaskType_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Task Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label6.Location = new System.Drawing.Point(12, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Reported Date";
            this.label6.Visible = false;
            // 
            // txtPriority
            // 
            this.txtPriority.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtPriority.Location = new System.Drawing.Point(103, 213);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(166, 23);
            this.txtPriority.TabIndex = 19;
            this.txtPriority.DoubleClick += new System.EventHandler(this.txtPriority_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label7.Location = new System.Drawing.Point(12, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Priority";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtStatus.Location = new System.Drawing.Point(103, 239);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(166, 23);
            this.txtStatus.TabIndex = 21;
            this.txtStatus.DoubleClick += new System.EventHandler(this.txtStatus_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Status";
            // 
            // txtAssignedTo
            // 
            this.txtAssignedTo.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.txtAssignedTo.Location = new System.Drawing.Point(103, 266);
            this.txtAssignedTo.Name = "txtAssignedTo";
            this.txtAssignedTo.Size = new System.Drawing.Size(166, 23);
            this.txtAssignedTo.TabIndex = 23;
            this.txtAssignedTo.DoubleClick += new System.EventHandler(this.txtAssignedTo_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label9.Location = new System.Drawing.Point(12, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Assigned To";
            // 
            // dtpReportedDate
            // 
            this.dtpReportedDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpReportedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportedDate.Location = new System.Drawing.Point(103, 294);
            this.dtpReportedDate.Name = "dtpReportedDate";
            this.dtpReportedDate.Size = new System.Drawing.Size(166, 23);
            this.dtpReportedDate.TabIndex = 24;
            this.dtpReportedDate.Visible = false;
            // 
            // rbtTimeSheetRegister
            // 
            this.rbtTimeSheetRegister.AutoSize = true;
            this.rbtTimeSheetRegister.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.rbtTimeSheetRegister.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbtTimeSheetRegister.Location = new System.Drawing.Point(15, 41);
            this.rbtTimeSheetRegister.Name = "rbtTimeSheetRegister";
            this.rbtTimeSheetRegister.Size = new System.Drawing.Size(129, 19);
            this.rbtTimeSheetRegister.TabIndex = 25;
            this.rbtTimeSheetRegister.TabStop = true;
            this.rbtTimeSheetRegister.Text = "Time Sheet Register";
            this.rbtTimeSheetRegister.UseVisualStyleBackColor = true;
            this.rbtTimeSheetRegister.CheckedChanged += new System.EventHandler(this.rbtTimeSheetRegister_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnClear.Location = new System.Drawing.Point(114, 103);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.ucTittleBar1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 41);
            this.panel3.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(7, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Reports";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_minimize);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(215, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 41);
            this.panel1.TabIndex = 6;
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(116)))));
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(116)))));
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
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(116)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(116)))));
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 1);
            this.panel5.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(15, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 1);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label10.Location = new System.Drawing.Point(13, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Date Period";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.rbtTimeSheet);
            this.panel4.Controls.Add(this.rbtTask);
            this.panel4.Controls.Add(this.rbtTaskRegister);
            this.panel4.Controls.Add(this.rbtTimeSheetRegister);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 42);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 74);
            this.panel4.TabIndex = 29;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.btnClear);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.dtpFromDate);
            this.panel6.Controls.Add(this.dtpToDate);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(1, 329);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(279, 141);
            this.panel6.TabIndex = 30;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(215, 41);
            this.ucTittleBar1.TabIndex = 6;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(281, 471);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dtpReportedDate);
            this.Controls.Add(this.txtAssignedTo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTaskType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.RadioButton rbtTimeSheet;
        private System.Windows.Forms.RadioButton rbtTask;
        private System.Windows.Forms.RadioButton rbtTaskRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTaskType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAssignedTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpReportedDate;
        private System.Windows.Forms.RadioButton rbtTimeSheetRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
    }
}