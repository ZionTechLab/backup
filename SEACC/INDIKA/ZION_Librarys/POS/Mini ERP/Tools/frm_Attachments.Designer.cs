namespace Digiteq
{
    partial class frm_Attachments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Attachments));
            this.dgv_Upload = new System.Windows.Forms.DataGridView();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attachment_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.ucTittleBar1 = new Digiteq.ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Upload)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Upload
            // 
            this.dgv_Upload.AllowUserToAddRows = false;
            this.dgv_Upload.AllowUserToDeleteRows = false;
            this.dgv_Upload.AllowUserToResizeColumns = false;
            this.dgv_Upload.AllowUserToResizeRows = false;
            this.dgv_Upload.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Upload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Upload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Upload.ColumnHeadersVisible = false;
            this.dgv_Upload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.icon,
            this.FileName,
            this.FilePath,
            this.Task_ID,
            this.Attachment_ID,
            this.isNew,
            this.IsDeleted});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Upload.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Upload.Location = new System.Drawing.Point(11, 42);
            this.dgv_Upload.MultiSelect = false;
            this.dgv_Upload.Name = "dgv_Upload";
            this.dgv_Upload.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Upload.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Upload.RowHeadersVisible = false;
            this.dgv_Upload.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Upload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Upload.Size = new System.Drawing.Size(240, 273);
            this.dgv_Upload.TabIndex = 25;
            this.dgv_Upload.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Upload_MouseDoubleClick);
            // 
            // icon
            // 
            this.icon.DataPropertyName = "icon";
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
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 210;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // Task_ID
            // 
            this.Task_ID.DataPropertyName = "Task_ID";
            this.Task_ID.HeaderText = "Task_ID1";
            this.Task_ID.Name = "Task_ID";
            this.Task_ID.ReadOnly = true;
            this.Task_ID.Visible = false;
            // 
            // Attachment_ID
            // 
            this.Attachment_ID.DataPropertyName = "Attachment_ID";
            this.Attachment_ID.HeaderText = "Attachment_Index";
            this.Attachment_ID.Name = "Attachment_ID";
            this.Attachment_ID.ReadOnly = true;
            this.Attachment_ID.Visible = false;
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
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(220, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 30);
            this.btnRemove.TabIndex = 473;
            this.btnRemove.Text = "";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnUpload.Location = new System.Drawing.Point(184, 6);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(30, 30);
            this.btnUpload.TabIndex = 474;
            this.btnUpload.Text = "";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 475;
            this.label1.Text = "Upload Attachments";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.dgv_Upload);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.btnRemove);
            this.pnlBody.Controls.Add(this.btnUpload);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(1, 35);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(260, 325);
            this.pnlBody.TabIndex = 476;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.LightSlateGray;
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "Attachments";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(1, 1);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(260, 34);
            this.ucTittleBar1.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(225, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(35, 34);
            this.btn_Close.TabIndex = 472;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_Attachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(262, 361);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.ucTittleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Attachments";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Attachments";
//            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Attachments_FormClosing);
//            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Attachments_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Upload)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
        public System.Windows.Forms.DataGridView dgv_Upload;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridViewImageColumn icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attachment_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn isNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeleted;
    }
}