namespace Digiteq
{
    partial class frm_rpt_AdminRegiser
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
            this.rdoPrintLog = new System.Windows.Forms.RadioButton();
            this.rdoFormaster = new System.Windows.Forms.RadioButton();
            this.rdoFormMaster = new System.Windows.Forms.RadioButton();
            this.rdoReportMaster = new System.Windows.Forms.RadioButton();
            this.rdoUserMaster = new System.Windows.Forms.RadioButton();
            this.Z2 = new System.Windows.Forms.Panel();
            this.txtReprtCatagory = new System.Windows.Forms.TextBox();
            this.lblReprtCatagory = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtModuleName = new System.Windows.Forms.TextBox();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.txtDocument = new System.Windows.Forms.TextBox();
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
            this.btnPrint.Location = new System.Drawing.Point(500, 276);
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
            this.zpanel2.Controls.Add(this.rdoPrintLog);
            this.zpanel2.Controls.Add(this.rdoFormaster);
            this.zpanel2.Controls.Add(this.rdoFormMaster);
            this.zpanel2.Controls.Add(this.rdoReportMaster);
            this.zpanel2.Controls.Add(this.rdoUserMaster);
            this.zpanel2.Location = new System.Drawing.Point(3, 3);
            this.zpanel2.Name = "zpanel2";
            this.zpanel2.Size = new System.Drawing.Size(572, 120);
            this.zpanel2.TabIndex = 0;
            // 
            // rdoPrintLog
            // 
            this.rdoPrintLog.AutoSize = true;
            this.rdoPrintLog.BackColor = System.Drawing.Color.Transparent;
            this.rdoPrintLog.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPrintLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPrintLog.Location = new System.Drawing.Point(200, 19);
            this.rdoPrintLog.Name = "rdoPrintLog";
            this.rdoPrintLog.Size = new System.Drawing.Size(68, 18);
            this.rdoPrintLog.TabIndex = 5;
            this.rdoPrintLog.TabStop = true;
            this.rdoPrintLog.Text = "Print Log";
            this.rdoPrintLog.UseVisualStyleBackColor = false;
            this.rdoPrintLog.CheckedChanged += new System.EventHandler(this.rdoPrintLog_CheckedChanged);
            // 
            // rdoFormaster
            // 
            this.rdoFormaster.AutoSize = true;
            this.rdoFormaster.BackColor = System.Drawing.Color.Transparent;
            this.rdoFormaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFormaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoFormaster.Location = new System.Drawing.Point(20, 43);
            this.rdoFormaster.Name = "rdoFormaster";
            this.rdoFormaster.Size = new System.Drawing.Size(92, 18);
            this.rdoFormaster.TabIndex = 4;
            this.rdoFormaster.TabStop = true;
            this.rdoFormaster.Text = "Form Master ";
            this.rdoFormaster.UseVisualStyleBackColor = false;
            // 
            // rdoFormMaster
            // 
            this.rdoFormMaster.AutoSize = true;
            this.rdoFormMaster.BackColor = System.Drawing.Color.Transparent;
            this.rdoFormMaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFormMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoFormMaster.Location = new System.Drawing.Point(19, 43);
            this.rdoFormMaster.Name = "rdoFormMaster";
            this.rdoFormMaster.Size = new System.Drawing.Size(92, 18);
            this.rdoFormMaster.TabIndex = 4;
            this.rdoFormMaster.TabStop = true;
            this.rdoFormMaster.Text = "Form Master ";
            this.rdoFormMaster.UseVisualStyleBackColor = false;
            // 
            // rdoReportMaster
            // 
            this.rdoReportMaster.AutoSize = true;
            this.rdoReportMaster.BackColor = System.Drawing.Color.Transparent;
            this.rdoReportMaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReportMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReportMaster.Location = new System.Drawing.Point(20, 67);
            this.rdoReportMaster.Name = "rdoReportMaster";
            this.rdoReportMaster.Size = new System.Drawing.Size(99, 18);
            this.rdoReportMaster.TabIndex = 3;
            this.rdoReportMaster.TabStop = true;
            this.rdoReportMaster.Text = "Report Master ";
            this.rdoReportMaster.UseVisualStyleBackColor = false;
            this.rdoReportMaster.CheckedChanged += new System.EventHandler(this.rdoReportMaster_CheckedChanged);
            // 
            // rdoUserMaster
            // 
            this.rdoUserMaster.AutoSize = true;
            this.rdoUserMaster.BackColor = System.Drawing.Color.Transparent;
            this.rdoUserMaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoUserMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoUserMaster.Location = new System.Drawing.Point(20, 19);
            this.rdoUserMaster.Name = "rdoUserMaster";
            this.rdoUserMaster.Size = new System.Drawing.Size(122, 18);
            this.rdoUserMaster.TabIndex = 0;
            this.rdoUserMaster.TabStop = true;
            this.rdoUserMaster.Text = "User Master Report";
            this.rdoUserMaster.UseVisualStyleBackColor = false;
            this.rdoUserMaster.CheckedChanged += new System.EventHandler(this.rdoUserMaster_CheckedChanged);
            // 
            // Z2
            // 
            this.Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Z2.Controls.Add(this.txtUserID);
            this.Z2.Controls.Add(this.lblUserName);
            this.Z2.Controls.Add(this.txtDocument);
            this.Z2.Controls.Add(this.lblDocument);
            this.Z2.Controls.Add(this.txtReprtCatagory);
            this.Z2.Controls.Add(this.lblReprtCatagory);
            this.Z2.Controls.Add(this.lblGroupName);
            this.Z2.Controls.Add(this.txtGroupName);
            this.Z2.Controls.Add(this.txtModuleName);
            this.Z2.Controls.Add(this.lblModuleName);
            this.Z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Z2.Location = new System.Drawing.Point(3, 129);
            this.Z2.Name = "Z2";
            this.Z2.Size = new System.Drawing.Size(572, 95);
            this.Z2.TabIndex = 475;
            // 
            // txtReprtCatagory
            // 
            this.txtReprtCatagory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtReprtCatagory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReprtCatagory.Location = new System.Drawing.Point(350, 37);
            this.txtReprtCatagory.Name = "txtReprtCatagory";
            this.txtReprtCatagory.ReadOnly = true;
            this.txtReprtCatagory.Size = new System.Drawing.Size(211, 22);
            this.txtReprtCatagory.TabIndex = 470;
            this.txtReprtCatagory.DoubleClick += new System.EventHandler(this.txtReprtCatagory_DoubleClick);
            this.txtReprtCatagory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReprtCatagory_KeyDown);
            // 
            // lblReprtCatagory
            // 
            this.lblReprtCatagory.AutoSize = true;
            this.lblReprtCatagory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReprtCatagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReprtCatagory.Location = new System.Drawing.Point(261, 41);
            this.lblReprtCatagory.Name = "lblReprtCatagory";
            this.lblReprtCatagory.Size = new System.Drawing.Size(87, 14);
            this.lblReprtCatagory.TabIndex = 469;
            this.lblReprtCatagory.Text = "Report Catagory";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGroupName.Location = new System.Drawing.Point(8, 13);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(70, 14);
            this.lblGroupName.TabIndex = 468;
            this.lblGroupName.Text = "Group Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtGroupName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(82, 9);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(164, 22);
            this.txtGroupName.TabIndex = 467;
            this.txtGroupName.DoubleClick += new System.EventHandler(this.txtGroupName_DoubleClick);
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
            // 
            // txtModuleName
            // 
            this.txtModuleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtModuleName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModuleName.Location = new System.Drawing.Point(350, 9);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.ReadOnly = true;
            this.txtModuleName.Size = new System.Drawing.Size(211, 22);
            this.txtModuleName.TabIndex = 464;
            this.txtModuleName.Text = "Asanka Jayasuriya";
            this.txtModuleName.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            this.txtModuleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblModuleName.Location = new System.Drawing.Point(261, 13);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(77, 14);
            this.lblModuleName.TabIndex = 463;
            this.lblModuleName.Text = "Module Name";
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
            this.z1.Location = new System.Drawing.Point(3, 233);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(572, 38);
            this.z1.TabIndex = 476;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(417, 276);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 477;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(82, 37);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(164, 22);
            this.txtUserID.TabIndex = 479;
            this.txtUserID.Text = "Asanka Jayasuriya";
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.DoubleClick += new System.EventHandler(this.txtUserID_DoubleClick);
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUserName.Location = new System.Drawing.Point(9, 41);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 14);
            this.lblUserName.TabIndex = 478;
            this.lblUserName.Text = "User Name";
            this.lblUserName.Click += new System.EventHandler(this.lblNewCustomer_Click);
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDocument.Location = new System.Drawing.Point(9, 69);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(67, 14);
            this.lblDocument.TabIndex = 480;
            this.lblDocument.Text = "Document #";
            // 
            // txtDocument
            // 
            this.txtDocument.BackColor = System.Drawing.SystemColors.Window;
            this.txtDocument.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocument.Location = new System.Drawing.Point(82, 65);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(164, 22);
            this.txtDocument.TabIndex = 481;
            // 
            // frm_rpt_AdminRegiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(579, 304);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.Z2);
            this.Controls.Add(this.zpanel2);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_AdminRegiser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Master ";
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
        private System.Windows.Forms.RadioButton rdoUserMaster;
        private System.Windows.Forms.Panel Z2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtModuleName;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.RadioButton rdoReportMaster;
        private System.Windows.Forms.TextBox txtReprtCatagory;
        private System.Windows.Forms.Label lblReprtCatagory;
        private System.Windows.Forms.RadioButton rdoFormMaster;
        private System.Windows.Forms.RadioButton rdoFormaster;
        private System.Windows.Forms.RadioButton rdoPrintLog;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.TextBox txtDocument;

    }
}