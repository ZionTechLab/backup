namespace Digiteq
{
    partial class frm_accAPNSettlement_ReportViewer
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtAPNNo = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkAPNNo = new System.Windows.Forms.CheckBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreditorID = new System.Windows.Forms.TextBox();
            this.chkCreditorDetails = new System.Windows.Forms.CheckBox();
            this.chkPaymentMode = new System.Windows.Forms.CheckBox();
            this.btnRemoveContact2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 47);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(813, 447);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblItemName);
            this.panel2.Controls.Add(this.cmbPaymentMode);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.txtAPNNo);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.chkAPNNo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCreditorID);
            this.panel2.Controls.Add(this.chkCreditorDetails);
            this.panel2.Controls.Add(this.chkPaymentMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(813, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 447);
            this.panel2.TabIndex = 5;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemName.Location = new System.Drawing.Point(12, 8);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(50, 19);
            this.lblItemName.TabIndex = 476;
            this.lblItemName.Text = "Filters";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.BackColor = System.Drawing.Color.White;
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "All APN",
            "Settled APN",
            "Unsettled APN"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(15, 120);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(210, 21);
            this.cmbPaymentMode.TabIndex = 475;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Digiteq.Properties.Resources.add_page;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(69, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "   Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Period From :";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(150, 335);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Refresh";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(150, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "Export";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // txtAPNNo
            // 
            this.txtAPNNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtAPNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPNNo.Location = new System.Drawing.Point(15, 171);
            this.txtAPNNo.Name = "txtAPNNo";
            this.txtAPNNo.Size = new System.Drawing.Size(210, 22);
            this.txtAPNNo.TabIndex = 3;
            this.txtAPNNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAPNNo_KeyUp);
            this.txtAPNNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAPNNo_MouseDoubleClick);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(15, 300);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(210, 20);
            this.dtpTo.TabIndex = 10;
            // 
            // chkAPNNo
            // 
            this.chkAPNNo.AutoSize = true;
            this.chkAPNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAPNNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkAPNNo.Location = new System.Drawing.Point(15, 147);
            this.chkAPNNo.Name = "chkAPNNo";
            this.chkAPNNo.Size = new System.Drawing.Size(64, 18);
            this.chkAPNNo.TabIndex = 472;
            this.chkAPNNo.Text = "APN No";
            this.chkAPNNo.UseVisualStyleBackColor = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(15, 245);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(210, 20);
            this.dtpFrom.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Period To :";
            // 
            // txtCreditorID
            // 
            this.txtCreditorID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditorID.Location = new System.Drawing.Point(15, 67);
            this.txtCreditorID.Name = "txtCreditorID";
            this.txtCreditorID.Size = new System.Drawing.Size(210, 22);
            this.txtCreditorID.TabIndex = 0;
            this.txtCreditorID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCreditorID_KeyUp);
            this.txtCreditorID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCreditorID_MouseDoubleClick);
            // 
            // chkCreditorDetails
            // 
            this.chkCreditorDetails.AutoSize = true;
            this.chkCreditorDetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreditorDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkCreditorDetails.Location = new System.Drawing.Point(15, 43);
            this.chkCreditorDetails.Name = "chkCreditorDetails";
            this.chkCreditorDetails.Size = new System.Drawing.Size(103, 18);
            this.chkCreditorDetails.TabIndex = 472;
            this.chkCreditorDetails.Text = "Creditor Details";
            this.chkCreditorDetails.UseVisualStyleBackColor = true;
            // 
            // chkPaymentMode
            // 
            this.chkPaymentMode.AutoSize = true;
            this.chkPaymentMode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPaymentMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkPaymentMode.Location = new System.Drawing.Point(15, 95);
            this.chkPaymentMode.Name = "chkPaymentMode";
            this.chkPaymentMode.Size = new System.Drawing.Size(101, 18);
            this.chkPaymentMode.TabIndex = 474;
            this.chkPaymentMode.Text = "Payment Mode";
            this.chkPaymentMode.UseVisualStyleBackColor = true;
            this.chkPaymentMode.CheckedChanged += new System.EventHandler(this.chkPaymentMode_CheckedChanged);
            // 
            // btnRemoveContact2
            // 
            this.btnRemoveContact2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveContact2.FlatAppearance.BorderSize = 0;
            this.btnRemoveContact2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemoveContact2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveContact2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveContact2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRemoveContact2.Location = new System.Drawing.Point(1020, 0);
            this.btnRemoveContact2.Name = "btnRemoveContact2";
            this.btnRemoveContact2.Size = new System.Drawing.Size(34, 47);
            this.btnRemoveContact2.TabIndex = 587;
            this.btnRemoveContact2.Text = "";
            this.btnRemoveContact2.UseVisualStyleBackColor = true;
            this.btnRemoveContact2.Click += new System.EventHandler(this.btnRemoveContact2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnRemoveContact2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 47);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(12, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 42);
            this.label3.TabIndex = 477;
            this.label3.Text = "Report Viewer";
            // 
            // frm_accAPNSettlement_ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 494);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_accAPNSettlement_ReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.frm_accAPNSettlement_ReportViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_bpsChequeRegister_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtAPNNo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkAPNNo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreditorID;
        private System.Windows.Forms.CheckBox chkCreditorDetails;
        private System.Windows.Forms.CheckBox chkPaymentMode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnRemoveContact2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}