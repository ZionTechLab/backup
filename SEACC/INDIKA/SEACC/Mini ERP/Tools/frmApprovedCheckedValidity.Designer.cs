namespace Digiteq
{
    partial class frmApprovedCheckedValidity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUserDetails = new SEACC_DataGrid();
            this.usertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserDetails
            // 
            this.dgvUserDetails.AllowUserToAddRows = false;
            this.dgvUserDetails.AllowUserToDeleteRows = false;
            this.dgvUserDetails.AllowUserToResizeColumns = false;
            this.dgvUserDetails.AllowUserToResizeRows = false;
            this.dgvUserDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUserDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUserDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserDetails.ColumnHeadersVisible = false;
            this.dgvUserDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usertype,
            this.Column1,
            this.user,
            this.Column2,
            this.datetime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserDetails.GridColor = System.Drawing.Color.White;
            this.dgvUserDetails.Location = new System.Drawing.Point(5, 5);
            this.dgvUserDetails.Name = "dgvUserDetails";
            this.dgvUserDetails.ReadOnly = true;
            this.dgvUserDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserDetails.RowHeadersVisible = false;
            this.dgvUserDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserDetails.Size = new System.Drawing.Size(350, 122);
            this.dgvUserDetails.TabIndex = 489;
            // 
            // usertype
            // 
            this.usertype.DataPropertyName = "usertype";
            this.usertype.HeaderText = "User Type";
            this.usertype.Name = "usertype";
            this.usertype.ReadOnly = true;
            this.usertype.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Column1";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 10;
            // 
            // user
            // 
            this.user.DataPropertyName = "user";
            this.user.HeaderText = "User";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Column2";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 10;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "datetime";
            this.datetime.HeaderText = "Date & Time";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.Width = 120;
            // 
            // frmApprovedCheckedValidity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(360, 132);
            this.Controls.Add(this.dgvUserDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmApprovedCheckedValidity";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "User Details";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.frmApprovedCheckedValidity_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn usertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        public SEACC_DataGrid dgvUserDetails;
    }
}