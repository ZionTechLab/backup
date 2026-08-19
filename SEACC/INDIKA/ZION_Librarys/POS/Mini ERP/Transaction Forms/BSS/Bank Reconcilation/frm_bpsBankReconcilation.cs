using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using DataTire;

namespace Digiteq
{
    public partial class frm_bpsBankReconcilation : SEACC_Form
    {
        #region Variables
        public DataTable dtReconcilation = new DataTable();
        #endregion

        #region Form load
        public frm_bpsBankReconcilation()
        {
            InitializeComponent();
        }

        public frm_bpsBankReconcilation(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            dgvReconcile.AutoGenerateColumns = false;
        }

        private void frm_bpsBankReconcilation_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, false, false, false, false, false, false);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvReconcile, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvBank, clsFormatter.colorGrid, UI_Color);
            RefreshGridBank();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridBank()
        {
            try
            {
                int iRow;
                dgvBank.Rows.Clear();

                foreach (tbl_genCompanyAccount detail in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber != "default" && p.CompanyID != "default" && p.AccountNumber != ""))
                {
                    tbl_zBank oBank = tbl_zBank.Select(detail.Bank_ID);
                    if (oBank != null)
                    {
                        dgvBank.Rows.Add();
                        iRow = dgvBank.Rows.Count - 1;

                        dgvBank["BankAccNo", iRow].Value = detail.AccountNumber;
                        dgvBank["BankID", iRow].Value = oBank.Bank_ID;
                        dgvBank["Bank", iRow].Value = oBank.SortName;
                        dgvBank["CompanyAccNo", iRow].Value = detail.CompanyAccount_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void RefreshGridReconcilation()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dtReconcilation.Rows.Clear();

                int iCompanyAccID = clsValidate.ValidateGridValue(dgvBank, "CompanyAccNo", dgvBank.SelectedRows[0].Index, 0);

                dtReconcilation.Merge(DBHandling.ExecQuery("exec sp_GetBankReconcilation '" + clsSecurity.CompanyID + "','" + clsSecurity.BranchID + "'," + iCompanyAccID).Tables[0]);
                dgvReconcile.DataSource = dtReconcilation;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion

        private void dgvBank_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                RefreshGridReconcilation();
            }
        }

        private void btnRecNew_Click(object sender, EventArgs e)
        {
            if (dgvBank.SelectedRows.Count != 0)
            {
                int iCompanyAccID = clsValidate.ValidateGridValue(dgvBank, "CompanyAccNo", dgvBank.SelectedRows[0].Index, -1);
                if (iCompanyAccID != -1)
                {
                    frm_bpsNewReconcilation frm = new frm_bpsNewReconcilation(iCompanyAccID);
                    tbl_genCompanyAccount oComAccount = tbl_genCompanyAccount.Select(iCompanyAccID);
                    if (oComAccount != null)
                    {
                        frm.lblBank.Tag = oComAccount.Bank_ID;
                        frm.lblBank.Text = clsGenaralName.getName_Bank(oComAccount.Bank_ID);

                        frm.lblAccountNo.Text = oComAccount.AccountNumber;

                        string sQuary = "SELECT dbo.GetLastReconcileDate('" + oComAccount.AccountNumber + "')";
                        DateTime dLastDate = DBHandling.ExecQuery_ReturnDateTime(sQuary);
                        frm.dtpFromDate.Value = dLastDate.AddDays(1);

                        string sQuary2 = "SELECT dbo.GetLastReconcileBalance('" + oComAccount.AccountNumber + "')";
                        decimal dLastBalance = DBHandling.ExecQuery_ReturnDecimal(sQuary2);
                        frm.txtLastBalance.Text = clsFormatter.FormatDecimalPlaces_Price(dLastBalance);
                    }

                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        frm_bpsReconcilationBankStatement frm2 = new frm_bpsReconcilationBankStatement(FormName.BankReconcilationStatement, iCompanyAccID, frm.txtStatementNo.Text, frm.dtpFromDate.Value, frm.dtpStatementDate.Value, decimal.Parse(frm.txtStatementBalance.Text), decimal.Parse(frm.txtLastBalance.Text));
                        clsHelpMethods_Local.DisplayForm(frm2, clsFormatter.colorBills, (this.Parent as Form).MdiParent,true);

                        RefreshGridReconcilation();
                    }
                }
            }
        }

        private void btnRecCancel_Click(object sender, EventArgs e)
        {
            if (dgvReconcile.RowCount > 0)
            {
                int iRecSerial = -1;
                int iCompanyAccID = clsValidate.ValidateGridValue(dgvBank, "CompanyAccNo", dgvBank.SelectedRows[0].Index, -1);
                 iRecSerial = clsValidate.ValidateGridValue(dgvReconcile, "recSerial_ID", dgvReconcile.SelectedRows[0].Index, iRecSerial);

                if (iRecSerial != -1)
                {
                    string sQuary = "SELECT dbo.GetLastReconcilation(" + iCompanyAccID + ")";
                    int iLastRecID = DBHandling.ExecQuery_ReturnInt(sQuary);

                    if (iRecSerial == iLastRecID)
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, iLastRecID.ToString()), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (msgResult == DialogResult.Yes)
                        {
                            tbl_bpsBankReconciliation oBankRec = tbl_bpsBankReconciliation.Select(iCompanyAccID, iLastRecID);
                            if (oBankRec != null)
                            {
                                #region Cash Deposite Detail
                                foreach (tbl_bpsCashDeposit oCashDeposite in tbl_bpsCashDeposit.SelectAll().Where(p => p.CompanyAccount_ID == oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo))//need to optimize
                                {
                                    oCashDeposite.IsReconciled = false;
                                    oCashDeposite.RecSerialNo = -1;
                                    oCashDeposite.Update();
                                }
                                #endregion

                                #region Acc ChequeReconcilation
                                string sAccChqReconciledID = "";
                                foreach (tbl_accChequeReconciliation_Detail oAccChequeReconcilationDetail in tbl_accChequeReconciliation_Detail.SelectAll().Where(p => p.CompanyAccount_ID == oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo))//need to optimaize
                                {
                                    #region Update AccChequeRegister
                                    tbl_accChequeRegister oChequeRegister = tbl_accChequeRegister.Select(oAccChequeReconcilationDetail.ChequeRegister_ID);
                                    if (oChequeRegister != null)
                                    {
                                      //  oChequeRegister.ReconcilationDate = oChequeRegister.DateCheque;
                                        oChequeRegister.IsLocked = false;
                                        oChequeRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.New);
                                        oChequeRegister.RecSerialNo = -1;
                                        oChequeRegister.Update();
                                    }
                                    foreach (tbl_accChequeReconciliation oRec in tbl_accChequeReconciliation.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccID && p.RecSerialNo == iRecSerial))
                                    {
                                        tbl_accChequeReconciliation_Detail.DeleteAllByReconciliation_ID(oRec.Reconciliation_ID);
                                        oRec.Delete();
                                    }
                                    #endregion

                                    sAccChqReconciledID = oAccChequeReconcilationDetail.Reconciliation_ID;
                                    oAccChequeReconcilationDetail.Delete();
                                }

                                tbl_accChequeReconciliation oAccChequeReconcilation = tbl_accChequeReconciliation.Select(sAccChqReconciledID);
                                if (oAccChequeReconcilation != null)
                                {
                                    oAccChequeReconcilation.IsDeleted = true;
                                    oAccChequeReconcilation.Update();
                                }
                                #endregion

                                #region Cheque Deposite Detail
                                string sBpsChqReconciledID = "";

                                foreach (tbl_bpsChequeDeposit_Detail oChequeDepositeDetail in tbl_bpsChequeDeposit_Detail.SelectAll().Where(p => p.CompanyAccount_ID == oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo))
                                {
                                    tbl_bpsChequeRegister oRegister = tbl_bpsChequeRegister.Select(oChequeDepositeDetail.ChequeRegister_ID);
                                    if (oRegister != null)
                                    {
                                        List<tbl_bpsChequeDeposit_Detail> oDep = tbl_bpsChequeDeposit_Detail.SelectAllByChequeRegister_ID(oChequeDepositeDetail.ChequeRegister_ID);
                                        if (oDep.Count > 1)
                                        {
                                            oRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited);
                                            oChequeDepositeDetail.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited);
                                        }
                                        else
                                        {
                                            oRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deposited);
                                            oChequeDepositeDetail.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deposited);
                                        }
                                        oChequeDepositeDetail.RecSerialNo = -1;
                                        oChequeDepositeDetail.Update();

                                        oRegister.DateReconcilied = oRegister.DateRegister;
                                        oRegister.IsReconcilied = false;
                                        oRegister.Update();
                                    }
                                }
                                
                                tbl_bpsChequeReconciliation oBpsChequeReconcilation = tbl_bpsChequeReconciliation.Select(sBpsChqReconciledID);
                                if (oBpsChequeReconcilation != null)
                                {
                                    foreach (tbl_bpsChequeReconciliation_Detail oChequeReconcilationDetail in tbl_bpsChequeReconciliation_Detail.SelectAll().Where(p => p.CompanyAccount_ID == oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo))
                                    {
                                        sBpsChqReconciledID = oChequeReconcilationDetail.Reconciliation_ID;
                                        oChequeReconcilationDetail.Delete();
                                    }
                                        oBpsChequeReconcilation.IsDeleted = true;
                                    oBpsChequeReconcilation.Update();
                                }
                                #endregion

                                #region BE
                                foreach (tbl_accJournalEntry_Detail oJEDetail in tbl_accJournalEntry_Detail.SelectAll().Where(p => p.CompanyAccount_ID == oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo))
                                {
                                    oJEDetail.IsReconciled = false;
                                    oJEDetail.RecSerialNo = -1;
                                    oJEDetail.Update();
                                }
                                #endregion

                                #region BT
                                foreach (tbl_bpsChequeRegister oRegister in tbl_bpsChequeRegister.SelectAll().Where(p =>p.CompanyAccount_ID== oBankRec.CompanyAccount_ID && p.RecSerialNo == oBankRec.RecSerialNo && (p.PaymentMethod_ID == (int)PaymentMethod.Bank_Transfer)))
                                {
                                    #region Realized
                                    oRegister.IsReconcilied = false;
                                    oRegister.RecSerialNo = -1;
                                    oRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deposited);
                                    oRegister.Update();
                                    #endregion
                                } 
                                #endregion

                                oBankRec.IsDeleted = true;
                                oBankRec.Update();

                                dgvReconcile.Rows.RemoveAt(dgvReconcile.Rows.Count - 1);

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please Cancel the last Record/s to Cancel this Record.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Please select a Record to Cancel.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No detail to cancel.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvReconcile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string sColName = dgvReconcile.Columns[e.ColumnIndex].Name;
                if (sColName == "recSerialNo")
                {
                    int iCompanyAccID = clsValidate.ValidateGridValue(dgvReconcile, "companyAccID", e.RowIndex, 0);
                    int irecSerial_ID = clsValidate.ValidateGridValue(dgvReconcile, "recSerial_ID", e.RowIndex, 0);


                    frm_bpsReconcilationBankStatement frm2 = new frm_bpsReconcilationBankStatement(FormName.BankReconcilationStatement, iCompanyAccID, irecSerial_ID);
                    clsHelpMethods_Local.DisplayForm(frm2, clsFormatter.colorBills, (this.Parent as Form).MdiParent,true);

                    RefreshGridReconcilation();
                }
            }
        }
    }
}