namespace Digiteq.Transaction_Forms.COM
{
    partial class frm_txComComissionCalculation_Collectors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.grdTxn = new Digiteq.SEACC_DataGrid();
            this.receipt_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setteledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCommishion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfCollecters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devidedCommishion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRAP = new System.Windows.Forms.Label();
            this.lblCollecter = new System.Windows.Forms.Label();
            this.dgvDateSlab = new SEACC_DataGrid();
            this.isSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slabName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deductionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalCommission = new System.Windows.Forms.TextBox();
            this.txtChequeDateDed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSecDepositDed = new System.Windows.Forms.TextBox();
            this.txtAdvDed = new System.Windows.Forms.TextBox();
            this.txtLoanDed = new System.Windows.Forms.TextBox();
            this.txtNetComm = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTxn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateSlab)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(248, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 473;
            this.label6.Text = "Collector :";
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(681, 165);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 25);
            this.btnPrint.TabIndex = 471;
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
            this.btnLoad.Location = new System.Drawing.Point(454, 165);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(109, 25);
            this.btnLoad.TabIndex = 469;
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
            this.btnSave.Location = new System.Drawing.Point(568, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 25);
            this.btnSave.TabIndex = 470;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.Black;
            this.lblPeriod.Location = new System.Drawing.Point(14, 45);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(74, 15);
            this.lblPeriod.TabIndex = 467;
            this.lblPeriod.Text = "R. A. Period :";
            // 
            // grdTxn
            // 
            this.grdTxn.AllowUserToAddRows = false;
            this.grdTxn.AllowUserToDeleteRows = false;
            this.grdTxn.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grdTxn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTxn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdTxn.ColumnHeadersHeight = 35;
            this.grdTxn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receipt_ID,
            this.receiptDate,
            this.setteledAmount,
            this.TotalCommishion,
            this.NoOfCollecters,
            this.presentage,
            this.devidedCommishion});
            this.grdTxn.EnableHeadersVisualStyles = false;
            this.grdTxn.Location = new System.Drawing.Point(17, 206);
            this.grdTxn.MultiSelect = false;
            this.grdTxn.Name = "grdTxn";
            this.grdTxn.ReadOnly = true;
            this.grdTxn.RowHeadersVisible = false;
            this.grdTxn.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTxn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTxn.Size = new System.Drawing.Size(773, 302);
            this.grdTxn.TabIndex = 476;
            // 
            // receipt_ID
            // 
            this.receipt_ID.DataPropertyName = "receipt_ID";
            this.receipt_ID.HeaderText = "Receipt ID";
            this.receipt_ID.Name = "receipt_ID";
            this.receipt_ID.ReadOnly = true;
            // 
            // receiptDate
            // 
            this.receiptDate.DataPropertyName = "receiptDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.receiptDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.receiptDate.HeaderText = "Date";
            this.receiptDate.Name = "receiptDate";
            this.receiptDate.ReadOnly = true;
            // 
            // setteledAmount
            // 
            this.setteledAmount.DataPropertyName = "setteledAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.setteledAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.setteledAmount.HeaderText = "Amount";
            this.setteledAmount.Name = "setteledAmount";
            this.setteledAmount.ReadOnly = true;
            // 
            // TotalCommishion
            // 
            this.TotalCommishion.DataPropertyName = "TotalCommishion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TotalCommishion.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalCommishion.HeaderText = "Total Commishion";
            this.TotalCommishion.Name = "TotalCommishion";
            this.TotalCommishion.ReadOnly = true;
            // 
            // NoOfCollecters
            // 
            this.NoOfCollecters.DataPropertyName = "NoOfCollecters";
            this.NoOfCollecters.HeaderText = "Collecters";
            this.NoOfCollecters.Name = "NoOfCollecters";
            this.NoOfCollecters.ReadOnly = true;
            // 
            // presentage
            // 
            this.presentage.DataPropertyName = "presentage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.presentage.DefaultCellStyle = dataGridViewCellStyle4;
            this.presentage.HeaderText = "%";
            this.presentage.Name = "presentage";
            this.presentage.ReadOnly = true;
            // 
            // devidedCommishion
            // 
            this.devidedCommishion.DataPropertyName = "devidedCommishion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.devidedCommishion.DefaultCellStyle = dataGridViewCellStyle5;
            this.devidedCommishion.HeaderText = "Commishion";
            this.devidedCommishion.Name = "devidedCommishion";
            this.devidedCommishion.ReadOnly = true;
            // 
            // lblRAP
            // 
            this.lblRAP.AutoSize = true;
            this.lblRAP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAP.ForeColor = System.Drawing.Color.Black;
            this.lblRAP.Location = new System.Drawing.Point(85, 45);
            this.lblRAP.Name = "lblRAP";
            this.lblRAP.Size = new System.Drawing.Size(74, 15);
            this.lblRAP.TabIndex = 477;
            this.lblRAP.Text = "R. A. Period :";
            // 
            // lblCollecter
            // 
            this.lblCollecter.AutoSize = true;
            this.lblCollecter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollecter.ForeColor = System.Drawing.Color.Black;
            this.lblCollecter.Location = new System.Drawing.Point(309, 45);
            this.lblCollecter.Name = "lblCollecter";
            this.lblCollecter.Size = new System.Drawing.Size(61, 15);
            this.lblCollecter.TabIndex = 478;
            this.lblCollecter.Text = "Collector :";
            // 
            // dgvDateSlab
            // 
            this.dgvDateSlab.AllowUserToAddRows = false;
            this.dgvDateSlab.AllowUserToDeleteRows = false;
            this.dgvDateSlab.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDateSlab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDateSlab.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDateSlab.ColumnHeadersHeight = 18;
            this.dgvDateSlab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelected,
            this.id,
            this.slabName,
            this.deductionAmount});
            this.dgvDateSlab.EnableHeadersVisualStyles = false;
            this.dgvDateSlab.Location = new System.Drawing.Point(557, 41);
            this.dgvDateSlab.MultiSelect = false;
            this.dgvDateSlab.Name = "dgvDateSlab";
            this.dgvDateSlab.ReadOnly = true;
            this.dgvDateSlab.RowHeadersVisible = false;
            this.dgvDateSlab.RowTemplate.Height = 18;
            this.dgvDateSlab.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDateSlab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDateSlab.Size = new System.Drawing.Size(228, 73);
            this.dgvDateSlab.TabIndex = 479;
            this.dgvDateSlab.Visible = false;
            this.dgvDateSlab.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDateSlab_CellClick);
            // 
            // isSelected
            // 
            this.isSelected.DataPropertyName = "isSelected";
            this.isSelected.HeaderText = "";
            this.isSelected.Name = "isSelected";
            this.isSelected.ReadOnly = true;
            this.isSelected.Width = 30;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // slabName
            // 
            this.slabName.DataPropertyName = "slabName";
            this.slabName.HeaderText = "Date Slab";
            this.slabName.Name = "slabName";
            this.slabName.ReadOnly = true;
            this.slabName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.slabName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.slabName.Width = 60;
            // 
            // deductionAmount
            // 
            this.deductionAmount.DataPropertyName = "deductionAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.deductionAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.deductionAmount.HeaderText = "Deduction Amount";
            this.deductionAmount.Name = "deductionAmount";
            this.deductionAmount.ReadOnly = true;
            this.deductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.deductionAmount.Width = 115;
            // 
            // txtTotalCommission
            // 
            this.txtTotalCommission.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCommission.Location = new System.Drawing.Point(269, 82);
            this.txtTotalCommission.Name = "txtTotalCommission";
            this.txtTotalCommission.ReadOnly = true;
            this.txtTotalCommission.Size = new System.Drawing.Size(156, 22);
            this.txtTotalCommission.TabIndex = 480;
            this.txtTotalCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtChequeDateDed
            // 
            this.txtChequeDateDed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeDateDed.Location = new System.Drawing.Point(-18, 92);
            this.txtChequeDateDed.Name = "txtChequeDateDed";
            this.txtChequeDateDed.ReadOnly = true;
            this.txtChequeDateDed.Size = new System.Drawing.Size(156, 22);
            this.txtChequeDateDed.TabIndex = 481;
            this.txtChequeDateDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequeDateDed.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(155, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 482;
            this.label1.Text = "Total Commission :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-1, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 483;
            this.label2.Text = "Cheque Date Deduction :";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(107, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 15);
            this.label3.TabIndex = 484;
            this.label3.Text = "Security Deposit Deduction :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(139, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 15);
            this.label4.TabIndex = 485;
            this.label4.Text = "Advanced Deduction :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(166, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 486;
            this.label5.Text = "Loan Deduction :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(161, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 15);
            this.label7.TabIndex = 487;
            this.label7.Text = "Net Commission :";
            // 
            // txtSecDepositDed
            // 
            this.txtSecDepositDed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecDepositDed.Location = new System.Drawing.Point(269, 104);
            this.txtSecDepositDed.Name = "txtSecDepositDed";
            this.txtSecDepositDed.Size = new System.Drawing.Size(156, 22);
            this.txtSecDepositDed.TabIndex = 488;
            this.txtSecDepositDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSecDepositDed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecDepositDed_KeyDown);
            this.txtSecDepositDed.Leave += new System.EventHandler(this.txtSecDepositDed_Leave);
            // 
            // txtAdvDed
            // 
            this.txtAdvDed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvDed.Location = new System.Drawing.Point(269, 126);
            this.txtAdvDed.Name = "txtAdvDed";
            this.txtAdvDed.Size = new System.Drawing.Size(156, 22);
            this.txtAdvDed.TabIndex = 489;
            this.txtAdvDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdvDed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdvDed_KeyDown);
            this.txtAdvDed.Leave += new System.EventHandler(this.txtAdvDed_Leave);
            // 
            // txtLoanDed
            // 
            this.txtLoanDed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanDed.Location = new System.Drawing.Point(269, 148);
            this.txtLoanDed.Name = "txtLoanDed";
            this.txtLoanDed.Size = new System.Drawing.Size(156, 22);
            this.txtLoanDed.TabIndex = 490;
            this.txtLoanDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoanDed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanDed_KeyDown);
            this.txtLoanDed.Leave += new System.EventHandler(this.txtLoanDed_Leave);
            // 
            // txtNetComm
            // 
            this.txtNetComm.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetComm.Location = new System.Drawing.Point(269, 170);
            this.txtNetComm.Name = "txtNetComm";
            this.txtNetComm.ReadOnly = true;
            this.txtNetComm.Size = new System.Drawing.Size(156, 22);
            this.txtNetComm.TabIndex = 491;
            this.txtNetComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frm_txComComissionCalculation_Collectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.txtNetComm);
            this.Controls.Add(this.txtLoanDed);
            this.Controls.Add(this.txtAdvDed);
            this.Controls.Add(this.txtSecDepositDed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChequeDateDed);
            this.Controls.Add(this.txtTotalCommission);
            this.Controls.Add(this.dgvDateSlab);
            this.Controls.Add(this.lblCollecter);
            this.Controls.Add(this.lblRAP);
            this.Controls.Add(this.grdTxn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPeriod);
            this.Name = "frm_txComComissionCalculation_Collectors";
            this.Text = "Comission Calculation - Collectors";
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnLoad, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.grdTxn, 0);
            this.Controls.SetChildIndex(this.lblRAP, 0);
            this.Controls.SetChildIndex(this.lblCollecter, 0);
            this.Controls.SetChildIndex(this.dgvDateSlab, 0);
            this.Controls.SetChildIndex(this.txtTotalCommission, 0);
            this.Controls.SetChildIndex(this.txtChequeDateDed, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtSecDepositDed, 0);
            this.Controls.SetChildIndex(this.txtAdvDed, 0);
            this.Controls.SetChildIndex(this.txtLoanDed, 0);
            this.Controls.SetChildIndex(this.txtNetComm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTxn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateSlab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPeriod;
        private SEACC_DataGrid grdTxn;
        private System.Windows.Forms.Label lblRAP;
        private System.Windows.Forms.Label lblCollecter;
        private SEACC_DataGrid dgvDateSlab;
        private System.Windows.Forms.TextBox txtTotalCommission;
        private System.Windows.Forms.TextBox txtChequeDateDed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSecDepositDed;
        private System.Windows.Forms.TextBox txtAdvDed;
        private System.Windows.Forms.TextBox txtLoanDed;
        private System.Windows.Forms.TextBox txtNetComm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn slabName;
        private System.Windows.Forms.DataGridViewTextBoxColumn deductionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn setteledAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCommishion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfCollecters;
        private System.Windows.Forms.DataGridViewTextBoxColumn presentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn devidedCommishion;
    }
}