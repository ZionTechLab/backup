#region derectives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic; 
#endregion


namespace Digiteq
{
    public partial class frmReportSetting : Form
    {
        #region Variables
        //this variable is declare because in here we are changing primary key. 
        static int rowId =-1;
        
        //to manage update and insert
        static bool IsUpdate = false;
        public string glbUserID = "";

        //to keep glob ref no
        public string glbOrderRefNo = "", glbInquiryID = "";

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;
        bool IsUpdateAddressBook = false;
        string s_FileName;
        #endregion
        
        #region Form Load
        private void frm_AutoNumber_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Report Output Setting [RS]", 2, iFormID);
            // ClearFields();

            //add data to the data grid and format  
            CusDataGridViewFormat();
            RefreshGrid();
            ClearFields();

        } 

        public frmReportSetting()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ReportSetting);
            iFormID = clsSecurity.getFormID(FormName.ReportSetting);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }

        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        ValidateEmptyForeignKey();
                        if (txtReportID.TextLength > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            string sReportID = txtReportID.Tag.ToString();
                            string suserID = txtUserName.Tag.ToString();
                            string sprinterID = txtPrinterName.Tag.ToString();
                            string spaperSizeID = txtPaperSize.Tag.ToString();
                            string sterminalID = txtTerminalName.Tag.ToString();

                            if (IsUpdate)
                            {
                                //update report setting
                                tbl_securityReportSetting oldDetail = tbl_securityReportSetting.Select(sReportID, suserID, sprinterID, spaperSizeID, sterminalID);
                                if (oldDetail != null)
                                {
                                    oldDetail.Delete();
                                }
                                tbl_securityReportSetting detail = new tbl_securityReportSetting(sReportID, suserID, sprinterID, spaperSizeID, sterminalID, chkActivate.Checked);
                                detail.Insert();

                                //update report master
                                bool bPaperSet = txtPaperSize.TextLength > 0 ? true : false;
                                bool bPrinterSet = txtPrinterName.TextLength > 0 ? true : false;
                                tbl_securityReportMaster oReport = tbl_securityReportMaster.Select(sReportID);
                                if (oReport != null)
                                {
                                    oReport.IsSetPaper = bPaperSet;
                                    oReport.IsSetPrinter = bPrinterSet;
                                    oReport.Update();
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //insert report setting
                                tbl_securityReportSetting detail = new tbl_securityReportSetting(sReportID, suserID, sprinterID, spaperSizeID, sterminalID, chkActivate.Checked);
                                detail.Insert();

                                //update report master
                                bool bPaperSet = txtPaperSize.TextLength > 0 ? true : false;
                                bool bPrinterSet = txtPrinterName.TextLength > 0 ? true : false;
                                tbl_securityReportMaster oReport = tbl_securityReportMaster.Select(sReportID);
                                if (oReport != null)
                                {
                                    oReport.IsSetPaper = bPaperSet;
                                    oReport.IsSetPrinter = bPrinterSet;
                                    oReport.Update();
                                }

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                        ClearFields();
                        RefreshGrid();
                        rowId = -1;
                    }
                }
            }
        }
        #endregion


        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateEmptyForeignKey();
                Cursor = Cursors.WaitCursor;
                string sReportID = txtReportID.Tag.ToString();
                string suserID = txtUserName.Tag.ToString();
                string sprinterID = txtPrinterName.Tag.ToString();
                string spaperSizeID = txtPaperSize.Tag.ToString();
                string sterminalID = txtTerminalName.Tag.ToString();

                tbl_securityReportSetting oldDetail = tbl_securityReportSetting.Select(sReportID, suserID, sprinterID, spaperSizeID, sterminalID);
                if (oldDetail != null)
                {
                    oldDetail.Delete();
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
                ClearFields();
                RefreshGrid();               
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            // Clear all text boxes in the form
            clsHelpMethods.RecursiveClearTextBoxes(this.Controls); 

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReportID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblReportName, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPrinterName, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPaperSize, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtUserName, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTerminalName, true);

            chkActivate.Checked = false;
            //set the flag and enable the id            
            txtReportID.Enabled = true;
            s_FileName = "";           
          

            if (txtReportID.Enabled)
                txtReportID.Focus();
        }
        #endregion
        
        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            List<tbl_securityReportSetting> details = tbl_securityReportSetting.SelectAll();
            foreach (tbl_securityReportSetting detail in details)
            {
                if (detail.Report_ID == "0")
                {
                    continue;
                }
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;

                dgvDetail["cTerminalName", iRow].Tag   = detail.Terminal_ID;
                dgvDetail["cUserName", iRow].Tag       =  detail.User_ID;
                dgvDetail["cPaperSize", iRow].Tag = detail.Paper_ID;
                dgvDetail["cPrinterName", iRow].Tag = detail.Printer_ID;
                dgvDetail["ReportID", iRow].Tag = detail.Report_ID;


                dgvDetail["cTerminalName", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Terminal(detail.Terminal_ID));
                dgvDetail["cUserName", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.User_ID));
                dgvDetail["cPaperSize", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Paper(detail.Paper_ID));
                dgvDetail["cPrinterName", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Printer(detail.Printer_ID));
                dgvDetail["ReportID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ReportMaster(detail.Report_ID));
                dgvDetail["cActive", iRow].Value      = detail.IsActive? true : false;

            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string iFormID,string userID,string printerID,string paperSizeID,string terminalID)
           {
            try
            {
                if (iFormID.Length > 0  && userID !=null && printerID !=null && paperSizeID !=null && terminalID !=null)
                {                    
                    tbl_securityReportSetting detail = tbl_securityReportSetting.Select(iFormID, userID, printerID, paperSizeID, terminalID);
                    if (detail != null)
                    {
                        // assign values
                        txtTerminalName.Tag = detail.Terminal_ID;
                        txtUserName.Tag = detail.User_ID;
                        txtPaperSize.Tag = detail.Paper_ID;
                        txtPrinterName.Tag = detail.Printer_ID;
                        txtReportID.Tag = detail.Report_ID;


                        txtTerminalName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Terminal(detail.Terminal_ID));
                        txtUserName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.User_ID));
                        txtPaperSize.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Paper(detail.Paper_ID));
                        txtPrinterName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Printer(detail.Printer_ID));
                        txtReportID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ReportMaster(detail.Report_ID));
                        
                        chkActivate.Checked = detail.IsActive;                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// " Please Enter the Details... ";
            bool bStatus = true;

            try
            {
                if (txtReportID.Tag == null)
                {
                    strMessage += "\n printer name";
                    bStatus = false;
                }
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }


            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = " ";
            bool bStatus = true;

            try
            {
               
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtPrinterName);
                clsCommon.ValidateForeignKey(ref txtPaperSize);
                clsCommon.ValidateForeignKey(ref txtUserName);
                clsCommon.ValidateForeignKey(ref txtTerminalName);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorAdminHeaderColour, clsFormatter.colorDigiteqTheamColorAdminForColour);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["ReportID", e.RowIndex].Tag.ToString();
                string userID = dgvDetail["cUserName", e.RowIndex].Tag.ToString();
                string printerID = dgvDetail["cPrinterName", e.RowIndex].Tag.ToString();
                string paperSizeID = dgvDetail["cPaperSize", e.RowIndex].Tag.ToString();
                string terminalID = dgvDetail["cTerminalName", e.RowIndex].Tag.ToString();

                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                    IsUpdate = true;
                    rowId = e.RowIndex;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["ReportID", e.RowIndex].Tag.ToString();
                string userID = dgvDetail["cUserName", e.RowIndex].Tag.ToString();
                string printerID = dgvDetail["cPrinterName", e.RowIndex].Tag.ToString();
                string paperSizeID = dgvDetail["cPaperSize", e.RowIndex].Tag.ToString();
                string terminalID = dgvDetail["cTerminalName", e.RowIndex].Tag.ToString();

                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                    IsUpdate = true;
                    rowId = e.RowIndex;//this is for capture the selected row for the primary key updte.
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        } 
        #endregion

        #region Events Keydown
        private void txtFormID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionReports(ref txtReportID);
                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }

            }
        }       
        private void frmAutoFormNumber_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        #region Double Click 
        private void txtFormID_DoubleClick(object sender, EventArgs e)
        {

            Search_ReportName();
        }

        private void txtPrinterName_DoubleClick(object sender, EventArgs e)
        {
            Search_PrinterName();
        }

        private void txtPaperSize_DoubleClick(object sender, EventArgs e)
        {
            Search_PaperSize();
        }

        private void txtUserName_DoubleClick(object sender, EventArgs e)
        {
            Search_User();
        }

        private void txtTerminalName_DoubleClick(object sender, EventArgs e)
        {
            Search_Terminal();
        } 
        #endregion

        #region Search Methord
        private void Search_PrinterName()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Printer(txtPrinterName);

                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Search_ReportName()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ReportMaster(txtReportID);

                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }
            }
            catch(Exception)
            {

            }
        }

        private void Search_PaperSize()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_paperSize(txtPaperSize);

                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }
            }
            catch (Exception)
            {

            }
        }

       
        private void Search_User()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.Search_MasterUser(ref txtUserName);

                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Search_Terminal()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Terminal(txtTerminalName);

                string sID = txtReportID.Tag.ToString();
                string userID = txtUserName.Tag.ToString();
                string printerID = txtPrinterName.Tag.ToString();
                string paperSizeID = txtPaperSize.Tag.ToString();
                string terminalID = txtTerminalName.Tag.ToString();


                if (sID.Length > 0 && userID != null && printerID != null && paperSizeID != null && terminalID != null)
                {
                    //fills the values to controls
                    FillDetails(sID, userID, printerID, paperSizeID, terminalID);
                }
            }
            catch (Exception )
            {

            }
        }

        #endregion
       
    }
}