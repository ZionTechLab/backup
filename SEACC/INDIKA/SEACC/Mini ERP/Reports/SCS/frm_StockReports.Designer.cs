namespace Digiteq.Reports.SCS
{
    partial class frm_StockReports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridMain = new Digiteq.SEACC_DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtQty = new SEACC.WinFormControls.Components.xTextBox();
            this.chkShowLessThan = new System.Windows.Forms.CheckBox();
            this.rdoItemWise = new System.Windows.Forms.RadioButton();
            this.rdoStoreWise = new System.Windows.Forms.RadioButton();
            this.cmbStore = new SEACC.WinFormControls.Components.xCheckComboBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cmbItemClass = new SEACC.WinFormControls.Components.xCheckComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHideZeroQty = new System.Windows.Forms.CheckBox();
            this.cmbItemType = new SEACC.WinFormControls.Components.xCheckComboBox();
            this.cmbItemCat = new SEACC.WinFormControls.Components.xCheckComboBox();
            this.btnrint = new System.Windows.Forms.Button();
            this.btnRetrive = new System.Windows.Forms.Button();
            this.chkShowDeactivate = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 439);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(380, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 439);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // gridMain
            // 
            this.gridMain.AllowUserToAddRows = false;
            this.gridMain.AllowUserToDeleteRows = false;
            this.gridMain.AllowUserToResizeRows = false;
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(3, 18);
            this.gridMain.Name = "gridMain";
            this.gridMain.RowHeadersVisible = false;
            this.gridMain.Size = new System.Drawing.Size(691, 418);
            this.gridMain.TabIndex = 0;
            this.gridMain.Tag = "Stock Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.btnrint);
            this.groupBox1.Controls.Add(this.btnRetrive);
            this.groupBox1.Controls.Add(this.chkShowDeactivate);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.pnlDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.chkShowLessThan);
            this.panel2.Controls.Add(this.rdoItemWise);
            this.panel2.Controls.Add(this.rdoStoreWise);
            this.panel2.Controls.Add(this.cmbStore);
            this.panel2.Controls.Add(this.txtItem);
            this.panel2.Controls.Add(this.cmbItemClass);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkHideZeroQty);
            this.panel2.Controls.Add(this.cmbItemType);
            this.panel2.Controls.Add(this.cmbItemCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 213);
            this.panel2.TabIndex = 598;
            // 
            // txtQty
            // 
            this.txtQty.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtQty.AllowSpecialCaractors = true;
            this.txtQty.BackColor = System.Drawing.Color.Transparent;
            this.txtQty.DisplayText = "";
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(177, 142);
            this.txtQty.Margin = new System.Windows.Forms.Padding(0);
            this.txtQty.MaxLength = 32767;
            this.txtQty.Multiline = false;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(151, 21);
            this.txtQty.TabIndex = 601;
            this.txtQty.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtQty.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Numaric;
            this.txtQty.WidthText = 151;
            // 
            // chkShowLessThan
            // 
            this.chkShowLessThan.AutoSize = true;
            this.chkShowLessThan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowLessThan.ForeColor = System.Drawing.Color.Black;
            this.chkShowLessThan.Location = new System.Drawing.Point(84, 142);
            this.chkShowLessThan.Name = "chkShowLessThan";
            this.chkShowLessThan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowLessThan.Size = new System.Drawing.Size(96, 17);
            this.chkShowLessThan.TabIndex = 599;
            this.chkShowLessThan.Text = "Qty Less Than";
            this.chkShowLessThan.UseVisualStyleBackColor = true;
            this.chkShowLessThan.CheckedChanged += new System.EventHandler(this.chkShowLessThan_CheckedChanged);
            // 
            // rdoItemWise
            // 
            this.rdoItemWise.AutoSize = true;
            this.rdoItemWise.Checked = true;
            this.rdoItemWise.Location = new System.Drawing.Point(84, 188);
            this.rdoItemWise.Name = "rdoItemWise";
            this.rdoItemWise.Size = new System.Drawing.Size(75, 17);
            this.rdoItemWise.TabIndex = 598;
            this.rdoItemWise.TabStop = true;
            this.rdoItemWise.Text = "Item Wise";
            this.rdoItemWise.UseVisualStyleBackColor = true;
            // 
            // rdoStoreWise
            // 
            this.rdoStoreWise.AutoSize = true;
            this.rdoStoreWise.Location = new System.Drawing.Point(84, 165);
            this.rdoStoreWise.Name = "rdoStoreWise";
            this.rdoStoreWise.Size = new System.Drawing.Size(80, 17);
            this.rdoStoreWise.TabIndex = 598;
            this.rdoStoreWise.Text = "Store Wise";
            this.rdoStoreWise.UseVisualStyleBackColor = true;
            // 
            // cmbStore
            // 
            this.cmbStore.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbStore.BackColor = System.Drawing.Color.Transparent;
            this.cmbStore.Checked = false;
            this.cmbStore.ComboBoxText = "";
            this.cmbStore.DataSource = null;
            this.cmbStore.DisplayMember = "";
            this.cmbStore.DisplayText = "Store :";
            this.cmbStore.DisplayText_All = "All";
            this.cmbStore.EnableCheckBox = true;
            this.cmbStore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStore.Location = new System.Drawing.Point(11, 6);
            this.cmbStore.Margin = new System.Windows.Forms.Padding(0);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.SelectedIndex = 0;
            this.cmbStore.Size = new System.Drawing.Size(361, 22);
            this.cmbStore.TabIndex = 1;
            this.cmbStore.ValueMember = "";
            this.cmbStore.WidthCombo = 180;
            this.cmbStore.WidthText = 65;
            this.cmbStore.SelectionChanged += new SEACC.WinFormControls.Components.xCheckComboBox.SelectionChangedEventHandler(this.cmbStore_SelectionChanged);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(84, 93);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(244, 22);
            this.txtItem.TabIndex = 597;
            this.txtItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyUp);
            // 
            // cmbItemClass
            // 
            this.cmbItemClass.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbItemClass.BackColor = System.Drawing.Color.Transparent;
            this.cmbItemClass.Checked = false;
            this.cmbItemClass.ComboBoxText = "";
            this.cmbItemClass.DataSource = null;
            this.cmbItemClass.DisplayMember = "";
            this.cmbItemClass.DisplayText = "Item Class :";
            this.cmbItemClass.DisplayText_All = "All";
            this.cmbItemClass.EnableCheckBox = true;
            this.cmbItemClass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemClass.Location = new System.Drawing.Point(11, 27);
            this.cmbItemClass.Margin = new System.Windows.Forms.Padding(0);
            this.cmbItemClass.Name = "cmbItemClass";
            this.cmbItemClass.SelectedIndex = 0;
            this.cmbItemClass.Size = new System.Drawing.Size(361, 22);
            this.cmbItemClass.TabIndex = 1;
            this.cmbItemClass.ValueMember = "";
            this.cmbItemClass.WidthCombo = 180;
            this.cmbItemClass.WidthText = 65;
            this.cmbItemClass.SelectionChanged += new SEACC.WinFormControls.Components.xCheckComboBox.SelectionChangedEventHandler(this.cmbItemClass_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 596;
            this.label2.Text = "Item :";
            // 
            // chkHideZeroQty
            // 
            this.chkHideZeroQty.AutoSize = true;
            this.chkHideZeroQty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHideZeroQty.ForeColor = System.Drawing.Color.Black;
            this.chkHideZeroQty.Location = new System.Drawing.Point(84, 121);
            this.chkHideZeroQty.Name = "chkHideZeroQty";
            this.chkHideZeroQty.Size = new System.Drawing.Size(132, 17);
            this.chkHideZeroQty.TabIndex = 18;
            this.chkHideZeroQty.Text = "Hide Zero Quantities";
            this.chkHideZeroQty.UseVisualStyleBackColor = true;
            // 
            // cmbItemType
            // 
            this.cmbItemType.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbItemType.BackColor = System.Drawing.Color.Transparent;
            this.cmbItemType.Checked = false;
            this.cmbItemType.ComboBoxText = "";
            this.cmbItemType.DataSource = null;
            this.cmbItemType.DisplayMember = "";
            this.cmbItemType.DisplayText = "Item Type :";
            this.cmbItemType.DisplayText_All = "All";
            this.cmbItemType.EnableCheckBox = true;
            this.cmbItemType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemType.Location = new System.Drawing.Point(11, 48);
            this.cmbItemType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.SelectedIndex = 0;
            this.cmbItemType.Size = new System.Drawing.Size(361, 22);
            this.cmbItemType.TabIndex = 1;
            this.cmbItemType.ValueMember = "";
            this.cmbItemType.WidthCombo = 180;
            this.cmbItemType.WidthText = 65;
            this.cmbItemType.SelectionChanged += new SEACC.WinFormControls.Components.xCheckComboBox.SelectionChangedEventHandler(this.cmbItemType_SelectionChanged);
            // 
            // cmbItemCat
            // 
            this.cmbItemCat.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbItemCat.BackColor = System.Drawing.Color.Transparent;
            this.cmbItemCat.Checked = false;
            this.cmbItemCat.ComboBoxText = "";
            this.cmbItemCat.DataSource = null;
            this.cmbItemCat.DisplayMember = "";
            this.cmbItemCat.DisplayText = "Item Category :";
            this.cmbItemCat.DisplayText_All = "All";
            this.cmbItemCat.EnableCheckBox = true;
            this.cmbItemCat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemCat.Location = new System.Drawing.Point(-4, 69);
            this.cmbItemCat.Margin = new System.Windows.Forms.Padding(0);
            this.cmbItemCat.Name = "cmbItemCat";
            this.cmbItemCat.SelectedIndex = 0;
            this.cmbItemCat.Size = new System.Drawing.Size(376, 22);
            this.cmbItemCat.TabIndex = 1;
            this.cmbItemCat.ValueMember = "";
            this.cmbItemCat.WidthCombo = 180;
            this.cmbItemCat.WidthText = 65;
            this.cmbItemCat.SelectionChanged += new SEACC.WinFormControls.Components.xCheckComboBox.SelectionChangedEventHandler(this.cmbItemCat_SelectionChanged);
            // 
            // btnrint
            // 
            this.btnrint.Location = new System.Drawing.Point(286, 324);
            this.btnrint.Name = "btnrint";
            this.btnrint.Size = new System.Drawing.Size(75, 23);
            this.btnrint.TabIndex = 0;
            this.btnrint.Text = "Export";
            this.btnrint.UseVisualStyleBackColor = true;
            this.btnrint.Click += new System.EventHandler(this.btnrint_Click);
            // 
            // btnRetrive
            // 
            this.btnRetrive.Location = new System.Drawing.Point(205, 324);
            this.btnRetrive.Name = "btnRetrive";
            this.btnRetrive.Size = new System.Drawing.Size(75, 23);
            this.btnRetrive.TabIndex = 0;
            this.btnRetrive.Text = "Retrive";
            this.btnRetrive.UseVisualStyleBackColor = true;
            this.btnRetrive.Click += new System.EventHandler(this.btnRetrive_Click);
            // 
            // chkShowDeactivate
            // 
            this.chkShowDeactivate.AutoSize = true;
            this.chkShowDeactivate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowDeactivate.ForeColor = System.Drawing.Color.Black;
            this.chkShowDeactivate.Location = new System.Drawing.Point(87, 237);
            this.chkShowDeactivate.Name = "chkShowDeactivate";
            this.chkShowDeactivate.Size = new System.Drawing.Size(141, 17);
            this.chkShowDeactivate.TabIndex = 10;
            this.chkShowDeactivate.Text = "Show Deactivate Items";
            this.chkShowDeactivate.UseVisualStyleBackColor = true;
            this.chkShowDeactivate.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(14, 324);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Controls.Add(this.label4);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Location = new System.Drawing.Point(13, 257);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(318, 60);
            this.pnlDate.TabIndex = 595;
            this.pnlDate.Visible = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(107, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(99, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 585;
            this.label4.Text = "Period To :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(99, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // frm_StockReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 478);
            this.Controls.Add(this.panel1);
            this.Name = "frm_StockReports";
            this.Text = "Stock Reports";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private SEACC.WinFormControls.Components.xCheckComboBox cmbItemCat;
        private SEACC.WinFormControls.Components.xCheckComboBox cmbItemType;
        private SEACC.WinFormControls.Components.xCheckComboBox cmbItemClass;
        private SEACC.WinFormControls.Components.xCheckComboBox cmbStore;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.CheckBox chkShowDeactivate;
        private System.Windows.Forms.CheckBox chkHideZeroQty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRetrive;
        private System.Windows.Forms.Button btnClear;
        private SEACC_DataGrid gridMain;
        private System.Windows.Forms.Button btnrint;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoItemWise;
        private System.Windows.Forms.RadioButton rdoStoreWise;
        private System.Windows.Forms.CheckBox chkShowLessThan;
        private SEACC.WinFormControls.Components.xTextBox txtQty;
    }
}