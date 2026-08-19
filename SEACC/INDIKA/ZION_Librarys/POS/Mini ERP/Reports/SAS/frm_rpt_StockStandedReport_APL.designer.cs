namespace Digiteq
{
    partial class frm_rpt_StockStandedReport_APL
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
            this.rdo_TrackingReport_Qty = new System.Windows.Forms.RadioButton();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoStockValueReport = new System.Windows.Forms.RadioButton();
            this.rdoAgeAnalysis = new System.Windows.Forms.RadioButton();
            this.rdoPO_TrackingReport = new System.Windows.Forms.RadioButton();
            this.rdoSRvsGIN = new System.Windows.Forms.RadioButton();
            this.rdoItemSplitNoteDelta = new System.Windows.Forms.RadioButton();
            this.rdo_TrackingReport_Weight = new System.Windows.Forms.RadioButton();
            this.rdoStockTake = new System.Windows.Forms.RadioButton();
            this.rdoPOItemCostHistory = new System.Windows.Forms.RadioButton();
            this.rdoPendingLoanIn = new System.Windows.Forms.RadioButton();
            this.rdoStockBalanceVsPending = new System.Windows.Forms.RadioButton();
            this.rdoPendingLoanOut = new System.Windows.Forms.RadioButton();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.z2 = new System.Windows.Forms.Panel();
            this.lblPONo = new System.Windows.Forms.Label();
            this.txtPoNo = new System.Windows.Forms.TextBox();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.lblItemCategory = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.z2.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_TrackingReport_Qty
            // 
            this.rdo_TrackingReport_Qty.AutoSize = true;
            this.rdo_TrackingReport_Qty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_TrackingReport_Qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdo_TrackingReport_Qty.Location = new System.Drawing.Point(10, 10);
            this.rdo_TrackingReport_Qty.Name = "rdo_TrackingReport_Qty";
            this.rdo_TrackingReport_Qty.Size = new System.Drawing.Size(165, 18);
            this.rdo_TrackingReport_Qty.TabIndex = 2;
            this.rdo_TrackingReport_Qty.TabStop = true;
            this.rdo_TrackingReport_Qty.Text = "Stocks Tracking Report - Qty";
            this.rdo_TrackingReport_Qty.UseVisualStyleBackColor = true;
            this.rdo_TrackingReport_Qty.CheckedChanged += new System.EventHandler(this.rdoStoreStock_CheckedChanged);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoStockValueReport);
            this.x1.Controls.Add(this.rdo_TrackingReport_Qty);
            this.x1.Controls.Add(this.rdoAgeAnalysis);
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(406, 69);
            this.x1.TabIndex = 5;
            // 
            // rdoStockValueReport
            // 
            this.rdoStockValueReport.AutoSize = true;
            this.rdoStockValueReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStockValueReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoStockValueReport.Location = new System.Drawing.Point(10, 37);
            this.rdoStockValueReport.Name = "rdoStockValueReport";
            this.rdoStockValueReport.Size = new System.Drawing.Size(118, 18);
            this.rdoStockValueReport.TabIndex = 11;
            this.rdoStockValueReport.TabStop = true;
            this.rdoStockValueReport.Text = "Stock Value Report";
            this.rdoStockValueReport.UseVisualStyleBackColor = true;
            // 
            // rdoAgeAnalysis
            // 
            this.rdoAgeAnalysis.AutoSize = true;
            this.rdoAgeAnalysis.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAgeAnalysis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAgeAnalysis.Location = new System.Drawing.Point(223, 37);
            this.rdoAgeAnalysis.Name = "rdoAgeAnalysis";
            this.rdoAgeAnalysis.Size = new System.Drawing.Size(154, 18);
            this.rdoAgeAnalysis.TabIndex = 10;
            this.rdoAgeAnalysis.TabStop = true;
            this.rdoAgeAnalysis.Text = "Stock Age Analysis Report";
            this.rdoAgeAnalysis.UseVisualStyleBackColor = true;
            // 
            // rdoPO_TrackingReport
            // 
            this.rdoPO_TrackingReport.AutoSize = true;
            this.rdoPO_TrackingReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPO_TrackingReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPO_TrackingReport.Location = new System.Drawing.Point(133, 93);
            this.rdoPO_TrackingReport.Name = "rdoPO_TrackingReport";
            this.rdoPO_TrackingReport.Size = new System.Drawing.Size(180, 18);
            this.rdoPO_TrackingReport.TabIndex = 9;
            this.rdoPO_TrackingReport.TabStop = true;
            this.rdoPO_TrackingReport.Text = "Purchase Order Tracking Report";
            this.rdoPO_TrackingReport.UseVisualStyleBackColor = true;
            // 
            // rdoSRvsGIN
            // 
            this.rdoSRvsGIN.AutoSize = true;
            this.rdoSRvsGIN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSRvsGIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSRvsGIN.Location = new System.Drawing.Point(209, 106);
            this.rdoSRvsGIN.Name = "rdoSRvsGIN";
            this.rdoSRvsGIN.Size = new System.Drawing.Size(146, 18);
            this.rdoSRvsGIN.TabIndex = 7;
            this.rdoSRvsGIN.TabStop = true;
            this.rdoSRvsGIN.Text = "Store Requests vs Issues";
            this.rdoSRvsGIN.UseVisualStyleBackColor = true;
            this.rdoSRvsGIN.CheckedChanged += new System.EventHandler(this.rdoSRvsGIN_CheckedChanged);
            // 
            // rdoItemSplitNoteDelta
            // 
            this.rdoItemSplitNoteDelta.AutoSize = true;
            this.rdoItemSplitNoteDelta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoItemSplitNoteDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoItemSplitNoteDelta.Location = new System.Drawing.Point(184, 106);
            this.rdoItemSplitNoteDelta.Name = "rdoItemSplitNoteDelta";
            this.rdoItemSplitNoteDelta.Size = new System.Drawing.Size(173, 18);
            this.rdoItemSplitNoteDelta.TabIndex = 6;
            this.rdoItemSplitNoteDelta.TabStop = true;
            this.rdoItemSplitNoteDelta.Text = "Item Split Note - Delta Report";
            this.rdoItemSplitNoteDelta.UseVisualStyleBackColor = true;
            this.rdoItemSplitNoteDelta.CheckedChanged += new System.EventHandler(this.rdoItemSplitNoteDelta_CheckedChanged);
            // 
            // rdo_TrackingReport_Weight
            // 
            this.rdo_TrackingReport_Weight.AutoSize = true;
            this.rdo_TrackingReport_Weight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_TrackingReport_Weight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdo_TrackingReport_Weight.Location = new System.Drawing.Point(182, 98);
            this.rdo_TrackingReport_Weight.Name = "rdo_TrackingReport_Weight";
            this.rdo_TrackingReport_Weight.Size = new System.Drawing.Size(183, 18);
            this.rdo_TrackingReport_Weight.TabIndex = 5;
            this.rdo_TrackingReport_Weight.TabStop = true;
            this.rdo_TrackingReport_Weight.Text = "Stocks Tracking Report - Weight";
            this.rdo_TrackingReport_Weight.UseVisualStyleBackColor = true;
            this.rdo_TrackingReport_Weight.CheckedChanged += new System.EventHandler(this.rdo_TrackingReport_Weight_CheckedChanged);
            // 
            // rdoStockTake
            // 
            this.rdoStockTake.AutoSize = true;
            this.rdoStockTake.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStockTake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoStockTake.Location = new System.Drawing.Point(218, 117);
            this.rdoStockTake.Name = "rdoStockTake";
            this.rdoStockTake.Size = new System.Drawing.Size(137, 18);
            this.rdoStockTake.TabIndex = 3;
            this.rdoStockTake.TabStop = true;
            this.rdoStockTake.Text = "Opening Stocks Report";
            this.rdoStockTake.UseVisualStyleBackColor = true;
            this.rdoStockTake.CheckedChanged += new System.EventHandler(this.rdoStockTake_CheckedChanged);
            // 
            // rdoPOItemCostHistory
            // 
            this.rdoPOItemCostHistory.AutoSize = true;
            this.rdoPOItemCostHistory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPOItemCostHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPOItemCostHistory.Location = new System.Drawing.Point(192, 117);
            this.rdoPOItemCostHistory.Name = "rdoPOItemCostHistory";
            this.rdoPOItemCostHistory.Size = new System.Drawing.Size(128, 18);
            this.rdoPOItemCostHistory.TabIndex = 12;
            this.rdoPOItemCostHistory.TabStop = true;
            this.rdoPOItemCostHistory.Text = "PO Item Cost History";
            this.rdoPOItemCostHistory.UseVisualStyleBackColor = true;
            this.rdoPOItemCostHistory.CheckedChanged += new System.EventHandler(this.rdoPOItemCostHistory_CheckedChanged);
            // 
            // rdoPendingLoanIn
            // 
            this.rdoPendingLoanIn.AutoSize = true;
            this.rdoPendingLoanIn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingLoanIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingLoanIn.Location = new System.Drawing.Point(225, 116);
            this.rdoPendingLoanIn.Name = "rdoPendingLoanIn";
            this.rdoPendingLoanIn.Size = new System.Drawing.Size(105, 18);
            this.rdoPendingLoanIn.TabIndex = 8;
            this.rdoPendingLoanIn.TabStop = true;
            this.rdoPendingLoanIn.Text = "Pending Loan-IN";
            this.rdoPendingLoanIn.UseVisualStyleBackColor = true;
            this.rdoPendingLoanIn.CheckedChanged += new System.EventHandler(this.rdoPendingLoanIn_CheckedChanged);
            // 
            // rdoStockBalanceVsPending
            // 
            this.rdoStockBalanceVsPending.AutoSize = true;
            this.rdoStockBalanceVsPending.Enabled = false;
            this.rdoStockBalanceVsPending.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStockBalanceVsPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoStockBalanceVsPending.Location = new System.Drawing.Point(164, 117);
            this.rdoStockBalanceVsPending.Name = "rdoStockBalanceVsPending";
            this.rdoStockBalanceVsPending.Size = new System.Drawing.Size(191, 18);
            this.rdoStockBalanceVsPending.TabIndex = 4;
            this.rdoStockBalanceVsPending.TabStop = true;
            this.rdoStockBalanceVsPending.Text = "Stocks Balance Vs Pending Orders";
            this.rdoStockBalanceVsPending.UseVisualStyleBackColor = true;
            this.rdoStockBalanceVsPending.CheckedChanged += new System.EventHandler(this.rdoStockBalanceVsPending_CheckedChanged);
            // 
            // rdoPendingLoanOut
            // 
            this.rdoPendingLoanOut.AutoSize = true;
            this.rdoPendingLoanOut.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingLoanOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingLoanOut.Location = new System.Drawing.Point(166, 116);
            this.rdoPendingLoanOut.Name = "rdoPendingLoanOut";
            this.rdoPendingLoanOut.Size = new System.Drawing.Size(112, 18);
            this.rdoPendingLoanOut.TabIndex = 3;
            this.rdoPendingLoanOut.TabStop = true;
            this.rdoPendingLoanOut.Text = "Pending Loan-Out";
            this.rdoPendingLoanOut.UseVisualStyleBackColor = true;
            this.rdoPendingLoanOut.CheckedChanged += new System.EventHandler(this.rdoPendingLoanOut_CheckedChanged);
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.LightGray;
            this.txtStore.Enabled = false;
            this.txtStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(78, 8);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(162, 22);
            this.txtStore.TabIndex = 15;
            this.txtStore.DoubleClick += new System.EventHandler(this.txtStoreStock_DoubleClick);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(334, 204);
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
            this.btnClear.Location = new System.Drawing.Point(256, 204);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.lblStore);
            this.z2.Controls.Add(this.txtItemName);
            this.z2.Controls.Add(this.lblItemName);
            this.z2.Controls.Add(this.txtStore);
            this.z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z2.Location = new System.Drawing.Point(8, 83);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(406, 70);
            this.z2.TabIndex = 477;
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPONo.Location = new System.Drawing.Point(202, 118);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(41, 14);
            this.lblPONo.TabIndex = 22;
            this.lblPONo.Text = "PO No.";
            // 
            // txtPoNo
            // 
            this.txtPoNo.BackColor = System.Drawing.Color.LightGray;
            this.txtPoNo.Enabled = false;
            this.txtPoNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoNo.Location = new System.Drawing.Point(243, 116);
            this.txtPoNo.Name = "txtPoNo";
            this.txtPoNo.ReadOnly = true;
            this.txtPoNo.Size = new System.Drawing.Size(138, 22);
            this.txtPoNo.TabIndex = 21;
            this.txtPoNo.DoubleClick += new System.EventHandler(this.txtPoNo_DoubleClick);
            this.txtPoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPoNo_KeyDown);
            // 
            // txtItemType
            // 
            this.txtItemType.BackColor = System.Drawing.Color.LightGray;
            this.txtItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(212, 97);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.ReadOnly = true;
            this.txtItemType.Size = new System.Drawing.Size(197, 22);
            this.txtItemType.TabIndex = 19;
            this.txtItemType.DoubleClick += new System.EventHandler(this.txtItemType_DoubleClick);
            this.txtItemType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemType_KeyDown);
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemType.Location = new System.Drawing.Point(154, 99);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(57, 14);
            this.lblItemType.TabIndex = 20;
            this.lblItemType.Text = "Item Type";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(212, 124);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.ReadOnly = true;
            this.txtItemCategory.Size = new System.Drawing.Size(197, 22);
            this.txtItemCategory.TabIndex = 17;
            this.txtItemCategory.DoubleClick += new System.EventHandler(this.txtItemCategory_DoubleClick);
            this.txtItemCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCategory_KeyDown);
            // 
            // lblItemCategory
            // 
            this.lblItemCategory.AutoSize = true;
            this.lblItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemCategory.Location = new System.Drawing.Point(154, 126);
            this.lblItemCategory.Name = "lblItemCategory";
            this.lblItemCategory.Size = new System.Drawing.Size(77, 14);
            this.lblItemCategory.TabIndex = 18;
            this.lblItemCategory.Text = "Item Category";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStore.Location = new System.Drawing.Point(7, 12);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(66, 14);
            this.lblStore.TabIndex = 16;
            this.lblStore.Text = "Store Name";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.LightGray;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(78, 37);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(299, 22);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtItemName_DoubleClick);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblItemName.Location = new System.Drawing.Point(7, 41);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(63, 14);
            this.lblItemName.TabIndex = 12;
            this.lblItemName.Text = "Item Name";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label2);
            this.z1.Controls.Add(this.dtpFrom);
            this.z1.Controls.Add(this.dtpTo);
            this.z1.Controls.Add(this.label3);
            this.z1.Location = new System.Drawing.Point(8, 159);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(406, 39);
            this.z1.TabIndex = 478;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(86, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(96, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(289, 8);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(96, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(225, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Period To :";
            // 
            // frm_rpt_StockStandedReport_APL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(421, 233);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.lblPONo);
            this.Controls.Add(this.txtItemCategory);
            this.Controls.Add(this.rdoStockTake);
            this.Controls.Add(this.lblItemCategory);
            this.Controls.Add(this.txtPoNo);
            this.Controls.Add(this.rdo_TrackingReport_Weight);
            this.Controls.Add(this.rdoPOItemCostHistory);
            this.Controls.Add(this.rdoItemSplitNoteDelta);
            this.Controls.Add(this.rdoSRvsGIN);
            this.Controls.Add(this.rdoPO_TrackingReport);
            this.Controls.Add(this.rdoPendingLoanIn);
            this.Controls.Add(this.rdoStockBalanceVsPending);
            this.Controls.Add(this.rdoPendingLoanOut);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_StockStandedReport_APL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Analysis Report";
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

        private System.Windows.Forms.RadioButton rdo_TrackingReport_Qty;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoStockTake;
        private System.Windows.Forms.RadioButton rdoStockBalanceVsPending;
        private System.Windows.Forms.RadioButton rdo_TrackingReport_Weight;
        private System.Windows.Forms.RadioButton rdoItemSplitNoteDelta;
        private System.Windows.Forms.RadioButton rdoPendingLoanOut;
        private System.Windows.Forms.RadioButton rdoSRvsGIN;
        private System.Windows.Forms.RadioButton rdoPendingLoanIn;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label lblItemCategory;
        private System.Windows.Forms.RadioButton rdoPO_TrackingReport;
        private System.Windows.Forms.RadioButton rdoAgeAnalysis;
        private System.Windows.Forms.RadioButton rdoStockValueReport;
        private System.Windows.Forms.RadioButton rdoPOItemCostHistory;
        private System.Windows.Forms.Label lblPONo;
        private System.Windows.Forms.TextBox txtPoNo;
    }
}