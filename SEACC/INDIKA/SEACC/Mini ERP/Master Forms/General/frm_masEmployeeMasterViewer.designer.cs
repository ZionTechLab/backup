namespace Digiteq
{
    partial class frm_masEmployeeMasterViewer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOperator = new System.Windows.Forms.CheckBox();
            this.chkAssistant = new System.Windows.Forms.CheckBox();
            this.chkDrive = new System.Windows.Forms.CheckBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.labFax = new System.Windows.Forms.Label();
            this.txtDesignationName = new System.Windows.Forms.TextBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblNic = new System.Windows.Forms.Label();
            this.txtNicNo = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtMoible = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.tetEmployeeCode = new System.Windows.Forms.TextBox();
            this.lblEmpCode = new System.Windows.Forms.Label();
            this.chkSalesExecutive = new System.Windows.Forms.CheckBox();
            this.chkSalesManager = new System.Windows.Forms.CheckBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.chkSelesRep = new System.Windows.Forms.CheckBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.chkAreaManager = new System.Windows.Forms.CheckBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSalesTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkOperator);
            this.panel1.Controls.Add(this.chkAssistant);
            this.panel1.Controls.Add(this.chkDrive);
            this.panel1.Controls.Add(this.dtpDateOfBirth);
            this.panel1.Controls.Add(this.lblDateOfBirth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labFax);
            this.panel1.Controls.Add(this.txtDesignationName);
            this.panel1.Controls.Add(this.lblDesignation);
            this.panel1.Controls.Add(this.txtSalesTarget);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.btnLoadImage);
            this.panel1.Controls.Add(this.pbxImage);
            this.panel1.Controls.Add(this.txtTelephone);
            this.panel1.Controls.Add(this.lblTelephone);
            this.panel1.Controls.Add(this.lblNic);
            this.panel1.Controls.Add(this.txtNicNo);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.txtMoible);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.lblMobile);
            this.panel1.Controls.Add(this.tetEmployeeCode);
            this.panel1.Controls.Add(this.lblEmpCode);
            this.panel1.Controls.Add(this.chkSalesExecutive);
            this.panel1.Controls.Add(this.chkSalesManager);
            this.panel1.Controls.Add(this.txtEmployeeID);
            this.panel1.Controls.Add(this.chkSelesRep);
            this.panel1.Controls.Add(this.txtEmployeeName);
            this.panel1.Controls.Add(this.lblEmployeeID);
            this.panel1.Controls.Add(this.chkAreaManager);
            this.panel1.Controls.Add(this.lblEmpName);
            this.panel1.Location = new System.Drawing.Point(10, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 192);
            this.panel1.TabIndex = 22;
            // 
            // chkOperator
            // 
            this.chkOperator.AutoSize = true;
            this.chkOperator.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkOperator.Location = new System.Drawing.Point(544, 166);
            this.chkOperator.Name = "chkOperator";
            this.chkOperator.Size = new System.Drawing.Size(70, 18);
            this.chkOperator.TabIndex = 433;
            this.chkOperator.Text = "Operator";
            this.chkOperator.UseVisualStyleBackColor = true;
            // 
            // chkAssistant
            // 
            this.chkAssistant.AutoSize = true;
            this.chkAssistant.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssistant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAssistant.Location = new System.Drawing.Point(467, 166);
            this.chkAssistant.Name = "chkAssistant";
            this.chkAssistant.Size = new System.Drawing.Size(71, 18);
            this.chkAssistant.TabIndex = 432;
            this.chkAssistant.Text = "Assistant";
            this.chkAssistant.UseVisualStyleBackColor = true;
            // 
            // chkDrive
            // 
            this.chkDrive.AutoSize = true;
            this.chkDrive.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDrive.Location = new System.Drawing.Point(404, 166);
            this.chkDrive.Name = "chkDrive";
            this.chkDrive.Size = new System.Drawing.Size(57, 18);
            this.chkDrive.TabIndex = 431;
            this.chkDrive.Text = "Driver";
            this.chkDrive.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(119, 110);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(120, 20);
            this.dtpDateOfBirth.TabIndex = 430;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDateOfBirth.Location = new System.Drawing.Point(11, 113);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(67, 14);
            this.lblDateOfBirth.TabIndex = 429;
            this.lblDateOfBirth.Text = "DateOfBirth";
            // 
            // labFax
            // 
            this.labFax.AutoSize = true;
            this.labFax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labFax.Location = new System.Drawing.Point(294, 113);
            this.labFax.Name = "labFax";
            this.labFax.Size = new System.Drawing.Size(25, 14);
            this.labFax.TabIndex = 428;
            this.labFax.Text = "Fax";
            // 
            // txtDesignationName
            // 
            this.txtDesignationName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignationName.Location = new System.Drawing.Point(119, 85);
            this.txtDesignationName.Name = "txtDesignationName";
            this.txtDesignationName.Size = new System.Drawing.Size(120, 22);
            this.txtDesignationName.TabIndex = 347;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDesignation.Location = new System.Drawing.Point(11, 88);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(66, 14);
            this.lblDesignation.TabIndex = 346;
            this.lblDesignation.Text = "Designation";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(362, 110);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(120, 22);
            this.txtFax.TabIndex = 426;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Image = global::Digiteq.Properties.Resources.add;
            this.btnLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadImage.Location = new System.Drawing.Point(499, 108);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(105, 25);
            this.btnLoadImage.TabIndex = 424;
            this.btnLoadImage.Text = "    Add Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImage.Image = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.InitialImage = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.Location = new System.Drawing.Point(499, 8);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(105, 100);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 425;
            this.pbxImage.TabStop = false;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(362, 60);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(120, 22);
            this.txtTelephone.TabIndex = 423;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTelephone.Location = new System.Drawing.Point(294, 63);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(57, 14);
            this.lblTelephone.TabIndex = 422;
            this.lblTelephone.Text = "Telephone";
            // 
            // lblNic
            // 
            this.lblNic.AutoSize = true;
            this.lblNic.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNic.Location = new System.Drawing.Point(294, 13);
            this.lblNic.Name = "lblNic";
            this.lblNic.Size = new System.Drawing.Size(43, 14);
            this.lblNic.TabIndex = 421;
            this.lblNic.Text = "Nic No:";
            // 
            // txtNicNo
            // 
            this.txtNicNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNicNo.Location = new System.Drawing.Point(362, 10);
            this.txtNicNo.Name = "txtNicNo";
            this.txtNicNo.Size = new System.Drawing.Size(120, 22);
            this.txtNicNo.TabIndex = 420;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmail.Location = new System.Drawing.Point(294, 88);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 14);
            this.lblEmail.TabIndex = 419;
            this.lblEmail.Text = "Email";
            // 
            // txtMoible
            // 
            this.txtMoible.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoible.Location = new System.Drawing.Point(362, 35);
            this.txtMoible.Name = "txtMoible";
            this.txtMoible.Size = new System.Drawing.Size(120, 22);
            this.txtMoible.TabIndex = 418;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(362, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(120, 22);
            this.txtEmail.TabIndex = 417;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblMobile.Location = new System.Drawing.Point(294, 38);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(41, 14);
            this.lblMobile.TabIndex = 416;
            this.lblMobile.Text = "Mobile";
            // 
            // tetEmployeeCode
            // 
            this.tetEmployeeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tetEmployeeCode.Location = new System.Drawing.Point(119, 60);
            this.tetEmployeeCode.Name = "tetEmployeeCode";
            this.tetEmployeeCode.Size = new System.Drawing.Size(120, 22);
            this.tetEmployeeCode.TabIndex = 415;
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.AutoSize = true;
            this.lblEmpCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmpCode.Location = new System.Drawing.Point(11, 66);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(99, 14);
            this.lblEmpCode.TabIndex = 414;
            this.lblEmpCode.Text = "Employee Number";
            // 
            // chkSalesExecutive
            // 
            this.chkSalesExecutive.AutoSize = true;
            this.chkSalesExecutive.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalesExecutive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSalesExecutive.Location = new System.Drawing.Point(295, 166);
            this.chkSalesExecutive.Name = "chkSalesExecutive";
            this.chkSalesExecutive.Size = new System.Drawing.Size(103, 18);
            this.chkSalesExecutive.TabIndex = 105;
            this.chkSalesExecutive.Text = "Sales Executive";
            this.chkSalesExecutive.UseVisualStyleBackColor = true;
            // 
            // chkSalesManager
            // 
            this.chkSalesManager.AutoSize = true;
            this.chkSalesManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalesManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSalesManager.Location = new System.Drawing.Point(8, 166);
            this.chkSalesManager.Name = "chkSalesManager";
            this.chkSalesManager.Size = new System.Drawing.Size(99, 18);
            this.chkSalesManager.TabIndex = 7;
            this.chkSalesManager.Text = "Sales Manager";
            this.chkSalesManager.UseVisualStyleBackColor = true;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtEmployeeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.Location = new System.Drawing.Point(119, 10);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(120, 22);
            this.txtEmployeeID.TabIndex = 0;
            this.txtEmployeeID.DoubleClick += new System.EventHandler(this.txtEmployeeID_DoubleClick);
            this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
            // 
            // chkSelesRep
            // 
            this.chkSelesRep.AutoSize = true;
            this.chkSelesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelesRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSelesRep.Location = new System.Drawing.Point(215, 166);
            this.chkSelesRep.Name = "chkSelesRep";
            this.chkSelesRep.Size = new System.Drawing.Size(74, 18);
            this.chkSelesRep.TabIndex = 6;
            this.chkSelesRep.Text = "Seles Rep";
            this.chkSelesRep.UseVisualStyleBackColor = true;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(119, 35);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(156, 22);
            this.txtEmployeeName.TabIndex = 1;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmployeeID.Location = new System.Drawing.Point(11, 13);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(70, 14);
            this.lblEmployeeID.TabIndex = 72;
            this.lblEmployeeID.Text = "Employee ID";
            // 
            // chkAreaManager
            // 
            this.chkAreaManager.AutoSize = true;
            this.chkAreaManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAreaManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAreaManager.Location = new System.Drawing.Point(113, 166);
            this.chkAreaManager.Name = "chkAreaManager";
            this.chkAreaManager.Size = new System.Drawing.Size(96, 18);
            this.chkAreaManager.TabIndex = 5;
            this.chkAreaManager.Text = "Area Manager";
            this.chkAreaManager.UseVisualStyleBackColor = true;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmpName.Location = new System.Drawing.Point(11, 38);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(89, 14);
            this.lblEmpName.TabIndex = 104;
            this.lblEmpName.Text = "Employee Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(483, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 30;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.EmployeeName,
            this.EmployeeCode,
            this.designation,
            this.Nic,
            this.Mobile,
            this.Telephone,
            this.Email});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 243);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(629, 307);
            this.dgvDetail.TabIndex = 20;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Width = 60;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 90;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.HeaderText = "Employee Number";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.Width = 80;
            // 
            // designation
            // 
            this.designation.HeaderText = "Designation";
            this.designation.Name = "designation";
            this.designation.Width = 80;
            // 
            // Nic
            // 
            this.Nic.HeaderText = "Nic No:";
            this.Nic.Name = "Nic";
            this.Nic.Width = 80;
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            this.Mobile.Width = 80;
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            this.Telephone.Width = 80;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 80;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(406, 212);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(560, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSalesTarget
            // 
            this.txtSalesTarget.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesTarget.Location = new System.Drawing.Point(119, 134);
            this.txtSalesTarget.Name = "txtSalesTarget";
            this.txtSalesTarget.Size = new System.Drawing.Size(120, 22);
            this.txtSalesTarget.TabIndex = 426;
            this.txtSalesTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesTarget_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 428;
            this.label1.Text = "Sales Target";
            // 
            // frm_masEmployeeMasterViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(662, 567);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_masEmployeeMasterViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Master";
            this.Load += new System.EventHandler(this.frm_mtrEmplioyeeMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_masEmployeeMaster_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDesignationName;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.CheckBox chkSalesExecutive;
        private System.Windows.Forms.CheckBox chkSalesManager;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.CheckBox chkSelesRep;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.CheckBox chkAreaManager;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tetEmployeeCode;
        private System.Windows.Forms.Label lblEmpCode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtMoible;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblNic;
        private System.Windows.Forms.TextBox txtNicNo;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label labFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.CheckBox chkAssistant;
        private System.Windows.Forms.CheckBox chkDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.CheckBox chkOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalesTarget;



    }
}