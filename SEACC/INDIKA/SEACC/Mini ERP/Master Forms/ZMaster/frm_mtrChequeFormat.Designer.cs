namespace Digiteq
{
    partial class frm_mtrChequeFormat
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
            this.dgvChequeDes = new SEACC_DataGrid();
            this.ChequeFormat_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeFormat_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeFormatDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblChequeFormatCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtChequeFormatCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvChequeDetail = new SEACC_DataGrid();
            this.element_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontType_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtChequeFormatID = new System.Windows.Forms.TextBox();
            this.lblXmargin = new System.Windows.Forms.Label();
            this.lblYmargin = new System.Windows.Forms.Label();
            this.txtXmargin = new System.Windows.Forms.TextBox();
            this.txtYmargin = new System.Windows.Forms.TextBox();
            this.pnlChequeLayout = new System.Windows.Forms.Panel();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblAccountPayee = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblAmountCB = new System.Windows.Forms.Label();
            this.lblCBPayee4 = new System.Windows.Forms.Label();
            this.lblCBPayee3 = new System.Windows.Forms.Label();
            this.lblCBPayee2 = new System.Windows.Forms.Label();
            this.lblCBPayee1 = new System.Windows.Forms.Label();
            this.lblCBDate = new System.Windows.Forms.Label();
            this.lblAmountWordLine3 = new System.Windows.Forms.Label();
            this.lblYear4 = new System.Windows.Forms.Label();
            this.lblYear3 = new System.Windows.Forms.Label();
            this.lblMonth2 = new System.Windows.Forms.Label();
            this.lblMonth1 = new System.Windows.Forms.Label();
            this.lblDay2 = new System.Windows.Forms.Label();
            this.lblDay1 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountWordLine2 = new System.Windows.Forms.Label();
            this.lblAmountWordLine1 = new System.Windows.Forms.Label();
            this.lblPayee = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtCounterBookLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDetail)).BeginInit();
            this.pnlChequeLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dgvChequeDes
            // 
            this.dgvChequeDes.AllowUserToAddRows = false;
            this.dgvChequeDes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChequeDes.ColumnHeadersHeight = 25;
            this.dgvChequeDes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChequeFormat_ID,
            this.ChequeFormat_Code,
            this.ChequeFormatDescription});
            this.dgvChequeDes.Location = new System.Drawing.Point(9, 35);
            this.dgvChequeDes.Name = "dgvChequeDes";
            this.dgvChequeDes.RowHeadersVisible = false;
            this.dgvChequeDes.Size = new System.Drawing.Size(343, 402);
            this.dgvChequeDes.TabIndex = 4;
            this.dgvChequeDes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequeDes_CellClick);
            this.dgvChequeDes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequeDes_CellContentClick);
            // 
            // ChequeFormat_ID
            // 
            this.ChequeFormat_ID.HeaderText = "Cheque Format ID";
            this.ChequeFormat_ID.Name = "ChequeFormat_ID";
            this.ChequeFormat_ID.Visible = false;
            this.ChequeFormat_ID.Width = 80;
            // 
            // ChequeFormat_Code
            // 
            this.ChequeFormat_Code.HeaderText = "Format Code";
            this.ChequeFormat_Code.Name = "ChequeFormat_Code";
            this.ChequeFormat_Code.Width = 140;
            // 
            // ChequeFormatDescription
            // 
            this.ChequeFormatDescription.HeaderText = "Description";
            this.ChequeFormatDescription.Name = "ChequeFormatDescription";
            this.ChequeFormatDescription.Width = 200;
            // 
            // lblChequeFormatCode
            // 
            this.lblChequeFormatCode.AutoSize = true;
            this.lblChequeFormatCode.Location = new System.Drawing.Point(367, 49);
            this.lblChequeFormatCode.Name = "lblChequeFormatCode";
            this.lblChequeFormatCode.Size = new System.Drawing.Size(116, 13);
            this.lblChequeFormatCode.TabIndex = 5;
            this.lblChequeFormatCode.Text = "Cheque Format Code";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(367, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // txtChequeFormatCode
            // 
            this.txtChequeFormatCode.BackColor = System.Drawing.Color.LightGray;
            this.txtChequeFormatCode.Location = new System.Drawing.Point(489, 44);
            this.txtChequeFormatCode.Name = "txtChequeFormatCode";
            this.txtChequeFormatCode.Size = new System.Drawing.Size(150, 22);
            this.txtChequeFormatCode.TabIndex = 7;
            this.txtChequeFormatCode.DoubleClick += new System.EventHandler(this.txtChequeFormatCode_DoubleClick);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(489, 72);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(281, 47);
            this.txtDescription.TabIndex = 8;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.Silver;
            this.pnlLine.Location = new System.Drawing.Point(358, 35);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1, 400);
            this.pnlLine.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(764, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(685, 443);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(843, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvChequeDetail
            // 
            this.dgvChequeDetail.AllowUserToAddRows = false;
            this.dgvChequeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChequeDetail.ColumnHeadersHeight = 25;
            this.dgvChequeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.element_ID,
            this.element_description,
            this.FontType,
            this.FontType_ID,
            this.xValue,
            this.yValue,
            this.length});
            this.dgvChequeDetail.Location = new System.Drawing.Point(366, 125);
            this.dgvChequeDetail.Name = "dgvChequeDetail";
            this.dgvChequeDetail.RowHeadersVisible = false;
            this.dgvChequeDetail.RowHeadersWidth = 10;
            this.dgvChequeDetail.Size = new System.Drawing.Size(552, 312);
            this.dgvChequeDetail.TabIndex = 15;
            this.dgvChequeDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequeDetail_CellDoubleClick);
            this.dgvChequeDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChequeDetail_CellEndEdit);
            this.dgvChequeDetail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvChequeDetail_CellMouseClick);
            this.dgvChequeDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvChequeDetail_CellParsing);
            // 
            // element_ID
            // 
            this.element_ID.DataPropertyName = "element_ID";
            this.element_ID.HeaderText = "Element_ID";
            this.element_ID.Name = "element_ID";
            this.element_ID.Visible = false;
            // 
            // element_description
            // 
            this.element_description.DataPropertyName = "element_description";
            this.element_description.HeaderText = "Element Description";
            this.element_description.Name = "element_description";
            this.element_description.ReadOnly = true;
            this.element_description.Width = 160;
            // 
            // FontType
            // 
            this.FontType.DataPropertyName = "FontType";
            this.FontType.HeaderText = "Font Type ";
            this.FontType.Name = "FontType";
            this.FontType.ReadOnly = true;
            this.FontType.Width = 150;
            // 
            // FontType_ID
            // 
            this.FontType_ID.DataPropertyName = "FontType_ID";
            this.FontType_ID.HeaderText = "FontType_ID";
            this.FontType_ID.Name = "FontType_ID";
            this.FontType_ID.Visible = false;
            // 
            // xValue
            // 
            this.xValue.DataPropertyName = "xValue";
            this.xValue.HeaderText = "X-Value";
            this.xValue.Name = "xValue";
            this.xValue.Width = 80;
            // 
            // yValue
            // 
            this.yValue.DataPropertyName = "yValue";
            this.yValue.HeaderText = "Y-Value";
            this.yValue.Name = "yValue";
            this.yValue.Width = 80;
            // 
            // length
            // 
            this.length.DataPropertyName = "length";
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            this.length.Width = 80;
            // 
            // txtChequeFormatID
            // 
            this.txtChequeFormatID.Location = new System.Drawing.Point(437, 153);
            this.txtChequeFormatID.Name = "txtChequeFormatID";
            this.txtChequeFormatID.Size = new System.Drawing.Size(100, 22);
            this.txtChequeFormatID.TabIndex = 16;
            // 
            // lblXmargin
            // 
            this.lblXmargin.AutoSize = true;
            this.lblXmargin.Location = new System.Drawing.Point(776, 77);
            this.lblXmargin.Name = "lblXmargin";
            this.lblXmargin.Size = new System.Drawing.Size(54, 13);
            this.lblXmargin.TabIndex = 17;
            this.lblXmargin.Text = "X-Margin";
            // 
            // lblYmargin
            // 
            this.lblYmargin.AutoSize = true;
            this.lblYmargin.Location = new System.Drawing.Point(776, 102);
            this.lblYmargin.Name = "lblYmargin";
            this.lblYmargin.Size = new System.Drawing.Size(53, 13);
            this.lblYmargin.TabIndex = 18;
            this.lblYmargin.Text = "Y-Margin";
            // 
            // txtXmargin
            // 
            this.txtXmargin.Location = new System.Drawing.Point(843, 72);
            this.txtXmargin.Name = "txtXmargin";
            this.txtXmargin.Size = new System.Drawing.Size(72, 22);
            this.txtXmargin.TabIndex = 19;
            this.txtXmargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXmargin_KeyPress);
            // 
            // txtYmargin
            // 
            this.txtYmargin.Location = new System.Drawing.Point(843, 97);
            this.txtYmargin.Name = "txtYmargin";
            this.txtYmargin.Size = new System.Drawing.Size(72, 22);
            this.txtYmargin.TabIndex = 20;
            this.txtYmargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYmargin_KeyPress);
            // 
            // pnlChequeLayout
            // 
            this.pnlChequeLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlChequeLayout.Controls.Add(this.lblLine1);
            this.pnlChequeLayout.Controls.Add(this.lblAccountPayee);
            this.pnlChequeLayout.Controls.Add(this.lblLine2);
            this.pnlChequeLayout.Controls.Add(this.lblAmountCB);
            this.pnlChequeLayout.Controls.Add(this.lblCBPayee4);
            this.pnlChequeLayout.Controls.Add(this.lblCBPayee3);
            this.pnlChequeLayout.Controls.Add(this.lblCBPayee2);
            this.pnlChequeLayout.Controls.Add(this.lblCBPayee1);
            this.pnlChequeLayout.Controls.Add(this.lblCBDate);
            this.pnlChequeLayout.Controls.Add(this.lblAmountWordLine3);
            this.pnlChequeLayout.Controls.Add(this.lblYear4);
            this.pnlChequeLayout.Controls.Add(this.lblYear3);
            this.pnlChequeLayout.Controls.Add(this.lblMonth2);
            this.pnlChequeLayout.Controls.Add(this.lblMonth1);
            this.pnlChequeLayout.Controls.Add(this.lblDay2);
            this.pnlChequeLayout.Controls.Add(this.lblDay1);
            this.pnlChequeLayout.Controls.Add(this.lblAmount);
            this.pnlChequeLayout.Controls.Add(this.lblAmountWordLine2);
            this.pnlChequeLayout.Controls.Add(this.lblAmountWordLine1);
            this.pnlChequeLayout.Controls.Add(this.lblPayee);
            this.pnlChequeLayout.Location = new System.Drawing.Point(9, 475);
            this.pnlChequeLayout.Name = "pnlChequeLayout";
            this.pnlChequeLayout.Size = new System.Drawing.Size(909, 229);
            this.pnlChequeLayout.TabIndex = 21;
            // 
            // lblLine1
            // 
            this.lblLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblLine1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine1.Location = new System.Drawing.Point(179, 3);
            this.lblLine1.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(139, 16);
            this.lblLine1.TabIndex = 19;
            this.lblLine1.Text = "______________________";
            // 
            // lblAccountPayee
            // 
            this.lblAccountPayee.AutoSize = true;
            this.lblAccountPayee.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountPayee.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountPayee.Location = new System.Drawing.Point(190, 19);
            this.lblAccountPayee.Margin = new System.Windows.Forms.Padding(0);
            this.lblAccountPayee.Name = "lblAccountPayee";
            this.lblAccountPayee.Size = new System.Drawing.Size(113, 14);
            this.lblAccountPayee.TabIndex = 17;
            this.lblAccountPayee.Text = "Account Payee Only.";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.BackColor = System.Drawing.Color.Transparent;
            this.lblLine2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine2.Location = new System.Drawing.Point(179, 23);
            this.lblLine2.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(139, 14);
            this.lblLine2.TabIndex = 18;
            this.lblLine2.Text = "______________________";
            // 
            // lblAmountCB
            // 
            this.lblAmountCB.AutoSize = true;
            this.lblAmountCB.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountCB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountCB.Location = new System.Drawing.Point(42, 180);
            this.lblAmountCB.Name = "lblAmountCB";
            this.lblAmountCB.Size = new System.Drawing.Size(100, 14);
            this.lblAmountCB.TabIndex = 16;
            this.lblAmountCB.Text = "**12,345,678.00**";
            // 
            // lblCBPayee4
            // 
            this.lblCBPayee4.AutoSize = true;
            this.lblCBPayee4.BackColor = System.Drawing.Color.Transparent;
            this.lblCBPayee4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBPayee4.Location = new System.Drawing.Point(42, 110);
            this.lblCBPayee4.Name = "lblCBPayee4";
            this.lblCBPayee4.Size = new System.Drawing.Size(11, 14);
            this.lblCBPayee4.TabIndex = 15;
            this.lblCBPayee4.Text = "-";
            // 
            // lblCBPayee3
            // 
            this.lblCBPayee3.AutoSize = true;
            this.lblCBPayee3.BackColor = System.Drawing.Color.Transparent;
            this.lblCBPayee3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBPayee3.Location = new System.Drawing.Point(42, 87);
            this.lblCBPayee3.Name = "lblCBPayee3";
            this.lblCBPayee3.Size = new System.Drawing.Size(11, 14);
            this.lblCBPayee3.TabIndex = 14;
            this.lblCBPayee3.Text = "-";
            // 
            // lblCBPayee2
            // 
            this.lblCBPayee2.AutoSize = true;
            this.lblCBPayee2.BackColor = System.Drawing.Color.Transparent;
            this.lblCBPayee2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBPayee2.Location = new System.Drawing.Point(42, 64);
            this.lblCBPayee2.Name = "lblCBPayee2";
            this.lblCBPayee2.Size = new System.Drawing.Size(41, 14);
            this.lblCBPayee2.TabIndex = 13;
            this.lblCBPayee2.Text = "Pvt Ltd";
            // 
            // lblCBPayee1
            // 
            this.lblCBPayee1.AutoSize = true;
            this.lblCBPayee1.BackColor = System.Drawing.Color.Transparent;
            this.lblCBPayee1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBPayee1.Location = new System.Drawing.Point(42, 41);
            this.lblCBPayee1.Name = "lblCBPayee1";
            this.lblCBPayee1.Size = new System.Drawing.Size(95, 14);
            this.lblCBPayee1.TabIndex = 12;
            this.lblCBPayee1.Text = "Digiteq Solution";
            // 
            // lblCBDate
            // 
            this.lblCBDate.AutoSize = true;
            this.lblCBDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCBDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBDate.Location = new System.Drawing.Point(42, 12);
            this.lblCBDate.Name = "lblCBDate";
            this.lblCBDate.Size = new System.Drawing.Size(63, 14);
            this.lblCBDate.TabIndex = 11;
            this.lblCBDate.Text = "2019-01-01";
            // 
            // lblAmountWordLine3
            // 
            this.lblAmountWordLine3.AutoSize = true;
            this.lblAmountWordLine3.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountWordLine3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountWordLine3.Location = new System.Drawing.Point(206, 140);
            this.lblAmountWordLine3.Name = "lblAmountWordLine3";
            this.lblAmountWordLine3.Size = new System.Drawing.Size(16, 23);
            this.lblAmountWordLine3.TabIndex = 10;
            this.lblAmountWordLine3.Text = "-";
            // 
            // lblYear4
            // 
            this.lblYear4.AutoSize = true;
            this.lblYear4.BackColor = System.Drawing.Color.Transparent;
            this.lblYear4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear4.Location = new System.Drawing.Point(844, 21);
            this.lblYear4.Name = "lblYear4";
            this.lblYear4.Size = new System.Drawing.Size(20, 23);
            this.lblYear4.TabIndex = 9;
            this.lblYear4.Text = "2";
            // 
            // lblYear3
            // 
            this.lblYear3.AutoSize = true;
            this.lblYear3.BackColor = System.Drawing.Color.Transparent;
            this.lblYear3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear3.Location = new System.Drawing.Point(811, 21);
            this.lblYear3.Name = "lblYear3";
            this.lblYear3.Size = new System.Drawing.Size(20, 23);
            this.lblYear3.TabIndex = 8;
            this.lblYear3.Text = "1";
            // 
            // lblMonth2
            // 
            this.lblMonth2.AutoSize = true;
            this.lblMonth2.BackColor = System.Drawing.Color.Transparent;
            this.lblMonth2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth2.Location = new System.Drawing.Point(714, 21);
            this.lblMonth2.Name = "lblMonth2";
            this.lblMonth2.Size = new System.Drawing.Size(20, 23);
            this.lblMonth2.TabIndex = 7;
            this.lblMonth2.Text = "9";
            // 
            // lblMonth1
            // 
            this.lblMonth1.AutoSize = true;
            this.lblMonth1.BackColor = System.Drawing.Color.Transparent;
            this.lblMonth1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth1.Location = new System.Drawing.Point(681, 21);
            this.lblMonth1.Name = "lblMonth1";
            this.lblMonth1.Size = new System.Drawing.Size(20, 23);
            this.lblMonth1.TabIndex = 6;
            this.lblMonth1.Text = "0";
            // 
            // lblDay2
            // 
            this.lblDay2.AutoSize = true;
            this.lblDay2.BackColor = System.Drawing.Color.Transparent;
            this.lblDay2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay2.Location = new System.Drawing.Point(648, 21);
            this.lblDay2.Name = "lblDay2";
            this.lblDay2.Size = new System.Drawing.Size(20, 23);
            this.lblDay2.TabIndex = 5;
            this.lblDay2.Text = "5";
            // 
            // lblDay1
            // 
            this.lblDay1.AutoSize = true;
            this.lblDay1.BackColor = System.Drawing.Color.Transparent;
            this.lblDay1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay1.Location = new System.Drawing.Point(618, 20);
            this.lblDay1.Name = "lblDay1";
            this.lblDay1.Size = new System.Drawing.Size(20, 23);
            this.lblDay1.TabIndex = 4;
            this.lblDay1.Text = "2";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(643, 114);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(161, 23);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "**12,345,678.00**";
            // 
            // lblAmountWordLine2
            // 
            this.lblAmountWordLine2.AutoSize = true;
            this.lblAmountWordLine2.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountWordLine2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountWordLine2.Location = new System.Drawing.Point(208, 118);
            this.lblAmountWordLine2.Name = "lblAmountWordLine2";
            this.lblAmountWordLine2.Size = new System.Drawing.Size(365, 23);
            this.lblAmountWordLine2.TabIndex = 2;
            this.lblAmountWordLine2.Text = "Thousand Six Hundred And Seventy Eight Only";
            // 
            // lblAmountWordLine1
            // 
            this.lblAmountWordLine1.AutoSize = true;
            this.lblAmountWordLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountWordLine1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountWordLine1.Location = new System.Drawing.Point(243, 94);
            this.lblAmountWordLine1.Name = "lblAmountWordLine1";
            this.lblAmountWordLine1.Size = new System.Drawing.Size(354, 23);
            this.lblAmountWordLine1.TabIndex = 1;
            this.lblAmountWordLine1.Text = "Twelve Million Three Hundred And Forty Five";
            // 
            // lblPayee
            // 
            this.lblPayee.AutoSize = true;
            this.lblPayee.BackColor = System.Drawing.Color.Transparent;
            this.lblPayee.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayee.Location = new System.Drawing.Point(206, 59);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(189, 23);
            this.lblPayee.TabIndex = 0;
            this.lblPayee.Text = "Digiteq Solution Pvt Ltd";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.LightGray;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(366, 443);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 25);
            this.btnProcess.TabIndex = 22;
            this.btnProcess.Text = "    Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtCounterBookLength
            // 
            this.txtCounterBookLength.Location = new System.Drawing.Point(769, 44);
            this.txtCounterBookLength.Name = "txtCounterBookLength";
            this.txtCounterBookLength.Size = new System.Drawing.Size(146, 22);
            this.txtCounterBookLength.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Counter Book Length";
            // 
            // frm_mtrChequeFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 475);
            this.Controls.Add(this.txtCounterBookLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.pnlChequeLayout);
            this.Controls.Add(this.txtYmargin);
            this.Controls.Add(this.txtXmargin);
            this.Controls.Add(this.lblYmargin);
            this.Controls.Add(this.lblXmargin);
            this.Controls.Add(this.dgvChequeDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtChequeFormatCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblChequeFormatCode);
            this.Controls.Add(this.dgvChequeDes);
            this.Controls.Add(this.txtChequeFormatID);
            this.Name = "frm_mtrChequeFormat";
            this.Text = "Cheque Format";
            this.Load += new System.EventHandler(this.frm_mtrChequeFormat_Load);
            this.Controls.SetChildIndex(this.txtChequeFormatID, 0);
            this.Controls.SetChildIndex(this.dgvChequeDes, 0);
            this.Controls.SetChildIndex(this.lblChequeFormatCode, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.txtChequeFormatCode, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.pnlLine, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.dgvChequeDetail, 0);
            this.Controls.SetChildIndex(this.lblXmargin, 0);
            this.Controls.SetChildIndex(this.lblYmargin, 0);
            this.Controls.SetChildIndex(this.txtXmargin, 0);
            this.Controls.SetChildIndex(this.txtYmargin, 0);
            this.Controls.SetChildIndex(this.pnlChequeLayout, 0);
            this.Controls.SetChildIndex(this.btnProcess, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCounterBookLength, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDetail)).EndInit();
            this.pnlChequeLayout.ResumeLayout(false);
            this.pnlChequeLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvChequeDes;
        private System.Windows.Forms.Label lblChequeFormatCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtChequeFormatCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvChequeDetail;
        private System.Windows.Forms.TextBox txtChequeFormatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeFormat_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeFormat_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeFormatDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn element_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontType_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn xValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn yValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.Label lblXmargin;
        private System.Windows.Forms.Label lblYmargin;
        private System.Windows.Forms.TextBox txtXmargin;
        private System.Windows.Forms.TextBox txtYmargin;
        private System.Windows.Forms.Panel pnlChequeLayout;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label lblYear4;
        private System.Windows.Forms.Label lblYear3;
        private System.Windows.Forms.Label lblMonth2;
        private System.Windows.Forms.Label lblMonth1;
        private System.Windows.Forms.Label lblDay2;
        private System.Windows.Forms.Label lblDay1;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountWordLine2;
        private System.Windows.Forms.Label lblAmountWordLine1;
        private System.Windows.Forms.Label lblAmountWordLine3;
        private System.Windows.Forms.Label lblAmountCB;
        private System.Windows.Forms.Label lblCBPayee4;
        private System.Windows.Forms.Label lblCBPayee3;
        private System.Windows.Forms.Label lblCBPayee2;
        private System.Windows.Forms.Label lblCBPayee1;
        private System.Windows.Forms.Label lblCBDate;
        private System.Windows.Forms.Label lblAccountPayee;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.TextBox txtCounterBookLength;
        private System.Windows.Forms.Label label1;
    }
}