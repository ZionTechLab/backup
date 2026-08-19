#region Using Derectives
using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

#endregion

namespace Digiteq
{
    public partial class frm_rpt_ChequeStanded_APL : Form
    {
        #region Variables
        //form manage
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_rpt_ChequeStanded_APL()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportChequeStanded);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_rpt_ChequeStanded_APL_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Cheque Standard Reports", 2, iFormID);
            clearField();
            rdoChequeToBeDeposited.Checked = false;
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //get selection controls
            bool bCustomerSelected = false, bBankSelected = false, bSalesRepSelected = false;
            string sFormula = "";
            if (txtCustomer.Tag != null)
                bCustomerSelected = true;
            if (txtBank.Tag != null)
                bBankSelected = true;
            if (txtSalesRep.Tag != null)
                bSalesRepSelected = true;

            if (rdoChequeToBeDeposited.Checked)
            {
                sFormula = "{vw_rpt_bpsChequeRegister.pd_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeRegister.pd_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";              

                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                sFormula += " and {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False";
                print("\\reports\\BSS\\Standard\\rpt_sas_PendingDepositChequeSummary.rpt", "Pending Cheque Deposit", sFormula);
            }
            else if (rdoChequesInHandAll.Checked)
            {
                sFormula += " {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";

                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";              


                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHand.rpt", "Cheques In Hand", sFormula);
            }
            else if (rdoRealizedCheques.Checked)
            {
                sFormula = " {vw_rpt_bpsChequeReconciliation.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReconciliation.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeReconciliation.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                if (bBankSelected)
                    sFormula += " and {vw_rpt_bpsChequeReconciliation.bank_ID} = '" + txtBank.Tag.ToString().Trim() + "'";
                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeReconciliation.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";              

                
                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReconciliation.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReconciliation.isDeleted} = False";

                sFormula += " and {vw_rpt_bpsChequeReconciliation.chequeStatus_ID} = '" + clsAutocode.getChequeStatusID(ChequeStatus.Realized) + "'";
                print("\\reports\\BSS\\Standard\\rpt_sas_RealizedChequeSummary.rpt", "Realized Cheque Summary", sFormula);
            }
            else if (rdoReturnCheques.Checked)
            {
                sFormula = " {vw_rpt_bpsChequeReturn.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_bpsChequeReturn.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeReturn.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                if (bBankSelected)
                    sFormula += " and {vw_rpt_bpsChequeReturn.bank_ID} = '" + txtBank.Tag.ToString().Trim() + "'";
                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeReturn.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";           


                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReturn.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReturn.isDeleted} = False";

                sFormula += " and {vw_rpt_bpsChequeReturn.isReturned} = True";
                print("\\reports\\BSS\\Standard\\rpt_sas_ReturnedChequeSummary.rpt", "Returned Cheque Summary", sFormula);
            }
                //
            else if (rdoChequesInHandApprovedForDeposite.Checked)
            {
                sFormula += " {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False and {vw_rpt_bpsChequeRegister.isApproved} = True";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";           

                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHandApproved.rpt", "Cheques in Hand [Approved For Deposit]", sFormula);
            }
            else if (rdoChequesInHandPendingApproval.Checked)
            {
                sFormula += " {vw_rpt_bpsChequeRegister.isDepositted} = False and {vw_rpt_bpsChequeRegister.isReIssued} = False and {vw_rpt_bpsChequeRegister.isApproved} = False";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeRegister.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";           


                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeRegister.isDeleted} = False";

                print("\\reports\\BSS\\Standard\\rpt_sas_ChequesInHandPending.rpt", "Cheques in Hand [Pending Approval]", sFormula);
            }
            else if (rdoReturnedChequesInHand.Checked)
            {
                sFormula += " {vw_rpt_bpsChequeReturn.isSeattled} = False";

                if (bCustomerSelected)
                    sFormula += " and {vw_rpt_bpsChequeReturn.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                if (bSalesRepSelected)
                    sFormula += " and {vw_rpt_bpsChequeReturn.salesRep_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";           


                if (rdoDeleted.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReturn.isDeleted} = True";
                if (rdoActual.Checked)
                    sFormula += " and {vw_rpt_bpsChequeReturn.isDeleted} = False";

                print("\\reports\\BSS\\Standard\\rpt_sas_ReturnedChequesOutstanding.rpt", "Returned Cheques in Hand", sFormula);
            }
        }
        #endregion


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
            rdoChequeToBeDeposited.Checked = false;
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtCustomer.Text = "<<ALL Customer>>";
            txtBank.Text = "<<ALL Bank>>";
            txtSalesRep.Text = "<<ALL Sales Rep>>";

            txtCustomer.Tag = null;
            txtBank.Tag = null;

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Cheque Management Reports";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
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


        #region Print Selectection
        private void PrintAll()
        {
            if (rdoChequeToBeDeposited.Checked)
                print("\\reports\\rptChequeToBeDeposited_All.rpt", "", "All Cheques To Be Deposited");
        }

        private void PrintCustomerBank()
        {
            string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "' and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
            string title = "Customer: " + txtCustomer.Text + "       Bank Name: " + txtBank.Text;
            if (rdoChequeToBeDeposited.Checked)//|| rdoRegisteredCheques.Checked)
                print("\\reports\\rptChequeToBeDeposited_CustomerBank.rpt", selectformula, title);
        }
        private void PrintBankBranch()
        {

        }
        private void PrintBank()
        {
            string selectformula = " and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
            string title = "Bank Name: " + txtBank.Text;
            if (rdoChequeToBeDeposited.Checked)//|| rdoRegisteredCheques.Checked)
                print("\\reports\\rptChequeToBeDeposited_Bank.rpt", selectformula, title);
        }
        private void PrintCustomer()
        {
            string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "'";
            string title = "Customer: " + txtCustomer.Text;
            if (rdoChequeToBeDeposited.Checked)// || rdoRegisteredCheques.Checked)
                print("\\reports\\rptChequeToBeDeposited_Customer.rpt", selectformula, title);
        }
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_BankID();
            }
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtBank_DoubleClick(object sender, EventArgs e)
        {
            Search_BankID();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCustomer.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCustomer.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void Search_BankID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_BankCompany();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtBank.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtBank.Tag = frmSearchMaster.s_SearchID;
            }
        }

        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events CheckedChanged
        private void rdoRealizedCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoReturnCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeToBeDeposited_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeInHand_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoChequeToBeDeposited.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBank, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBank, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFrom, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTo, true);
            }
            else if (rdoChequesInHandAll.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBank, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBank, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
                clsCommon.SetEnableDisable_NormalLabel(lblFrom, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTo, false);
            }
            if (rdoRealizedCheques.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBank, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBank, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFrom, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTo, true);
            }
            if (rdoReturnCheques.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBank, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBank, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblFrom, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTo, true);
            }
            else if (rdoReturnedChequesInHand.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBank, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblBank, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFrom, false);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpTo, false);
                clsCommon.SetEnableDisable_NormalLabel(lblFrom, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTo, false);
            }
        }
        #endregion

        

     



   
    }
}