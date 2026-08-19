using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_toolCheckToDepositeMode : Form
    {
        #region Public variables
       public int iFormID; 
        #endregion

        #region Form Load
        private void frm_toolCheckToDepositeMode1_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        public frm_toolCheckToDepositeMode()
        {
            InitializeComponent();
        } 
        #endregion

        #region  Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do You Want To Set this cheque to Deposited mode? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;    

                    #region Cheque
                    if (rdoChequeRegister.Checked)
                    {
                        tbl_bpsChequeRegister oldRecord = tbl_bpsChequeRegister.Select(txtRecodeID.Text.Trim());
                        tbl_bpsChequeReconciliation_Detail.DeleteAllByChequeRegister_ID(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            if (oldRecord.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                            {
                                oldRecord.ChequeStatus_ID = "1";
                                oldRecord.IsReconcilied = false;
                                oldRecord.Update();
                            }
                        }
                    }
                    #endregion


                    ClearFields();
                    MessageBox.Show("Cheque Set to deposited mode.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            txtRecodeID.Tag = null;
            txtRecodeID.Clear();
            rdoChequeRegister.Checked = true;
        }
        #endregion

        #region Event Double Click
        private void txtRecodeID_DoubleClick(object sender, EventArgs e)
        {
            if (rdoChequeRegister.Checked)
                clsSearch.Search_TransactionChequeRegister_Direct(ref txtRecodeID,true);
         
        } 
        #endregion

        #region Event Key Press
        private void txtRecodeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (rdoChequeRegister.Checked)
                    clsSearch.Search_TransactionPrePlane(ref txtRecodeID);
            }
        } 
        #endregion
       
    }
}
