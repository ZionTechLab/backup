namespace Digiteq
{
    partial class frm_rpt_SalesPendingOrder_APL
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoInvoiceItemSummary = new System.Windows.Forms.RadioButton();
            this.rdoPendingCustomerOrderDetailDate = new System.Windows.Forms.RadioButton();
            this.rdoPendingOrderItemSummary = new System.Windows.Forms.RadioButton();
            this.rdoPendingOrderItem = new System.Windows.Forms.RadioButton();
            this.rdoPendingCustomerOrderSummery = new System.Windows.Forms.RadioButton();
            this.rdoPendingCustomerOrderDetailTown = new System.Windows.Forms.RadioButton();
            this.z2 = new System.Windows.Forms.Panel();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.x1.SuspendLayout();
            this.z2.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(97, 10);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(163, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(7, 13);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(95, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(285, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Period To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(359, 6);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoInvoiceItemSummary);
            this.x1.Controls.Add(this.rdoPendingCustomerOrderDetailDate);
            this.x1.Controls.Add(this.rdoPendingOrderItemSummary);
            this.x1.Controls.Add(this.rdoPendingOrderItem);
            this.x1.Controls.Add(this.rdoPendingCustomerOrderSummery);
            this.x1.Location = new System.Drawing.Point(8, 12);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(529, 34);
            this.x1.TabIndex = 5;
            // 
            // rdoInvoiceItemSummary
            // 
            this.rdoInvoiceItemSummary.AutoSize = true;
            this.rdoInvoiceItemSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvoiceItemSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoInvoiceItemSummary.Location = new System.Drawing.Point(312, 7);
            this.rdoInvoiceItemSummary.Name = "rdoInvoiceItemSummary";
            this.rdoInvoiceItemSummary.Size = new System.Drawing.Size(179, 18);
            this.rdoInvoiceItemSummary.TabIndex = 23;
            this.rdoInvoiceItemSummary.TabStop = true;
            this.rdoInvoiceItemSummary.Text = "Pending Invoice Item Summary";
            this.rdoInvoiceItemSummary.UseVisualStyleBackColor = true;
            // 
            // rdoPendingCustomerOrderDetailDate
            // 
            this.rdoPendingCustomerOrderDetailDate.AutoSize = true;
            this.rdoPendingCustomerOrderDetailDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingCustomerOrderDetailDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingCustomerOrderDetailDate.Location = new System.Drawing.Point(11, 55);
            this.rdoPendingCustomerOrderDetailDate.Name = "rdoPendingCustomerOrderDetailDate";
            this.rdoPendingCustomerOrderDetailDate.Size = new System.Drawing.Size(199, 18);
            this.rdoPendingCustomerOrderDetailDate.TabIndex = 22;
            this.rdoPendingCustomerOrderDetailDate.TabStop = true;
            this.rdoPendingCustomerOrderDetailDate.Text = "Pending Delivery Item [Date-Wise]";
            this.rdoPendingCustomerOrderDetailDate.UseVisualStyleBackColor = true;
            this.rdoPendingCustomerOrderDetailDate.CheckedChanged += new System.EventHandler(this.rdoPendingDeliveryDetail_CheckedChanged);
            // 
            // rdoPendingOrderItemSummary
            // 
            this.rdoPendingOrderItemSummary.AutoSize = true;
            this.rdoPendingOrderItemSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingOrderItemSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingOrderItemSummary.Location = new System.Drawing.Point(11, 7);
            this.rdoPendingOrderItemSummary.Name = "rdoPendingOrderItemSummary";
            this.rdoPendingOrderItemSummary.Size = new System.Drawing.Size(186, 18);
            this.rdoPendingOrderItemSummary.TabIndex = 19;
            this.rdoPendingOrderItemSummary.TabStop = true;
            this.rdoPendingOrderItemSummary.Text = "Pending Delivery Item Summary";
            this.rdoPendingOrderItemSummary.UseVisualStyleBackColor = true;
            this.rdoPendingOrderItemSummary.CheckedChanged += new System.EventHandler(this.rdoPendingOrderItemSummary_CheckedChanged);
            // 
            // rdoPendingOrderItem
            // 
            this.rdoPendingOrderItem.AutoSize = true;
            this.rdoPendingOrderItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingOrderItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingOrderItem.Location = new System.Drawing.Point(11, 29);
            this.rdoPendingOrderItem.Name = "rdoPendingOrderItem";
            this.rdoPendingOrderItem.Size = new System.Drawing.Size(209, 18);
            this.rdoPendingOrderItem.TabIndex = 17;
            this.rdoPendingOrderItem.TabStop = true;
            this.rdoPendingOrderItem.Text = "Pending Delivery Item For Customers";
            this.rdoPendingOrderItem.UseVisualStyleBackColor = true;
            this.rdoPendingOrderItem.CheckedChanged += new System.EventHandler(this.rdoPendingOrderItem_CheckedChanged);
            // 
            // rdoPendingCustomerOrderSummery
            // 
            this.rdoPendingCustomerOrderSummery.AutoSize = true;
            this.rdoPendingCustomerOrderSummery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingCustomerOrderSummery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingCustomerOrderSummery.Location = new System.Drawing.Point(276, 29);
            this.rdoPendingCustomerOrderSummery.Name = "rdoPendingCustomerOrderSummery";
            this.rdoPendingCustomerOrderSummery.Size = new System.Drawing.Size(229, 18);
            this.rdoPendingCustomerOrderSummery.TabIndex = 10;
            this.rdoPendingCustomerOrderSummery.TabStop = true;
            this.rdoPendingCustomerOrderSummery.Text = "Pending Delivery  Summary [Town-Wise]";
            this.rdoPendingCustomerOrderSummery.UseVisualStyleBackColor = true;
            this.rdoPendingCustomerOrderSummery.CheckedChanged += new System.EventHandler(this.rdoPendingCustomerOrderSummery_CheckedChanged);
            // 
            // rdoPendingCustomerOrderDetailTown
            // 
            this.rdoPendingCustomerOrderDetailTown.AutoSize = true;
            this.rdoPendingCustomerOrderDetailTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingCustomerOrderDetailTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingCustomerOrderDetailTown.Location = new System.Drawing.Point(285, 16);
            this.rdoPendingCustomerOrderDetailTown.Name = "rdoPendingCustomerOrderDetailTown";
            this.rdoPendingCustomerOrderDetailTown.Size = new System.Drawing.Size(211, 18);
            this.rdoPendingCustomerOrderDetailTown.TabIndex = 12;
            this.rdoPendingCustomerOrderDetailTown.TabStop = true;
            this.rdoPendingCustomerOrderDetailTown.Text = "Pending Delivery  Detail [Town-Wise]";
            this.rdoPendingCustomerOrderDetailTown.UseVisualStyleBackColor = true;
            this.rdoPendingCustomerOrderDetailTown.CheckedChanged += new System.EventHandler(this.rdoPendingCustomerOrderDetail_CheckedChanged);
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.txtSalesRep);
            this.z2.Controls.Add(this.lblSalseRep);
            this.z2.Controls.Add(this.txtCustomer);
            this.z2.Controls.Add(this.lblCustomer);
            this.z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z2.Location = new System.Drawing.Point(8, 51);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(529, 41);
            this.z2.TabIndex = 6;
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(359, 10);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(163, 22);
            this.txtSalesRep.TabIndex = 459;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            this.txtSalesRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRep_KeyDown);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalseRep.Location = new System.Drawing.Point(270, 13);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(82, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman Code";
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.LightGray;
            this.txtTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(318, 59);
            this.txtTown.Name = "txtTown";
            this.txtTown.ReadOnly = true;
            this.txtTown.Size = new System.Drawing.Size(157, 22);
            this.txtTown.TabIndex = 463;
            this.txtTown.DoubleClick += new System.EventHandler(this.txtTown_DoubleClick);
            this.txtTown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTown_KeyDown);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTown.Location = new System.Drawing.Point(244, 62);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(66, 14);
            this.lblTown.TabIndex = 464;
            this.lblTown.Text = "Town Name";
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(339, 59);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(157, 22);
            this.txtRoute.TabIndex = 461;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            this.txtRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoute_KeyDown);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(265, 62);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 462;
            this.lblRoute.Text = "Route Name";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.dtpFrom);
            this.z1.Controls.Add(this.dtpTo);
            this.z1.Controls.Add(this.label2);
            this.z1.Location = new System.Drawing.Point(8, 98);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(529, 39);
            this.z1.TabIndex = 38;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(462, 143);
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
            this.btnClear.Location = new System.Drawing.Point(384, 143);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_rpt_SalesPendingOrder_APL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(544, 173);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.rdoPendingCustomerOrderDetailTown);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.lblTown);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_SalesPendingOrder_APL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Standed  Report";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.RadioButton rdoPendingCustomerOrderSummery;
        private System.Windows.Forms.RadioButton rdoPendingCustomerOrderDetailTown;
        private System.Windows.Forms.RadioButton rdoPendingOrderItem;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.RadioButton rdoPendingOrderItemSummary;
        private System.Windows.Forms.RadioButton rdoPendingCustomerOrderDetailDate;
        private System.Windows.Forms.RadioButton rdoInvoiceItemSummary;
    }
}