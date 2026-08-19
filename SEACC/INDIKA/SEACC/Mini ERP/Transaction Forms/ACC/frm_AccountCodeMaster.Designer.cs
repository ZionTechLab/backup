namespace Digiteq.Transaction_Forms.ACC
{
    partial class frm_AccountCodeMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AccountCodeMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbControlAcc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.cmbAcctCodeStatus = new System.Windows.Forms.ComboBox();
            this.lblAcctCode = new System.Windows.Forms.Label();
            this.txtAcctCodeName = new System.Windows.Forms.TextBox();
            this.txtAcctCode = new System.Windows.Forms.TextBox();
            this.lblAcctCodeName = new System.Windows.Forms.Label();
            this.lblAcctCodeStatus = new System.Windows.Forms.Label();
            this.txtAcctCodeType2Name = new System.Windows.Forms.TextBox();
            this.txtAcctCodeType2Code = new System.Windows.Forms.TextBox();
            this.lblAcctCodeType2Code = new System.Windows.Forms.Label();
            this.txtAcctCodeSubGlCode = new System.Windows.Forms.TextBox();
            this.txtAcctCodeTypeName = new System.Windows.Forms.TextBox();
            this.txtAcctCodeGlName = new System.Windows.Forms.TextBox();
            this.txtAcctCodeGlCode = new System.Windows.Forms.TextBox();
            this.txtAcctCodeSubGLName = new System.Windows.Forms.TextBox();
            this.txtAcctCodeTypeCode = new System.Windows.Forms.TextBox();
            this.lblAcctCodeGlCode = new System.Windows.Forms.Label();
            this.lblAcctCodeSubGlCode = new System.Windows.Forms.Label();
            this.lblAcctCodeTypeCode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.receipt_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setteledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCommishion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfCollecters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devidedCommishion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(798, 419);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.cmbControlAcc);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblSortOrder);
            this.panel2.Controls.Add(this.txtSortOrder);
            this.panel2.Controls.Add(this.cmbAcctCodeStatus);
            this.panel2.Controls.Add(this.lblAcctCode);
            this.panel2.Controls.Add(this.txtAcctCodeName);
            this.panel2.Controls.Add(this.txtAcctCode);
            this.panel2.Controls.Add(this.lblAcctCodeName);
            this.panel2.Controls.Add(this.lblAcctCodeStatus);
            this.panel2.Controls.Add(this.txtAcctCodeType2Name);
            this.panel2.Controls.Add(this.txtAcctCodeType2Code);
            this.panel2.Controls.Add(this.lblAcctCodeType2Code);
            this.panel2.Controls.Add(this.txtAcctCodeSubGlCode);
            this.panel2.Controls.Add(this.txtAcctCodeTypeName);
            this.panel2.Controls.Add(this.txtAcctCodeGlName);
            this.panel2.Controls.Add(this.txtAcctCodeGlCode);
            this.panel2.Controls.Add(this.txtAcctCodeSubGLName);
            this.panel2.Controls.Add(this.txtAcctCodeTypeCode);
            this.panel2.Controls.Add(this.lblAcctCodeGlCode);
            this.panel2.Controls.Add(this.lblAcctCodeSubGlCode);
            this.panel2.Controls.Add(this.lblAcctCodeTypeCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 151);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(629, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(548, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "Cancel";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(467, 113);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 67;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // cmbControlAcc
            // 
            this.cmbControlAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbControlAcc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cmbControlAcc.FormattingEnabled = true;
            this.cmbControlAcc.Location = new System.Drawing.Point(557, 52);
            this.cmbControlAcc.Name = "cmbControlAcc";
            this.cmbControlAcc.Size = new System.Drawing.Size(138, 22);
            this.cmbControlAcc.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(464, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 65;
            this.label5.Text = "Control Account";
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortOrder.ForeColor = System.Drawing.Color.Black;
            this.lblSortOrder.Location = new System.Drawing.Point(464, 12);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(61, 14);
            this.lblSortOrder.TabIndex = 64;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortOrder.Location = new System.Drawing.Point(557, 8);
            this.txtSortOrder.MaxLength = 4;
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Size = new System.Drawing.Size(138, 22);
            this.txtSortOrder.TabIndex = 63;
            // 
            // cmbAcctCodeStatus
            // 
            this.cmbAcctCodeStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cmbAcctCodeStatus.FormattingEnabled = true;
            this.cmbAcctCodeStatus.Location = new System.Drawing.Point(557, 30);
            this.cmbAcctCodeStatus.Name = "cmbAcctCodeStatus";
            this.cmbAcctCodeStatus.Size = new System.Drawing.Size(138, 22);
            this.cmbAcctCodeStatus.TabIndex = 62;
            // 
            // lblAcctCode
            // 
            this.lblAcctCode.AutoSize = true;
            this.lblAcctCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCode.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCode.Location = new System.Drawing.Point(17, 12);
            this.lblAcctCode.Name = "lblAcctCode";
            this.lblAcctCode.Size = new System.Drawing.Size(58, 14);
            this.lblAcctCode.TabIndex = 57;
            this.lblAcctCode.Text = "Acct.Code";
            // 
            // txtAcctCodeName
            // 
            this.txtAcctCodeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeName.Location = new System.Drawing.Point(116, 30);
            this.txtAcctCodeName.Name = "txtAcctCodeName";
            this.txtAcctCodeName.Size = new System.Drawing.Size(303, 22);
            this.txtAcctCodeName.TabIndex = 61;
            // 
            // txtAcctCode
            // 
            this.txtAcctCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAcctCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCode.Location = new System.Drawing.Point(116, 8);
            this.txtAcctCode.Name = "txtAcctCode";
            this.txtAcctCode.Size = new System.Drawing.Size(303, 22);
            this.txtAcctCode.TabIndex = 58;
            // 
            // lblAcctCodeName
            // 
            this.lblAcctCodeName.AutoSize = true;
            this.lblAcctCodeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeName.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeName.Location = new System.Drawing.Point(17, 34);
            this.lblAcctCodeName.Name = "lblAcctCodeName";
            this.lblAcctCodeName.Size = new System.Drawing.Size(63, 14);
            this.lblAcctCodeName.TabIndex = 59;
            this.lblAcctCodeName.Text = "Acct.Name";
            // 
            // lblAcctCodeStatus
            // 
            this.lblAcctCodeStatus.AutoSize = true;
            this.lblAcctCodeStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeStatus.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeStatus.Location = new System.Drawing.Point(464, 34);
            this.lblAcctCodeStatus.Name = "lblAcctCodeStatus";
            this.lblAcctCodeStatus.Size = new System.Drawing.Size(41, 14);
            this.lblAcctCodeStatus.TabIndex = 60;
            this.lblAcctCodeStatus.Text = "Status";
            // 
            // txtAcctCodeType2Name
            // 
            this.txtAcctCodeType2Name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAcctCodeType2Name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeType2Name.ForeColor = System.Drawing.Color.DimGray;
            this.txtAcctCodeType2Name.Location = new System.Drawing.Point(206, 118);
            this.txtAcctCodeType2Name.Name = "txtAcctCodeType2Name";
            this.txtAcctCodeType2Name.ReadOnly = true;
            this.txtAcctCodeType2Name.Size = new System.Drawing.Size(213, 22);
            this.txtAcctCodeType2Name.TabIndex = 55;
            this.txtAcctCodeType2Name.Text = "CASH";
            // 
            // txtAcctCodeType2Code
            // 
            this.txtAcctCodeType2Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAcctCodeType2Code.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeType2Code.Location = new System.Drawing.Point(116, 118);
            this.txtAcctCodeType2Code.Name = "txtAcctCodeType2Code";
            this.txtAcctCodeType2Code.ReadOnly = true;
            this.txtAcctCodeType2Code.Size = new System.Drawing.Size(86, 22);
            this.txtAcctCodeType2Code.TabIndex = 56;
            this.txtAcctCodeType2Code.Text = "0002511";
            // 
            // lblAcctCodeType2Code
            // 
            this.lblAcctCodeType2Code.AutoSize = true;
            this.lblAcctCodeType2Code.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeType2Code.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeType2Code.Location = new System.Drawing.Point(17, 121);
            this.lblAcctCodeType2Code.Name = "lblAcctCodeType2Code";
            this.lblAcctCodeType2Code.Size = new System.Drawing.Size(97, 14);
            this.lblAcctCodeType2Code.TabIndex = 54;
            this.lblAcctCodeType2Code.Text = "Acct. Type 2 Code";
            // 
            // txtAcctCodeSubGlCode
            // 
            this.txtAcctCodeSubGlCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAcctCodeSubGlCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeSubGlCode.Location = new System.Drawing.Point(116, 74);
            this.txtAcctCodeSubGlCode.Name = "txtAcctCodeSubGlCode";
            this.txtAcctCodeSubGlCode.ReadOnly = true;
            this.txtAcctCodeSubGlCode.Size = new System.Drawing.Size(86, 22);
            this.txtAcctCodeSubGlCode.TabIndex = 47;
            this.txtAcctCodeSubGlCode.Text = "0002510";
            // 
            // txtAcctCodeTypeName
            // 
            this.txtAcctCodeTypeName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAcctCodeTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeTypeName.ForeColor = System.Drawing.Color.DimGray;
            this.txtAcctCodeTypeName.Location = new System.Drawing.Point(206, 96);
            this.txtAcctCodeTypeName.Name = "txtAcctCodeTypeName";
            this.txtAcctCodeTypeName.ReadOnly = true;
            this.txtAcctCodeTypeName.Size = new System.Drawing.Size(213, 22);
            this.txtAcctCodeTypeName.TabIndex = 46;
            this.txtAcctCodeTypeName.Text = "CASH";
            // 
            // txtAcctCodeGlName
            // 
            this.txtAcctCodeGlName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAcctCodeGlName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeGlName.ForeColor = System.Drawing.Color.DimGray;
            this.txtAcctCodeGlName.Location = new System.Drawing.Point(206, 52);
            this.txtAcctCodeGlName.Name = "txtAcctCodeGlName";
            this.txtAcctCodeGlName.ReadOnly = true;
            this.txtAcctCodeGlName.Size = new System.Drawing.Size(213, 22);
            this.txtAcctCodeGlName.TabIndex = 52;
            this.txtAcctCodeGlName.Text = "ASSETS";
            // 
            // txtAcctCodeGlCode
            // 
            this.txtAcctCodeGlCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAcctCodeGlCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeGlCode.Location = new System.Drawing.Point(116, 52);
            this.txtAcctCodeGlCode.Name = "txtAcctCodeGlCode";
            this.txtAcctCodeGlCode.ReadOnly = true;
            this.txtAcctCodeGlCode.Size = new System.Drawing.Size(86, 22);
            this.txtAcctCodeGlCode.TabIndex = 53;
            this.txtAcctCodeGlCode.Text = "0002500";
            // 
            // txtAcctCodeSubGLName
            // 
            this.txtAcctCodeSubGLName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAcctCodeSubGLName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeSubGLName.ForeColor = System.Drawing.Color.DimGray;
            this.txtAcctCodeSubGLName.Location = new System.Drawing.Point(206, 74);
            this.txtAcctCodeSubGLName.Name = "txtAcctCodeSubGLName";
            this.txtAcctCodeSubGLName.ReadOnly = true;
            this.txtAcctCodeSubGLName.Size = new System.Drawing.Size(213, 22);
            this.txtAcctCodeSubGLName.TabIndex = 48;
            this.txtAcctCodeSubGLName.Text = "CURRENT-ASSETS";
            // 
            // txtAcctCodeTypeCode
            // 
            this.txtAcctCodeTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAcctCodeTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeTypeCode.Location = new System.Drawing.Point(116, 96);
            this.txtAcctCodeTypeCode.Name = "txtAcctCodeTypeCode";
            this.txtAcctCodeTypeCode.ReadOnly = true;
            this.txtAcctCodeTypeCode.Size = new System.Drawing.Size(86, 22);
            this.txtAcctCodeTypeCode.TabIndex = 49;
            this.txtAcctCodeTypeCode.Text = "0002511";
            // 
            // lblAcctCodeGlCode
            // 
            this.lblAcctCodeGlCode.AutoSize = true;
            this.lblAcctCodeGlCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeGlCode.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeGlCode.Location = new System.Drawing.Point(17, 56);
            this.lblAcctCodeGlCode.Name = "lblAcctCodeGlCode";
            this.lblAcctCodeGlCode.Size = new System.Drawing.Size(50, 14);
            this.lblAcctCodeGlCode.TabIndex = 51;
            this.lblAcctCodeGlCode.Text = "GL Code";
            // 
            // lblAcctCodeSubGlCode
            // 
            this.lblAcctCodeSubGlCode.AutoSize = true;
            this.lblAcctCodeSubGlCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeSubGlCode.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeSubGlCode.Location = new System.Drawing.Point(17, 77);
            this.lblAcctCodeSubGlCode.Name = "lblAcctCodeSubGlCode";
            this.lblAcctCodeSubGlCode.Size = new System.Drawing.Size(73, 14);
            this.lblAcctCodeSubGlCode.TabIndex = 50;
            this.lblAcctCodeSubGlCode.Text = "Sub GL Code";
            // 
            // lblAcctCodeTypeCode
            // 
            this.lblAcctCodeTypeCode.AutoSize = true;
            this.lblAcctCodeTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctCodeTypeCode.ForeColor = System.Drawing.Color.Black;
            this.lblAcctCodeTypeCode.Location = new System.Drawing.Point(17, 101);
            this.lblAcctCodeTypeCode.Name = "lblAcctCodeTypeCode";
            this.lblAcctCodeTypeCode.Size = new System.Drawing.Size(97, 14);
            this.lblAcctCodeTypeCode.TabIndex = 45;
            this.lblAcctCodeTypeCode.Text = "Acct. Type 1 Code";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(778, 248);
            this.panel3.TabIndex = 2;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receipt_ID,
            this.receiptDate,
            this.setteledAmount,
            this.TotalCommishion,
            this.NoOfCollecters,
            this.presentage,
            this.devidedCommishion});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(772, 242);
            this.dgvDetail.TabIndex = 477;
            // 
            // receipt_ID
            // 
            this.receipt_ID.DataPropertyName = "receipt_ID";
            this.receipt_ID.HeaderText = "Receipt ID";
            this.receipt_ID.Name = "receipt_ID";
            this.receipt_ID.ReadOnly = true;
            // 
            // receiptDate
            // 
            this.receiptDate.DataPropertyName = "receiptDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.receiptDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.receiptDate.HeaderText = "Date";
            this.receiptDate.Name = "receiptDate";
            this.receiptDate.ReadOnly = true;
            // 
            // setteledAmount
            // 
            this.setteledAmount.DataPropertyName = "setteledAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.setteledAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.setteledAmount.HeaderText = "Amount";
            this.setteledAmount.Name = "setteledAmount";
            this.setteledAmount.ReadOnly = true;
            // 
            // TotalCommishion
            // 
            this.TotalCommishion.DataPropertyName = "TotalCommishion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TotalCommishion.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalCommishion.HeaderText = "Total Commishion";
            this.TotalCommishion.Name = "TotalCommishion";
            this.TotalCommishion.ReadOnly = true;
            // 
            // NoOfCollecters
            // 
            this.NoOfCollecters.DataPropertyName = "NoOfCollecters";
            this.NoOfCollecters.HeaderText = "Collecters";
            this.NoOfCollecters.Name = "NoOfCollecters";
            this.NoOfCollecters.ReadOnly = true;
            // 
            // presentage
            // 
            this.presentage.DataPropertyName = "presentage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.presentage.DefaultCellStyle = dataGridViewCellStyle4;
            this.presentage.HeaderText = "%";
            this.presentage.Name = "presentage";
            this.presentage.ReadOnly = true;
            // 
            // devidedCommishion
            // 
            this.devidedCommishion.DataPropertyName = "devidedCommishion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.devidedCommishion.DefaultCellStyle = dataGridViewCellStyle5;
            this.devidedCommishion.HeaderText = "Commishion";
            this.devidedCommishion.Name = "devidedCommishion";
            this.devidedCommishion.ReadOnly = true;
            // 
            // frm_AccountCodeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.panel1);
            this.Name = "frm_AccountCodeMaster";
            this.Text = "frm_AccountCodeMaster";
            this.Load += new System.EventHandler(this.frm_AccountCodeMaster_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAcctCodeType2Name;
        private System.Windows.Forms.TextBox txtAcctCodeType2Code;
        private System.Windows.Forms.Label lblAcctCodeType2Code;
        private System.Windows.Forms.TextBox txtAcctCodeSubGlCode;
        private System.Windows.Forms.TextBox txtAcctCodeTypeName;
        private System.Windows.Forms.TextBox txtAcctCodeGlName;
        private System.Windows.Forms.TextBox txtAcctCodeGlCode;
        private System.Windows.Forms.TextBox txtAcctCodeSubGLName;
        private System.Windows.Forms.TextBox txtAcctCodeTypeCode;
        private System.Windows.Forms.Label lblAcctCodeGlCode;
        private System.Windows.Forms.Label lblAcctCodeSubGlCode;
        private System.Windows.Forms.Label lblAcctCodeTypeCode;
        private System.Windows.Forms.ComboBox cmbControlAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.ComboBox cmbAcctCodeStatus;
        private System.Windows.Forms.Label lblAcctCode;
        private System.Windows.Forms.TextBox txtAcctCodeName;
        private System.Windows.Forms.TextBox txtAcctCode;
        private System.Windows.Forms.Label lblAcctCodeName;
        private System.Windows.Forms.Label lblAcctCodeStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel3;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn setteledAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCommishion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfCollecters;
        private System.Windows.Forms.DataGridViewTextBoxColumn presentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn devidedCommishion;
    }
}