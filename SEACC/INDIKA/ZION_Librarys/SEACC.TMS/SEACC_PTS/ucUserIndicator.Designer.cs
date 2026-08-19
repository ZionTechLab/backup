namespace SEACC_PTS
{
    partial class ucUserIndicator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pbxProPic = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.personalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUser.Location = new System.Drawing.Point(5, 31);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(101, 13);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "label1";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucUserIndicator_MouseDown);
            this.lblUser.MouseEnter += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            this.lblUser.MouseLeave += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            // 
            // lblFullName
            // 
            this.lblFullName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(5, 5);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(101, 26);
            this.lblFullName.TabIndex = 9;
            this.lblFullName.Text = "User :";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFullName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucUserIndicator_MouseDown);
            this.lblFullName.MouseEnter += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            this.lblFullName.MouseLeave += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            // 
            // pbxProPic
            // 
            this.pbxProPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxProPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxProPic.InitialImage = null;
            this.pbxProPic.Location = new System.Drawing.Point(106, 5);
            this.pbxProPic.Name = "pbxProPic";
            this.pbxProPic.Size = new System.Drawing.Size(48, 48);
            this.pbxProPic.TabIndex = 10;
            this.pbxProPic.TabStop = false;
            this.pbxProPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucUserIndicator_MouseDown);
            this.pbxProPic.MouseEnter += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            this.pbxProPic.MouseLeave += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalizeToolStripMenuItem,
            this.logOffToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // personalizeToolStripMenuItem
            // 
            this.personalizeToolStripMenuItem.AutoSize = false;
            this.personalizeToolStripMenuItem.Name = "personalizeToolStripMenuItem";
            this.personalizeToolStripMenuItem.Size = new System.Drawing.Size(172, 28);
            this.personalizeToolStripMenuItem.Text = "Personalize";
            this.personalizeToolStripMenuItem.Click += new System.EventHandler(this.personalizeToolStripMenuItem_Click);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.AutoSize = false;
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(172, 28);
            this.logOffToolStripMenuItem.Text = "Log Off";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AutoSize = false;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // ucUserIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pbxProPic);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ucUserIndicator";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(159, 58);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucUserIndicator_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ucUserIndicator_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucUserIndicator_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox pbxProPic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
