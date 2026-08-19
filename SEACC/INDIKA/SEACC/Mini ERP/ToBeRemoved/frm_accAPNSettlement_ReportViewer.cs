using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq.DataSets;
using Digiteq.DataSets.ACC;
using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_accAPNSettlement_ReportViewer : Form
    {
        #region Variables
        //from Receipt
        public bool bIsFromReceipt = false;
        public string rcpCustomerID = "default";
        public string rcpInvoiceID = "default";
        public string rcpReceiptID = "default";
        public DateTime rcpDate = clsSecurity.getServerDateTime();
        public decimal rcpCashAmount = 0;

        private BindingSource bsInward = new BindingSource();
        private BindingSource nsOutward = new BindingSource();
        private string sFilterQuary_Inword = "";

        public DataTable dtAllRecodes = new DataTable();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_accAPNSettlement glb_dts_accAPNSettlement = new dts_accAPNSettlement();
        string sFormConfigCode;

        public int iFormID;

        //for security handle
        public bool bNoAccess;
     //   public bool bHasChecked;
     //   public bool bHasApproved;
      //  DateTime glbApprovedDate = clsSecurity.getServerDateTime();
      //  DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region Form Load
        public frm_accAPNSettlement_ReportViewer()
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accAPNSettlement);
            //iFormID = clsSecurity.getFormID(FormName.accAPNSettlement);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            this.Text = clsFormatter.DigiteqTitle + " - APN Settlement Report ";

            iFormID = clsSecurity.getFormID(FormName.accAPNSettlement);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
           
            WindowState = FormWindowState.Maximized;
        }

        private void frm_accAPNSettlement_ReportViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "APN Settlement Report", 6, iFormID);

            ClearFields();
            //Refresh();
            //ShowDialog();
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtCreditorID.Clear();
            txtCreditorID.Tag = null;
            txtAPNNo.Tag = null;
            txtAPNNo.Clear();
            chkAPNNo.Checked = false;
            chkCreditorDetails.Checked = false;
            cmbPaymentMode.SelectedIndex = 0;

            crystalReportViewer1.Refresh();
        }
        #endregion

        #region Events Keydown
        private void frm_bpsChequeRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        #endregion

        #region Events DoubleClick
        private void txtCreditorID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtCreditorID);
        }
        private void txtAPNNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_TransactionAccountPayableNote(ref txtAPNNo);
        }
        #endregion

        #region Events KeyUp Inward
        private void txtAPNNo_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void txtCreditorID_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        #endregion

        #region Event Checkbox ChechChange
        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreditorDetails.Checked)
                txtCreditorID.Enabled = false;
            else
            {
                txtCreditorID.Enabled = true;
                txtCreditorID.Text = "";
            }
        }

        private void chkAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAPNNo.Checked)
                txtAPNNo.Enabled = false;
            else
            {
                txtAPNNo.Enabled = true;
                txtAPNNo.Text = "";
            }
        }

        private void chkPaymentMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaymentMode.Checked)
                cmbPaymentMode.Enabled = false;
            else
            {
                cmbPaymentMode.Enabled = true;
                cmbPaymentMode.SelectedIndex = 0;
            }
        }
        #endregion
    
        #region Search Methods
        private void Search_Account()
        {
            //try
            //{
            //    Form frmhelpsearch = new frmSearchTransaction();
            //    if (txtCreditorID.Tag != null && txtCreditorID.Tag.ToString().Length > 0)
            //        clsSearch.passValue_CustomerAccountByCustomerID(txtCreditorID.Tag.ToString());
            //    else
            //        clsSearch.passValue_CustomerAccount();

            //    frmhelpsearch.ShowDialog();
            //    if (frmSearchTransaction.s_SearchID.Length > 0)
            //    {
            //        if (frmSearchTransaction.s_SearchText.Length > 0)
            //            txtAPNNo.Text = frmSearchTransaction.s_SearchID;
            //        if (frmSearchTransaction.s_SearchID.Length > 0)
            //            txtAPNNo.Tag = frmSearchTransaction.s_SearchID;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //}
        }
        private void Search_CustomerID()
        {
            //try
            //{
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.Search_MasterSupplier();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //        if (frmSearchMaster.s_SearchText.Length > 0)
            //            txtCreditorID.Text = frmSearchMaster.s_SearchText;
            //        if (frmSearchMaster.s_SearchID.Length > 0)
            //            txtCreditorID.Tag = frmSearchMaster.s_SearchID;
            //        createFilterQuary_Inward(txtCreditorID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //}
        }
        #endregion


        #region Export Data
        private void btnExport_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = "Exported from gridview";


            // storing header part in Excel
            //for (int i = 1; i < dgvMain.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[1, i] = dgvMain.Columns[i - 1].HeaderText;
            //}



            //// storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvMain.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvMain.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvMain.Rows[i].Cells[j].Value.ToString();
            //    }
            //}


            // save the application
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            app.Quit();

        } 
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Refresh(); 
        }

        private void Refresh()
        {
            bool bCreditorSelected = false;
            bool bPaymentMode = false;
            bool bAPNNoSelected = false;

            string sRptID = clsAutocode.getReportID(enum_ReportName.RG_APN_Settlement_Report);

            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
            if (clsHelpMethods_Local.GetReportPath(sRptID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            {

                string sFilter = "", sFormula = "";

                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");



                if (txtCreditorID.Tag != null && txtCreditorID.Tag.ToString().Length > 0)
                    bCreditorSelected = true;
                if (txtAPNNo.Tag != null && txtAPNNo.Tag.ToString().Length > 0)
                    bCreditorSelected = true;
                if (cmbPaymentMode.SelectedIndex != 0)
                    bPaymentMode = true;



                if (clsSecurity.PermissionToPrint_WithMessage(sRptID))
                {
                    try
                    {
                        if (sReportPath != "")
                        {
                            glb_dts_accAPNSettlement.Clear();
                            glb_dtsReportExport.Clear();
                            Cursor = Cursors.WaitCursor;

                            List<tbl_accAccountPayableNote> oAPNList;

                            #region Filter - Creditor
                            if (bCreditorSelected)
                            {
                                oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == txtCreditorID.Tag.ToString() && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                                sFilter += " Creditor Name : " + txtCreditorID.Text.Trim();
                            }
                            else if (bAPNNoSelected)
                            {
                                oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID == txtAPNNo.Text.Trim() && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                                sFilter += " Account Payable Note ID : " + txtAPNNo.Text.Trim();
                            }
                            else if (bPaymentMode)
                            {
                                bool bStatus = false;
                                if (cmbPaymentMode.SelectedIndex == 1)
                                    bStatus = true;
                                else if (cmbPaymentMode.SelectedIndex == 2)
                                    bStatus = false;
                                oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.IsSeattled == bStatus && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                                sFilter += " Payment Mode : " + cmbPaymentMode.SelectedItem;
                            }
                            else
                            {
                                oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date).ToList();
                                //oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= DateTime.Parse("2017-06-01") && p.AccountPayableNoteDate.Date <= DateTime.Parse("2017-07-14")).ToList();
                            }
                            #endregion

                            string sPVID = "";
                            DateTime dtpPVDate = DateTime.Now;
                            decimal dTotalAmount = 0, dSettleAmount = 0;
                            foreach (tbl_accAccountPayableNote oAPN in oAPNList)
                            {
                                foreach (tbl_accPaymentVoucher_Detail oPVD in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID))
                                {
                                    //sPVID += oPVD.PaymentVoucher_ID;
                                    //dSettleAmount += oPVD.SettleAmount;

                                    tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(oPVD.PaymentVoucher_ID);
                                    //foreach (tbl_accPaymentVoucher oPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.AccountPayableNote_ID == oAPN.AccountPayableNote_ID))
                                    //{
                                    //    //dTotalAmount += ;
                                    //    dtpPVDate = oPV.PaymentVoucherDate;
                                    //}
                                    if (oPV != null)
                                    {
                                        glb_dts_accAPNSettlement.dt_accPaymentVoucherDetail.Adddt_accPaymentVoucherDetailRow(oAPN.AccountPayableNote_ID, oPVD.PaymentVoucher_ID, DateTime.Parse(oPV.PaymentVoucherDate.ToShortDateString()),
                                            oPV.TotalAmount, oPVD.SettleAmount, "0", DateTime.Now);
                                    }
                                }
                                //glb_dts_accAPNSettlement.dt_accAPNSettlement.Adddt_accAPNSettlementRow(oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate,
                                //        oAPN.Supplier_ID, clsGenaralName.getName_Supplier(oAPN.Supplier_ID), oAPN.SubTotal, oAPN.IsSeattled, sPVID, DateTime.Parse(dtpPVDate.ToShortDateString()),
                                //        dTotalAmount, dSettleAmount, "", DateTime.Now);

                                glb_dts_accAPNSettlement.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate,
                                            oAPN.Supplier_ID, clsGenaralName.getName_Supplier(oAPN.Supplier_ID), oAPN.SubTotal, oAPN.IsSeattled);
                            }

                            glb_dts_accAPNSettlement.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                            print(sReportPath, glb_dts_accAPNSettlement, glb_dtsReportExport.dt_rptParameter);
                            //frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                            //rpt.print(sRptPath, glb_dts_accAPNSettlement, glb_dtsReportExport.dt_rptParameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        glb_dts_accAPNSettlement.Clear();
                        glb_dtsReportExport.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        public void print(string path, DataSet ReportDataSet, DataTable ParameterData)
        {
            print(path, ReportDataSet, ParameterData, false);
        }

        public string print(string path, DataSet ReportDataSet, DataTable ParameterData, bool isExportToPDF)
        {
            string returnvalue = "";
            //if (!clsConfig.bProductActivated)
            //{
            //    MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string s_Path = "";

                    if (path != "")
                    {
                        ReportDocument objRpt = new ReportDocument();

                        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                        s_Path += path;

                        objRpt.Load(s_Path);
                        objRpt.SetDataSource(ReportDataSet);

                        #region Set Server Detail for Report
                        ConnectionInfo connInfo = new ConnectionInfo();
                        connInfo.ServerName = clsSecurity.getRegServerName();
                        connInfo.DatabaseName = clsSecurity.decryptPassword(clsSecurity.getRegDatabaseName());
                        connInfo.UserID = clsSecurity.decryptPassword(clsSecurity.getRegDBUserName());
                        connInfo.Password = clsSecurity.decryptPassword(clsSecurity.getRegDBUserPassword());
                        connInfo.IntegratedSecurity = false;

                        TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                        tableLogOnInfo.ConnectionInfo = connInfo;
                        objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                        objRpt.VerifyDatabase();
                        #endregion

                        #region Add FormulaFields
                        //foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                        //{
                        //    if (detail.isFormulaField)
                        //    {
                        //        try
                        //        {
                        //            objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = clsCommon.fncsetstring(detail.FormulaFieldsvalue);
                        //        }
                        //        catch (Exception)
                        //        {
                        //            //   MessageBox.Show("Crystal report Formula Field not found - " + detail.FormulaFieldsName);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        // objRpt.DataDefinition.ParameterFields[detail.FormulaFieldsName].CurrentValues.Add(clsCommon.fncsetstring(detail.FormulaFieldsvalue));
                        //    }
                        //}
                        #endregion

                        //if (isExportToPDF)
                        //{
                        //    returnvalue = ExporttoPDF(objRpt);
                        //}
                        //else
                        //{
                        //    string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                        //    if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods_Local.GetHostName() == Split[0]))
                        //    {
                        //        if (clsSecurity.UserIDLoged == "digiteq")
                        //        {
                        //            DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                        //            if (dialogResult == DialogResult.Yes)
                        //                PrintNormal(objRpt);
                        //            else if (dialogResult == DialogResult.No)
                        //                PrintRemort(objRpt);
                        //        }
                        //        else
                        //            PrintRemort(objRpt);
                        //    }
                        //    else
                        //        PrintNormal(objRpt);
                        //}
                        
                        crystalReportViewer1.ReportSource = objRpt;
                        crystalReportViewer1.Refresh();
                        crystalReportViewer1.DisplayToolbar = true;
                        crystalReportViewer1.CloseView(true);
                    //  ShowDialog();
                        crystalReportViewer1.RefreshReport();

                        objRpt.Close();
                        objRpt.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Report doesn't exist", "", MessageBoxButtons.OK);
                    }
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
            return returnvalue;
        }

        private void PrintNormal(ReportDocument objRpt)
        {
            #region Normal Login
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.CloseView(true);
            //WindowState = FormWindowState.Maximized;
            //ShowDialog();
            #endregion
        }

        private void PrintRemort(ReportDocument objRpt)
        {
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();

            string sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".rpt";
            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, sFilePath);
            System.IO.File.Move(sFilePath, sFilePath.Replace("ReportExportTemp\\", clsConfig.sRemortDesktopExportPath));

            MessegeBox mess = new MessegeBox();
            mess.Show();
        }

        private string ExporttoPDF(ReportDocument objRpt)
        {
            #region Remort Desktop Login
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();

            string sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFilePath);

            #endregion
            return sFilePath;
        }

        private void btnRemoveContact2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}