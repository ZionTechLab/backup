namespace Digiteq
{
    partial class frmReportSetting
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
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTerminalName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaperSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrinterName = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.ReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrinterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPaperSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTerminalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.zpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(332, 114);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(62, 25);
            this.btnNew.TabIndex = 465;
            this.btnNew.Text = "   Clear";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.label4);
            this.zpanel4.Controls.Add(this.chkActivate);
            this.zpanel4.Controls.Add(this.label5);
            this.zpanel4.Controls.Add(this.txtTerminalName);
            this.zpanel4.Controls.Add(this.label6);
            this.zpanel4.Controls.Add(this.txtUserName);
            this.zpanel4.Controls.Add(this.label3);
            this.zpanel4.Controls.Add(this.txtPaperSize);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtPrinterName);
            this.zpanel4.Controls.Add(this.lblReportName);
            this.zpanel4.Controls.Add(this.txtReportID);
            this.zpanel4.Location = new System.Drawing.Point(8, 8);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(542, 100);
            this.zpanel4.TabIndex = 464;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(281, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 468;
            this.label4.Text = "Status";
            // 
            // chkActivate
            // 
            this.chkActivate.AutoSize = true;
            this.chkActivate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkActivate.Location = new System.Drawing.Point(378, 68);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(71, 19);
            this.chkActivate.TabIndex = 467;
            this.chkActivate.Text = "Activate";
            this.chkActivate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(281, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 462;
            this.label5.Text = "Terminal Name";
            // 
            // txtTerminalName
            // 
            this.txtTerminalName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTerminalName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminalName.Location = new System.Drawing.Point(378, 37);
            this.txtTerminalName.Name = "txtTerminalName";
            this.txtTerminalName.ReadOnly = true;
            this.txtTerminalName.Size = new System.Drawing.Size(150, 23);
            this.txtTerminalName.TabIndex = 463;
            this.txtTerminalName.DoubleClick += new System.EventHandler(this.txtTerminalName_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(281, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 460;
            this.label6.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(378, 8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(150, 23);
            this.txtUserName.TabIndex = 461;
            this.txtUserName.DoubleClick += new System.EventHandler(this.txtUserName_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 458;
            this.label3.Text = "Paper Size";
            // 
            // txtPaperSize
            // 
            this.txtPaperSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPaperSize.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaperSize.Location = new System.Drawing.Point(96, 66);
            this.txtPaperSize.Name = "txtPaperSize";
            this.txtPaperSize.ReadOnly = true;
            this.txtPaperSize.Size = new System.Drawing.Size(150, 23);
            this.txtPaperSize.TabIndex = 459;
            this.txtPaperSize.DoubleClick += new System.EventHandler(this.txtPaperSize_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 456;
            this.label2.Text = "Printer Name";
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtPrinterName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrinterName.Location = new System.Drawing.Point(96, 37);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.ReadOnly = true;
            this.txtPrinterName.Size = new System.Drawing.Size(150, 23);
            this.txtPrinterName.TabIndex = 457;
            this.txtPrinterName.DoubleClick += new System.EventHandler(this.txtPrinterName_DoubleClick);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReportName.Location = new System.Drawing.Point(10, 11);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(81, 15);
            this.lblReportName.TabIndex = 454;
            this.lblReportName.Text = "Report Name";
            // 
            // txtReportID
            // 
            this.txtReportID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtReportID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportID.Location = new System.Drawing.Point(96, 8);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(150, 23);
            this.txtReportID.TabIndex = 455;
            this.txtReportID.DoubleClick += new System.EventHandler(this.txtFormID_DoubleClick);
            this.txtReportID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormID_KeyDown);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportID,
            this.cPrinterName,
            this.cPaperSize,
            this.cUserName,
            this.cTerminalName,
            this.cActive});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 145);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(542, 340);
            this.dgvDetail.TabIndex = 463;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ReportID
            // 
            this.ReportID.HeaderText = "Report Name";
            this.ReportID.Name = "ReportID";
            this.ReportID.Width = 90;
            // 
            // cPrinterName
            // 
            this.cPrinterName.HeaderText = "Printer Name";
            this.cPrinterName.Name = "cPrinterName";
            this.cPrinterName.Width = 250;
            // 
            // cPaperSize
            // 
            this.cPaperSize.HeaderText = "Paper Size";
            this.cPaperSize.Name = "cPaperSize";
            this.cPaperSize.Width = 90;
            // 
            // cUserName
            // 
            this.cUserName.HeaderText = "User Name";
            this.cUserName.Name = "cUserName";
            this.cUserName.Width = 110;
            // 
            // cTerminalName
            // 
            this.cTerminalName.HeaderText = "Terminal Name";
            this.cTerminalName.Name = "cTerminalName";
            this.cTerminalName.Visible = false;
            this.cTerminalName.Width = 140;
            // 
            // cActive
            // 
            this.cActive.HeaderText = "Active";
            this.cActive.Name = "cActive";
            this.cActive.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Image = global::Digiteq.Properties.Resources.delete;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(475, 114);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "  Delete";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(397, 114);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "  Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frmReportSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(558, 493);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.zpanel4);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReportSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Output Setting";
            this.Load += new System.EventHandler(this.frm_AutoNumber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoFormNumber_KeyDown);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTerminalName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaperSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrinterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrinterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPaperSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTerminalName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cActive;
    }
}