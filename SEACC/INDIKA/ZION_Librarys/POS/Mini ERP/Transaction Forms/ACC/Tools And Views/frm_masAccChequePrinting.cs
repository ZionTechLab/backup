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
using Digiteq_Logic;
using System.Drawing.Printing;
using System.Xml;

namespace Digiteq
{
    public partial class frm_masAccChequePrinting : MettroForm
    {
        #region Variables
        string sFormConfigCode;
        public string accChequeRegister_ID = "";
        public int iFormID;

        public bool bNoAccess;
        public DataTable glb_dtChequeToPrint = new DataTable();
        //report
        String year;
        String month;
        String date;
        String ChequeDate;
        #endregion

        #region Form Load
        public frm_masAccChequePrinting()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accFinancial);
            iFormID = clsSecurity.getFormID(FormName.accFinancial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masFinancialMaster_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Financial Year [FY]", 3, iFormID);

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

        #region Btn Save
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
                            if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods.GetHostName() == Split[0]))
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
                    else if (i == 2)
                    {
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCRGID2, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtPayee2, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAmount2, false);

                        clsCommon.SetEnableDisable_NormalDateTimePicker(dtpChequeDate2, true);

                        //asign values                    
                        txtChequeNo2.Text = detail.ChequeNumber;
                        //Please do Update payee .....                
                        dtpChequeDate2.Value = detail.DateCheque;
                        txtAmount2.Text = detail.ChequeAmount.ToString("n2");
                        txtPayee2.Text = detail.Payee;
                        txtCRGID2.Text = detail.ChequeRegister_ID;
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

        #region event DoubleClick
        private void txtBank_DoubleClick(object sender, EventArgs e)
        {
            Search_BankName(txtBank);
        }

        private void txtCRGID1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtCRGID2.Text.Length > 0)
                txtCRGID1.Tag = txtCRGID2.Text.Trim();
            Search_ChequeRegisterNo(1, txtCRGID1);
        }

        private void txtCRGID2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string s = txtCRGID1.Tag.ToString();
            txtCRGID2.Tag = txtCRGID1.Text.Trim();
            Search_ChequeRegisterNo(2, txtCRGID2);
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

        private void txtCRGID2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCRGID2.Tag = txtCRGID1.Text.Trim();
                Search_ChequeRegisterNo(2, txtCRGID2);
            }
        }

        private void txtCRGID1_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ChequeRegisterNo(1, txtCRGID1);
        }
        #endregion

        private void PntDocCheque_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int i_Xvalue = 50, i_Yvalue = 0;

                StringFormat sf = new StringFormat();
                Font Font_Title1 = new Font("Calibri", 09, FontStyle.Bold);
                Font Font_Title2 = new Font("Calibri", 10, FontStyle.Bold);
                Font Font_Title3 = new Font("Calibri", 14, FontStyle.Bold);
                Font Font_Title4 = new Font("Calibri", 14, FontStyle.Regular);

                if (txtBank.Tag.ToString().Length > 0)
                {
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
                        , sUndeline = "______________________";

                   

                    int iLastStr = 16;
                    if (sPayee.Length <= 48)
                        iLastStr = sPayee.Length - 32;
                    string[] sRupee = SplitWord(clsCommon.CurrencyToWord(decimal.Parse(txtAmount1.Text)).ToUpper());


                    #region Rohana
                    if (clsConfig.sCustomChequeFormat == "Rohana")
                    {
                        if (sBankName.Contains("HATTON NATIONAL BANK"))
                        {
                            #region HNB


                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 46), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                            }


                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 10), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 58), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 56), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 82));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 56), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 82));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }
                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 215));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 83));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 125));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 153));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 183));//rupee3

                            e.Graphics.DrawString(d1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 30));//day1
                            e.Graphics.DrawString(d2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 30));//day2
                            e.Graphics.DrawString(m1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 30));//month1
                            e.Graphics.DrawString(m2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 30));//month2
                            e.Graphics.DrawString(y1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 756, i_Yvalue + 30));//year1
                            e.Graphics.DrawString(y2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 778, i_Yvalue + 30));//year2
                            e.Graphics.DrawString(y3, Font_Title1, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 30));//year3
                            e.Graphics.DrawString(y4, Font_Title1, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 30));//year4
                            e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 676, i_Yvalue + 144));//amount

                            #endregion
                        }
                        else if (sBankName.Contains("COMMERCIAL BANK"))
                        {
                            #region COMMERCIAL BANK

                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 38), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 51), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 51), sf);
                            }
                            i_Yvalue += 5;
                            i_Xvalue += 3;

                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 62));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 7));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 7));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 7));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 7));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 7));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 7));//year4
                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 690, i_Yvalue + 124));//amount 
                            #endregion
                        }
                    }
                    #endregion

                    #region Celcius
                    else if (clsConfig.sCustomChequeFormat == "Celcius")
                    {
                        #region Amana Bank PLC || com || ntb || BOC
                        if (txtBank.Tag.ToString() == "7463" || txtBank.Tag.ToString() == "7056" || txtBank.Tag.ToString() == "7162" || txtBank.Tag.ToString() == "7010")
                        {
                            if (sPayee.Length <= 56)
                                iLastStr = sPayee.Length - 40;

                            int[] x = new int[20];
                            int[] y = new int[20];

                            foreach (tbl_zChequePrinting oElament in tbl_zChequePrinting.SelectAll().Where(p => p.BankID == txtBank.Tag.ToString()))
                            {
                                x[oElament.ElementID] = oElament.XValue;
                                y[oElament.ElementID] = oElament.YValue;
                            }

                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 46), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                            }

                            #region Counter Book
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + x[0], i_Yvalue + y[0]), sf);//Date

                            if (sPayee.Length < 20)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + x[1], i_Yvalue + y[1]), sf);
                            else if (sPayee.Length < 40)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + x[2], i_Yvalue + y[2]), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, sPayee.Length - 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 85));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + x[2], i_Yvalue + y[2]), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 85));//payee2
                                e.Graphics.DrawString(sPayee.Substring(40, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 110));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + x[3], i_Yvalue + y[3]));//amount 

                            #endregion

                            #region Cheque Area
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + x[4], i_Yvalue + y[4]));//Payee //ok

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + x[5], i_Yvalue + y[5]));//rupee1 ok              
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + x[6], i_Yvalue + y[6]));//rupee2 ok
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + x[7], i_Yvalue + y[7]));//rupee3 ok

                            e.Graphics.DrawString(d1, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[8], i_Yvalue + y[8]));//day1
                            e.Graphics.DrawString(d2, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[9], i_Yvalue + y[9]));//day2
                            e.Graphics.DrawString(m1, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[10], i_Yvalue + y[10]));//month1
                            e.Graphics.DrawString(m2, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[11], i_Yvalue + y[11]));//month2                
                            e.Graphics.DrawString(y3, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[12], i_Yvalue + y[12]));//year3
                            e.Graphics.DrawString(y4, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[13], i_Yvalue + y[13]));//year4

                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + x[14], i_Yvalue + y[14]));//amount
                            #endregion
                        }
                        #endregion
                        #region HNB
                        else if (sBankName.Contains("HATTON NATIONAL BANK"))
                        {
                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 30), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                            }
                            i_Yvalue += 5;
                            i_Xvalue += 3;

                            if (sPayee.Length <= 56)
                                iLastStr = sPayee.Length - 40;

                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 50, i_Yvalue + 12), sf);//Date
                            if (sPayee.Length < 20)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 35), sf);
                            else if (sPayee.Length < 40)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, sPayee.Length - 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 85), sf);//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 85), sf);//payee2
                                e.Graphics.DrawString(sPayee.Substring(40, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue - 15, i_Yvalue + 110), sf);//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 210));//amount


                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 60));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 235, i_Yvalue + 100));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 130));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 160));//rupee3

                            e.Graphics.DrawString(d1, Font_Title2, Brushes.Black, new Point(i_Xvalue + 645, i_Yvalue + 8));//day1
                            e.Graphics.DrawString(d2, Font_Title2, Brushes.Black, new Point(i_Xvalue + 670, i_Yvalue + 8));//day2
                            e.Graphics.DrawString(m1, Font_Title2, Brushes.Black, new Point(i_Xvalue + 695, i_Yvalue + 8));//month1
                            e.Graphics.DrawString(m2, Font_Title2, Brushes.Black, new Point(i_Xvalue + 720, i_Yvalue + 8));//month2
                            e.Graphics.DrawString(y1, Font_Title2, Brushes.Black, new Point(i_Xvalue + 745, i_Yvalue + 8));//year1
                            e.Graphics.DrawString(y2, Font_Title2, Brushes.Black, new Point(i_Xvalue + 770, i_Yvalue + 8));//year2
                            e.Graphics.DrawString(y3, Font_Title2, Brushes.Black, new Point(i_Xvalue + 795, i_Yvalue + 8));//year3
                            e.Graphics.DrawString(y4, Font_Title2, Brushes.Black, new Point(i_Xvalue + 820, i_Yvalue + 8));//year4

                            e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 670, i_Yvalue + 125));//amount 
                        }
                        #endregion                      
                        #region NATIONAL DEVELOPMENT BANK PLC
                        else if (sBankName.Contains("NATIONAL DEVELOPMENT BANK PLC"))
                        {
                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 400, i_Yvalue + 38), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 400, i_Yvalue + 51), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 400, i_Yvalue + 51), sf);
                            }

                            if (sPayee.Length <= 56)
                                iLastStr = sPayee.Length - 40;

                            #region Counter Book
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 40, i_Yvalue + 8), sf);//Date
                            if (sPayee.Length < 20)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 10, i_Yvalue + 30), sf);
                            else if (sPayee.Length < 40)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 53), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, sPayee.Length - 20), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 78));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 53), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 78));//payee2
                                e.Graphics.DrawString(sPayee.Substring(40, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 103));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 45, i_Yvalue + 200));//amount 
                            #endregion
                            #region Cheque Area
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 230, i_Yvalue + 65));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 103));//rupee1 ok              
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 133));//rupee2 ok
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 163));//rupee3 ok

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 645, i_Yvalue + 5));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 670, i_Yvalue + 5));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 695, i_Yvalue + 5));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 720, i_Yvalue + 5));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 795, i_Yvalue + 5));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 820, i_Yvalue + 5));//year4

                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 670, i_Yvalue + 120));//amount ok
                            #endregion
                        }
                        #endregion
                        #region PAN ASIA BANK
                        else if (sBankName.Contains("PAN ASIA BANK"))
                        {
                            if (sPayee.Length <= 56)
                                iLastStr = sPayee.Length - 40;

                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 46), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 58), sf);
                            }

                            #region Counter Book
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 30, i_Yvalue), sf);//Date
                            if (sPayee.Length < 20)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 20, i_Yvalue + 30), sf);
                            else if (sPayee.Length < 40)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 40), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, sPayee.Length - 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 65));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 40), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(20, 20), Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 65));//payee2
                                e.Graphics.DrawString(sPayee.Substring(40, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue + 5, i_Yvalue + 90));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 45, i_Yvalue + 190));//amount 
                            #endregion

                            #region Cheque Area
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 72));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 113));//rupee1 ok              
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 210, i_Yvalue + 140));//rupee2 ok
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 210, i_Yvalue + 170));//rupee3 ok

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 650, i_Yvalue + 18));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 675, i_Yvalue + 18));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 700, i_Yvalue + 18));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 725, i_Yvalue + 18));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 800, i_Yvalue + 18));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 825, i_Yvalue + 18));//year4

                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 670, i_Yvalue + 140));//amount ok
                            #endregion
                        } 
                        #endregion
                    }
                    #endregion

                    #region Other
                    else
                    {
                        if (chkAccPayee.Checked && !sBankName.Contains("COMMERCIAL BANK") && !sBankName.Contains("HATTON NATIONAL BANK") && !sBankName.Contains("NATIONAL DEVELOPMENT BANK PLC"))
                        {
                            e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 38), sf);
                            e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 50), sf);
                            e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 340, i_Yvalue + 51), sf);
                        }

                        if (sBankName.Contains("SAMPATH BANK"))
                        {
                            #region SAMPATH BANK
                            //case "SAMPATH BANK":
                            //Sampath Bank 
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 2), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 20, i_Yvalue + 85), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue + 20, i_Yvalue + 85), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 111));//payee2

                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue + 20, i_Yvalue + 85), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 111));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 137));//payee2
                            }
                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 245));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 63));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 220, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 10));//day1
                            e.Graphics.DrawString(d2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 10));//day2
                            e.Graphics.DrawString(m1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 10));//month1
                            e.Graphics.DrawString(m2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 10));//month2                            
                            e.Graphics.DrawString(y3, Font_Title1, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 10));//year3
                            e.Graphics.DrawString(y4, Font_Title1, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 10));//year4
                            e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 676, i_Yvalue + 127));//amount
                            //break;
                            #endregion
                        }
                        else if (sBankName.Contains("HATTON NATIONAL BANK"))
                        {
                            #region HNB
                            {
                                #region AccountPayee
                                if (chkAccPayee.Checked)
                                {
                                    e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 30), sf);
                                    e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                                    e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                                }
                                #endregion 

                                #region Other
                                e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 10), sf);//Date
                                if (sPayee.Length < 16)
                                    e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 58), sf);
                                else if (sPayee.Length < 32)
                                {
                                    e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 56), sf);//payee1
                                    e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 82));//payee2
                                }
                                else
                                {
                                    e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 56), sf);//payee1
                                    e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 82));//payee2
                                    e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                                }

                                e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 215));//amount
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 72));//Payee

                                e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 113));//rupee1                
                                e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 141));//rupee2
                                e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 171));//rupee3

                                e.Graphics.DrawString(d1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 20));//day1
                                e.Graphics.DrawString(d2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 20));//day2
                                e.Graphics.DrawString(m1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 20));//month1
                                e.Graphics.DrawString(m2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 20));//month2
                                e.Graphics.DrawString(y1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 756, i_Yvalue + 20));//year1
                                e.Graphics.DrawString(y2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 778, i_Yvalue + 20));//year2
                                e.Graphics.DrawString(y3, Font_Title1, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 20));//year3
                                e.Graphics.DrawString(y4, Font_Title1, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 20));//year4
                                e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 676, i_Yvalue + 127));//amount 
                                #endregion
                            }
                            //break;
                            #endregion
                        }
                        else if (sBankName.Contains("PEOPLE’S BANK") || sBankName.Contains("PEOPLES BANK"))
                        {
                            #region PEOPLE'S BANK
                            //case "PEOPLE’S BANK":
                            //Peoples Bank                
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 53), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 53), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 78));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 53), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 78));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 103));//payee2
                            }
                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 63));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 15));//day1
                            e.Graphics.DrawString(d2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 15));//day2
                            e.Graphics.DrawString(m1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 15));//month1
                            e.Graphics.DrawString(m2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 15));//month2                
                            e.Graphics.DrawString(y3, Font_Title1, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 15));//year3
                            e.Graphics.DrawString(y4, Font_Title1, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 15));//year4
                            e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 676, i_Yvalue + 127));//amount
                            //break; 
                            #endregion
                        }
                        else if (sBankName.Contains("SEYLAN BANK"))
                        {
                            #region SEYLAN BANK
                            //case "SEYLAN BANK":
                            //Seylan Bank    
                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }
                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 62));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 11));//day1
                            e.Graphics.DrawString(d2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 11));//day2
                            e.Graphics.DrawString(m1, Font_Title1, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 11));//month1
                            e.Graphics.DrawString(m2, Font_Title1, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 11));//month2                
                            e.Graphics.DrawString(y3, Font_Title1, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 11));//year3
                            e.Graphics.DrawString(y4, Font_Title1, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 11));//year4
                            e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(i_Xvalue + 676, i_Yvalue + 127));//amount
                            //break; 
                            #endregion
                        }

                        else if (sBankName.Contains("COMMERCIAL BANK"))
                        {
                            #region COMMERCIAL BANK



                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 32), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 45), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 45), sf);
                            }
                            i_Yvalue += 5;
                            i_Xvalue += 3;

                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 62));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 11));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 11));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 11));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 11));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 11));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 11));//year4
                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 690, i_Yvalue + 127));//amount 
                            #endregion
                        }
                        else if (sBankName.Contains("BANK OF CEYLON"))
                        {
                            #region BANK OF CEYLON



                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 30), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 450, i_Yvalue + 43), sf);
                            }
                            i_Yvalue += 5;
                            i_Xvalue += 3;

                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 62));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 650, i_Yvalue + 9));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 675, i_Yvalue + 9));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 699, i_Yvalue + 9));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 725, i_Yvalue + 9));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 799, i_Yvalue + 9));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 823, i_Yvalue + 9));//year4
                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 690, i_Yvalue + 124));//amount 
                            #endregion
                        }
                        else
                        {
                            #region OTHER BANK
                            if (chkAccPayee.Checked)
                            {
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 38), sf);
                                e.Graphics.DrawString(sAccountPayee, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 51), sf);
                                e.Graphics.DrawString(sUndeline, Font_Title1, Brushes.Black, new Point(i_Xvalue + 200, i_Yvalue + 51), sf);
                            }
                            i_Yvalue += 5;
                            i_Xvalue += 3;

                            e.Graphics.DrawString(sDate, Font_Title1, Brushes.Black, new Point(i_Xvalue + 57, i_Yvalue + 5), sf);//Date
                            if (sPayee.Length < 16)
                                e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);
                            else if (sPayee.Length < 32)
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                            }
                            else
                            {
                                e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 60), sf);//payee1
                                e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 84));//payee2
                                e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(i_Xvalue, i_Yvalue + 108));//payee2
                            }

                            e.Graphics.DrawString(sAmount, Font_Title1, Brushes.Black, new Point(i_Xvalue + 60, i_Yvalue + 205));//amount
                            e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(i_Xvalue + 240, i_Yvalue + 62));//Payee

                            e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(i_Xvalue + 245, i_Yvalue + 103));//rupee1                
                            e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 131));//rupee2
                            e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(i_Xvalue + 225, i_Yvalue + 161));//rupee3

                            e.Graphics.DrawString(d1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 653, i_Yvalue + 7));//day1
                            e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 678, i_Yvalue + 7));//day2
                            e.Graphics.DrawString(m1, Font_Title4, Brushes.Black, new Point(i_Xvalue + 702, i_Yvalue + 7));//month1
                            e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(i_Xvalue + 728, i_Yvalue + 7));//month2                
                            e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(i_Xvalue + 802, i_Yvalue + 7));//year3
                            e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(i_Xvalue + 826, i_Yvalue + 7));//year4
                            e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(i_Xvalue + 690, i_Yvalue + 124));//amount

                            #endregion
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
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
                else if (Counter < 105)
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

    }
}
