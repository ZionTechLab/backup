namespace Digiteq
{
    partial class frm_sasDeliveryOrderManuslSettle
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
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoCode = new System.Windows.Forms.TextBox();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.DOCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtDoCode);
            this.zpanel4.Controls.Add(this.lblJobNo);
            this.zpanel4.Controls.Add(this.txtJobNo);
            this.zpanel4.Location = new System.Drawing.Point(8, 8);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(249, 65);
            this.zpanel4.TabIndex = 466;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 456;
            this.label2.Text = "D/O Code";
            // 
            // txtDoCode
            // 
            this.txtDoCode.BackColor = System.Drawing.Color.LightGray;
            this.txtDoCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoCode.Location = new System.Drawing.Point(77, 34);
            this.txtDoCode.Name = "txtDoCode";
            this.txtDoCode.Size = new System.Drawing.Size(120, 23);
            this.txtDoCode.TabIndex = 457;
            this.txtDoCode.DoubleClick += new System.EventHandler(this.txtDoCode_DoubleClick);
            this.txtDoCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoCode_KeyDown);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJobNo.Location = new System.Drawing.Point(10, 9);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(44, 15);
            this.lblJobNo.TabIndex = 454;
            this.lblJobNo.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.BackColor = System.Drawing.Color.LightGray;
            this.txtJobNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNo.Location = new System.Drawing.Point(77, 7);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(120, 23);
            this.txtJobNo.TabIndex = 455;
            this.txtJobNo.DoubleClick += new System.EventHandler(this.txtJobNo_DoubleClick);
            this.txtJobNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNo_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(103, 77);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 474;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(181, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 473;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOCode,
            this.DODate,
            this.Settle});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 108);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(248, 175);
            this.dgvDetail.TabIndex = 476;
            // 
            // DOCode
            // 
            this.DOCode.HeaderText = "D/O Code";
            this.DOCode.Name = "DOCode";
            this.DOCode.ReadOnly = true;
            // 
            // DODate
            // 
            this.DODate.HeaderText = "D/O Date";
            this.DODate.Name = "DODate";
            this.DODate.ReadOnly = true;
            // 
            // Settle
            // 
            this.Settle.HeaderText = "Settle";
            this.Settle.Name = "Settle";
            this.Settle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Settle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Settle.Width = 50;
            // 
            // frm_sasDeliveryOrderManuslSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(266, 291);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.zpanel4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasDeliveryOrderManuslSettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D/O Manual Settle";
            this.Load += new System.EventHandler(this.frm_sasDeliveryOrderManuslSettle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasDeliveryOrderManuslSettle_KeyDown);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoCode;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DODate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Settle;
    }
}