namespace Digiteq
{
    partial class frm_rpt_CustomerMasterReport
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
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoCustomerProfile = new System.Windows.Forms.RadioButton();
            this.rdoCustomerMailing = new System.Windows.Forms.RadioButton();
            this.rdoTownWise = new System.Windows.Forms.RadioButton();
            this.rdoRouterWise = new System.Windows.Forms.RadioButton();
            this.rdoCustomerMaster = new System.Windows.Forms.RadioButton();
            this.rdoSalesRep2 = new System.Windows.Forms.RadioButton();
            this.rdoSalesRep = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.z2 = new System.Windows.Forms.Panel();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.z2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoCustomerProfile);
            this.x1.Controls.Add(this.rdoCustomerMailing);
            this.x1.Controls.Add(this.rdoTownWise);
            this.x1.Controls.Add(this.rdoRouterWise);
            this.x1.Controls.Add(this.rdoCustomerMaster);
            this.x1.Controls.Add(this.rdoSalesRep2);
            this.x1.Controls.Add(this.rdoSalesRep);
            this.x1.Location = new System.Drawing.Point(6, 33);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(546, 112);
            this.x1.TabIndex = 7;
            // 
            // rdoCustomerProfile
            // 
            this.rdoCustomerProfile.AutoSize = true;
            this.rdoCustomerProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.rdoCustomerProfile.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCustomerProfile.Location = new System.Drawing.Point(10, 79);
            this.rdoCustomerProfile.Name = "rdoCustomerProfile";
            this.rdoCustomerProfile.Size = new System.Drawing.Size(192, 18);
            this.rdoCustomerProfile.TabIndex = 20;
            this.rdoCustomerProfile.TabStop = true;
            this.rdoCustomerProfile.Text = "Customer Profile (Customer-wise)";
            this.rdoCustomerProfile.UseVisualStyleBackColor = false;
            this.rdoCustomerProfile.CheckedChanged += new System.EventHandler(this.rdoCustomerProfile_CheckedChanged);
            // 
            // rdoCustomerMailing
            // 
            this.rdoCustomerMailing.AutoSize = true;
            this.rdoCustomerMailing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerMailing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCustomerMailing.Location = new System.Drawing.Point(293, 56);
            this.rdoCustomerMailing.Name = "rdoCustomerMailing";
            this.rdoCustomerMailing.Size = new System.Drawing.Size(148, 18);
            this.rdoCustomerMailing.TabIndex = 19;
            this.rdoCustomerMailing.TabStop = true;
            this.rdoCustomerMailing.Text = "Customer Mailing Report";
            this.rdoCustomerMailing.UseVisualStyleBackColor = true;
            // 
            // rdoTownWise
            // 
            this.rdoTownWise.AutoSize = true;
            this.rdoTownWise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTownWise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoTownWise.Location = new System.Drawing.Point(293, 32);
            this.rdoTownWise.Name = "rdoTownWise";
            this.rdoTownWise.Size = new System.Drawing.Size(225, 18);
            this.rdoTownWise.TabIndex = 18;
            this.rdoTownWise.TabStop = true;
            this.rdoTownWise.Text = "Customer Master Summary (Town-wise)";
            this.rdoTownWise.UseVisualStyleBackColor = true;
            this.rdoTownWise.CheckedChanged += new System.EventHandler(this.rdoTownWise_CheckedChanged);
            // 
            // rdoRouterWise
            // 
            this.rdoRouterWise.AutoSize = true;
            this.rdoRouterWise.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRouterWise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRouterWise.Location = new System.Drawing.Point(293, 6);
            this.rdoRouterWise.Name = "rdoRouterWise";
            this.rdoRouterWise.Size = new System.Drawing.Size(228, 18);
            this.rdoRouterWise.TabIndex = 17;
            this.rdoRouterWise.TabStop = true;
            this.rdoRouterWise.Text = "Customer Master Summary (Route-wise)";
            this.rdoRouterWise.UseVisualStyleBackColor = true;
            this.rdoRouterWise.CheckedChanged += new System.EventHandler(this.rdoRouterWise_CheckedChanged);
            // 
            // rdoCustomerMaster
            // 
            this.rdoCustomerMaster.AutoSize = true;
            this.rdoCustomerMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.rdoCustomerMaster.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCustomerMaster.Location = new System.Drawing.Point(11, 6);
            this.rdoCustomerMaster.Name = "rdoCustomerMaster";
            this.rdoCustomerMaster.Size = new System.Drawing.Size(246, 18);
            this.rdoCustomerMaster.TabIndex = 16;
            this.rdoCustomerMaster.TabStop = true;
            this.rdoCustomerMaster.Text = "Customer Master Summary (Customer-wise)";
            this.rdoCustomerMaster.UseVisualStyleBackColor = false;
            this.rdoCustomerMaster.CheckedChanged += new System.EventHandler(this.rdoCustomerMaster_CheckedChanged);
            // 
            // rdoSalesRep2
            // 
            this.rdoSalesRep2.AutoSize = true;
            this.rdoSalesRep2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesRep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSalesRep2.Location = new System.Drawing.Point(10, 56);
            this.rdoSalesRep2.Name = "rdoSalesRep2";
            this.rdoSalesRep2.Size = new System.Drawing.Size(186, 18);
            this.rdoSalesRep2.TabIndex = 15;
            this.rdoSalesRep2.TabStop = true;
            this.rdoSalesRep2.Text = "Sales Rep-Wice Customers (Txn)";
            this.rdoSalesRep2.UseVisualStyleBackColor = true;
            this.rdoSalesRep2.CheckedChanged += new System.EventHandler(this.rdoSalesRep2_CheckedChanged);
            // 
            // rdoSalesRep
            // 
            this.rdoSalesRep.AutoSize = true;
            this.rdoSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSalesRep.Location = new System.Drawing.Point(11, 32);
            this.rdoSalesRep.Name = "rdoSalesRep";
            this.rdoSalesRep.Size = new System.Drawing.Size(247, 18);
            this.rdoSalesRep.TabIndex = 15;
            this.rdoSalesRep.TabStop = true;
            this.rdoSalesRep.Text = "Customer Master Summary (Sales Rep-wise)";
            this.rdoSalesRep.UseVisualStyleBackColor = true;
            this.rdoSalesRep.CheckedChanged += new System.EventHandler(this.rdoSalesRep_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(477, 291);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 26);
            this.btnPrint.TabIndex = 479;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.txtTown);
            this.z2.Controls.Add(this.lblTown);
            this.z2.Controls.Add(this.txtRoute);
            this.z2.Controls.Add(this.lblRoute);
            this.z2.Controls.Add(this.txtSalesRep);
            this.z2.Controls.Add(this.lblSalseRep);
            this.z2.Controls.Add(this.txtCustomer);
            this.z2.Controls.Add(this.lblCustomer);
            this.z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z2.Location = new System.Drawing.Point(6, 223);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(546, 64);
            this.z2.TabIndex = 480;
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.LightGray;
            this.txtTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(366, 33);
            this.txtTown.Name = "txtTown";
            this.txtTown.ReadOnly = true;
            this.txtTown.Size = new System.Drawing.Size(161, 22);
            this.txtTown.TabIndex = 463;
            this.txtTown.DoubleClick += new System.EventHandler(this.txtTown_DoubleClick);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTown.Location = new System.Drawing.Point(290, 37);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(66, 14);
            this.lblTown.TabIndex = 464;
            this.lblTown.Text = "Town Name";
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(366, 6);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(161, 22);
            this.txtRoute.TabIndex = 461;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(290, 10);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 462;
            this.lblRoute.Text = "Route Name";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(97, 33);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(163, 22);
            this.txtSalesRep.TabIndex = 459;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalseRep.Location = new System.Drawing.Point(7, 37);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(88, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman Name";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(97, 6);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(163, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(7, 10);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(396, 291);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 481;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTypeName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClassName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(6, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 64);
            this.panel1.TabIndex = 481;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(366, 6);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(161, 22);
            this.txtCategory.TabIndex = 463;
            this.txtCategory.DoubleClick += new System.EventHandler(this.txtCategory_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(290, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 464;
            this.label1.Text = "Category";
            // 
            // txtTypeName
            // 
            this.txtTypeName.BackColor = System.Drawing.Color.LightGray;
            this.txtTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeName.Location = new System.Drawing.Point(97, 34);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(163, 22);
            this.txtTypeName.TabIndex = 461;
            this.txtTypeName.DoubleClick += new System.EventHandler(this.txtTypeName_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 462;
            this.label2.Text = "Type Name";
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.LightGray;
            this.txtClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassName.Location = new System.Drawing.Point(97, 6);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(163, 22);
            this.txtClassName.TabIndex = 0;
            this.txtClassName.DoubleClick += new System.EventHandler(this.txtClassName_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Class Name";
            // 
            // frm_rpt_CustomerMasterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(559, 322);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.btnPrint);
            this.MaximizeBox = false;
            this.Name = "frm_rpt_CustomerMasterReport";
            this.Text = "Customer Master Report";
            this.Load += new System.EventHandler(this.frm_rpt_CustomerMasterReport_Load);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.z2, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdoCustomerMaster;
        private System.Windows.Forms.RadioButton rdoSalesRep;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoTownWise;
        private System.Windows.Forms.RadioButton rdoRouterWise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoCustomerMailing;
        private System.Windows.Forms.RadioButton rdoSalesRep2;
        private System.Windows.Forms.RadioButton rdoCustomerProfile;
    }
}