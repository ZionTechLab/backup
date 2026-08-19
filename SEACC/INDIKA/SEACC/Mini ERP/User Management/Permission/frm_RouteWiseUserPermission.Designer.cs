namespace Digiteq.User_Management.Permission
{
    partial class frm_RouteWiseUserPermission
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblNewCustomer = new System.Windows.Forms.Label();
            this.chkEditAll = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkApprovableAll = new System.Windows.Forms.CheckBox();
            this.chkCheckableAll = new System.Windows.Forms.CheckBox();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.chkWriteAll = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.route_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.route_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowWrite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowCheckable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowApprovable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(48, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(159, 22);
            this.txtUserName.TabIndex = 431;
            this.txtUserName.Text = "Asanka Jayasuriya";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(48, 46);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(159, 22);
            this.txtUserID.TabIndex = 429;
            this.txtUserID.Text = "Asanka Jayasuriya";
            this.txtUserID.DoubleClick += new System.EventHandler(this.txtUserID_DoubleClick);
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNewCustomer.Location = new System.Drawing.Point(12, 49);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(30, 14);
            this.lblNewCustomer.TabIndex = 428;
            this.lblNewCustomer.Text = "User";
            // 
            // chkEditAll
            // 
            this.chkEditAll.AutoSize = true;
            this.chkEditAll.Location = new System.Drawing.Point(174, 283);
            this.chkEditAll.Name = "chkEditAll";
            this.chkEditAll.Size = new System.Drawing.Size(39, 17);
            this.chkEditAll.TabIndex = 465;
            this.chkEditAll.Text = "All";
            this.chkEditAll.UseVisualStyleBackColor = true;
            this.chkEditAll.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(225, 44);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(72, 17);
            this.chkAll.TabIndex = 464;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkApprovableAll
            // 
            this.chkApprovableAll.AutoSize = true;
            this.chkApprovableAll.Location = new System.Drawing.Point(103, 329);
            this.chkApprovableAll.Name = "chkApprovableAll";
            this.chkApprovableAll.Size = new System.Drawing.Size(39, 17);
            this.chkApprovableAll.TabIndex = 463;
            this.chkApprovableAll.Text = "All";
            this.chkApprovableAll.UseVisualStyleBackColor = true;
            this.chkApprovableAll.Visible = false;
            // 
            // chkCheckableAll
            // 
            this.chkCheckableAll.AutoSize = true;
            this.chkCheckableAll.Location = new System.Drawing.Point(58, 210);
            this.chkCheckableAll.Name = "chkCheckableAll";
            this.chkCheckableAll.Size = new System.Drawing.Size(39, 17);
            this.chkCheckableAll.TabIndex = 462;
            this.chkCheckableAll.Text = "All";
            this.chkCheckableAll.UseVisualStyleBackColor = true;
            this.chkCheckableAll.Visible = false;
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Location = new System.Drawing.Point(125, 283);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.Size = new System.Drawing.Size(39, 17);
            this.chkDeleteAll.TabIndex = 461;
            this.chkDeleteAll.Text = "All";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            this.chkDeleteAll.Visible = false;
            // 
            // chkWriteAll
            // 
            this.chkWriteAll.AutoSize = true;
            this.chkWriteAll.Location = new System.Drawing.Point(75, 283);
            this.chkWriteAll.Name = "chkWriteAll";
            this.chkWriteAll.Size = new System.Drawing.Size(39, 17);
            this.chkWriteAll.TabIndex = 460;
            this.chkWriteAll.Text = "All";
            this.chkWriteAll.UseVisualStyleBackColor = true;
            this.chkWriteAll.Visible = false;
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Location = new System.Drawing.Point(25, 283);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(39, 17);
            this.chkReadAll.TabIndex = 459;
            this.chkReadAll.Text = "All";
            this.chkReadAll.UseVisualStyleBackColor = true;
            this.chkReadAll.Visible = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.route_ID,
            this.route_Code,
            this.AllowRead,
            this.AllowWrite,
            this.AllowDelete,
            this.AllowUpdate,
            this.AllowCheckable,
            this.AllowApprovable});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(225, 64);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(177, 348);
            this.dgvDetail.TabIndex = 458;
            // 
            // route_ID
            // 
            this.route_ID.DataPropertyName = "route_ID";
            this.route_ID.HeaderText = "route_ID";
            this.route_ID.Name = "route_ID";
            this.route_ID.ReadOnly = true;
            this.route_ID.Visible = false;
            this.route_ID.Width = 65;
            // 
            // route_Code
            // 
            this.route_Code.DataPropertyName = "route_Code";
            this.route_Code.HeaderText = "Route Code";
            this.route_Code.Name = "route_Code";
            this.route_Code.ReadOnly = true;
            // 
            // AllowRead
            // 
            this.AllowRead.DataPropertyName = "AllowRead";
            this.AllowRead.HeaderText = "Read";
            this.AllowRead.Name = "AllowRead";
            this.AllowRead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowRead.Visible = false;
            this.AllowRead.Width = 50;
            // 
            // AllowWrite
            // 
            this.AllowWrite.DataPropertyName = "AllowWrite";
            this.AllowWrite.HeaderText = "Write";
            this.AllowWrite.Name = "AllowWrite";
            this.AllowWrite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowWrite.Width = 50;
            // 
            // AllowDelete
            // 
            this.AllowDelete.DataPropertyName = "AllowDelete";
            this.AllowDelete.HeaderText = "Delete";
            this.AllowDelete.Name = "AllowDelete";
            this.AllowDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowDelete.Visible = false;
            this.AllowDelete.Width = 50;
            // 
            // AllowUpdate
            // 
            this.AllowUpdate.DataPropertyName = "AllowUpdate";
            this.AllowUpdate.HeaderText = "Edit";
            this.AllowUpdate.Name = "AllowUpdate";
            this.AllowUpdate.Visible = false;
            this.AllowUpdate.Width = 50;
            // 
            // AllowCheckable
            // 
            this.AllowCheckable.DataPropertyName = "AllowCheckable";
            this.AllowCheckable.HeaderText = "Checkable";
            this.AllowCheckable.Name = "AllowCheckable";
            this.AllowCheckable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowCheckable.Visible = false;
            this.AllowCheckable.Width = 73;
            // 
            // AllowApprovable
            // 
            this.AllowApprovable.DataPropertyName = "AllowApprovable";
            this.AllowApprovable.HeaderText = "Approvable";
            this.AllowApprovable.Name = "AllowApprovable";
            this.AllowApprovable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowApprovable.Visible = false;
            this.AllowApprovable.Width = 76;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(132, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 466;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(48, 116);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 467;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frm_RouteWiseUserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 440);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.chkEditAll);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkApprovableAll);
            this.Controls.Add(this.chkCheckableAll);
            this.Controls.Add(this.chkDeleteAll);
            this.Controls.Add(this.chkWriteAll);
            this.Controls.Add(this.chkReadAll);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblNewCustomer);
            this.Name = "frm_RouteWiseUserPermission";
            this.Text = "Route Wise User Permission";
            this.Load += new System.EventHandler(this.frm_RouteWiseUserPermission_Load);
            this.Controls.SetChildIndex(this.lblNewCustomer, 0);
            this.Controls.SetChildIndex(this.txtUserID, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.chkReadAll, 0);
            this.Controls.SetChildIndex(this.chkWriteAll, 0);
            this.Controls.SetChildIndex(this.chkDeleteAll, 0);
            this.Controls.SetChildIndex(this.chkCheckableAll, 0);
            this.Controls.SetChildIndex(this.chkApprovableAll, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            this.Controls.SetChildIndex(this.chkEditAll, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.CheckBox chkEditAll;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkApprovableAll;
        private System.Windows.Forms.CheckBox chkCheckableAll;
        private System.Windows.Forms.CheckBox chkDeleteAll;
        private System.Windows.Forms.CheckBox chkWriteAll;
        private System.Windows.Forms.CheckBox chkReadAll;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_Code;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowWrite;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowCheckable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowApprovable;
    }
}