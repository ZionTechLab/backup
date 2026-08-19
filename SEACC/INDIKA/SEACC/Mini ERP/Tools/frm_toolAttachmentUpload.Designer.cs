namespace Digiteq
{
    partial class frm_toolAttachmentUpload
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_toolAttachmentUpload));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvAttachment = new SEACC_DataGrid();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.isNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attachment_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofd_Attachments = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Digiteq.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(1, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(82, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "    Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvAttachment
            // 
            this.dgvAttachment.AllowUserToAddRows = false;
            this.dgvAttachment.AllowUserToDeleteRows = false;
            this.dgvAttachment.AllowUserToResizeColumns = false;
            this.dgvAttachment.AllowUserToResizeRows = false;
            this.dgvAttachment.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttachment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttachment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachment.ColumnHeadersVisible = false;
            this.dgvAttachment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.icon,
            this.isNew,
            this.IsDeleted,
            this.FileName,
            this.FilePath,
            this.Task_ID1,
            this.Attachment_Index});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttachment.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttachment.Location = new System.Drawing.Point(1, 41);
            this.dgvAttachment.MultiSelect = false;
            this.dgvAttachment.Name = "dgvAttachment";
            this.dgvAttachment.ReadOnly = true;
            this.dgvAttachment.RowHeadersVisible = false;
            this.dgvAttachment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvAttachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachment.Size = new System.Drawing.Size(208, 284);
            this.dgvAttachment.TabIndex = 24;
            this.dgvAttachment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachment_CellDoubleClick);
            this.dgvAttachment.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachment_CellMouseDown);
            // 
            // icon
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.icon.DefaultCellStyle = dataGridViewCellStyle1;
            this.icon.HeaderText = "icon";
            this.icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.icon.Name = "icon";
            this.icon.ReadOnly = true;
            this.icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.icon.Width = 20;
            // 
            // isNew
            // 
            this.isNew.DataPropertyName = "isNew";
            this.isNew.HeaderText = "isNew";
            this.isNew.Name = "isNew";
            this.isNew.ReadOnly = true;
            this.isNew.Visible = false;
            // 
            // IsDeleted
            // 
            this.IsDeleted.HeaderText = "IsDeleted";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 340;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // Task_ID1
            // 
            this.Task_ID1.HeaderText = "Task_ID1";
            this.Task_ID1.Name = "Task_ID1";
            this.Task_ID1.ReadOnly = true;
            this.Task_ID1.Visible = false;
            // 
            // Attachment_Index
            // 
            this.Attachment_Index.HeaderText = "Attachment_Index";
            this.Attachment_Index.Name = "Attachment_Index";
            this.Attachment_Index.ReadOnly = true;
            this.Attachment_Index.Visible = false;
            // 
            // ofd_Attachments
            // 
            this.ofd_Attachments.FileName = "openFileDialog1";
            // 
            // frm_toolAttachmentUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(211, 328);
            this.Controls.Add(this.dgvAttachment);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_toolAttachmentUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attachments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_toolAttachmentUpload_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.OpenFileDialog ofd_Attachments;
        public SEACC_DataGrid dgvAttachment;
        private System.Windows.Forms.DataGridViewImageColumn icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn isNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attachment_Index;
    }
}