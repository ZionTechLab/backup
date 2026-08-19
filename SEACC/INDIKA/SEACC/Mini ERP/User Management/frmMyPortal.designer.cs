namespace Digiteq
{
    partial class frmMyPortal
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
            this.label26 = new System.Windows.Forms.Label();
            this.jj = new System.Windows.Forms.Panel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.x3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.x5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOldPin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoLegacy = new System.Windows.Forms.RadioButton();
            this.rdoMetro = new System.Windows.Forms.RadioButton();
            this.btnUpdateTheme = new System.Windows.Forms.Button();
            this.jj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.x3.SuspendLayout();
            this.x5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(9, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "MY PORTAL";
            // 
            // jj
            // 
            this.jj.BackColor = System.Drawing.Color.Transparent;
            this.jj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jj.Controls.Add(this.btnLoadImage);
            this.jj.Controls.Add(this.label6);
            this.jj.Controls.Add(this.txtPassword);
            this.jj.Controls.Add(this.label26);
            this.jj.Controls.Add(this.btnPrint);
            this.jj.Controls.Add(this.btnCancel);
            this.jj.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jj.Location = new System.Drawing.Point(7, 6);
            this.jj.Name = "jj";
            this.jj.Size = new System.Drawing.Size(691, 36);
            this.jj.TabIndex = 403;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Image = global::Digiteq.Properties.Resources.settings;
            this.btnLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadImage.Location = new System.Drawing.Point(526, 5);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(85, 25);
            this.btnLoadImage.TabIndex = 465;
            this.btnLoadImage.Text = "   Change Pic";
            this.btnLoadImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(219, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 14);
            this.label6.TabIndex = 464;
            this.label6.Text = "Exisitng Password ";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txtPassword.Location = new System.Drawing.Point(324, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(122, 22);
            this.txtPassword.TabIndex = 463;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.accept;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(450, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 456;
            this.btnPrint.Text = "   Save";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(611, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "Close    ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = System.Drawing.Color.Silver;
            this.pbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImage.Image = global::Digiteq.Properties.Resources.no_image;
            this.pbxImage.Location = new System.Drawing.Point(704, 7);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(136, 136);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 457;
            this.pbxImage.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 459;
            this.label5.Text = "User Code";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserID.Enabled = false;
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(75, 57);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(218, 22);
            this.txtUserID.TabIndex = 458;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 461;
            this.label1.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(75, 86);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(218, 22);
            this.txtUserName.TabIndex = 460;
            // 
            // x3
            // 
            this.x3.BackColor = System.Drawing.Color.Transparent;
            this.x3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x3.Controls.Add(this.label9);
            this.x3.Controls.Add(this.txtPassword1);
            this.x3.Controls.Add(this.label2);
            this.x3.Controls.Add(this.label3);
            this.x3.Controls.Add(this.txtPassword2);
            this.x3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x3.Location = new System.Drawing.Point(511, 49);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(187, 140);
            this.x3.TabIndex = 462;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(-1, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 25);
            this.label9.TabIndex = 462;
            this.label9.Text = "Change Password";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword1.Location = new System.Drawing.Point(11, 56);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(162, 22);
            this.txtPassword1.TabIndex = 458;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 461;
            this.label2.Text = "Re Enter Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 459;
            this.label3.Text = "New Password";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2.Location = new System.Drawing.Point(11, 103);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(162, 22);
            this.txtPassword2.TabIndex = 460;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // x5
            // 
            this.x5.BackColor = System.Drawing.Color.Transparent;
            this.x5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x5.Controls.Add(this.label7);
            this.x5.Controls.Add(this.txtOldPin);
            this.x5.Controls.Add(this.label11);
            this.x5.Controls.Add(this.label12);
            this.x5.Controls.Add(this.txtNewPin);
            this.x5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x5.Location = new System.Drawing.Point(318, 49);
            this.x5.Name = "x5";
            this.x5.Size = new System.Drawing.Size(187, 140);
            this.x5.TabIndex = 463;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(-1, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 462;
            this.label7.Text = "Change Pin Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOldPin
            // 
            this.txtOldPin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPin.Location = new System.Drawing.Point(12, 56);
            this.txtOldPin.MaxLength = 4;
            this.txtOldPin.Name = "txtOldPin";
            this.txtOldPin.PasswordChar = '*';
            this.txtOldPin.Size = new System.Drawing.Size(162, 22);
            this.txtOldPin.TabIndex = 458;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label11.Location = new System.Drawing.Point(9, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 461;
            this.label11.Text = "New Pin No.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label12.Location = new System.Drawing.Point(9, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 14);
            this.label12.TabIndex = 459;
            this.label12.Text = "Old Pin No.";
            // 
            // txtNewPin
            // 
            this.txtNewPin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPin.Location = new System.Drawing.Point(12, 103);
            this.txtNewPin.MaxLength = 4;
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.PasswordChar = '*';
            this.txtNewPin.Size = new System.Drawing.Size(162, 22);
            this.txtNewPin.TabIndex = 460;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 461;
            this.label4.Text = "Theme";
            // 
            // rdoLegacy
            // 
            this.rdoLegacy.AutoSize = true;
            this.rdoLegacy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdoLegacy.Location = new System.Drawing.Point(75, 126);
            this.rdoLegacy.Name = "rdoLegacy";
            this.rdoLegacy.Size = new System.Drawing.Size(60, 17);
            this.rdoLegacy.TabIndex = 464;
            this.rdoLegacy.TabStop = true;
            this.rdoLegacy.Text = "Legacy";
            this.rdoLegacy.UseVisualStyleBackColor = true;
            // 
            // rdoMetro
            // 
            this.rdoMetro.AutoSize = true;
            this.rdoMetro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdoMetro.Location = new System.Drawing.Point(141, 127);
            this.rdoMetro.Name = "rdoMetro";
            this.rdoMetro.Size = new System.Drawing.Size(52, 17);
            this.rdoMetro.TabIndex = 465;
            this.rdoMetro.TabStop = true;
            this.rdoMetro.Text = "Metro";
            this.rdoMetro.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTheme
            // 
            this.btnUpdateTheme.Location = new System.Drawing.Point(199, 123);
            this.btnUpdateTheme.Name = "btnUpdateTheme";
            this.btnUpdateTheme.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTheme.TabIndex = 466;
            this.btnUpdateTheme.Text = "Update";
            this.btnUpdateTheme.UseVisualStyleBackColor = true;
            this.btnUpdateTheme.Click += new System.EventHandler(this.btnUpdateTheme_Click);
            // 
            // frmMyPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(848, 217);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdateTheme);
            this.Controls.Add(this.rdoMetro);
            this.Controls.Add(this.rdoLegacy);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.x5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.jj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmMyPortal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_bpsChequeViewer_Load);
            this.jj.ResumeLayout(false);
            this.jj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.x3.ResumeLayout(false);
            this.x3.PerformLayout();
            this.x5.ResumeLayout(false);
            this.x5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel jj;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Panel x3;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel x5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOldPin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNewPin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoLegacy;
        private System.Windows.Forms.RadioButton rdoMetro;
        private System.Windows.Forms.Button btnUpdateTheme;
    }
}