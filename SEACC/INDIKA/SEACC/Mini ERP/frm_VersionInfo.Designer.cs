namespace Digiteq
{
    partial class frm_VersionInfo
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
            this.seacC_DataGrid1 = new Digiteq.SEACC_DataGrid();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.seacC_DataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // seacC_DataGrid1
            // 
            this.seacC_DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seacC_DataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.DBVersion,
            this.FileVersion});
            this.seacC_DataGrid1.Location = new System.Drawing.Point(12, 12);
            this.seacC_DataGrid1.Name = "seacC_DataGrid1";
            this.seacC_DataGrid1.RowHeadersVisible = false;
            this.seacC_DataGrid1.Size = new System.Drawing.Size(304, 188);
            this.seacC_DataGrid1.TabIndex = 0;
            // 
            // Component
            // 
            this.Component.DataPropertyName = "Component";
            this.Component.HeaderText = "Component";
            this.Component.Name = "Component";
            // 
            // DBVersion
            // 
            this.DBVersion.DataPropertyName = "DB Version";
            this.DBVersion.HeaderText = "DB Version";
            this.DBVersion.Name = "DBVersion";
            // 
            // FileVersion
            // 
            this.FileVersion.DataPropertyName = "File Version";
            this.FileVersion.HeaderText = "File Version";
            this.FileVersion.Name = "FileVersion";
            // 
            // frm_VersionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 210);
            this.Controls.Add(this.seacC_DataGrid1);
            this.Name = "frm_VersionInfo";
            this.Text = "frm_VersionInfo";
            ((System.ComponentModel.ISupportInitialize)(this.seacC_DataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid seacC_DataGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileVersion;
    }
}