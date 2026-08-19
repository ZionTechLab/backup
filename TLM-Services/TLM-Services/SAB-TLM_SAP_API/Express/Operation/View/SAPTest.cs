
using Express.UI.Insfastructure.SAP;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class SAPTest : Form
    {
        private Label label1;
        private GroupBox groupBox2;
        private Button button1;

        public SAPTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                      
           
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Send to SAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 135);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // SAPTest
            // 
            this.ClientSize = new System.Drawing.Size(444, 186);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "SAPTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.SAPTest_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            label1.Text = "Please wait while proccessing...";

            label1.ForeColor = Color.Red;

            SAPInvoiceHeaderViewModel InvHedView = new SAPInvoiceHeaderViewModel();          

            SAPRest<SAPInvoiceHeaderViewModel> RST = new SAPRest<SAPInvoiceHeaderViewModel>();
            var result = RST.Post("INVOICE", InvHedView).Result;

         
            label1.Text = result.Message;

            label1.ForeColor = Color.Green;

          
        }

        private void SAPTest_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            SAPInvoiceHeaderViewModel InvHedView = new SAPInvoiceHeaderViewModel();

            SAPRest<SAPInvoiceHeaderViewModel> RST = new SAPRest<SAPInvoiceHeaderViewModel>();
            var result = RST.Post("INVOICE", InvHedView).Result;

            this.Close();
        }
    }
}
