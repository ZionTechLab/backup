namespace Digiteq
{
    partial class frm_sasDeliveryOrderViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.RegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkViewAll = new System.Windows.Forms.CheckBox();
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtColourCompleted = new System.Windows.Forms.TextBox();
            this.txtColourDeleted = new System.Windows.Forms.TextBox();
            this.txtColourInProgress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRefNo = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.chkDeliveryNoteNo = new System.Windows.Forms.CheckBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.txtDeliveryNoteNo = new System.Windows.Forms.TextBox();
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.RegisterCode,
            this.CustomerName,
            this.Date,
            this.OrderRefNo,
            this.GrandTotal});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 83);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(825, 479);
            this.dgvDetail.TabIndex = 9;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellMouseLeave);
            this.dgvDetail.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseMove);
            // 
            // RegisterCode
            // 
            this.RegisterCode.DataPropertyName = "DelOrderCode";
            this.RegisterCode.HeaderText = "Del. Order No";
            this.RegisterCode.Name = "RegisterCode";
            this.RegisterCode.Width = 125;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 295;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 155;
            // 
            // OrderRefNo
            // 
            this.OrderRefNo.DataPropertyName = "OrderRefNo";
            this.OrderRefNo.HeaderText = "Order Ref No";
            this.OrderRefNo.Name = "OrderRefNo";
            this.OrderRefNo.Width = 130;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GrandTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrandTotal.HeaderText = "Grand Total";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.Width = 117;
            // 
            // chkViewAll
            // 
            this.chkViewAll.AutoSize = true;
            this.chkViewAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkViewAll.Location = new System.Drawing.Point(511, 41);
            this.chkViewAll.Name = "chkViewAll";
            this.chkViewAll.Size = new System.Drawing.Size(67, 18);
            this.chkViewAll.TabIndex = 0;
            this.chkViewAll.Text = "View All";
            this.chkViewAll.UseVisualStyleBackColor = true;
            this.chkViewAll.CheckedChanged += new System.EventHandler(this.chkViewAll_CheckedChanged);
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.label5);
            this.zpanel4.Controls.Add(this.textBox4);
            this.zpanel4.Controls.Add(this.label4);
            this.zpanel4.Controls.Add(this.textBox3);
            this.zpanel4.Controls.Add(this.label3);
            this.zpanel4.Controls.Add(this.textBox2);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.textBox1);
            this.zpanel4.Controls.Add(this.txtColourCompleted);
            this.zpanel4.Controls.Add(this.txtColourDeleted);
            this.zpanel4.Controls.Add(this.txtColourInProgress);
            this.zpanel4.Controls.Add(this.label1);
            this.zpanel4.Location = new System.Drawing.Point(9, 568);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(825, 30);
            this.zpanel4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(733, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Records";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(786, 3);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(34, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(654, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "-";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(665, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(34, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(448, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "-";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(459, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(34, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(239, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "-";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(250, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtColourCompleted
            // 
            this.txtColourCompleted.BackColor = System.Drawing.Color.White;
            this.txtColourCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColourCompleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColourCompleted.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtColourCompleted.Location = new System.Drawing.Point(293, 4);
            this.txtColourCompleted.Multiline = true;
            this.txtColourCompleted.Name = "txtColourCompleted";
            this.txtColourCompleted.ReadOnly = true;
            this.txtColourCompleted.Size = new System.Drawing.Size(155, 20);
            this.txtColourCompleted.TabIndex = 11;
            this.txtColourCompleted.Text = "System Completed Orders";
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
            this.txtColourDeleted.Location = new System.Drawing.Point(499, 4);
            this.txtColourDeleted.Multiline = true;
            this.txtColourDeleted.Name = "txtColourDeleted";
            this.txtColourDeleted.ReadOnly = true;
            this.txtColourDeleted.Size = new System.Drawing.Size(155, 20);
            this.txtColourDeleted.TabIndex = 9;
            this.txtColourDeleted.Text = "System Deleted Orders";
            this.txtColourDeleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColourDeleted.Click += new System.EventHandler(this.txtColourDeleted_Click);
            this.txtColourDeleted.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.txtColourDeleted.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // txtColourInProgress
            // 
            this.txtColourInProgress.BackColor = System.Drawing.Color.White;
            this.txtColourInProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColourInProgress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColourInProgress.Location = new System.Drawing.Point(81, 4);
            this.txtColourInProgress.Multiline = true;
            this.txtColourInProgress.Name = "txtColourInProgress";
            this.txtColourInProgress.ReadOnly = true;
            this.txtColourInProgress.Size = new System.Drawing.Size(155, 20);
            this.txtColourInProgress.TabIndex = 8;
            this.txtColourInProgress.Text = "System In-Progress Orders";
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
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Colour Codes";
            // 
            // chkRefNo
            // 
            this.chkRefNo.AutoSize = true;
            this.chkRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRefNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkRefNo.Location = new System.Drawing.Point(511, 11);
            this.chkRefNo.Name = "chkRefNo";
            this.chkRefNo.Size = new System.Drawing.Size(60, 18);
            this.chkRefNo.TabIndex = 8;
            this.chkRefNo.Text = "Ref No";
            this.chkRefNo.UseVisualStyleBackColor = true;
            this.chkRefNo.CheckedChanged += new System.EventHandler(this.chkRefNo_CheckedChanged);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDate.Location = new System.Drawing.Point(293, 11);
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
            this.chkCustomerName.Location = new System.Drawing.Point(16, 39);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(106, 18);
            this.chkCustomerName.TabIndex = 6;
            this.chkCustomerName.Text = "Customer Name";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            this.chkCustomerName.CheckedChanged += new System.EventHandler(this.chkCustomerName_CheckedChanged);
            // 
            // chkDeliveryNoteNo
            // 
            this.chkDeliveryNoteNo.AutoSize = true;
            this.chkDeliveryNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeliveryNoteNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDeliveryNoteNo.Location = new System.Drawing.Point(16, 11);
            this.chkDeliveryNoteNo.Name = "chkDeliveryNoteNo";
            this.chkDeliveryNoteNo.Size = new System.Drawing.Size(94, 18);
            this.chkDeliveryNoteNo.TabIndex = 5;
            this.chkDeliveryNoteNo.Text = "Cus. Order No";
            this.chkDeliveryNoteNo.UseVisualStyleBackColor = true;
            this.chkDeliveryNoteNo.CheckedChanged += new System.EventHandler(this.chkDeliveryNoteNo_CheckedChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(593, 7);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(216, 22);
            this.txtRefNo.TabIndex = 2;
            this.txtRefNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRefNo_KeyUp);
            // 
            // txtDeliveryNoteNo
            // 
            this.txtDeliveryNoteNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryNoteNo.Location = new System.Drawing.Point(122, 9);
            this.txtDeliveryNoteNo.Name = "txtDeliveryNoteNo";
            this.txtDeliveryNoteNo.Size = new System.Drawing.Size(131, 22);
            this.txtDeliveryNoteNo.TabIndex = 0;
            this.txtDeliveryNoteNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryNoteNo_KeyUp);
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel1.Controls.Add(this.btnNew);
            this.xpanel1.Controls.Add(this.btnClear);
            this.xpanel1.Controls.Add(this.chkViewAll);
            this.xpanel1.Controls.Add(this.chkRefNo);
            this.xpanel1.Controls.Add(this.chkDate);
            this.xpanel1.Controls.Add(this.chkCustomerName);
            this.xpanel1.Controls.Add(this.chkDeliveryNoteNo);
            this.xpanel1.Controls.Add(this.txtRefNo);
            this.xpanel1.Controls.Add(this.txtDeliveryNoteNo);
            this.xpanel1.Controls.Add(this.txtDate);
            this.xpanel1.Controls.Add(this.txtCustomerName);
            this.xpanel1.Location = new System.Drawing.Point(9, 8);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(825, 69);
            this.xpanel1.TabIndex = 7;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(634, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 25);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "     Create  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.new_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(734, 35);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(358, 9);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 22);
            this.txtDate.TabIndex = 1;
            this.txtDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyUp);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(122, 37);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(355, 22);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyUp);
            // 
            // frm_sasDeliveryOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(844, 605);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.zpanel4);
            this.Controls.Add(this.xpanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_sasDeliveryOrderViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Order Viewer";
            this.Load += new System.EventHandler(this.frm_sasDeliveryOrderViewer_Load);
            this.VisibleChanged += new System.EventHandler(this.frm_sasDeliveryOrderViewer_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.CheckBox chkViewAll;
        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRefNo;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.CheckBox chkDeliveryNoteNo;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.TextBox txtDeliveryNoteNo;
        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtColourCompleted;
        private System.Windows.Forms.TextBox txtColourDeleted;
        private System.Windows.Forms.TextBox txtColourInProgress;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
    }
}