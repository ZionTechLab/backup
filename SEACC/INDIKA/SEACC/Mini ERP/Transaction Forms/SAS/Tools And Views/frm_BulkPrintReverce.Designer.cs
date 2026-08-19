namespace Digiteq.Transaction_Forms.SAS.Tools_And_Views
{
    partial class frm_BulkPrintReverce
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnReverce = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gridRoute = new Digiteq.SEACC_DataGrid();
            this.Select1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.route_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.route_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpCashFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpCashTo = new System.Windows.Forms.DateTimePicker();
            this.dgvMain = new Digiteq.SEACC_DataGrid();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Invoice_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryOrder_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPrinted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll_Inv = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(982, 410);
            this.panel1.TabIndex = 51;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkAll_Inv);
            this.panel3.Controls.Add(this.dgvMain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(182, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 410);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.btnReverce);
            this.panel2.Controls.Add(this.gridRoute);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dtpCashFrom);
            this.panel2.Controls.Add(this.lblTo);
            this.panel2.Controls.Add(this.lblFrom);
            this.panel2.Controls.Add(this.dtpCashTo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 410);
            this.panel2.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(13, 69);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(39, 17);
            this.chkAll.TabIndex = 498;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnReverce
            // 
            this.btnReverce.Location = new System.Drawing.Point(13, 364);
            this.btnReverce.Name = "btnReverce";
            this.btnReverce.Size = new System.Drawing.Size(156, 23);
            this.btnReverce.TabIndex = 497;
            this.btnReverce.Text = "Reverce";
            this.btnReverce.UseVisualStyleBackColor = true;
            this.btnReverce.Click += new System.EventHandler(this.btnReverce_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 496;
            this.label1.Text = "Route";
            // 
            // gridRoute
            // 
            this.gridRoute.AllowUserToAddRows = false;
            this.gridRoute.AllowUserToDeleteRows = false;
            this.gridRoute.AllowUserToResizeRows = false;
            this.gridRoute.BackgroundColor = System.Drawing.Color.DarkGray;
            this.gridRoute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridRoute.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridRoute.ColumnHeadersHeight = 40;
            this.gridRoute.ColumnHeadersVisible = false;
            this.gridRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select1,
            this.route_ID,
            this.route_Code});
            this.gridRoute.EnableHeadersVisualStyles = false;
            this.gridRoute.Location = new System.Drawing.Point(13, 91);
            this.gridRoute.MultiSelect = false;
            this.gridRoute.Name = "gridRoute";
            this.gridRoute.RowHeadersVisible = false;
            this.gridRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoute.Size = new System.Drawing.Size(155, 221);
            this.gridRoute.TabIndex = 495;
            // 
            // Select1
            // 
            this.Select1.DataPropertyName = "Select";
            this.Select1.FillWeight = 40F;
            this.Select1.HeaderText = "select";
            this.Select1.Name = "Select1";
            this.Select1.Width = 40;
            // 
            // route_ID
            // 
            this.route_ID.DataPropertyName = "route_ID";
            this.route_ID.HeaderText = "route_ID";
            this.route_ID.Name = "route_ID";
            this.route_ID.Visible = false;
            this.route_ID.Width = 75;
            // 
            // route_Code
            // 
            this.route_Code.DataPropertyName = "route_Code";
            this.route_Code.HeaderText = "route_Code";
            this.route_Code.Name = "route_Code";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(94, 65);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 23);
            this.btnRefresh.TabIndex = 494;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpCashFrom
            // 
            this.dtpCashFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCashFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCashFrom.Location = new System.Drawing.Point(71, 9);
            this.dtpCashFrom.Name = "dtpCashFrom";
            this.dtpCashFrom.Size = new System.Drawing.Size(98, 22);
            this.dtpCashFrom.TabIndex = 492;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Black;
            this.lblTo.Location = new System.Drawing.Point(10, 42);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 491;
            this.lblTo.Text = "To ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Black;
            this.lblFrom.Location = new System.Drawing.Point(10, 14);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 490;
            this.lblFrom.Text = "From";
            // 
            // dtpCashTo
            // 
            this.dtpCashTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCashTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCashTo.Location = new System.Drawing.Point(71, 35);
            this.dtpCashTo.Name = "dtpCashTo";
            this.dtpCashTo.Size = new System.Drawing.Size(97, 22);
            this.dtpCashTo.TabIndex = 489;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMain.ColumnHeadersHeight = 40;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.Invoice_ID,
            this.deliveryOrder_ID,
            this.deliveryOrderDate,
            this.customerName,
            this.deliveryAddress,
            this.isPrinted});
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Location = new System.Drawing.Point(6, 21);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(782, 378);
            this.dgvMain.TabIndex = 482;
            // 
            // select
            // 
            this.select.DataPropertyName = "Select";
            this.select.FillWeight = 40F;
            this.select.HeaderText = "select";
            this.select.Name = "select";
            this.select.Width = 40;
            // 
            // Invoice_ID
            // 
            this.Invoice_ID.DataPropertyName = "Invoice_ID";
            this.Invoice_ID.HeaderText = "Invoice ID";
            this.Invoice_ID.Name = "Invoice_ID";
            this.Invoice_ID.Width = 75;
            // 
            // deliveryOrder_ID
            // 
            this.deliveryOrder_ID.DataPropertyName = "deliveryOrder_ID";
            this.deliveryOrder_ID.FillWeight = 70F;
            this.deliveryOrder_ID.HeaderText = "Delivery Order ID";
            this.deliveryOrder_ID.Name = "deliveryOrder_ID";
            this.deliveryOrder_ID.ReadOnly = true;
            this.deliveryOrder_ID.Width = 75;
            // 
            // deliveryOrderDate
            // 
            this.deliveryOrderDate.DataPropertyName = "invoiceDate";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.deliveryOrderDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.deliveryOrderDate.FillWeight = 80F;
            this.deliveryOrderDate.HeaderText = "Date";
            this.deliveryOrderDate.Name = "deliveryOrderDate";
            this.deliveryOrderDate.ReadOnly = true;
            this.deliveryOrderDate.Width = 70;
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.HeaderText = "Customer";
            this.customerName.Name = "customerName";
            this.customerName.Width = 210;
            // 
            // deliveryAddress
            // 
            this.deliveryAddress.DataPropertyName = "deliveryAddress";
            this.deliveryAddress.HeaderText = "Delivery Address";
            this.deliveryAddress.Name = "deliveryAddress";
            this.deliveryAddress.ReadOnly = true;
            this.deliveryAddress.Width = 220;
            // 
            // isPrinted
            // 
            this.isPrinted.DataPropertyName = "isPrinted";
            this.isPrinted.HeaderText = "Printed";
            this.isPrinted.Name = "isPrinted";
            this.isPrinted.Width = 60;
            // 
            // chkAll_Inv
            // 
            this.chkAll_Inv.AutoSize = true;
            this.chkAll_Inv.Location = new System.Drawing.Point(11, 3);
            this.chkAll_Inv.Name = "chkAll_Inv";
            this.chkAll_Inv.Size = new System.Drawing.Size(39, 17);
            this.chkAll_Inv.TabIndex = 488;
            this.chkAll_Inv.Text = "All";
            this.chkAll_Inv.UseVisualStyleBackColor = true;
            this.chkAll_Inv.CheckedChanged += new System.EventHandler(this.chkAll_Inv_CheckedChanged);
            // 
            // frm_BulkPrintReverce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 449);
            this.Controls.Add(this.panel1);
            this.Name = "frm_BulkPrintReverce";
            this.Text = "frm_BulkPrintReverce";
            this.Load += new System.EventHandler(this.frm_BulkPrintReverce_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnReverce;
        private System.Windows.Forms.Label label1;
        private SEACC_DataGrid gridRoute;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select1;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_Code;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpCashFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpCashTo;
        private SEACC_DataGrid dgvMain;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryOrder_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPrinted;
        private System.Windows.Forms.CheckBox chkAll_Inv;
    }
}