namespace Digiteq
{
    partial class frm_accAPNSettlementViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkSettlementMode = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbSettlementMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtAPNNo = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkAPNNo = new System.Windows.Forms.CheckBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreditorID = new System.Windows.Forms.TextBox();
            this.chkCreditorID = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.lblCredit = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMainBody = new System.Windows.Forms.Panel();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APNNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APNDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlMainBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeight = 30;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.APNNo,
            this.BillNo,
            this.APNDate,
            this.CreditorName,
            this.sType,
            this.PVNo,
            this.PVDate,
            this.Credit,
            this.Debit,
            this.Balance,
            this.Status});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.Silver;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(910, 535);
            this.dgvMain.TabIndex = 3;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.chkSettlementMode);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.cmbSettlementMode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.txtAPNNo);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.chkAPNNo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCreditorID);
            this.panel2.Controls.Add(this.chkCreditorID);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(915, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 535);
            this.panel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 489;
            this.label4.Text = "Date Range";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Location = new System.Drawing.Point(0, 320);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(210, 1);
            this.panel5.TabIndex = 486;
            // 
            // chkSettlementMode
            // 
            this.chkSettlementMode.AutoSize = true;
            this.chkSettlementMode.BackColor = System.Drawing.Color.White;
            this.chkSettlementMode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSettlementMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.chkSettlementMode.Location = new System.Drawing.Point(9, 268);
            this.chkSettlementMode.Name = "chkSettlementMode";
            this.chkSettlementMode.Size = new System.Drawing.Size(112, 18);
            this.chkSettlementMode.TabIndex = 479;
            this.chkSettlementMode.Text = "Settlement Mode";
            this.chkSettlementMode.UseVisualStyleBackColor = false;
            this.chkSettlementMode.CheckedChanged += new System.EventHandler(this.chkSettlementMode_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(110, 492);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 28);
            this.btnPrint.TabIndex = 477;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.DimGray;
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(9, 328);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 28);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbSettlementMode
            // 
            this.cmbSettlementMode.BackColor = System.Drawing.Color.White;
            this.cmbSettlementMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettlementMode.FormattingEnabled = true;
            this.cmbSettlementMode.Items.AddRange(new object[] {
            "All APN",
            "Settled APN",
            "Unsettled APN"});
            this.cmbSettlementMode.Location = new System.Drawing.Point(5, 291);
            this.cmbSettlementMode.Name = "cmbSettlementMode";
            this.cmbSettlementMode.Size = new System.Drawing.Size(188, 23);
            this.cmbSettlementMode.TabIndex = 475;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Period From :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(110, 328);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DimGray;
            this.btnExport.Image = global::Digiteq.Properties.Resources.export_icon_17;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(9, 492);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(91, 28);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtAPNNo
            // 
            this.txtAPNNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtAPNNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPNNo.Location = new System.Drawing.Point(5, 240);
            this.txtAPNNo.Name = "txtAPNNo";
            this.txtAPNNo.Size = new System.Drawing.Size(188, 23);
            this.txtAPNNo.TabIndex = 3;
            this.txtAPNNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAPNNo_KeyUp);
            this.txtAPNNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtAPNNo_MouseDoubleClick);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpTo.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(9, 101);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(188, 23);
            this.dtpTo.TabIndex = 10;
            // 
            // chkAPNNo
            // 
            this.chkAPNNo.AutoSize = true;
            this.chkAPNNo.BackColor = System.Drawing.Color.White;
            this.chkAPNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkAPNNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.chkAPNNo.Location = new System.Drawing.Point(9, 220);
            this.chkAPNNo.Name = "chkAPNNo";
            this.chkAPNNo.Size = new System.Drawing.Size(64, 18);
            this.chkAPNNo.TabIndex = 472;
            this.chkAPNNo.Text = "APN No";
            this.chkAPNNo.UseVisualStyleBackColor = false;
            this.chkAPNNo.CheckedChanged += new System.EventHandler(this.chkAPNNo_CheckedChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFrom.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(9, 55);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(188, 23);
            this.dtpFrom.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Period To :";
            // 
            // txtCreditorID
            // 
            this.txtCreditorID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditorID.Location = new System.Drawing.Point(5, 190);
            this.txtCreditorID.Name = "txtCreditorID";
            this.txtCreditorID.Size = new System.Drawing.Size(188, 23);
            this.txtCreditorID.TabIndex = 0;
            this.txtCreditorID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCreditorID_KeyUp);
            this.txtCreditorID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCreditorID_MouseDoubleClick);
            // 
            // chkCreditorID
            // 
            this.chkCreditorID.AutoSize = true;
            this.chkCreditorID.BackColor = System.Drawing.Color.White;
            this.chkCreditorID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkCreditorID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.chkCreditorID.Location = new System.Drawing.Point(9, 168);
            this.chkCreditorID.Name = "chkCreditorID";
            this.chkCreditorID.Size = new System.Drawing.Size(103, 18);
            this.chkCreditorID.TabIndex = 472;
            this.chkCreditorID.Text = "Creditor Details";
            this.chkCreditorID.UseVisualStyleBackColor = false;
            this.chkCreditorID.CheckedChanged += new System.EventHandler(this.chkCreditorID_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(-1, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(210, 28);
            this.panel6.TabIndex = 487;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 490;
            this.label5.Text = "Filter";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightGray;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(-1, -1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(210, 28);
            this.panel8.TabIndex = 487;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 1);
            this.panel1.TabIndex = 485;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.Controls.Add(this.lblAction);
            this.pnlFooter.Controls.Add(this.lblDebit);
            this.pnlFooter.Controls.Add(this.lblCredit);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 545);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1130, 23);
            this.pnlFooter.TabIndex = 5;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblAction.Location = new System.Drawing.Point(10, 2);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(0, 15);
            this.lblAction.TabIndex = 588;
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.BackColor = System.Drawing.Color.LightGray;
            this.lblDebit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDebit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit.ForeColor = System.Drawing.Color.Black;
            this.lblDebit.Location = new System.Drawing.Point(635, 3);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(70, 14);
            this.lblDebit.TabIndex = 589;
            this.lblDebit.Text = "1,000,000.00";
            this.lblDebit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDebit.Visible = false;
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.BackColor = System.Drawing.Color.LightGray;
            this.lblCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCredit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit.ForeColor = System.Drawing.Color.Black;
            this.lblCredit.Location = new System.Drawing.Point(553, 3);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(70, 14);
            this.lblCredit.TabIndex = 489;
            this.lblCredit.Text = "1,000,000.00";
            this.lblCredit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCredit.Visible = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.SteelBlue;
            this.panel9.Controls.Add(this.dgvMain);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(5, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(910, 535);
            this.panel9.TabIndex = 488;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.panel9);
            this.pnlBody.Controls.Add(this.panel2);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBody.Size = new System.Drawing.Size(1130, 545);
            this.pnlBody.TabIndex = 489;
            // 
            // pnlMainBody
            // 
            this.pnlMainBody.Controls.Add(this.pnlBody);
            this.pnlMainBody.Controls.Add(this.pnlFooter);
            this.pnlMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBody.Location = new System.Drawing.Point(3, 29);
            this.pnlMainBody.Name = "pnlMainBody";
            this.pnlMainBody.Size = new System.Drawing.Size(1130, 568);
            this.pnlMainBody.TabIndex = 4;
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            this.LineNo.HeaderText = "#";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LineNo.Width = 30;
            // 
            // APNNo
            // 
            this.APNNo.DataPropertyName = "APNNo";
            this.APNNo.HeaderText = "APN No";
            this.APNNo.Name = "APNNo";
            this.APNNo.ReadOnly = true;
            this.APNNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.APNNo.Width = 70;
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "Bill No";
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            this.BillNo.Width = 70;
            // 
            // APNDate
            // 
            this.APNDate.DataPropertyName = "APNDate";
            dataGridViewCellStyle2.NullValue = null;
            this.APNDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.APNDate.HeaderText = "APN Date";
            this.APNDate.Name = "APNDate";
            this.APNDate.ReadOnly = true;
            this.APNDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.APNDate.Width = 75;
            // 
            // CreditorName
            // 
            this.CreditorName.DataPropertyName = "CreditorName";
            this.CreditorName.HeaderText = "Creditor Details";
            this.CreditorName.Name = "CreditorName";
            this.CreditorName.ReadOnly = true;
            this.CreditorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CreditorName.Width = 150;
            // 
            // sType
            // 
            this.sType.DataPropertyName = "sType";
            this.sType.HeaderText = "Doc. Name";
            this.sType.Name = "sType";
            this.sType.ReadOnly = true;
            this.sType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sType.Width = 55;
            // 
            // PVNo
            // 
            this.PVNo.DataPropertyName = "PVNo";
            this.PVNo.HeaderText = "PV/SDBN No";
            this.PVNo.Name = "PVNo";
            this.PVNo.ReadOnly = true;
            this.PVNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PVNo.Width = 80;
            // 
            // PVDate
            // 
            this.PVDate.DataPropertyName = "PVDate";
            dataGridViewCellStyle3.NullValue = null;
            this.PVDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.PVDate.HeaderText = "PV/SDBN Date";
            this.PVDate.Name = "PVDate";
            this.PVDate.ReadOnly = true;
            this.PVDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PVDate.Width = 75;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle4.NullValue = "-";
            this.Credit.DefaultCellStyle = dataGridViewCellStyle4;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Credit.Width = 75;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle5.NullValue = "-";
            this.Debit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Debit.Width = 75;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle6.NullValue = "-";
            this.Balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Balance.Width = 75;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 60;
            // 
            // frm_accAPNSettlementViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1136, 600);
            this.Controls.Add(this.pnlMainBody);
            this.KeyPreview = true;
            this.Name = "frm_accAPNSettlementViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APN Settlement";
            this.Load += new System.EventHandler(this.frm_bpsChequeRegister_Load);
            this.Controls.SetChildIndex(this.pnlMainBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlMainBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbSettlementMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtAPNNo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkAPNNo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreditorID;
        private System.Windows.Forms.CheckBox chkCreditorID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkSettlementMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlMainBody;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn APNNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn APNDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PVNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}