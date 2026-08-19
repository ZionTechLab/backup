namespace Digiteq
{
    partial class frm_cht_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cht_Sales));
            this.x1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.chtMounthlyCollection = new Digiteq.charts();
            this.chtSalesByCust = new Digiteq.charts();
            this.x1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMounthlyCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtSalesByCust)).BeginInit();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.Transparent;
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.btnRefresh);
            this.x1.Controls.Add(this.btnCancel);
            this.x1.Controls.Add(this.label26);
            this.x1.Controls.Add(this.pictureBox1);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(7, 7);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(1073, 36);
            this.x1.TabIndex = 404;
            this.x1.Paint += new System.Windows.Forms.PaintEventHandler(this.x1_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(917, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 396;
            this.btnRefresh.Text = "Refresh  ";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(993, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "Close    ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(109, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "Sales";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 385;
            this.pictureBox1.TabStop = false;
            // 
            // chtMounthlyCollection
            // 
            this.chtMounthlyCollection.Location = new System.Drawing.Point(7, 343);
            this.chtMounthlyCollection.Name = "chtMounthlyCollection";
            this.chtMounthlyCollection.Size = new System.Drawing.Size(1073, 295);
            this.chtMounthlyCollection.TabIndex = 405;
            this.chtMounthlyCollection.Click += new System.EventHandler(this.chtMounthlyCollection_Click);
            // 
            // chtSalesByCust
            // 
            this.chtSalesByCust.Location = new System.Drawing.Point(6, 48);
            this.chtSalesByCust.Name = "chtSalesByCust";
            this.chtSalesByCust.Size = new System.Drawing.Size(1074, 295);
            this.chtSalesByCust.TabIndex = 405;
            // 
            // frm_cht_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1092, 643);
            this.ControlBox = false;
            this.Controls.Add(this.chtMounthlyCollection);
            this.Controls.Add(this.chtSalesByCust);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frm_cht_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMounthlyCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtSalesByCust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Digiteq.charts chtSalesByCust;
        private Digiteq.charts chtMounthlyCollection;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}