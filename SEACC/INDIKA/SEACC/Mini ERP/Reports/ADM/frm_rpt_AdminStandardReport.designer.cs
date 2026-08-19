namespace Digiteq
{
    partial class frm_rpt_AdminStandardReport
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.zpanel2 = new System.Windows.Forms.Panel();
            this.rdoCancelledTransactions = new System.Windows.Forms.RadioButton();
            this.rdoReportPermissionReportWise = new System.Windows.Forms.RadioButton();
            this.rdoReportPermissionUserWise = new System.Windows.Forms.RadioButton();
            this.rdoPermissionFormWise = new System.Windows.Forms.RadioButton();
            this.rdoPermissionUserwise = new System.Windows.Forms.RadioButton();
            this.Z2 = new System.Windows.Forms.Panel();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblReportName = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.lblFormName = new System.Windows.Forms.Label();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.zpanel2.SuspendLayout();
            this.Z2.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(500, 263);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 474;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // zpanel2
            // 
            this.zpanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
            this.zpanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel2.Controls.Add(this.rdoCancelledTransactions);
            this.zpanel2.Controls.Add(this.rdoReportPermissionReportWise);
            this.zpanel2.Controls.Add(this.rdoReportPermissionUserWise);
            this.zpanel2.Controls.Add(this.rdoPermissionFormWise);
            this.zpanel2.Controls.Add(this.rdoPermissionUserwise);
            this.zpanel2.Location = new System.Drawing.Point(3, 6);
            this.zpanel2.Name = "zpanel2";
            this.zpanel2.Size = new System.Drawing.Size(572, 101);
            this.zpanel2.TabIndex = 0;
            // 
            // rdoCancelledTransactions
            // 
            this.rdoCancelledTransactions.AutoSize = true;
            this.rdoCancelledTransactions.BackColor = System.Drawing.Color.Transparent;
            this.rdoCancelledTransactions.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCancelledTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCancelledTransactions.Location = new System.Drawing.Point(20, 58);
            this.rdoCancelledTransactions.Name = "rdoCancelledTransactions";
            this.rdoCancelledTransactions.Size = new System.Drawing.Size(133, 18);
            this.rdoCancelledTransactions.TabIndex = 11;
            this.rdoCancelledTransactions.TabStop = true;
            this.rdoCancelledTransactions.Text = "Canceled Transactions";
            this.rdoCancelledTransactions.UseVisualStyleBackColor = false;
            // 
            // rdoReportPermissionReportWise
            // 
            this.rdoReportPermissionReportWise.AutoSize = true;
            this.rdoReportPermissionReportWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoReportPermissionReportWise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReportPermissionReportWise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReportPermissionReportWise.Location = new System.Drawing.Point(346, 34);
            this.rdoReportPermissionReportWise.Name = "rdoReportPermissionReportWise";
            this.rdoReportPermissionReportWise.Size = new System.Drawing.Size(188, 18);
            this.rdoReportPermissionReportWise.TabIndex = 10;
            this.rdoReportPermissionReportWise.TabStop = true;
            this.rdoReportPermissionReportWise.Text = "Report Permission (Report-Wise)";
            this.rdoReportPermissionReportWise.UseVisualStyleBackColor = false;
            this.rdoReportPermissionReportWise.CheckedChanged += new System.EventHandler(this.rdoReportPermissionReportWise_CheckedChanged);
            // 
            // rdoReportPermissionUserWise
            // 
            this.rdoReportPermissionUserWise.AutoSize = true;
            this.rdoReportPermissionUserWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoReportPermissionUserWise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReportPermissionUserWise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReportPermissionUserWise.Location = new System.Drawing.Point(346, 8);
            this.rdoReportPermissionUserWise.Name = "rdoReportPermissionUserWise";
            this.rdoReportPermissionUserWise.Size = new System.Drawing.Size(178, 18);
            this.rdoReportPermissionUserWise.TabIndex = 9;
            this.rdoReportPermissionUserWise.TabStop = true;
            this.rdoReportPermissionUserWise.Text = "Report Permission (User-Wise)";
            this.rdoReportPermissionUserWise.UseVisualStyleBackColor = false;
            this.rdoReportPermissionUserWise.CheckedChanged += new System.EventHandler(this.rdoReportPermissionUserWise_CheckedChanged);
            // 
            // rdoPermissionFormWise
            // 
            this.rdoPermissionFormWise.AutoSize = true;
            this.rdoPermissionFormWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoPermissionFormWise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPermissionFormWise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPermissionFormWise.Location = new System.Drawing.Point(20, 34);
            this.rdoPermissionFormWise.Name = "rdoPermissionFormWise";
            this.rdoPermissionFormWise.Size = new System.Drawing.Size(174, 18);
            this.rdoPermissionFormWise.TabIndex = 8;
            this.rdoPermissionFormWise.TabStop = true;
            this.rdoPermissionFormWise.Text = "Form Permission (Form-Wise)";
            this.rdoPermissionFormWise.UseVisualStyleBackColor = false;
            this.rdoPermissionFormWise.CheckedChanged += new System.EventHandler(this.rdoPermissionFormWise_CheckedChanged);
            // 
            // rdoPermissionUserwise
            // 
            this.rdoPermissionUserwise.AutoSize = true;
            this.rdoPermissionUserwise.BackColor = System.Drawing.Color.Transparent;
            this.rdoPermissionUserwise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPermissionUserwise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPermissionUserwise.Location = new System.Drawing.Point(20, 8);
            this.rdoPermissionUserwise.Name = "rdoPermissionUserwise";
            this.rdoPermissionUserwise.Size = new System.Drawing.Size(171, 18);
            this.rdoPermissionUserwise.TabIndex = 7;
            this.rdoPermissionUserwise.TabStop = true;
            this.rdoPermissionUserwise.Text = "Form Permission (User-Wise)";
            this.rdoPermissionUserwise.UseVisualStyleBackColor = false;
            this.rdoPermissionUserwise.CheckedChanged += new System.EventHandler(this.rdoPermissionUserwise_CheckedChanged);
            // 
            // Z2
            // 
            this.Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Z2.Controls.Add(this.cmbModule);
            this.Z2.Controls.Add(this.txtBranch);
            this.Z2.Controls.Add(this.lblBranch);
            this.Z2.Controls.Add(this.lblModule);
            this.Z2.Controls.Add(this.lblReportName);
            this.Z2.Controls.Add(this.txtReportName);
            this.Z2.Controls.Add(this.lblFormName);
            this.Z2.Controls.Add(this.txtFormName);
            this.Z2.Controls.Add(this.txtUserName);
            this.Z2.Controls.Add(this.lblUserName);
            this.Z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Z2.Location = new System.Drawing.Point(3, 113);
            this.Z2.Name = "Z2";
            this.Z2.Size = new System.Drawing.Size(572, 99);
            this.Z2.TabIndex = 475;
            // 
            // cmbModule
            // 
            this.cmbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModule.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Location = new System.Drawing.Point(82, 33);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(164, 22);
            this.cmbModule.TabIndex = 583;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(82, 61);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(164, 22);
            this.txtBranch.TabIndex = 581;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(8, 64);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 582;
            this.lblBranch.Text = "Branch";
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblModule.Location = new System.Drawing.Point(5, 35);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(77, 14);
            this.lblModule.TabIndex = 474;
            this.lblModule.Text = "Module Name";
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReportName.Location = new System.Drawing.Point(269, 35);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(73, 14);
            this.lblReportName.TabIndex = 472;
            this.lblReportName.Text = "Report Name";
            // 
            // txtReportName
            // 
            this.txtReportName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReportName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportName.Location = new System.Drawing.Point(346, 32);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.ReadOnly = true;
            this.txtReportName.Size = new System.Drawing.Size(211, 22);
            this.txtReportName.TabIndex = 471;
            this.txtReportName.DoubleClick += new System.EventHandler(this.txtReportName_DoubleClick);
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFormName.Location = new System.Drawing.Point(269, 8);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(66, 14);
            this.lblFormName.TabIndex = 466;
            this.lblFormName.Text = "Form Name";
            // 
            // txtFormName
            // 
            this.txtFormName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFormName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormName.Location = new System.Drawing.Point(346, 5);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.ReadOnly = true;
            this.txtFormName.Size = new System.Drawing.Size(211, 22);
            this.txtFormName.TabIndex = 465;
            this.txtFormName.TextChanged += new System.EventHandler(this.txtFormName_TextChanged);
            this.txtFormName.DoubleClick += new System.EventHandler(this.txtFormName_DoubleClick);
            this.txtFormName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormName_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(82, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(164, 22);
            this.txtUserName.TabIndex = 462;
            this.txtUserName.Text = "Asanka Jayasuriya";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.DoubleClick += new System.EventHandler(this.txtUserName_DoubleClick);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUserName.Location = new System.Drawing.Point(8, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 14);
            this.lblUserName.TabIndex = 461;
            this.lblUserName.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(97, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(368, 8);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(279, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Period To :";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.dtpFrom);
            this.z1.Controls.Add(this.dtpTo);
            this.z1.Controls.Add(this.label2);
            this.z1.Location = new System.Drawing.Point(3, 218);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(572, 38);
            this.z1.TabIndex = 476;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(417, 263);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 477;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_rpt_AdminStandardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(579, 296);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.Z2);
            this.Controls.Add(this.zpanel2);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_AdminStandardReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standard Report";
            this.Load += new System.EventHandler(this.frm_rpt_MasterReport_Load);
            this.zpanel2.ResumeLayout(false);
            this.zpanel2.PerformLayout();
            this.Z2.ResumeLayout(false);
            this.Z2.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel zpanel2;
        private System.Windows.Forms.Panel Z2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.RadioButton rdoReportPermissionReportWise;
        private System.Windows.Forms.RadioButton rdoReportPermissionUserWise;
        private System.Windows.Forms.RadioButton rdoPermissionFormWise;
        private System.Windows.Forms.RadioButton rdoPermissionUserwise;
        private System.Windows.Forms.RadioButton rdoCancelledTransactions;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbModule;
    }
}