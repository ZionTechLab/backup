using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_accChequeToNewMode_PV : MettroForm
    {
        #region Public variables
        public int iFormID;
        public bool bNoAccess;
        string sChequeRegisterID;
        #endregion

        #region Form Load   
        public frm_accChequeToNewMode_PV()
        {
            iFormID = clsSecurity.getFormID(FormName.ChequeToNewModePV);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_accChequeToNewMode_PV_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Cheque to New Mode [PV]", 6, iFormID);
            ClearFields();
        }
        #endregion

        #region Search 
        private void txtPV_DoubleClick(object sender, EventArgs e)
        {
            string sChequeNo = "";
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ChequeregisterByPV);

            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtPV.Tag = lstResult[0];
                txtPV.Text = lstResult[0];
                sChequeNo = lstResult[1];
                sChequeRegisterID = lstResult[2];
            }
        }
        #endregion

        #region Btn Unlock
        private void btnNewMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPV.Tag != null)
                {
                    DialogResult msgResult = MessageBox.Show("Do You Want To Unlock this Cheque? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        tbl_accChequeRegister oCheque = tbl_accChequeRegister.Select(sChequeRegisterID);
                        if (oCheque != null)
                        {
                            if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized))
                            {
                                #region tbl_accChequeReconciliation
                                foreach (tbl_accChequeReconciliation_Detail oReconDetail in tbl_accChequeReconciliation_Detail.SelectAll().Where(p => p.ChequeRegister_ID == oCheque.ChequeRegister_ID))
                                {
                                    tbl_accChequeReconciliation oRecon = tbl_accChequeReconciliation.Select(oReconDetail.Reconciliation_ID);
                                    if (oRecon != null)
                                    {
                                        oReconDetail.Delete();
                                    }
                                }
                                #endregion

                                oCheque.ChequeStatus_ID = "0";
                                // oCheque.IsReconcilied = false;
                                oCheque.PrintCount = 0;
                                oCheque.Update();

                                MessageBox.Show("Successfully Updated !!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This is a Realized Cheque, It is Not Allow To Set To New Mode .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Please select a Cheque to Unlock !!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                ClearFields();
            }
        }

        private void btnUnlockPV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPV.Tag != null)
                {
                    DialogResult msgResult = MessageBox.Show("Do You Want To Unlock this Payment Voucher? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        tbl_accChequeRegister oCheque = tbl_accChequeRegister.Select(sChequeRegisterID);
                        if (oCheque != null)
                        {
                            if (oCheque.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized))
                            {
                                tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(txtPV.Tag.ToString());
                                if (oPV != null)
                                {
                                    oPV.PrintCount = 0;
                                    oPV.Update();

                                    MessageBox.Show("Successfully Updated !!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show("This is already Realized, It is Not Allow To Set To New Mode .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Please select a Payment Voucher to Unlock !!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                ClearFields();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtPV.Tag = null;
            txtPV.Clear();
        }

        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

    }
}
