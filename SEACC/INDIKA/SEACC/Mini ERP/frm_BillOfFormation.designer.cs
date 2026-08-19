namespace Digiteq
{
    partial class frm_BillOfFormation
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
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWPresentage = new System.Windows.Forms.TextBox();
            this.txtFGPresentage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWStore = new System.Windows.Forms.TextBox();
            this.txtFGStore = new System.Windows.Forms.TextBox();
            this.txtWItem = new System.Windows.Forms.TextBox();
            this.txtFGItem = new System.Windows.Forms.TextBox();
            this.txtSubCategory2 = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridFG = new Digiteq.SEACC_DataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRMitem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRMStore = new System.Windows.Forms.TextBox();
            this.txtRMPresentage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.xpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFG)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.Transparent;
            this.xpanel1.Controls.Add(this.label6);
            this.xpanel1.Controls.Add(this.label3);
            this.xpanel1.Controls.Add(this.label1);
            this.xpanel1.Controls.Add(this.txtWPresentage);
            this.xpanel1.Controls.Add(this.txtFGPresentage);
            this.xpanel1.Controls.Add(this.label4);
            this.xpanel1.Controls.Add(this.label2);
            this.xpanel1.Controls.Add(this.txtWStore);
            this.xpanel1.Controls.Add(this.txtFGStore);
            this.xpanel1.Controls.Add(this.txtWItem);
            this.xpanel1.Controls.Add(this.txtFGItem);
            this.xpanel1.Controls.Add(this.txtSubCategory2);
            this.xpanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xpanel1.Location = new System.Drawing.Point(258, 38);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(438, 107);
            this.xpanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(40, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 597;
            this.label6.Text = "Store :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(43, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 14);
            this.label3.TabIndex = 595;
            this.label3.Text = "Item :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 594;
            this.label1.Text = "Presentage :";
            // 
            // txtWPresentage
            // 
            this.txtWPresentage.BackColor = System.Drawing.Color.White;
            this.txtWPresentage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWPresentage.Location = new System.Drawing.Point(260, 70);
            this.txtWPresentage.Name = "txtWPresentage";
            this.txtWPresentage.Size = new System.Drawing.Size(171, 22);
            this.txtWPresentage.TabIndex = 592;
            this.txtWPresentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWPresentage_KeyPress);
            // 
            // txtFGPresentage
            // 
            this.txtFGPresentage.BackColor = System.Drawing.Color.White;
            this.txtFGPresentage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGPresentage.Location = new System.Drawing.Point(83, 70);
            this.txtFGPresentage.Name = "txtFGPresentage";
            this.txtFGPresentage.Size = new System.Drawing.Size(171, 22);
            this.txtFGPresentage.TabIndex = 592;
            this.txtFGPresentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFGPresentage_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(260, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 587;
            this.label4.Text = "Wastage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(80, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 587;
            this.label2.Text = "Finish Good";
            // 
            // txtWStore
            // 
            this.txtWStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtWStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWStore.Location = new System.Drawing.Point(260, 46);
            this.txtWStore.Name = "txtWStore";
            this.txtWStore.ReadOnly = true;
            this.txtWStore.Size = new System.Drawing.Size(171, 22);
            this.txtWStore.TabIndex = 586;
            this.txtWStore.DoubleClick += new System.EventHandler(this.txtWStore_DoubleClick);
            // 
            // txtFGStore
            // 
            this.txtFGStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtFGStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGStore.Location = new System.Drawing.Point(83, 46);
            this.txtFGStore.Name = "txtFGStore";
            this.txtFGStore.ReadOnly = true;
            this.txtFGStore.Size = new System.Drawing.Size(171, 22);
            this.txtFGStore.TabIndex = 586;
            this.txtFGStore.DoubleClick += new System.EventHandler(this.txtFGStore_DoubleClick);
            // 
            // txtWItem
            // 
            this.txtWItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtWItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWItem.Location = new System.Drawing.Point(260, 23);
            this.txtWItem.Name = "txtWItem";
            this.txtWItem.ReadOnly = true;
            this.txtWItem.Size = new System.Drawing.Size(171, 22);
            this.txtWItem.TabIndex = 586;
            this.txtWItem.DoubleClick += new System.EventHandler(this.txtWItem_DoubleClick);
            // 
            // txtFGItem
            // 
            this.txtFGItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtFGItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGItem.Location = new System.Drawing.Point(83, 23);
            this.txtFGItem.Name = "txtFGItem";
            this.txtFGItem.ReadOnly = true;
            this.txtFGItem.Size = new System.Drawing.Size(171, 22);
            this.txtFGItem.TabIndex = 586;
            this.txtFGItem.DoubleClick += new System.EventHandler(this.txtFGItem_DoubleClick);
            // 
            // txtSubCategory2
            // 
            this.txtSubCategory2.BackColor = System.Drawing.Color.White;
            this.txtSubCategory2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2.Location = new System.Drawing.Point(453, 177);
            this.txtSubCategory2.Name = "txtSubCategory2";
            this.txtSubCategory2.Size = new System.Drawing.Size(152, 22);
            this.txtSubCategory2.TabIndex = 574;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.accept;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(444, 425);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 23);
            this.btnNew.TabIndex = 585;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(606, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 569;
            this.btnCancel.Text = "   Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(525, 425);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 568;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_ID,
            this.ItemName,
            this.SellingPrice,
            this.maxDiscount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(264, 191);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(421, 228);
            this.dgvDetail.TabIndex = 567;
          //  this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick_1);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellLeave);
            this.dgvDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetail_CellValidating);
            this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
            this.dgvDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDetail_KeyPress);
            // 
            // item_ID
            // 
            this.item_ID.DataPropertyName = "item_ID";
            this.item_ID.HeaderText = "Item ID";
            this.item_ID.Name = "item_ID";
            this.item_ID.ReadOnly = true;
            this.item_ID.Width = 80;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "itemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "Presenage";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.SellingPrice.HeaderText = "Presenage";
            this.SellingPrice.Name = "SellingPrice";
            // 
            // maxDiscount
            // 
            this.maxDiscount.DataPropertyName = "Store";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.maxDiscount.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxDiscount.HeaderText = "Store";
            this.maxDiscount.Name = "maxDiscount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridFG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(1, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7);
            this.panel1.Size = new System.Drawing.Size(257, 421);
            this.panel1.TabIndex = 568;
            // 
            // gridFG
            // 
            this.gridFG.AllowUserToAddRows = false;
            this.gridFG.BackgroundColor = System.Drawing.Color.DarkGray;
            this.gridFG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridFG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridFG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFG.EnableHeadersVisualStyles = false;
            this.gridFG.Location = new System.Drawing.Point(7, 7);
            this.gridFG.MultiSelect = false;
            this.gridFG.Name = "gridFG";
            this.gridFG.RowHeadersVisible = false;
            this.gridFG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFG.Size = new System.Drawing.Size(243, 407);
            this.gridFG.TabIndex = 568;
            this.gridFG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFG_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "item_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Item ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "itemName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(264, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 598;
            this.label5.Text = "Row Meterial";
            // 
            // txtRMitem
            // 
            this.txtRMitem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRMitem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMitem.Location = new System.Drawing.Point(304, 165);
            this.txtRMitem.Name = "txtRMitem";
            this.txtRMitem.ReadOnly = true;
            this.txtRMitem.Size = new System.Drawing.Size(99, 22);
            this.txtRMitem.TabIndex = 598;
            this.txtRMitem.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(264, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 598;
            this.label7.Text = "Item :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(409, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 14);
            this.label8.TabIndex = 599;
            this.label8.Text = "@";
            // 
            // txtRMStore
            // 
            this.txtRMStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRMStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStore.Location = new System.Drawing.Point(425, 165);
            this.txtRMStore.Name = "txtRMStore";
            this.txtRMStore.ReadOnly = true;
            this.txtRMStore.Size = new System.Drawing.Size(99, 22);
            this.txtRMStore.TabIndex = 598;
            this.txtRMStore.DoubleClick += new System.EventHandler(this.txtRMStore_DoubleClick);
            // 
            // txtRMPresentage
            // 
            this.txtRMPresentage.BackColor = System.Drawing.Color.White;
            this.txtRMPresentage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMPresentage.Location = new System.Drawing.Point(530, 165);
            this.txtRMPresentage.Name = "txtRMPresentage";
            this.txtRMPresentage.Size = new System.Drawing.Size(39, 22);
            this.txtRMPresentage.TabIndex = 592;
            this.txtRMPresentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRMPresentage_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(582, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 14);
            this.label9.TabIndex = 600;
            this.label9.Text = "%";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Digiteq.Properties.Resources._Arrow_Down;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(609, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 601;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_BillOfFormation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 460);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRMStore);
            this.Controls.Add(this.txtRMitem);
            this.Controls.Add(this.txtRMPresentage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_BillOfFormation";
            this.Text = "Bill Of Formation";
            this.Load += new System.EventHandler(this.frm_masItemMasterFinance_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.xpanel1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtRMPresentage, 0);
            this.Controls.SetChildIndex(this.txtRMitem, 0);
            this.Controls.SetChildIndex(this.txtRMStore, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel xpanel1;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubCategory2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtFGItem;
        private System.Windows.Forms.TextBox txtFGPresentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWPresentage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWStore;
        private System.Windows.Forms.TextBox txtFGStore;
        private System.Windows.Forms.TextBox txtWItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxDiscount;
        private System.Windows.Forms.Panel panel1;
        private SEACC_DataGrid gridFG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRMitem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRMStore;
        private System.Windows.Forms.TextBox txtRMPresentage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}