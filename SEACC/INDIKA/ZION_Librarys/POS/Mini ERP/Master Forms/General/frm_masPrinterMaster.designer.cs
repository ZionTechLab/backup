namespace Digiteq
{
    partial class frm_masPrinterMaster
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.printerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultPrinter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrinterPort = new System.Windows.Forms.ComboBox();
            this.txtPrinterName = new System.Windows.Forms.ComboBox();
            this.labPrinterID = new System.Windows.Forms.Label();
            this.chkDefaultPrinter = new System.Windows.Forms.CheckBox();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblPrinterPort = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtPrinterID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.printerID,
            this.printerName,
            this.printerPort,
            this.remark,
            this.defaultPrinter});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 156);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(427, 244);
            this.dgvDetail.TabIndex = 4;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // printerID
            // 
            this.printerID.HeaderText = "Printer ID";
            this.printerID.Name = "printerID";
            this.printerID.Width = 90;
            // 
            // printerName
            // 
            this.printerName.HeaderText = "PrinterName";
            this.printerName.Name = "printerName";
            this.printerName.Width = 250;
            // 
            // printerPort
            // 
            this.printerPort.HeaderText = "Printer Port";
            this.printerPort.Name = "printerPort";
            this.printerPort.Width = 84;
            // 
            // remark
            // 
            this.remark.HeaderText = "Remark";
            this.remark.Name = "remark";
            this.remark.Visible = false;
            this.remark.Width = 80;
            // 
            // defaultPrinter
            // 
            this.defaultPrinter.HeaderText = "Default Printer";
            this.defaultPrinter.Name = "defaultPrinter";
            this.defaultPrinter.Visible = false;
            this.defaultPrinter.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(282, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(205, 125);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(359, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPrinterPort);
            this.panel1.Controls.Add(this.txtPrinterName);
            this.panel1.Controls.Add(this.labPrinterID);
            this.panel1.Controls.Add(this.chkDefaultPrinter);
            this.panel1.Controls.Add(this.lblPrinterName);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.lblPrinterPort);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.txtPrinterID);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 111);
            this.panel1.TabIndex = 0;
            // 
            // txtPrinterPort
            // 
            this.txtPrinterPort.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrinterPort.FormattingEnabled = true;
            this.txtPrinterPort.Items.AddRange(new object[] {
            "SELECT PORT"});
            this.txtPrinterPort.Location = new System.Drawing.Point(335, 7);
            this.txtPrinterPort.Name = "txtPrinterPort";
            this.txtPrinterPort.Size = new System.Drawing.Size(79, 22);
            this.txtPrinterPort.TabIndex = 10;
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrinterName.FormattingEnabled = true;
            this.txtPrinterName.Items.AddRange(new object[] {
            "PLEASE SELECT THE PRINTER"});
            this.txtPrinterName.Location = new System.Drawing.Point(86, 34);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.Size = new System.Drawing.Size(328, 22);
            this.txtPrinterName.TabIndex = 9;
            // 
            // labPrinterID
            // 
            this.labPrinterID.AutoSize = true;
            this.labPrinterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.labPrinterID.Location = new System.Drawing.Point(12, 10);
            this.labPrinterID.Name = "labPrinterID";
            this.labPrinterID.Size = new System.Drawing.Size(67, 14);
            this.labPrinterID.TabIndex = 0;
            this.labPrinterID.Text = "Printer Code";
            // 
            // chkDefaultPrinter
            // 
            this.chkDefaultPrinter.AutoSize = true;
            this.chkDefaultPrinter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkDefaultPrinter.Location = new System.Drawing.Point(221, 10);
            this.chkDefaultPrinter.Name = "chkDefaultPrinter";
            this.chkDefaultPrinter.Size = new System.Drawing.Size(40, 18);
            this.chkDefaultPrinter.TabIndex = 8;
            this.chkDefaultPrinter.Text = "DF";
            this.chkDefaultPrinter.UseVisualStyleBackColor = true;
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrinterName.Location = new System.Drawing.Point(12, 36);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(70, 14);
            this.lblPrinterName.TabIndex = 2;
            this.lblPrinterName.Text = "PrinterName";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtRemark.Location = new System.Drawing.Point(86, 60);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(328, 42);
            this.txtRemark.TabIndex = 7;
            // 
            // lblPrinterPort
            // 
            this.lblPrinterPort.AutoSize = true;
            this.lblPrinterPort.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrinterPort.Location = new System.Drawing.Point(302, 10);
            this.lblPrinterPort.Name = "lblPrinterPort";
            this.lblPrinterPort.Size = new System.Drawing.Size(27, 14);
            this.lblPrinterPort.TabIndex = 4;
            this.lblPrinterPort.Text = "Port";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemark.Location = new System.Drawing.Point(12, 63);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(46, 14);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "Remark";
            // 
            // txtPrinterID
            // 
            this.txtPrinterID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtPrinterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrinterID.Location = new System.Drawing.Point(86, 7);
            this.txtPrinterID.Name = "txtPrinterID";
            this.txtPrinterID.Size = new System.Drawing.Size(129, 22);
            this.txtPrinterID.TabIndex = 1;
            this.txtPrinterID.DoubleClick += new System.EventHandler(this.txtPrinterID_DoubleClick);
            this.txtPrinterID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrinterID_KeyDown);
            // 
            // frm_masPrinterMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 409);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_masPrinterMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Master";
            this.Load += new System.EventHandler(this.frm_masPrinterMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_masPrinterMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labPrinterID;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPrinterID;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblPrinterPort;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.CheckBox chkDefaultPrinter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultPrinter;
        private System.Windows.Forms.ComboBox txtPrinterName;
        private System.Windows.Forms.ComboBox txtPrinterPort;
    }
}