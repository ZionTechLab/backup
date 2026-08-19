namespace Digiteq
{
    partial class frmPendingApprovals
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tbpChecking = new System.Windows.Forms.TabPage();
            this.pnlCheck = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbModuleCheck = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComBranchCheck = new System.Windows.Forms.ComboBox();
            this.btnClearCheck = new System.Windows.Forms.Button();
            this.btnSaveCheck = new System.Windows.Forms.Button();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.dgvCheckPending = new SEACC_DataGrid();
            this.formID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formNameChk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvFormCheck = new SEACC_DataGrid();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpApprove = new System.Windows.Forms.TabPage();
            this.pnlApprove = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbModuleApprove = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbComBranchApprove = new System.Windows.Forms.ComboBox();
            this.btnClearApprove = new System.Windows.Forms.Button();
            this.chkApprove = new System.Windows.Forms.CheckBox();
            this.dgvFormApprove = new SEACC_DataGrid();
            this.noApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formNameApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_SaveApprove = new System.Windows.Forms.Button();
            this.dgvApprovalPending = new SEACC_DataGrid();
            this.formIDApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formNameA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnIDApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnDateApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckApp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isApprove = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbControl.SuspendLayout();
            this.tbpChecking.SuspendLayout();
            this.pnlCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormCheck)).BeginInit();
            this.tbpApprove.SuspendLayout();
            this.pnlApprove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormApprove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalPending)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tbpChecking);
            this.tbControl.Controls.Add(this.tbpApprove);
            this.tbControl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControl.Location = new System.Drawing.Point(4, 4);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(825, 566);
            this.tbControl.TabIndex = 2;
            this.tbControl.SelectedIndexChanged += new System.EventHandler(this.tbControl_SelectedIndexChanged);
            // 
            // tbpChecking
            // 
            this.tbpChecking.Controls.Add(this.pnlCheck);
            this.tbpChecking.Location = new System.Drawing.Point(4, 22);
            this.tbpChecking.Name = "tbpChecking";
            this.tbpChecking.Padding = new System.Windows.Forms.Padding(3);
            this.tbpChecking.Size = new System.Drawing.Size(817, 540);
            this.tbpChecking.TabIndex = 0;
            this.tbpChecking.Text = "Checking";
            this.tbpChecking.UseVisualStyleBackColor = true;
            // 
            // pnlCheck
            // 
            this.pnlCheck.Controls.Add(this.label3);
            this.pnlCheck.Controls.Add(this.cmbModuleCheck);
            this.pnlCheck.Controls.Add(this.label1);
            this.pnlCheck.Controls.Add(this.cmbComBranchCheck);
            this.pnlCheck.Controls.Add(this.btnClearCheck);
            this.pnlCheck.Controls.Add(this.btnSaveCheck);
            this.pnlCheck.Controls.Add(this.chkCheck);
            this.pnlCheck.Controls.Add(this.dgvCheckPending);
            this.pnlCheck.Controls.Add(this.dgvFormCheck);
            this.pnlCheck.Location = new System.Drawing.Point(4, 6);
            this.pnlCheck.Name = "pnlCheck";
            this.pnlCheck.Size = new System.Drawing.Size(808, 528);
            this.pnlCheck.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(353, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 496;
            this.label3.Text = "Module";
            // 
            // cmbModuleCheck
            // 
            this.cmbModuleCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuleCheck.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModuleCheck.FormattingEnabled = true;
            this.cmbModuleCheck.Location = new System.Drawing.Point(408, 6);
            this.cmbModuleCheck.Name = "cmbModuleCheck";
            this.cmbModuleCheck.Size = new System.Drawing.Size(220, 22);
            this.cmbModuleCheck.TabIndex = 495;
            this.cmbModuleCheck.SelectedIndexChanged += new System.EventHandler(this.cmbModuleCheck_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 494;
            this.label1.Text = "Company Branch";
            // 
            // cmbComBranchCheck
            // 
            this.cmbComBranchCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranchCheck.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranchCheck.FormattingEnabled = true;
            this.cmbComBranchCheck.Location = new System.Drawing.Point(103, 6);
            this.cmbComBranchCheck.Name = "cmbComBranchCheck";
            this.cmbComBranchCheck.Size = new System.Drawing.Size(225, 22);
            this.cmbComBranchCheck.TabIndex = 493;
            this.cmbComBranchCheck.SelectedIndexChanged += new System.EventHandler(this.cmbComBranchCheck_SelectedIndexChanged);
            // 
            // btnClearCheck
            // 
            this.btnClearCheck.BackgroundImage = global::Digiteq.Properties.Resources.add_page;
            this.btnClearCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCheck.Location = new System.Drawing.Point(645, 493);
            this.btnClearCheck.Name = "btnClearCheck";
            this.btnClearCheck.Size = new System.Drawing.Size(75, 25);
            this.btnClearCheck.TabIndex = 6;
            this.btnClearCheck.Text = "Clear";
            this.btnClearCheck.UseVisualStyleBackColor = true;
            this.btnClearCheck.Click += new System.EventHandler(this.btnClearCheck_Click);
            // 
            // btnSaveCheck
            // 
            this.btnSaveCheck.BackgroundImage = global::Digiteq.Properties.Resources.accept;
            this.btnSaveCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCheck.Location = new System.Drawing.Point(727, 493);
            this.btnSaveCheck.Name = "btnSaveCheck";
            this.btnSaveCheck.Size = new System.Drawing.Size(75, 25);
            this.btnSaveCheck.TabIndex = 5;
            this.btnSaveCheck.Text = "Save";
            this.btnSaveCheck.UseVisualStyleBackColor = true;
            this.btnSaveCheck.Click += new System.EventHandler(this.btnSaveCheck_Click);
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheck.Location = new System.Drawing.Point(725, 9);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(79, 21);
            this.chkCheck.TabIndex = 2;
            this.chkCheck.Text = "Select All";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            // 
            // dgvCheckPending
            // 
            this.dgvCheckPending.AllowUserToAddRows = false;
            this.dgvCheckPending.AllowUserToDeleteRows = false;
            this.dgvCheckPending.AllowUserToResizeRows = false;
            this.dgvCheckPending.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvCheckPending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheckPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCheckPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formID,
            this.formNameChk,
            this.txnID,
            this.txnDate,
            this.remarks,
            this.amount,
            this.isCheck});
            this.dgvCheckPending.EnableHeadersVisualStyles = false;
            this.dgvCheckPending.Location = new System.Drawing.Point(227, 39);
            this.dgvCheckPending.MultiSelect = false;
            this.dgvCheckPending.Name = "dgvCheckPending";
            this.dgvCheckPending.RowHeadersVisible = false;
            this.dgvCheckPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckPending.Size = new System.Drawing.Size(573, 448);
            this.dgvCheckPending.TabIndex = 1;
            this.dgvCheckPending.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCheckPending_CellMouseClick);
            // 
            // formID
            // 
            this.formID.DataPropertyName = "formID";
            this.formID.HeaderText = "Form ID";
            this.formID.Name = "formID";
            this.formID.ReadOnly = true;
            this.formID.Visible = false;
            // 
            // formNameChk
            // 
            this.formNameChk.DataPropertyName = "formName";
            this.formNameChk.HeaderText = "Form Name";
            this.formNameChk.Name = "formNameChk";
            this.formNameChk.ReadOnly = true;
            this.formNameChk.Visible = false;
            // 
            // txnID
            // 
            this.txnID.DataPropertyName = "txnID";
            this.txnID.HeaderText = "Txn ID";
            this.txnID.Name = "txnID";
            this.txnID.ReadOnly = true;
            // 
            // txnDate
            // 
            this.txnDate.DataPropertyName = "txnDate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txnDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.txnDate.HeaderText = "Date";
            this.txnDate.Name = "txnDate";
            this.txnDate.ReadOnly = true;
            this.txnDate.Width = 80;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "References";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 215;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount.DefaultCellStyle = dataGridViewCellStyle10;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // isCheck
            // 
            this.isCheck.DataPropertyName = "isCheck";
            this.isCheck.HeaderText = "Check";
            this.isCheck.Name = "isCheck";
            this.isCheck.ReadOnly = true;
            this.isCheck.Width = 60;
            // 
            // dgvFormCheck
            // 
            this.dgvFormCheck.AllowUserToAddRows = false;
            this.dgvFormCheck.AllowUserToDeleteRows = false;
            this.dgvFormCheck.AllowUserToResizeColumns = false;
            this.dgvFormCheck.AllowUserToResizeRows = false;
            this.dgvFormCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFormCheck.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFormCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.formName});
            this.dgvFormCheck.EnableHeadersVisualStyles = false;
            this.dgvFormCheck.Location = new System.Drawing.Point(8, 39);
            this.dgvFormCheck.MultiSelect = false;
            this.dgvFormCheck.Name = "dgvFormCheck";
            this.dgvFormCheck.RowHeadersVisible = false;
            this.dgvFormCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormCheck.Size = new System.Drawing.Size(205, 448);
            this.dgvFormCheck.TabIndex = 0;
            this.dgvFormCheck.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFormCheck_CellMouseClick);
            // 
            // no
            // 
            this.no.DataPropertyName = "formID";
            this.no.HeaderText = "Form ID";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Visible = false;
            // 
            // formName
            // 
            this.formName.DataPropertyName = "formName";
            this.formName.HeaderText = "Form";
            this.formName.Name = "formName";
            this.formName.ReadOnly = true;
            this.formName.Width = 200;
            // 
            // tbpApprove
            // 
            this.tbpApprove.Controls.Add(this.pnlApprove);
            this.tbpApprove.Location = new System.Drawing.Point(4, 22);
            this.tbpApprove.Name = "tbpApprove";
            this.tbpApprove.Padding = new System.Windows.Forms.Padding(3);
            this.tbpApprove.Size = new System.Drawing.Size(817, 540);
            this.tbpApprove.TabIndex = 1;
            this.tbpApprove.Text = "Approve";
            this.tbpApprove.UseVisualStyleBackColor = true;
            // 
            // pnlApprove
            // 
            this.pnlApprove.Controls.Add(this.label4);
            this.pnlApprove.Controls.Add(this.cmbModuleApprove);
            this.pnlApprove.Controls.Add(this.label2);
            this.pnlApprove.Controls.Add(this.cmbComBranchApprove);
            this.pnlApprove.Controls.Add(this.btnClearApprove);
            this.pnlApprove.Controls.Add(this.chkApprove);
            this.pnlApprove.Controls.Add(this.dgvFormApprove);
            this.pnlApprove.Controls.Add(this.btn_SaveApprove);
            this.pnlApprove.Controls.Add(this.dgvApprovalPending);
            this.pnlApprove.Location = new System.Drawing.Point(4, 6);
            this.pnlApprove.Name = "pnlApprove";
            this.pnlApprove.Size = new System.Drawing.Size(808, 528);
            this.pnlApprove.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(358, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 498;
            this.label4.Text = "Module";
            // 
            // cmbModuleApprove
            // 
            this.cmbModuleApprove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuleApprove.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModuleApprove.FormattingEnabled = true;
            this.cmbModuleApprove.Location = new System.Drawing.Point(413, 6);
            this.cmbModuleApprove.Name = "cmbModuleApprove";
            this.cmbModuleApprove.Size = new System.Drawing.Size(220, 22);
            this.cmbModuleApprove.TabIndex = 497;
            this.cmbModuleApprove.SelectedIndexChanged += new System.EventHandler(this.cmbModuleApprove_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 496;
            this.label2.Text = "Company Branch";
            // 
            // cmbComBranchApprove
            // 
            this.cmbComBranchApprove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranchApprove.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranchApprove.FormattingEnabled = true;
            this.cmbComBranchApprove.Location = new System.Drawing.Point(103, 6);
            this.cmbComBranchApprove.Name = "cmbComBranchApprove";
            this.cmbComBranchApprove.Size = new System.Drawing.Size(225, 22);
            this.cmbComBranchApprove.TabIndex = 495;
            this.cmbComBranchApprove.SelectedIndexChanged += new System.EventHandler(this.cmbComBranchApprove_SelectedIndexChanged);
            // 
            // btnClearApprove
            // 
            this.btnClearApprove.BackgroundImage = global::Digiteq.Properties.Resources.add_page;
            this.btnClearApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearApprove.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearApprove.Location = new System.Drawing.Point(645, 493);
            this.btnClearApprove.Name = "btnClearApprove";
            this.btnClearApprove.Size = new System.Drawing.Size(75, 25);
            this.btnClearApprove.TabIndex = 4;
            this.btnClearApprove.Text = "Clear";
            this.btnClearApprove.UseVisualStyleBackColor = true;
            this.btnClearApprove.Click += new System.EventHandler(this.btnClearApprove_Click);
            // 
            // chkApprove
            // 
            this.chkApprove.AutoSize = true;
            this.chkApprove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApprove.Location = new System.Drawing.Point(725, 7);
            this.chkApprove.Name = "chkApprove";
            this.chkApprove.Size = new System.Drawing.Size(79, 21);
            this.chkApprove.TabIndex = 4;
            this.chkApprove.Text = "Select All";
            this.chkApprove.UseVisualStyleBackColor = true;
            this.chkApprove.CheckedChanged += new System.EventHandler(this.chkApprove_CheckedChanged);
            // 
            // dgvFormApprove
            // 
            this.dgvFormApprove.AllowUserToAddRows = false;
            this.dgvFormApprove.AllowUserToDeleteRows = false;
            this.dgvFormApprove.AllowUserToResizeColumns = false;
            this.dgvFormApprove.AllowUserToResizeRows = false;
            this.dgvFormApprove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFormApprove.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFormApprove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noApp,
            this.formNameApp});
            this.dgvFormApprove.EnableHeadersVisualStyles = false;
            this.dgvFormApprove.Location = new System.Drawing.Point(8, 39);
            this.dgvFormApprove.MultiSelect = false;
            this.dgvFormApprove.Name = "dgvFormApprove";
            this.dgvFormApprove.RowHeadersVisible = false;
            this.dgvFormApprove.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormApprove.Size = new System.Drawing.Size(205, 448);
            this.dgvFormApprove.TabIndex = 3;
            this.dgvFormApprove.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFormApprove_CellMouseClick);
            // 
            // noApp
            // 
            this.noApp.DataPropertyName = "formIDApp";
            this.noApp.HeaderText = "Form ID";
            this.noApp.Name = "noApp";
            this.noApp.ReadOnly = true;
            this.noApp.Visible = false;
            // 
            // formNameApp
            // 
            this.formNameApp.DataPropertyName = "formNameApp";
            this.formNameApp.HeaderText = "Form";
            this.formNameApp.Name = "formNameApp";
            this.formNameApp.ReadOnly = true;
            this.formNameApp.Width = 200;
            // 
            // btn_SaveApprove
            // 
            this.btn_SaveApprove.BackgroundImage = global::Digiteq.Properties.Resources.accept;
            this.btn_SaveApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_SaveApprove.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveApprove.Location = new System.Drawing.Point(727, 493);
            this.btn_SaveApprove.Name = "btn_SaveApprove";
            this.btn_SaveApprove.Size = new System.Drawing.Size(75, 25);
            this.btn_SaveApprove.TabIndex = 3;
            this.btn_SaveApprove.Text = "Save";
            this.btn_SaveApprove.UseVisualStyleBackColor = true;
            this.btn_SaveApprove.Click += new System.EventHandler(this.btn_SaveApprove_Click);
            // 
            // dgvApprovalPending
            // 
            this.dgvApprovalPending.AllowUserToAddRows = false;
            this.dgvApprovalPending.AllowUserToDeleteRows = false;
            this.dgvApprovalPending.AllowUserToResizeRows = false;
            this.dgvApprovalPending.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvApprovalPending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApprovalPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvApprovalPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formIDApp,
            this.formNameA,
            this.txnIDApp,
            this.txnDateApp,
            this.remarksApp,
            this.amountApp,
            this.isCheckApp,
            this.isApprove});
            this.dgvApprovalPending.EnableHeadersVisualStyles = false;
            this.dgvApprovalPending.Location = new System.Drawing.Point(227, 39);
            this.dgvApprovalPending.MultiSelect = false;
            this.dgvApprovalPending.Name = "dgvApprovalPending";
            this.dgvApprovalPending.RowHeadersVisible = false;
            this.dgvApprovalPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalPending.Size = new System.Drawing.Size(573, 448);
            this.dgvApprovalPending.TabIndex = 2;
            this.dgvApprovalPending.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApprovalPending_CellMouseClick);
            // 
            // formIDApp
            // 
            this.formIDApp.DataPropertyName = "formIDApp";
            this.formIDApp.HeaderText = "Form ID";
            this.formIDApp.Name = "formIDApp";
            this.formIDApp.ReadOnly = true;
            this.formIDApp.Visible = false;
            // 
            // formNameA
            // 
            this.formNameA.DataPropertyName = "formNameApp";
            this.formNameA.HeaderText = "Form Name";
            this.formNameA.Name = "formNameA";
            this.formNameA.ReadOnly = true;
            this.formNameA.Visible = false;
            // 
            // txnIDApp
            // 
            this.txnIDApp.DataPropertyName = "txnIDApp";
            this.txnIDApp.HeaderText = "Txn ID";
            this.txnIDApp.Name = "txnIDApp";
            this.txnIDApp.ReadOnly = true;
            // 
            // txnDateApp
            // 
            this.txnDateApp.DataPropertyName = "txnDateApp";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txnDateApp.DefaultCellStyle = dataGridViewCellStyle11;
            this.txnDateApp.HeaderText = "Date";
            this.txnDateApp.Name = "txnDateApp";
            this.txnDateApp.ReadOnly = true;
            this.txnDateApp.Width = 80;
            // 
            // remarksApp
            // 
            this.remarksApp.DataPropertyName = "remarksApp";
            this.remarksApp.HeaderText = "References";
            this.remarksApp.Name = "remarksApp";
            this.remarksApp.ReadOnly = true;
            this.remarksApp.Width = 155;
            // 
            // amountApp
            // 
            this.amountApp.DataPropertyName = "amountApp";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountApp.DefaultCellStyle = dataGridViewCellStyle12;
            this.amountApp.HeaderText = "Amount";
            this.amountApp.Name = "amountApp";
            this.amountApp.ReadOnly = true;
            // 
            // isCheckApp
            // 
            this.isCheckApp.DataPropertyName = "isCheckApp";
            this.isCheckApp.HeaderText = "Check";
            this.isCheckApp.Name = "isCheckApp";
            this.isCheckApp.ReadOnly = true;
            this.isCheckApp.Width = 60;
            // 
            // isApprove
            // 
            this.isApprove.DataPropertyName = "isApprove";
            this.isApprove.HeaderText = "Approve";
            this.isApprove.Name = "isApprove";
            this.isApprove.ReadOnly = true;
            this.isApprove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isApprove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isApprove.Width = 60;
            // 
            // frmPendingApprovals
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbControl);
            this.Name = "frmPendingApprovals";
            this.Size = new System.Drawing.Size(840, 630);
            this.Load += new System.EventHandler(this.frmPendingApprovals_Load);
            this.Controls.SetChildIndex(this.tbControl, 0);
            this.tbControl.ResumeLayout(false);
            this.tbpChecking.ResumeLayout(false);
            this.pnlCheck.ResumeLayout(false);
            this.pnlCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormCheck)).EndInit();
            this.tbpApprove.ResumeLayout(false);
            this.pnlApprove.ResumeLayout(false);
            this.pnlApprove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormApprove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalPending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tbpChecking;
        private System.Windows.Forms.TabPage tbpApprove;
        private System.Windows.Forms.Panel pnlCheck;
        private SEACC_DataGrid dgvFormCheck;
        private SEACC_DataGrid dgvCheckPending;
        private System.Windows.Forms.Button btn_SaveApprove;
        private System.Windows.Forms.Button btnClearApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn formName;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.Panel pnlApprove;
        private System.Windows.Forms.CheckBox chkApprove;
        private SEACC_DataGrid dgvFormApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn noApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn formNameApp;
        private SEACC_DataGrid dgvApprovalPending;
        private System.Windows.Forms.Button btnClearCheck;
        private System.Windows.Forms.Button btnSaveCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbComBranchCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbComBranchApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn formID;
        private System.Windows.Forms.DataGridViewTextBoxColumn formNameChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn formIDApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn formNameA;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnIDApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnDateApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountApp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckApp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isApprove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbModuleCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbModuleApprove;
    }
}
