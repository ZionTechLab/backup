namespace Digiteq
{
    partial class frmDebitNoteTypeMaster
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.DebitNoteTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitNoteTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDebitNoteTypeCode = new System.Windows.Forms.Label();
            this.lblDebitNoteTypeName = new System.Windows.Forms.Label();
            this.txtDebitNoteTypeName = new System.Windows.Forms.TextBox();
            this.txtCreditNoteTypeName = new System.Windows.Forms.TextBox();
            this.txtDebitNoteTypeCode = new System.Windows.Forms.TextBox();
            this.txtCreditNoteTypeCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DebitNoteTypeCode,
            this.DebitNoteTypeName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 144);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(329, 173);
            this.dgvDetail.TabIndex = 40;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // DebitNoteTypeCode
            // 
            this.DebitNoteTypeCode.FillWeight = 200F;
            this.DebitNoteTypeCode.Frozen = true;
            this.DebitNoteTypeCode.HeaderText = "Debit Note Type Code";
            this.DebitNoteTypeCode.Name = "DebitNoteTypeCode";
            this.DebitNoteTypeCode.Width = 120;
            // 
            // DebitNoteTypeName
            // 
            this.DebitNoteTypeName.FillWeight = 200F;
            this.DebitNoteTypeName.HeaderText = "Debit Note Type Name";
            this.DebitNoteTypeName.Name = "DebitNoteTypeName";
            this.DebitNoteTypeName.Width = 210;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblDebitNoteTypeCode);
            this.panel2.Controls.Add(this.lblDebitNoteTypeName);
            this.panel2.Controls.Add(this.txtDebitNoteTypeName);
            this.panel2.Controls.Add(this.txtCreditNoteTypeName);
            this.panel2.Controls.Add(this.txtDebitNoteTypeCode);
            this.panel2.Controls.Add(this.txtCreditNoteTypeCode);
            this.panel2.Location = new System.Drawing.Point(8, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 61);
            this.panel2.TabIndex = 37;
            // 
            // lblDebitNoteTypeCode
            // 
            this.lblDebitNoteTypeCode.AutoSize = true;
            this.lblDebitNoteTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteTypeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDebitNoteTypeCode.Location = new System.Drawing.Point(7, 10);
            this.lblDebitNoteTypeCode.Name = "lblDebitNoteTypeCode";
            this.lblDebitNoteTypeCode.Size = new System.Drawing.Size(76, 14);
            this.lblDebitNoteTypeCode.TabIndex = 72;
            this.lblDebitNoteTypeCode.Text = "DR Type Code";
            // 
            // lblDebitNoteTypeName
            // 
            this.lblDebitNoteTypeName.AutoSize = true;
            this.lblDebitNoteTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteTypeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDebitNoteTypeName.Location = new System.Drawing.Point(7, 37);
            this.lblDebitNoteTypeName.Name = "lblDebitNoteTypeName";
            this.lblDebitNoteTypeName.Size = new System.Drawing.Size(82, 14);
            this.lblDebitNoteTypeName.TabIndex = 104;
            this.lblDebitNoteTypeName.Text = "DR Type Name";
            // 
            // txtDebitNoteTypeName
            // 
            this.txtDebitNoteTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteTypeName.Location = new System.Drawing.Point(89, 34);
            this.txtDebitNoteTypeName.Name = "txtDebitNoteTypeName";
            this.txtDebitNoteTypeName.Size = new System.Drawing.Size(235, 22);
            this.txtDebitNoteTypeName.TabIndex = 1;
            // 
            // txtCreditNoteTypeName
            // 
            this.txtCreditNoteTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteTypeName.Location = new System.Drawing.Point(95, 34);
            this.txtCreditNoteTypeName.Name = "txtCreditNoteTypeName";
            this.txtCreditNoteTypeName.Size = new System.Drawing.Size(182, 22);
            this.txtCreditNoteTypeName.TabIndex = 1;
            // 
            // txtDebitNoteTypeCode
            // 
            this.txtDebitNoteTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDebitNoteTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteTypeCode.Location = new System.Drawing.Point(89, 7);
            this.txtDebitNoteTypeCode.Name = "txtDebitNoteTypeCode";
            this.txtDebitNoteTypeCode.Size = new System.Drawing.Size(102, 22);
            this.txtDebitNoteTypeCode.TabIndex = 0;
            this.txtDebitNoteTypeCode.DoubleClick += new System.EventHandler(this.txtDebitNoteTypeCode_DoubleClick);
            this.txtDebitNoteTypeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDebitNoteTypeCode_KeyDown);
            // 
            // txtCreditNoteTypeCode
            // 
            this.txtCreditNoteTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCreditNoteTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteTypeCode.Location = new System.Drawing.Point(95, 7);
            this.txtCreditNoteTypeCode.Name = "txtCreditNoteTypeCode";
            this.txtCreditNoteTypeCode.Size = new System.Drawing.Size(96, 22);
            this.txtCreditNoteTypeCode.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(109, 113);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 42;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(186, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(263, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDebitNoteTypeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(347, 325);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDebitNoteTypeMaster";
            this.Text = "Debit Note Type Master";
            this.Load += new System.EventHandler(this.frmDebitNoteTypeMaster_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDebitNoteTypeCode;
        private System.Windows.Forms.Label lblDebitNoteTypeName;
        private System.Windows.Forms.TextBox txtDebitNoteTypeName;
        private System.Windows.Forms.TextBox txtCreditNoteTypeName;
        private System.Windows.Forms.TextBox txtDebitNoteTypeCode;
        private System.Windows.Forms.TextBox txtCreditNoteTypeCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitNoteTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitNoteTypeName;
    }
}