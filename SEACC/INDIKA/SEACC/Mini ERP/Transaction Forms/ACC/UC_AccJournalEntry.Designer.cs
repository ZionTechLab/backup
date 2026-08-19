namespace Digiteq
{
    partial class UC_AccJournalEntry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetail = new SEACC_DataGrid();
            this.Line_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_sup_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_sup_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc1_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_AddRow = new System.Windows.Forms.Button();
            this.Btn_GridDelete = new System.Windows.Forms.Button();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.zRemark = new System.Windows.Forms.Panel();
            this.txtDifferance = new System.Windows.Forms.TextBox();
            this.txtTotDebit = new System.Windows.Forms.TextBox();
            this.txtTotCredit = new System.Windows.Forms.TextBox();
            this.lblDifferance = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblJournalDate = new System.Windows.Forms.Label();
            this.dtpJVDate = new System.Windows.Forms.DateTimePicker();
            this.txtJournalID = new System.Windows.Forms.TextBox();
            this.lblJournalID = new System.Windows.Forms.Label();
            this.xSetting = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.zRemark.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xSetting);
            this.panel1.Controls.Add(this.dgvDetail);
            this.panel1.Controls.Add(this.Btn_AddRow);
            this.panel1.Controls.Add(this.Btn_GridDelete);
            this.panel1.Controls.Add(this.lblCancelled);
            this.panel1.Controls.Add(this.chkShowSettle);
            this.panel1.Controls.Add(this.zRemark);
            this.panel1.Controls.Add(this.txtNarration);
            this.panel1.Controls.Add(this.lblNarration);
            this.panel1.Controls.Add(this.lblJournalDate);
            this.panel1.Controls.Add(this.dtpJVDate);
            this.panel1.Controls.Add(this.txtJournalID);
            this.panel1.Controls.Add(this.lblJournalID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 433);
            this.panel1.TabIndex = 3;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line_No,
            this.accCode,
            this.accName,
            this.cus_sup_ID,
            this.cus_sup_Name,
            this.debitAmount,
            this.creditAmount,
            this.Remarks,
            this.subAcc1_ID,
            this.subAcc1Name,
            this.subAcc2_ID,
            this.subAcc2Name,
            this.Type});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 72);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(974, 245);
            this.dgvDetail.TabIndex = 527;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellLeave);
            // 
            // Line_No
            // 
            this.Line_No.DataPropertyName = "Line_No";
            this.Line_No.HeaderText = "#";
            this.Line_No.Name = "Line_No";
            this.Line_No.ReadOnly = true;
            this.Line_No.Width = 30;
            // 
            // accCode
            // 
            this.accCode.DataPropertyName = "AccCode";
            this.accCode.HeaderText = "Account Code";
            this.accCode.Name = "accCode";
            this.accCode.ReadOnly = true;
            this.accCode.Width = 120;
            // 
            // accName
            // 
            this.accName.DataPropertyName = "AccName";
            this.accName.HeaderText = "Account Name";
            this.accName.Name = "accName";
            this.accName.ReadOnly = true;
            this.accName.Width = 250;
            // 
            // cus_sup_ID
            // 
            this.cus_sup_ID.DataPropertyName = "cus_sup_ID";
            this.cus_sup_ID.HeaderText = "customer_ID";
            this.cus_sup_ID.Name = "cus_sup_ID";
            this.cus_sup_ID.ReadOnly = true;
            this.cus_sup_ID.Visible = false;
            // 
            // cus_sup_Name
            // 
            this.cus_sup_Name.DataPropertyName = "cus_sup_Name";
            this.cus_sup_Name.HeaderText = "Customer";
            this.cus_sup_Name.Name = "cus_sup_Name";
            this.cus_sup_Name.ReadOnly = true;
            this.cus_sup_Name.Width = 200;
            // 
            // debitAmount
            // 
            this.debitAmount.DataPropertyName = "debitAmount";
            this.debitAmount.HeaderText = "Debit Amount";
            this.debitAmount.Name = "debitAmount";
            // 
            // creditAmount
            // 
            this.creditAmount.DataPropertyName = "creditAmount";
            this.creditAmount.HeaderText = "Credit Amount";
            this.creditAmount.Name = "creditAmount";
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 260;
            // 
            // subAcc1_ID
            // 
            this.subAcc1_ID.DataPropertyName = "subAcc1_ID";
            this.subAcc1_ID.HeaderText = "subAcc1 ID";
            this.subAcc1_ID.Name = "subAcc1_ID";
            this.subAcc1_ID.Visible = false;
            // 
            // subAcc1Name
            // 
            this.subAcc1Name.DataPropertyName = "subAcc1Name";
            this.subAcc1Name.HeaderText = "Sub Account 1";
            this.subAcc1Name.Name = "subAcc1Name";
            this.subAcc1Name.Width = 120;
            // 
            // subAcc2_ID
            // 
            this.subAcc2_ID.DataPropertyName = "subAcc2_ID";
            this.subAcc2_ID.HeaderText = "subAcc2 ID";
            this.subAcc2_ID.Name = "subAcc2_ID";
            this.subAcc2_ID.Visible = false;
            // 
            // subAcc2Name
            // 
            this.subAcc2Name.DataPropertyName = "subAcc2Name";
            this.subAcc2Name.HeaderText = "Sub Account 2";
            this.subAcc2Name.Name = "subAcc2Name";
            this.subAcc2Name.Width = 120;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            // 
            // Btn_AddRow
            // 
            this.Btn_AddRow.Location = new System.Drawing.Point(959, 45);
            this.Btn_AddRow.Name = "Btn_AddRow";
            this.Btn_AddRow.Size = new System.Drawing.Size(22, 23);
            this.Btn_AddRow.TabIndex = 548;
            this.Btn_AddRow.Text = "+";
            this.Btn_AddRow.UseVisualStyleBackColor = true;
            this.Btn_AddRow.Click += new System.EventHandler(this.Btn_AddRow_Click);
            // 
            // Btn_GridDelete
            // 
            this.Btn_GridDelete.Location = new System.Drawing.Point(932, 45);
            this.Btn_GridDelete.Name = "Btn_GridDelete";
            this.Btn_GridDelete.Size = new System.Drawing.Size(23, 23);
            this.Btn_GridDelete.TabIndex = 547;
            this.Btn_GridDelete.Text = "x";
            this.Btn_GridDelete.UseVisualStyleBackColor = true;
            this.Btn_GridDelete.Click += new System.EventHandler(this.Btn_GridDelete_Click);
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(209, 19);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 546;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(225, 18);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 545;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // zRemark
            // 
            this.zRemark.BackColor = System.Drawing.Color.Silver;
            this.zRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zRemark.Controls.Add(this.txtDifferance);
            this.zRemark.Controls.Add(this.txtTotDebit);
            this.zRemark.Controls.Add(this.txtTotCredit);
            this.zRemark.Controls.Add(this.lblDifferance);
            this.zRemark.Location = new System.Drawing.Point(8, 323);
            this.zRemark.Name = "zRemark";
            this.zRemark.Size = new System.Drawing.Size(975, 37);
            this.zRemark.TabIndex = 529;
            // 
            // txtDifferance
            // 
            this.txtDifferance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifferance.Location = new System.Drawing.Point(114, 3);
            this.txtDifferance.Multiline = true;
            this.txtDifferance.Name = "txtDifferance";
            this.txtDifferance.ReadOnly = true;
            this.txtDifferance.Size = new System.Drawing.Size(145, 22);
            this.txtDifferance.TabIndex = 11;
            // 
            // txtTotDebit
            // 
            this.txtTotDebit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDebit.Location = new System.Drawing.Point(656, 6);
            this.txtTotDebit.Multiline = true;
            this.txtTotDebit.Name = "txtTotDebit";
            this.txtTotDebit.ReadOnly = true;
            this.txtTotDebit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotDebit.Size = new System.Drawing.Size(92, 22);
            this.txtTotDebit.TabIndex = 10;
            // 
            // txtTotCredit
            // 
            this.txtTotCredit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotCredit.Location = new System.Drawing.Point(754, 6);
            this.txtTotCredit.Multiline = true;
            this.txtTotCredit.Name = "txtTotCredit";
            this.txtTotCredit.ReadOnly = true;
            this.txtTotCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotCredit.Size = new System.Drawing.Size(97, 22);
            this.txtTotCredit.TabIndex = 9;
            // 
            // lblDifferance
            // 
            this.lblDifferance.AutoSize = true;
            this.lblDifferance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifferance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDifferance.Location = new System.Drawing.Point(7, 6);
            this.lblDifferance.Name = "lblDifferance";
            this.lblDifferance.Size = new System.Drawing.Size(100, 14);
            this.lblDifferance.TabIndex = 8;
            this.lblDifferance.Text = "Difference Amount";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(367, 14);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(559, 50);
            this.txtNarration.TabIndex = 488;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNarration.Location = new System.Drawing.Point(307, 17);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(54, 14);
            this.lblNarration.TabIndex = 487;
            this.lblNarration.Text = "Narration";
            // 
            // lblJournalDate
            // 
            this.lblJournalDate.AutoSize = true;
            this.lblJournalDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJournalDate.Location = new System.Drawing.Point(10, 50);
            this.lblJournalDate.Name = "lblJournalDate";
            this.lblJournalDate.Size = new System.Drawing.Size(31, 14);
            this.lblJournalDate.TabIndex = 486;
            this.lblJournalDate.Text = "Date";
            // 
            // dtpJVDate
            // 
            this.dtpJVDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJVDate.Location = new System.Drawing.Point(78, 44);
            this.dtpJVDate.Name = "dtpJVDate";
            this.dtpJVDate.Size = new System.Drawing.Size(125, 22);
            this.dtpJVDate.TabIndex = 485;
            // 
            // txtJournalID
            // 
            this.txtJournalID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtJournalID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJournalID.Location = new System.Drawing.Point(78, 16);
            this.txtJournalID.Name = "txtJournalID";
            this.txtJournalID.Size = new System.Drawing.Size(125, 22);
            this.txtJournalID.TabIndex = 484;
            this.txtJournalID.DoubleClick += new System.EventHandler(this.txtJournalID_DoubleClick);
            this.txtJournalID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJournalID_KeyDown);
            // 
            // lblJournalID
            // 
            this.lblJournalID.AutoSize = true;
            this.lblJournalID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJournalID.Location = new System.Drawing.Point(10, 19);
            this.lblJournalID.Name = "lblJournalID";
            this.lblJournalID.Size = new System.Drawing.Size(56, 14);
            this.lblJournalID.TabIndex = 483;
            this.lblJournalID.Text = " Entry No.";
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.button1);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label3);
            this.xSetting.Location = new System.Drawing.Point(817, 2);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(163, 57);
            this.xSetting.TabIndex = 595;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(130, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 28);
            this.button1.TabIndex = 470;
            this.button1.Text = "";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(29, 30);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 469;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 453;
            this.label3.Text = "Special Settings";
            // 
            // UC_AccJournalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UC_AccJournalEntry";
            this.Size = new System.Drawing.Size(995, 481);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccJournalEntry_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.UC_AccJournalEntry_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.zRemark.ResumeLayout(false);
            this.zRemark.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtJournalID;
        private System.Windows.Forms.Label lblJournalID;
        private System.Windows.Forms.Label lblJournalDate;
        private System.Windows.Forms.DateTimePicker dtpJVDate;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblNarration;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel zRemark;
        private System.Windows.Forms.TextBox txtDifferance;
        private System.Windows.Forms.TextBox txtTotDebit;
        private System.Windows.Forms.TextBox txtTotCredit;
        private System.Windows.Forms.Label lblDifferance;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Button Btn_AddRow;
        private System.Windows.Forms.Button Btn_GridDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn accCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_sup_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_sup_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc1_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
    }
}
