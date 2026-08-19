namespace Digiteq
{
    partial class frmFormListPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.z1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.NoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.z1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.btnPrint);
            this.z1.Controls.Add(this.btnCancel);
            this.z1.Controls.Add(this.label67);
            this.z1.Controls.Add(this.lblOrderRefNo);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(7, 7);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(360, 33);
            this.z1.TabIndex = 402;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.accept;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(222, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 25);
            this.btnPrint.TabIndex = 457;
            this.btnPrint.Text = "   Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(288, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 393;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.Gray;
            this.label67.Location = new System.Drawing.Point(12, 8);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(52, 14);
            this.label67.TabIndex = 374;
            this.label67.Text = "Order No";
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderRefNo.Location = new System.Drawing.Point(69, 4);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(147, 22);
            this.lblOrderRefNo.TabIndex = 373;
            this.lblOrderRefNo.Text = "56";
            this.lblOrderRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoteID,
            this.NoteDate,
            this.NoteAmount,
            this.Select});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 46);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(360, 184);
            this.dgvDetail.TabIndex = 403;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // NoteID
            // 
            this.NoteID.HeaderText = "Note ID";
            this.NoteID.Name = "NoteID";
            // 
            // NoteDate
            // 
            this.NoteDate.HeaderText = "Date";
            this.NoteDate.Name = "NoteDate";
            // 
            // NoteAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NoteAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoteAmount.HeaderText = "Amount";
            this.NoteAmount.Name = "NoteAmount";
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 55;
            // 
            // frmFormListPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(374, 239);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.z1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmFormListPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFormList_Load);
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}