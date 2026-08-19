
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // SAPTest
            // 
            this.ClientSize = new System.Drawing.Size(1150, 537);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "SAPTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SAPTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            List<AccountGLViewModel> AccountGLViewList = new List<AccountGLViewModel>();
            List<AccountReceivableViewModel> AccountReceivableList = new List<AccountReceivableViewModel>();
            List<AccountTaxViewModel> AccoutTaxViewList = new List<AccountTaxViewModel>();
            List<CurrencyAmountViewModel> CurrencyAmoutViewList = new List<CurrencyAmountViewModel>();

            SAPInvoiceHeaderViewModel InvHedView = new SAPInvoiceHeaderViewModel();

            InvHedView.ACDocNo = "1234567";
            InvHedView.HeaderTxt = "Header Text";
            InvHedView.CompCode = "1100";
            InvHedView.DocDate = DateTime.Parse("2018-10-03");
            InvHedView.PostingDate = DateTime.Parse("2018-10-03");
            InvHedView.FiscYear = 2018;
            InvHedView.FiscPeriod = 00;
            InvHedView.DocType = "AB";

            AccountGLViewModel AccountGLView = new AccountGLViewModel();
            AccountGLView.ItemNoAcc = 1;
            AccountGLView.GLAccount = "0040000000";
            AccountGLView.ItemText = "JEDA";
            AccountGLView.AccType = "S";
            AccountGLView.FisPeriod = 00;
            AccountGLView.TaxCode = "S2";
            AccountGLView.ProfitCntr = "C000";

            AccountGLViewList.Add(AccountGLView);

            AccountReceivableViewModel AccReceivableView = new AccountReceivableViewModel();
            AccReceivableView.ItemNoAcc = 2;
            AccReceivableView.Customer = "0000000003";
            AccReceivableView.CompCode = "1100";
            AccReceivableView.ProfitCntr = "C000";
            AccountReceivableList.Add(AccReceivableView);

            AccountTaxViewModel AccountTaxView = new AccountTaxViewModel();
            AccountTaxView.ItemNoAcc = 3;
            AccountTaxView.GLAccount = "0022000010";
            AccountTaxView.TaxCode = "S2";
            AccountTaxView.TaxRate = 5;
            AccoutTaxViewList.Add(AccountTaxView);

            CurrencyAmountViewModel CurrencyAmountView = new CurrencyAmountViewModel();
            CurrencyAmountView.ItemNoAcc = 1;
            CurrencyAmountView.CurrencyISO = "SAR";
            CurrencyAmountView.AmtDocCur = -1000;

            CurrencyAmoutViewList.Add(CurrencyAmountView);

            CurrencyAmountViewModel CurrencyAmountView1 = new CurrencyAmountViewModel();
            CurrencyAmountView1.ItemNoAcc = 2;
            CurrencyAmountView1.CurrencyISO = "SAR";
            CurrencyAmountView1.AmtDocCur = 1050;

            CurrencyAmoutViewList.Add(CurrencyAmountView1);

            CurrencyAmountViewModel CurrencyAmountView2 = new CurrencyAmountViewModel();
            CurrencyAmountView2.ItemNoAcc = 3;
            CurrencyAmountView2.CurrencyISO = "SAR";
            CurrencyAmountView2.AmtDocCur = -50;
            CurrencyAmountView2.BaseAmt = 1000;
            CurrencyAmountView2.TaxAmt = -50;

            CurrencyAmoutViewList.Add(CurrencyAmountView2);

            InvHedView.AccountGL = AccountGLViewList;
            InvHedView.AccountReceivable = AccountReceivableList;
            InvHedView.AccountTax = AccoutTaxViewList;
            InvHedView.CurrencyAmount = CurrencyAmoutViewList;

            SAPRest<SAPInvoiceHeaderViewModel> RST = new SAPRest<SAPInvoiceHeaderViewModel>();
            var result = RST.Post("INVOICE", InvHedView).Result;

            //string msg = result.Message.Split('|')[0].ToString();

            //if (msg.Trim() == "SUCCESS")
            //{
            //    label1.ForeColor = Color.Green;
            //}
            //else
            //{
            //    label1.ForeColor = Color.Red;
            //}

            label1.Text = result.Message;
        }

        private void SAPTest_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
