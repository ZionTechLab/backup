namespace Digiteq
{
	partial class frm_Alert_Home
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
            this.xpanel3 = new System.Windows.Forms.Panel();
            this.btnAlertMaster = new System.Windows.Forms.Button();
            this.btnAlertScheduling = new System.Windows.Forms.Button();
            this.btnUsrSetup = new System.Windows.Forms.Button();
            this.btnEmailConfig = new System.Windows.Forms.Button();
            this.xpanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.btnAlertMaster);
            this.xpanel3.Controls.Add(this.btnAlertScheduling);
            this.xpanel3.Controls.Add(this.btnUsrSetup);
            this.xpanel3.Controls.Add(this.btnEmailConfig);
            this.xpanel3.Location = new System.Drawing.Point(8, 8);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(281, 159);
            this.xpanel3.TabIndex = 20;
            // 
            // btnAlertMaster
            // 
            this.btnAlertMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnAlertMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertMaster.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlertMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlertMaster.Location = new System.Drawing.Point(142, 81);
            this.btnAlertMaster.Name = "btnAlertMaster";
            this.btnAlertMaster.Size = new System.Drawing.Size(128, 67);
            this.btnAlertMaster.TabIndex = 17;
            this.btnAlertMaster.Text = "Alert Master";
            this.btnAlertMaster.UseVisualStyleBackColor = false;
            this.btnAlertMaster.Click += new System.EventHandler(this.btnAlertMaster_Click);
            // 
            // btnAlertScheduling
            // 
            this.btnAlertScheduling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnAlertScheduling.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlertScheduling.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlertScheduling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlertScheduling.Location = new System.Drawing.Point(8, 81);
            this.btnAlertScheduling.Name = "btnAlertScheduling";
            this.btnAlertScheduling.Size = new System.Drawing.Size(128, 67);
            this.btnAlertScheduling.TabIndex = 16;
            this.btnAlertScheduling.Text = "Scheduling Alerts";
            this.btnAlertScheduling.UseVisualStyleBackColor = false;
            this.btnAlertScheduling.Click += new System.EventHandler(this.btnAlertScheduling_Click);
            // 
            // btnUsrSetup
            // 
            this.btnUsrSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnUsrSetup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsrSetup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrSetup.Location = new System.Drawing.Point(142, 8);
            this.btnUsrSetup.Name = "btnUsrSetup";
            this.btnUsrSetup.Size = new System.Drawing.Size(128, 67);
            this.btnUsrSetup.TabIndex = 15;
            this.btnUsrSetup.Text = "Setting Users";
            this.btnUsrSetup.UseVisualStyleBackColor = false;
            this.btnUsrSetup.Click += new System.EventHandler(this.btnUsrSetup_Click);
            // 
            // btnEmailConfig
            // 
            this.btnEmailConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnEmailConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmailConfig.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailConfig.Location = new System.Drawing.Point(8, 8);
            this.btnEmailConfig.Name = "btnEmailConfig";
            this.btnEmailConfig.Size = new System.Drawing.Size(128, 67);
            this.btnEmailConfig.TabIndex = 13;
            this.btnEmailConfig.Text = "Email Config";
            this.btnEmailConfig.UseVisualStyleBackColor = false;
            this.btnEmailConfig.Click += new System.EventHandler(this.btnEmailConfig_Click);
            // 
            // frm_Alert_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 175);
            this.Controls.Add(this.xpanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Alert_Home";
            this.Text = "Alert Home";
            this.xpanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btnAlertMaster;
        private System.Windows.Forms.Button btnAlertScheduling;
        private System.Windows.Forms.Button btnUsrSetup;
        private System.Windows.Forms.Button btnEmailConfig;
	}
}