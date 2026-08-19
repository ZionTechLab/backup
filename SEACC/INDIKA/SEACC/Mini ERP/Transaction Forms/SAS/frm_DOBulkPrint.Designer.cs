namespace Digiteq
{
    partial class frm_DOBulkPrint
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gridRoute = new Digiteq.SEACC_DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSummary = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkAll_Inv = new System.Windows.Forms.CheckBox();
            this.chkNotDeliverd = new System.Windows.Forms.CheckBox();
            this.Select1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.route_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.route_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dtpCashFrom
            // 
            this.dtpCashFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCashFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCashFrom.Location = new System.Drawing.Point(71, 51);
            this.dtpCashFrom.Name = "dtpCashFrom";
            this.dtpCashFrom.Size = new System.Drawing.Size(98, 22);
            this.dtpCashFrom.TabIndex = 480;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Black;
            this.lblTo.Location = new System.Drawing.Point(10, 84);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 479;
            this.lblTo.Text = "To ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Black;
            this.lblFrom.Location = new System.Drawing.Point(10, 56);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 478;
            this.lblFrom.Text = "From";
            // 
            // dtpCashTo
            // 
            this.dtpCashTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCashTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCashTo.Location = new System.Drawing.Point(71, 77);
            this.dtpCashTo.Name = "dtpCashTo";
            this.dtpCashTo.Size = new System.Drawing.Size(97, 22);
            this.dtpCashTo.TabIndex = 477;
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
            this.dgvMain.Location = new System.Drawing.Point(174, 51);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(782, 378);
            this.dgvMain.TabIndex = 481;
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
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.deliveryOrderDate.DefaultCellStyle = dataGridViewCellStyle1;
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 377);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 23);
            this.btnRefresh.TabIndex = 482;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(13, 406);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 482;
            this.btnPrint.Text = "Qty Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.gridRoute.Location = new System.Drawing.Point(13, 133);
            this.gridRoute.MultiSelect = false;
            this.gridRoute.Name = "gridRoute";
            this.gridRoute.RowHeadersVisible = false;
            this.gridRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoute.Size = new System.Drawing.Size(155, 221);
            this.gridRoute.TabIndex = 483;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 484;
            this.label1.Text = "Route";
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(94, 406);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(75, 23);
            this.btnSummary.TabIndex = 485;
            this.btnSummary.Text = "Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(13, 111);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(39, 17);
            this.chkAll.TabIndex = 486;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkAll_Inv
            // 
            this.chkAll_Inv.AutoSize = true;
            this.chkAll_Inv.Location = new System.Drawing.Point(180, 35);
            this.chkAll_Inv.Name = "chkAll_Inv";
            this.chkAll_Inv.Size = new System.Drawing.Size(39, 17);
            this.chkAll_Inv.TabIndex = 487;
            this.chkAll_Inv.Text = "All";
            this.chkAll_Inv.UseVisualStyleBackColor = true;
            this.chkAll_Inv.CheckedChanged += new System.EventHandler(this.chkAll_Inv_CheckedChanged);
            // 
            // chkNotDeliverd
            // 
            this.chkNotDeliverd.AutoSize = true;
            this.chkNotDeliverd.Checked = true;
            this.chkNotDeliverd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotDeliverd.Location = new System.Drawing.Point(13, 360);
            this.chkNotDeliverd.Name = "chkNotDeliverd";
            this.chkNotDeliverd.Size = new System.Drawing.Size(117, 17);
            this.chkNotDeliverd.TabIndex = 488;
            this.chkNotDeliverd.Text = "Not Deliverd Only";
            this.chkNotDeliverd.UseVisualStyleBackColor = true;
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
            // frm_DOBulkPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 450);
            this.Controls.Add(this.chkNotDeliverd);
            this.Controls.Add(this.chkAll_Inv);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridRoute);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.dtpCashFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpCashTo);
            this.Name = "frm_DOBulkPrint";
            this.Text = "Bulk DO Print";
            this.Load += new System.EventHandler(this.frm_DOBulkPrint_Load);
            this.Controls.SetChildIndex(this.dtpCashTo, 0);
            this.Controls.SetChildIndex(this.lblFrom, 0);
            this.Controls.SetChildIndex(this.lblTo, 0);
            this.Controls.SetChildIndex(this.dtpCashFrom, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.gridRoute, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSummary, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            this.Controls.SetChildIndex(this.chkAll_Inv, 0);
            this.Controls.SetChildIndex(this.chkNotDeliverd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCashFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpCashTo;
        private SEACC_DataGrid dgvMain;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrint;
        private SEACC_DataGrid gridRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkAll_Inv;
        private System.Windows.Forms.CheckBox chkNotDeliverd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryOrder_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPrinted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select1;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_Code;
    }
}