using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Drawing.Printing;
using System.Xml;

namespace Digiteq
{
    public partial class frm_masAccChequePrinting_New : MettroForm
    {
        #region Variables

        public string accChequeRegister_ID = "";
 

  
        public DataTable glb_dtChequeToPrint = new DataTable();
        //report
        String year;
        String month;
        String date;
        String ChequeDate;
        #endregion

        #region Form Load
        public frm_masAccChequePrinting_New()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accFinancial);
            iFormID = clsSecurity.getFormID(FormName.accFinancial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masFinancialMaster_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, "Financial Year [FY]", 3, iFormID);

            if (accChequeRegister_ID.Length > 0)
                FillDetails(1, accChequeRegister_ID);

        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool bIsPrinted = false, bStatus = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                tbl_securityReportPermission oPermission = tbl_securityReportPermission.Select(clsSecurity.UserIDLoged, "BSS/SD/0010", clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oPermission != null)
                {
                    tbl_accChequeRegister oCheque = tbl_accChequeRegister.Select(accChequeRegister_ID);
                    if (oCheque != null && oCheque.PrintCount > 0)
                    {
                        bIsPrinted = true;
                        if (oPermission.AllowRePrint)
                            bIsPrinted = false;
                    }

                    if (!bIsPrinted && oPermission.AllowPrint)
                    {
                        year = dtpChequeDate1.Value.Year.ToString();
                        month = dtpChequeDate1.Value.Month.ToString("00");
                        date = dtpChequeDate1.Value.Day.ToString("00");
                        ChequeDate = clsFormatter.FormatDate_Short(dtpChequeDate1.Value.Date);

                        string sFormula = "";
                        PntDocCheque.DefaultPageSettings.Landscape = clsConfig.bChequeLandscape;
                        string sContains = txtBank.Text.Trim().ToUpper();
                        if (sContains.Contains("BANK OF CEYLON") || sContains.Contains("SAMPATH BANK") || sContains.Contains("SEYLAN BANK") || sContains.Contains("HATTON NATIONAL BANK") || sContains.Contains("PEOPLE’S BANK") || sContains.Contains("PEOPLES BANK") || sContains.Contains("COMMERCIAL BANK"))
                        {
                            string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                            if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods_Local.GetHostName() == Split[0]))
                            {
                                CreateChequeXMLFile();
                                bStatus = false;
                            }
                            else
                                bStatus = true;
                        }
                        else
                            bStatus = true;

                        if (bStatus)
                        {
                            PrintDialog pdi = new PrintDialog();
                            pdi.Document = PntDocCheque;
                            if (pdi.ShowDialog() == DialogResult.OK)
                            {
                                PrintPreviewDialog PrintPreviewDialog1 = new PrintPreviewDialog();
                                PrintPreviewDialog1.Document = PntDocCheque;
                                PrintPreviewDialog1.Width = 800;
                                PrintPreviewDialog1.ShowDialog();
                            }
                        }
                        oCheque.PrintedUser_ID = clsSecurity.UserIDLoged;
                        oCheque.PrintedTerminal_ID = clsSecurity.TerminalID;
                        oCheque.DatePrinted = clsSecurity.getServerDateTime();
                        oCheque.PrintCount++;
                        oCheque.Update();
                    }
                    else if (!oPermission.AllowPrint)
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToPrint), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToPrint), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ClearFields
        private void ClearFields()
        {
            // IsUpdate = false;
            // clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCRGID1, true);
            //   clsCommon.SetEnableDisable_NormalTextbox(txtPayee1, true);
            //    clsCommon.SetEnableDisable_NormalDateTimePicker(dtpChequeDate1, true);

            txtPayee1.Clear();
            txtCRGID1.Clear();

        }
        #endregion

        #region FillDetails
        private void FillDetails(int i, string sid)
        {
            tbl_accChequeRegister detail = tbl_accChequeRegister.Select(sid);
            if (detail != null)
            {
                tbl_genCompanyAccount oAcc = tbl_genCompanyAccount.Select(detail.CompanyAccount_ID);
                if (oAcc != null)
                {
                    //set the update flag and Locked
                    //  IsUpdate = true;
                    if (i == 1)
                    {
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCRGID1, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtPayee1, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAmount1, false);

                        clsCommon.SetEnableDisable_NormalDateTimePicker(dtpChequeDate1, true);

                        //asign values                   
                        txtChequeNo1.Text = detail.ChequeNumber;
                        //Please do Update payee .....                
                        dtpChequeDate1.Value = detail.DateCheque;
                        txtAmount1.Text = detail.ChequeAmount.ToString("n2");
                        txtPayee1.Text = detail.Payee;
                        txtCRGID1.Text = detail.ChequeRegister_ID;
                        txtBank.Text = clsGenaralName.getName_Bank(oAcc.Bank_ID);
                        txtBank.Tag = oAcc.Bank_ID;

                    }
                }
            }
        }
        #endregion

        #region Search Methods
        private void Search_ChequeRegisterNo(int i, TextBox myTextBox)
        {
            try
            {
                clsSearch.Search_MasterChequeRegister_Accounts(myTextBox);
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    myTextBox.Text = frmSearchMaster.s_SearchID;
                }
                FillDetails(i, myTextBox.Text);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Bank Details
        private void Search_BankName(TextBox myTextBox)
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();

                clsSearch.passValue_CompanyAccount();

                frmhelpsearch.ShowDialog();
                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        myTextBox.Text = frmSearchTransaction.s_SearchText;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        myTextBox.Tag = frmSearchTransaction.s_SearchID;

                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);

            }
        }
        #endregion

        #region Event DoubleClick
        private void txtBank_DoubleClick(object sender, EventArgs e)
        {
            Search_BankName(txtBank);
        }
        private void txtCRGID1_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeRegisterNo(1, txtCRGID1);
        }
        #endregion

        #region Event KeyDown

        private void txtFinancialTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_BankName(txtBank);
            }
        }

        private void txtCRGID1_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ChequeRegisterNo(1, txtCRGID1);
        }
        #endregion

        #region Print Page
        private void PntDocCheque_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                tbl_accChequeRegister detail = tbl_accChequeRegister.Select(accChequeRegister_ID);
                if (detail != null)
                {
                    tbl_genCompanyAccount oAccount = tbl_genCompanyAccount.Select(detail.CompanyAccount_ID);

                    if (txtBank.Tag.ToString().Length > 0)
                    {
                        #region Value Initialize
                        StringFormat sf = new StringFormat();
                        string sbankCode = txtBank.Tag.ToString();
                        string sEndMarks = clsConfig.bDisplay_ChequePrint_AmountEndWith_StarMark ? "***" : "";
                        string sBankName = txtBank.Text.Trim().ToUpper();
                        string sPayee = txtPayee1.Text.ToString()
                            , sAmount = "***" + txtAmount1.Text.ToString() + sEndMarks
                            , sDate = ChequeDate
                            , d1 = date.Substring(0, 1)
                            , d2 = date.Substring(1, 1)
                            , m1 = month.Substring(0, 1)
                            , m2 = month.Substring(1, 1)
                            , y1 = year.Substring(0, 1)
                            , y2 = year.Substring(1, 1)
                            , y3 = year.Substring(2, 1)
                            , y4 = year.Substring(3, 1)
                            , sAccountPayee = "** Account Payee Only **"
                            , sUnderline = "______________________";
                        #endregion
                        
                        int iCounterPayeeMaxLength = 20;

                        string[] sRupeeArr = SplitWord(clsCommon.CurrencyToWord(decimal.Parse(txtAmount1.Text)).ToUpper());

                        string[] sPayeeArr = null;
                        if(sPayee.Length > 20)
                            sPayeeArr = SplitPayee(sPayee);

                        #region Intialize Array
                        int[] x = new int[22];
                        int[] y = new int[22];
                        Font[] font = new Font[22];
                        #endregion

                        int i_Xvalue = 0, i_Yvalue = 0, i_CBLength = 0;
                        tbl_zChequeFormat oFormat = tbl_zChequeFormat.Select(oAccount.ChequeFormat_ID);
                        if (oFormat != null && oFormat.IsActive == true && oFormat.ChequeFormat_ID != -1)
                        {
                            i_Xvalue = oFormat.XMargin;
                            i_Yvalue = oFormat.YMargin;
                            i_CBLength = chkCounterBookPrint.Checked ? 0 : oFormat.CounterBookLength;

                            #region Fill Formats
                            foreach (tbl_zChequeFormat_Detail oFormats in tbl_zChequeFormat_Detail.SelectAll().Where(p => p.ChequeFormat_ID == oFormat.ChequeFormat_ID))
                            {
                                tbl_zFont oFont = tbl_zFont.Select(oFormats.FontType_ID.ToString());
                                Font Font = new Font(oFont.FontName, oFont.Size);

                                x[oFormats.Element_ID] = i_Xvalue + oFormats.XValue;
                                y[oFormats.Element_ID] = i_Yvalue + oFormats.YValue;
                                font[oFormats.Element_ID] = Font;
                            }
                            #endregion

                            #region Print Cheque
                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUnderline, font[20], Brushes.Black, new Point(x[20] - i_CBLength, y[20]), sf); //Top line
                                e.Graphics.DrawString(sAccountPayee, font[19], Brushes.Black, new Point(x[19] - i_CBLength, y[19]), sf); //Acount payee
                                e.Graphics.DrawString(sUnderline, font[21], Brushes.Black, new Point(x[21] - i_CBLength, y[21]), sf); //Bottom Line
                            }

                            #region Counter Book
                            if (chkCounterBookPrint.Checked)
                            {
                                e.Graphics.DrawString(sDate, font[10], Brushes.Black, new Point(x[10], y[10]), sf);//Date Value

                                if (sPayee.Length <= iCounterPayeeMaxLength)
                                    e.Graphics.DrawString(sPayee, font[0], Brushes.Black, new Point(x[0], y[0]), sf);//payee line 1
                                else
                                {
                                    e.Graphics.DrawString(sPayeeArr[0], font[1], Brushes.Black, new Point(x[1], y[1]), sf);//payee line 2
                                    e.Graphics.DrawString(sPayeeArr[1], font[2], Brushes.Black, new Point(x[2], y[2]));//payee line 3
                                    e.Graphics.DrawString(sPayeeArr[2], font[3], Brushes.Black, new Point(x[3], y[3]));//payee line 4
                                }

                                e.Graphics.DrawString(sAmount, font[5], Brushes.Black, new Point(x[5], y[5]));//amount line 1
                            }
                            #endregion

                            #region Cheque Area
                            e.Graphics.DrawString(sPayee, font[4], Brushes.Black, new Point(x[4] - i_CBLength, y[4]));//Payee

                            e.Graphics.DrawString(sRupeeArr[0], font[7], Brushes.Black, new Point(x[7] - i_CBLength, y[7]));//rupee value 1              
                            e.Graphics.DrawString(sRupeeArr[1], font[8], Brushes.Black, new Point(x[8] - i_CBLength, y[8]));//rupee value 2
                            e.Graphics.DrawString(sRupeeArr[2], font[9], Brushes.Black, new Point(x[9] - i_CBLength, y[9]));//rupee value 3

                            e.Graphics.DrawString(d1, font[11], Brushes.Black, new Point(x[11] - i_CBLength, y[11]));//day value 1
                            e.Graphics.DrawString(d2, font[12], Brushes.Black, new Point(x[12] - i_CBLength, y[12]));//day value 2

                            e.Graphics.DrawString(m1, font[13], Brushes.Black, new Point(x[13] - i_CBLength, y[13]));//month value 1
                            e.Graphics.DrawString(m2, font[14], Brushes.Black, new Point(x[14] - i_CBLength, y[14]));//month value 2

                            //e.Graphics.DrawString(y1, font[15], Brushes.Black, new Point(x[15] - i_CounterBook, y[15]));//year value 1
                            //e.Graphics.DrawString(y2, font[16], Brushes.Black, new Point(x[16] - i_CounterBook, y[16]));//year value 2
                            e.Graphics.DrawString(y3, font[17], Brushes.Black, new Point(x[17] - i_CBLength, y[17]));//year value 3
                            e.Graphics.DrawString(y4, font[18], Brushes.Black, new Point(x[18] - i_CBLength, y[18]));//year value 4

                            e.Graphics.DrawString(sAmount, font[6], Brushes.Black, new Point(x[6] - i_CBLength, y[6]));//amount line 2
                            #endregion
                            #endregion
                        }
                        else if (oFormat.IsActive == false && oFormat.ChequeFormat_ID != -1)
                        {
                            MessageBox.Show("This cheque format is not activated", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Cheque format is not apply to this account", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Help Method
        private string[] SplitWord(string sWord)
        {
            int Counter = 0;
            string[] word = sWord.Split(' '), ArrayStr = { "", "", "" };
            foreach (string str in word)
            {
                Counter += str.Length + 1;
                if (Counter < 50)
                    ArrayStr[0] += str + " ";
                else if (Counter < 105)
                    ArrayStr[1] += str + " ";
                else
                    ArrayStr[2] += str + " ";
            }
            return ArrayStr;
        }

        private string[] SplitPayee(string sWord)
        {
            int Counter = 0;
            string[] word = sWord.Split(' '), ArrayStr = { "", "", "" };
            foreach (string str in word)
            {
                Counter += str.Length + 1;
                if (Counter < 20)
                    ArrayStr[0] += str + " ";
                else if (Counter < 40)
                    ArrayStr[1] += str + " ";
                else
                    ArrayStr[2] += str + " ";
            }
            return ArrayStr;
        }

        private void CreateChequeXMLFile()
        {
            string sPath = clsConfig.sRemortDesktopExportPath;
            XmlTextWriter writer = new XmlTextWriter(@sPath + "cheque_" + clsSecurity.getServerDateTime().ToString("ddMMyyHHmm") + ".xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Cheque");

            writer.WriteStartElement("Cheque_Date");
            writer.WriteString(ChequeDate);
            writer.WriteEndElement();
            writer.WriteStartElement("Payee");
            writer.WriteString(txtPayee1.Text.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Bank");
            writer.WriteString(txtBank.Text.Trim());
            writer.WriteEndElement();
            writer.WriteStartElement("Amount");
            writer.WriteString(txtAmount1.Text.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("IsPayee");
            writer.WriteString(chkAccPayee.Checked.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("date");
            writer.WriteString(date);
            writer.WriteEndElement();
            writer.WriteStartElement("month");
            writer.WriteString(month);
            writer.WriteEndElement();
            writer.WriteStartElement("year");
            writer.WriteString(year);
            writer.WriteEndElement();
            writer.WriteStartElement("CurrencyToWord");
            writer.WriteString(clsCommon.CurrencyToWord(decimal.Parse(txtAmount1.Text)).ToUpper());
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            //MessageBox.Show("XML File created ! ");
        }

        #endregion
        
    }
}
