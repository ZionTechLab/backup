namespace Digiteq
{
    partial class frm_pmsProductionJobClose
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
            this.lblProductionJobID = new System.Windows.Forms.Label();
            this.txtProductionJobID = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViewJob = new System.Windows.Forms.Button();
            this.btnJobOpen = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.lblTotalDOQty = new System.Windows.Forms.Label();
            this.lblTotalDOWaight = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lblTotalSRNQty = new System.Windows.Forms.Label();
            this.lblTotalSRNWaigth = new System.Windows.Forms.Label();
            this.xRemark = new System.Windows.Forms.Panel();
            this.chkMultipleSelect = new System.Windows.Forms.CheckBox();
            this.rdoAllInclusiveReport = new System.Windows.Forms.RadioButton();
            this.rdoSVatReport = new System.Windows.Forms.RadioButton();
            this.rdoDutyFreeReport = new System.Windows.Forms.RadioButton();
            this.txtmarkUp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneralOverhead = new System.Windows.Forms.TextBox();
            this.lblInputWaste = new System.Windows.Forms.Label();
            this.btnViewProductionJob = new System.Windows.Forms.Button();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUOM1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerCategory = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblPendingDeliveryQty = new System.Windows.Forms.Label();
            this.btnJobClose = new System.Windows.Forms.Button();
            this.xRemark.SuspendLayout();
            this.zpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductionJobID
            // 
            this.lblProductionJobID.AutoSize = true;
            this.lblProductionJobID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionJobID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProductionJobID.Location = new System.Drawing.Point(10, 10);
            this.lblProductionJobID.Name = "lblProductionJobID";
            this.lblProductionJobID.Size = new System.Drawing.Size(92, 14);
            this.lblProductionJobID.TabIndex = 0;
            this.lblProductionJobID.Text = "Production Job ID";
            // 
            // txtProductionJobID
            // 
            this.txtProductionJobID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtProductionJobID.BackColor = System.Drawing.Color.LightGray;
            this.txtProductionJobID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionJobID.Location = new System.Drawing.Point(138, 7);
            this.txtProductionJobID.Name = "txtProductionJobID";
            this.txtProductionJobID.ReadOnly = true;
            this.txtProductionJobID.Size = new System.Drawing.Size(176, 22);
            this.txtProductionJobID.TabIndex = 1;
            this.txtProductionJobID.DoubleClick += new System.EventHandler(this.txtProductionJobID_DoubleClick);
            this.txtProductionJobID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductionJobID_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(12, 113);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 25);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViewJob
            // 
            this.btnViewJob.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewJob.Image = global::Digiteq.Properties.Resources.info;
            this.btnViewJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewJob.Location = new System.Drawing.Point(317, 7);
            this.btnViewJob.Name = "btnViewJob";
            this.btnViewJob.Size = new System.Drawing.Size(22, 22);
            this.btnViewJob.TabIndex = 6;
            this.btnViewJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewJob.UseVisualStyleBackColor = true;
            this.btnViewJob.Click += new System.EventHandler(this.btnViewJob_Click);
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOpen.ForeColor = System.Drawing.Color.Blue;
            this.btnJobOpen.Image = global::Digiteq.Properties.Resources.accept;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(141, 113);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(133, 25);
            this.btnJobOpen.TabIndex = 3;
            this.btnJobOpen.Text = "Production Job Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.UseVisualStyleBackColor = true;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Red;
            this.btnSelect.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(419, 113);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(168, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Production/Sales Job Close";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label30.Location = new System.Drawing.Point(264, 91);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(111, 14);
            this.label30.TabIndex = 604;
            this.label30.Text = "Delivery Qty/Weight";
            // 
            // lblTotalDOQty
            // 
            this.lblTotalDOQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalDOQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDOQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDOQty.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDOQty.Location = new System.Drawing.Point(396, 87);
            this.lblTotalDOQty.Name = "lblTotalDOQty";
            this.lblTotalDOQty.Size = new System.Drawing.Size(80, 22);
            this.lblTotalDOQty.TabIndex = 603;
            this.lblTotalDOQty.Text = "2342342";
            this.lblTotalDOQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDOWaight
            // 
            this.lblTotalDOWaight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalDOWaight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDOWaight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDOWaight.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDOWaight.Location = new System.Drawing.Point(482, 87);
            this.lblTotalDOWaight.Name = "lblTotalDOWaight";
            this.lblTotalDOWaight.Size = new System.Drawing.Size(80, 22);
            this.lblTotalDOWaight.TabIndex = 602;
            this.lblTotalDOWaight.Text = "2342342";
            this.lblTotalDOWaight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label21.Location = new System.Drawing.Point(10, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 14);
            this.label21.TabIndex = 605;
            this.label21.Text = "Order Qty";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.BackColor = System.Drawing.Color.White;
            this.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty.ForeColor = System.Drawing.Color.Black;
            this.lblOrderQty.Location = new System.Drawing.Point(124, 87);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(94, 22);
            this.lblOrderQty.TabIndex = 606;
            this.lblOrderQty.Text = "2342342";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUOM
            // 
            this.lblUOM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUOM.Location = new System.Drawing.Point(224, 87);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(29, 22);
            this.lblUOM.TabIndex = 607;
            this.lblUOM.Text = "KG";
            this.lblUOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label39.Location = new System.Drawing.Point(264, 118);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(114, 14);
            this.label39.TabIndex = 610;
            this.label39.Text = "Returned Qty/Weight";
            // 
            // lblTotalSRNQty
            // 
            this.lblTotalSRNQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalSRNQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSRNQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSRNQty.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalSRNQty.Location = new System.Drawing.Point(396, 114);
            this.lblTotalSRNQty.Name = "lblTotalSRNQty";
            this.lblTotalSRNQty.Size = new System.Drawing.Size(80, 22);
            this.lblTotalSRNQty.TabIndex = 609;
            this.lblTotalSRNQty.Text = "2342342";
            this.lblTotalSRNQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSRNWaigth
            // 
            this.lblTotalSRNWaigth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalSRNWaigth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSRNWaigth.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSRNWaigth.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalSRNWaigth.Location = new System.Drawing.Point(482, 114);
            this.lblTotalSRNWaigth.Name = "lblTotalSRNWaigth";
            this.lblTotalSRNWaigth.Size = new System.Drawing.Size(80, 22);
            this.lblTotalSRNWaigth.TabIndex = 608;
            this.lblTotalSRNWaigth.Text = "2342342";
            this.lblTotalSRNWaigth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xRemark
            // 
            this.xRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xRemark.Controls.Add(this.chkMultipleSelect);
            this.xRemark.Controls.Add(this.rdoAllInclusiveReport);
            this.xRemark.Controls.Add(this.rdoSVatReport);
            this.xRemark.Controls.Add(this.rdoDutyFreeReport);
            this.xRemark.Controls.Add(this.txtmarkUp);
            this.xRemark.Controls.Add(this.label3);
            this.xRemark.Controls.Add(this.txtGeneralOverhead);
            this.xRemark.Controls.Add(this.lblInputWaste);
            this.xRemark.Controls.Add(this.btnViewProductionJob);
            this.xRemark.Controls.Add(this.txtProductionJobID);
            this.xRemark.Controls.Add(this.lblProductionJobID);
            this.xRemark.Controls.Add(this.btnViewJob);
            this.xRemark.Location = new System.Drawing.Point(12, 11);
            this.xRemark.Name = "xRemark";
            this.xRemark.Size = new System.Drawing.Size(574, 96);
            this.xRemark.TabIndex = 611;
            // 
            // chkMultipleSelect
            // 
            this.chkMultipleSelect.AutoSize = true;
            this.chkMultipleSelect.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkMultipleSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkMultipleSelect.Location = new System.Drawing.Point(376, 9);
            this.chkMultipleSelect.Name = "chkMultipleSelect";
            this.chkMultipleSelect.Size = new System.Drawing.Size(100, 18);
            this.chkMultipleSelect.TabIndex = 17;
            this.chkMultipleSelect.Text = "Multiple Select";
            this.chkMultipleSelect.UseVisualStyleBackColor = true;
            // 
            // rdoAllInclusiveReport
            // 
            this.rdoAllInclusiveReport.AutoSize = true;
            this.rdoAllInclusiveReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAllInclusiveReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAllInclusiveReport.Location = new System.Drawing.Point(381, 64);
            this.rdoAllInclusiveReport.Name = "rdoAllInclusiveReport";
            this.rdoAllInclusiveReport.Size = new System.Drawing.Size(188, 18);
            this.rdoAllInclusiveReport.TabIndex = 13;
            this.rdoAllInclusiveReport.TabStop = true;
            this.rdoAllInclusiveReport.Text = "All Inclusive Cost Analysis Report";
            this.rdoAllInclusiveReport.UseVisualStyleBackColor = true;
            // 
            // rdoSVatReport
            // 
            this.rdoSVatReport.AutoSize = true;
            this.rdoSVatReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSVatReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSVatReport.Location = new System.Drawing.Point(207, 64);
            this.rdoSVatReport.Name = "rdoSVatReport";
            this.rdoSVatReport.Size = new System.Drawing.Size(157, 18);
            this.rdoSVatReport.TabIndex = 14;
            this.rdoSVatReport.TabStop = true;
            this.rdoSVatReport.Text = "S-VAT Cost Analysis Report";
            this.rdoSVatReport.UseVisualStyleBackColor = true;
            // 
            // rdoDutyFreeReport
            // 
            this.rdoDutyFreeReport.AutoSize = true;
            this.rdoDutyFreeReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDutyFreeReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDutyFreeReport.Location = new System.Drawing.Point(12, 64);
            this.rdoDutyFreeReport.Name = "rdoDutyFreeReport";
            this.rdoDutyFreeReport.Size = new System.Drawing.Size(178, 18);
            this.rdoDutyFreeReport.TabIndex = 15;
            this.rdoDutyFreeReport.TabStop = true;
            this.rdoDutyFreeReport.Text = "Duty Free Cost Analysis Report";
            this.rdoDutyFreeReport.UseVisualStyleBackColor = true;
            // 
            // txtmarkUp
            // 
            this.txtmarkUp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmarkUp.ForeColor = System.Drawing.Color.Black;
            this.txtmarkUp.Location = new System.Drawing.Point(317, 36);
            this.txtmarkUp.Name = "txtmarkUp";
            this.txtmarkUp.ReadOnly = true;
            this.txtmarkUp.Size = new System.Drawing.Size(68, 22);
            this.txtmarkUp.TabIndex = 12;
            this.txtmarkUp.Text = "15";
            this.txtmarkUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtmarkUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmarkUp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(243, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mark Up % :";
            // 
            // txtGeneralOverhead
            // 
            this.txtGeneralOverhead.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneralOverhead.ForeColor = System.Drawing.Color.Black;
            this.txtGeneralOverhead.Location = new System.Drawing.Point(138, 35);
            this.txtGeneralOverhead.Name = "txtGeneralOverhead";
            this.txtGeneralOverhead.ReadOnly = true;
            this.txtGeneralOverhead.Size = new System.Drawing.Size(68, 22);
            this.txtGeneralOverhead.TabIndex = 10;
            this.txtGeneralOverhead.Text = "11";
            this.txtGeneralOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGeneralOverhead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGeneralOverhead_KeyPress);
            // 
            // lblInputWaste
            // 
            this.lblInputWaste.AutoSize = true;
            this.lblInputWaste.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputWaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblInputWaste.Location = new System.Drawing.Point(9, 39);
            this.lblInputWaste.Name = "lblInputWaste";
            this.lblInputWaste.Size = new System.Drawing.Size(115, 14);
            this.lblInputWaste.TabIndex = 9;
            this.lblInputWaste.Text = "General Overhead % :";
            // 
            // btnViewProductionJob
            // 
            this.btnViewProductionJob.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProductionJob.Image = global::Digiteq.Properties.Resources.info;
            this.btnViewProductionJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewProductionJob.Location = new System.Drawing.Point(341, 7);
            this.btnViewProductionJob.Name = "btnViewProductionJob";
            this.btnViewProductionJob.Size = new System.Drawing.Size(22, 22);
            this.btnViewProductionJob.TabIndex = 7;
            this.btnViewProductionJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewProductionJob.UseVisualStyleBackColor = true;
            this.btnViewProductionJob.Click += new System.EventHandler(this.btnViewProductionJob_Click);
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.zpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel1.Controls.Add(this.label2);
            this.zpanel1.Controls.Add(this.lblUOM1);
            this.zpanel1.Controls.Add(this.lblCustomerName);
            this.zpanel1.Controls.Add(this.lblCustomerCategory);
            this.zpanel1.Controls.Add(this.lblItemID);
            this.zpanel1.Controls.Add(this.label221);
            this.zpanel1.Controls.Add(this.lblCustomerCode);
            this.zpanel1.Controls.Add(this.label95);
            this.zpanel1.Controls.Add(this.label16);
            this.zpanel1.Controls.Add(this.label1);
            this.zpanel1.Controls.Add(this.lblOrderDate);
            this.zpanel1.Controls.Add(this.lblOrderNo);
            this.zpanel1.Controls.Add(this.lblDeliveryDate);
            this.zpanel1.Controls.Add(this.lblPendingDeliveryQty);
            this.zpanel1.Controls.Add(this.label39);
            this.zpanel1.Controls.Add(this.lblTotalSRNQty);
            this.zpanel1.Controls.Add(this.lblTotalSRNWaigth);
            this.zpanel1.Controls.Add(this.lblTotalDOQty);
            this.zpanel1.Controls.Add(this.label30);
            this.zpanel1.Controls.Add(this.lblTotalDOWaight);
            this.zpanel1.Controls.Add(this.lblOrderQty);
            this.zpanel1.Controls.Add(this.lblUOM);
            this.zpanel1.Controls.Add(this.label21);
            this.zpanel1.Location = new System.Drawing.Point(12, 144);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(575, 148);
            this.zpanel1.TabIndex = 612;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 626;
            this.label2.Text = "Pending Qty";
            // 
            // lblUOM1
            // 
            this.lblUOM1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUOM1.Location = new System.Drawing.Point(224, 114);
            this.lblUOM1.Name = "lblUOM1";
            this.lblUOM1.Size = new System.Drawing.Size(29, 22);
            this.lblUOM1.TabIndex = 625;
            this.lblUOM1.Text = "KG";
            this.lblUOM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomerName.Location = new System.Drawing.Point(264, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(298, 22);
            this.lblCustomerName.TabIndex = 623;
            this.lblCustomerName.Text = "1,120,175.00";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerCategory
            // 
            this.lblCustomerCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCategory.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomerCategory.Location = new System.Drawing.Point(264, 33);
            this.lblCustomerCategory.Name = "lblCustomerCategory";
            this.lblCustomerCategory.Size = new System.Drawing.Size(298, 22);
            this.lblCustomerCategory.TabIndex = 624;
            this.lblCustomerCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemID
            // 
            this.lblItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.ForeColor = System.Drawing.Color.Blue;
            this.lblItemID.Location = new System.Drawing.Point(124, 33);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(129, 22);
            this.lblItemID.TabIndex = 621;
            this.lblItemID.Text = "160,251.00";
            this.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label221.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label221.Location = new System.Drawing.Point(10, 64);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(87, 14);
            this.label221.TabIndex = 619;
            this.label221.Text = "Customer Name";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomerCode.Location = new System.Drawing.Point(124, 60);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(129, 22);
            this.lblCustomerCode.TabIndex = 622;
            this.lblCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label95.Location = new System.Drawing.Point(10, 37);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(63, 14);
            this.label95.TabIndex = 620;
            this.label95.Text = "Item Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label16.Location = new System.Drawing.Point(264, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 14);
            this.label16.TabIndex = 614;
            this.label16.Text = "Order / Delivery Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 615;
            this.label1.Text = "Order No";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderDate.Location = new System.Drawing.Point(384, 6);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(86, 22);
            this.lblOrderDate.TabIndex = 616;
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderNo.Location = new System.Drawing.Point(124, 6);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(130, 22);
            this.lblOrderNo.TabIndex = 617;
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.ForeColor = System.Drawing.Color.Blue;
            this.lblDeliveryDate.Location = new System.Drawing.Point(476, 6);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(86, 22);
            this.lblDeliveryDate.TabIndex = 618;
            this.lblDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPendingDeliveryQty
            // 
            this.lblPendingDeliveryQty.BackColor = System.Drawing.Color.Red;
            this.lblPendingDeliveryQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDeliveryQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingDeliveryQty.ForeColor = System.Drawing.Color.White;
            this.lblPendingDeliveryQty.Location = new System.Drawing.Point(123, 114);
            this.lblPendingDeliveryQty.Name = "lblPendingDeliveryQty";
            this.lblPendingDeliveryQty.Size = new System.Drawing.Size(95, 22);
            this.lblPendingDeliveryQty.TabIndex = 612;
            this.lblPendingDeliveryQty.Text = "2342342";
            this.lblPendingDeliveryQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnJobClose
            // 
            this.btnJobClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobClose.ForeColor = System.Drawing.Color.Red;
            this.btnJobClose.Image = global::Digiteq.Properties.Resources.accept;
            this.btnJobClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobClose.Location = new System.Drawing.Point(280, 113);
            this.btnJobClose.Name = "btnJobClose";
            this.btnJobClose.Size = new System.Drawing.Size(136, 25);
            this.btnJobClose.TabIndex = 625;
            this.btnJobClose.Text = "Production Job Close";
            this.btnJobClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobClose.UseVisualStyleBackColor = true;
            this.btnJobClose.Click += new System.EventHandler(this.btnJobClose_Click);
            // 
            // frm_pmsProductionJobClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(596, 303);
            this.Controls.Add(this.btnJobClose);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.xRemark);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnJobOpen);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_pmsProductionJobClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmItemSearch_Load);
            this.xRemark.ResumeLayout(false);
            this.xRemark.PerformLayout();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductionJobID;
        private System.Windows.Forms.TextBox txtProductionJobID;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnViewJob;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblTotalDOQty;
        private System.Windows.Forms.Label lblTotalDOWaight;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblTotalSRNQty;
        private System.Windows.Forms.Label lblTotalSRNWaigth;
        private System.Windows.Forms.Panel xRemark;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.Label lblPendingDeliveryQty;
        private System.Windows.Forms.Button btnViewProductionJob;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerCategory;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Button btnJobClose;
        private System.Windows.Forms.Label lblUOM1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoAllInclusiveReport;
        private System.Windows.Forms.RadioButton rdoSVatReport;
        private System.Windows.Forms.RadioButton rdoDutyFreeReport;
        private System.Windows.Forms.TextBox txtmarkUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGeneralOverhead;
        private System.Windows.Forms.Label lblInputWaste;
        private System.Windows.Forms.CheckBox chkMultipleSelect;
    }
}