namespace Digiteq
{
    partial class frm_mtrAccountGLNote
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.glNote_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glNoteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoProfitAndLost = new System.Windows.Forms.RadioButton();
            this.rdoBalanceSheet = new System.Windows.Forms.RadioButton();
            this.lblGLNoteID = new System.Windows.Forms.Label();
            this.lblGLNoteName = new System.Windows.Forms.Label();
            this.txtGLNoteName = new System.Windows.Forms.TextBox();
            this.txtGLNoteID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(164, 108);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.glNote_ID,
            this.glNoteName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 139);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 252);
            this.dgvDetail.TabIndex = 4;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // glNote_ID
            // 
            this.glNote_ID.HeaderText = "GL Note ID";
            this.glNote_ID.Name = "glNote_ID";
            this.glNote_ID.Width = 90;
            // 
            // glNoteName
            // 
            this.glNoteName.HeaderText = "GL Note Name";
            this.glNoteName.MinimumWidth = 50;
            this.glNoteName.Name = "glNoteName";
            this.glNoteName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdoProfitAndLost);
            this.panel2.Controls.Add(this.rdoBalanceSheet);
            this.panel2.Controls.Add(this.lblGLNoteID);
            this.panel2.Controls.Add(this.lblGLNoteName);
            this.panel2.Controls.Add(this.txtGLNoteName);
            this.panel2.Controls.Add(this.txtGLNoteID);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 92);
            this.panel2.TabIndex = 0;
            // 
            // rdoProfitAndLost
            // 
            this.rdoProfitAndLost.AutoSize = true;
            this.rdoProfitAndLost.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoProfitAndLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoProfitAndLost.Location = new System.Drawing.Point(154, 62);
            this.rdoProfitAndLost.Name = "rdoProfitAndLost";
            this.rdoProfitAndLost.Size = new System.Drawing.Size(96, 18);
            this.rdoProfitAndLost.TabIndex = 5;
            this.rdoProfitAndLost.TabStop = true;
            this.rdoProfitAndLost.Text = "Profit and Lost";
            this.rdoProfitAndLost.UseVisualStyleBackColor = true;
            // 
            // rdoBalanceSheet
            // 
            this.rdoBalanceSheet.AutoSize = true;
            this.rdoBalanceSheet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoBalanceSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoBalanceSheet.Location = new System.Drawing.Point(51, 62);
            this.rdoBalanceSheet.Name = "rdoBalanceSheet";
            this.rdoBalanceSheet.Size = new System.Drawing.Size(95, 18);
            this.rdoBalanceSheet.TabIndex = 4;
            this.rdoBalanceSheet.TabStop = true;
            this.rdoBalanceSheet.Text = "Balance Sheet";
            this.rdoBalanceSheet.UseVisualStyleBackColor = true;
            // 
            // lblGLNoteID
            // 
            this.lblGLNoteID.AutoSize = true;
            this.lblGLNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGLNoteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGLNoteID.Location = new System.Drawing.Point(10, 11);
            this.lblGLNoteID.Name = "lblGLNoteID";
            this.lblGLNoteID.Size = new System.Drawing.Size(61, 14);
            this.lblGLNoteID.TabIndex = 0;
            this.lblGLNoteID.Text = "GL Note ID";
            // 
            // lblGLNoteName
            // 
            this.lblGLNoteName.AutoSize = true;
            this.lblGLNoteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGLNoteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGLNoteName.Location = new System.Drawing.Point(10, 37);
            this.lblGLNoteName.Name = "lblGLNoteName";
            this.lblGLNoteName.Size = new System.Drawing.Size(80, 14);
            this.lblGLNoteName.TabIndex = 2;
            this.lblGLNoteName.Text = "GL Note Name";
            // 
            // txtGLNoteName
            // 
            this.txtGLNoteName.AcceptsTab = true;
            this.txtGLNoteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLNoteName.Location = new System.Drawing.Point(106, 34);
            this.txtGLNoteName.Name = "txtGLNoteName";
            this.txtGLNoteName.Size = new System.Drawing.Size(199, 22);
            this.txtGLNoteName.TabIndex = 3;
            // 
            // txtGLNoteID
            // 
            this.txtGLNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtGLNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLNoteID.Location = new System.Drawing.Point(106, 8);
            this.txtGLNoteID.Name = "txtGLNoteID";
            this.txtGLNoteID.Size = new System.Drawing.Size(120, 22);
            this.txtGLNoteID.TabIndex = 1;
            this.txtGLNoteID.DoubleClick += new System.EventHandler(this.txtGLNoteID_DoubleClick);
            this.txtGLNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGLNoteID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(87, 108);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(241, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrAccountGLNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(322, 396);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrAccountGLNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GL Note Master";
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_accGLNote_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGLNoteID;
        private System.Windows.Forms.Label lblGLNoteName;
        private System.Windows.Forms.TextBox txtGLNoteName;
        private System.Windows.Forms.TextBox txtGLNoteID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdoProfitAndLost;
        private System.Windows.Forms.RadioButton rdoBalanceSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNote_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNoteName;

    }
}