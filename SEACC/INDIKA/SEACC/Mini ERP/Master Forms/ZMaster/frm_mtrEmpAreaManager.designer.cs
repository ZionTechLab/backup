namespace Digiteq
{
    partial class frm_mtrEmpAreaManager
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
            this.ManagerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAreaManagerName = new System.Windows.Forms.TextBox();
            this.lblAreaManagerID = new System.Windows.Forms.Label();
            this.lblSalesManagerName = new System.Windows.Forms.Label();
            this.txtSalesManagerName = new System.Windows.Forms.TextBox();
            this.txtAreaManagerID = new System.Windows.Forms.TextBox();
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
            this.btnDelete.Location = new System.Drawing.Point(165, 127);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
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
            this.ManagerID,
            this.ManagerName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 158);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 235);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ManagerID
            // 
            this.ManagerID.HeaderText = "Manager ID";
            this.ManagerID.Name = "ManagerID";
            this.ManagerID.Width = 90;
            // 
            // ManagerName
            // 
            this.ManagerName.HeaderText = "Manager Name";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtAreaManagerName);
            this.panel2.Controls.Add(this.lblAreaManagerID);
            this.panel2.Controls.Add(this.lblSalesManagerName);
            this.panel2.Controls.Add(this.txtSalesManagerName);
            this.panel2.Controls.Add(this.txtAreaManagerID);
            this.panel2.Location = new System.Drawing.Point(6, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 89);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "Arear Manager";
            // 
            // txtAreaManagerName
            // 
            this.txtAreaManagerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManagerName.Location = new System.Drawing.Point(100, 59);
            this.txtAreaManagerName.Name = "txtAreaManagerName";
            this.txtAreaManagerName.Size = new System.Drawing.Size(199, 22);
            this.txtAreaManagerName.TabIndex = 105;
            this.txtAreaManagerName.Text = "Plastic Bag";
            // 
            // lblAreaManagerID
            // 
            this.lblAreaManagerID.AutoSize = true;
            this.lblAreaManagerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaManagerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAreaManagerID.Location = new System.Drawing.Point(4, 10);
            this.lblAreaManagerID.Name = "lblAreaManagerID";
            this.lblAreaManagerID.Size = new System.Drawing.Size(89, 14);
            this.lblAreaManagerID.TabIndex = 72;
            this.lblAreaManagerID.Text = "Area Manager Id";
            // 
            // lblSalesManagerName
            // 
            this.lblSalesManagerName.AutoSize = true;
            this.lblSalesManagerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesManagerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalesManagerName.Location = new System.Drawing.Point(4, 35);
            this.lblSalesManagerName.Name = "lblSalesManagerName";
            this.lblSalesManagerName.Size = new System.Drawing.Size(80, 14);
            this.lblSalesManagerName.TabIndex = 104;
            this.lblSalesManagerName.Text = "Sales Manager";
            // 
            // txtSalesManagerName
            // 
            this.txtSalesManagerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSalesManagerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesManagerName.Location = new System.Drawing.Point(100, 32);
            this.txtSalesManagerName.Name = "txtSalesManagerName";
            this.txtSalesManagerName.ReadOnly = true;
            this.txtSalesManagerName.Size = new System.Drawing.Size(199, 22);
            this.txtSalesManagerName.TabIndex = 1;
            this.txtSalesManagerName.Text = "Plastic Bag";
            this.txtSalesManagerName.DoubleClick += new System.EventHandler(this.txtBankName_DoubleClick);
            this.txtSalesManagerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankName_KeyDown);
            // 
            // txtAreaManagerID
            // 
            this.txtAreaManagerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAreaManagerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManagerID.Location = new System.Drawing.Point(100, 7);
            this.txtAreaManagerID.Name = "txtAreaManagerID";
            this.txtAreaManagerID.Size = new System.Drawing.Size(120, 22);
            this.txtAreaManagerID.TabIndex = 0;
            this.txtAreaManagerID.DoubleClick += new System.EventHandler(this.txtBranchID_DoubleClick);
            this.txtAreaManagerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(88, 127);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(242, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrEmpAreaManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(323, 400);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrEmpAreaManager";
            this.Text = "Arear Managers";
            this.Load += new System.EventHandler(this.frm_mtrBranch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrBranch_KeyDown);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAreaManagerName;
        private System.Windows.Forms.Label lblAreaManagerID;
        private System.Windows.Forms.Label lblSalesManagerName;
        private System.Windows.Forms.TextBox txtSalesManagerName;
        private System.Windows.Forms.TextBox txtAreaManagerID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;

    }
}