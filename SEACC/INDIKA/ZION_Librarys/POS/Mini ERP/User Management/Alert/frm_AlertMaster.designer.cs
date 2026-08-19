namespace Digiteq
{
    partial class frm_AlertMaster
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAlertID = new System.Windows.Forms.Label();
            this.lblFormCatagory = new System.Windows.Forms.Label();
            this.LblAlertname = new System.Windows.Forms.Label();
            this.txtFormCatagory = new System.Windows.Forms.TextBox();
            this.txtAlertName = new System.Windows.Forms.TextBox();
            this.txtAlertID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.DGAlert = new System.Windows.Forms.DataGridView();
            this.AlertId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alertname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblAlertID);
            this.panel2.Controls.Add(this.lblFormCatagory);
            this.panel2.Controls.Add(this.LblAlertname);
            this.panel2.Controls.Add(this.txtFormCatagory);
            this.panel2.Controls.Add(this.txtAlertName);
            this.panel2.Controls.Add(this.txtAlertID);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 93);
            this.panel2.TabIndex = 1;
            // 
            // lblAlertID
            // 
            this.lblAlertID.AutoSize = true;
            this.lblAlertID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAlertID.Location = new System.Drawing.Point(7, 13);
            this.lblAlertID.Name = "lblAlertID";
            this.lblAlertID.Size = new System.Drawing.Size(43, 14);
            this.lblAlertID.TabIndex = 0;
            this.lblAlertID.Text = "Alert Id";
            // 
            // lblFormCatagory
            // 
            this.lblFormCatagory.AutoSize = true;
            this.lblFormCatagory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormCatagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFormCatagory.Location = new System.Drawing.Point(7, 64);
            this.lblFormCatagory.Name = "lblFormCatagory";
            this.lblFormCatagory.Size = new System.Drawing.Size(80, 14);
            this.lblFormCatagory.TabIndex = 2;
            this.lblFormCatagory.Text = "Form Catagory";
            // 
            // LblAlertname
            // 
            this.LblAlertname.AutoSize = true;
            this.LblAlertname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlertname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LblAlertname.Location = new System.Drawing.Point(7, 39);
            this.LblAlertname.Name = "LblAlertname";
            this.LblAlertname.Size = new System.Drawing.Size(64, 14);
            this.LblAlertname.TabIndex = 2;
            this.LblAlertname.Text = "Alert Name";
            // 
            // txtFormCatagory
            // 
            this.txtFormCatagory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormCatagory.Location = new System.Drawing.Point(97, 61);
            this.txtFormCatagory.Name = "txtFormCatagory";
            this.txtFormCatagory.Size = new System.Drawing.Size(199, 22);
            this.txtFormCatagory.TabIndex = 3;
            // 
            // txtAlertName
            // 
            this.txtAlertName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlertName.Location = new System.Drawing.Point(97, 36);
            this.txtAlertName.Name = "txtAlertName";
            this.txtAlertName.Size = new System.Drawing.Size(199, 22);
            this.txtAlertName.TabIndex = 3;
            // 
            // txtAlertID
            // 
            this.txtAlertID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAlertID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlertID.Location = new System.Drawing.Point(97, 10);
            this.txtAlertID.Name = "txtAlertID";
            this.txtAlertID.Size = new System.Drawing.Size(120, 22);
            this.txtAlertID.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(238, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DGAlert
            // 
            this.DGAlert.AllowUserToAddRows = false;
            this.DGAlert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGAlert.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGAlert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlertId,
            this.Alertname});
            this.DGAlert.EnableHeadersVisualStyles = false;
            this.DGAlert.Location = new System.Drawing.Point(8, 138);
            this.DGAlert.MultiSelect = false;
            this.DGAlert.Name = "DGAlert";
            this.DGAlert.RowHeadersVisible = false;
            this.DGAlert.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGAlert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGAlert.Size = new System.Drawing.Size(305, 179);
            this.DGAlert.TabIndex = 7;
            this.DGAlert.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAlert_CellClick);
            this.DGAlert.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAlert_CellContentClick);
            // 
            // AlertId
            // 
            this.AlertId.HeaderText = "Alert Id";
            this.AlertId.Name = "AlertId";
            // 
            // Alertname
            // 
            this.Alertname.HeaderText = "Alert Name";
            this.Alertname.Name = "Alertname";
            this.Alertname.Width = 200;
            // 
            // frm_AlertMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(320, 322);
            this.Controls.Add(this.DGAlert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_AlertMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert Master";
            this.Load += new System.EventHandler(this.frm_Alert_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Alert_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAlertID;
        private System.Windows.Forms.Label LblAlertname;
        private System.Windows.Forms.TextBox txtAlertName;
        private System.Windows.Forms.TextBox txtAlertID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView DGAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alertname;
        private System.Windows.Forms.Label lblFormCatagory;
        private System.Windows.Forms.TextBox txtFormCatagory;
    }
}