using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using DataTire;

namespace Digiteq.User_Management.Tools
{
    public partial class frm_bpsCashDepositCancelation_NewVersion : SEACC_Form
    {
        /*Todo
         *2019-06-11 <Gayan>
         *POS Cash deposies must be linked here
         */

        #region Form Load
        public frm_bpsCashDepositCancelation_NewVersion(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_bpsCashDepositCancelation_NewVersion_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, false, false, false, false, false, false);
            ClearFields();
        }
        #endregion

        #region  Btn Save
        private void btnReverce_Click(object sender, EventArgs e)
        {
            if (txtReciept.Tag != null)
            {
                DialogResult msgResult = MessageBox.Show("Do You Want To Reverse Cash Deposit? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    string sRemark = "Error", sActivity = "Error";

                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        #region Cheque
                        tbl_bpsCashDeposit_Detail oldRecord = tbl_bpsCashDeposit_Detail.Select(txtReciept.Tag.ToString(),txtReciept.Text);
                        tbl_bpsCashDeposit oCashDeposit = tbl_bpsCashDeposit.Select(oldRecord.CashDeposit_ID);
                        sRemark = "Cash Deposit Cancelation || Deposit ID - " + oCashDeposit.CashDeposit_ID + " ||  Amount - " + clsFormatter.FormatDecimalPlaces_UnitPrice(oCashDeposit.TotalAmount);
                        if (oldRecord != null && oCashDeposit != null)
                        {
                            if (!oCashDeposit.IsReconciled)
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(oCashDeposit.DateDeposit))
                                {
                                    #region Receipts
                                    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.SelectAllByReceipt_ID(oldRecord.Receipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash).FirstOrDefault();
                                    if (detail != null && detail.ChequeRegister_ID != "default")
                                    {
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);

                                        //   decimal dCashAmount = 0;


                                        // dCashAmount = detail.Amount;
                                        detail.DepositedCashAmount -= oldRecord.DepositedAmount;
                                        detail.IsDepositted = false;
                                        detail.Update();


                                        //tbl_accAccountReceipt ARdetail = tbl_accAccountReceipt.Select(oldRecord.Receipt_ID);
                                        //if (ARdetail != null && ARdetail.AccountReceipt_ID != "default")
                                        //{
                                        //    //  dCashAmount = ARdetail.CashAmount;
                                        //    ARdetail.IsCashDeposited = false;
                                        //    ARdetail.Update();
                                        //}

                                        oCashDeposit.TotalAmount -= oldRecord.DepositedAmount;
                                        oCashDeposit.DepositedAmount -= oldRecord.DepositedAmount;
                                        --oCashDeposit.TotalReceipt;

                                        oCashDeposit.Update();

                                        oldRecord.Delete();
                                        sActivity = "Cash Has Set To New Mode.";
                                        MessageBox.Show(sActivity, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    #endregion

                                    #region Account Receipts
                                    tbl_bpsChequeRegister Chqdetail = tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(oldRecord.Receipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash).FirstOrDefault();
                                    if (Chqdetail != null && Chqdetail.ChequeRegister_ID != "default")
                                    {
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);

                                        //Chqdetail.DepositedCashAmount -= oldRecord.DepositedAmount;
                                        Chqdetail.IsDepositted = false;
                                        Chqdetail.Update();

                                        tbl_accAccountReceipt ARdetail = tbl_accAccountReceipt.Select(oldRecord.Receipt_ID);
                                        if (ARdetail != null && ARdetail.AccountReceipt_ID != "default")
                                        {
                                            ARdetail.IsCashDeposited = false;
                                            ARdetail.DepositedCashAmount -= oldRecord.DepositedAmount;
                                            ARdetail.Update();
                                        }

                                        oCashDeposit.TotalAmount -= oldRecord.DepositedAmount;
                                        oCashDeposit.DepositedAmount -= oldRecord.DepositedAmount;
                                        --oCashDeposit.TotalReceipt;
                                        oCashDeposit.Update();

                                        oldRecord.Delete();
                                        sActivity = "Cash Has Set To New Mode.";
                                        MessageBox.Show(sActivity, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                MessageBox.Show("This is already Relized , It is Not Allow To Set To New Mode .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            sActivity = "Cash Record is Invalid";
                            MessageBox.Show("This Record is Invalid........!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        arc_audAuditTrailLog oAdutLog = new arc_audAuditTrailLog(clsSecurity.getServerDateTime(), clsSecurity.CompanyID + " || " + clsSecurity.BranchID, clsSecurity.UserIDLoged, clsSecurity.TerminalID, "", "", "", sActivity, sRemark);
                        oAdutLog.Insert();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        #endregion

        #region btn Reset
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtReciept.ReadOnly = true;
            txtReciept.Tag = null;
            txtReciept.Clear();
        }

        #endregion

        private void txtReciept_DoubleClick(object sender, EventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CashDeposites);

            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtReciept.Tag = lstResult[0];
                txtReciept.Text = lstResult[1];
            }
        }
    }
}
