namespace Express.UI.Inquiry
{
    partial class ShipmentHeld
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.cmb_agency = new System.Windows.Forms.ComboBox();
            this.lbl_Agency = new System.Windows.Forms.Label();
            this.lbl_company = new System.Windows.Forms.Label();
            this.dteUpto = new System.Windows.Forms.DateTimePicker();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.cmdGateway = new System.Windows.Forms.ComboBox();
            this.btnRetrive = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkGateway = new System.Windows.Forms.CheckBox();
            this.chkStation = new System.Windows.Forms.CheckBox();
            this.rdSummery = new System.Windows.Forms.RadioButton();
            this.rdDetail = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.txtMthan10 = new System.Windows.Forms.TextBox();
            this.txtDay7 = new System.Windows.Forms.TextBox();
            this.txtDay6 = new System.Windows.Forms.TextBox();
            this.txtDay5 = new System.Windows.Forms.TextBox();
            this.txtDay4 = new System.Windows.Forms.TextBox();
            this.txtDay3 = new System.Windows.Forms.TextBox();
            this.txtDay2 = new System.Windows.Forms.TextBox();
            this.txtDay1 = new System.Windows.Forms.TextBox();
            this.grvInqShipment = new System.Windows.Forms.DataGridView();
            this.clGatway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDay10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgInqShipWork = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvInqShipment)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(76, 40);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(186, 22);
            this.txtCompany.TabIndex = 33;
            // 
            // cmb_agency
            // 
            this.cmb_agency.DisplayMember = "AgncyName";
            this.cmb_agency.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_agency.FormattingEnabled = true;
            this.cmb_agency.Location = new System.Drawing.Point(76, 18);
            this.cmb_agency.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_agency.Name = "cmb_agency";
            this.cmb_agency.Size = new System.Drawing.Size(186, 21);
            this.cmb_agency.TabIndex = 32;
            this.cmb_agency.ValueMember = "AgncyCode";
            this.cmb_agency.SelectedValueChanged += new System.EventHandler(this.cmb_agency_SelectedValueChanged);
            // 
            // lbl_Agency
            // 
            this.lbl_Agency.AutoSize = true;
            this.lbl_Agency.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Agency.Location = new System.Drawing.Point(20, 21);
            this.lbl_Agency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Agency.Name = "lbl_Agency";
            this.lbl_Agency.Size = new System.Drawing.Size(52, 13);
            this.lbl_Agency.TabIndex = 31;
            this.lbl_Agency.Text = "Agency :";
            // 
            // lbl_company
            // 
            this.lbl_company.AutoSize = true;
            this.lbl_company.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_company.Location = new System.Drawing.Point(9, 43);
            this.lbl_company.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_company.Name = "lbl_company";
            this.lbl_company.Size = new System.Drawing.Size(63, 13);
            this.lbl_company.TabIndex = 30;
            this.lbl_company.Text = "Comapny :";
            // 
            // dteUpto
            // 
            this.dteUpto.CustomFormat = "dd-MMM-yyyy";
            this.dteUpto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteUpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteUpto.Location = new System.Drawing.Point(76, 19);
            this.dteUpto.Name = "dteUpto";
            this.dteUpto.Size = new System.Drawing.Size(105, 22);
            this.dteUpto.TabIndex = 57;
            this.dteUpto.ValueChanged += new System.EventHandler(this.dteUpto_ValueChanged);
            // 
            // cmbStation
            // 
            this.cmbStation.DisplayMember = "StationN";
            this.cmbStation.Enabled = false;
            this.cmbStation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(76, 64);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(152, 21);
            this.cmbStation.TabIndex = 61;
            this.cmbStation.ValueMember = "StationID";
            // 
            // cmdGateway
            // 
            this.cmdGateway.DisplayMember = "GatewayN";
            this.cmdGateway.Enabled = false;
            this.cmdGateway.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGateway.FormattingEnabled = true;
            this.cmdGateway.Location = new System.Drawing.Point(76, 42);
            this.cmdGateway.Name = "cmdGateway";
            this.cmdGateway.Size = new System.Drawing.Size(152, 21);
            this.cmdGateway.TabIndex = 60;
            this.cmdGateway.ValueMember = "GatewayID";
            // 
            // btnRetrive
            // 
            this.btnRetrive.BackColor = System.Drawing.SystemColors.Control;
            this.btnRetrive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrive.Location = new System.Drawing.Point(12, 467);
            this.btnRetrive.Name = "btnRetrive";
            this.btnRetrive.Size = new System.Drawing.Size(75, 39);
            this.btnRetrive.TabIndex = 62;
            this.btnRetrive.Text = "Retrieve";
            this.btnRetrive.UseVisualStyleBackColor = false;
            this.btnRetrive.Click += new System.EventHandler(this.btnRetrive_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(91, 467);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 39);
            this.btnPrint.TabIndex = 63;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkGateway
            // 
            this.chkGateway.AutoSize = true;
            this.chkGateway.Location = new System.Drawing.Point(230, 44);
            this.chkGateway.Name = "chkGateway";
            this.chkGateway.Size = new System.Drawing.Size(40, 17);
            this.chkGateway.TabIndex = 64;
            this.chkGateway.Text = "All";
            this.chkGateway.UseVisualStyleBackColor = true;
            this.chkGateway.CheckedChanged += new System.EventHandler(this.chkGateway_CheckedChanged);
            // 
            // chkStation
            // 
            this.chkStation.AutoSize = true;
            this.chkStation.Location = new System.Drawing.Point(230, 66);
            this.chkStation.Name = "chkStation";
            this.chkStation.Size = new System.Drawing.Size(40, 17);
            this.chkStation.TabIndex = 65;
            this.chkStation.Text = "All";
            this.chkStation.UseVisualStyleBackColor = true;
            this.chkStation.CheckedChanged += new System.EventHandler(this.chkStation_CheckedChanged);
            // 
            // rdSummery
            // 
            this.rdSummery.AutoSize = true;
            this.rdSummery.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSummery.Location = new System.Drawing.Point(6, 19);
            this.rdSummery.Name = "rdSummery";
            this.rdSummery.Size = new System.Drawing.Size(74, 17);
            this.rdSummery.TabIndex = 66;
            this.rdSummery.TabStop = true;
            this.rdSummery.Text = "Summary";
            this.rdSummery.UseVisualStyleBackColor = true;
            // 
            // rdDetail
            // 
            this.rdDetail.AutoSize = true;
            this.rdDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDetail.Location = new System.Drawing.Point(6, 42);
            this.rdDetail.Name = "rdDetail";
            this.rdDetail.Size = new System.Drawing.Size(55, 17);
            this.rdDetail.TabIndex = 67;
            this.rdDetail.TabStop = true;
            this.rdDetail.Text = "Detail";
            this.rdDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_agency);
            this.groupBox1.Controls.Add(this.lbl_company);
            this.groupBox1.Controls.Add(this.lbl_Agency);
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 76);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dteUpto);
            this.groupBox2.Controls.Add(this.cmdGateway);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkStation);
            this.groupBox2.Controls.Add(this.cmbStation);
            this.groupBox2.Controls.Add(this.chkGateway);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 100);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Up to date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Station :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Gateway :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdSummery);
            this.groupBox3.Controls.Add(this.rdDetail);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 71);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Print Option";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnRetrive);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 561);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(284, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1073, 561);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtGrandTotal);
            this.groupBox4.Controls.Add(this.txtMthan10);
            this.groupBox4.Controls.Add(this.txtDay7);
            this.groupBox4.Controls.Add(this.txtDay6);
            this.groupBox4.Controls.Add(this.txtDay5);
            this.groupBox4.Controls.Add(this.txtDay4);
            this.groupBox4.Controls.Add(this.txtDay3);
            this.groupBox4.Controls.Add(this.txtDay2);
            this.groupBox4.Controls.Add(this.txtDay1);
            this.groupBox4.Controls.Add(this.grvInqShipment);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1070, 561);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(958, 504);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(100, 22);
            this.txtGrandTotal.TabIndex = 78;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMthan10
            // 
            this.txtMthan10.Location = new System.Drawing.Point(857, 504);
            this.txtMthan10.Name = "txtMthan10";
            this.txtMthan10.ReadOnly = true;
            this.txtMthan10.Size = new System.Drawing.Size(100, 22);
            this.txtMthan10.TabIndex = 77;
            this.txtMthan10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay7
            // 
            this.txtDay7.Location = new System.Drawing.Point(756, 504);
            this.txtDay7.Name = "txtDay7";
            this.txtDay7.ReadOnly = true;
            this.txtDay7.Size = new System.Drawing.Size(100, 22);
            this.txtDay7.TabIndex = 76;
            this.txtDay7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay6
            // 
            this.txtDay6.Location = new System.Drawing.Point(655, 504);
            this.txtDay6.Name = "txtDay6";
            this.txtDay6.ReadOnly = true;
            this.txtDay6.Size = new System.Drawing.Size(100, 22);
            this.txtDay6.TabIndex = 75;
            this.txtDay6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay5
            // 
            this.txtDay5.Location = new System.Drawing.Point(554, 504);
            this.txtDay5.Name = "txtDay5";
            this.txtDay5.ReadOnly = true;
            this.txtDay5.Size = new System.Drawing.Size(100, 22);
            this.txtDay5.TabIndex = 74;
            this.txtDay5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay4
            // 
            this.txtDay4.Location = new System.Drawing.Point(453, 504);
            this.txtDay4.Name = "txtDay4";
            this.txtDay4.ReadOnly = true;
            this.txtDay4.Size = new System.Drawing.Size(100, 22);
            this.txtDay4.TabIndex = 73;
            this.txtDay4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay3
            // 
            this.txtDay3.Location = new System.Drawing.Point(352, 504);
            this.txtDay3.Name = "txtDay3";
            this.txtDay3.ReadOnly = true;
            this.txtDay3.Size = new System.Drawing.Size(100, 22);
            this.txtDay3.TabIndex = 72;
            this.txtDay3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay2
            // 
            this.txtDay2.Location = new System.Drawing.Point(251, 504);
            this.txtDay2.Name = "txtDay2";
            this.txtDay2.ReadOnly = true;
            this.txtDay2.Size = new System.Drawing.Size(100, 22);
            this.txtDay2.TabIndex = 71;
            this.txtDay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDay1
            // 
            this.txtDay1.Location = new System.Drawing.Point(150, 504);
            this.txtDay1.Name = "txtDay1";
            this.txtDay1.ReadOnly = true;
            this.txtDay1.Size = new System.Drawing.Size(100, 22);
            this.txtDay1.TabIndex = 70;
            this.txtDay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grvInqShipment
            // 
            this.grvInqShipment.AllowUserToAddRows = false;
            this.grvInqShipment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.Black;
            this.grvInqShipment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle40;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvInqShipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.grvInqShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvInqShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clGatway,
            this.clDay1,
            this.clDay2,
            this.clDay3,
            this.clDay4,
            this.clDay5,
            this.clDay6,
            this.clDay7,
            this.clDay10,
            this.clLineTotal});
            this.grvInqShipment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvInqShipment.EnableHeadersVisualStyles = false;
            this.grvInqShipment.Location = new System.Drawing.Point(3, 18);
            this.grvInqShipment.Name = "grvInqShipment";
            this.grvInqShipment.RowHeadersVisible = false;
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.White;
            this.grvInqShipment.RowsDefaultCellStyle = dataGridViewCellStyle52;
            this.grvInqShipment.RowTemplate.Height = 15;
            this.grvInqShipment.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grvInqShipment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grvInqShipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grvInqShipment.Size = new System.Drawing.Size(1064, 480);
            this.grvInqShipment.TabIndex = 59;
            // 
            // clGatway
            // 
            this.clGatway.DataPropertyName = "Gateway";
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clGatway.DefaultCellStyle = dataGridViewCellStyle42;
            this.clGatway.HeaderText = "Gateway";
            this.clGatway.Name = "clGatway";
            this.clGatway.ReadOnly = true;
            this.clGatway.Width = 150;
            // 
            // clDay1
            // 
            this.clDay1.DataPropertyName = "Day1";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDay1.DefaultCellStyle = dataGridViewCellStyle43;
            this.clDay1.HeaderText = "Day 1";
            this.clDay1.Name = "clDay1";
            this.clDay1.ReadOnly = true;
            // 
            // clDay2
            // 
            this.clDay2.DataPropertyName = "Day2";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDay2.DefaultCellStyle = dataGridViewCellStyle44;
            this.clDay2.HeaderText = "Day 2";
            this.clDay2.Name = "clDay2";
            // 
            // clDay3
            // 
            this.clDay3.DataPropertyName = "Day3";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDay3.DefaultCellStyle = dataGridViewCellStyle45;
            this.clDay3.HeaderText = "Day 3";
            this.clDay3.Name = "clDay3";
            // 
            // clDay4
            // 
            this.clDay4.DataPropertyName = "Day4";
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clDay4.DefaultCellStyle = dataGridViewCellStyle46;
            this.clDay4.HeaderText = "Day 4";
            this.clDay4.Name = "clDay4";
            this.clDay4.ReadOnly = true;
            // 
            // clDay5
            // 
            this.clDay5.DataPropertyName = "Day5";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clDay5.DefaultCellStyle = dataGridViewCellStyle47;
            this.clDay5.HeaderText = "Day 5";
            this.clDay5.Name = "clDay5";
            this.clDay5.ReadOnly = true;
            // 
            // clDay6
            // 
            this.clDay6.DataPropertyName = "Day6";
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clDay6.DefaultCellStyle = dataGridViewCellStyle48;
            this.clDay6.HeaderText = "Day 6";
            this.clDay6.Name = "clDay6";
            this.clDay6.ReadOnly = true;
            // 
            // clDay7
            // 
            this.clDay7.DataPropertyName = "Day7";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clDay7.DefaultCellStyle = dataGridViewCellStyle49;
            this.clDay7.HeaderText = "Day 7";
            this.clDay7.Name = "clDay7";
            this.clDay7.ReadOnly = true;
            // 
            // clDay10
            // 
            this.clDay10.DataPropertyName = "MoreThanDay10";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clDay10.DefaultCellStyle = dataGridViewCellStyle50;
            this.clDay10.HeaderText = "Day 10 >";
            this.clDay10.Name = "clDay10";
            this.clDay10.ReadOnly = true;
            // 
            // clLineTotal
            // 
            this.clLineTotal.DataPropertyName = "LineTotal";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.clLineTotal.DefaultCellStyle = dataGridViewCellStyle51;
            this.clLineTotal.HeaderText = "Totals";
            this.clLineTotal.Name = "clLineTotal";
            this.clLineTotal.ReadOnly = true;
            // 
            // bgInqShipWork
            // 
            this.bgInqShipWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgInqShipWork_DoWork);
            this.bgInqShipWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgInqShipWork_RunWorkerCompleted);
            // 
            // ShipmentHeld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ShipmentHeld";
            this.Text = "Shipment Held At Custom";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvInqShipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.ComboBox cmb_agency;
        private System.Windows.Forms.Label lbl_Agency;
        private System.Windows.Forms.Label lbl_company;
        private System.Windows.Forms.DateTimePicker dteUpto;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.ComboBox cmdGateway;
        private System.Windows.Forms.Button btnRetrive;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkGateway;
        private System.Windows.Forms.CheckBox chkStation;
        private System.Windows.Forms.RadioButton rdSummery;
        private System.Windows.Forms.RadioButton rdDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grvInqShipment;
        private System.ComponentModel.BackgroundWorker bgInqShipWork;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.TextBox txtMthan10;
        private System.Windows.Forms.TextBox txtDay7;
        private System.Windows.Forms.TextBox txtDay6;
        private System.Windows.Forms.TextBox txtDay5;
        private System.Windows.Forms.TextBox txtDay4;
        private System.Windows.Forms.TextBox txtDay3;
        private System.Windows.Forms.TextBox txtDay2;
        private System.Windows.Forms.TextBox txtDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGatway;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineTotal;
    }
}