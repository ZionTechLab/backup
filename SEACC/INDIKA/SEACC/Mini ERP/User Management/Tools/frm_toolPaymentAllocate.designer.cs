namespace Digiteq
{
    partial class frm_toolPaymentAllocate
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
            this.chkActiveAllocationDate = new System.Windows.Forms.CheckBox();
            this.dtpAllocationDate = new System.Windows.Forms.DateTimePicker();
            this.txtAllocationCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rdoOverPayment = new System.Windows.Forms.RadioButton();
            this.rdoPartPayment = new System.Windows.Forms.RadioButton();
            this.rdoAdvancePayment = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAllocate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.x.SuspendLayout();
            this.x1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkActiveAllocationDate
            // 
            this.chkActiveAllocationDate.AutoSize = true;
            this.chkActiveAllocationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkActiveAllocationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chkActiveAllocationDate.Location = new System.Drawing.Point(26, 117);
            this.chkActiveAllocationDate.Name = "chkActiveAllocationDate";
            this.chkActiveAllocationDate.Size = new System.Drawing.Size(136, 18);
            this.chkActiveAllocationDate.TabIndex = 467;
            this.chkActiveAllocationDate.Text = "Active Allocation Date";
            this.chkActiveAllocationDate.UseVisualStyleBackColor = true;
            this.chkActiveAllocationDate.CheckedChanged += new System.EventHandler(this.chkActiveAllocationDate_CheckedChanged);
            // 
            // dtpAllocationDate
            // 
            this.dtpAllocationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtpAllocationDate.Enabled = false;
            this.dtpAllocationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAllocationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAllocationDate.Location = new System.Drawing.Point(168, 112);
            this.dtpAllocationDate.Name = "dtpAllocationDate";
            this.dtpAllocationDate.Size = new System.Drawing.Size(95, 22);
            this.dtpAllocationDate.TabIndex = 466;
            // 
            // txtAllocationCode
            // 
            this.txtAllocationCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAllocationCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocationCode.Location = new System.Drawing.Point(131, 10);
            this.txtAllocationCode.Name = "txtAllocationCode";
            this.txtAllocationCode.Size = new System.Drawing.Size(144, 22);
            this.txtAllocationCode.TabIndex = 465;
            this.txtAllocationCode.Text = "Asanka Jayasuriya";
            this.txtAllocationCode.DoubleClick += new System.EventHandler(this.txtAllocationCode_DoubleClick);
            this.txtAllocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAllocationCode_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Location = new System.Drawing.Point(23, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 14);
            this.label15.TabIndex = 464;
            this.label15.Text = "Allocation Code";
            // 
            // rdoOverPayment
            // 
            this.rdoOverPayment.AutoSize = true;
            this.rdoOverPayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOverPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoOverPayment.Location = new System.Drawing.Point(45, 86);
            this.rdoOverPayment.Name = "rdoOverPayment";
            this.rdoOverPayment.Size = new System.Drawing.Size(96, 18);
            this.rdoOverPayment.TabIndex = 10;
            this.rdoOverPayment.TabStop = true;
            this.rdoOverPayment.Text = "Over Payment";
            this.rdoOverPayment.UseVisualStyleBackColor = true;
            // 
            // rdoPartPayment
            // 
            this.rdoPartPayment.AutoSize = true;
            this.rdoPartPayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPartPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPartPayment.Location = new System.Drawing.Point(45, 62);
            this.rdoPartPayment.Name = "rdoPartPayment";
            this.rdoPartPayment.Size = new System.Drawing.Size(92, 18);
            this.rdoPartPayment.TabIndex = 9;
            this.rdoPartPayment.TabStop = true;
            this.rdoPartPayment.Text = "Part Payment";
            this.rdoPartPayment.UseVisualStyleBackColor = true;
            // 
            // rdoAdvancePayment
            // 
            this.rdoAdvancePayment.AutoSize = true;
            this.rdoAdvancePayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAdvancePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAdvancePayment.Location = new System.Drawing.Point(45, 38);
            this.rdoAdvancePayment.Name = "rdoAdvancePayment";
            this.rdoAdvancePayment.Size = new System.Drawing.Size(114, 18);
            this.rdoAdvancePayment.TabIndex = 8;
            this.rdoAdvancePayment.TabStop = true;
            this.rdoAdvancePayment.Text = "Advance Payment";
            this.rdoAdvancePayment.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(280, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAllocate
            // 
            this.btnAllocate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllocate.Image = global::Digiteq.Properties.Resources.accept;
            this.btnAllocate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllocate.Location = new System.Drawing.Point(210, 195);
            this.btnAllocate.Name = "btnAllocate";
            this.btnAllocate.Size = new System.Drawing.Size(70, 25);
            this.btnAllocate.TabIndex = 6;
            this.btnAllocate.Text = "Save";
            this.btnAllocate.UseVisualStyleBackColor = true;
            this.btnAllocate.Click += new System.EventHandler(this.btnAllocate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(140, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 25);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // x
            // 
            this.x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x.Controls.Add(this.label3);
            this.x.Location = new System.Drawing.Point(7, 7);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(343, 31);
            this.x.TabIndex = 468;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(29, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment Allocation Form";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // x1
            // 
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoAdvancePayment);
            this.x1.Controls.Add(this.chkActiveAllocationDate);
            this.x1.Controls.Add(this.rdoPartPayment);
            this.x1.Controls.Add(this.dtpAllocationDate);
            this.x1.Controls.Add(this.rdoOverPayment);
            this.x1.Controls.Add(this.txtAllocationCode);
            this.x1.Controls.Add(this.label15);
            this.x1.Location = new System.Drawing.Point(7, 44);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(343, 146);
            this.x1.TabIndex = 468;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(68, 195);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 25);
            this.btnPrint.TabIndex = 545;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frm_toolPaymentAllocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(364, 229);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnAllocate);
            this.Controls.Add(this.x);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_toolPaymentAllocate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmQuickLogin_Load);
            this.x.ResumeLayout(false);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAllocate;
        private System.Windows.Forms.RadioButton rdoAdvancePayment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoPartPayment;
        private System.Windows.Forms.RadioButton rdoOverPayment;
        private System.Windows.Forms.TextBox txtAllocationCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkActiveAllocationDate;
        private System.Windows.Forms.DateTimePicker dtpAllocationDate;
        private System.Windows.Forms.Panel x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnPrint;
    }
}