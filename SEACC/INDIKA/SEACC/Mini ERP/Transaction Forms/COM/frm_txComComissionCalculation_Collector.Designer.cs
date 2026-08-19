namespace Digiteq.Transaction_Forms.COM
{
    partial class frm_txComComissionCalculation_Collector
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
            this.txtComPeriod = new System.Windows.Forms.TextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dgvMain = new SEACC_DataGrid();
            this.selesRep_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // txtComPeriod
            // 
            this.txtComPeriod.BackColor = System.Drawing.Color.LightGray;
            this.txtComPeriod.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComPeriod.Location = new System.Drawing.Point(81, 34);
            this.txtComPeriod.Name = "txtComPeriod";
            this.txtComPeriod.ReadOnly = true;
            this.txtComPeriod.Size = new System.Drawing.Size(267, 22);
            this.txtComPeriod.TabIndex = 51;
            this.txtComPeriod.DoubleClick += new System.EventHandler(this.txtComPeriod_DoubleClick);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.Black;
            this.lblPeriod.Location = new System.Drawing.Point(9, 38);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(74, 15);
            this.lblPeriod.TabIndex = 52;
            this.lblPeriod.Text = "R. A. Period :";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMain.ColumnHeadersHeight = 35;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selesRep_ID,
            this.selesRepName,
            this.totalAmount,
            this.deductions,
            this.netAmount,
            this.isApproved});
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Location = new System.Drawing.Point(12, 116);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(636, 272);
            this.dgvMain.TabIndex = 53;
            this.dgvMain.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMain_CellBeginEdit);
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvMain_KeyPress);
            // 
            // selesRep_ID
            // 
            this.selesRep_ID.DataPropertyName = "collecter_ID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.selesRep_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.selesRep_ID.HeaderText = "Collector Code";
            this.selesRep_ID.Name = "selesRep_ID";
            this.selesRep_ID.ReadOnly = true;
            this.selesRep_ID.Width = 70;
            // 
            // selesRepName
            // 
            this.selesRepName.DataPropertyName = "collecterName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.selesRepName.DefaultCellStyle = dataGridViewCellStyle2;
            this.selesRepName.HeaderText = "Collector Name";
            this.selesRepName.Name = "selesRepName";
            this.selesRepName.ReadOnly = true;
            this.selesRepName.Width = 200;
            // 
            // totalAmount
            // 
            this.totalAmount.DataPropertyName = "totalCommishion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.totalAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalAmount.HeaderText = "Gross R. A.";
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.ReadOnly = true;
            // 
            // deductions
            // 
            this.deductions.DataPropertyName = "deductions";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.deductions.DefaultCellStyle = dataGridViewCellStyle4;
            this.deductions.HeaderText = "Deductions";
            this.deductions.Name = "deductions";
            // 
            // netAmount
            // 
            this.netAmount.DataPropertyName = "netCommishion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.netAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.netAmount.HeaderText = "Net R.A.";
            this.netAmount.Name = "netAmount";
            this.netAmount.ReadOnly = true;
            // 
            // isApproved
            // 
            this.isApproved.DataPropertyName = "isApproved";
            this.isApproved.HeaderText = "Approved";
            this.isApproved.Name = "isApproved";
            this.isApproved.ReadOnly = true;
            this.isApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isApproved.Width = 60;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(239, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 25);
            this.btnPrint.TabIndex = 474;
            this.btnPrint.Text = "  Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(12, 75);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(109, 25);
            this.btnLoad.TabIndex = 472;
            this.btnLoad.Text = "Re Calculate";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(126, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 25);
            this.btnSave.TabIndex = 473;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Digiteq.Properties.Resources.Printer;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(354, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 25);
            this.button1.TabIndex = 475;
            this.button1.Text = "Detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_txComComissionCalculation_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 400);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.txtComPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Name = "frm_txComComissionCalculation_Summary";
            this.Text = "Risk Allowance Calculation - Collector";
            this.Load += new System.EventHandler(this.frm_txComComissionCalculation_Collectors_Load);
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.txtComPeriod, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnLoad, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private SEACC_DataGrid dgvMain;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn selesRep_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn selesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn deductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn netAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isApproved;
        private System.Windows.Forms.Button button1;
    }
}