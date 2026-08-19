namespace Express.UI.Pricing.View
{
    partial class OrgCharges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkExcempt = new System.Windows.Forms.CheckBox();
            this.txtLocalCurrency = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtSalesAreaName = new System.Windows.Forms.TextBox();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.txtSalseAreaCode = new System.Windows.Forms.TextBox();
            this.txtOrgCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdAdminCharges = new System.Windows.Forms.DataGridView();
            this.dataManipulate1 = new Express.UI.Common.CustomControl.DataManipulate();
            this.OrgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excemptY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesAreaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgAddr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgAddr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdminCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chkExcempt);
            this.groupBox1.Controls.Add(this.txtLocalCurrency);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtSalesAreaName);
            this.groupBox1.Controls.Add(this.txtAddress3);
            this.groupBox1.Controls.Add(this.txtAddress2);
            this.groupBox1.Controls.Add(this.txtAddress1);
            this.groupBox1.Controls.Add(this.txtOrgName);
            this.groupBox1.Controls.Add(this.txtSalseAreaCode);
            this.groupBox1.Controls.Add(this.txtOrgCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 135);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(353, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkExcempt
            // 
            this.chkExcempt.AutoSize = true;
            this.chkExcempt.Location = new System.Drawing.Point(560, 95);
            this.chkExcempt.Name = "chkExcempt";
            this.chkExcempt.Size = new System.Drawing.Size(67, 17);
            this.chkExcempt.TabIndex = 21;
            this.chkExcempt.Text = "Excempt";
            this.chkExcempt.UseVisualStyleBackColor = true;
            this.chkExcempt.CheckedChanged += new System.EventHandler(this.chkExcempt_CheckedChanged);
            // 
            // txtLocalCurrency
            // 
            this.txtLocalCurrency.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtLocalCurrency.Location = new System.Drawing.Point(524, 93);
            this.txtLocalCurrency.Name = "txtLocalCurrency";
            this.txtLocalCurrency.Size = new System.Drawing.Size(28, 22);
            this.txtLocalCurrency.TabIndex = 12;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(419, 93);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(102, 22);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalesAreaName
            // 
            this.txtSalesAreaName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtSalesAreaName.Location = new System.Drawing.Point(479, 67);
            this.txtSalesAreaName.Name = "txtSalesAreaName";
            this.txtSalesAreaName.Size = new System.Drawing.Size(154, 22);
            this.txtSalesAreaName.TabIndex = 14;
            // 
            // txtAddress3
            // 
            this.txtAddress3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAddress3.Location = new System.Drawing.Point(60, 93);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(287, 22);
            this.txtAddress3.TabIndex = 15;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAddress2.Location = new System.Drawing.Point(60, 67);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(287, 22);
            this.txtAddress2.TabIndex = 16;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAddress1.Location = new System.Drawing.Point(60, 42);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(287, 22);
            this.txtAddress1.TabIndex = 17;
            // 
            // txtOrgName
            // 
            this.txtOrgName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtOrgName.Location = new System.Drawing.Point(149, 16);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(198, 22);
            this.txtOrgName.TabIndex = 18;
            // 
            // txtSalseAreaCode
            // 
            this.txtSalseAreaCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtSalseAreaCode.Location = new System.Drawing.Point(419, 67);
            this.txtSalseAreaCode.Name = "txtSalseAreaCode";
            this.txtSalseAreaCode.Size = new System.Drawing.Size(57, 22);
            this.txtSalseAreaCode.TabIndex = 19;
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtOrgCode.Location = new System.Drawing.Point(60, 16);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.Size = new System.Drawing.Size(85, 22);
            this.txtOrgCode.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(353, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sales Area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Customer ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdAdminCharges);
            this.groupBox2.Location = new System.Drawing.Point(13, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 253);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // grdAdminCharges
            // 
            this.grdAdminCharges.AllowUserToAddRows = false;
            this.grdAdminCharges.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.grdAdminCharges.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdminCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAdminCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAdminCharges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrgCode,
            this.OrgName,
            this.Amount,
            this.excemptY,
            this.ChargeCode,
            this.SalesAreaID,
            this.SalesAreaName,
            this.OrgAddr1,
            this.OrgAddr2,
            this.OrgCity});
            this.grdAdminCharges.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAdminCharges.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdAdminCharges.EnableHeadersVisualStyles = false;
            this.grdAdminCharges.Location = new System.Drawing.Point(6, 13);
            this.grdAdminCharges.MultiSelect = false;
            this.grdAdminCharges.Name = "grdAdminCharges";
            this.grdAdminCharges.ReadOnly = true;
            this.grdAdminCharges.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.grdAdminCharges.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdAdminCharges.RowTemplate.Height = 15;
            this.grdAdminCharges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAdminCharges.Size = new System.Drawing.Size(627, 234);
            this.grdAdminCharges.TabIndex = 3;
            this.grdAdminCharges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAdminCharges_CellContentClick);
            // 
            // dataManipulate1
            // 
            this.dataManipulate1.Location = new System.Drawing.Point(140, 402);
            this.dataManipulate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataManipulate1.Name = "dataManipulate1";
            this.dataManipulate1.Size = new System.Drawing.Size(373, 46);
            this.dataManipulate1.TabIndex = 8;
            // 
            // OrgCode
            // 
            this.OrgCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OrgCode.DataPropertyName = "Cust Code";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrgCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.OrgCode.HeaderText = "Org Code";
            this.OrgCode.Name = "OrgCode";
            this.OrgCode.ReadOnly = true;
            this.OrgCode.Width = 81;
            // 
            // OrgName
            // 
            this.OrgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrgName.DataPropertyName = "Customer Name";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrgName.DefaultCellStyle = dataGridViewCellStyle4;
            this.OrgName.HeaderText = "Org Name";
            this.OrgName.Name = "OrgName";
            this.OrgName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Amount.DataPropertyName = "Charge Amount";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 75;
            // 
            // excemptY
            // 
            this.excemptY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.excemptY.DataPropertyName = "excemptY";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excemptY.DefaultCellStyle = dataGridViewCellStyle6;
            this.excemptY.HeaderText = "Excempt";
            this.excemptY.Name = "excemptY";
            this.excemptY.ReadOnly = true;
            this.excemptY.Width = 76;
            // 
            // ChargeCode
            // 
            this.ChargeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ChargeCode.DataPropertyName = "ChargeCode";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ChargeCode.DefaultCellStyle = dataGridViewCellStyle7;
            this.ChargeCode.HeaderText = "Charge Code";
            this.ChargeCode.Name = "ChargeCode";
            this.ChargeCode.ReadOnly = true;
            this.ChargeCode.Width = 99;
            // 
            // SalesAreaID
            // 
            this.SalesAreaID.DataPropertyName = "SalesAreaID";
            this.SalesAreaID.HeaderText = "SalasID";
            this.SalesAreaID.Name = "SalesAreaID";
            this.SalesAreaID.ReadOnly = true;
            this.SalesAreaID.Visible = false;
            // 
            // SalesAreaName
            // 
            this.SalesAreaName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SalesAreaName.DataPropertyName = "SalesAreaName";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesAreaName.DefaultCellStyle = dataGridViewCellStyle8;
            this.SalesAreaName.HeaderText = "Sales Area Name";
            this.SalesAreaName.Name = "SalesAreaName";
            this.SalesAreaName.ReadOnly = true;
            this.SalesAreaName.Width = 109;
            // 
            // OrgAddr1
            // 
            this.OrgAddr1.DataPropertyName = "OrgAddr1";
            this.OrgAddr1.HeaderText = "Address1";
            this.OrgAddr1.Name = "OrgAddr1";
            this.OrgAddr1.ReadOnly = true;
            this.OrgAddr1.Visible = false;
            // 
            // OrgAddr2
            // 
            this.OrgAddr2.DataPropertyName = "OrgAddr2";
            this.OrgAddr2.HeaderText = "Address2";
            this.OrgAddr2.Name = "OrgAddr2";
            this.OrgAddr2.ReadOnly = true;
            this.OrgAddr2.Visible = false;
            // 
            // OrgCity
            // 
            this.OrgCity.DataPropertyName = "OrgCity";
            this.OrgCity.HeaderText = "City";
            this.OrgCity.Name = "OrgCity";
            this.OrgCity.ReadOnly = true;
            this.OrgCity.Visible = false;
            // 
            // OrgCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataManipulate1);
            this.Name = "OrgCharges";
            this.Text = "Customer Charges";
            this.Load += new System.EventHandler(this.OrgCharges_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAdminCharges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Common.CustomControl.DataManipulate dataManipulate1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkExcempt;
        private System.Windows.Forms.TextBox txtLocalCurrency;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtSalesAreaName;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.TextBox txtSalseAreaCode;
        private System.Windows.Forms.TextBox txtOrgCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdAdminCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn excemptY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesAreaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgAddr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgAddr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgCity;
    }
}