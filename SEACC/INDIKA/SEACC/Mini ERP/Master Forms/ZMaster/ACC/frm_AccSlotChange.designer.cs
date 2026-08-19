namespace Digiteq
{
    partial class frm_AccSlotChange
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
            this.dgvDetail = new SEACC_DataGrid();
            this.SlotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsDelete = new System.Windows.Forms.CheckBox();
            this.txtSlotName = new System.Windows.Forms.TextBox();
            this.lblIsDelete = new System.Windows.Forms.Label();
            this.txtSlotID = new System.Windows.Forms.TextBox();
            this.lblSlotID = new System.Windows.Forms.Label();
            this.lblSlotName = new System.Windows.Forms.Label();
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
            this.btnDelete.Location = new System.Drawing.Point(250, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlotID,
            this.SlotName,
            this.IsDelete});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 129);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(479, 236);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // SlotID
            // 
            this.SlotID.HeaderText = "Slot No";
            this.SlotID.Name = "SlotID";
            this.SlotID.ReadOnly = true;
            this.SlotID.Width = 60;
            // 
            // SlotName
            // 
            this.SlotName.HeaderText = "Slot Name";
            this.SlotName.Name = "SlotName";
            this.SlotName.ReadOnly = true;
            this.SlotName.Width = 350;
            // 
            // IsDelete
            // 
            this.IsDelete.HeaderText = "Hide";
            this.IsDelete.Name = "IsDelete";
            this.IsDelete.ReadOnly = true;
            this.IsDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsDelete.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkIsDelete);
            this.panel2.Controls.Add(this.txtSlotName);
            this.panel2.Controls.Add(this.lblIsDelete);
            this.panel2.Controls.Add(this.txtSlotID);
            this.panel2.Controls.Add(this.lblSlotID);
            this.panel2.Controls.Add(this.lblSlotName);
            this.panel2.Location = new System.Drawing.Point(8, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 61);
            this.panel2.TabIndex = 7;
            // 
            // chkIsDelete
            // 
            this.chkIsDelete.AutoSize = true;
            this.chkIsDelete.Location = new System.Drawing.Point(459, 3);
            this.chkIsDelete.Name = "chkIsDelete";
            this.chkIsDelete.Size = new System.Drawing.Size(15, 14);
            this.chkIsDelete.TabIndex = 111;
            this.chkIsDelete.UseVisualStyleBackColor = true;
            // 
            // txtSlotName
            // 
            this.txtSlotName.BackColor = System.Drawing.Color.White;
            this.txtSlotName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlotName.Location = new System.Drawing.Point(80, 33);
            this.txtSlotName.Name = "txtSlotName";
            this.txtSlotName.ReadOnly = true;
            this.txtSlotName.Size = new System.Drawing.Size(394, 22);
            this.txtSlotName.TabIndex = 110;
            // 
            // lblIsDelete
            // 
            this.lblIsDelete.AutoSize = true;
            this.lblIsDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblIsDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblIsDelete.Location = new System.Drawing.Point(419, 3);
            this.lblIsDelete.Name = "lblIsDelete";
            this.lblIsDelete.Size = new System.Drawing.Size(30, 14);
            this.lblIsDelete.TabIndex = 109;
            this.lblIsDelete.Text = "Hide";
            // 
            // txtSlotID
            // 
            this.txtSlotID.BackColor = System.Drawing.Color.White;
            this.txtSlotID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlotID.Location = new System.Drawing.Point(80, 6);
            this.txtSlotID.Name = "txtSlotID";
            this.txtSlotID.ReadOnly = true;
            this.txtSlotID.Size = new System.Drawing.Size(236, 22);
            this.txtSlotID.TabIndex = 107;
            // 
            // lblSlotID
            // 
            this.lblSlotID.AutoSize = true;
            this.lblSlotID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSlotID.Location = new System.Drawing.Point(4, 9);
            this.lblSlotID.Name = "lblSlotID";
            this.lblSlotID.Size = new System.Drawing.Size(43, 14);
            this.lblSlotID.TabIndex = 72;
            this.lblSlotID.Text = "Slot No";
            this.lblSlotID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlotName
            // 
            this.lblSlotName.AutoSize = true;
            this.lblSlotName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSlotName.Location = new System.Drawing.Point(4, 36);
            this.lblSlotName.Name = "lblSlotName";
            this.lblSlotName.Size = new System.Drawing.Size(59, 14);
            this.lblSlotName.TabIndex = 104;
            this.lblSlotName.Text = "Slot Name";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(331, 100);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(412, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_AccSlotChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(497, 372);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.Name = "frm_AccSlotChange";
            this.Text = "Acc Slot  Master";
            this.Load += new System.EventHandler(this.frm_AccFormula_Load);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSlotID;
        private System.Windows.Forms.Label lblSlotName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSlotID;
        private System.Windows.Forms.Label lblIsDelete;
        private System.Windows.Forms.CheckBox chkIsDelete;
        private System.Windows.Forms.TextBox txtSlotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDelete;

    }
}