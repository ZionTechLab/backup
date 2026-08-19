namespace SEACC_Cryptography
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
            this.lblSeaccType = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnGenerated = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucTittleBar1 = new Digiteq.ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSeaccType
            // 
            this.lblSeaccType.AutoSize = true;
            this.lblSeaccType.BackColor = System.Drawing.Color.Transparent;
            this.lblSeaccType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeaccType.ForeColor = System.Drawing.Color.White;
            this.lblSeaccType.Location = new System.Drawing.Point(63, 50);
            this.lblSeaccType.Name = "lblSeaccType";
            this.lblSeaccType.Size = new System.Drawing.Size(156, 29);
            this.lblSeaccType.TabIndex = 1111;
            this.lblSeaccType.Text = "Cryptography";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SEACC_Cryptography.Properties.Resources.digiteq_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(192, 359);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // btnGenerated
            // 
            this.btnGenerated.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerated.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnGenerated.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGenerated.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGenerated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerated.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGenerated.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerated.Location = new System.Drawing.Point(86, 254);
            this.btnGenerated.Name = "btnGenerated";
            this.btnGenerated.Size = new System.Drawing.Size(174, 28);
            this.btnGenerated.TabIndex = 5;
            this.btnGenerated.Text = "Generated";
            this.btnGenerated.UseVisualStyleBackColor = false;
            this.btnGenerated.Click += new System.EventHandler(this.btnGenerated_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 3333;
            this.label7.Text = "Servers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 6666;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(86, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(174, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 5555;
            this.label1.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(86, 175);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(174, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 4444;
            this.label3.Text = "Database";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.ForeColor = System.Drawing.Color.Black;
            this.txtDatabase.Location = new System.Drawing.Point(86, 150);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(174, 23);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.ForeColor = System.Drawing.Color.Black;
            this.txtServer.Location = new System.Drawing.Point(86, 125);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(174, 23);
            this.txtServer.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SEACC_Cryptography.Properties.Resources.data_encryption;
            this.pictureBox1.Location = new System.Drawing.Point(19, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 234;
            this.pictureBox1.TabStop = false;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.Transparent;
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(275, 38);
            this.ucTittleBar1.TabIndex = 233;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Location = new System.Drawing.Point(248, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(27, 26);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(57, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 15);
            this.label4.TabIndex = 2222;
            this.label4.Text = "_________________________________";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SEACC_Cryptography.Properties.Resources.download;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(275, 387);
            this.Controls.Add(this.ucTittleBar1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnGenerated);
            this.Controls.Add(this.lblSeaccType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeaccType;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnGenerated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtServer;
        private Digiteq.ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

