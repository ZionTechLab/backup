using DataTire;
using Digiteq.Properties;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Digiteq
{
    partial class frm_accCreditorSettlement
    {
        private IContainer components = null;



        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
       

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.x5 = new System.Windows.Forms.Panel();
            this.dgvAPN = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtAPNSettlementID = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.lblCustomerOrderID = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.z1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.TextBox();
            this.zpnlSettledPayment = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAPNAmount = new System.Windows.Forms.TextBox();
            this.zpnlSelettedAPN = new System.Windows.Forms.FlowLayoutPanel();
            this.pgrAPN = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pgrPayment = new System.Windows.Forms.ProgressBar();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.SettlementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APNID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.x6 = new System.Windows.Forms.Panel();
            this.TxnPv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnIDPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Txn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPV)).BeginInit();
            this.panel1.SuspendLayout();
            this.z1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.x6.SuspendLayout();
            this.SuspendLayout();
            // 
            // x5
            // 
            this.x5.BackColor = System.Drawing.Color.White;
            this.x5.Controls.Add(this.dgvAPN);
            this.x5.Controls.Add(this.label3);
            this.x5.Location = new System.Drawing.Point(9, 12);
            this.x5.Name = "x5";
            this.x5.Size = new System.Drawing.Size(324, 220);
            this.x5.TabIndex = 0;
            // 
            // dgvAPN
            // 
            this.dgvAPN.AllowUserToAddRows = false;
            this.dgvAPN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Txn,
            this.TxnID,
            this.refNo,
            this.Date,
            this.Amount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAPN.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAPN.Location = new System.Drawing.Point(0, 18);
            this.dgvAPN.MultiSelect = false;
            this.dgvAPN.Name = "dgvAPN";
            this.dgvAPN.ReadOnly = true;
            this.dgvAPN.RowHeadersVisible = false;
            this.dgvAPN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAPN.Size = new System.Drawing.Size(324, 202);
            this.dgvAPN.TabIndex = 0;
            this.dgvAPN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPN_CellDoubleClick);
            this.dgvAPN.MouseLeave += new System.EventHandler(this.dgvAPN_MouseLeave);
            this.dgvAPN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAPN_MouseUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 18);
            this.label3.TabIndex = 567;
            this.label3.Text = "UN-SETTLED CREDITS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPV
            // 
            this.dgvPV.AllowUserToAddRows = false;
            this.dgvPV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TxnPv,
            this.TxnIDPV,
            this.PVDate,
            this.PVAmount});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPV.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPV.Location = new System.Drawing.Point(0, 18);
            this.dgvPV.MultiSelect = false;
            this.dgvPV.Name = "dgvPV";
            this.dgvPV.ReadOnly = true;
            this.dgvPV.RowHeadersVisible = false;
            this.dgvPV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPV.Size = new System.Drawing.Size(323, 202);
            this.dgvPV.TabIndex = 582;
            this.dgvPV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPV_CellDoubleClick);
            this.dgvPV.MouseLeave += new System.EventHandler(this.dgvPV_MouseLeave);
            this.dgvPV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvPV_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 18);
            this.label1.TabIndex = 568;
            this.label1.Text = "UN-SETTLED DEBITS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblCustomerID);
            this.panel1.Controls.Add(this.txtAPNSettlementID);
            this.panel1.Controls.Add(this.txtSupplierID);
            this.panel1.Controls.Add(this.lblCustomerOrderID);
            this.panel1.Controls.Add(this.lblFromDate);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Location = new System.Drawing.Point(668, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 152);
            this.panel1.TabIndex = 576;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(102, 35);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 22);
            this.dtpFromDate.TabIndex = 574;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(9, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 14);
            this.label13.TabIndex = 575;
            this.label13.Text = "Date To";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerID.Location = new System.Drawing.Point(9, 12);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(80, 14);
            this.lblCustomerID.TabIndex = 570;
            this.lblCustomerID.Text = "Supplier Name";
            // 
            // txtAPNSettlementID
            // 
            this.txtAPNSettlementID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAPNSettlementID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPNSettlementID.Location = new System.Drawing.Point(102, 91);
            this.txtAPNSettlementID.Name = "txtAPNSettlementID";
            this.txtAPNSettlementID.Size = new System.Drawing.Size(120, 22);
            this.txtAPNSettlementID.TabIndex = 578;
            this.txtAPNSettlementID.Text = "GN005";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSupplierID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierID.Location = new System.Drawing.Point(102, 9);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(183, 22);
            this.txtSupplierID.TabIndex = 571;
            this.txtSupplierID.DoubleClick += new System.EventHandler(this.txtSupplierID_DoubleClick);
            // 
            // lblCustomerOrderID
            // 
            this.lblCustomerOrderID.AutoSize = true;
            this.lblCustomerOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerOrderID.Location = new System.Drawing.Point(9, 99);
            this.lblCustomerOrderID.Name = "lblCustomerOrderID";
            this.lblCustomerOrderID.Size = new System.Drawing.Size(89, 14);
            this.lblCustomerOrderID.TabIndex = 577;
            this.lblCustomerOrderID.Text = "Settlement Code";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblFromDate.Location = new System.Drawing.Point(9, 41);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(60, 14);
            this.lblFromDate.TabIndex = 573;
            this.lblFromDate.Text = "Date From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(102, 63);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 22);
            this.dtpToDate.TabIndex = 572;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.White;
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label12);
            this.z1.Controls.Add(this.label4);
            this.z1.Controls.Add(this.txtBalance);
            this.z1.Controls.Add(this.label5);
            this.z1.Controls.Add(this.lblPaymentAmount);
            this.z1.Controls.Add(this.zpnlSettledPayment);
            this.z1.Controls.Add(this.lblAPNAmount);
            this.z1.Controls.Add(this.zpnlSelettedAPN);
            this.z1.Controls.Add(this.pgrAPN);
            this.z1.Controls.Add(this.label7);
            this.z1.Controls.Add(this.label9);
            this.z1.Controls.Add(this.pgrPayment);
            this.z1.Location = new System.Drawing.Point(7, 264);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(977, 180);
            this.z1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(884, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 14);
            this.label12.TabIndex = 596;
            this.label12.Text = "Balance Amount";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(355, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(621, 18);
            this.label4.TabIndex = 569;
            this.label4.Text = "PAYMENT SETTLED";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.Control;
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(889, 148);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(77, 22);
            this.txtBalance.TabIndex = 595;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(-1, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 18);
            this.label5.TabIndex = 568;
            this.label5.Text = "APN SETTLED";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaymentAmount.Enabled = false;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.Location = new System.Drawing.Point(88, 149);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(77, 22);
            this.lblPaymentAmount.TabIndex = 594;
            this.lblPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zpnlSettledPayment
            // 
            this.zpnlSettledPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpnlSettledPayment.Location = new System.Drawing.Point(355, 16);
            this.zpnlSettledPayment.Name = "zpnlSettledPayment";
            this.zpnlSettledPayment.Size = new System.Drawing.Size(621, 103);
            this.zpnlSettledPayment.TabIndex = 1;
            this.zpnlSettledPayment.DragDrop += new System.Windows.Forms.DragEventHandler(this.zpnlSettledPayment_DragDrop);
            this.zpnlSettledPayment.DragEnter += new System.Windows.Forms.DragEventHandler(this.zpnlSettledPayment_DragEnter);
            // 
            // lblAPNAmount
            // 
            this.lblAPNAmount.BackColor = System.Drawing.SystemColors.Control;
            this.lblAPNAmount.Enabled = false;
            this.lblAPNAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPNAmount.Location = new System.Drawing.Point(88, 123);
            this.lblAPNAmount.Name = "lblAPNAmount";
            this.lblAPNAmount.Size = new System.Drawing.Size(77, 22);
            this.lblAPNAmount.TabIndex = 591;
            this.lblAPNAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zpnlSelettedAPN
            // 
            this.zpnlSelettedAPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpnlSelettedAPN.Location = new System.Drawing.Point(-1, 16);
            this.zpnlSelettedAPN.Name = "zpnlSelettedAPN";
            this.zpnlSelettedAPN.Size = new System.Drawing.Size(345, 103);
            this.zpnlSelettedAPN.TabIndex = 0;
            this.zpnlSelettedAPN.DragDrop += new System.Windows.Forms.DragEventHandler(this.zpnlSelettedAPN_DragDrop_1);
            this.zpnlSelettedAPN.DragEnter += new System.Windows.Forms.DragEventHandler(this.zpnlSelettedAPN_DragEnter);
            // 
            // pgrAPN
            // 
            this.pgrAPN.Location = new System.Drawing.Point(171, 125);
            this.pgrAPN.Maximum = 0;
            this.pgrAPN.Name = "pgrAPN";
            this.pgrAPN.Size = new System.Drawing.Size(707, 22);
            this.pgrAPN.Step = 1;
            this.pgrAPN.TabIndex = 589;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(7, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 592;
            this.label7.Text = "APN Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(6, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 14);
            this.label9.TabIndex = 593;
            this.label9.Text = "Payment Total";
            // 
            // pgrPayment
            // 
            this.pgrPayment.Location = new System.Drawing.Point(171, 149);
            this.pgrPayment.Maximum = 0;
            this.pgrPayment.Name = "pgrPayment";
            this.pgrPayment.Size = new System.Drawing.Size(707, 22);
            this.pgrPayment.Step = 1;
            this.pgrPayment.TabIndex = 590;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettlementDate,
            this.APNID,
            this.Narration,
            this.DocumentAmount,
            this.DebitAmount,
            this.CreditAmount,
            this.BalanceAmount});
            this.dgvDetail.Location = new System.Drawing.Point(7, 469);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.Size = new System.Drawing.Size(977, 109);
            this.dgvDetail.TabIndex = 2;
            // 
            // SettlementDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SettlementDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.SettlementDate.HeaderText = "APN Date";
            this.SettlementDate.Name = "SettlementDate";
            // 
            // APNID
            // 
            this.APNID.HeaderText = "APN No.";
            this.APNID.Name = "APNID";
            this.APNID.Width = 120;
            // 
            // Narration
            // 
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            this.Narration.Width = 265;
            // 
            // DocumentAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DocumentAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.DocumentAmount.HeaderText = "Document Amount";
            this.DocumentAmount.Name = "DocumentAmount";
            this.DocumentAmount.Width = 120;
            // 
            // DebitAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DebitAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.DebitAmount.HeaderText = "Debit Amount";
            this.DebitAmount.Name = "DebitAmount";
            this.DebitAmount.Width = 120;
            // 
            // CreditAmount
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditAmount.DefaultCellStyle = dataGridViewCellStyle10;
            this.CreditAmount.HeaderText = "Credit Amount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.Width = 120;
            // 
            // BalanceAmount
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BalanceAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.BalanceAmount.HeaderText = "Balance Amount";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Width = 120;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label11.Location = new System.Drawing.Point(7, 452);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(977, 18);
            this.label11.TabIndex = 588;
            this.label11.Text = "DEBTOR SETTLEMENT LEDGER DETAIL - WITH PAYMENT DETAIL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Digiteq.Properties.Resources.download;
            this.pictureBox2.Location = new System.Drawing.Point(555, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 18);
            this.pictureBox2.TabIndex = 591;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label10.Location = new System.Drawing.Point(429, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 14);
            this.label10.TabIndex = 590;
            this.label10.Text = "DRAG AND DROP HERE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Digiteq.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(201, 238);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.TabIndex = 589;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(75, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 14);
            this.label8.TabIndex = 588;
            this.label8.Text = "DRAG AND DROP HERE";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(678, 244);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 592;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(832, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 593;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // x6
            // 
            this.x6.Controls.Add(this.dgvPV);
            this.x6.Controls.Add(this.label1);
            this.x6.Location = new System.Drawing.Point(339, 13);
            this.x6.Name = "x6";
            this.x6.Size = new System.Drawing.Size(323, 220);
            this.x6.TabIndex = 592;
            // 
            // TxnPv
            // 
            this.TxnPv.HeaderText = "Txn";
            this.TxnPv.Name = "TxnPv";
            this.TxnPv.ReadOnly = true;
            this.TxnPv.Width = 50;
            // 
            // TxnIDPV
            // 
            this.TxnIDPV.HeaderText = "Txn ID";
            this.TxnIDPV.Name = "TxnIDPV";
            this.TxnIDPV.ReadOnly = true;
            this.TxnIDPV.Width = 70;
            // 
            // PVDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PVDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.PVDate.HeaderText = "Date";
            this.PVDate.Name = "PVDate";
            this.PVDate.ReadOnly = true;
            this.PVDate.Width = 70;
            // 
            // PVAmount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.PVAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.PVAmount.HeaderText = "Amount";
            this.PVAmount.Name = "PVAmount";
            this.PVAmount.ReadOnly = true;
            this.PVAmount.Width = 80;
            // 
            // Txn
            // 
            this.Txn.HeaderText = "Txn";
            this.Txn.Name = "Txn";
            this.Txn.ReadOnly = true;
            this.Txn.Width = 50;
            // 
            // TxnID
            // 
            this.TxnID.HeaderText = "Txn ID";
            this.TxnID.Name = "TxnID";
            this.TxnID.ReadOnly = true;
            this.TxnID.Width = 80;
            // 
            // refNo
            // 
            this.refNo.HeaderText = "Ref.";
            this.refNo.Name = "refNo";
            this.refNo.ReadOnly = true;
            this.refNo.Width = 50;
            // 
            // Date
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 70;
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 70;
            // 
            // frm_accCreditorSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.x6);
            this.Controls.Add(this.x5);
            this.Location = new System.Drawing.Point(527, 254);
            this.Name = "frm_accCreditorSettlement";
            this.Size = new System.Drawing.Size(991, 631);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accCreditorSettlement_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accCreditorSettlement_SF_saveButton_Click);
            this.Load += new System.EventHandler(this.frm_accDebtorsSettlement_Load);
            this.Controls.SetChildIndex(this.x5, 0);
            this.Controls.SetChildIndex(this.x6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.x5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.x6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel x5;

        private Panel z1;

        private DataGridView dgvDetail;

        private Label label11;

        private Label label3;

        private Label label1;

        private Label lblCustomerID;

        private Label label13;

        private DateTimePicker dtpFromDate;

        private Label lblFromDate;

        private DateTimePicker dtpToDate;

        private TextBox txtSupplierID;

        private PictureBox pictureBox2;

        private Label label10;

        private PictureBox pictureBox1;

        private Label label8;

        private Label label4;

        private Label label5;

        private Label label12;

        private TextBox txtBalance;

        private TextBox lblPaymentAmount;

        private TextBox lblAPNAmount;

        private ProgressBar pgrAPN;

        private Label label7;

        private Label label9;

        private ProgressBar pgrPayment;

        private Panel panel1;

        private TextBox txtAPNSettlementID;

        private Label lblCustomerOrderID;

        private DataGridView dgvAPN;

        private DataGridView dgvPV;
        private Button btnNew;
        private Button btnSave;
        private DataGridViewTextBoxColumn SettlementDate;
        private DataGridViewTextBoxColumn APNID;
        private DataGridViewTextBoxColumn Narration;
        private DataGridViewTextBoxColumn DocumentAmount;
        private DataGridViewTextBoxColumn DebitAmount;
        private DataGridViewTextBoxColumn CreditAmount;
        private DataGridViewTextBoxColumn BalanceAmount;
        private FlowLayoutPanel zpnlSelettedAPN;
        private FlowLayoutPanel zpnlSettledPayment;
        private Panel x6;
        private DataGridViewTextBoxColumn Txn;
        private DataGridViewTextBoxColumn TxnID;
        private DataGridViewTextBoxColumn refNo;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn TxnPv;
        private DataGridViewTextBoxColumn TxnIDPV;
        private DataGridViewTextBoxColumn PVDate;
        private DataGridViewTextBoxColumn PVAmount;

        //        private System.Windows.Forms.Panel x5;
        //        private System.Windows.Forms.Panel z1;
        //        private System.Windows.Forms.DataGridView dgvDetail;
        //        private System.Windows.Forms.Label label11;
        //        private System.Windows.Forms.Label label3;
        //        private System.Windows.Forms.Label label2;
        //        private System.Windows.Forms.Label label1;
        //        private System.Windows.Forms.Label lblCustomerID;
        //        private System.Windows.Forms.Label label13;
        //        private System.Windows.Forms.DateTimePicker dtpFromDate;
        //        private System.Windows.Forms.Label lblFromDate;
        //        private System.Windows.Forms.DateTimePicker dtpToDate;
        //        private System.Windows.Forms.TextBox txtSupplierID;
        //        private System.Windows.Forms.PictureBox pictureBox2;
        //        private System.Windows.Forms.Label label10;
        //        private System.Windows.Forms.PictureBox pictureBox1;
        //        private System.Windows.Forms.Label label8;
        //        private System.Windows.Forms.Button btnPrint;
        //        private System.Windows.Forms.Button btnNew;
        //        private System.Windows.Forms.Button btnDelete;
        //        private System.Windows.Forms.Button btnSave;
        //        private System.Windows.Forms.Panel zpnlSettledPayment;
        //        private System.Windows.Forms.Panel zpnlSelettedAPN;
        //        private System.Windows.Forms.Label label4;
        //        private System.Windows.Forms.Label label5;
        //        private System.Windows.Forms.Label label12;
        //        private System.Windows.Forms.TextBox txtBalance;
        //        private System.Windows.Forms.TextBox lblPaymentAmount;
        //        private System.Windows.Forms.TextBox lblAPNAmount;
        //        private System.Windows.Forms.ProgressBar pgrAPN;
        //        private System.Windows.Forms.Label label7;
        //        private System.Windows.Forms.Label label9;
        //        private System.Windows.Forms.ProgressBar pgrPayment;
        //        private System.Windows.Forms.Panel panel1;
        //        private System.Windows.Forms.DateTimePicker dtpSettlementDate;
        //        private System.Windows.Forms.Label label6;
        //        private System.Windows.Forms.Button btnCustomerViewer;
        //        private System.Windows.Forms.TextBox txtAPNSettlementID;
        //        private System.Windows.Forms.Label lblCustomerOrderID;
        //        private System.Windows.Forms.DataGridView dgvAPN;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn APNNo;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        //        private System.Windows.Forms.DataGridView dgvPV;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn PVNo;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn PVDate;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn PVAmount;
        //        private System.Windows.Forms.DataGridView dgvDbn;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn DbnNo;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn DbnDate;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn DbnAmount;
    }
}