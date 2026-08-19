namespace SEACC_LOGIN
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblHeader = new System.Windows.Forms.Label();
            this.pSeperator = new System.Windows.Forms.Panel();
            this.pModules = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.icon_seacc_login = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblNetworkAvailability = new System.Windows.Forms.Label();
            this.timerNetworkChecker = new System.Windows.Forms.Timer(this.components);
            this.ucUserIndicator = new Digiteq. ucUserIndicator();
            this.pModules.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Location = new System.Drawing.Point(7, 128);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(164, 21);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "SEACC ERP";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pSeperator
            // 
            this.pSeperator.BackColor = System.Drawing.Color.White;
            this.pSeperator.ForeColor = System.Drawing.Color.White;
            this.pSeperator.Location = new System.Drawing.Point(11, 155);
            this.pSeperator.Name = "pSeperator";
            this.pSeperator.Size = new System.Drawing.Size(160, 1);
            this.pSeperator.TabIndex = 5;
            // 
            // pModules
            // 
            this.pModules.AutoScroll = true;
            this.pModules.BackColor = System.Drawing.Color.Transparent;
            this.pModules.Controls.Add(this.lblNetworkAvailability);
            this.pModules.Location = new System.Drawing.Point(11, 162);
            this.pModules.Name = "pModules";
            this.pModules.Size = new System.Drawing.Size(160, 293);
            this.pModules.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 41);
            this.panel1.TabIndex = 15;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(63, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 34);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(3, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(34, 35);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(121, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 32);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(12, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 1);
            this.panel2.TabIndex = 6;
            // 
            // icon_seacc_login
            // 
            this.icon_seacc_login.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.icon_seacc_login.BalloonTipText = "SEACC is running on the PC";
            this.icon_seacc_login.BalloonTipTitle = "SEACC LOGIN";
            this.icon_seacc_login.Icon = ((System.Drawing.Icon)(resources.GetObject("icon_seacc_login.Icon")));
            this.icon_seacc_login.Text = "SEACC LOGIN";
            this.icon_seacc_login.Visible = true;
            this.icon_seacc_login.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icon_seacc_login_MouseDoubleClick);
            // 
            // lblNetworkAvailability
            // 
            this.lblNetworkAvailability.AutoSize = true;
            this.lblNetworkAvailability.Font = new System.Drawing.Font("Segoe MDL2 Assets", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkAvailability.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNetworkAvailability.Location = new System.Drawing.Point(12, 194);
            this.lblNetworkAvailability.Name = "lblNetworkAvailability";
            this.lblNetworkAvailability.Size = new System.Drawing.Size(136, 96);
            this.lblNetworkAvailability.TabIndex = 54;
            this.lblNetworkAvailability.Text = "";
            // 
            // timerNetworkChecker
            // 
            this.timerNetworkChecker.Interval = 1000;
            this.timerNetworkChecker.Tick += new System.EventHandler(this.timerNetworkChecker_Tick);
            // 
            // ucUserIndicator
            // 
            this.ucUserIndicator.BackColor = System.Drawing.Color.Transparent;
            this.ucUserIndicator.DisplayName = "label1";
            this.ucUserIndicator.ForeColor = System.Drawing.Color.White;
            this.ucUserIndicator.Location = new System.Drawing.Point(11, 65);
            this.ucUserIndicator.Name = "ucUserIndicator";
            this.ucUserIndicator.Padding = new System.Windows.Forms.Padding(5);
            this.ucUserIndicator.Picture = null;
            this.ucUserIndicator.Size = new System.Drawing.Size(159, 58);
            this.ucUserIndicator.TabIndex = 13;
            this.ucUserIndicator.UserID = "label1";
            this.ucUserIndicator.UserName = "label1";
            this.ucUserIndicator.Load += new System.EventHandler(this.ucUserIndicator_Load);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.BackgroundImage = global::SEACC_LOGIN.Properties.Resources.b;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(183, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pModules);
            this.Controls.Add(this.ucUserIndicator);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pSeperator);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(584, 456);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.pModules.ResumeLayout(false);
            this.pModules.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pSeperator;
        private Digiteq. ucUserIndicator ucUserIndicator;
        private System.Windows.Forms.Panel pModules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NotifyIcon icon_seacc_login;
        private System.Windows.Forms.Label lblNetworkAvailability;
        private System.Windows.Forms.Timer timerNetworkChecker;
    }
}