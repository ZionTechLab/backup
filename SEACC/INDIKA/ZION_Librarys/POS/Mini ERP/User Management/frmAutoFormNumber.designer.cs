namespace Digiteq
{
    partial class frmAutoFormNumber
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
            this.btnNew = new System.Windows.Forms.Button();
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTxn = new System.Windows.Forms.TextBox();
            this.chkAutoGenerate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormConfigID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeperator2 = new System.Windows.Forms.TextBox();
            this.txtPrefix1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrefix2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSeperator1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.FormNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seperator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seperator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoGenerate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.zpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(396, 158);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 465;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.Transparent;
            this.zpanel4.Controls.Add(this.txtDoc);
            this.zpanel4.Controls.Add(this.label8);
            this.zpanel4.Controls.Add(this.label10);
            this.zpanel4.Controls.Add(this.txtTxn);
            this.zpanel4.Controls.Add(this.chkAutoGenerate);
            this.zpanel4.Controls.Add(this.label1);
            this.zpanel4.Controls.Add(this.txtFormName);
            this.zpanel4.Controls.Add(this.txtCount);
            this.zpanel4.Controls.Add(this.label9);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtLength);
            this.zpanel4.Controls.Add(this.label3);
            this.zpanel4.Controls.Add(this.txtFormConfigID);
            this.zpanel4.ForeColor = System.Drawing.Color.Black;
            this.zpanel4.Location = new System.Drawing.Point(7, 32);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(368, 120);
            this.zpanel4.TabIndex = 464;
            // 
            // txtDoc
            // 
            this.txtDoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDoc.Location = new System.Drawing.Point(288, 60);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(73, 23);
            this.txtDoc.TabIndex = 467;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(227, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 468;
            this.label8.Text = "Doc Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(227, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 470;
            this.label10.Text = "Txn Code";
            // 
            // txtTxn
            // 
            this.txtTxn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtTxn.Location = new System.Drawing.Point(288, 86);
            this.txtTxn.Name = "txtTxn";
            this.txtTxn.Size = new System.Drawing.Size(73, 23);
            this.txtTxn.TabIndex = 469;
            // 
            // chkAutoGenerate
            // 
            this.chkAutoGenerate.AutoSize = true;
            this.chkAutoGenerate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoGenerate.ForeColor = System.Drawing.Color.Black;
            this.chkAutoGenerate.Location = new System.Drawing.Point(225, 10);
            this.chkAutoGenerate.Name = "chkAutoGenerate";
            this.chkAutoGenerate.Size = new System.Drawing.Size(108, 19);
            this.chkAutoGenerate.TabIndex = 466;
            this.chkAutoGenerate.Text = "Auto Generate";
            this.chkAutoGenerate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 454;
            this.label1.Text = "Form No";
            // 
            // txtFormName
            // 
            this.txtFormName.BackColor = System.Drawing.Color.White;
            this.txtFormName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtFormName.Location = new System.Drawing.Point(109, 34);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(252, 23);
            this.txtFormName.TabIndex = 0;
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.White;
            this.txtCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtCount.Location = new System.Drawing.Point(109, 86);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(110, 23);
            this.txtCount.TabIndex = 2;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 319;
            this.label9.Text = "Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 321;
            this.label2.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtLength.Location = new System.Drawing.Point(109, 60);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(110, 23);
            this.txtLength.TabIndex = 320;
            this.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 456;
            this.label3.Text = "From Name";
            // 
            // txtFormConfigID
            // 
            this.txtFormConfigID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFormConfigID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormConfigID.Location = new System.Drawing.Point(109, 8);
            this.txtFormConfigID.Name = "txtFormConfigID";
            this.txtFormConfigID.ReadOnly = true;
            this.txtFormConfigID.Size = new System.Drawing.Size(110, 23);
            this.txtFormConfigID.TabIndex = 455;
            this.txtFormConfigID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormConfigID_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 296;
            this.label4.Text = "Prefix 1";
            // 
            // txtSeperator2
            // 
            this.txtSeperator2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeperator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtSeperator2.Location = new System.Drawing.Point(142, 86);
            this.txtSeperator2.Name = "txtSeperator2";
            this.txtSeperator2.Size = new System.Drawing.Size(83, 23);
            this.txtSeperator2.TabIndex = 461;
            // 
            // txtPrefix1
            // 
            this.txtPrefix1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefix1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtPrefix1.Location = new System.Drawing.Point(142, 8);
            this.txtPrefix1.Name = "txtPrefix1";
            this.txtPrefix1.Size = new System.Drawing.Size(83, 23);
            this.txtPrefix1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(7, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 462;
            this.label6.Text = "Seperator 2";
            // 
            // txtPrefix2
            // 
            this.txtPrefix2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefix2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtPrefix2.Location = new System.Drawing.Point(142, 34);
            this.txtPrefix2.Name = "txtPrefix2";
            this.txtPrefix2.Size = new System.Drawing.Size(83, 23);
            this.txtPrefix2.TabIndex = 459;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(7, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 15);
            this.label7.TabIndex = 460;
            this.label7.Text = "Prefix 2 / Financial Year";
            // 
            // txtSeperator1
            // 
            this.txtSeperator1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeperator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtSeperator1.Location = new System.Drawing.Point(142, 60);
            this.txtSeperator1.Name = "txtSeperator1";
            this.txtSeperator1.Size = new System.Drawing.Size(83, 23);
            this.txtSeperator1.TabIndex = 457;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 458;
            this.label5.Text = "Seperator 1";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormNo,
            this.FormName,
            this.Prefix1,
            this.Seperator1,
            this.Prefix2,
            this.Seperator2,
            this.Length,
            this.Count,
            this.AutoGenerate});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 189);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(622, 299);
            this.dgvDetail.TabIndex = 463;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // FormNo
            // 
            this.FormNo.HeaderText = "Form No";
            this.FormNo.Name = "FormNo";
            this.FormNo.Width = 72;
            // 
            // FormName
            // 
            this.FormName.HeaderText = "Form Name";
            this.FormName.Name = "FormName";
            this.FormName.Width = 130;
            // 
            // Prefix1
            // 
            this.Prefix1.HeaderText = "Prefix 1";
            this.Prefix1.Name = "Prefix1";
            this.Prefix1.Width = 60;
            // 
            // Seperator1
            // 
            this.Seperator1.HeaderText = "Sepe. 1";
            this.Seperator1.Name = "Seperator1";
            this.Seperator1.Width = 65;
            // 
            // Prefix2
            // 
            this.Prefix2.HeaderText = "Prefix 2";
            this.Prefix2.Name = "Prefix2";
            this.Prefix2.Width = 65;
            // 
            // Seperator2
            // 
            this.Seperator2.HeaderText = "Sepe. 2";
            this.Seperator2.Name = "Seperator2";
            this.Seperator2.Width = 64;
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.Width = 50;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 50;
            // 
            // AutoGenerate
            // 
            this.AutoGenerate.HeaderText = "Auto";
            this.AutoGenerate.Name = "AutoGenerate";
            this.AutoGenerate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AutoGenerate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AutoGenerate.Width = 75;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.LightGray;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Image = global::Digiteq.Properties.Resources.delete;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(553, 158);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "  Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.LightGray;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(474, 158);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "  Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.White;
            this.zpanel1.Controls.Add(this.txtSeperator1);
            this.zpanel1.Controls.Add(this.label5);
            this.zpanel1.Controls.Add(this.label4);
            this.zpanel1.Controls.Add(this.label6);
            this.zpanel1.Controls.Add(this.txtPrefix1);
            this.zpanel1.Controls.Add(this.txtSeperator2);
            this.zpanel1.Controls.Add(this.txtPrefix2);
            this.zpanel1.Controls.Add(this.label7);
            this.zpanel1.ForeColor = System.Drawing.Color.Black;
            this.zpanel1.Location = new System.Drawing.Point(397, 32);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(232, 120);
            this.zpanel1.TabIndex = 467;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(385, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 112);
            this.panel2.TabIndex = 469;
            // 
            // frmAutoFormNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 495);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.zpanel4);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.KeyPreview = true;
            this.Name = "frmAutoFormNumber";
            this.Text = "Auto Form Number";
            this.Load += new System.EventHandler(this.frm_AutoNumber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoFormNumber_KeyDown);
            this.Controls.SetChildIndex(this.btn_Close, 0);
            this.Controls.SetChildIndex(this.btn_Save, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.zpanel4, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.zpanel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.TextBox txtPrefix1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormConfigID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeperator2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrefix2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSeperator1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox chkAutoGenerate;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTxn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seperator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seperator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AutoGenerate;
    }
}