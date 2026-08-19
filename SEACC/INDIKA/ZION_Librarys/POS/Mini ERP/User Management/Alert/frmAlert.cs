using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmAlert : Form
    {

        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;
        //to keep form detail       
        //string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frmAlert()
        {
            iFormID = clsSecurity.getFormID(FormName.Alerts);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmAlert_Load(object sender, EventArgs e)
        {
            ClearFields();
            FillDetails();
        } 
        #endregion

        #region Btn Refresh Alert
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDetails();
        }
        #endregion

        #region Btn Close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblTodayPendingCheque.Text = "0";
            lblUserName.Text = "";
            lblLocation.Text = "";
            lbloutOfNumber.Text = "";
            lblPendingNotesApprovalCount.Text = "0";
            lblPendingNotesChecking.Text = "";
            lblPendingNotesCheckingCount.Text = "0";
            lblPendingNotesConfirmCount.Text = "0";
            lblDesignation.Text = "";
            lblTodayPendingChequeAmount.Text = "0.00";
            lblTodayPendingCheque.Text = "0";
            lblTotalOnlineUsersNumber.Text = "";
            lblTotalReturnedChequesTotalAmount.Text = "0.00";
            lblTotalReturnedChequesTotalCount.Text = "0";
            lblYesterdayReturnedChequesAmount.Text = "0.00";
            lblYesterdayReturnedChequesCount.Text = "0";
        }
        #endregion

        #region  Fill Details
        private void FillDetails()
        {
            SetPendingChequeDepositDetail();
            YesterDayretunCheques();
            lblUserName.Text = clsSecurity.UserNameLoged;
            lblLocation.Text = "Head Office";
            lblDesignation.Text = clsSecurity.UserGroupLoged;
            //tbl_genCompanyInfo detail = 
            //lblHeadOffice
        }
        #endregion

        #region Set PendingChequeDepositDetail
        private void SetPendingChequeDepositDetail()
        {
            try
            {
                int iCount = 0,  iDepositCount = 0, iDepositCountTotal = 0;
                decimal dAmount = 0,  dDepositAmount = 0, dDepositAmountTotal = 0 ;

                
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                    {
                        if (detail.IsDepositted == false && detail.DateCheque.Date == clsSecurity.getServerDateTime().Date)
                        {
                            dAmount += detail.Amount;
                            iCount++;
                        }
                        if (detail.IsDepositted == false)
                        {
                            iDepositCount++;
                            dDepositAmount += detail.Amount;
                        }
                        if (detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C))
                        {
                            dDepositAmountTotal += detail.Amount;
                            iDepositCountTotal++;
                        }

                        #region Yester day retun Cheques
                        //if (detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C))
                        //{


                        //    List<tbl_bpsChequeReconciliation_Detail> Rdetails = tbl_bpsChequeReconciliation_Detail.SelectAll();
                        //    foreach (tbl_bpsChequeReconciliation_Detail Rdetail in Rdetails)
                        //    {
                        //        if (Rdetail.ChequeRegister_ID == detail.ChequeRegister_ID)
                        //        {
                        //            tbl_bpsChequeReconciliation ChequeReconciliation = tbl_bpsChequeReconciliation.Select(Rdetail.ChequeRegister_ID);
                        //            if (ChequeReconciliation != null)
                        //                if (ChequeReconciliation.DateReconciliation.Date != clsSecurity.getServerDateTime().Date)
                        //                {
                        //                    dDepositAmountTotal += detail.ChequeAmount;
                        //                    iDepositCountTotal++;
                        //                }

                        //        }

                        //    }

                        //} 
                        #endregion
                    }
                }

                lblTodayPendingCheque.Text = iCount.ToString();
                lblTodayPendingChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);

                lblTodatePendingChequeDepositedTotalCount.Text = iDepositCount.ToString();
                lblTodatePendingChequeDepositedTotalAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDepositAmount);

            

                lblTotalReturnedChequesTotalCount.Text = iDepositCountTotal.ToString();
                lblTotalReturnedChequesTotalAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDepositAmountTotal);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            // CalculateChequeAmount();
        } 

        #endregion

        #region Yester Dayretun Cheques
        private void YesterDayretunCheques()
        {
            decimal dReturnAmount = 0;
            int iReturnCount = 0;
            List<tbl_bpsChequeReconciliation> Rdetails = tbl_bpsChequeReconciliation.SelectAll();
            foreach (tbl_bpsChequeReconciliation Rdetail in Rdetails)
            {
                if (Rdetail.DateReconciliation.Date == clsSecurity.getServerDateTime().Date.AddDays(-1))
                {
                    List<tbl_bpsChequeReconciliation_Detail> ChequeReconciliationDetail = tbl_bpsChequeReconciliation_Detail.SelectAllByReconciliation_ID(Rdetail.Reconciliation_ID);

                    foreach (tbl_bpsChequeReconciliation_Detail CRdetail in ChequeReconciliationDetail)
                    {
                        tbl_bpsChequeRegister ChequeReconciliation = tbl_bpsChequeRegister.Select(CRdetail.ChequeRegister_ID);
                        if (ChequeReconciliation.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || ChequeReconciliation.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || ChequeReconciliation.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C))
                        {
                            dReturnAmount += ChequeReconciliation.Amount;
                            iReturnCount++;
                        }
                    }
                }
            }
            lblYesterdayReturnedChequesCount.Text = iReturnCount.ToString();
            lblYesterdayReturnedChequesAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dReturnAmount);
        } 
        #endregion



       


    }
}
