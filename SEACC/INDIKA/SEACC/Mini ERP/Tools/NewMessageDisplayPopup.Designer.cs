namespace Digiteq
{
    partial class NewMessageDisplayPopup
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
            this.btnView = new System.Windows.Forms.Button();
            this.lbluserID = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnView.Location = new System.Drawing.Point(12, 82);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(177, 28);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View Message";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lbluserID
            // 
            this.lbluserID.AutoSize = true;
            this.lbluserID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserID.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbluserID.Location = new System.Drawing.Point(11, 12);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(57, 19);
            this.lbluserID.TabIndex = 416;
            this.lbluserID.Text = "User ID";
            // 
            // pbxImage
            // 
            this.pbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImage.Image = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.InitialImage = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.Location = new System.Drawing.Point(199, 12);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(98, 98);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 415;
            this.pbxImage.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblUser.Location = new System.Drawing.Point(88, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 19);
            this.lblUser.TabIndex = 418;
            this.lblUser.Text = "User Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 2);
            this.label1.TabIndex = 419;
            this.label1.Text = "Group Name";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblGroupName.Location = new System.Drawing.Point(12, 54);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(70, 14);
            this.lblGroupName.TabIndex = 420;
            this.lblGroupName.Text = "Group Name";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NewMessageDisplayPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 118);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.lbluserID);
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewMessageDisplayPopup";
            this.Text = "NewMessageDisplayPopup";
            this.Load += new System.EventHandler(this.NewMessageDisplayPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lbluserID;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Timer timer1;
    }
}