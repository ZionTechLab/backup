namespace Digiteq
{
    partial class MettroForm
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ucTittleBar1 = new Digiteq.ucTittleBar();
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btnReSize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.ucTittleBar1.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(681, 29);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(2, 231);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(1, 29);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(2, 231);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(3, 258);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(678, 2);
            this.pnlBottom.TabIndex = 3;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.ucTittleBar1.Controls.Add(this.pnlFormHeader);
            this.ucTittleBar1.DisplayName = "label1";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(1, 1);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(682, 28);
            this.ucTittleBar1.TabIndex = 0;
            // 
            // pnlFormHeader
            // 
            this.pnlFormHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormHeader.Controls.Add(this.btnSettings);
            this.pnlFormHeader.Controls.Add(this.btn_minimize);
            this.pnlFormHeader.Controls.Add(this.btnReSize);
            this.pnlFormHeader.Controls.Add(this.btn_Close);
            this.pnlFormHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFormHeader.Location = new System.Drawing.Point(538, 0);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Size = new System.Drawing.Size(144, 28);
            this.pnlFormHeader.TabIndex = 46;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSettings.Location = new System.Drawing.Point(24, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 28);
            this.btnSettings.TabIndex = 47;
            this.btnSettings.Text = "";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_minimize.Location = new System.Drawing.Point(54, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 28);
            this.btn_minimize.TabIndex = 46;
            this.btn_minimize.Text = "";
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btnReSize
            // 
            this.btnReSize.BackColor = System.Drawing.Color.Transparent;
            this.btnReSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReSize.FlatAppearance.BorderSize = 0;
            this.btnReSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReSize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReSize.Location = new System.Drawing.Point(84, 0);
            this.btnReSize.Name = "btnReSize";
            this.btnReSize.Size = new System.Drawing.Size(30, 28);
            this.btnReSize.TabIndex = 48;
            this.btnReSize.Text = "";
            this.btnReSize.UseVisualStyleBackColor = false;
            this.btnReSize.Visible = false;
            this.btnReSize.Click += new System.EventHandler(this.btnReSize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Close.Location = new System.Drawing.Point(114, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 44;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // MettroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.ucTittleBar1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MettroForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.pnlFormHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Digiteq. ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReSize;
    }
}