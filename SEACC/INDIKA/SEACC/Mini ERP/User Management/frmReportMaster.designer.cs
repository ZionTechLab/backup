namespace Digiteq
{
    partial class frmReportMaster
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
            this.btnNew = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkDefaultPrinter = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReportCategory = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.chkSetPrinter = new System.Windows.Forms.CheckBox();
            this.chkSetUser = new System.Windows.Forms.CheckBox();
            this.chkSetTerminal = new System.Windows.Forms.CheckBox();
            this.chkSetPaper = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(413, 142);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(62, 25);
            this.btnNew.TabIndex = 465;
            this.btnNew.Text = "   Clear";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkDefaultPrinter);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtReportName);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtReportCategory);
            this.panel4.Controls.Add(this.txtOrder);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.chkActivate);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtReportID);
            this.panel4.Location = new System.Drawing.Point(8, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(382, 128);
            this.panel4.TabIndex = 464;
            // 
            // chkDefaultPrinter
            // 
            this.chkDefaultPrinter.AutoSize = true;
            this.chkDefaultPrinter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDefaultPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDefaultPrinter.Location = new System.Drawing.Point(213, 95);
            this.chkDefaultPrinter.Name = "chkDefaultPrinter";
            this.chkDefaultPrinter.Size = new System.Drawing.Size(156, 19);
            this.chkDefaultPrinter.TabIndex = 483;
            this.chkDefaultPrinter.Text = "Activate Default Printer";
            this.chkDefaultPrinter.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(10, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 482;
            this.label9.Text = "Report Settings";
            // 
            // txtReportName
            // 
            this.txtReportName.BackColor = System.Drawing.SystemColors.Window;
            this.txtReportName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportName.Location = new System.Drawing.Point(109, 36);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(260, 23);
            this.txtReportName.TabIndex = 477;
            this.txtReportName.DoubleClick += new System.EventHandler(this.txtReportName_DoubleClick);
            this.txtReportName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportName_KeyDown);
            this.txtReportName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReportName_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(10, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 478;
            this.label6.Text = "Report Category";
            // 
            // txtReportCategory
            // 
            this.txtReportCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReportCategory.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReportCategory.Location = new System.Drawing.Point(109, 64);
            this.txtReportCategory.Name = "txtReportCategory";
            this.txtReportCategory.Size = new System.Drawing.Size(260, 23);
            this.txtReportCategory.TabIndex = 0;
            this.txtReportCategory.DoubleClick += new System.EventHandler(this.txtReportCategory_DoubleClick);
            this.txtReportCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportCategory_KeyDown);
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOrder.Location = new System.Drawing.Point(290, 7);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(79, 23);
            this.txtOrder.TabIndex = 472;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(219, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 473;
            this.label4.Text = "Sort Order";
            // 
            // chkActivate
            // 
            this.chkActivate.AutoSize = true;
            this.chkActivate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkActivate.Location = new System.Drawing.Point(109, 95);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(71, 19);
            this.chkActivate.TabIndex = 466;
            this.chkActivate.Text = "Activate";
            this.chkActivate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 454;
            this.label1.Text = "Report No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 456;
            this.label3.Text = "Report Name";
            // 
            // txtReportID
            // 
            this.txtReportID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtReportID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportID.Location = new System.Drawing.Point(109, 7);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(100, 23);
            this.txtReportID.TabIndex = 455;
            this.txtReportID.DoubleClick += new System.EventHandler(this.txtReportID_DoubleClick);
            this.txtReportID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportID_KeyDown);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportID,
            this.SortOrder,
            this.ReportName,
            this.ReportCategory,
            this.DisplayName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 173);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(542, 312);
            this.dgvDetail.TabIndex = 463;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Image = global::Digiteq.Properties.Resources.delete;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(338, 142);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "  Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(475, 142);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "  Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // chkSetPrinter
            // 
            this.chkSetPrinter.AutoSize = true;
            this.chkSetPrinter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSetPrinter.Location = new System.Drawing.Point(17, 66);
            this.chkSetPrinter.Name = "chkSetPrinter";
            this.chkSetPrinter.Size = new System.Drawing.Size(107, 19);
            this.chkSetPrinter.TabIndex = 480;
            this.chkSetPrinter.Text = "Enable Printer ";
            this.chkSetPrinter.UseVisualStyleBackColor = true;
            // 
            // chkSetUser
            // 
            this.chkSetUser.AutoSize = true;
            this.chkSetUser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSetUser.Location = new System.Drawing.Point(17, 9);
            this.chkSetUser.Name = "chkSetUser";
            this.chkSetUser.Size = new System.Drawing.Size(90, 19);
            this.chkSetUser.TabIndex = 479;
            this.chkSetUser.Text = "Enable User";
            this.chkSetUser.UseVisualStyleBackColor = true;
            // 
            // chkSetTerminal
            // 
            this.chkSetTerminal.AutoSize = true;
            this.chkSetTerminal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetTerminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSetTerminal.Location = new System.Drawing.Point(17, 38);
            this.chkSetTerminal.Name = "chkSetTerminal";
            this.chkSetTerminal.Size = new System.Drawing.Size(112, 19);
            this.chkSetTerminal.TabIndex = 478;
            this.chkSetTerminal.Text = "Enable Terminal";
            this.chkSetTerminal.UseVisualStyleBackColor = true;
            // 
            // chkSetPaper
            // 
            this.chkSetPaper.AutoSize = true;
            this.chkSetPaper.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetPaper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSetPaper.Location = new System.Drawing.Point(17, 95);
            this.chkSetPaper.Name = "chkSetPaper";
            this.chkSetPaper.Size = new System.Drawing.Size(97, 19);
            this.chkSetPaper.TabIndex = 477;
            this.chkSetPaper.Text = "Enable Paper";
            this.chkSetPaper.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkSetUser);
            this.panel1.Controls.Add(this.chkSetPrinter);
            this.panel1.Controls.Add(this.chkSetPaper);
            this.panel1.Controls.Add(this.chkSetTerminal);
            this.panel1.Location = new System.Drawing.Point(396, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 128);
            this.panel1.TabIndex = 481;
            // 
            // ReportID
            // 
            this.ReportID.DataPropertyName = "ReportID";
            this.ReportID.HeaderText = "Report ID";
            this.ReportID.Name = "ReportID";
            this.ReportID.Width = 105;
            // 
            // SortOrder
            // 
            this.SortOrder.DataPropertyName = "SortOrder";
            this.SortOrder.HeaderText = "Order";
            this.SortOrder.Name = "SortOrder";
            this.SortOrder.Width = 50;
            // 
            // ReportName
            // 
            this.ReportName.DataPropertyName = "ReportName";
            this.ReportName.HeaderText = "Report Name";
            this.ReportName.Name = "ReportName";
            this.ReportName.Width = 225;
            // 
            // ReportCategory
            // 
            this.ReportCategory.DataPropertyName = "ReportCategory";
            this.ReportCategory.HeaderText = "ReportCategory";
            this.ReportCategory.Name = "ReportCategory";
            this.ReportCategory.Width = 158;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Visible = false;
            this.DisplayName.Width = 140;
            // 
            // frmReportMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(558, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReportMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Master";
            this.Load += new System.EventHandler(this.frmReportMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportMaster_KeyDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtReportCategory;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox chkActivate;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDefaultPrinter;
        private System.Windows.Forms.CheckBox chkSetPrinter;
        private System.Windows.Forms.CheckBox chkSetUser;
        private System.Windows.Forms.CheckBox chkSetTerminal;
        private System.Windows.Forms.CheckBox chkSetPaper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
    }
}