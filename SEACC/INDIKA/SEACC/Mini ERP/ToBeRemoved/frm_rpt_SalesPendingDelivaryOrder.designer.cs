namespace Digiteq
{
    partial class frm_rpt_SalesPendingDelivaryOrder
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
            this.pnl1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoPendingCustomerOrderDetailDate = new System.Windows.Forms.RadioButton();
            this.rdoPendingOrderItemSummary = new System.Windows.Forms.RadioButton();
            this.rdoPendingOrderItem = new System.Windows.Forms.RadioButton();
            this.rdoPendingCustomerOrderSummery = new System.Windows.Forms.RadioButton();
            this.rdoPendingCustomerOrderDetailTown = new System.Windows.Forms.RadioButton();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
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
            this.lblCustomer.Location = new System.Drawing.Point(7, 14);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(95, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(165, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(275, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Period To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(349, 9);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(163, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.Transparent;
            this.pnl1.Controls.Add(this.rdoPendingCustomerOrderDetailDate);
            this.pnl1.Controls.Add(this.rdoPendingOrderItemSummary);
            this.pnl1.Controls.Add(this.rdoPendingOrderItem);
            this.pnl1.Controls.Add(this.rdoPendingCustomerOrderSummery);
            this.pnl1.Controls.Add(this.rdoPendingCustomerOrderDetailTown);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl1.Location = new System.Drawing.Point(3, 29);
            this.pnl1.Name = "pnl1";
            this.pnl1.Padding = new System.Windows.Forms.Padding(10, 10, 5, 5);
            this.pnl1.Size = new System.Drawing.Size(523, 92);
            this.pnl1.TabIndex = 5;
            // 
            // rdoPendingCustomerOrderDetailDate
            // 
            this.rdoPendingCustomerOrderDetailDate.AutoSize = true;
            this.rdoPendingCustomerOrderDetailDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingCustomerOrderDetailDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingCustomerOrderDetailDate.Location = new System.Drawing.Point(13, 13);
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
            this.rdoPendingOrderItemSummary.Location = new System.Drawing.Point(13, 37);
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
            this.rdoPendingOrderItem.Location = new System.Drawing.Point(13, 61);
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
            this.rdoPendingCustomerOrderSummery.Location = new System.Drawing.Point(228, 13);
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
            this.rdoPendingCustomerOrderDetailTown.Location = new System.Drawing.Point(228, 37);
            this.rdoPendingCustomerOrderDetailTown.Name = "rdoPendingCustomerOrderDetailTown";
            this.rdoPendingCustomerOrderDetailTown.Size = new System.Drawing.Size(211, 18);
            this.rdoPendingCustomerOrderDetailTown.TabIndex = 12;
            this.rdoPendingCustomerOrderDetailTown.TabStop = true;
            this.rdoPendingCustomerOrderDetailTown.Text = "Pending Delivery  Detail [Town-Wise]";
            this.rdoPendingCustomerOrderDetailTown.UseVisualStyleBackColor = true;
            this.rdoPendingCustomerOrderDetailTown.CheckedChanged += new System.EventHandler(this.rdoPendingCustomerOrderDetail_CheckedChanged);
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnl2.Controls.Add(this.txtItem);
            this.pnl2.Controls.Add(this.lblItem);
            this.pnl2.Controls.Add(this.txtTown);
            this.pnl2.Controls.Add(this.lblTown);
            this.pnl2.Controls.Add(this.txtRoute);
            this.pnl2.Controls.Add(this.lblRoute);
            this.pnl2.Controls.Add(this.txtSalesRep);
            this.pnl2.Controls.Add(this.lblSalseRep);
            this.pnl2.Controls.Add(this.txtCustomer);
            this.pnl2.Controls.Add(this.lblCustomer);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnl2.Location = new System.Drawing.Point(3, 121);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(523, 100);
            this.pnl2.TabIndex = 6;
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.Color.LightGray;
            this.txtItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(97, 65);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(163, 22);
            this.txtItem.TabIndex = 465;
            this.txtItem.DoubleClick += new System.EventHandler(this.txtItem_DoubleClick);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItem.Location = new System.Drawing.Point(8, 69);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(57, 14);
            this.lblItem.TabIndex = 466;
            this.lblItem.Text = "Item Code";
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.LightGray;
            this.txtTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(349, 37);
            this.txtTown.Name = "txtTown";
            this.txtTown.ReadOnly = true;
            this.txtTown.Size = new System.Drawing.Size(163, 22);
            this.txtTown.TabIndex = 463;
            this.txtTown.DoubleClick += new System.EventHandler(this.txtTown_DoubleClick);
            this.txtTown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTown_KeyDown);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTown.Location = new System.Drawing.Point(275, 41);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(66, 14);
            this.lblTown.TabIndex = 464;
            this.lblTown.Text = "Town Name";
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(349, 10);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(163, 22);
            this.txtRoute.TabIndex = 461;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            this.txtRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoute_KeyDown);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(275, 14);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 462;
            this.lblRoute.Text = "Route Name";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(97, 37);
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
            this.lblSalseRep.Location = new System.Drawing.Point(8, 41);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(82, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman Code";
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.White;
            this.pnl3.Controls.Add(this.panel1);
            this.pnl3.Controls.Add(this.label1);
            this.pnl3.Controls.Add(this.dtpFrom);
            this.pnl3.Controls.Add(this.dtpTo);
            this.pnl3.Controls.Add(this.label2);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl3.Location = new System.Drawing.Point(3, 221);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(523, 40);
            this.pnl3.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 2);
            this.panel1.TabIndex = 477;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(439, 266);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(360, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_rpt_SalesPendingDelivaryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 300);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_SalesPendingDelivaryOrder";
            this.Text = "Sales Standed  Report";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.pnl1, 0);
            this.Controls.SetChildIndex(this.pnl2, 0);
            this.Controls.SetChildIndex(this.pnl3, 0);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.FlowLayoutPanel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel pnl3;
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
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Panel panel1;
    }
}