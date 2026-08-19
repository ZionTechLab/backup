using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;

namespace Digiteq{
    public partial class frm_bpsChequeSetting : Form
    {
        public frm_bpsChequeSetting()
        {
            InitializeComponent();
            this.clnFontType.FlatStyle = FlatStyle.Flat;
        }

        List<tbl_zChequePrinting> newCheque = new List<tbl_zChequePrinting>();
        List<tbl_zChequePrinting> tmpCopy = new List<tbl_zChequePrinting>();
        private void frm_bpsChequeSetting_Load(object sender, EventArgs e)
        {
            foreach (tbl_zFont font in tbl_zFont.SelectAll())
            {
            //    clnFontType.Items.Add(font.FontTypeID);
            }

            newCheque.Clear();
            newCheque =  DefaultChequeParameter();
            dgvData.DataSource = newCheque;            
        }

        private void txtBankName_DoubleClick(object sender, EventArgs e)
        {
            string status = "";
            try
            {
                
                clsSearch.Search_Bank(ref txtBankName);
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = null;
                newCheque.Clear();
                foreach (tbl_zChequePrinting detail in tbl_zChequePrinting.SelectAll().Where(p => p.BankID == txtBankName.Tag.ToString()))
                {
                    newCheque.Add(detail);
                }
                if (newCheque.Count == 0)
                {
                    status = "New cheque format";
                    newCheque = DefaultChequeParameter();
                } 
                dgvData.DataSource = newCheque;
                dgvData.Refresh();
                lblStatus2.Text = status;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = null;
            Clear();
            newCheque.Clear();
            newCheque = DefaultChequeParameter();
            dgvData.DataSource = newCheque;
            dgvData.Refresh();
            btnCopy.Tag = "";
            btnCopy.Text = "Copy";
            tmpCopy.Clear();
            lblStatus.Text = "";
            lblStatus2.Text = "";
        }

        private List<tbl_zChequePrinting> DefaultChequeParameter()
        {
            List<tbl_zChequePrinting>  DefaultChq = new List<tbl_zChequePrinting>();
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 1, ElementDiscription = "Counter Page Payee Line One", XValue = 20, YValue = 60, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 2, ElementDiscription = "Counter Page Payee Line Two", XValue = 0, YValue = 84, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 3, ElementDiscription = "Counter Page Payee Line Three", XValue = 0, YValue = 108, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 4, ElementDiscription = "Cheque Payee Line", XValue = 240, YValue = 62, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 5, ElementDiscription = "Counter Page Amount Line", XValue = 60, YValue = 205, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 6, ElementDiscription = "Cheque Amount Line ", XValue = 690, YValue = 124, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 7, ElementDiscription = "Rupee Line One", XValue = 245, YValue = 103, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 8, ElementDiscription = "Rupee Line Two", XValue = 225, YValue = 131, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 9, ElementDiscription = "Rupee Line Three", XValue = 225, YValue = 161, FontType = "Font2", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 10, ElementDiscription = "Counter Page Date Line", XValue = 57, YValue = 5, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 11, ElementDiscription = "Day Value One", XValue = 650, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 12, ElementDiscription = "Day Value Two", XValue = 675, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 13, ElementDiscription = "Month Value One ", XValue = 699, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 14, ElementDiscription = "Month Value Two", XValue = 725, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 15, ElementDiscription = "Year Value One ", XValue = 756, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 16, ElementDiscription = "Year Value Two", XValue = 778, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 17, ElementDiscription = "Year Value Three", XValue = 799, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 18, ElementDiscription = "Year Value Four", XValue = 826, YValue = 9, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 19, ElementDiscription = "Accout Payee ", XValue = 450, YValue = 43, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 20, ElementDiscription = "Top Line", XValue = 450, YValue = 30, FontType = "Font1", Length = 0, IsPrint = true });
            DefaultChq.Add(new tbl_zChequePrinting { BankID = "", AccountNo = "", ElementID = 21, ElementDiscription = "Bottom Line", XValue = 450, YValue = 43, FontType = "Font1", Length = 0, IsPrint = true });
            return DefaultChq;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBankName.Tag != null)
            {
                tbl_zChequePrinting chq = tbl_zChequePrinting.Select(txtBankName.Tag.ToString(), (int)enum_ChequeData.Payee1);
                if (chq != null)
                {
                    foreach (tbl_zChequePrinting detail in newCheque)
                    {
                        detail.BankID = txtBankName.Tag.ToString();
                        detail.Update();
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (tbl_zChequePrinting detail in newCheque)
                    {
                        detail.BankID = txtBankName.Tag.ToString();
                        detail.Insert();
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblStatus2.Text = "";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string status = " | ";
            if (btnCopy.Tag != "Copy")
            {                
                foreach (tbl_zChequePrinting detail in newCheque)
                {
                    tmpCopy.Add(detail);
                }
                status = txtBankName.Text + " bank cheque template copied."; 
                Clear();
                btnCopy.Tag = "Copy";
                btnCopy.Text = "Paste";
                
            }
            else
            {
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = null;
                newCheque.Clear();
                foreach (tbl_zChequePrinting detail in tmpCopy)
                {
                    newCheque.Add(detail);
                }
                
                btnCopy.Tag = "";
                btnCopy.Text = "Copy";
                dgvData.DataSource = newCheque;
                dgvData.Refresh(); 
                tmpCopy.Clear();
                status = ""; 
            }
            lblStatus.Text = status;
        }

        private void Clear()
        {
            //dgvData.Refresh();
            txtBankName.Clear();
            txtBankName.Tag = "";
            //newCheque.Clear();
        }

              

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clnGetDefault.Index)
            {
                //string ss = dgvData[1, e.RowIndex].Value.ToString();
                //int iElementID = Convert.ToInt32(dgvData[1, e.RowIndex].Value.ToString());
                //foreach (tbl_zChequePrinting c in DefaultChequeParameter())
                //{
                //    if (c.ElementID == iElementID)
                //    {
                //        dgvData[clnXValue.Index, e.RowIndex].Value = c.XValue;
                //        dgvData[clnYValue.Index, e.RowIndex].Value = c.YValue;
                //        break;
                //    }
                //}

            }
        }
        int i_Xvalue = 50, i_Yvalue = 0;
        String year;
        String month;
        String date;
        String ChequeDate;
        string sPayee, sAmount, sDate, d1, d2, m1, m2, y1, y2, y3, y4, sAccountPayee, sUndeline;
        string[] sRupee, sPayeeLine;
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            PntDocCheque.DefaultPageSettings.Landscape = true;
            foreach (System.Drawing.Printing.PaperSize item in PntDocCheque.PrinterSettings.PaperSizes)
            {
                string str = item.ToString();
            }  

            PageSetupDialog PageSetupDialog1 = new PageSetupDialog();
            PageSetupDialog1.Document = PntDocCheque;
            PageSetupDialog1.ShowDialog();
            PrintPreviewDialog PrintPreviewDialog1 = new PrintPreviewDialog();
            PrintPreviewDialog1.Document = PntDocCheque;
            PrintPreviewDialog1.Width = 800;
            PrintPreviewDialog1.ShowDialog();
        }

        private string[] SplitWord(string sWord)
        {
            int Counter = 0;
            string[] word = sWord.Split(' '), ArrayStr = { "", "", "" };
            foreach (string str in word)
            {
                Counter += str.Length + 1;
                if (Counter < 50)
                    ArrayStr[0] += str + " ";
                else if (Counter < 100)
                    ArrayStr[1] += str + " ";
                else
                    ArrayStr[2] += str + " ";
            }
            return ArrayStr;
        }
        private string[] SplitWordPayee(string sWord)
        {
            int Counter = 0;
            string[] word = sWord.Split(' '), ArrayStr = { "", "", "" };
            foreach (string str in word)
            {
                Counter += str.Length + 1;
                if (Counter < 16)
                    ArrayStr[0] += str + " ";
                else if (Counter < 32)
                    ArrayStr[1] += str + " ";
                else
                    ArrayStr[2] += str + " ";
            }
            return ArrayStr;
        }
        private string GetValue(enum_ChequeData iElementID)
        {
            switch (iElementID)
            {
                case enum_ChequeData.Payee1: return sPayeeLine[0];
                case enum_ChequeData.Payee2: return sPayeeLine[1];
                case enum_ChequeData.Payee3: return sPayeeLine[2];
                case enum_ChequeData.Payee4: return sPayee;

                case enum_ChequeData.Amount1:
                case enum_ChequeData.Amount2:
                    return sAmount;
                case enum_ChequeData.Rupee1: return sRupee[0];
                case enum_ChequeData.Rupee2: return sRupee[1];
                case enum_ChequeData.Rupee3: return sRupee[2];

                case enum_ChequeData.Date: return sDate;
                case enum_ChequeData.Day1: return d1;
                case enum_ChequeData.Day2: return d2;
                case enum_ChequeData.Month1: return m1;
                case enum_ChequeData.Month2: return m2;
                case enum_ChequeData.Year1: return y1;
                case enum_ChequeData.Year2: return y2;
                case enum_ChequeData.Year3: return y3;
                case enum_ChequeData.Year4: return y4;
                case enum_ChequeData.AccountPayee: return sAccountPayee;
                case enum_ChequeData.TopLine:
                case enum_ChequeData.BottomLine:
                    return sUndeline;
                default: return "";
            }
        }

        private void PntDocCheque_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {                
                StringFormat sf = new StringFormat();
              //  clsFont clsFont = new clsFont();
                ChequeDate = clsFormatter.FormatDate_Short(System.DateTime.Now.Date);
                year = System.DateTime.Now.Year.ToString();
                month = System.DateTime.Now.Month.ToString("00");
                date = System.DateTime.Now.Day.ToString("00");
                sPayee = "TEST CUSTOMER "+clsSecurity.CompanyName.ToString();
                sAmount = "***" + "789301255.00";
                sDate = ChequeDate;
                d1 = date.Substring(0, 1);
                d2 = date.Substring(1, 1);
                m1 = month.Substring(0, 1);
                m2 = month.Substring(1, 1);
                y1 = year.Substring(0, 1);
                y2 = year.Substring(1, 1);
                y3 = year.Substring(2, 1);
                y4 = year.Substring(3, 1);
                sAccountPayee = "** Account Payee Only **";
                sUndeline = "______________________";

                sRupee = SplitWord(clsCommon.CurrencyToWord(decimal.Parse("789301255.00")).ToUpper());
                sPayeeLine = SplitWordPayee(sPayee);

                //clsFont.clsFontSet();
                //string sAccountID = "";
                //tbl_genCompanyAccount account = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, sAccountID);
               // if (account != null)
               
                    foreach (tbl_zChequePrinting detail in newCheque)// tbl_zChequePrinting.SelectAll().Where(p => p.BankID == account.Bank_ID))
                    {
                        if (detail.IsPrint)
                        {
                           // clsFont selectedFont = clsFont.FontList.Find(x => x.sFontID == detail.FontType);

                        //    e.Graphics.DrawString(GetValue((enum_ChequeData)detail.ElementID), selectedFont.oFont, Brushes.Black, new Point(i_Xvalue + detail.XValue, i_Yvalue + detail.YValue), sf);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
    }
}
