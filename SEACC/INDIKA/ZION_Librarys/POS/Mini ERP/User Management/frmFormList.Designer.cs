namespace Digiteq
{
    partial class frmFormList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.NoteID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dd
            // 
            this.dd.BackColor = System.Drawing.Color.DarkGray;
            this.dd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dd.Controls.Add(this.panel1);
            this.dd.Controls.Add(this.label67);
            this.dd.Controls.Add(this.lblOrderRefNo);
            this.dd.Dock = System.Windows.Forms.DockStyle.Top;
            this.dd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dd.Location = new System.Drawing.Point(5, 5);
            this.dd.Name = "dd";
            this.dd.Size = new System.Drawing.Size(363, 33);
            this.dd.TabIndex = 402;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(298, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(63, 31);
            this.panel1.TabIndex = 458;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(3, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(25, 25);
            this.btnSelect.TabIndex = 457;
            this.btnSelect.Text = "   Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(34, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(25, 25);
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
            this.label67.Location = new System.Drawing.Point(3, 8);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(52, 14);
            this.label67.TabIndex = 374;
            this.label67.Text = "Order No";
            this.label67.Visible = false;
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderRefNo.Location = new System.Drawing.Point(61, 6);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(153, 22);
            this.lblOrderRefNo.TabIndex = 373;
            this.lblOrderRefNo.Text = "56";
            this.lblOrderRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOrderRefNo.Visible = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoteID2,
            this.NoteID,
            this.NoteDate,
            this.NoteAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 41);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(363, 184);
            this.dgvDetail.TabIndex = 403;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // NoteID2
            // 
            this.NoteID2.HeaderText = "NoteID2";
            this.NoteID2.Name = "NoteID2";
            this.NoteID2.Width = 90;
            // 
            // NoteID
            // 
            this.NoteID.HeaderText = "Note ID";
            this.NoteID.Name = "NoteID";
            this.NoteID.Width = 90;
            // 
            // NoteDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NoteDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoteDate.HeaderText = "Date";
            this.NoteDate.Name = "NoteDate";
            this.NoteDate.Width = 90;
            // 
            // NoteAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NoteAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.NoteAmount.HeaderText = "Amount";
            this.NoteAmount.Name = "NoteAmount";
            this.NoteAmount.Width = 90;
            // 
            // frmFormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(373, 230);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.dd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmFormList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFormList_Load);
            this.dd.ResumeLayout(false);
            this.dd.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteAmount;
    }
}