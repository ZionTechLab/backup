
namespace Digiteq
{
    partial class frm_BookNoAllocate_Receipt
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridMain = new Digiteq.SEACC_DataGrid();
            this.PageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSalesRep = new SEACC.WinFormControls.Components.xComboBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.txtRemarks = new SEACC.WinFormControls.Components.xTextBox();
            this.txtBookNo = new SEACC.WinFormControls.Components.xTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStart = new SEACC.WinFormControls.Components.xTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPreFix = new SEACC.WinFormControls.Components.xTextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtLength = new SEACC.WinFormControls.Components.xTextBox();
            this.txtEnd = new SEACC.WinFormControls.Components.xTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(493, 285);
            this.panel1.TabIndex = 51;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridMain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(334, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(159, 285);
            this.panel3.TabIndex = 34;
            // 
            // gridMain
            // 
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PageNo});
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(5, 5);
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(149, 275);
            this.gridMain.TabIndex = 0;
            // 
            // PageNo
            // 
            this.PageNo.DataPropertyName = "PageNo";
            this.PageNo.HeaderText = "Page No";
            this.PageNo.Name = "PageNo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSalesRep);
            this.panel2.Controls.Add(this.btnShowAll);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.txtBookNo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtStart);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.txtPreFix);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Controls.Add(this.txtLength);
            this.panel2.Controls.Add(this.txtEnd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(334, 285);
            this.panel2.TabIndex = 33;
            // 
            // cmbSalesRep
            // 
            this.cmbSalesRep.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbSalesRep.BackColor = System.Drawing.Color.Transparent;
            this.cmbSalesRep.ComboBoxText = "";
            this.cmbSalesRep.DataSource = null;
            this.cmbSalesRep.DisplayMember = "";
            this.cmbSalesRep.DisplayText = "Sales Rep :";
            this.cmbSalesRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesRep.Location = new System.Drawing.Point(10, 10);
            this.cmbSalesRep.Margin = new System.Windows.Forms.Padding(0);
            this.cmbSalesRep.Name = "cmbSalesRep";
            this.cmbSalesRep.SelectedIndex = -1;
            this.cmbSalesRep.SelectedItem = null;
            this.cmbSalesRep.SelectedValue = "";
            this.cmbSalesRep.Size = new System.Drawing.Size(312, 21);
            this.cmbSalesRep.TabIndex = 3;
            this.cmbSalesRep.ValueMember = "";
            this.cmbSalesRep.WidthCombo = 180;
            this.cmbSalesRep.WidthText = 66;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(260, 193);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(62, 23);
            this.btnShowAll.TabIndex = 32;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtRemarks.AllowSpecialCaractors = true;
            this.txtRemarks.BackColor = System.Drawing.Color.Transparent;
            this.txtRemarks.DisplayText = "Remarks :";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(10, 157);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemarks.MaxLength = 32767;
            this.txtRemarks.Multiline = false;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(312, 23);
            this.txtRemarks.TabIndex = 1;
            this.txtRemarks.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRemarks.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Standerd;
            this.txtRemarks.WidthText = 245;
            // 
            // txtBookNo
            // 
            this.txtBookNo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtBookNo.AllowSpecialCaractors = true;
            this.txtBookNo.BackColor = System.Drawing.Color.Transparent;
            this.txtBookNo.DisplayText = "Book No :";
            this.txtBookNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNo.Location = new System.Drawing.Point(10, 31);
            this.txtBookNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtBookNo.MaxLength = 32767;
            this.txtBookNo.Multiline = false;
            this.txtBookNo.Name = "txtBookNo";
            this.txtBookNo.Size = new System.Drawing.Size(312, 22);
            this.txtBookNo.TabIndex = 1;
            this.txtBookNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBookNo.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Standerd;
            this.txtBookNo.WidthText = 245;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(198, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStart
            // 
            this.txtStart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtStart.AllowSpecialCaractors = true;
            this.txtStart.BackColor = System.Drawing.Color.Transparent;
            this.txtStart.DisplayText = "Start :";
            this.txtStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(10, 104);
            this.txtStart.Margin = new System.Windows.Forms.Padding(0);
            this.txtStart.MaxLength = 32767;
            this.txtStart.Multiline = false;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(312, 21);
            this.txtStart.TabIndex = 1;
            this.txtStart.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStart.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Numaric;
            this.txtStart.WidthText = 245;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(137, 193);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "New";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtPreFix
            // 
            this.txtPreFix.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtPreFix.AllowSpecialCaractors = true;
            this.txtPreFix.BackColor = System.Drawing.Color.Transparent;
            this.txtPreFix.DisplayText = "Prefix :";
            this.txtPreFix.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreFix.Location = new System.Drawing.Point(10, 62);
            this.txtPreFix.Margin = new System.Windows.Forms.Padding(0);
            this.txtPreFix.MaxLength = 32767;
            this.txtPreFix.Multiline = false;
            this.txtPreFix.Name = "txtPreFix";
            this.txtPreFix.Size = new System.Drawing.Size(312, 21);
            this.txtPreFix.TabIndex = 1;
            this.txtPreFix.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreFix.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Standerd;
            this.txtPreFix.WidthText = 245;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(76, 193);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(55, 23);
            this.btnProcess.TabIndex = 30;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtLength
            // 
            this.txtLength.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtLength.AllowSpecialCaractors = true;
            this.txtLength.BackColor = System.Drawing.Color.Transparent;
            this.txtLength.DisplayText = "Length :";
            this.txtLength.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLength.Location = new System.Drawing.Point(10, 83);
            this.txtLength.Margin = new System.Windows.Forms.Padding(0);
            this.txtLength.MaxLength = 32767;
            this.txtLength.Multiline = false;
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(312, 21);
            this.txtLength.TabIndex = 1;
            this.txtLength.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLength.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Numaric;
            this.txtLength.WidthText = 245;
            // 
            // txtEnd
            // 
            this.txtEnd.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtEnd.AllowSpecialCaractors = true;
            this.txtEnd.BackColor = System.Drawing.Color.Transparent;
            this.txtEnd.DisplayText = "End :";
            this.txtEnd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnd.Location = new System.Drawing.Point(10, 125);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(0);
            this.txtEnd.MaxLength = 32767;
            this.txtEnd.Multiline = false;
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(312, 32);
            this.txtEnd.TabIndex = 1;
            this.txtEnd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEnd.TextBoxtype = SEACC.WinFormControls.Components.TextBxType.Numaric;
            this.txtEnd.WidthText = 245;
            // 
            // frm_BookNoAllocate_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 324);
            this.Controls.Add(this.panel1);
            this.Name = "frm_BookNoAllocate_Receipt";
            this.Text = "Book No Allocate Receipt";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SEACC.WinFormControls.Components.xTextBox txtBookNo;
        private SEACC.WinFormControls.Components.xComboBox cmbSalesRep;
        private SEACC.WinFormControls.Components.xTextBox txtEnd;
        private SEACC.WinFormControls.Components.xTextBox txtStart;
        private SEACC.WinFormControls.Components.xTextBox txtLength;
        private SEACC.WinFormControls.Components.xTextBox txtPreFix;
        private System.Windows.Forms.Panel panel3;
        private SEACC_DataGrid gridMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcess;
        private SEACC.WinFormControls.Components.xTextBox txtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNo;
    }
}