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
using CrystalDecisions.Shared;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{

    // digiteq will note provide "open" credit note directly on customer's name in sales system. sales system is 
    // totally balsed on sales notes. this type of credit note could be done in GL module (journal voucher) 2011-12-16 (Asanka/Mr. Vijitha)


    public partial class frm_bpsCreditNote_PolyPS : SEACC_Form
    {
        
        //to manage update and insert
      //  static bool IsUpdate = false;

        //form manage
     //   string sFormConfigCode;
     //   public int iFormID;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbCreditNoteID = "";

        //for security handle
   //     public bool bNoAccess;
  //      public bool bHasChecked;
    //    public bool bHasApproved;
        //     DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //     DateTime glbCheckedDate = clsSecurity.getServerDateTime();




        #region Form Load
        public frm_bpsCreditNote_PolyPS()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.bssCreditNote);
            iFormID = clsSecurity.getFormID(FormName.bssCreditNote);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        public frm_bpsCreditNote_PolyPS(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmInvoice_Load(object sender, EventArgs e)
        {
            //format Form
           // clsFormatter.setFormatForm(this, "Credit Note", 2, iFormID);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
            //if the order genarated from a Delivery Order 

            if (glbCreditNoteID != null && glbCreditNoteID.Length > 0)
                FillDetails(glbCreditNoteID);
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    if (txtCreditNoteID.Text.Trim().Length > 0)
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        //delete one record
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Credit Note : " + txtCreditNoteID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            detail.IsDeleted = true;
                                            detail.DateModified = clsSecurity.getServerDateTime();
                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            detail.Update();

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                    {
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
                    {
                        if (CheckOutstandingValidity())
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    ValidateEmptyForeignKey();
                                    if (glbOrderRefNo.Length <= 0)
                                        glbOrderRefNo = "default";

                                    if (IsUpdate)  //update records
                                    {
                                        #region Update
                                        tbl_bpsCreditNote oldRecord = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                        if (oldRecord != null && CheckPrintingValidity(oldRecord.PrintCount))
                                        {
                                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                            {
                                                //CRN Detail                                   
                                                #region Update old Details
                                                List<tbl_bpsCreditNote_Detail> oldInvDetails = tbl_bpsCreditNote_Detail.SelectAllByCreditNote_ID(txtCreditNoteID.Text.Trim());
                                                foreach (tbl_bpsCreditNote_Detail oldInvDetail in oldInvDetails)
                                                {
                                                    string sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                                    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0;
                                                    bool bHasInvoInDB = false;

                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {

                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                        dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                        dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                        dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                        if (oldInvDetail.CreditNote_ID == txtCreditNoteID.Text.Trim() && oldInvDetail.Item_ID == sItemCode && oldInvDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                                                oldInvDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldInvDetail.ItemSerialNo == sItemSerialNo && oldInvDetail.ItemSerialNo2 == sItemSerialNo2)
                                                        {
                                                            bHasInvoInDB = true;
                                                            dgvDetail.Rows.RemoveAt(row.Index);
                                                            break; //database contain this item
                                                        }
                                                    }

                                                    if (bHasInvoInDB)
                                                    {
                                                        oldInvDetail.Item_ID = sItemCode;
                                                        oldInvDetail.Qty = dQuantity;
                                                        oldInvDetail.Weight = dWeight;
                                                        oldInvDetail.UnitPrice = dUnitPrice;
                                                        oldInvDetail.WeightPrice = dWeightPrice;
                                                        oldInvDetail.TatalAmount = dAmount;
                                                        oldInvDetail.Remark = sRemarks;
                                                        oldInvDetail.Update();
                                                    }
                                                    else
                                                    {
                                                        oldInvDetail.Delete();
                                                    }
                                                }
                                                #endregion

                                                #region Newlly Added Items insert
                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    string sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                                    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0;

                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                    if (sItemCode.Length > 0)
                                                    {
                                                        tbl_bpsCreditNote_Detail items = new tbl_bpsCreditNote_Detail(row.Index, txtCreditNoteID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2,
                                                            sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, dUnitPrice, dWeightPrice, 0, 0, dAmount, sRemarks);
                                                        items.Insert();
                                                    }
                                                }
                                                #endregion

                                                //CRN Header
                                                #region Update Invoice Header
                                                bool bIsLocked = oldRecord.IsLocked;
                                                if (chkReverseCalculation.Checked)
                                                    bIsLocked = true;

                                                tbl_bpsCreditNote detail = new tbl_bpsCreditNote(txtCreditNoteID.Text.Trim(), dtpCreditNoteDate.Value, txtRemark.Text.Trim(), txtSalesReturnNoteID.Tag.ToString(),
                                                    txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), txtDeliveryOrderID.Tag.ToString(), glbOrderRefNo, txtChequeNo.Tag.ToString(), txtCreditNoteType.Tag.ToString(),
                                                    oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID, txtCurrencyID.Tag.ToString(), txtSalesNoteType.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                    decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                    decimal.Parse(txtSubTotal.Tag.ToString()), decimal.Parse(txtDiscount.Tag.ToString()), decimal.Parse(txtNBT.Tag.ToString()), decimal.Parse(txtVat.Tag.ToString()), decimal.Parse(txtOtherTax.Tag.ToString()),
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                    oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                                                    oldRecord.IsDeleted, oldRecord.IsLocked, !chkUnitPricing.Checked, oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount, oldRecord.CompanyID, oldRecord.CompanyBranch_ID, oldRecord.Is_WriteOff, oldRecord.PosReturnTransaction_Index, oldRecord.AdvanceReceived_Index);
                                                detail.Update();

                                                #endregion

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        #endregion
                                    }
                                    else  //insert records
                                    {
                                        #region Insert
                                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        {
                                            if (clsConfig.bSalesNoteType_SerialNoActiveFor_CreditNote)
                                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode_FromSalesNoteType_CreditNote(txtSalesNoteType.Tag.ToString());
                                            else
                                            {
                                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                            }
                                        }

                                        if (txtCreditNoteID.TextLength > 0)
                                        {
                                            bool bIsLocked = false;
                                            if (chkReverseCalculation.Checked)
                                                bIsLocked = true;

                                            //CreditNote Header
                                            tbl_bpsCreditNote detail = new tbl_bpsCreditNote(txtCreditNoteID.Text.Trim(), dtpCreditNoteDate.Value, txtRemark.Text.Trim(), txtSalesReturnNoteID.Tag.ToString(),
                                                txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), txtDeliveryOrderID.Tag.ToString(), glbOrderRefNo, txtChequeNo.Tag.ToString(), txtCreditNoteType.Tag.ToString(),
                                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurrencyID.Tag.ToString(), txtSalesNoteType.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                decimal.Parse(txtSubTotal.Tag.ToString()), decimal.Parse(txtDiscount.Tag.ToString()), decimal.Parse(txtNBT.Tag.ToString()), decimal.Parse(txtVat.Tag.ToString()), decimal.Parse(txtOtherTax.Tag.ToString()),
                                                decimal.Parse(txtGrandTotal.Text.Trim()), clsSecurity.UserIDLoged, "default", "default", "default",
                                                clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                clsSecurity.getServerDateTime(), false, false, false, false, false, !chkUnitPricing.Checked, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, false, -1, -1);
                                            detail.Insert();
                                            //CreditNote  Detail                                
                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                try
                                                {
                                                    string sItemCode = "", sUom = "default", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                                    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0;

                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                    sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index, "default");
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                    if (sItemCode.Length > 0)
                                                    {
                                                        tbl_bpsCreditNote_Detail items = new tbl_bpsCreditNote_Detail(row.Index, txtCreditNoteID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2,
                                                            sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, dUnitPrice, dWeightPrice, 0, 0, dAmount, sRemarks);
                                                        items.Insert();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                                    SEACCException.Show(ex);
                                                }//error may come because last row of the grid may not have information
                                            }

                                        //    clsAlerts_Email.createEmail_CreditNote(txtCreditNoteID.Text.Trim(), enum_Alerts.CreditNoteCreated);
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Credit Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        #endregion
                                    }
                                }
                                catch (Exception ex)
                                {
                                    SEACCException.Show(ex);
                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                    if (detail != null)
                                        FillDetails(detail.CreditNote_ID);
                                }
                            }
                        }//outstaindings validity
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditNoteID.Text.Trim().Length > 0 && txtCreditNoteID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";// sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = false, bCheckingDone = false;
                    tbl_bpsCreditNote CreditNote = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                    if (CreditNote != null)
                    {
                        //Write Audit Trial Log
                        clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CreditNote), CreditNote.CreditNote_ID);

                        #region Validate Approval
                        if (clsConfig.bApprovalNeedToPrintCreditNote)
                        {
                            if (CreditNote.IsApproved)
                                bApprovalDone = true;
                            else
                                MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            bApprovalDone = true;
                        #endregion

                        #region Validate Checking
                        if (clsConfig.bCheckingNeedToPrintCreditNote)
                        {
                            if (CreditNote.IsChecked)
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

                            sCreateUser = "[ " + clsGenaralName.getName_User(CreditNote.CreateUser_ID) + " ] [ " + CreditNote.DateCreate.ToShortDateString() + " ]";
                            if (CreditNote.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(CreditNote.CheckedUser_ID) + " ] [ " + CreditNote.DateChecked.ToShortDateString() + " ]";
                            if (CreditNote.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(CreditNote.ApprovedUser_ID) + " ] [ " + CreditNote.DateApproved.ToShortDateString() + " ]";

                            #region Print The Doc
                            if (bOkToPrint && bApprovalDone)
                            {
                                CreditNote.PrintCount++;
                                CreditNote.Update();

                                string s_Path = "", sReportTitle = "CREDIT NOTE", sFormula = "";
                                if (txtCreditNoteID.TextLength > 0)
                                    sFormula = "{vw_rpt_bpsCreditNote.creditNote_ID} = '" + txtCreditNoteID.Text.Trim() + "'";

                                ReportDocument RD = new ReportDocument();
                                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                                s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote_WD.rpt";

                                frm_ReportViewer viewer = new frm_ReportViewer();
                                viewer.crystalReportViewer1.ShowExportButton = false;
                                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                                //  clsSecurity.LogonServer(ref RD);
                                RD.Refresh();

                                //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                                viewer.crystalReportViewer1.ReportSource = RD;
                                viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                viewer.crystalReportViewer1.Visible = true;
                                viewer.crystalReportViewer1.DisplayToolbar = true;
                                viewer.crystalReportViewer1.CloseView(false);
                                viewer.WindowState = FormWindowState.Maximized;

                                viewer.ShowDialog();

                                RD.Close();
                                RD.Dispose();
                            }
                            #endregion
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the Credit Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion



        #region Btn Customer View
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            {
                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                frm.glbCustomerID = txtCustomerID.Tag.ToString();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //frm.MdiParent = this.MdiParent;
                    //frm.Show();
                }
            }
        }
        #endregion

        #region Btn Add Invoice
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                if (detail != null)
                {
                    //add order ref detail
                    FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

                    //disable controls
                    SetDisableControl(false);

                    //add item details
                    RefreshGridByInvoiceID(detail.Invoice_ID);

                    txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                    txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));
                }
            }
        }
        #endregion

        #region Btn Add DeliveryOrder
        private void btnAddDO_Click(object sender, EventArgs e)
        {
            //if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)
            //{
            //    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Tag.ToString());
            //    if (detail != null)
            //    {
            //        //add order ref detail
            //        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

            //        //disable controls
            //        SetDisableControl(false);

            //        //add item details
            //        RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);

            //        txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
            //        txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));
            //    }
            //}
        }
        #endregion

        #region Btn Add SRN
        private void btnAddSRN_Click(object sender, EventArgs e)
        {
            if (txtSalesReturnNoteID.Tag != null && txtSalesReturnNoteID.Tag.ToString().Trim().Length > 0)
            {
                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSalesReturnNoteID.Tag.ToString());
                if (detail != null)
                {
                    //add order ref detail
                    FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

                    //disable controls
                    SetDisableControl(false);

                    //add item details
                    RefreshGridBySalesReturnedNoteID(detail.SalesReturnedNote_ID);

                    txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                    txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal));
                }
            }
        }
        #endregion

        #region Btn Add Cheque
        private void btnAddCheque_Click(object sender, EventArgs e)
        {
            if (txtChequeNo.Tag != null && txtChequeNo.Tag.ToString().Trim().Length > 0)
            {
                tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(txtChequeNo.Tag.ToString());
                if (detail != null)
                {
                    //add order ref detail
                    FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.Amount);

                    //disable controls
                    SetDisableControl(false);

                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit));
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            //price
            if (clsConfig.bEnableGridLock_Price_Invoice)
                dgvDetail.Columns["UnitPrice"].ReadOnly = true;
            else
                dgvDetail.Columns["UnitPrice"].ReadOnly = false;
            //qty
            if (clsConfig.bEnableGridLock_Quantity_Invoice)
                dgvDetail.Columns["Quantity"].ReadOnly = true;
            else
                dgvDetail.Columns["Quantity"].ReadOnly = false;

        }
        private void CusDataGirdViewFormatForCalucation(DataGridView dgv, bool bWeightCalculation)
        {
            if (bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = true;
                dgv.Columns["WeightPrice"].Visible = true;
                dgv.Columns["Quantity"].Visible = false;
                dgv.Columns["UnitPrice"].Visible = false;
            }
            else if (!bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = false;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = true;
                dgv.Columns["UnitPrice"].Visible = true;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);

            SetDisableControl(true);

            txtCreditNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtCreditNoteType.Tag = null;
            txtSalesReturnNoteID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtChequeNo.Tag = null;
            txtSalesNoteType.Tag = null;

            txtRemark.Clear();
            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtDeliveryOrderID.Clear();
            txtOrderRefNo.Clear();
            txtCreditNoteType.Clear();
            txtSalesReturnNoteID.Clear();
            txtInvoiceID.Clear();
            txtChequeNo.Clear();
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            txtSalesNoteType.Clear();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;

            txtDiscount.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtVat.Text = "0.00";

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();
            chkShowSettle.Checked = false;


            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkReverseCalculation.Enabled = true;
            chkSettings.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCreditNoteID.Text = "<Auto Generate>";
            else
                txtCreditNoteID.Clear();
            if (txtCreditNoteID.Enabled)
            {
                txtCreditNoteID.SelectAll();
                txtCreditNoteID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sCreditNoteID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_bpsCreditNote_Detail> details = tbl_bpsCreditNote_Detail.SelectAllByCreditNote_ID(sCreditNoteID);
                foreach (tbl_bpsCreditNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID,
                            detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByInvoiceID(string sInvoiceID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_sasInvoice_Detail> details = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoiceID);
                foreach (tbl_sasInvoice_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID,
                            detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByDeliveryOrderID(string sDeliveryOrderID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID);
                foreach (tbl_sasDeliveryOrder_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID,
                            detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridBySalesReturnedNoteID(string sSalesReturnedID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_sasSalesReturnedNote_Detail> details = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(sSalesReturnedID);
                foreach (tbl_sasSalesReturnedNote_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, item.Uom_ID, detail.UnitPrice, detail.KiloPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID,
                            detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                        SetDisableControl(false);

                        //asign values
                        txtCreditNoteID.Tag = detail.CreditNote_ID;
                        txtDeliveryOrderID.Tag = detail.DeliveryOrder_ID;
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtCreditNoteType.Tag = detail.CreditNoteType_ID;
                        txtSalesReturnNoteID.Tag = detail.SalesReturnedNote_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtChequeNo.Tag = detail.ChequeRegister_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        txtCreditNoteID.Text = detail.CreditNote_ID;
                        txtDeliveryOrderID.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtCreditNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CreditNoteType(detail.CreditNoteType_ID));
                        txtSalesReturnNoteID.Text = clsCommon.GetForeignKeyValue(detail.SalesReturnedNote_ID);
                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtChequeNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeNo(detail.ChequeRegister_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        dtpCreditNoteDate.Value = detail.CreditNoteDate;
                        txtRemark.Text = detail.Remark;
                        txtRemark.Text = detail.Remark;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        //Tax Details
                        if (detail.DiscountTotal > 0)
                        {
                            chkDiscount.Checked = true;
                            txtDiscount.Tag = detail.DiscountTotal;
                            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberNoDecimal(detail.DiscountPercentage);
                        }
                        else
                            chkDiscount.Checked = false;
                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;

                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);

                        if (detail.IsApproved)
                        {
                            // bHasApproved = true;
                            //  glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            //   bHasChecked = true;
                            //glbCheckedDate = detail.DateChecked;
                        }
                        userDetailsColorChanges();


                        //fill item details
                        RefreshGrid(detail.CreditNote_ID);
                        //  FillDetailsCustomer(detail.Customer_ID);


                        //Asign tax values after all calculation
                        txtSubTotal.Tag = detail.SubTotal;
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                        txtDiscount.Tag = detail.DiscountTotal;
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                        txtNBT.Tag = detail.NbtTotal;
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                        txtVat.Tag = detail.VatTotal;
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                        txtOtherTax.Tag = detail.OtherTaxTotal;
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalAmount);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill OrderRefNo
        private void FillOrderRefNo(string sOrderRefID, string sCustomerID, decimal dAmount)
        {
            glbOrderRefNo = sOrderRefID;
            tbl_genCustomerMaster cus = tbl_genCustomerMaster.Select(sCustomerID);
            if (cus != null)
            {
                txtCustomerID.Tag = cus.Customer_ID;
                txtCustomerID.Text = cus.CustomerName;
            }

            tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sOrderRefID);
            if (detail != null && detail.OrderRefNo_ID != "default")
            {
                txtOrderRefNo.Text = detail.OrderRefNo;
                txtOrderRefNo.Tag = detail.OrderRefNo_ID;
            }

            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
        }
        #endregion

        #region Fill Customer Detials
        private void FillDetailsCustomer(string sCustomerID)
        {
            try
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();


                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = clsGenaralName.getName_Customer(customer.Customer_ID);

                    txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrencyID.Tag = null;
                txtCurrencyID.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrencyID.Tag = currency.Currency_ID;
                        txtCurrencyID.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By DeliveryOrderID
        private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        {
            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DeliveryOrderID);

            if (detail != null)
            {
                txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);


                if (detail.DiscountTotal > 0)
                    chkDiscount.Checked = true;
                else
                    chkDiscount.Checked = false;
                if (detail.NbtTotal > 0)
                    chkNBT.Checked = true;
                else
                    chkNBT.Checked = false;
                if (detail.VatTotal > 0)
                    chkVat.Checked = true;
                else
                    chkVat.Checked = false;
                if (detail.OtherTaxTotal > 0)
                    chkOtherTax.Checked = true;
                else
                    chkOtherTax.Checked = false;

                txtRemark.Text = detail.Remark;
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtCustomerID.TextLength == 0)
                {
                    strMessage += "\n" + "Customer Name ";
                    bStatus = false;
                }
                if (txtSalesNoteType.TextLength == 0)
                {
                    strMessage += "\n" + "Note Type ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            //  string sItemCode = "", sDoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            //  decimal dQuantity = 0, dWeight = 0;

            //if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.Invoice)) && (!IsUpdate))
            //{
            //    foreach (DataGridViewRow row in dgvDetail.Rows)
            //    {
            //        try
            //        {
            //            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
            //            sDoCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
            //            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
            //            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
            //            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
            //            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
            //            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
            //            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

            //            tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
            //            if (DoDetail != null)
            //            {
            //                if (chkUnitPricing.Checked)
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (DoDetail.Qty < dQuantity)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (DoDetail.Qty < (DoDetail.QtySettle + dQuantity))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity  \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (DoDetail.Weight < dWeight)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (DoDetail.Weight < (DoDetail.WeightSettle + dWeight))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight\n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            clsValidate.WriteErrorLog("", iFormID,ex);
            //           SEACCException.Show(ex);
            //        }
            //    }
            //    if (!rtn)
            //    {
            //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            return rtn;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n Sub Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Pasentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtVat.Text.Trim()))
                {
                    strMessage += "\n VAT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n VAT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtNBT.Text.Trim()))
                {
                    strMessage += "\n NBT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n NBT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtGrandTotal.Text.Trim()))
                {
                    strMessage += "\n Grand Total";
                    bStatus = false;
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckOutstandingValidity()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                    if (customer != null && customer.Customer_ID != "default")
                    {
                        if (customer.IsBlacklisted)
                        {
                            bOk = false;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (clsConfig.bCreditBalanceInvoice_Message) //security 1 - Message
                            {
                                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                                {
                                    dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                    if (txtGrandTotal.TextLength > 0)
                                        dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
                                    if (dCreditBalance < dAmountDue) //Condition
                                    {
                                        bOk = false;
                                        if (clsConfig.bCreditBalanceInvoice_Lock) //security 2 - Lock
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        else
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                bOk = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bOk;
        }

        private bool CheckPrintingValidity(int iPrintCount)
        {
            bool bOk = true;
            try
            {
                if (iPrintCount > 0)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bOk;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtInvoiceID);
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                clsCommon.ValidateForeignKey(ref txtSalesReturnNoteID);
                clsCommon.ValidateForeignKey(ref txtChequeNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        



        #region Events KeyDown
        private void txtCreditNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CreditNote();
            }
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Invoice(sender);
            }
        }
        private void txtSalesReturnNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesReturnNoteID(sender);
            }
        }
        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Cheque(sender);
            }
        }
        private void txtDeliveryOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DeliveryOrder(sender);
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_SalesExecutiveID();
            }
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }
        #endregion

        #region Events Double Click   
        private void txtCreditNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNote();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_Invoice(sender);
        }
        private void txtChequeNo_DoubleClick(object sender, EventArgs e)
        {
            Search_Cheque(sender);
        }
        private void txtDeliveryOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrder(sender);
        }
        private void txtCreditNoteType_DoubleClick(object sender, EventArgs e)
        {
            //  Search_CreditNoteType();
        }
        private void txtSalesReturnNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesReturnNoteID(sender);
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0.00";
                txtDiscount.Tag = "0";
                CalculateTaxesAndGrandTotal();
            }
        }

        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
                chkVat.Checked = true;
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                txtPercentageOtherTax.Enabled = true;
                chkVat_CheckedChanged(chkVat, new EventArgs());
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtPercentageOtherTax.Text = clsCommon.getPesentageOtherTax().ToString();
                chkVat_CheckedChanged(chkVat, new EventArgs());
                txtOtherTax.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }

        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //call cellend events for all records
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
            }
        }

        private void chkReverseCalculation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReverseCalculation.Checked)
            {
                chkReverseCalculation.Enabled = false;
                VatNBTReverceCalculation(clsCommon.getPesentageVAT(), clsCommon.getPesentageNBT());
                chkNBT.Checked = true;
                chkVat.Checked = true;
            }
        }

        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings.Checked)
            //{

            //    chkSettings.Image = Digiteq.Properties.Resources.network;
            //}
            //else
            //{
            //    xSetting.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.settings;
            //}
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.SalesGrid_CellDoubleClick(sender, e, dgvDetail);
            CalcualteSubTotal();
            CalculateTaxesAndGrandTotal();
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.SalesGrid_CellEndEdit_crn(sender, e, dgvDetail, !chkUnitPricing.Checked);
            CalcualteSubTotal();
            CalculateTaxesAndGrandTotal();
        }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region Disable Money Controls
        private void DisableMoneyControls()
        {
            txtDiscount.Enabled = false;
            txtPercentageDiscount.Enabled = false;
            txtPercentageVat.Enabled = false;
            txtPercentageNBT.Enabled = false;
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
        }
        #endregion

        #region Search Methods
        private void Search_CreditNote()
        {
            try
            {
                clsSearch.Search_TransactionCreditNote_Direct(ref txtCreditNoteID, chkShowSettle.Checked);
                if (txtCreditNoteID.Tag != null && txtCreditNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtCreditNoteID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomerID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                        FillDetailsCustomer(frmSearchMaster.s_SearchID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Invoice(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), false, "", true, true, true, true, true, "");
                else
                    clsSearch.Search_TransactionInvoice_Use(ref txtInvoiceID, false, "", true, true, false, true);

                btnAddInvoice_Click(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesReturnNoteID(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionSalesReturnNote(ref txtSalesReturnNoteID, txtCustomerID.Tag.ToString(), true, false, false);
                else
                    clsSearch.Search_TransactionSalesReturnNote(ref txtSalesReturnNoteID, "", true, false, false);

                btnAddSRN_Click(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CreditNoteType()
        {
            try
            {
                clsSearch.Search_MasterCreditNoteType(ref txtCreditNoteType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Cheque(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionChequeByCustomerID_Use(ref txtChequeNo, txtCustomerID.Tag.ToString(), false, "", true);
                else
                    clsSearch.Search_TransactionCheque_Use(ref txtChequeNo, false, "", true);

                btnAddCheque_Click(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_DeliveryOrder(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrderID, txtCustomerID.Tag.ToString(), true);
                else
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrderID, "", true);

                btnAddDO_Click(sender, new EventArgs());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }
        #endregion

        #region Calcualte Values
        private void CalcualteSubTotal()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (dgvDetail["Amount", x].Tag != null && dgvDetail["Amount", x].Tag.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Tag.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Tag.ToString());
                    }
                }
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                txtSubTotal.Tag = Amount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }

        #endregion

        #region Vat/NBT Revers calculation
        private void VatNBTReverceCalculation(decimal dVatRate, decimal dNBTRate)
        {
            if (dVatRate > 0 && dNBTRate > 0)
            {
                decimal dAfterVAT = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    decimal dUnitPrice = 0, dWeightPrice = 0, dVatAmount = 0, dQty = 0, dWeight = 0;
                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));

                    #region Tax Amount Calculation
                    if (chkUnitPricing.Checked)
                    {
                        dAfterVAT = (dUnitPrice / (100 + dVatRate)) * 100;
                        dUnitPrice = (dAfterVAT / (100 + dNBTRate)) * 100;
                    }
                    else
                    {
                        dAfterVAT = (dWeightPrice / (100 + dVatRate)) * 100;
                        dWeightPrice = (dAfterVAT / (100 + dNBTRate)) * 100;
                    }
                    #endregion

                    #region Assign New Value
                    if (clsCommon.IsCustomerizedGrid())
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice;// clsFormatter.FormatToNumberWithTwoDecimalPlaces(dUnitPrice);
                            dgvDetail["UnitPrice", row.Index].Tag = dUnitPrice;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice;// clsFormatter.FormatToNumberWithTwoDecimalPlaces(dWeightPrice);
                            dgvDetail["WeightPrice", row.Index].Tag = dWeightPrice;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["WeightPrice"].Index, row.Index));
                        }
                    }
                    else
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice.ToString();
                            dgvDetail["UnitPrice", row.Index].Tag = dUnitPrice.ToString();
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice.ToString();
                            dgvDetail["WeightPrice", row.Index].Tag = dWeightPrice.ToString();
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["WeightPrice"].Index, row.Index));
                        }
                    }
                    #endregion

                }

                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }

        }
        #endregion      

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string Uom_ID, decimal UnitPrice, decimal KiloPrice, decimal TatalAmount,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark)
        {
            try
            {
                //if the item already in the datagrid, only update weight and qty of the item.
                bool isNewItem = true;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (ItemID == clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, ""))
                    {
                        string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                        sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                        sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                        if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
                        {
                            dgvDetail.Rows.RemoveAt(iRow);
                            Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                            Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                            iRow = row.Index;
                        }
                    }
                }

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(Uom_ID);
                dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
                dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["Remarks", iRow].Value = Remark;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Width", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Width);
                    dgvDetail["Height", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Height);
                    dgvDetail["Gauge", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gauge);
                    dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);// add by thilina

                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                    if (isNewItem)
                    {
                        dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                        dgvDetail["UnitPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                    }
                    if (isNewItem)
                    {
                        dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);
                        dgvDetail["WeightPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);
                    }

                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithFourDecimalPlaces(TatalAmount);
                    dgvDetail["Amount", iRow].Tag = clsFormatter.FormatToCurrecyWithFourDecimalPlaces(TatalAmount);
                }
                else
                {
                    dgvDetail["Width", iRow].Value = Width.ToString();
                    dgvDetail["Height", iRow].Value = Height.ToString();
                    dgvDetail["Gauge", iRow].Value = Gauge.ToString();
                    dgvDetail["Gusset", iRow].Value = Gusset.ToString();//add by thilina
                    dgvDetail["Weight", iRow].Value = Weight.ToString();
                    if (isNewItem)
                    {
                        dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                        dgvDetail["UnitPrice", iRow].Tag = UnitPrice.ToString();
                    }
                    dgvDetail["Quantity", iRow].Value = Qty.ToString();
                    dgvDetail["Amount", iRow].Value = TatalAmount.ToString();
                    dgvDetail["Amount", iRow].Tag = TatalAmount;
                    if (isNewItem)
                    {
                        dgvDetail["WeightPrice", iRow].Value = KiloPrice.ToString();
                        dgvDetail["WeightPrice", iRow].Tag = KiloPrice.ToString();
                    }
                }
                // dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Settle Delivery Order
        private void SetDeliveryOrderSettle(string sDeliveryOrderID)
        {
            bool bIsSettle = false, bLocked = false;
            if (clsConfig.bAutoSettleHideDeliveryOrder)
            {
                List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID);
                foreach (tbl_sasDeliveryOrder_Detail detail in details)
                {
                    bIsSettle = true;
                    if (chkUnitPricing.Checked)
                    {
                        if (detail.QtySettle < detail.Qty)
                        {
                            bIsSettle = false;
                            break;
                        }
                        if (detail.QtySettle > 0)
                            bLocked = true;
                    }
                    else
                    {
                        if (detail.WeightSettle < detail.Weight)
                        {
                            bIsSettle = false;
                            break;
                        }
                        if (detail.WeightSettle > 0)
                            bLocked = true;
                    }
                }

                tbl_sasDeliveryOrder DeliveryOrder = tbl_sasDeliveryOrder.Select(sDeliveryOrderID);
                if (DeliveryOrder != null)
                {
                    DeliveryOrder.IsSeattled = bIsSettle;
                    DeliveryOrder.IsLocked = bLocked;
                    DeliveryOrder.Update();
                }
            }
        }
        #endregion


        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDeliveryOrderID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtChequeNo, bEnable);

            clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblChequeNo, bEnable);

            btnAddCheque.Enabled = bEnable;
            btnAddDO.Enabled = bEnable;
            btnAddInvoice.Enabled = bEnable;
            btnAddSRN.Enabled = bEnable;
        }
        #endregion


        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            //  decimal dDiscount = 0;
            if (txtDiscount.TextLength > 0 && clsCommon.isCurrency(txtDiscount.Text.Trim()) && decimal.Parse(txtDiscount.Text.Trim()) > 0)
            {
                txtDiscount.Tag = txtDiscount.Text.Trim();
                txtPercentageDiscount.Text = "0";
            }
            else
                txtDiscount.Tag = "0";

            CalculateTaxesAndGrandTotal();
        }


        #region User Checked Approve Details
        private void btnChecked_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtCreditNoteID.Text != null && txtCreditNoteID.TextLength > 0)
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            frmSetApproved login = new frmSetApproved();
                            login.iFormID = iFormID;
                            login.userID = clsSecurity.UserIDLoged;
                            login.ShowDialog();
                            if (frmSetApproved.bChecked)
                            {
                                //bHasApproved = true;
                                //  glbApprovedDate = clsSecurity.getServerDateTime();
                                if (IsUpdate)
                                {
                                    userDetailsColorChanges();

                                    tbl_bpsCreditNote objCN = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                    if (objCN != null)
                                    {
                                        objCN.IsApproved = true;
                                        objCN.DateApproved = clsSecurity.getServerDateTime();
                                        objCN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                        objCN.Update();
                                    }
                                }
                            }
                            //   else if (frmSetApproved.bReset)
                            //       bHasApproved = false;
                        }
                    }
                    else
                        MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtCreditNoteID.Text != null && txtCreditNoteID.TextLength > 0)
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            frmSetChecked login = new frmSetChecked();
                            login.iFormID = iFormID;
                            login.userID = clsSecurity.UserIDLoged;
                            login.ShowDialog();
                            if (frmSetChecked.bChecked)
                            {
                                bHasChecked = true;
                                //glbCheckedDate = clsSecurity.getServerDateTime();

                                if (IsUpdate)
                                {
                                    userDetailsColorChanges();

                                    tbl_bpsCreditNote objCN = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                    if (objCN != null)
                                    {
                                        objCN.IsChecked = true;
                                        objCN.DateChecked = clsSecurity.getServerDateTime();
                                        objCN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                        objCN.Update();
                                    }
                                }

                            }
                            //  else if (frmSetChecked.bReset)
                            //bHasChecked = false;
                        }
                    }
                    else
                        MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            if (txtCreditNoteID.Text != "" || txtCreditNoteID.Text != "<Auto Generate>")
            {
                userDetailsColorChanges();
                tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));


                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
            }
        }

        private void frm_bpsCreditNote_PolyPS_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void frm_bpsCreditNote_PolyPS_SF_printButton_Click(object sender, EventArgs e)
        {
            btnPrint_Click( sender,  e);

        }

    private void frm_bpsCreditNote_PolyPS_SF_saveButton_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void frm_bpsCreditNote_PolyPS_SF_cancelButton_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
        }

        #region User Details Color Changes
        private void userDetailsColorChanges()
        {
            if (bHasApproved)
            {
                this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
                this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
                btnApproved.Enabled = false;
                btnChecked.Enabled = false;

            }
            if (bHasChecked)
            {
                this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
                btnChecked.Enabled = false;
            }
            if (!bHasApproved && !bHasChecked)
            {
                this.btnApproved.ForeColor = System.Drawing.Color.Red;
                this.btnChecked.ForeColor = System.Drawing.Color.Red;
                this.btnApproved.BackColor = System.Drawing.Color.White;
                this.btnChecked.BackColor = System.Drawing.Color.White;
                btnApproved.Enabled = true;
                btnChecked.Enabled = true;
            }
        }
        #endregion
        #endregion

    }
}


#region Events Mouseclick
//private void txtFlowInquiry_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Inquiry(sender, e, glbOrderRefNo);
//}

//private void txtFlowQuotaion_MouseClick(object sender, MouseEventArgs e)
//{

//}

//private void txtFlowSalesReturned_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
//}
//private void txtFlowCustomerOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowProductionJob_MouseClick(object sender, MouseEventArgs e)
//{

//}

//private void txtFlowDeliveryOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_DeliveryOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowInvoice_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Invoice(sender, e, glbOrderRefNo);
//}

//private void txtFlowReceipt_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Receipt(sender, e, glbOrderRefNo);
//}
#endregion