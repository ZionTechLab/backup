namespace Digiteq.Transaction_Forms.COM
{
    partial class frm_masItemCategory_ComissionWiseBreakDown
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItemCategory = new SEACC_DataGrid();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalSalesRate_SR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountedSalesRate_SR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetForSalePeriod_SR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalSalesRate_AM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountedSalesRate_AM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetForSalePeriod_AM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalSalesRate_SM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountedSalesRate_SM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetForSalePeriod_SM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalSalesRate_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountedSalesRate_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetForSalePeriod_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dgvItemCategory
            // 
            this.dgvItemCategory.AllowUserToAddRows = false;
            this.dgvItemCategory.AllowUserToDeleteRows = false;
            this.dgvItemCategory.AllowUserToResizeRows = false;
            this.dgvItemCategory.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvItemCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItemCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemCategory.ColumnHeadersHeight = 60;
            this.dgvItemCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.CategoryID,
            this.CategoryName,
            this.NormalSalesRate_SR,
            this.DiscountedSalesRate_SR,
            this.TargetForSalePeriod_SR,
            this.NormalSalesRate_AM,
            this.DiscountedSalesRate_AM,
            this.TargetForSalePeriod_AM,
            this.NormalSalesRate_SM,
            this.DiscountedSalesRate_SM,
            this.TargetForSalePeriod_SM,
            this.NormalSalesRate_Col,
            this.DiscountedSalesRate_Col,
            this.TargetForSalePeriod_Col});
            this.dgvItemCategory.EnableHeadersVisualStyles = false;
            this.dgvItemCategory.Location = new System.Drawing.Point(8, 35);
            this.dgvItemCategory.MultiSelect = false;
            this.dgvItemCategory.Name = "dgvItemCategory";
            this.dgvItemCategory.RowHeadersVisible = false;
            this.dgvItemCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItemCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemCategory.Size = new System.Drawing.Size(945, 344);
            this.dgvItemCategory.TabIndex = 15;
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.LineNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.LineNo.HeaderText = "Line No";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 35;
            // 
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "Category ID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Width = 180;
            // 
            // NormalSalesRate_SR
            // 
            this.NormalSalesRate_SR.DataPropertyName = "NormalSalesRate_SR";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NormalSalesRate_SR.DefaultCellStyle = dataGridViewCellStyle3;
            this.NormalSalesRate_SR.HeaderText = "Sales Rep Normal Rate";
            this.NormalSalesRate_SR.Name = "NormalSalesRate_SR";
            this.NormalSalesRate_SR.Width = 50;
            // 
            // DiscountedSalesRate_SR
            // 
            this.DiscountedSalesRate_SR.DataPropertyName = "DiscountedSalesRate_SR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.DiscountedSalesRate_SR.DefaultCellStyle = dataGridViewCellStyle4;
            this.DiscountedSalesRate_SR.HeaderText = "Sales Rep Disc. Rate";
            this.DiscountedSalesRate_SR.Name = "DiscountedSalesRate_SR";
            this.DiscountedSalesRate_SR.Width = 50;
            // 
            // TargetForSalePeriod_SR
            // 
            this.TargetForSalePeriod_SR.DataPropertyName = "TargetForSalePeriod_SR";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.TargetForSalePeriod_SR.DefaultCellStyle = dataGridViewCellStyle5;
            this.TargetForSalePeriod_SR.HeaderText = "Sales Rep Target";
            this.TargetForSalePeriod_SR.Name = "TargetForSalePeriod_SR";
            this.TargetForSalePeriod_SR.Width = 50;
            // 
            // NormalSalesRate_AM
            // 
            this.NormalSalesRate_AM.DataPropertyName = "NormalSalesRate_AM";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NormalSalesRate_AM.DefaultCellStyle = dataGridViewCellStyle6;
            this.NormalSalesRate_AM.HeaderText = "AM Normal Rate";
            this.NormalSalesRate_AM.Name = "NormalSalesRate_AM";
            this.NormalSalesRate_AM.Width = 50;
            // 
            // DiscountedSalesRate_AM
            // 
            this.DiscountedSalesRate_AM.DataPropertyName = "DiscountedSalesRate_AM";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.DiscountedSalesRate_AM.DefaultCellStyle = dataGridViewCellStyle7;
            this.DiscountedSalesRate_AM.HeaderText = "AM Disc. Rate";
            this.DiscountedSalesRate_AM.Name = "DiscountedSalesRate_AM";
            this.DiscountedSalesRate_AM.Width = 50;
            // 
            // TargetForSalePeriod_AM
            // 
            this.TargetForSalePeriod_AM.DataPropertyName = "TargetForSalePeriod_AM";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.TargetForSalePeriod_AM.DefaultCellStyle = dataGridViewCellStyle8;
            this.TargetForSalePeriod_AM.HeaderText = "AM Target";
            this.TargetForSalePeriod_AM.Name = "TargetForSalePeriod_AM";
            this.TargetForSalePeriod_AM.Width = 50;
            // 
            // NormalSalesRate_SM
            // 
            this.NormalSalesRate_SM.DataPropertyName = "NormalSalesRate_SM";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NormalSalesRate_SM.DefaultCellStyle = dataGridViewCellStyle9;
            this.NormalSalesRate_SM.HeaderText = "SM Normal Rate";
            this.NormalSalesRate_SM.Name = "NormalSalesRate_SM";
            this.NormalSalesRate_SM.Width = 50;
            // 
            // DiscountedSalesRate_SM
            // 
            this.DiscountedSalesRate_SM.DataPropertyName = "DiscountedSalesRate_SM";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.DiscountedSalesRate_SM.DefaultCellStyle = dataGridViewCellStyle10;
            this.DiscountedSalesRate_SM.HeaderText = "SM Disc. Rate";
            this.DiscountedSalesRate_SM.Name = "DiscountedSalesRate_SM";
            this.DiscountedSalesRate_SM.Width = 50;
            // 
            // TargetForSalePeriod_SM
            // 
            this.TargetForSalePeriod_SM.DataPropertyName = "TargetForSalePeriod_SM";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.TargetForSalePeriod_SM.DefaultCellStyle = dataGridViewCellStyle11;
            this.TargetForSalePeriod_SM.HeaderText = "SM Target";
            this.TargetForSalePeriod_SM.Name = "TargetForSalePeriod_SM";
            this.TargetForSalePeriod_SM.Width = 50;
            // 
            // NormalSalesRate_Col
            // 
            this.NormalSalesRate_Col.DataPropertyName = "NormalSalesRate_Col";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NormalSalesRate_Col.DefaultCellStyle = dataGridViewCellStyle12;
            this.NormalSalesRate_Col.HeaderText = "Collector Normal Rate";
            this.NormalSalesRate_Col.Name = "NormalSalesRate_Col";
            this.NormalSalesRate_Col.Width = 50;
            // 
            // DiscountedSalesRate_Col
            // 
            this.DiscountedSalesRate_Col.DataPropertyName = "DiscountedSalesRate_Col";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.DiscountedSalesRate_Col.DefaultCellStyle = dataGridViewCellStyle13;
            this.DiscountedSalesRate_Col.HeaderText = "Collector Disc. Rate";
            this.DiscountedSalesRate_Col.Name = "DiscountedSalesRate_Col";
            this.DiscountedSalesRate_Col.Width = 50;
            // 
            // TargetForSalePeriod_Col
            // 
            this.TargetForSalePeriod_Col.DataPropertyName = "TargetForSalePeriod_Col";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.TargetForSalePeriod_Col.DefaultCellStyle = dataGridViewCellStyle14;
            this.TargetForSalePeriod_Col.HeaderText = "Collector Target";
            this.TargetForSalePeriod_Col.Name = "TargetForSalePeriod_Col";
            this.TargetForSalePeriod_Col.Width = 50;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(830, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 35);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_masItemCategory_ComissionWiseBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 431);
            this.Controls.Add(this.dgvItemCategory);
            this.Controls.Add(this.btnSave);
            this.Name = "frm_masItemCategory_ComissionWiseBreakDown";
            this.Text = "Item Wise Risk Allowance Rates";
            this.Load += new System.EventHandler(this.frm_masItemCategory_ComissionWiseBreakDown_Load);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.dgvItemCategory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SEACC_DataGrid dgvItemCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalSalesRate_SR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountedSalesRate_SR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetForSalePeriod_SR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalSalesRate_AM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountedSalesRate_AM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetForSalePeriod_AM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalSalesRate_SM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountedSalesRate_SM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetForSalePeriod_SM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalSalesRate_Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountedSalesRate_Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetForSalePeriod_Col;
    }
}