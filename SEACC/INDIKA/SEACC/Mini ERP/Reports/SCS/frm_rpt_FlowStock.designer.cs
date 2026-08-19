namespace Digiteq
{
    partial class frm_rpt_FlowStock
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
            this.rdoStore = new System.Windows.Forms.RadioButton();
            this.rdoDepartment = new System.Windows.Forms.RadioButton();
            this.x1 = new System.Windows.Forms.Panel();
            this.chkJobBase = new System.Windows.Forms.CheckBox();
            this.txtJobCode = new System.Windows.Forms.TextBox();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.z2 = new System.Windows.Forms.Panel();
            this.pnlNoteType = new System.Windows.Forms.Panel();
            this.txtStockNoteType = new System.Windows.Forms.TextBox();
            this.lblNoteType = new System.Windows.Forms.Label();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.z1 = new System.Windows.Forms.Panel();
            this.chkShowZeroItem = new System.Windows.Forms.CheckBox();
            this.chkItemModel1 = new System.Windows.Forms.CheckBox();
            this.chkShowDeactivate = new System.Windows.Forms.CheckBox();
            this.chkBackdate = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.x1.SuspendLayout();
            this.z2.SuspendLayout();
            this.pnlNoteType.SuspendLayout();
            this.z1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoStore
            // 
            this.rdoStore.AutoSize = true;
            this.rdoStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoStore.Location = new System.Drawing.Point(12, 9);
            this.rdoStore.Name = "rdoStore";
            this.rdoStore.Size = new System.Drawing.Size(54, 18);
            this.rdoStore.TabIndex = 2;
            this.rdoStore.TabStop = true;
            this.rdoStore.Text = "Store ";
            this.rdoStore.UseVisualStyleBackColor = true;
            this.rdoStore.CheckedChanged += new System.EventHandler(this.rdoStoreStock_CheckedChanged);
            // 
            // rdoDepartment
            // 
            this.rdoDepartment.AutoSize = true;
            this.rdoDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDepartment.Location = new System.Drawing.Point(12, 64);
            this.rdoDepartment.Name = "rdoDepartment";
            this.rdoDepartment.Size = new System.Drawing.Size(88, 18);
            this.rdoDepartment.TabIndex = 1;
            this.rdoDepartment.TabStop = true;
            this.rdoDepartment.Text = "Department ";
            this.rdoDepartment.UseVisualStyleBackColor = true;
            this.rdoDepartment.CheckedChanged += new System.EventHandler(this.rdoDepartmentStock_CheckedChanged);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.chkJobBase);
            this.x1.Controls.Add(this.txtJobCode);
            this.x1.Controls.Add(this.txtSection);
            this.x1.Controls.Add(this.label3);
            this.x1.Controls.Add(this.rdoSection);
            this.x1.Controls.Add(this.txtDepartment);
            this.x1.Controls.Add(this.rdoStore);
            this.x1.Controls.Add(this.rdoDepartment);
            this.x1.Controls.Add(this.txtStore);
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(329, 36);
            this.x1.TabIndex = 5;
            // 
            // chkJobBase
            // 
            this.chkJobBase.AutoSize = true;
            this.chkJobBase.Enabled = false;
            this.chkJobBase.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJobBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkJobBase.Location = new System.Drawing.Point(121, 92);
            this.chkJobBase.Name = "chkJobBase";
            this.chkJobBase.Size = new System.Drawing.Size(83, 18);
            this.chkJobBase.TabIndex = 478;
            this.chkJobBase.Text = "With Job ID";
            this.chkJobBase.UseVisualStyleBackColor = true;
            // 
            // txtJobCode
            // 
            this.txtJobCode.BackColor = System.Drawing.Color.LightGray;
            this.txtJobCode.Enabled = false;
            this.txtJobCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobCode.Location = new System.Drawing.Point(121, 52);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.ReadOnly = true;
            this.txtJobCode.Size = new System.Drawing.Size(194, 22);
            this.txtJobCode.TabIndex = 15;
            this.txtJobCode.DoubleClick += new System.EventHandler(this.txtJobCode_DoubleClick);
            this.txtJobCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobCode_KeyDown);
            // 
            // txtSection
            // 
            this.txtSection.BackColor = System.Drawing.Color.LightGray;
            this.txtSection.Enabled = false;
            this.txtSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(121, 36);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(194, 22);
            this.txtSection.TabIndex = 477;
            this.txtSection.DoubleClick += new System.EventHandler(this.txtSectionStoke_DoubleClick);
            this.txtSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSection_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Job Code";
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSection.Location = new System.Drawing.Point(12, 38);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(64, 18);
            this.rdoSection.TabIndex = 5;
            this.rdoSection.TabStop = true;
            this.rdoSection.Text = "Section ";
            this.rdoSection.UseVisualStyleBackColor = true;
            this.rdoSection.CheckedChanged += new System.EventHandler(this.rdoSectionStock_CheckedChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.LightGray;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(121, 62);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(194, 22);
            this.txtDepartment.TabIndex = 16;
            this.txtDepartment.DoubleClick += new System.EventHandler(this.txtDepartmentStock_DoubleClick);
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.LightGray;
            this.txtStore.Enabled = false;
            this.txtStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(121, 7);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(194, 22);
            this.txtStore.TabIndex = 15;
            this.txtStore.DoubleClick += new System.EventHandler(this.txtStoreStock_DoubleClick);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.pnlNoteType);
            this.z2.Controls.Add(this.txtItemType);
            this.z2.Controls.Add(this.label2);
            this.z2.Controls.Add(this.txtItemCategory);
            this.z2.Controls.Add(this.label1);
            this.z2.Controls.Add(this.txtItemName);
            this.z2.Controls.Add(this.lblCustomer);
            this.z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z2.Location = new System.Drawing.Point(8, 50);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(329, 121);
            this.z2.TabIndex = 477;
            // 
            // pnlNoteType
            // 
            this.pnlNoteType.Controls.Add(this.txtStockNoteType);
            this.pnlNoteType.Controls.Add(this.lblNoteType);
            this.pnlNoteType.Location = new System.Drawing.Point(1, 81);
            this.pnlNoteType.Name = "pnlNoteType";
            this.pnlNoteType.Size = new System.Drawing.Size(321, 34);
            this.pnlNoteType.TabIndex = 478;
            this.pnlNoteType.Visible = false;
            // 
            // txtStockNoteType
            // 
            this.txtStockNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtStockNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockNoteType.Location = new System.Drawing.Point(120, 5);
            this.txtStockNoteType.Name = "txtStockNoteType";
            this.txtStockNoteType.ReadOnly = true;
            this.txtStockNoteType.Size = new System.Drawing.Size(194, 22);
            this.txtStockNoteType.TabIndex = 17;
            this.txtStockNoteType.DoubleClick += new System.EventHandler(this.txtNoteType_DoubleClick);
            this.txtStockNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoteType_KeyDown);
            // 
            // lblNoteType
            // 
            this.lblNoteType.AutoSize = true;
            this.lblNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNoteType.Location = new System.Drawing.Point(11, 9);
            this.lblNoteType.Name = "lblNoteType";
            this.lblNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblNoteType.TabIndex = 18;
            this.lblNoteType.Text = "Note Type";
            // 
            // txtItemType
            // 
            this.txtItemType.BackColor = System.Drawing.Color.LightGray;
            this.txtItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(121, 6);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.ReadOnly = true;
            this.txtItemType.Size = new System.Drawing.Size(194, 22);
            this.txtItemType.TabIndex = 15;
            this.txtItemType.DoubleClick += new System.EventHandler(this.txtItemType_DoubleClick);
            this.txtItemType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemType_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Item Type";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(121, 34);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.ReadOnly = true;
            this.txtItemCategory.Size = new System.Drawing.Size(194, 22);
            this.txtItemCategory.TabIndex = 13;
            this.txtItemCategory.DoubleClick += new System.EventHandler(this.txtItemCategory_DoubleClick);
            this.txtItemCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCategory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Item Category";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.LightGray;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(121, 61);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(194, 22);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtItemName_DoubleClick);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(12, 64);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Item Name";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(262, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(187, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.chkShowZeroItem);
            this.z1.Controls.Add(this.chkItemModel1);
            this.z1.Controls.Add(this.chkShowDeactivate);
            this.z1.Controls.Add(this.chkBackdate);
            this.z1.Controls.Add(this.dtpTo);
            this.z1.Controls.Add(this.label5);
            this.z1.Location = new System.Drawing.Point(8, 3);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(329, 62);
            this.z1.TabIndex = 478;
            // 
            // chkShowZeroItem
            // 
            this.chkShowZeroItem.AutoSize = true;
            this.chkShowZeroItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowZeroItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowZeroItem.Location = new System.Drawing.Point(119, 34);
            this.chkShowZeroItem.Name = "chkShowZeroItem";
            this.chkShowZeroItem.Size = new System.Drawing.Size(124, 18);
            this.chkShowZeroItem.TabIndex = 19;
            this.chkShowZeroItem.Text = "Show 0 Qty/Weight";
            this.chkShowZeroItem.UseVisualStyleBackColor = true;
            // 
            // chkItemModel1
            // 
            this.chkItemModel1.AutoSize = true;
            this.chkItemModel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemModel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemModel1.Location = new System.Drawing.Point(242, 9);
            this.chkItemModel1.Name = "chkItemModel1";
            this.chkItemModel1.Size = new System.Drawing.Size(77, 18);
            this.chkItemModel1.TabIndex = 18;
            this.chkItemModel1.Text = "Back Date";
            this.chkItemModel1.UseVisualStyleBackColor = true;
            // 
            // chkShowDeactivate
            // 
            this.chkShowDeactivate.AutoSize = true;
            this.chkShowDeactivate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowDeactivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowDeactivate.Location = new System.Drawing.Point(8, 34);
            this.chkShowDeactivate.Name = "chkShowDeactivate";
            this.chkShowDeactivate.Size = new System.Drawing.Size(107, 18);
            this.chkShowDeactivate.TabIndex = 17;
            this.chkShowDeactivate.Text = "Show Deactvate";
            this.chkShowDeactivate.UseVisualStyleBackColor = true;
            // 
            // chkBackdate
            // 
            this.chkBackdate.AutoSize = true;
            this.chkBackdate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBackdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkBackdate.Location = new System.Drawing.Point(243, 34);
            this.chkBackdate.Name = "chkBackdate";
            this.chkBackdate.Size = new System.Drawing.Size(77, 18);
            this.chkBackdate.TabIndex = 16;
            this.chkBackdate.Text = "Back Date";
            this.chkBackdate.UseVisualStyleBackColor = true;
            this.chkBackdate.CheckedChanged += new System.EventHandler(this.chkBackdate_CheckedChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(121, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(115, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(14, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Period To :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 42);
            this.panel1.TabIndex = 479;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 7);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(168, 23);
            this.progressBar1.TabIndex = 477;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.z1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 72);
            this.panel2.TabIndex = 480;
            // 
            // frm_rpt_FlowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(344, 285);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.x1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_FlowStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flow Stock Report";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.pnlNoteType.ResumeLayout(false);
            this.pnlNoteType.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoDepartment;
        private System.Windows.Forms.RadioButton rdoStore;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkJobBase;
        private System.Windows.Forms.TextBox txtStockNoteType;
        private System.Windows.Forms.Label lblNoteType;
        private System.Windows.Forms.Panel pnlNoteType;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.CheckBox chkBackdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkShowDeactivate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkItemModel1;
        private System.Windows.Forms.CheckBox chkShowZeroItem;
    }
}