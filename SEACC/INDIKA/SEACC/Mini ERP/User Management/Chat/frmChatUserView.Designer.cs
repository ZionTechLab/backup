namespace Digiteq
{
    partial class frmChatUserView
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
            this.lblUser = new System.Windows.Forms.Label();
            this.lbluserID = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.xpnlChatRooms = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.xpnlChatRooms.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUser.Location = new System.Drawing.Point(8, 35);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 19);
            this.lblUser.TabIndex = 409;
            this.lblUser.Text = "User Name";
            // 
            // lbluserID
            // 
            this.lbluserID.AutoSize = true;
            this.lbluserID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbluserID.Location = new System.Drawing.Point(8, 9);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(57, 19);
            this.lbluserID.TabIndex = 407;
            this.lbluserID.Text = "User ID";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGroupName.Location = new System.Drawing.Point(9, 73);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(70, 14);
            this.lblGroupName.TabIndex = 408;
            this.lblGroupName.Text = "Group Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 2);
            this.label1.TabIndex = 410;
            this.label1.Text = "Group Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEmail.Location = new System.Drawing.Point(9, 93);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 14);
            this.lblEmail.TabIndex = 414;
            this.lblEmail.Text = "Email";
            // 
            // pbxImage
            // 
            this.pbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImage.Image = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.InitialImage = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.Location = new System.Drawing.Point(196, 9);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(98, 98);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 406;
            this.pbxImage.TabStop = false;
            // 
            // xpnlChatRooms
            // 
            this.xpnlChatRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpnlChatRooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpnlChatRooms.Controls.Add(this.lbluserID);
            this.xpnlChatRooms.Controls.Add(this.lblEmail);
            this.xpnlChatRooms.Controls.Add(this.pbxImage);
            this.xpnlChatRooms.Controls.Add(this.lblGroupName);
            this.xpnlChatRooms.Controls.Add(this.lblUser);
            this.xpnlChatRooms.Controls.Add(this.label1);
            this.xpnlChatRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xpnlChatRooms.Location = new System.Drawing.Point(0, 0);
            this.xpnlChatRooms.Name = "xpnlChatRooms";
            this.xpnlChatRooms.Size = new System.Drawing.Size(307, 117);
            this.xpnlChatRooms.TabIndex = 415;
            // 
            // frmChatUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 117);
            this.ControlBox = false;
            this.Controls.Add(this.xpnlChatRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmChatUserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.frmChatUserView_Deactivate);
            this.Load += new System.EventHandler(this.frmChatUserView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.xpnlChatRooms.ResumeLayout(false);
            this.xpnlChatRooms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lbluserID;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel xpnlChatRooms;
    }
}