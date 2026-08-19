namespace Digiteq
{
    partial class UC_AccCustomerOpeningBalance
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
            this.panel = new System.Windows.Forms.Panel();
            this.txtFinYear_Month = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinYear = new System.Windows.Forms.TextBox();
            this.lblFinYear = new System.Windows.Forms.Label();
            this.dgvDetail = new SEACC_DataGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.AccCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Gainsboro;
            this.panel.Controls.Add(this.txtFinYear_Month);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.txtFinYear);
            this.panel.Controls.Add(this.lblFinYear);
            this.panel.Location = new System.Drawing.Point(9, 10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(802, 42);
            this.panel.TabIndex = 0;
            // 
            // txtFinYear_Month
            // 
            this.txtFinYear_Month.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFinYear_Month.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinYear_Month.Location = new System.Drawing.Point(368, 9);
            this.txtFinYear_Month.Name = "txtFinYear_Month";
            this.txtFinYear_Month.ReadOnly = true;
            this.txtFinYear_Month.Size = new System.Drawing.Size(179, 22);
            this.txtFinYear_Month.TabIndex = 597;
            this.txtFinYear_Month.DoubleClick += new System.EventHandler(this.txtFinYear_Month_DoubleClick);
            this.txtFinYear_Month.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinYear_Month_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(306, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 592;
            this.label5.Text = "Month";
            // 
            // txtFinYear
            // 
            this.txtFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFinYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinYear.Location = new System.Drawing.Point(112, 9);
            this.txtFinYear.Name = "txtFinYear";
            this.txtFinYear.Size = new System.Drawing.Size(179, 22);
            this.txtFinYear.TabIndex = 590;
            this.txtFinYear.DoubleClick += new System.EventHandler(this.txtFinYear_DoubleClick);
            this.txtFinYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinYear_KeyDown);
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFinYear.Location = new System.Drawing.Point(11, 12);
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(75, 14);
            this.lblFinYear.TabIndex = 589;
            this.lblFinYear.Text = "Financial Year";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccCode,
            this.AccName,
            this.CustomerID,
            this.CustomerName,
            this.OBalance});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 58);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(800, 476);
            this.dgvDetail.TabIndex = 567;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.panel);
            this.panel5.Controls.Add(this.dgvDetail);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(821, 549);
            this.panel5.TabIndex = 601;
            // 
            // AccCode
            // 
            this.AccCode.DataPropertyName = "AccCode";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AccCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.AccCode.HeaderText = "Account Code";
            this.AccCode.Name = "AccCode";
            this.AccCode.ReadOnly = true;
            this.AccCode.Width = 120;
            // 
            // AccName
            // 
            this.AccName.DataPropertyName = "AccName";
            this.AccName.HeaderText = "Account Name";
            this.AccName.Name = "AccName";
            this.AccName.Width = 250;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 190;
            // 
            // OBalance
            // 
            this.OBalance.DataPropertyName = "OBalance";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.OBalance.DefaultCellStyle = dataGridViewCellStyle2;
            this.OBalance.HeaderText = "Openning Balance";
            this.OBalance.Name = "OBalance";
            this.OBalance.Width = 120;
            // 
            // UC_AccCustomerOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "UC_AccCustomerOpeningBalance";
            this.Size = new System.Drawing.Size(821, 635);
            this.Load += new System.EventHandler(this.UC_AccCustomerOpeningBalance_Load);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtFinYear;
        private System.Windows.Forms.Label lblFinYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtFinYear_Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBalance;

    }
}