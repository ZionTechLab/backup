namespace Digiteq
{
    partial class frm_bpsReceiptTracer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new SEACC_DataGrid();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColourCompleted = new System.Windows.Forms.TextBox();
            this.txtColourDeleted = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtColourInProgress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkViewAll = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.ChkReceiptNo = new System.Windows.Forms.CheckBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.zpanel4.SuspendLayout();
            this.xpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptNo,
            this.CustomerName,
            this.Date,
            this.CashAmount,
            this.ChequeAmount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 82);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(823, 476);
            this.dgvDetail.TabIndex = 9;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellMouseLeave);
            this.dgvDetail.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseMove);
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.DataPropertyName = "ReceiptNo";
            this.ReceiptNo.HeaderText = "Receipt No";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.Width = 150;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 290;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 140;
            // 
            // CashAmount
            // 
            this.CashAmount.DataPropertyName = "CashAmount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CashAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.CashAmount.HeaderText = "CashAmount";
            this.CashAmount.Name = "CashAmount";
            this.CashAmount.Width = 120;
            // 
            // ChequeAmount
            // 
            this.ChequeAmount.DataPropertyName = "ChequeAmount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ChequeAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.ChequeAmount.HeaderText = "ChequeAmount";
            this.ChequeAmount.Name = "ChequeAmount";
            this.ChequeAmount.Width = 120;
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.label5);
            this.zpanel4.Controls.Add(this.label4);
            this.zpanel4.Controls.Add(this.label3);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtColourCompleted);
            this.zpanel4.Controls.Add(this.txtColourDeleted);
            this.zpanel4.Controls.Add(this.textBox4);
            this.zpanel4.Controls.Add(this.textBox3);
            this.zpanel4.Controls.Add(this.textBox2);
            this.zpanel4.Controls.Add(this.textBox1);
            this.zpanel4.Controls.Add(this.txtColourInProgress);
            this.zpanel4.Controls.Add(this.label1);
            this.zpanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.zpanel4.Location = new System.Drawing.Point(8, 564);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(823, 30);
            this.zpanel4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(729, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Records";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(657, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(449, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(240, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "-";
            // 
            // txtColourCompleted
            // 
            this.txtColourCompleted.BackColor = System.Drawing.Color.White;
            this.txtColourCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColourCompleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColourCompleted.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtColourCompleted.Location = new System.Drawing.Point(291, 5);
            this.txtColourCompleted.Multiline = true;
            this.txtColourCompleted.Name = "txtColourCompleted";
            this.txtColourCompleted.ReadOnly = true;
            this.txtColourCompleted.Size = new System.Drawing.Size(155, 20);
            this.txtColourCompleted.TabIndex = 7;
            this.txtColourCompleted.Text = "System Completed Receipts";
            this.txtColourCompleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColourCompleted.Click += new System.EventHandler(this.txtColourCompleted_Click);
            this.txtColourCompleted.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.txtColourCompleted.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // txtColourDeleted
            // 
            this.txtColourDeleted.BackColor = System.Drawing.Color.White;
            this.txtColourDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColourDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColourDeleted.Location = new System.Drawing.Point(500, 5);
            this.txtColourDeleted.Multiline = true;
            this.txtColourDeleted.Name = "txtColourDeleted";
            this.txtColourDeleted.ReadOnly = true;
            this.txtColourDeleted.Size = new System.Drawing.Size(155, 20);
            this.txtColourDeleted.TabIndex = 5;
            this.txtColourDeleted.Text = "System Deleted Receipts";
            this.txtColourDeleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColourDeleted.Click += new System.EventHandler(this.txtColourDeleted_Click);
            this.txtColourDeleted.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.txtColourDeleted.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(782, 4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(34, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(671, 5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(34, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(460, 5);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(251, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtColourInProgress
            // 
            this.txtColourInProgress.BackColor = System.Drawing.Color.White;
            this.txtColourInProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColourInProgress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColourInProgress.Location = new System.Drawing.Point(84, 5);
            this.txtColourInProgress.Multiline = true;
            this.txtColourInProgress.Name = "txtColourInProgress";
            this.txtColourInProgress.ReadOnly = true;
            this.txtColourInProgress.Size = new System.Drawing.Size(155, 20);
            this.txtColourInProgress.TabIndex = 4;
            this.txtColourInProgress.Text = "System In-Progress Receipts";
            this.txtColourInProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColourInProgress.Click += new System.EventHandler(this.txtColourInProgress_Click);
            this.txtColourInProgress.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.txtColourInProgress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Colour Codes";
            // 
            // chkViewAll
            // 
            this.chkViewAll.AutoSize = true;
            this.chkViewAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkViewAll.Location = new System.Drawing.Point(509, 41);
            this.chkViewAll.Name = "chkViewAll";
            this.chkViewAll.Size = new System.Drawing.Size(67, 18);
            this.chkViewAll.TabIndex = 0;
            this.chkViewAll.Text = "View All";
            this.chkViewAll.UseVisualStyleBackColor = true;
            this.chkViewAll.CheckedChanged += new System.EventHandler(this.chkViewAll_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(636, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "     Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.new_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(732, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "    Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDate.Location = new System.Drawing.Point(291, 11);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(50, 18);
            this.chkDate.TabIndex = 7;
            this.chkDate.Text = "Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkCustomerName.Location = new System.Drawing.Point(14, 39);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(106, 18);
            this.chkCustomerName.TabIndex = 6;
            this.chkCustomerName.Text = "Customer Name";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            this.chkCustomerName.CheckedChanged += new System.EventHandler(this.chkCustomerName_CheckedChanged);
            // 
            // ChkReceiptNo
            // 
            this.ChkReceiptNo.AutoSize = true;
            this.ChkReceiptNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkReceiptNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ChkReceiptNo.Location = new System.Drawing.Point(14, 11);
            this.ChkReceiptNo.Name = "ChkReceiptNo";
            this.ChkReceiptNo.Size = new System.Drawing.Size(80, 18);
            this.ChkReceiptNo.TabIndex = 5;
            this.ChkReceiptNo.Text = "Receipt No";
            this.ChkReceiptNo.UseVisualStyleBackColor = true;
            this.ChkReceiptNo.CheckedChanged += new System.EventHandler(this.ChkReceiptNo_CheckedChanged);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(120, 9);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(131, 22);
            this.txtReceiptNo.TabIndex = 0;
            this.txtReceiptNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReceiptNo_KeyUp);
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel1.Controls.Add(this.chkViewAll);
            this.xpanel1.Controls.Add(this.btnNew);
            this.xpanel1.Controls.Add(this.btnClear);
            this.xpanel1.Controls.Add(this.chkDate);
            this.xpanel1.Controls.Add(this.chkCustomerName);
            this.xpanel1.Controls.Add(this.ChkReceiptNo);
            this.xpanel1.Controls.Add(this.txtReceiptNo);
            this.xpanel1.Controls.Add(this.txtDate);
            this.xpanel1.Controls.Add(this.txtCustomerName);
            this.xpanel1.Location = new System.Drawing.Point(8, 8);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(823, 68);
            this.xpanel1.TabIndex = 7;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(356, 9);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 22);
            this.txtDate.TabIndex = 1;
            this.txtDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyUp);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(120, 37);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(355, 22);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyUp);
            // 
            // frm_bpsReceiptTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 605);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.zpanel4);
            this.Controls.Add(this.xpanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_bpsReceiptTracer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Tracer";
            this.Load += new System.EventHandler(this.frm_bpsReceiptTracer_Load);
            this.VisibleChanged += new System.EventHandler(this.frm_bpsReceiptTracer_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkViewAll;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.CheckBox ChkReceiptNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtColourCompleted;
        private System.Windows.Forms.TextBox txtColourDeleted;
        private System.Windows.Forms.TextBox txtColourInProgress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeAmount;

    }
}