using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Digiteq
{
    public partial class frm_rpt_PettyCashAccountr : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        bool bExpenditureType = false, bIncomeType = false, bPettyCashAccountID = false, bSpentBy = false,
            bActivity = false, bCostCenter = false, bSuplier = false, bLevel1 = false, bLevel2 = false, bLevel3 = false,
            bVoucherNo = false;

        //form manage
        string sFormConfigCode;
        public int iFormID;

        //for security handle
        public bool bNoAccess;
      //  public bool bHasChecked;
    //    public bool bHasApproved;
      //  DateTime glbApprovedDate = clsSecurity.getServerDateTime();
     //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region From Load
        public frm_rpt_PettyCashAccountr()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportPettyCashAccount);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
            clearField();
        }
        private void frm_bpsPettyCashAccount_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, " Cash Book Report", 3, iFormID);
            clearField();
        }
        #endregion


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
        #endregion

        #region Event Double Click
        private void txtPettyCashAccount_ID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount(ref txtPettyCashAccountID);
            if (txtPettyCashAccountID.Tag != null)
                txtPettyCashAccountID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCashAccount(txtPettyCashAccountID.Tag.ToString()));
        }
        private void txtExpenditureType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashExpenditureType(ref txtExpenditureType);
        }
        private void txtIncomeType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashIncomeType(ref txtIncomeType);
        }
        private void txtVoucherNo_DoubleClick(object sender, EventArgs e)
        {
            if (txtPettyCashAccountID.Tag != null)
                clsSearch.Search_TransactionPettyCashAccountVoucherNoBypettyCashAccount(ref txtVoucherNo, txtPettyCashAccountID.Tag.ToString());
            else
                clsSearch.Search_TransactionPettyCashAccountVoucherNo(ref txtVoucherNo);
        }
        private void txtSpentBy_DoubleClick(object sender, EventArgs e)
        {
            if (txtPettyCashAccountID.Tag != null)
                clsSearch.Search_TransactionPettyCashAccountSpentUserNameBypettyCashAccount(ref txtSpentBy, txtPettyCashAccountID.Tag.ToString());
            else
                clsSearch.Search_TransactionPettyCashAccountSpentUserName(ref txtSpentBy);
        }
        private void txtSuplier_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType2(ref txtSuplier, clsConfig.sCostCenter2);
        }
        private void txtCostCenter_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType(ref txtCostCenter, clsConfig.sCostCenter1);
        }
        private void txtActivity_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType3(ref txtActivity, clsConfig.sCostCenter3);
        }
        private void txtLevel1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel1);
        }
        private void txtLevel2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel2);
        }
        private void txtLevel3_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel3);
        }
        #endregion

        #region Event key Down
        private void txtPettyCashAccount_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPettyCashAccount(ref txtPettyCashAccountID);
            }
        }
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtPettyCashAccountID.Tag != null)
                    clsSearch.Search_TransactionPettyCashAccountVoucherNoBypettyCashAccount(ref txtVoucherNo, txtPettyCashAccountID.Tag.ToString());
                else
                    clsSearch.Search_TransactionPettyCashAccountVoucherNo(ref txtVoucherNo);
            }
        }
        private void txtSpentBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtPettyCashAccountID.Tag != null)
                    clsSearch.Search_TransactionPettyCashAccountSpentUserNameBypettyCashAccount(ref txtSpentBy, txtPettyCashAccountID.Tag.ToString());
                else
                    clsSearch.Search_TransactionPettyCashAccountSpentUserName(ref txtSpentBy);
            }
        }
        #endregion

        #region Evevnt Checked Changed
        private void rdoSelectedAccount_CheckedChanged(object sender, EventArgs e)
        {

            txtPettyCashAccountID.Enabled = true;
        }

        private void rdoAllAccount_CheckedChanged(object sender, EventArgs e)
        {

            txtPettyCashAccountID.Enabled = false;
            txtPettyCashAccountID.Clear();

        }
        private void chkIncomeType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpenditureType.Checked)
            {
                //chkExpenditureType.Checked = true;
                txtExpenditureType.Enabled = true;
                txtLevel1.Enabled = true;
                txtLevel2.Enabled = true;
                txtLevel3.Enabled = true;
                txtIncomeType.Enabled = false;
                chkIncomeType.Checked = false;
            }
            if (chkIncomeType.Checked)
            {
                txtExpenditureType.Enabled = false;
                txtLevel1.Enabled = false;
                txtLevel2.Enabled = false;
                txtLevel3.Enabled = false;
                txtIncomeType.Enabled = true;
                chkIncomeType.Checked = true;
                chkExpenditureType.Checked = false;

            }
            else
            {
                clearField();
            }
        }
        private void chkExpenditureType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncomeType.Checked)
            {
                chkIncomeType.Checked = true;
                chkExpenditureType.Checked = false;
                txtIncomeType.Enabled = true;
                txtExpenditureType.Enabled = false;
                txtLevel1.Enabled = false;
                txtLevel2.Enabled = false;
                txtLevel3.Enabled = false;
            }
            else if (chkExpenditureType.Checked)
            {
                txtIncomeType.Enabled = false;
                chkExpenditureType.Checked = true;
                txtExpenditureType.Enabled = true;
                txtLevel1.Enabled = true;
                txtLevel2.Enabled = true;
                txtLevel3.Enabled = true;
                chkIncomeType.Checked = false;
            }
            else
            {
                clearField();
            }

        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtExpenditureType.Text = "<All Expenditure Types>";
            txtIncomeType.Text = "<All Income Types>";
            txtVoucherNo.Text = "<Voucher No(s)>";
            txtSpentBy.Text = "<All Spenders>";
            txtPettyCashAccountID.Text = "<All Cash Book Accouns>";
            txtActivity.Text = "<All Activity>";
            txtCostCenter.Text = "<All Cost Center>";
            txtSuplier.Text = "<All Suppliers>";
            txtLevel1.Text = "<All Levels Codes>";
            txtLevel2.Text = "<All Levels Codes>";
            txtLevel3.Text = "<All Levels Codes>";

            txtIncomeType.Tag = null;
            txtExpenditureType.Tag = null;
            txtPettyCashAccountID.Tag = null;
            txtSpentBy.Tag = null;
            txtVoucherNo.Tag = null;
            txtActivity.Tag = null;
            txtCostCenter.Tag = null;
            txtSuplier.Tag = null;
            txtLevel1.Tag = null;
            txtLevel2.Tag = null;
            txtLevel3.Tag = null;

            txtIncomeType.Enabled = false;
            txtExpenditureType.Enabled = false;
            txtLevel1.Enabled = false;
            txtLevel2.Enabled = false;
            txtLevel3.Enabled = false;
            chkExpenditureType.Checked = false;
            chkIncomeType.Checked = false;

            bPettyCashAccountID = false;
            bExpenditureType = false;
            bPettyCashAccountID = false;
            bVoucherNo = false;
            bSpentBy = false;
            bIncomeType = false;
            bActivity = false;
            bCostCenter = false;
            bSuplier = false;
            bLevel1 = false;
            bLevel2 = false;
            bLevel3 = false;

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            rdoBillDate.Checked = true;
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpToEnterd, false);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFromEnterd, false);
            //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
            //clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
        }
        #endregion

        #region print
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Cash Book Register";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);

                if (rdoBillDate.Checked)
                    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                if (rdoEnteredDate.Checked)
                    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From  " + dtpFromEnterd.Value.ToString("dd MMM yyyy") + "  To  " + dtpToEnterd.Value.ToString("dd MMM yyyy"));

                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                if (!chkExpenditureType.Checked && !chkIncomeType.Checked)
                    RD.DataDefinition.FormulaFields["OpanningBalace"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(dAmount));

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

        #region Print Permission Validity
        private bool PrintValidity()
        {
            bool bStatus = true;
            if (txtPettyCashAccountID.Tag == null)
            {
                List<tbl_bpsPettyCashAccount> details = tbl_bpsPettyCashAccount.SelectAll();
                foreach (tbl_bpsPettyCashAccount detail in details)
                {
                    if (detail.PettyCashAccount_ID != "default")
                    {
                        if (!(clsSecurity.PermissionToReadPettyCash(detail.PettyCashAccount_ID, clsSecurity.UserIDLoged)))
                        {
                            MessageBox.Show("You have no permission to print Petty Cash Account - " + detail.PettyCashAccountName, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bStatus = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (!(clsSecurity.PermissionToReadPettyCash(txtPettyCashAccountID.Tag.ToString(), clsSecurity.UserIDLoged)))
                {
                    bStatus = false;
                    MessageBox.Show("Access Denied ! \n\nUser does not have permission to access this Petty Cash Account", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return bStatus;
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (txtExpenditureType.Tag != null && txtExpenditureType.Tag.ToString().Trim().Length > 0)
                bExpenditureType = true;
            if (txtIncomeType.Tag != null && txtIncomeType.Tag.ToString().Trim().Length > 0)
                bIncomeType = true;
            if (txtPettyCashAccountID.Tag != null && txtPettyCashAccountID.Tag.ToString().Trim().Length > 0)
                bPettyCashAccountID = true;
            if (txtVoucherNo.Tag != null && txtVoucherNo.Tag.ToString().Trim().Length > 0)
                bVoucherNo = true;
            if (txtSpentBy.Tag != null && txtSpentBy.Tag.ToString().Trim().Length > 0)
                bSpentBy = true;
            if (txtActivity.Tag != null && txtActivity.Tag.ToString().Trim().Length > 0)
                bActivity = true;
            if (txtCostCenter.Tag != null && txtCostCenter.Tag.ToString().Trim().Length > 0)
                bCostCenter = true;
            if (txtSuplier.Tag != null && txtSuplier.Tag.ToString().Trim().Length > 0)
                bSuplier = true;
            if (txtLevel1.Tag != null && txtLevel1.Tag.ToString().Trim().Length > 0)
                bLevel1 = true;
            if (txtLevel2.Tag != null && txtLevel2.Tag.ToString().Trim().Length > 0)
                bLevel2 = true;
            if (txtLevel3.Tag != null && txtLevel3.Tag.ToString().Trim().Length > 0)
                bLevel3 = true;

            if (PrintValidity())
            {
                string sFormula = "";
                string sAccountName = "";
                if (rdoBillDate.Checked)
                    sFormula = " {vw_rpt_bpsPetteyCashTransaction.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsPetteyCashTransaction.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "' and {vw_rpt_bpsPetteyCashTransaction.isDeleted} = false";
                if (rdoEnteredDate.Checked)
                    sFormula = " {vw_rpt_bpsPetteyCashTransaction.P_DateCreate} >= '" + dtpFromEnterd.Value.Year.ToString() + dtpFromEnterd.Value.Month.ToString("00") + dtpFromEnterd.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsPetteyCashTransaction.P_DateCreate} <= '" + dtpToEnterd.Value.Year.ToString() + dtpToEnterd.Value.Month.ToString("00") + dtpToEnterd.Value.Day.ToString("00") + "' and {vw_rpt_bpsPetteyCashTransaction.isDeleted} = false";
                if (bSpentBy)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.spentUserName} = '" + txtSpentBy.Text.ToString() + "'";
                if (bVoucherNo)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.voucherNo} = '" + txtVoucherNo.Text.ToString() + "'";
                if (bPettyCashAccountID)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCashAccount_ID} = '" + txtPettyCashAccountID.Tag.ToString().Trim() + "'";
                if (bExpenditureType)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCashExpenditureTypeName} = '" + txtExpenditureType.Text.ToString() + "'";
                if (bIncomeType)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCashIncomeTypeName} = '" + txtIncomeType.Text.ToString() + "'";
                if (bActivity)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.cost_Center3_ID} = '" + txtActivity.Tag.ToString() + "'";
                if (bCostCenter)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.cost_Center_ID} = '" + txtCostCenter.Tag.ToString() + "'";
                if (bSuplier)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.cost_Center2_ID} = '" + txtSuplier.Tag.ToString().Trim() + "'";
                if (bLevel1)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCash_Level_1Name} = '" + txtLevel1.Text.ToString() + "'";
                if (bLevel2)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCash_Level_2Name} = '" + txtLevel2.Text.ToString() + "'";
                if (bLevel3)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCash_Level_3Name} = '" + txtLevel3.Text.ToString() + "'";
                if (chkExpenditureType.Checked)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.isExpenditure} = true ";
                if (chkIncomeType.Checked)
                    sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.isIncome} = true ";

                if (bPettyCashAccountID)
                    sAccountName = clsGenaralName.getName_PettyCashAccount(txtPettyCashAccountID.Tag.ToString());



                #region Print
                if (chkExpenditureType.Checked)
                {
                    if (bExpenditureType)
                    {
                        //print("\\reports\\rpt_bpsPettyCashTransactionGroupByExpenditureTypes.rpt", txtExpenditureType.Text.ToString(), sFormula);
                        print("\\reports\\PET\\rpt_bpsPettyCashTransaction.rpt", txtExpenditureType.Text.ToString(), sFormula);
                    }
                    else
                    {
                        sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCashExpenditureTypeName} <> 'default'";
                        print("\\reports\\PET\\rpt_bpsPettyCashTransaction.rpt", sAccountName + "EXPENDITURE TRANSACTIONS", sFormula);
                        //print("\\reports\\rpt_bpsPettyCashTransactionGroupByExpenditureTypes.rpt", sAccountName + " Petty Cash Expenditure Detail ", sFormula);
                    }
                }
                if (chkIncomeType.Checked)
                {
                    if (bIncomeType)
                    {
                        //print("\\reports\\rpt_bpsPettyCashTransactionGroupByIncomeTypes.rpt", txtIncomeType.Text.ToString(), sFormula);
                        print("\\reports\\PET\\rpt_bpsPettyCashTransaction.rpt", txtIncomeType.Text.ToString(), sFormula);
                    }
                    else
                    {
                        //print("\\reports\\rpt_bpsPettyCashTransactionGroupByIncomeTypes.rpt", sAccountName + " Petty Cash Income Detail ", sFormula);
                        sFormula = sFormula + " and " + "{vw_rpt_bpsPetteyCashTransaction.pettyCashIncomeTypeName} <> 'default'";
                        print("\\reports\\PET\\rpt_bpsPettyCashTransaction.rpt", sAccountName + "INCOME TRANSACTIONS", sFormula);
                    }
                }
                if (!chkExpenditureType.Checked && !chkIncomeType.Checked)
                {
                    if (txtPettyCashAccountID.Tag != null && txtPettyCashAccountID.TextLength > 0)
                        PettyCashAccountWiseOpanningBalance(txtPettyCashAccountID.Tag.ToString());
                    else
                        OpanningBalance();

                    print("\\reports\\PET\\rpt_bpsPettyCashTransactionWithOpanningBalance.rpt", sAccountName + " INCOME & EXPENDITURE TRANSACTIONS", sFormula);
                }
                #endregion
            }

        }
        #endregion

        #region rdo Changed
        private void rdoBillDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBillDate.Checked)
            {
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpToEnterd, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFromEnterd, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
            }
        }

        private void rdoEnteredDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEnteredDate.Checked)
            {
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpToEnterd, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFromEnterd, true);
            }
        }
        #endregion


        #region Opanning Balance
        decimal dAmount = 0;
        private decimal OpanningBalance()
        {
            decimal ExpenditureAmount = 0, IncomeAmount = 0;
            dAmount = 0;
            if (rdoBillDate.Checked)
                ExpenditureAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.IsExpenditure && p.TransactionDate.Date < dtpFrom.Value.Date).Sum(p => p.Amount);
            if (rdoBillDate.Checked)
                IncomeAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.TransactionDate.Date < dtpFrom.Value.Date && !p.IsExpenditure).Sum(p => p.Amount);

            if (rdoEnteredDate.Checked)
                ExpenditureAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.IsExpenditure && p.DateCreate.Date < dtpFromEnterd.Value.Date).Sum(p => p.Amount);
            if (rdoEnteredDate.Checked)
                IncomeAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.DateCreate.Date < dtpFromEnterd.Value.Date && !p.IsExpenditure).Sum(p => p.Amount);

            dAmount = IncomeAmount - ExpenditureAmount;

            return dAmount;
        }

        private decimal PettyCashAccountWiseOpanningBalance(string PettyCashAccount_ID)
        {
            decimal ExpenditureAmount = 0, IncomeAmount = 0;
            dAmount = 0;

            if (rdoBillDate.Checked)
                ExpenditureAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.PettyCashAccount_ID == PettyCashAccount_ID && p.IsExpenditure && p.TransactionDate.Date < dtpFrom.Value.Date).Sum(p => p.Amount);
            if (rdoBillDate.Checked)
                IncomeAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.PettyCashAccount_ID == PettyCashAccount_ID && p.TransactionDate.Date < dtpFrom.Value.Date && !p.IsExpenditure).ToList().Sum(p => p.Amount);


            if (rdoEnteredDate.Checked)
                ExpenditureAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.PettyCashAccount_ID == PettyCashAccount_ID && p.IsExpenditure && p.DateCreate.Date < dtpFromEnterd.Value.Date).Sum(p => p.Amount);
            if (rdoEnteredDate.Checked)
                IncomeAmount = tbl_bpsPettyCashAccount_Transaction.SelectAll().Where(p => !p.IsDeleted && p.PettyCashAccount_ID == PettyCashAccount_ID && p.DateCreate.Date < dtpFromEnterd.Value.Date && !p.IsExpenditure).Sum(p => p.Amount);

            dAmount = IncomeAmount - ExpenditureAmount;

            return dAmount;
        }
        #endregion
    }
}
