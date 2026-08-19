namespace Digiteq
{
    partial class frmUserPermission_StorWise
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddUserTemplate = new System.Windows.Forms.Button();
            this.btnAddRoleTemplate = new System.Windows.Forms.Button();
            this.txtUserTemplate = new System.Windows.Forms.TextBox();
            this.txtRoleTemplate = new System.Windows.Forms.TextBox();
            this.chkIsUser = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtUserLevel = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewCustomer = new System.Windows.Forms.Label();
            this.pblBody = new System.Windows.Forms.Panel();
            this.chkEditAll = new System.Windows.Forms.CheckBox();
            this.chkNone = new System.Windows.Forms.CheckBox();
            this.chkApprovableAll = new System.Windows.Forms.CheckBox();
            this.chkCheckableAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.chkWriteAll = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.FormCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowWrite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowCheckable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowApprovable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pblBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(578, 0);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlHeader.Controls.Add(this.pnlFilters);
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Controls.Add(this.btnAddUserTemplate);
            this.pnlHeader.Controls.Add(this.btnAddRoleTemplate);
            this.pnlHeader.Controls.Add(this.txtUserTemplate);
            this.pnlHeader.Controls.Add(this.txtRoleTemplate);
            this.pnlHeader.Controls.Add(this.chkIsUser);
            this.pnlHeader.Controls.Add(this.txtUserName);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.txtDepartment);
            this.pnlHeader.Controls.Add(this.txtUserLevel);
            this.pnlHeader.Controls.Add(this.label18);
            this.pnlHeader.Controls.Add(this.label14);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.txtUserID);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.lblNewCustomer);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeader.Location = new System.Drawing.Point(3, 29);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(662, 152);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilters.Controls.Add(this.label6);
            this.pnlFilters.Controls.Add(this.panel3);
            this.pnlFilters.Controls.Add(this.label5);
            this.pnlFilters.Controls.Add(this.txtFormName);
            this.pnlFilters.Controls.Add(this.txtCategory);
            this.pnlFilters.Controls.Add(this.label4);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilters.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilters.Location = new System.Drawing.Point(0, 90);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlFilters.Size = new System.Drawing.Size(662, 62);
            this.pnlFilters.TabIndex = 446;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(313, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 490;
            this.label6.Text = "Store Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(9, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 1);
            this.panel3.TabIndex = 489;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(287, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 453;
            this.label5.Text = "Module Filter";
            // 
            // txtFormName
            // 
            this.txtFormName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormName.Location = new System.Drawing.Point(388, 30);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(246, 22);
            this.txtFormName.TabIndex = 452;
            this.txtFormName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFormName_KeyUp);
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(95, 30);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(200, 22);
            this.txtCategory.TabIndex = 451;
            this.txtCategory.Text = "Asanka Jayasuriya";
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(15, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 450;
            this.label4.Text = "Module Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(325, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 70);
            this.panel2.TabIndex = 472;
            // 
            // btnAddUserTemplate
            // 
            this.btnAddUserTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUserTemplate.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddUserTemplate.Location = new System.Drawing.Point(604, 33);
            this.btnAddUserTemplate.Name = "btnAddUserTemplate";
            this.btnAddUserTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnAddUserTemplate.TabIndex = 449;
            this.btnAddUserTemplate.UseVisualStyleBackColor = true;
            // 
            // btnAddRoleTemplate
            // 
            this.btnAddRoleTemplate.Enabled = false;
            this.btnAddRoleTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoleTemplate.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddRoleTemplate.Location = new System.Drawing.Point(604, 8);
            this.btnAddRoleTemplate.Name = "btnAddRoleTemplate";
            this.btnAddRoleTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnAddRoleTemplate.TabIndex = 449;
            this.btnAddRoleTemplate.UseVisualStyleBackColor = true;
            // 
            // txtUserTemplate
            // 
            this.txtUserTemplate.BackColor = System.Drawing.Color.LightGray;
            this.txtUserTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTemplate.Location = new System.Drawing.Point(440, 33);
            this.txtUserTemplate.Name = "txtUserTemplate";
            this.txtUserTemplate.ReadOnly = true;
            this.txtUserTemplate.Size = new System.Drawing.Size(156, 22);
            this.txtUserTemplate.TabIndex = 448;
            this.txtUserTemplate.DoubleClick += new System.EventHandler(this.txtUserTemplate_DoubleClick);
            this.txtUserTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserTemplate_KeyDown);
            // 
            // txtRoleTemplate
            // 
            this.txtRoleTemplate.BackColor = System.Drawing.Color.LightGray;
            this.txtRoleTemplate.Enabled = false;
            this.txtRoleTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleTemplate.Location = new System.Drawing.Point(440, 8);
            this.txtRoleTemplate.Name = "txtRoleTemplate";
            this.txtRoleTemplate.ReadOnly = true;
            this.txtRoleTemplate.Size = new System.Drawing.Size(156, 22);
            this.txtRoleTemplate.TabIndex = 448;
            // 
            // chkIsUser
            // 
            this.chkIsUser.AutoSize = true;
            this.chkIsUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIsUser.Location = new System.Drawing.Point(222, 10);
            this.chkIsUser.Name = "chkIsUser";
            this.chkIsUser.Size = new System.Drawing.Size(60, 18);
            this.chkIsUser.TabIndex = 428;
            this.chkIsUser.Text = "Is User";
            this.chkIsUser.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(96, 33);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(200, 22);
            this.txtUserName.TabIndex = 427;
            this.txtUserName.Text = "Asanka Jayasuriya";
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 426;
            this.label1.Text = "User Name";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(440, 59);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(197, 22);
            this.txtDepartment.TabIndex = 422;
            // 
            // txtUserLevel
            // 
            this.txtUserLevel.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserLevel.Enabled = false;
            this.txtUserLevel.Location = new System.Drawing.Point(96, 59);
            this.txtUserLevel.Name = "txtUserLevel";
            this.txtUserLevel.Size = new System.Drawing.Size(150, 22);
            this.txtUserLevel.TabIndex = 421;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(355, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 14);
            this.label18.TabIndex = 425;
            this.label18.Text = "Department";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(13, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 14);
            this.label14.TabIndex = 424;
            this.label14.Text = "User Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(355, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 359;
            this.label3.Text = "User Template";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(96, 8);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(120, 22);
            this.txtUserID.TabIndex = 420;
            this.txtUserID.Text = "Asanka Jayasuriya";
            this.txtUserID.DoubleClick += new System.EventHandler(this.txtUserID_DoubleClick);
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(355, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 359;
            this.label2.Text = "Role Template";
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNewCustomer.Location = new System.Drawing.Point(13, 11);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(57, 14);
            this.lblNewCustomer.TabIndex = 359;
            this.lblNewCustomer.Text = "User Code";
            // 
            // pblBody
            // 
            this.pblBody.Controls.Add(this.chkEditAll);
            this.pblBody.Controls.Add(this.chkNone);
            this.pblBody.Controls.Add(this.chkApprovableAll);
            this.pblBody.Controls.Add(this.chkCheckableAll);
            this.pblBody.Controls.Add(this.btnSave);
            this.pblBody.Controls.Add(this.chkDeleteAll);
            this.pblBody.Controls.Add(this.btnNew);
            this.pblBody.Controls.Add(this.chkWriteAll);
            this.pblBody.Controls.Add(this.chkReadAll);
            this.pblBody.Controls.Add(this.dgvDetail);
            this.pblBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pblBody.Location = new System.Drawing.Point(3, 181);
            this.pblBody.Name = "pblBody";
            this.pblBody.Size = new System.Drawing.Size(662, 375);
            this.pblBody.TabIndex = 448;
            // 
            // chkEditAll
            // 
            this.chkEditAll.AutoSize = true;
            this.chkEditAll.Location = new System.Drawing.Point(439, 10);
            this.chkEditAll.Name = "chkEditAll";
            this.chkEditAll.Size = new System.Drawing.Size(39, 18);
            this.chkEditAll.TabIndex = 457;
            this.chkEditAll.Text = "All";
            this.chkEditAll.UseVisualStyleBackColor = true;
            this.chkEditAll.CheckedChanged += new System.EventHandler(this.chkEditAll_CheckedChanged);
            // 
            // chkNone
            // 
            this.chkNone.AutoSize = true;
            this.chkNone.Location = new System.Drawing.Point(10, 10);
            this.chkNone.Name = "chkNone";
            this.chkNone.Size = new System.Drawing.Size(72, 18);
            this.chkNone.TabIndex = 456;
            this.chkNone.Text = "Select All";
            this.chkNone.UseVisualStyleBackColor = true;
            this.chkNone.CheckedChanged += new System.EventHandler(this.chkNone_CheckedChanged);
            // 
            // chkApprovableAll
            // 
            this.chkApprovableAll.AutoSize = true;
            this.chkApprovableAll.Location = new System.Drawing.Point(562, 10);
            this.chkApprovableAll.Name = "chkApprovableAll";
            this.chkApprovableAll.Size = new System.Drawing.Size(39, 18);
            this.chkApprovableAll.TabIndex = 455;
            this.chkApprovableAll.Text = "All";
            this.chkApprovableAll.UseVisualStyleBackColor = true;
            this.chkApprovableAll.CheckedChanged += new System.EventHandler(this.chkApprovableAll_CheckedChanged);
            // 
            // chkCheckableAll
            // 
            this.chkCheckableAll.AutoSize = true;
            this.chkCheckableAll.Location = new System.Drawing.Point(490, 10);
            this.chkCheckableAll.Name = "chkCheckableAll";
            this.chkCheckableAll.Size = new System.Drawing.Size(39, 18);
            this.chkCheckableAll.TabIndex = 454;
            this.chkCheckableAll.Text = "All";
            this.chkCheckableAll.UseVisualStyleBackColor = true;
            this.chkCheckableAll.CheckedChanged += new System.EventHandler(this.chkCheckableAll_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(577, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 448;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Location = new System.Drawing.Point(390, 10);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.Size = new System.Drawing.Size(39, 18);
            this.chkDeleteAll.TabIndex = 453;
            this.chkDeleteAll.Text = "All";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            this.chkDeleteAll.CheckedChanged += new System.EventHandler(this.chkDeleteAll_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(496, 340);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 449;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkWriteAll
            // 
            this.chkWriteAll.AutoSize = true;
            this.chkWriteAll.Location = new System.Drawing.Point(340, 10);
            this.chkWriteAll.Name = "chkWriteAll";
            this.chkWriteAll.Size = new System.Drawing.Size(39, 18);
            this.chkWriteAll.TabIndex = 452;
            this.chkWriteAll.Text = "All";
            this.chkWriteAll.UseVisualStyleBackColor = true;
            this.chkWriteAll.CheckedChanged += new System.EventHandler(this.chkWriteAll_CheckedChanged);
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Location = new System.Drawing.Point(290, 10);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(39, 18);
            this.chkReadAll.TabIndex = 451;
            this.chkReadAll.Text = "All";
            this.chkReadAll.UseVisualStyleBackColor = true;
            this.chkReadAll.CheckedChanged += new System.EventHandler(this.chkReadAll_CheckedChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormCode,
            this.FormName,
            this.AllowRead,
            this.AllowWrite,
            this.AllowDelete,
            this.AllowUpdate,
            this.AllowCheckable,
            this.AllowApprovable});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 33);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(645, 301);
            this.dgvDetail.TabIndex = 450;
            // 
            // FormCode
            // 
            this.FormCode.DataPropertyName = "FormCode";
            this.FormCode.HeaderText = "Store Code";
            this.FormCode.Name = "FormCode";
            this.FormCode.ReadOnly = true;
            this.FormCode.Width = 65;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormName";
            this.FormName.HeaderText = "Store  Name";
            this.FormName.Name = "FormName";
            this.FormName.ReadOnly = true;
            this.FormName.Width = 210;
            // 
            // AllowRead
            // 
            this.AllowRead.DataPropertyName = "AllowRead";
            this.AllowRead.HeaderText = "Read";
            this.AllowRead.Name = "AllowRead";
            this.AllowRead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowRead.Width = 50;
            // 
            // AllowWrite
            // 
            this.AllowWrite.DataPropertyName = "AllowWrite";
            this.AllowWrite.HeaderText = "Write";
            this.AllowWrite.Name = "AllowWrite";
            this.AllowWrite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowWrite.Width = 50;
            // 
            // AllowDelete
            // 
            this.AllowDelete.DataPropertyName = "AllowDelete";
            this.AllowDelete.HeaderText = "Delete";
            this.AllowDelete.Name = "AllowDelete";
            this.AllowDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowDelete.Width = 50;
            // 
            // AllowUpdate
            // 
            this.AllowUpdate.DataPropertyName = "AllowUpdate";
            this.AllowUpdate.HeaderText = "Edit";
            this.AllowUpdate.Name = "AllowUpdate";
            this.AllowUpdate.Width = 50;
            // 
            // AllowCheckable
            // 
            this.AllowCheckable.DataPropertyName = "AllowCheckable";
            this.AllowCheckable.HeaderText = "Checkable";
            this.AllowCheckable.Name = "AllowCheckable";
            this.AllowCheckable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowCheckable.Width = 73;
            // 
            // AllowApprovable
            // 
            this.AllowApprovable.DataPropertyName = "AllowApprovable";
            this.AllowApprovable.HeaderText = "Approvable";
            this.AllowApprovable.Name = "AllowApprovable";
            this.AllowApprovable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowApprovable.Width = 76;
            // 
            // frmUserPermission_StorWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 559);
            this.Controls.Add(this.pblBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmUserPermission_StorWise";
            this.Text = "Store Wise User Permission";
            this.Load += new System.EventHandler(this.frmCustomerOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasInquiry_KeyDown);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pblBody, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pblBody.ResumeLayout(false);
            this.pblBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.Button btnAddUserTemplate;
        private System.Windows.Forms.Button btnAddRoleTemplate;
        private System.Windows.Forms.TextBox txtUserTemplate;
        private System.Windows.Forms.TextBox txtRoleTemplate;
        private System.Windows.Forms.CheckBox chkIsUser;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtUserLevel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pblBody;
        private System.Windows.Forms.CheckBox chkEditAll;
        private System.Windows.Forms.CheckBox chkNone;
        private System.Windows.Forms.CheckBox chkApprovableAll;
        private System.Windows.Forms.CheckBox chkCheckableAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkDeleteAll;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox chkWriteAll;
        private System.Windows.Forms.CheckBox chkReadAll;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowWrite;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowCheckable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowApprovable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
    }
}