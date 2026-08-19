namespace Express.UI.Invoice.View
{
    partial class InvDelInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtInvPendingFC = new System.Windows.Forms.TextBox();
            this.txtBilledAwb = new System.Windows.Forms.TextBox();
            this.btnPendingInvPrv = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBilledAmt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBilledWgt = new System.Windows.Forms.TextBox();
            this.btnInvDetProcess = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPendingBillProcess = new System.Windows.Forms.Button();
            this.btnPendingBillPrv = new System.Windows.Forms.Button();
            this.txtBillPendingWgt = new System.Windows.Forms.TextBox();
            this.txtBillPendingAwb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNotDelWgt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnNotDelPrv = new System.Windows.Forms.Button();
            this.txtNotDelPack = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_agency = new System.Windows.Forms.ComboBox();
            this.lbl_company = new System.Windows.Forms.Label();
            this.lbl_Agency = new System.Windows.Forms.Label();
            this.txtCompanyN = new System.Windows.Forms.TextBox();
            this.btnPendingRetrive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dteUptodate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOrgCountry = new System.Windows.Forms.TextBox();
            this.txtOrgCity = new System.Windows.Forms.TextBox();
            this.txtOrgAdd2 = new System.Windows.Forms.TextBox();
            this.txtOrgAdd1 = new System.Windows.Forms.TextBox();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.txtOrgCode = new System.Windows.Forms.TextBox();
            this.txtFcCurr = new System.Windows.Forms.TextBox();
            this.txtLcCurr = new System.Windows.Forms.TextBox();
            this.txtConvertRate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtInvAmtLc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkInvDetAwbList = new System.Windows.Forms.CheckBox();
            this.txtInvAmtFc = new System.Windows.Forms.TextBox();
            this.txtInvoiceWgt = new System.Windows.Forms.TextBox();
            this.txtInvAwb = new System.Windows.Forms.TextBox();
            this.btnInvDetPrint = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.dteInvDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bgwPodProcess = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 457);
            this.panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtInvPendingFC);
            this.groupBox5.Controls.Add(this.txtBilledAwb);
            this.groupBox5.Controls.Add(this.btnPendingInvPrv);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtBilledAmt);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtBilledWgt);
            this.groupBox5.Controls.Add(this.btnInvDetProcess);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox5.Location = new System.Drawing.Point(0, 327);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 130);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Billed – Not Invoiced";
            // 
            // txtInvPendingFC
            // 
            this.txtInvPendingFC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtInvPendingFC.Location = new System.Drawing.Point(199, 67);
            this.txtInvPendingFC.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvPendingFC.Name = "txtInvPendingFC";
            this.txtInvPendingFC.ReadOnly = true;
            this.txtInvPendingFC.Size = new System.Drawing.Size(39, 22);
            this.txtInvPendingFC.TabIndex = 101;
            // 
            // txtBilledAwb
            // 
            this.txtBilledAwb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtBilledAwb.Location = new System.Drawing.Point(95, 21);
            this.txtBilledAwb.Margin = new System.Windows.Forms.Padding(2);
            this.txtBilledAwb.Name = "txtBilledAwb";
            this.txtBilledAwb.ReadOnly = true;
            this.txtBilledAwb.Size = new System.Drawing.Size(100, 22);
            this.txtBilledAwb.TabIndex = 83;
            this.txtBilledAwb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPendingInvPrv
            // 
            this.btnPendingInvPrv.BackColor = System.Drawing.SystemColors.Control;
            this.btnPendingInvPrv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingInvPrv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPendingInvPrv.Location = new System.Drawing.Point(257, 19);
            this.btnPendingInvPrv.Name = "btnPendingInvPrv";
            this.btnPendingInvPrv.Size = new System.Drawing.Size(75, 39);
            this.btnPendingInvPrv.TabIndex = 87;
            this.btnPendingInvPrv.Text = "Preview";
            this.btnPendingInvPrv.UseVisualStyleBackColor = false;
            this.btnPendingInvPrv.Click += new System.EventHandler(this.btnPendingInvPrv_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(46, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "AWBs :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(39, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Weight :";
            // 
            // txtBilledAmt
            // 
            this.txtBilledAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtBilledAmt.Location = new System.Drawing.Point(95, 67);
            this.txtBilledAmt.Margin = new System.Windows.Forms.Padding(2);
            this.txtBilledAmt.Name = "txtBilledAmt";
            this.txtBilledAmt.ReadOnly = true;
            this.txtBilledAmt.Size = new System.Drawing.Size(100, 22);
            this.txtBilledAmt.TabIndex = 85;
            this.txtBilledAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Amount  (FC) :";
            // 
            // txtBilledWgt
            // 
            this.txtBilledWgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtBilledWgt.Location = new System.Drawing.Point(95, 44);
            this.txtBilledWgt.Margin = new System.Windows.Forms.Padding(2);
            this.txtBilledWgt.Name = "txtBilledWgt";
            this.txtBilledWgt.ReadOnly = true;
            this.txtBilledWgt.Size = new System.Drawing.Size(100, 22);
            this.txtBilledWgt.TabIndex = 84;
            this.txtBilledWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInvDetProcess
            // 
            this.btnInvDetProcess.BackColor = System.Drawing.SystemColors.Control;
            this.btnInvDetProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvDetProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInvDetProcess.Location = new System.Drawing.Point(257, 58);
            this.btnInvDetProcess.Name = "btnInvDetProcess";
            this.btnInvDetProcess.Size = new System.Drawing.Size(75, 39);
            this.btnInvDetProcess.TabIndex = 90;
            this.btnInvDetProcess.Text = "Process";
            this.btnInvDetProcess.UseVisualStyleBackColor = false;
            this.btnInvDetProcess.Click += new System.EventHandler(this.btnInvDetProcess_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPendingBillProcess);
            this.groupBox2.Controls.Add(this.btnPendingBillPrv);
            this.groupBox2.Controls.Add(this.txtBillPendingWgt);
            this.groupBox2.Controls.Add(this.txtBillPendingAwb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(0, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Billing Pending –Delivered";
            // 
            // btnPendingBillProcess
            // 
            this.btnPendingBillProcess.BackColor = System.Drawing.SystemColors.Control;
            this.btnPendingBillProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingBillProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPendingBillProcess.Location = new System.Drawing.Point(257, 51);
            this.btnPendingBillProcess.Name = "btnPendingBillProcess";
            this.btnPendingBillProcess.Size = new System.Drawing.Size(75, 39);
            this.btnPendingBillProcess.TabIndex = 83;
            this.btnPendingBillProcess.Text = "Billing Process";
            this.btnPendingBillProcess.UseVisualStyleBackColor = false;
            this.btnPendingBillProcess.Click += new System.EventHandler(this.btnPendingBillProcess_Click);
            // 
            // btnPendingBillPrv
            // 
            this.btnPendingBillPrv.BackColor = System.Drawing.SystemColors.Control;
            this.btnPendingBillPrv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingBillPrv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPendingBillPrv.Location = new System.Drawing.Point(257, 11);
            this.btnPendingBillPrv.Name = "btnPendingBillPrv";
            this.btnPendingBillPrv.Size = new System.Drawing.Size(75, 39);
            this.btnPendingBillPrv.TabIndex = 82;
            this.btnPendingBillPrv.Text = "Preview";
            this.btnPendingBillPrv.UseVisualStyleBackColor = false;
            this.btnPendingBillPrv.Click += new System.EventHandler(this.btnPendingBillPrv_Click);
            // 
            // txtBillPendingWgt
            // 
            this.txtBillPendingWgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtBillPendingWgt.Location = new System.Drawing.Point(95, 53);
            this.txtBillPendingWgt.Margin = new System.Windows.Forms.Padding(2);
            this.txtBillPendingWgt.Name = "txtBillPendingWgt";
            this.txtBillPendingWgt.ReadOnly = true;
            this.txtBillPendingWgt.Size = new System.Drawing.Size(100, 22);
            this.txtBillPendingWgt.TabIndex = 81;
            this.txtBillPendingWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBillPendingAwb
            // 
            this.txtBillPendingAwb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtBillPendingAwb.Location = new System.Drawing.Point(95, 30);
            this.txtBillPendingAwb.Margin = new System.Windows.Forms.Padding(2);
            this.txtBillPendingAwb.Name = "txtBillPendingAwb";
            this.txtBillPendingAwb.ReadOnly = true;
            this.txtBillPendingAwb.Size = new System.Drawing.Size(100, 22);
            this.txtBillPendingAwb.TabIndex = 80;
            this.txtBillPendingAwb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(39, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Weight :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(46, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "AWBs :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNotDelWgt);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.btnNotDelPrv);
            this.groupBox3.Controls.Add(this.txtNotDelPack);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(0, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 80);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Billing Pending – Not Delivered";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtNotDelWgt
            // 
            this.txtNotDelWgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtNotDelWgt.Location = new System.Drawing.Point(95, 45);
            this.txtNotDelWgt.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotDelWgt.Name = "txtNotDelWgt";
            this.txtNotDelWgt.ReadOnly = true;
            this.txtNotDelWgt.Size = new System.Drawing.Size(100, 22);
            this.txtNotDelWgt.TabIndex = 87;
            this.txtNotDelWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(39, 48);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 86;
            this.label15.Text = "Weight :";
            // 
            // btnNotDelPrv
            // 
            this.btnNotDelPrv.BackColor = System.Drawing.SystemColors.Control;
            this.btnNotDelPrv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotDelPrv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNotDelPrv.Location = new System.Drawing.Point(257, 24);
            this.btnNotDelPrv.Name = "btnNotDelPrv";
            this.btnNotDelPrv.Size = new System.Drawing.Size(75, 39);
            this.btnNotDelPrv.TabIndex = 85;
            this.btnNotDelPrv.Text = "Preview";
            this.btnNotDelPrv.UseVisualStyleBackColor = false;
            this.btnNotDelPrv.Click += new System.EventHandler(this.btnNotDelPrv_Click);
            // 
            // txtNotDelPack
            // 
            this.txtNotDelPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtNotDelPack.Location = new System.Drawing.Point(95, 22);
            this.txtNotDelPack.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotDelPack.Name = "txtNotDelPack";
            this.txtNotDelPack.ReadOnly = true;
            this.txtNotDelPack.Size = new System.Drawing.Size(100, 22);
            this.txtNotDelPack.TabIndex = 84;
            this.txtNotDelPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(46, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "AWBs :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_agency);
            this.groupBox1.Controls.Add(this.lbl_company);
            this.groupBox1.Controls.Add(this.lbl_Agency);
            this.groupBox1.Controls.Add(this.txtCompanyN);
            this.groupBox1.Controls.Add(this.btnPendingRetrive);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dteUptodate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmb_agency
            // 
            this.cmb_agency.FormattingEnabled = true;
            this.cmb_agency.Location = new System.Drawing.Point(95, 24);
            this.cmb_agency.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_agency.Name = "cmb_agency";
            this.cmb_agency.Size = new System.Drawing.Size(237, 21);
            this.cmb_agency.TabIndex = 86;
            this.cmb_agency.SelectedValueChanged += new System.EventHandler(this.cmb_agency_SelectedValueChanged);
            // 
            // lbl_company
            // 
            this.lbl_company.AutoSize = true;
            this.lbl_company.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_company.Location = new System.Drawing.Point(27, 49);
            this.lbl_company.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_company.Name = "lbl_company";
            this.lbl_company.Size = new System.Drawing.Size(63, 13);
            this.lbl_company.TabIndex = 84;
            this.lbl_company.Text = "Company :";
            // 
            // lbl_Agency
            // 
            this.lbl_Agency.AutoSize = true;
            this.lbl_Agency.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Agency.Location = new System.Drawing.Point(38, 27);
            this.lbl_Agency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Agency.Name = "lbl_Agency";
            this.lbl_Agency.Size = new System.Drawing.Size(52, 13);
            this.lbl_Agency.TabIndex = 85;
            this.lbl_Agency.Text = "Agency :";
            // 
            // txtCompanyN
            // 
            this.txtCompanyN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtCompanyN.Location = new System.Drawing.Point(95, 47);
            this.txtCompanyN.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompanyN.Name = "txtCompanyN";
            this.txtCompanyN.ReadOnly = true;
            this.txtCompanyN.Size = new System.Drawing.Size(237, 20);
            this.txtCompanyN.TabIndex = 87;
            // 
            // btnPendingRetrive
            // 
            this.btnPendingRetrive.BackColor = System.Drawing.SystemColors.Control;
            this.btnPendingRetrive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingRetrive.Location = new System.Drawing.Point(257, 90);
            this.btnPendingRetrive.Name = "btnPendingRetrive";
            this.btnPendingRetrive.Size = new System.Drawing.Size(75, 39);
            this.btnPendingRetrive.TabIndex = 80;
            this.btnPendingRetrive.Text = "Retrieve";
            this.btnPendingRetrive.UseVisualStyleBackColor = false;
            this.btnPendingRetrive.Click += new System.EventHandler(this.btnPendingRetrive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Up to Date :";
            // 
            // dteUptodate
            // 
            this.dteUptodate.CustomFormat = "dd-MMM-yyyy";
            this.dteUptodate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteUptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteUptodate.Location = new System.Drawing.Point(95, 90);
            this.dteUptodate.Name = "dteUptodate";
            this.dteUptodate.Size = new System.Drawing.Size(102, 22);
            this.dteUptodate.TabIndex = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(348, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 457);
            this.panel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtOrgCountry);
            this.groupBox4.Controls.Add(this.txtOrgCity);
            this.groupBox4.Controls.Add(this.txtOrgAdd2);
            this.groupBox4.Controls.Add(this.txtOrgAdd1);
            this.groupBox4.Controls.Add(this.txtOrgName);
            this.groupBox4.Controls.Add(this.txtOrgCode);
            this.groupBox4.Controls.Add(this.txtFcCurr);
            this.groupBox4.Controls.Add(this.txtLcCurr);
            this.groupBox4.Controls.Add(this.txtConvertRate);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtInvAmtLc);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.chkInvDetAwbList);
            this.groupBox4.Controls.Add(this.txtInvAmtFc);
            this.groupBox4.Controls.Add(this.txtInvoiceWgt);
            this.groupBox4.Controls.Add(this.txtInvAwb);
            this.groupBox4.Controls.Add(this.btnInvDetPrint);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtInvNo);
            this.groupBox4.Controls.Add(this.dteInvDate);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(485, 457);
            this.groupBox4.TabIndex = 81;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Invoiced Detail";
            // 
            // txtOrgCountry
            // 
            this.txtOrgCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgCountry.Location = new System.Drawing.Point(217, 148);
            this.txtOrgCountry.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgCountry.Name = "txtOrgCountry";
            this.txtOrgCountry.ReadOnly = true;
            this.txtOrgCountry.Size = new System.Drawing.Size(263, 22);
            this.txtOrgCountry.TabIndex = 107;
            // 
            // txtOrgCity
            // 
            this.txtOrgCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgCity.Location = new System.Drawing.Point(113, 148);
            this.txtOrgCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgCity.Name = "txtOrgCity";
            this.txtOrgCity.ReadOnly = true;
            this.txtOrgCity.Size = new System.Drawing.Size(102, 22);
            this.txtOrgCity.TabIndex = 106;
            // 
            // txtOrgAdd2
            // 
            this.txtOrgAdd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgAdd2.Location = new System.Drawing.Point(113, 124);
            this.txtOrgAdd2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgAdd2.Name = "txtOrgAdd2";
            this.txtOrgAdd2.ReadOnly = true;
            this.txtOrgAdd2.Size = new System.Drawing.Size(367, 22);
            this.txtOrgAdd2.TabIndex = 105;
            // 
            // txtOrgAdd1
            // 
            this.txtOrgAdd1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgAdd1.Location = new System.Drawing.Point(113, 100);
            this.txtOrgAdd1.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgAdd1.Name = "txtOrgAdd1";
            this.txtOrgAdd1.ReadOnly = true;
            this.txtOrgAdd1.Size = new System.Drawing.Size(367, 22);
            this.txtOrgAdd1.TabIndex = 104;
            // 
            // txtOrgName
            // 
            this.txtOrgName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgName.Location = new System.Drawing.Point(217, 76);
            this.txtOrgName.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.ReadOnly = true;
            this.txtOrgName.Size = new System.Drawing.Size(263, 22);
            this.txtOrgName.TabIndex = 103;
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtOrgCode.Location = new System.Drawing.Point(113, 76);
            this.txtOrgCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.ReadOnly = true;
            this.txtOrgCode.Size = new System.Drawing.Size(102, 22);
            this.txtOrgCode.TabIndex = 102;
            // 
            // txtFcCurr
            // 
            this.txtFcCurr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtFcCurr.Location = new System.Drawing.Point(217, 273);
            this.txtFcCurr.Margin = new System.Windows.Forms.Padding(2);
            this.txtFcCurr.Name = "txtFcCurr";
            this.txtFcCurr.ReadOnly = true;
            this.txtFcCurr.Size = new System.Drawing.Size(39, 22);
            this.txtFcCurr.TabIndex = 101;
            // 
            // txtLcCurr
            // 
            this.txtLcCurr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtLcCurr.Location = new System.Drawing.Point(217, 250);
            this.txtLcCurr.Margin = new System.Windows.Forms.Padding(2);
            this.txtLcCurr.Name = "txtLcCurr";
            this.txtLcCurr.ReadOnly = true;
            this.txtLcCurr.Size = new System.Drawing.Size(39, 22);
            this.txtLcCurr.TabIndex = 100;
            // 
            // txtConvertRate
            // 
            this.txtConvertRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtConvertRate.Location = new System.Drawing.Point(329, 273);
            this.txtConvertRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtConvertRate.Name = "txtConvertRate";
            this.txtConvertRate.ReadOnly = true;
            this.txtConvertRate.Size = new System.Drawing.Size(67, 22);
            this.txtConvertRate.TabIndex = 99;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(260, 275);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 98;
            this.label16.Text = "Conv.Rate :";
            // 
            // txtInvAmtLc
            // 
            this.txtInvAmtLc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtInvAmtLc.Location = new System.Drawing.Point(113, 250);
            this.txtInvAmtLc.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvAmtLc.Name = "txtInvAmtLc";
            this.txtInvAmtLc.ReadOnly = true;
            this.txtInvAmtLc.Size = new System.Drawing.Size(100, 22);
            this.txtInvAmtLc.TabIndex = 97;
            this.txtInvAmtLc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(4, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Invoice Value (LC) :";
            // 
            // chkInvDetAwbList
            // 
            this.chkInvDetAwbList.AutoSize = true;
            this.chkInvDetAwbList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInvDetAwbList.Location = new System.Drawing.Point(322, 396);
            this.chkInvDetAwbList.Name = "chkInvDetAwbList";
            this.chkInvDetAwbList.Size = new System.Drawing.Size(73, 17);
            this.chkInvDetAwbList.TabIndex = 95;
            this.chkInvDetAwbList.Text = "AWB List";
            this.chkInvDetAwbList.UseVisualStyleBackColor = true;
            // 
            // txtInvAmtFc
            // 
            this.txtInvAmtFc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtInvAmtFc.Location = new System.Drawing.Point(113, 273);
            this.txtInvAmtFc.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvAmtFc.Name = "txtInvAmtFc";
            this.txtInvAmtFc.ReadOnly = true;
            this.txtInvAmtFc.Size = new System.Drawing.Size(100, 22);
            this.txtInvAmtFc.TabIndex = 94;
            this.txtInvAmtFc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvoiceWgt
            // 
            this.txtInvoiceWgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtInvoiceWgt.Location = new System.Drawing.Point(113, 227);
            this.txtInvoiceWgt.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceWgt.Name = "txtInvoiceWgt";
            this.txtInvoiceWgt.ReadOnly = true;
            this.txtInvoiceWgt.Size = new System.Drawing.Size(100, 22);
            this.txtInvoiceWgt.TabIndex = 93;
            this.txtInvoiceWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAwb
            // 
            this.txtInvAwb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.txtInvAwb.Location = new System.Drawing.Point(113, 204);
            this.txtInvAwb.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvAwb.Name = "txtInvAwb";
            this.txtInvAwb.ReadOnly = true;
            this.txtInvAwb.Size = new System.Drawing.Size(100, 22);
            this.txtInvAwb.TabIndex = 92;
            this.txtInvAwb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInvDetPrint
            // 
            this.btnInvDetPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnInvDetPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvDetPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInvDetPrint.Location = new System.Drawing.Point(398, 383);
            this.btnInvDetPrint.Name = "btnInvDetPrint";
            this.btnInvDetPrint.Size = new System.Drawing.Size(75, 39);
            this.btnInvDetPrint.TabIndex = 91;
            this.btnInvDetPrint.Text = "Print";
            this.btnInvDetPrint.UseVisualStyleBackColor = false;
            this.btnInvDetPrint.Click += new System.EventHandler(this.btnInvDetPrint_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(4, 276);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 89;
            this.label13.Text = "Invoice Value (FC) :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(58, 230);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 88;
            this.label12.Text = "Weight :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(65, 207);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 87;
            this.label11.Text = "AWBs :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(48, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 85;
            this.label10.Text = "Billing To :";
            // 
            // txtInvNo
            // 
            this.txtInvNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvNo.Location = new System.Drawing.Point(113, 27);
            this.txtInvNo.MaxLength = 60;
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(102, 22);
            this.txtInvNo.TabIndex = 84;
            this.txtInvNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvNo_KeyPress);
            // 
            // dteInvDate
            // 
            this.dteInvDate.CustomFormat = "dd-MMM-yyyy";
            this.dteInvDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteInvDate.Location = new System.Drawing.Point(113, 51);
            this.dteInvDate.Name = "dteInvDate";
            this.dteInvDate.Size = new System.Drawing.Size(102, 22);
            this.dteInvDate.TabIndex = 82;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(32, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 81;
            this.label9.Text = "Invoice Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(40, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Invoice No :";
            // 
            // bgwPodProcess
            // 
            this.bgwPodProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPodProcess_DoWork);
            this.bgwPodProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPodProcess_RunWorkerCompleted);
            // 
            // InvDelInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(849, 496);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(849, 496);
            this.Name = "InvDelInvoice";
            this.Text = "POD Invoice";
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dteUptodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPendingRetrive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPendingBillProcess;
        private System.Windows.Forms.Button btnPendingBillPrv;
        private System.Windows.Forms.TextBox txtBillPendingWgt;
        private System.Windows.Forms.TextBox txtBillPendingAwb;
        private System.Windows.Forms.Button btnPendingInvPrv;
        private System.Windows.Forms.TextBox txtBilledAmt;
        private System.Windows.Forms.TextBox txtBilledWgt;
        private System.Windows.Forms.TextBox txtBilledAwb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dteInvDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkInvDetAwbList;
        private System.Windows.Forms.TextBox txtInvAmtFc;
        private System.Windows.Forms.TextBox txtInvoiceWgt;
        private System.Windows.Forms.TextBox txtInvAwb;
        private System.Windows.Forms.Button btnInvDetPrint;
        private System.Windows.Forms.Button btnInvDetProcess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnNotDelPrv;
        private System.Windows.Forms.TextBox txtNotDelPack;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNotDelWgt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmb_agency;
        private System.Windows.Forms.Label lbl_company;
        private System.Windows.Forms.Label lbl_Agency;
        private System.Windows.Forms.TextBox txtCompanyN;
        private System.Windows.Forms.TextBox txtInvAmtLc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFcCurr;
        private System.Windows.Forms.TextBox txtLcCurr;
        private System.Windows.Forms.TextBox txtConvertRate;
        private System.Windows.Forms.Label label16;
        private System.ComponentModel.BackgroundWorker bgwPodProcess;
        private System.Windows.Forms.TextBox txtInvPendingFC;
        private System.Windows.Forms.TextBox txtOrgCountry;
        private System.Windows.Forms.TextBox txtOrgCity;
        private System.Windows.Forms.TextBox txtOrgAdd2;
        private System.Windows.Forms.TextBox txtOrgAdd1;
        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.TextBox txtOrgCode;
    }
}