namespace Digiteq
{
    partial class frmGroupApproval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new SEACC_DataGrid();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDCheques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrediteBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCOutstandings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Decline = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xFlow = new System.Windows.Forms.Panel();
            this.dtpTimePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerOrderID = new System.Windows.Forms.TextBox();
            this.dtpDatePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerOrderID = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPreparedBy = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.x2 = new System.Windows.Forms.Panel();
            this.flpNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.chkInquiry = new System.Windows.Forms.RadioButton();
            this.chkQutation = new System.Windows.Forms.RadioButton();
            this.chkCustomerOrder = new System.Windows.Forms.RadioButton();
            this.chkDeliveryOrder = new System.Windows.Forms.RadioButton();
            this.chkInvoice = new System.Windows.Forms.RadioButton();
            this.chkReceipt = new System.Windows.Forms.RadioButton();
            this.chkCheque = new System.Windows.Forms.RadioButton();
            this.chkSalesReturn = new System.Windows.Forms.RadioButton();
            this.chkCreditNote = new System.Windows.Forms.RadioButton();
            this.chkDebitNote = new System.Windows.Forms.RadioButton();
            this.chkAmount = new System.Windows.Forms.CheckBox();
            this.chkNoteID = new System.Windows.Forms.CheckBox();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtNoteID = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.xFlow.SuspendLayout();
            this.x2.SuspendLayout();
            this.flpNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.ApprovalStatusID,
            this.CustomerName,
            this.PDCheques,
            this.CrediteBalance,
            this.RCOutstandings,
            this.NoteNumber,
            this.Amount,
            this.Approve,
            this.Decline,
            this.ApprovalStatus});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 184);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(828, 413);
            this.dgvDetail.TabIndex = 12;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = false;
            // 
            // ApprovalStatusID
            // 
            this.ApprovalStatusID.HeaderText = "ApprovalStatusID";
            this.ApprovalStatusID.Name = "ApprovalStatusID";
            this.ApprovalStatusID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CustomerName.DefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 225;
            // 
            // PDCheques
            // 
            this.PDCheques.DataPropertyName = "PDCheques";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PDCheques.DefaultCellStyle = dataGridViewCellStyle2;
            this.PDCheques.HeaderText = "PDCheques";
            this.PDCheques.Name = "PDCheques";
            this.PDCheques.ReadOnly = true;
            this.PDCheques.Width = 90;
            // 
            // CrediteBalance
            // 
            this.CrediteBalance.DataPropertyName = "CrediteBalance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CrediteBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.CrediteBalance.HeaderText = "Sales Due";
            this.CrediteBalance.Name = "CrediteBalance";
            this.CrediteBalance.ReadOnly = true;
            this.CrediteBalance.Width = 90;
            // 
            // RCOutstandings
            // 
            this.RCOutstandings.DataPropertyName = "RCOutstandings";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RCOutstandings.DefaultCellStyle = dataGridViewCellStyle4;
            this.RCOutstandings.HeaderText = "R/C Outs.";
            this.RCOutstandings.Name = "RCOutstandings";
            this.RCOutstandings.ReadOnly = true;
            this.RCOutstandings.Width = 90;
            // 
            // NoteNumber
            // 
            this.NoteNumber.DataPropertyName = "NoteNumber";
            this.NoteNumber.HeaderText = "Note Number";
            this.NoteNumber.Name = "NoteNumber";
            this.NoteNumber.ReadOnly = true;
            this.NoteNumber.Width = 90;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 90;
            // 
            // Approve
            // 
            this.Approve.HeaderText = "Approve";
            this.Approve.Name = "Approve";
            this.Approve.Width = 50;
            // 
            // Decline
            // 
            this.Decline.HeaderText = "Decline";
            this.Decline.Name = "Decline";
            this.Decline.Visible = false;
            this.Decline.Width = 50;
            // 
            // ApprovalStatus
            // 
            this.ApprovalStatus.HeaderText = "Approval Status";
            this.ApprovalStatus.Name = "ApprovalStatus";
            // 
            // xFlow
            // 
            this.xFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xFlow.Controls.Add(this.dtpTimePreparedBy);
            this.xFlow.Controls.Add(this.txtCustomerOrderID);
            this.xFlow.Controls.Add(this.dtpDatePreparedBy);
            this.xFlow.Controls.Add(this.lblCustomerOrderID);
            this.xFlow.Controls.Add(this.label25);
            this.xFlow.Controls.Add(this.txtPreparedBy);
            this.xFlow.Controls.Add(this.label27);
            this.xFlow.Location = new System.Drawing.Point(7, 7);
            this.xFlow.Name = "xFlow";
            this.xFlow.Size = new System.Drawing.Size(828, 35);
            this.xFlow.TabIndex = 539;
            // 
            // dtpTimePreparedBy
            // 
            this.dtpTimePreparedBy.Enabled = false;
            this.dtpTimePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimePreparedBy.Location = new System.Drawing.Point(765, 6);
            this.dtpTimePreparedBy.Name = "dtpTimePreparedBy";
            this.dtpTimePreparedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimePreparedBy.TabIndex = 8;
            // 
            // txtCustomerOrderID
            // 
            this.txtCustomerOrderID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCustomerOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerOrderID.Location = new System.Drawing.Point(132, 6);
            this.txtCustomerOrderID.Name = "txtCustomerOrderID";
            this.txtCustomerOrderID.Size = new System.Drawing.Size(120, 22);
            this.txtCustomerOrderID.TabIndex = 3;
            this.txtCustomerOrderID.Text = "GN005";
            // 
            // dtpDatePreparedBy
            // 
            this.dtpDatePreparedBy.Enabled = false;
            this.dtpDatePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePreparedBy.Location = new System.Drawing.Point(677, 6);
            this.dtpDatePreparedBy.Name = "dtpDatePreparedBy";
            this.dtpDatePreparedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDatePreparedBy.TabIndex = 7;
            // 
            // lblCustomerOrderID
            // 
            this.lblCustomerOrderID.AutoSize = true;
            this.lblCustomerOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerOrderID.Location = new System.Drawing.Point(17, 10);
            this.lblCustomerOrderID.Name = "lblCustomerOrderID";
            this.lblCustomerOrderID.Size = new System.Drawing.Size(109, 14);
            this.lblCustomerOrderID.TabIndex = 2;
            this.lblCustomerOrderID.Text = "Batch Approval Code";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Gray;
            this.label25.Location = new System.Drawing.Point(593, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 14);
            this.label25.TabIndex = 6;
            this.label25.Text = "Prepared Date";
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreparedBy.ForeColor = System.Drawing.Color.Gray;
            this.txtPreparedBy.Location = new System.Drawing.Point(373, 6);
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.ReadOnly = true;
            this.txtPreparedBy.Size = new System.Drawing.Size(200, 22);
            this.txtPreparedBy.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(272, 10);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "Prepared By";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(683, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 541;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(604, 154);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 540;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(760, 154);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 542;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.flpNotes);
            this.x2.Controls.Add(this.chkAmount);
            this.x2.Controls.Add(this.chkNoteID);
            this.x2.Controls.Add(this.chkCustomerName);
            this.x2.Controls.Add(this.txtCustomerID);
            this.x2.Controls.Add(this.txtNoteID);
            this.x2.Controls.Add(this.txtAmount);
            this.x2.Location = new System.Drawing.Point(7, 48);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(828, 102);
            this.x2.TabIndex = 543;
            // 
            // flpNotes
            // 
            this.flpNotes.Controls.Add(this.chkInquiry);
            this.flpNotes.Controls.Add(this.chkQutation);
            this.flpNotes.Controls.Add(this.chkCustomerOrder);
            this.flpNotes.Controls.Add(this.chkDeliveryOrder);
            this.flpNotes.Controls.Add(this.chkInvoice);
            this.flpNotes.Controls.Add(this.chkReceipt);
            this.flpNotes.Controls.Add(this.chkCheque);
            this.flpNotes.Controls.Add(this.chkSalesReturn);
            this.flpNotes.Controls.Add(this.chkCreditNote);
            this.flpNotes.Controls.Add(this.chkDebitNote);
            this.flpNotes.Location = new System.Drawing.Point(5, 6);
            this.flpNotes.Name = "flpNotes";
            this.flpNotes.Size = new System.Drawing.Size(810, 61);
            this.flpNotes.TabIndex = 544;
            // 
            // chkInquiry
            // 
            this.chkInquiry.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInquiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkInquiry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkInquiry.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkInquiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkInquiry.Location = new System.Drawing.Point(3, 3);
            this.chkInquiry.Name = "chkInquiry";
            this.chkInquiry.Size = new System.Drawing.Size(129, 25);
            this.chkInquiry.TabIndex = 555;
            this.chkInquiry.TabStop = true;
            this.chkInquiry.Text = "1";
            this.chkInquiry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInquiry.UseVisualStyleBackColor = false;
            this.chkInquiry.CheckedChanged += new System.EventHandler(this.chkInquiry_CheckedChanged);
            // 
            // chkQutation
            // 
            this.chkQutation.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkQutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkQutation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkQutation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkQutation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkQutation.Location = new System.Drawing.Point(138, 3);
            this.chkQutation.Name = "chkQutation";
            this.chkQutation.Size = new System.Drawing.Size(129, 25);
            this.chkQutation.TabIndex = 556;
            this.chkQutation.TabStop = true;
            this.chkQutation.Text = "2";
            this.chkQutation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkQutation.UseVisualStyleBackColor = false;
            this.chkQutation.CheckedChanged += new System.EventHandler(this.chkQutation_CheckedChanged);
            // 
            // chkCustomerOrder
            // 
            this.chkCustomerOrder.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCustomerOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(1)))));
            this.chkCustomerOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCustomerOrder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkCustomerOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCustomerOrder.Location = new System.Drawing.Point(273, 3);
            this.chkCustomerOrder.Name = "chkCustomerOrder";
            this.chkCustomerOrder.Size = new System.Drawing.Size(129, 25);
            this.chkCustomerOrder.TabIndex = 557;
            this.chkCustomerOrder.TabStop = true;
            this.chkCustomerOrder.Text = "3";
            this.chkCustomerOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCustomerOrder.UseVisualStyleBackColor = false;
            this.chkCustomerOrder.CheckedChanged += new System.EventHandler(this.chkCustomerOrder_CheckedChanged);
            // 
            // chkDeliveryOrder
            // 
            this.chkDeliveryOrder.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDeliveryOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkDeliveryOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDeliveryOrder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkDeliveryOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDeliveryOrder.Location = new System.Drawing.Point(408, 3);
            this.chkDeliveryOrder.Name = "chkDeliveryOrder";
            this.chkDeliveryOrder.Size = new System.Drawing.Size(129, 25);
            this.chkDeliveryOrder.TabIndex = 558;
            this.chkDeliveryOrder.TabStop = true;
            this.chkDeliveryOrder.Text = "4";
            this.chkDeliveryOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDeliveryOrder.UseVisualStyleBackColor = false;
            this.chkDeliveryOrder.CheckedChanged += new System.EventHandler(this.chkDeliveryOrder_CheckedChanged);
            // 
            // chkInvoice
            // 
            this.chkInvoice.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkInvoice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkInvoice.Location = new System.Drawing.Point(543, 3);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(129, 25);
            this.chkInvoice.TabIndex = 559;
            this.chkInvoice.TabStop = true;
            this.chkInvoice.Text = "5";
            this.chkInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvoice.UseVisualStyleBackColor = false;
            this.chkInvoice.CheckedChanged += new System.EventHandler(this.chkInvoice_CheckedChanged);
            // 
            // chkReceipt
            // 
            this.chkReceipt.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkReceipt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkReceipt.Location = new System.Drawing.Point(678, 3);
            this.chkReceipt.Name = "chkReceipt";
            this.chkReceipt.Size = new System.Drawing.Size(129, 25);
            this.chkReceipt.TabIndex = 560;
            this.chkReceipt.TabStop = true;
            this.chkReceipt.Text = "6";
            this.chkReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkReceipt.UseVisualStyleBackColor = false;
            this.chkReceipt.CheckedChanged += new System.EventHandler(this.chkReceipt_CheckedChanged);
            // 
            // chkCheque
            // 
            this.chkCheque.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkCheque.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCheque.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCheque.Location = new System.Drawing.Point(3, 34);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(129, 25);
            this.chkCheque.TabIndex = 561;
            this.chkCheque.TabStop = true;
            this.chkCheque.Text = "7";
            this.chkCheque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCheque.UseVisualStyleBackColor = false;
            this.chkCheque.CheckedChanged += new System.EventHandler(this.chkCheque_CheckedChanged);
            // 
            // chkSalesReturn
            // 
            this.chkSalesReturn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSalesReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkSalesReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSalesReturn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSalesReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSalesReturn.Location = new System.Drawing.Point(138, 34);
            this.chkSalesReturn.Name = "chkSalesReturn";
            this.chkSalesReturn.Size = new System.Drawing.Size(129, 25);
            this.chkSalesReturn.TabIndex = 562;
            this.chkSalesReturn.TabStop = true;
            this.chkSalesReturn.Text = "8";
            this.chkSalesReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSalesReturn.UseVisualStyleBackColor = false;
            this.chkSalesReturn.CheckedChanged += new System.EventHandler(this.chkSalesReturn_CheckedChanged);
            // 
            // chkCreditNote
            // 
            this.chkCreditNote.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCreditNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkCreditNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCreditNote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkCreditNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCreditNote.Location = new System.Drawing.Point(273, 34);
            this.chkCreditNote.Name = "chkCreditNote";
            this.chkCreditNote.Size = new System.Drawing.Size(129, 25);
            this.chkCreditNote.TabIndex = 563;
            this.chkCreditNote.TabStop = true;
            this.chkCreditNote.Text = "9";
            this.chkCreditNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCreditNote.UseVisualStyleBackColor = false;
            this.chkCreditNote.CheckedChanged += new System.EventHandler(this.chkCreditNote_CheckedChanged);
            // 
            // chkDebitNote
            // 
            this.chkDebitNote.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDebitNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(244)))), ((int)(((byte)(133)))));
            this.chkDebitNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDebitNote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkDebitNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDebitNote.Location = new System.Drawing.Point(408, 34);
            this.chkDebitNote.Name = "chkDebitNote";
            this.chkDebitNote.Size = new System.Drawing.Size(129, 25);
            this.chkDebitNote.TabIndex = 564;
            this.chkDebitNote.TabStop = true;
            this.chkDebitNote.Text = "10";
            this.chkDebitNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDebitNote.UseVisualStyleBackColor = false;
            this.chkDebitNote.CheckedChanged += new System.EventHandler(this.chkDebitNote_CheckedChanged);
            // 
            // chkAmount
            // 
            this.chkAmount.AutoSize = true;
            this.chkAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAmount.Location = new System.Drawing.Point(635, 73);
            this.chkAmount.Name = "chkAmount";
            this.chkAmount.Size = new System.Drawing.Size(65, 18);
            this.chkAmount.TabIndex = 472;
            this.chkAmount.Text = "Amount";
            this.chkAmount.UseVisualStyleBackColor = true;
            this.chkAmount.CheckedChanged += new System.EventHandler(this.chkAmount_CheckedChanged);
            // 
            // chkNoteID
            // 
            this.chkNoteID.AutoSize = true;
            this.chkNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkNoteID.Location = new System.Drawing.Point(419, 73);
            this.chkNoteID.Name = "chkNoteID";
            this.chkNoteID.Size = new System.Drawing.Size(93, 18);
            this.chkNoteID.TabIndex = 472;
            this.chkNoteID.Text = "Note Number";
            this.chkNoteID.UseVisualStyleBackColor = true;
            this.chkNoteID.CheckedChanged += new System.EventHandler(this.chkNoteID_CheckedChanged);
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCustomerName.Location = new System.Drawing.Point(12, 73);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(106, 18);
            this.chkCustomerName.TabIndex = 472;
            this.chkCustomerName.Text = "Customer Name";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            this.chkCustomerName.CheckedChanged += new System.EventHandler(this.chkCustomerName_CheckedChanged);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(118, 71);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(293, 22);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtNoteID
            // 
            this.txtNoteID.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteID.Location = new System.Drawing.Point(510, 71);
            this.txtNoteID.Name = "txtNoteID";
            this.txtNoteID.Size = new System.Drawing.Size(103, 22);
            this.txtNoteID.TabIndex = 1;
            this.txtNoteID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceID_KeyUp);
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(713, 71);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 22);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(518, 338);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeCheckedBy.TabIndex = 11;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(518, 365);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeApprovedBy.TabIndex = 15;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(518, 365);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 16;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(518, 338);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 12;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(430, 338);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateCheckedBy.TabIndex = 10;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(430, 365);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateApprovedBy.TabIndex = 14;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(430, 365);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(346, 369);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 13;
            this.label29.Text = "Approved Date";
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(430, 338);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(346, 342);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 9;
            this.label26.Text = "Checked Date";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(126, 365);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 5;
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(126, 338);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(200, 22);
            this.txtCheckedBy.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label24.Location = new System.Drawing.Point(25, 342);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 14);
            this.label24.TabIndex = 2;
            this.label24.Text = "Checked By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label28.Location = new System.Drawing.Point(25, 369);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 4;
            this.label28.Text = "Approved By";
            // 
            // frmGroupApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(844, 605);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtTimeCheckedBy);
            this.Controls.Add(this.txtTimeApprovedBy);
            this.Controls.Add(this.dtpTimeApprovedBy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpTimeCheckedBy);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtDateCheckedBy);
            this.Controls.Add(this.xFlow);
            this.Controls.Add(this.txtDateApprovedBy);
            this.Controls.Add(this.dtpDateApprovedBy);
            this.Controls.Add(this.txtCheckedBy);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dtpDateCheckedBy);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtApprovedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGroupApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGroupApproval";
            this.Load += new System.EventHandler(this.frmGroupApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.xFlow.ResumeLayout(false);
            this.xFlow.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.flpNotes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel xFlow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.CheckBox chkAmount;
        private System.Windows.Forms.CheckBox chkNoteID;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtNoteID;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpTimePreparedBy;
        private System.Windows.Forms.DateTimePicker dtpDatePreparedBy;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPreparedBy;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtCustomerOrderID;
        private System.Windows.Forms.Label lblCustomerOrderID;
        private System.Windows.Forms.FlowLayoutPanel flpNotes;
        private System.Windows.Forms.RadioButton chkInquiry;
        private System.Windows.Forms.RadioButton chkQutation;
        private System.Windows.Forms.RadioButton chkCustomerOrder;
        private System.Windows.Forms.RadioButton chkDeliveryOrder;
        private System.Windows.Forms.RadioButton chkInvoice;
        private System.Windows.Forms.RadioButton chkReceipt;
        private System.Windows.Forms.RadioButton chkCheque;
        private System.Windows.Forms.RadioButton chkSalesReturn;
        private System.Windows.Forms.RadioButton chkCreditNote;
        private System.Windows.Forms.RadioButton chkDebitNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDCheques;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrediteBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn RCOutstandings;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approve;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Decline;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalStatus;
    }
}