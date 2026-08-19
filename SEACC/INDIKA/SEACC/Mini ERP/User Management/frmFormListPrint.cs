using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;


namespace Digiteq
{
    public partial class frmFormListPrint : Form
    {
        

        //to keep glob ref no
        public string glbOrderRefNo = "", glbHeader = "", glbReturnNoteID = "";
        public List<string> glbNotes = new List<string>();
        public ProcessNote pn;

        


        #region Form Load
        public frmFormListPrint()
        {
            InitializeComponent();
        }

        private void frmFormList_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            glbReturnNoteID = "";
            clsFormatter.setFormatForm(this, "", 2, 0);

            if (glbOrderRefNo.Length > 0 && glbOrderRefNo != "default")
            {
                tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(glbOrderRefNo);
                if (order != null && pn != null)
                    clsHelpMethods_Local.FillProcessNotes(order.OrderRefNo_ID, dgvDetail, pn, true);
            }
            else if (glbNotes.Count > 0)
            {
                clsHelpMethods_Local.FillProcessNotes(glbNotes, dgvDetail, pn, true);
            }


        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Btn Select
        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow Row in dgvDetail.Rows)
                {
                    glbReturnNoteID = clsValidate.ValidateGridValue(dgvDetail, "NoteID", dgvDetail.SelectedRows[0].Index, "");
                    if (glbReturnNoteID.Length > 0 && glbReturnNoteID != "<Auto Generate>")
                    {
                        //update receipt
                        Cursor = Cursors.WaitCursor;
                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
                        bool bOkToPrint = false, bApprovalDone = false, bCheckingDone = false;
                        tbl_sasInvoice order = tbl_sasInvoice.Select(glbReturnNoteID);
                        if (order != null)
                        {
                            #region Validate Approval
                            if (clsConfig.bApprovalNeedToPrintInvoice)
                            {
                                if (order.IsApproved)
                                    bApprovalDone = true;
                                else
                                    MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                bApprovalDone = true;
                            #endregion

                            #region Validate Checking
                            if (clsConfig.bCheckingNeedToPrintInvoice)
                            {
                                if (order.IsChecked)
                                    bCheckingDone = true;
                                else
                                    MessageBox.Show("Please Check the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                bCheckingDone = true;
                            #endregion

                            if (bApprovalDone && bCheckingDone)
                            {
                                
                                    bOkToPrint = true;

                                sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ]";
                                if (order.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ]";
                                if (order.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ]";

                                #region Print The Doc
                                if (bOkToPrint && bApprovalDone)
                                {
                                    order.PrintCount++;
                                    order.Update();

                                    string s_Path = "", sReportTitle = "", sFormula = "";
                                    if (order.VatTotal > 0 || order.NbtTotal > 0)
                                        sReportTitle = "TAX INVOICE";
                                    else
                                        sReportTitle = "INVOICE";
                                    if (glbReturnNoteID.Length > 0)
                                        sFormula = "{vw_rpt_sasInvoice.invoice_ID} = '" + glbReturnNoteID + "'";

                                    ReportDocument RD = new ReportDocument();
                                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WD.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WD.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WOD.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WSC.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_APL.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WR.rpt";
                                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_CWP.rpt";
                                    else
                                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WSC.rpt";

                                    frm_ReportViewer viewer = new frm_ReportViewer();
                                    viewer.crystalReportViewer1.ShowExportButton = false;
                                    RD.Load(s_Path);
                                //    clsSecurity.LogonServer(ref RD);
                                    RD.Refresh();

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                    {
                                        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                                        RD.DataDefinition.FormulaFields["Outstanding"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_All(order.Customer_ID)));
                                        RD.DataDefinition.FormulaFields["Cheques-In-Hand"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(order.Customer_ID)));
                                        RD.DataDefinition.FormulaFields["PurchaseOrderNo"].Text = clsCommon.fncsetstring(clsHelpMethods_Local.getCustomerPurchaseOrderID(order.OrderRefNo_ID));
                                    }

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                                    {
                                        RD.DataDefinition.FormulaFields["company VAT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                                        RD.DataDefinition.FormulaFields["company NBT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyNBT());
                                        RD.DataDefinition.FormulaFields["CompanyAddress3"].Text = "'Email :'" + clsCommon.fncsetstring(clsCommon.getCompanyEmail()) + "'  WEB :'" + clsCommon.fncsetstring(clsCommon.getCompanyWeb());
                                    }

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                        RD.DataDefinition.FormulaFields["ProjectType"].Text = clsCommon.fncsetstring("c");


                                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                                    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                    RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(order.Customer_ID));
                                    RD.DataDefinition.FormulaFields["CompanyVAT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());

                                    if (clsConfig.bDirectPrint_NP_Invoice) //Direct Print
                                    {
                                        RD.DataDefinition.RecordSelectionFormula = sFormula;
                                        clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_SalesInvoice), ref RD);
                                        RD.PrintToPrinter(1, false, 0, 0);

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DucumentPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else //View And Print
                                    {
                                        viewer.crystalReportViewer1.ReportSource = RD;
                                        viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                        viewer.crystalReportViewer1.Visible = true;
                                        viewer.crystalReportViewer1.DisplayToolbar = true;
                                        viewer.crystalReportViewer1.CloseView(false);
                                        viewer.WindowState = FormWindowState.Maximized;
                                        viewer.ShowDialog();
                                    }

                                    RD.Close();
                                    RD.Dispose();
                                }
                                #endregion
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);               
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales2, clsFormatter.colorDigiteqTheamColorSales2ForColour);           

            //Change Grid Headers
            if (glbHeader.Length > 0)
            {
                dgvDetail.Columns["NoteID"].HeaderText = glbHeader + " ID";
                dgvDetail.Columns["NoteDate"].HeaderText = glbHeader + " Date";
                dgvDetail.Columns["NoteAmount"].HeaderText = glbHeader + " Amount";
            }
        }
        #endregion

        #region Datagrid Events

        #endregion

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                glbReturnNoteID = clsValidate.ValidateGridValue(dgvDetail, "NoteID", e.RowIndex, "");
                this.Close();  
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }


    }
}
