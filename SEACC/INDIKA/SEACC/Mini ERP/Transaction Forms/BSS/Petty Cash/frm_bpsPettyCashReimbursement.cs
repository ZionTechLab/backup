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
    public partial class frm_bpsPettyCashReimbursement : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;
    

        #region Form Load
        public frm_bpsPettyCashReimbursement()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.PettyCashReimbursement);
            iFormID = clsSecurity.getFormID(FormName.PettyCashReimbursement);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsPettyCashReimbursement_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            ClearFields();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string PettyCashAccountID, int ifromLineNo, int iToLineNo)
        {
            int iRownew;
            dgvDetail.Rows.Clear();
            decimal dBalance = 0, dIncomeAmount = 0, dExpenditureAmount = 0, dOPBalanceAmount = 0;

            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(PettyCashAccountID).Where(p => p.ReimbRequest_ID == "default" && !p.IsDeleted && p.Line_No >= ifromLineNo && p.Line_No <= iToLineNo).ToList();
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
            {
                dgvDetail.Rows.Add();
                iRownew = dgvDetail.Rows.Count - 1;

                dgvDetail["DateCreated", iRownew].Value = detail.TransactionDate.ToShortDateString();
                dgvDetail["DateCreated", iRownew].Tag = detail.TransactionDate;
                dgvDetail["Narration", iRownew].Value = detail.Remark;
                dgvDetail["line_No", iRownew].Value = detail.Line_No;
                dgvDetail["User", iRownew].Value = detail.SpentUserName;
                dgvDetail["VoucherNo", iRownew].Value = detail.VoucherNo;
                dgvDetail["InvoiceNo", iRownew].Value = detail.InvoiceNo;
                dgvDetail["CostCenter", iRownew].Tag = detail.Cost_Center_ID;
                dgvDetail["CostCenter", iRownew].Value = clsGenaralName.getName_CostCenter1(detail.Cost_Center_ID);

                dgvDetail["clmCostCenter2", iRownew].Tag = detail.Cost_Center2_ID;
                dgvDetail["clmCostCenter3", iRownew].Tag = detail.Cost_Center3_ID;
                dgvDetail["clmCostCenter4", iRownew].Tag = detail.Cost_Center4_ID;

                dgvDetail["clmCostCenter2", iRownew].Value = clsGenaralName.getName_CostCenter2(detail.Cost_Center2_ID);
                dgvDetail["clmCostCenter3", iRownew].Value = clsGenaralName.getName_CostCenter3(detail.Cost_Center3_ID);
                dgvDetail["clmCostCenter4", iRownew].Value = clsGenaralName.getName_CostCenter4(detail.Cost_Center4_ID);


                if (detail.IsIncome)
                {
                    dgvDetail["isIncome", iRownew].Value = detail.IsIncome;
                    dgvDetail["isExpenditure", iRownew].Value = detail.IsExpenditure;
                    dgvDetail["Type", iRownew].Value = clsGenaralName.getName_IncomeType(detail.PettyCashIncomeType_ID);
                    dgvDetail["IncomeTag", iRownew].Tag = detail.PettyCashIncomeType_ID;
                    dgvDetail["ExpenditureTag", iRownew].Tag = "default";
                    dgvDetail["Income", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance + detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);

                    dgvDetail["IouID", iRownew].Value = "";
                    dgvDetail["IouID", iRownew].Tag = "default";
                    dIncomeAmount = dIncomeAmount + +detail.Amount;
                }
                else if (detail.IsExpenditure)
                {
                    dgvDetail["isIncome", iRownew].Value = detail.IsIncome;
                    dgvDetail["isExpenditure", iRownew].Value = detail.IsExpenditure;
                    dgvDetail["Type", iRownew].Value = clsGenaralName.getName_ExpenditureType(detail.PettyCashExpenditureType_ID);
                    dgvDetail["ExpenditureTag", iRownew].Tag = detail.PettyCashExpenditureType_ID;
                    dgvDetail["IncomeTag", iRownew].Tag = "default";
                    dgvDetail["Expendicher", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance - detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
                    dExpenditureAmount = dExpenditureAmount + detail.Amount;
                }
            }

            txtIncome.Text = clsFormatter.FormatToCurrecyWithThousendSep(dIncomeAmount);
            txtExpenditure.Text = clsFormatter.FormatToCurrecyWithThousendSep(dExpenditureAmount);
            dOPBalanceAmount = calculateOpanningBalance(PettyCashAccountID, ifromLineNo);
            txtOpaningBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOPBalanceAmount);
            txtClosingBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dIncomeAmount - dExpenditureAmount + dOPBalanceAmount);

            #region Select Add Row
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                dgvDetail.FirstDisplayedScrollingRowIndex = dgvDetail.Rows.Count - 1;
            }
            #endregion
        }

        private void RefreshGrid(string PettyCashAccountID, string ReimbRequestID)
        {
            int iRownew;
            dgvDetail.Rows.Clear();
            decimal dBalance = 0, dIncomeAmount = 0, dExpenditureAmount = 0;// dOPBalanceAmount = 0;

            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(PettyCashAccountID).Where(p => p.ReimbRequest_ID == ReimbRequestID).ToList();
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
            {
                dgvDetail.Rows.Add();
                iRownew = dgvDetail.Rows.Count - 1;

                dgvDetail["DateCreated", iRownew].Value = detail.TransactionDate.ToShortDateString();
                dgvDetail["DateCreated", iRownew].Tag = detail.TransactionDate;
                dgvDetail["Narration", iRownew].Value = detail.Remark;
                dgvDetail["line_No", iRownew].Value = detail.Line_No;
                dgvDetail["User", iRownew].Value = detail.SpentUserName;
                dgvDetail["VoucherNo", iRownew].Value = detail.VoucherNo;
                dgvDetail["InvoiceNo", iRownew].Value = detail.InvoiceNo;
                dgvDetail["CostCenter", iRownew].Tag = detail.Cost_Center_ID;
                dgvDetail["CostCenter", iRownew].Value = clsGenaralName.getName_CostCenter1(detail.Cost_Center_ID);

                dgvDetail["clmCostCenter2", iRownew].Tag = detail.Cost_Center2_ID;
                dgvDetail["clmCostCenter3", iRownew].Tag = detail.Cost_Center3_ID;
                dgvDetail["clmCostCenter4", iRownew].Tag = detail.Cost_Center4_ID;

                dgvDetail["clmCostCenter2", iRownew].Value = clsGenaralName.getName_CostCenter2(detail.Cost_Center2_ID);
                dgvDetail["clmCostCenter3", iRownew].Value = clsGenaralName.getName_CostCenter3(detail.Cost_Center3_ID);
                dgvDetail["clmCostCenter4", iRownew].Value = clsGenaralName.getName_CostCenter4(detail.Cost_Center4_ID);


                if (detail.IsIncome)
                {
                    dgvDetail["isIncome", iRownew].Value = detail.IsIncome;
                    dgvDetail["isExpenditure", iRownew].Value = detail.IsExpenditure;
                    dgvDetail["Type", iRownew].Value = clsGenaralName.getName_IncomeType(detail.PettyCashIncomeType_ID);
                    dgvDetail["IncomeTag", iRownew].Tag = detail.PettyCashIncomeType_ID;
                    dgvDetail["ExpenditureTag", iRownew].Tag = "default";
                    dgvDetail["Income", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance + detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);

                    dgvDetail["IouID", iRownew].Value = "";
                    dgvDetail["IouID", iRownew].Tag = "default";
                    dIncomeAmount = dIncomeAmount + +detail.Amount;
                }
                else if (detail.IsExpenditure)
                {
                    dgvDetail["isIncome", iRownew].Value = detail.IsIncome;
                    dgvDetail["isExpenditure", iRownew].Value = detail.IsExpenditure;
                    dgvDetail["Type", iRownew].Value = clsGenaralName.getName_ExpenditureType(detail.PettyCashExpenditureType_ID);
                    dgvDetail["ExpenditureTag", iRownew].Tag = detail.PettyCashExpenditureType_ID;
                    dgvDetail["IncomeTag", iRownew].Tag = "default";
                    dgvDetail["Expendicher", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance - detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
                    dExpenditureAmount = dExpenditureAmount + detail.Amount;
                }
            }



            #region Select Add Row
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                dgvDetail.FirstDisplayedScrollingRowIndex = dgvDetail.Rows.Count - 1;
            }
            #endregion
        }
        #endregion

        #region Double Click
        private void txtpettyCashAccountID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccountName(ref txtpettyCashAccountID);
            if (txtpettyCashAccountID.Tag != null)
            {
                try
                {
                    txtFromLineNo.Text = "";
                    var vLstRems = tbl_bpsPettyCashAccount_Transaction
                        .SelectAllByPettyCashAccount_ID(txtpettyCashAccountID.Tag.ToString())
                        .Where(p => !p.IsDeleted && p.ReimbRequest_ID == "default").ToList();
                    if (vLstRems.Any())
                        txtFromLineNo.Text = vLstRems.Min(p => p.Line_No).ToString();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
        private void txtPCReimbRequestNo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashReimbursement(ref txtPCReimbRequestNo, chkShowSettle.Checked);
            if (txtPCReimbRequestNo.Tag != null && txtPCReimbRequestNo.Tag.ToString().Trim().Length > 0)
                FillDetails(txtPCReimbRequestNo.Tag.ToString());
        }
        #endregion

        #region Key Press
        private void txtFromLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtFromLineNo.Text, e);
        }
        private void txtToLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtToLineNo.Text, e);
        }
        #endregion

        #region calculate Opanning Balance
        private decimal calculateOpanningBalance(string PettyCashAccountID, int ifromLineNo)
        {
            decimal dIncomeAmount = 0, dExpenditureAmount = 0, dOPBalanceAmount = 0;
            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(PettyCashAccountID).Where(p => !p.IsDeleted && p.ReimbRequest_ID != "default").ToList();  //Where(p => p.Line_No < ifromLineNo).ToList();
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
            {
                if (detail.IsIncome)
                {
                    dIncomeAmount = dIncomeAmount + +detail.Amount;
                }
                else if (detail.IsExpenditure)
                {
                    dExpenditureAmount = dExpenditureAmount + detail.Amount;
                }
            }
            dOPBalanceAmount = dIncomeAmount - dExpenditureAmount;
            return dOPBalanceAmount;
        }
        #endregion

        #region Validate
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtFromLineNo.TextLength == 0)
            {
                strMessage += "\n" + "From Line No";
                bStatus = false;
            }
            if (txtToLineNo.TextLength == 0)
            {
                strMessage += "\n" + "To Line No";
                bStatus = false;
            }
            if (txtpettyCashAccountID.TextLength == 0)
            {
                strMessage += "\n" + "Petty Cash Account";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;

        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!IsUpdate)
            {
                List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(txtpettyCashAccountID.Tag.ToString()).Where(p => p.Line_No >= int.Parse(txtFromLineNo.Text) && p.Line_No <= int.Parse(txtToLineNo.Text) && p.ReimbRequest_ID != "default").ToList();
                foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
                {
                    strMessage += "\n" + "Printed income or expenditure in this range ";
                    bStatus = false;
                    break;
                }

                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return bStatus;
        }
        #endregion


        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsMethods_GL.CheckValidity_FinancialYear(dtpReimbDate.Value.Date))
            {
                if (CheckValidity())
                {
                    btnAdd_Click(sender, e);
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKey();

                            //if (clsValidate.CheckValidity_TransactionCodeLength(txtPCReimbRequestNo.Text)) //if (txtPCReimbRequestNo.TextLength > 0)
                            //{
                            if (IsUpdate)  //update records
                            {
                                tbl_bpsPettyCashReimbursement oldRecord = tbl_bpsPettyCashReimbursement.Select(txtPCReimbRequestNo.Text.Trim());
                                if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                {
                                    if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPCReimbRequestNo.Text))
                                        {
                                            #region Set Default tbl_bpsPettyCashAccount_Transaction Old Recode Detail
                                            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(txtpettyCashAccountID.Tag.ToString()).Where(p => p.ReimbRequest_ID == oldRecord.ReimbRequest_ID).ToList();
                                            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
                                            {
                                                detail.ReimbRequest_ID = "default";
                                                detail.Update();
                                            }
                                            #endregion

                                            #region Update Petty Cash Account Transaction
                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                int iLine_No = 0;
                                                iLine_No = clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0"));

                                                tbl_bpsPettyCashAccount_Transaction Tdetail = tbl_bpsPettyCashAccount_Transaction.Select(iLine_No, txtpettyCashAccountID.Tag.ToString());
                                                if (Tdetail != null)
                                                {
                                                    Tdetail.ReimbRequest_ID = txtPCReimbRequestNo.Text.Trim();
                                                    Tdetail.Update();
                                                }
                                            }
                                            #endregion

                                            #region Update Heder
                                            tbl_bpsPettyCashReimbursement Hederdetail = new tbl_bpsPettyCashReimbursement(txtPCReimbRequestNo.Text, dtpReimbDate.Value, txtpettyCashAccountID.Tag.ToString(), int.Parse(txtFromLineNo.Text), int.Parse(txtToLineNo.Text), txtRemark.Text, decimal.Parse(txtOpaningBalance.Text), decimal.Parse(txtIncome.Text), decimal.Parse(txtExpenditure.Text), decimal.Parse(txtClosingBalance.Text), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                            oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsSeattled, oldRecord.PrintCount);
                                            Hederdetail.Update();
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    txtPCReimbRequestNo.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                if (clsValidate.CheckValidity_TransactionCodeLength(txtPCReimbRequestNo.Text)) //if (txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
                                {
                                    #region Insert
                                    tbl_bpsPettyCashReimbursement detail = new tbl_bpsPettyCashReimbursement(txtPCReimbRequestNo.Text, dtpReimbDate.Value, txtpettyCashAccountID.Tag.ToString(), int.Parse(txtFromLineNo.Text), int.Parse(txtToLineNo.Text), txtRemark.Text, decimal.Parse(txtOpaningBalance.Text), decimal.Parse(txtIncome.Text), decimal.Parse(txtExpenditure.Text), decimal.Parse(txtClosingBalance.Text), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString().Trim(),
                                txtApprovedBy.Tag.ToString().Trim(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, 0);
                                    detail.Insert();
                                    #endregion

                                    #region Update Petty Cash Account Transaction
                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                    {
                                        int iLine_No = 0;
                                        iLine_No = clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0"));

                                        tbl_bpsPettyCashAccount_Transaction Tdetail = tbl_bpsPettyCashAccount_Transaction.Select(iLine_No, txtpettyCashAccountID.Tag.ToString());
                                        if (Tdetail != null)
                                        {
                                            Tdetail.ReimbRequest_ID = txtPCReimbRequestNo.Text.Trim();
                                            Tdetail.Update();
                                        }
                                    }
                                    #endregion

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show(" PC Reimb Request No " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            FillDetails(txtPCReimbRequestNo.Text);
                        }
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
                if (txtPCReimbRequestNo.TextLength > 0 && txtPCReimbRequestNo.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    tbl_bpsPettyCashReimbursement oOrder = tbl_bpsPettyCashReimbursement.Select(txtPCReimbRequestNo.Text.Trim());
                    if (oOrder != null)
                    {
                        //Write Audit Trial Log
                        clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder), oOrder.ReimbRequest_ID);

                        oOrder.PrintCount++;
                        oOrder.DatePrinted = clsSecurity.getServerDateTime();
                        oOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
                        oOrder.PrintedUser_ID = clsSecurity.UserIDLoged;

                        sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ] [ " + oOrder.DateCreate.ToShortDateString() + " ]";
                        if (oOrder.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ] [ " + oOrder.DateChecked.ToShortDateString() + " ]";
                        if (oOrder.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ] [ " + oOrder.DateApproved.ToShortDateString() + " ]";
                        oOrder.Update();
                    }

                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sReportTitle = "PETTY CASH REIMBURSEMENT STATEMENT", sFormula = "";
                    if (txtPCReimbRequestNo.TextLength > 0)
                        sFormula = "{vw_rpt_bpsPettyCashReimbursement.reimbRequest_ID} = '" + txtPCReimbRequestNo.Text.Trim() + "'";

                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += "\\Reports\\PET\\Basic\\rpt_bpsPettyCashTransactionReimbursement.rpt";
                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                    //  clsSecurity.LogonServer(ref RD);
                    RD.Refresh();


                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                    //RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                    //RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                    // RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(oOrder.Customer_ID));


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
                else
                    MessageBox.Show("Please Select the Customer Order To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region btn Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    RefreshGrid(txtpettyCashAccountID.Tag.ToString(), int.Parse(txtFromLineNo.Text), int.Parse(txtToLineNo.Text));
                }
            }
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPCReimbRequestNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblPCReimbRequestNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtpettyCashAccountID, true);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPCReimbRequestNo.Text = "<Auto Generate>";
            else
                txtPCReimbRequestNo.Clear();

            txtFromLineNo.Clear();
            txtToLineNo.Clear();
            txtpettyCashAccountID.Clear();
            txtOpaningBalance.Clear();
            txtIncome.Clear();
            txtExpenditure.Clear();

            txtpettyCashAccountID.Tag = null;
            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion


        #region FillDetails
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsPettyCashReimbursement detail = tbl_bpsPettyCashReimbursement.Select(sID);
                    if (detail != null)
                    {
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPCReimbRequestNo, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtpettyCashAccountID, false);

                        RefreshGrid(detail.PettyCashAccount_ID, detail.ReimbRequest_ID);

                        dtpReimbDate.Value = detail.ReimbRequestDate;
                        txtpettyCashAccountID.Text = clsGenaralName.getName_PettyCashAccount(detail.PettyCashAccount_ID);
                        txtpettyCashAccountID.Tag = detail.PettyCashAccount_ID;
                        txtFromLineNo.Text = clsFormatter.FormatToNumberNoDecimal(detail.RangeFrom);
                        txtToLineNo.Text = clsFormatter.FormatToNumberNoDecimal(detail.RangeTo);
                        txtIncome.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalIncome);
                        txtExpenditure.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalExpenditure);
                        txtOpaningBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OPBalanceTotal);
                        txtClosingBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalIncome - detail.TotalExpenditure + detail.OPBalanceTotal);
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

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtCheckedBy);
                clsCommon.ValidateForeignKey(ref txtApprovedBy);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Delete
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPCReimbRequestNo.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpReimbDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_bpsPettyCashReimbursement detail = tbl_bpsPettyCashReimbursement.Select(txtPCReimbRequestNo.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Petty Cash Reimbursement : " + detail.ReimbRequest_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            //////Update Other Tables 

                                            DateTime lastdate = tbl_bpsPettyCashReimbursement.SelectAll().Where(p => p.PettyCashAccount_ID == detail.PettyCashAccount_ID).Max(p => p.DateCreate);

                                            tbl_bpsPettyCashReimbursement ReimbRequestdetail = tbl_bpsPettyCashReimbursement.SelectAll().SingleOrDefault(p => p.DateCreate == lastdate);

                                            if (ReimbRequestdetail != null)
                                            {
                                                if (ReimbRequestdetail.ReimbRequest_ID == detail.ReimbRequest_ID)
                                                {
                                                    #region Set Default tbl_bpsPettyCashAccount_Transaction Old Recode Detail
                                                    List<tbl_bpsPettyCashAccount_Transaction> Trndetails = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(txtpettyCashAccountID.Tag.ToString()).Where(p => p.ReimbRequest_ID == detail.ReimbRequest_ID).ToList();
                                                    foreach (tbl_bpsPettyCashAccount_Transaction Trndetail in Trndetails)
                                                    {
                                                        Trndetail.ReimbRequest_ID = "default";
                                                        Trndetail.Update();
                                                    }
                                                    #endregion

                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();
                                                    detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                    //-K-

                                                    detail.IsDeleted = true;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("You can delete only last reimbursed number", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
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
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }



        }
        #endregion


    }
}
