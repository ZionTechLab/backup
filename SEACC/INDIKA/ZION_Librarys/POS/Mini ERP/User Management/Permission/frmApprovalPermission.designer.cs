namespace Digiteq
{
    partial class frmApprovalPermission
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
            this.chkNone = new System.Windows.Forms.CheckBox();
            this.chkApprovableAll = new System.Windows.Forms.CheckBox();
            this.chkCheckableAll = new System.Windows.Forms.CheckBox();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.chkWriteAll = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.FormCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formCategory_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.x1 = new System.Windows.Forms.Panel();
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.chkEditAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x1.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkNone
            // 
            this.chkNone.AutoSize = true;
            this.chkNone.Location = new System.Drawing.Point(205, 177);
            this.chkNone.Name = "chkNone";
            this.chkNone.Size = new System.Drawing.Size(72, 18);
            this.chkNone.TabIndex = 445;
            this.chkNone.Text = "Select All";
            this.chkNone.UseVisualStyleBackColor = true;
            this.chkNone.CheckedChanged += new System.EventHandler(this.chkNone_CheckedChanged);
            // 
            // chkApprovableAll
            // 
            this.chkApprovableAll.AutoSize = true;
            this.chkApprovableAll.Location = new System.Drawing.Point(271, 328);
            this.chkApprovableAll.Name = "chkApprovableAll";
            this.chkApprovableAll.Size = new System.Drawing.Size(39, 18);
            this.chkApprovableAll.TabIndex = 444;
            this.chkApprovableAll.Text = "All";
            this.chkApprovableAll.UseVisualStyleBackColor = true;
            this.chkApprovableAll.CheckedChanged += new System.EventHandler(this.chkApprovableAll_CheckedChanged);
            // 
            // chkCheckableAll
            // 
            this.chkCheckableAll.AutoSize = true;
            this.chkCheckableAll.Location = new System.Drawing.Point(441, 274);
            this.chkCheckableAll.Name = "chkCheckableAll";
            this.chkCheckableAll.Size = new System.Drawing.Size(39, 18);
            this.chkCheckableAll.TabIndex = 443;
            this.chkCheckableAll.Text = "All";
            this.chkCheckableAll.UseVisualStyleBackColor = true;
            this.chkCheckableAll.CheckedChanged += new System.EventHandler(this.chkCheckableAll_CheckedChanged);
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Location = new System.Drawing.Point(414, 250);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.Size = new System.Drawing.Size(39, 18);
            this.chkDeleteAll.TabIndex = 442;
            this.chkDeleteAll.Text = "All";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            this.chkDeleteAll.CheckedChanged += new System.EventHandler(this.chkDeleteAll_CheckedChanged);
            // 
            // chkWriteAll
            // 
            this.chkWriteAll.AutoSize = true;
            this.chkWriteAll.Location = new System.Drawing.Point(364, 250);
            this.chkWriteAll.Name = "chkWriteAll";
            this.chkWriteAll.Size = new System.Drawing.Size(39, 18);
            this.chkWriteAll.TabIndex = 441;
            this.chkWriteAll.Text = "All";
            this.chkWriteAll.UseVisualStyleBackColor = true;
            this.chkWriteAll.CheckedChanged += new System.EventHandler(this.chkWriteAll_CheckedChanged);
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Location = new System.Drawing.Point(497, 180);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(39, 18);
            this.chkReadAll.TabIndex = 440;
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
            this.formCategory_ID,
            this.CategoryName,
            this.AllowRead});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 204);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(528, 292);
            this.dgvDetail.TabIndex = 6;
            // 
            // FormCode
            // 
            this.FormCode.DataPropertyName = "FormCode";
            this.FormCode.HeaderText = "Func Code";
            this.FormCode.Name = "FormCode";
            this.FormCode.ReadOnly = true;
            this.FormCode.Width = 65;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormName";
            this.FormName.HeaderText = "Function Name";
            this.FormName.Name = "FormName";
            this.FormName.ReadOnly = true;
            this.FormName.Width = 210;
            // 
            // formCategory_ID
            // 
            this.formCategory_ID.DataPropertyName = "formCategory_ID";
            this.formCategory_ID.HeaderText = "From Category";
            this.formCategory_ID.Name = "formCategory_ID";
            this.formCategory_ID.Visible = false;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 164;
            // 
            // AllowRead
            // 
            this.AllowRead.DataPropertyName = "AllowRead";
            this.AllowRead.HeaderText = "Active";
            this.AllowRead.Name = "AllowRead";
            this.AllowRead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowRead.Width = 70;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.btnAddUserTemplate);
            this.x1.Controls.Add(this.btnAddRoleTemplate);
            this.x1.Controls.Add(this.txtUserTemplate);
            this.x1.Controls.Add(this.txtRoleTemplate);
            this.x1.Controls.Add(this.chkIsUser);
            this.x1.Controls.Add(this.txtUserName);
            this.x1.Controls.Add(this.label1);
            this.x1.Controls.Add(this.txtDepartment);
            this.x1.Controls.Add(this.txtUserLevel);
            this.x1.Controls.Add(this.label18);
            this.x1.Controls.Add(this.label14);
            this.x1.Controls.Add(this.label3);
            this.x1.Controls.Add(this.txtUserID);
            this.x1.Controls.Add(this.label2);
            this.x1.Controls.Add(this.lblNewCustomer);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(528, 89);
            this.x1.TabIndex = 0;
            // 
            // btnAddUserTemplate
            // 
            this.btnAddUserTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUserTemplate.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddUserTemplate.Location = new System.Drawing.Point(496, 30);
            this.btnAddUserTemplate.Name = "btnAddUserTemplate";
            this.btnAddUserTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnAddUserTemplate.TabIndex = 449;
            this.btnAddUserTemplate.UseVisualStyleBackColor = true;
            // 
            // btnAddRoleTemplate
            // 
            this.btnAddRoleTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoleTemplate.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddRoleTemplate.Location = new System.Drawing.Point(496, 5);
            this.btnAddRoleTemplate.Name = "btnAddRoleTemplate";
            this.btnAddRoleTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnAddRoleTemplate.TabIndex = 449;
            this.btnAddRoleTemplate.UseVisualStyleBackColor = true;
            // 
            // txtUserTemplate
            // 
            this.txtUserTemplate.BackColor = System.Drawing.Color.LightGray;
            this.txtUserTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTemplate.Location = new System.Drawing.Point(368, 30);
            this.txtUserTemplate.Name = "txtUserTemplate";
            this.txtUserTemplate.ReadOnly = true;
            this.txtUserTemplate.Size = new System.Drawing.Size(120, 22);
            this.txtUserTemplate.TabIndex = 448;
            // 
            // txtRoleTemplate
            // 
            this.txtRoleTemplate.BackColor = System.Drawing.Color.LightGray;
            this.txtRoleTemplate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleTemplate.Location = new System.Drawing.Point(368, 5);
            this.txtRoleTemplate.Name = "txtRoleTemplate";
            this.txtRoleTemplate.ReadOnly = true;
            this.txtRoleTemplate.Size = new System.Drawing.Size(122, 22);
            this.txtRoleTemplate.TabIndex = 448;
            // 
            // chkIsUser
            // 
            this.chkIsUser.AutoSize = true;
            this.chkIsUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsUser.Location = new System.Drawing.Point(221, 7);
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
            this.txtUserName.Location = new System.Drawing.Point(95, 30);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(164, 22);
            this.txtUserName.TabIndex = 427;
            this.txtUserName.Text = "Asanka Jayasuriya";
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 426;
            this.label1.Text = "User Name";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(368, 56);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(150, 22);
            this.txtDepartment.TabIndex = 422;
            // 
            // txtUserLevel
            // 
            this.txtUserLevel.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserLevel.Enabled = false;
            this.txtUserLevel.Location = new System.Drawing.Point(95, 56);
            this.txtUserLevel.Name = "txtUserLevel";
            this.txtUserLevel.Size = new System.Drawing.Size(164, 22);
            this.txtUserLevel.TabIndex = 421;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label18.Location = new System.Drawing.Point(288, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 14);
            this.label18.TabIndex = 425;
            this.label18.Text = "Department";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label14.Location = new System.Drawing.Point(12, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 14);
            this.label14.TabIndex = 424;
            this.label14.Text = "User Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(286, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 359;
            this.label3.Text = "User Template";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(95, 5);
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
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(286, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 359;
            this.label2.Text = "Role Template";
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNewCustomer.Location = new System.Drawing.Point(12, 8);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(57, 14);
            this.lblNewCustomer.TabIndex = 359;
            this.lblNewCustomer.Text = "User Code";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(8, 171);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(89, 171);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(95, 27);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(158, 22);
            this.txtCategory.TabIndex = 451;
            this.txtCategory.Text = "Asanka Jayasuriya";
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 450;
            this.label4.Text = "Module Name";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label6);
            this.z1.Controls.Add(this.label5);
            this.z1.Controls.Add(this.txtFormName);
            this.z1.Controls.Add(this.txtCategory);
            this.z1.Controls.Add(this.label4);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(8, 104);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(528, 62);
            this.z1.TabIndex = 446;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(-1, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(565, 18);
            this.label6.TabIndex = 566;
            this.label6.Text = "Module Filter";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(288, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 453;
            this.label5.Text = "Form Name";
            // 
            // txtFormName
            // 
            this.txtFormName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormName.Location = new System.Drawing.Point(368, 27);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(150, 22);
            this.txtFormName.TabIndex = 452;
            this.txtFormName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFormName_KeyUp);
            // 
            // chkEditAll
            // 
            this.chkEditAll.AutoSize = true;
            this.chkEditAll.Location = new System.Drawing.Point(459, 250);
            this.chkEditAll.Name = "chkEditAll";
            this.chkEditAll.Size = new System.Drawing.Size(39, 18);
            this.chkEditAll.TabIndex = 447;
            this.chkEditAll.Text = "All";
            this.chkEditAll.UseVisualStyleBackColor = true;
            this.chkEditAll.CheckedChanged += new System.EventHandler(this.chkEditAll_CheckedChanged);
            // 
            // frmApprovalPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(542, 503);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.chkEditAll);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.chkNone);
            this.Controls.Add(this.chkApprovableAll);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.chkCheckableAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkDeleteAll);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.chkWriteAll);
            this.Controls.Add(this.chkReadAll);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmApprovalPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Permission";
            this.Load += new System.EventHandler(this.frmCustomerOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasInquiry_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtUserLevel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkApprovableAll;
        private System.Windows.Forms.CheckBox chkCheckableAll;
        private System.Windows.Forms.CheckBox chkDeleteAll;
        private System.Windows.Forms.CheckBox chkWriteAll;
        private System.Windows.Forms.CheckBox chkReadAll;
        private System.Windows.Forms.CheckBox chkNone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsUser;
        private System.Windows.Forms.Button btnAddUserTemplate;
        private System.Windows.Forms.Button btnAddRoleTemplate;
        private System.Windows.Forms.TextBox txtUserTemplate;
        private System.Windows.Forms.TextBox txtRoleTemplate;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEditAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn formCategory_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowRead;

    }
}