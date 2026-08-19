namespace Digiteq
{
    partial class frm_CreditNoteTypeMaster
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCreditNoteTypeCode = new System.Windows.Forms.Label();
            this.lblCreditNoteTypeName = new System.Windows.Forms.Label();
            this.txtCreditNoteTypeName = new System.Windows.Forms.TextBox();
            this.txtCreditNoteTypeCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.CreditNoteTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditNoteTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCreditNoteTypeCode);
            this.panel2.Controls.Add(this.lblCreditNoteTypeName);
            this.panel2.Controls.Add(this.txtCreditNoteTypeName);
            this.panel2.Controls.Add(this.txtCreditNoteTypeCode);
            this.panel2.Location = new System.Drawing.Point(8, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 61);
            this.panel2.TabIndex = 28;
            // 
            // lblCreditNoteTypeCode
            // 
            this.lblCreditNoteTypeCode.AutoSize = true;
            this.lblCreditNoteTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteTypeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCreditNoteTypeCode.Location = new System.Drawing.Point(7, 10);
            this.lblCreditNoteTypeCode.Name = "lblCreditNoteTypeCode";
            this.lblCreditNoteTypeCode.Size = new System.Drawing.Size(74, 14);
            this.lblCreditNoteTypeCode.TabIndex = 72;
            this.lblCreditNoteTypeCode.Text = "CR Type Code";
            // 
            // lblCreditNoteTypeName
            // 
            this.lblCreditNoteTypeName.AutoSize = true;
            this.lblCreditNoteTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteTypeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCreditNoteTypeName.Location = new System.Drawing.Point(7, 37);
            this.lblCreditNoteTypeName.Name = "lblCreditNoteTypeName";
            this.lblCreditNoteTypeName.Size = new System.Drawing.Size(80, 14);
            this.lblCreditNoteTypeName.TabIndex = 104;
            this.lblCreditNoteTypeName.Text = "CR Type Name";
            // 
            // txtCreditNoteTypeName
            // 
            this.txtCreditNoteTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteTypeName.Location = new System.Drawing.Point(88, 34);
            this.txtCreditNoteTypeName.Name = "txtCreditNoteTypeName";
            this.txtCreditNoteTypeName.Size = new System.Drawing.Size(235, 22);
            this.txtCreditNoteTypeName.TabIndex = 1;
            // 
            // txtCreditNoteTypeCode
            // 
            this.txtCreditNoteTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCreditNoteTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteTypeCode.Location = new System.Drawing.Point(88, 6);
            this.txtCreditNoteTypeCode.Name = "txtCreditNoteTypeCode";
            this.txtCreditNoteTypeCode.Size = new System.Drawing.Size(102, 22);
            this.txtCreditNoteTypeCode.TabIndex = 0;
            this.txtCreditNoteTypeCode.DoubleClick += new System.EventHandler(this.txtCreditNoteTypeCode_DoubleClick);
            this.txtCreditNoteTypeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteTypeCode_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(109, 106);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 34;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(186, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(263, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 33;
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
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditNoteTypeCode,
            this.CreditNoteTypeName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 137);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(329, 173);
            this.dgvDetail.TabIndex = 36;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // CreditNoteTypeCode
            // 
            this.CreditNoteTypeCode.FillWeight = 200F;
            this.CreditNoteTypeCode.Frozen = true;
            this.CreditNoteTypeCode.HeaderText = "Credit Note Type Code";
            this.CreditNoteTypeCode.Name = "CreditNoteTypeCode";
            this.CreditNoteTypeCode.Width = 120;
            // 
            // CreditNoteTypeName
            // 
            this.CreditNoteTypeName.FillWeight = 200F;
            this.CreditNoteTypeName.HeaderText = "Credit Note Type Name";
            this.CreditNoteTypeName.Name = "CreditNoteTypeName";
            this.CreditNoteTypeName.Width = 210;
            // 
            // frm_CreditNoteTypeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(348, 318);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_CreditNoteTypeMaster";
            this.Text = "Credit Note Type Master";
            this.Load += new System.EventHandler(this.frm_CreditNoteTypeMaster_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCreditNoteTypeCode;
        private System.Windows.Forms.Label lblCreditNoteTypeName;
        private System.Windows.Forms.TextBox txtCreditNoteTypeName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNoteTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNoteTypeName;
        private System.Windows.Forms.TextBox txtCreditNoteTypeCode;
    }
}