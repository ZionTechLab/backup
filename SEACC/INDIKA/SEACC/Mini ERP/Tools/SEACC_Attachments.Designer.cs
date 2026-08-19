namespace Digiteq
{
    partial class SEACC_Attachments
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
            this.btnAttachment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAttachment
            // 
            this.btnAttachment.BackColor = System.Drawing.Color.LightGray;
            this.btnAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAttachment.FlatAppearance.BorderSize = 0;
            this.btnAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachment.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachment.ForeColor = System.Drawing.Color.Black;
            this.btnAttachment.Image = global::Digiteq.Properties.Resources.icons8_attach_20;
            this.btnAttachment.Location = new System.Drawing.Point(0, 0);
            this.btnAttachment.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(30, 25);
            this.btnAttachment.TabIndex = 552;
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // SEACC_Attachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnAttachment);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SEACC_Attachments";
            this.Size = new System.Drawing.Size(30, 25);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAttachment;
    }
}
