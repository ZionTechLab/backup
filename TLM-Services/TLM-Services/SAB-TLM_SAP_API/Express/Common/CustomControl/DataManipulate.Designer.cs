namespace Express.UI.Common.CustomControl
{
    partial class DataManipulate
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.previewBtn = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.flowPannelButtonList = new System.Windows.Forms.FlowLayoutPanel();
            this.importBtn = new System.Windows.Forms.Button();
            this.flowPannelButtonList.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(561, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(56, 39);
            this.closeBtn.TabIndex = 17;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseForm);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(251, 3);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(56, 39);
            this.deleteBtn.TabIndex = 16;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteMethod);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(189, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 39);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.ClearMethod);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(127, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(56, 39);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveMethod);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(65, 3);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(56, 39);
            this.editBtn.TabIndex = 13;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditMethod);
            // 
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBtn.Location = new System.Drawing.Point(3, 3);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(56, 39);
            this.newBtn.TabIndex = 12;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.NewMethod);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(313, 3);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(56, 39);
            this.printBtn.TabIndex = 18;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.PrintMethod);
            // 
            // previewBtn
            // 
            this.previewBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.Location = new System.Drawing.Point(375, 3);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(56, 39);
            this.previewBtn.TabIndex = 19;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewMethod);
            // 
            // processBtn
            // 
            this.processBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processBtn.Location = new System.Drawing.Point(437, 3);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(56, 39);
            this.processBtn.TabIndex = 20;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.ProccessMethod);
            // 
            // flowPannelButtonList
            // 
            this.flowPannelButtonList.Controls.Add(this.newBtn);
            this.flowPannelButtonList.Controls.Add(this.editBtn);
            this.flowPannelButtonList.Controls.Add(this.saveBtn);
            this.flowPannelButtonList.Controls.Add(this.cancelBtn);
            this.flowPannelButtonList.Controls.Add(this.deleteBtn);
            this.flowPannelButtonList.Controls.Add(this.printBtn);
            this.flowPannelButtonList.Controls.Add(this.previewBtn);
            this.flowPannelButtonList.Controls.Add(this.processBtn);
            this.flowPannelButtonList.Controls.Add(this.importBtn);
            this.flowPannelButtonList.Controls.Add(this.closeBtn);
            this.flowPannelButtonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPannelButtonList.Location = new System.Drawing.Point(0, 0);
            this.flowPannelButtonList.Name = "flowPannelButtonList";
            this.flowPannelButtonList.Size = new System.Drawing.Size(623, 46);
            this.flowPannelButtonList.TabIndex = 21;
            // 
            // importBtn
            // 
            this.importBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(499, 3);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(56, 39);
            this.importBtn.TabIndex = 21;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.ImportMethod);
            // 
            // DataManipulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPannelButtonList);
            this.Name = "DataManipulate";
            this.Size = new System.Drawing.Size(623, 46);
            this.flowPannelButtonList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.FlowLayoutPanel flowPannelButtonList;
        private System.Windows.Forms.Button importBtn;
    }
}
