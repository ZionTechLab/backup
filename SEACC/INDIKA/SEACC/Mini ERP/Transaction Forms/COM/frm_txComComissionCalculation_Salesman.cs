using DataTire;
using Zion.ERP.Reports.DataSets;
//using Zion.ERP.Reports.DataSets.COM;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZION.ERP.Reports.DataSets.COM;

namespace Digiteq.Transaction_Forms.COM
{
    public partial class frm_txComComissionCalculation_Salesman : MettroForm
    {
        /*
         *Draft Note Print Not Developped yet         
         */

        #region Class Variables

        private bool IsUpdateMode = false;
        private DataTable dtComissionCalc;
        private DataTable dtChequeDateDed;
        private DataTable dtReturnChequeDed;
        private DataTable dtReturnedPreChequeDed;
        decimal DeductionPresentage = 0;
        private BindingSource SB_ComissionCalc;
        private BindingSource SB_ChequeDateDed;
        private BindingSource SB_ReturnChequeDed;
        private BindingSource SB_ReturnedPreChequeDed;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_CommissionNP glb_dts_CommissionNP = new dts_CommissionNP();

        long ComCalcIndex = -1;
        #endregion

        #region Form Load

        #region Init Form
        public frm_txComComissionCalculation_Salesman()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Com_ComissionCalculation);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }
        #endregion

        private void frm_txComComissionCalculation_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            #region Init Data Tables

            #region Comission Calculation Table
            dtComissionCalc = new DataTable();
            //Columns
            dtComissionCalc.Columns.Add("LineNo", typeof(int));
            dtComissionCalc.Columns.Add("Description", typeof(string));
            dtComissionCalc.Columns.Add("ComAmount", typeof(string));
            dtComissionCalc.Columns.Add("ComAmount_noVAT", typeof(string));
            //Rows
            dtComissionCalc.Rows.Add(0, "Net Sales", "0.00", "0.00");
            dtComissionCalc.Rows.Add(1, "Item Category Wise Commission", "0.00", "0.00");
            dtComissionCalc.Rows.Add(2, "Credit Note Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(3, "Cheque Date Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(4, "Return CHQ Deduction - This Period", "0.00", "0.00");
            dtComissionCalc.Rows.Add(5, "Return CHQ Deduction - Previous", "0.00", "0.00");
            dtComissionCalc.Rows.Add(6, "Security Desposit Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(7, "Bill Advance Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(8, "Loan Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(9, "Advance Deduction", "0.00", "0.00");
            dtComissionCalc.Rows.Add(10, "Net Commission", "0.00", "0.00");
            //Data Source Binding
            SB_ComissionCalc = new BindingSource();
            dgvCalcComission.AutoGenerateColumns = false;
            SB_ComissionCalc.DataSource = dtComissionCalc;
            dgvCalcComission.DataSource = SB_ComissionCalc;
            #endregion

            #region Cheq Date Deduction Table
            dtChequeDateDed = new DataTable();
            //Columns
            dtChequeDateDed.Columns.Add("LineNo", typeof(int));
            dtChequeDateDed.Columns.Add("IsSelect", typeof(string));
            dtChequeDateDed.Columns.Add("DateSlab", typeof(string));
            dtChequeDateDed.Columns.Add("CheqRegID", typeof(string));
            dtChequeDateDed.Columns.Add("ChequeNo", typeof(string));
            dtChequeDateDed.Columns.Add("ChequeDate", typeof(string));
            dtChequeDateDed.Columns.Add("InvoiceDate", typeof(string));
            dtChequeDateDed.Columns.Add("DeleveryDate", typeof(string));
            dtChequeDateDed.Columns.Add("Amount", typeof(string));
            dtChequeDateDed.Columns.Add("ChqDedRate", typeof(string));
            dtChequeDateDed.Columns.Add("DedAmountChq", typeof(string));
            dtChequeDateDed.Columns.Add("DedAmtFull", typeof(string));
            dtChequeDateDed.Columns.Add("Transaction", typeof(string));
            dtChequeDateDed.Columns.Add("Remark", typeof(string));
            dtChequeDateDed.Columns.Add("CustomerName", typeof(string)); 
            dtChequeDateDed.Columns.Add("AllocatedAmount", typeof(string));
            //Data Source Binding
            SB_ChequeDateDed = new BindingSource();
            dgvCheqDateDed.AutoGenerateColumns = false;
            SB_ChequeDateDed.DataSource = dtChequeDateDed;
            dgvCheqDateDed.DataSource = SB_ChequeDateDed;
            #endregion

            #region Return Cheque Deduction This Period
            dtReturnChequeDed = new DataTable();
            //Columns
            dtReturnChequeDed.Columns.Add("LineNo", typeof(int));
            dtReturnChequeDed.Columns.Add("IsSelectRChq", typeof(string));
            dtReturnChequeDed.Columns.Add("CheqRegID", typeof(string));
            dtReturnChequeDed.Columns.Add("ChequeNo", typeof(string));
            dtReturnChequeDed.Columns.Add("ChequeDate", typeof(string));
            dtReturnChequeDed.Columns.Add("ChequeAmount", typeof(string));
            dtReturnChequeDed.Columns.Add("DeductionRate", typeof(string));
            dtReturnChequeDed.Columns.Add("DeductionAmount", typeof(string));
            dtReturnChequeDed.Columns.Add("TransactionID", typeof(string));
            dtReturnChequeDed.Columns.Add("Remark", typeof(string));
            //Data Source Binding
            SB_ReturnChequeDed = new BindingSource();
            dgvReturnCheqDeduction.AutoGenerateColumns = false;
            SB_ReturnChequeDed.DataSource = dtReturnChequeDed;
            dgvReturnCheqDeduction.DataSource = SB_ReturnChequeDed;
            #endregion

            #region Return Cheque Deduction Previous Period
            dtReturnedPreChequeDed = new DataTable();
            //Columns
            dtReturnedPreChequeDed.Columns.Add("LineNo", typeof(int));

            DataColumn dcIsSelectRchqP = new DataColumn();
            dcIsSelectRchqP.ColumnName = "IsSelectRchqP";
            dcIsSelectRchqP.DataType = typeof(string);
            dcIsSelectRchqP.DefaultValue = "\uE0A2";
            dtReturnedPreChequeDed.Columns.Add(dcIsSelectRchqP);

            dtReturnedPreChequeDed.Columns.Add("CheqRegID", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("ChequeNo", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("ChequeDate", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("ChequeAmount", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("DeductionRate", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("DeductionAmount", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("RTransactionID", typeof(string));
            dtReturnedPreChequeDed.Columns.Add("Remark", typeof(string));
            //Data Source Binding
            SB_ReturnedPreChequeDed = new BindingSource();
            dgvPreReturnCheques.AutoGenerateColumns = false;
            SB_ReturnedPreChequeDed.DataSource = dtReturnedPreChequeDed;
            dgvPreReturnCheques.DataSource = SB_ReturnedPreChequeDed;
            #endregion 

            #endregion

            ExpanderFormat();
            ClearFields();
        }
        #endregion

        #region Action Buttons
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    #region Init Varialbles 

                    #region Role of Employee
                    int iRoleOfEmp = -1;
                    if (txtSalesExecutiveID.Tag != null)
                        iRoleOfEmp = (int)SalesCommission_EmpRole.SalesRep;
                    else if (txtAreaManager.Tag != null)
                        iRoleOfEmp = (int)SalesCommission_EmpRole.AreaManager;
                    else if (txtSalesManager.Tag != null)
                        iRoleOfEmp = (int)SalesCommission_EmpRole.SalesManager;
                    else if (txtCollector.Tag != null)
                        iRoleOfEmp = (int)SalesCommission_EmpRole.Collector;
                    #endregion

                    int iLineNo = 0;
                    string sDescription = "";
                    string sComAmount_Gross_withVAT = "0.00";
                    string sComAmount_Gross_noVAT = "0.00";
                    string sComAmount_CRN_Ded_withVAT = "0.00";
                    string sComAmount_CRN_Ded_noVAT = "0.00";
                    string sComAmount_ChqData_Ded_withVAT = "0.00";
                    string sComAmount_ChqData_Ded_noVAT = "0.00";
                    string sComAmount_RchqData_DedThisp_withVAT = "0.00";
                    string sComAmount_RchqData_DedThisp_noVAT = "0.00";
                    string sComAmount_RchqData_DedPrvp_withVAT = "0.00";
                    string sComAmount_RchqData_DedPrvp_noVAT = "0.00";
                    string sComAmount_Security_Ded_withVAT = "0.00";
                    string sComAmount_Security_Ded_noVAT = "0.00";
                    string sComAmount_BillAdv_Ded_withVAT = "0.00";
                    string sComAmount_BillAdv_Ded_noVAT = "0.00";
                    string sComAmount_Loan_Ded_withVAT = "0.00";
                    string sComAmount_Loan_Ded_noVAT = "0.00";
                    string sComAmount_Adv_Ded_withVAT = "0.00";
                    string sComAmount_Adv_Ded_noVAT = "0.00";
                    string sComAmount_Net_withVAT = "0.00";
                    string sComAmount_Net_noVAT = "0.00";

                    foreach (DataRow calcDr in dtComissionCalc.Rows)
                    {
                        iLineNo = clsValidate.ValidateRowValue(calcDr, "LineNo", -1);

                        switch (iLineNo)
                        {
                            case 1:
                                sComAmount_Gross_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_Gross_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 2:
                                sComAmount_CRN_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_CRN_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 3:
                                sComAmount_ChqData_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_ChqData_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 4:
                                sComAmount_RchqData_DedThisp_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_RchqData_DedThisp_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 5:
                                sComAmount_RchqData_DedPrvp_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_RchqData_DedPrvp_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 6:
                                sComAmount_Security_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_Security_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 7:
                                sComAmount_BillAdv_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_BillAdv_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 8:
                                sComAmount_Loan_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_Loan_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 9:
                                sComAmount_Adv_Ded_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_Adv_Ded_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            case 10:
                                sComAmount_Net_withVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount", "0.00");
                                sComAmount_Net_noVAT = clsValidate.ValidateRowValue(calcDr, "ComAmount_noVAT", "0.00");
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion

                    #region Update

                    if (IsUpdateMode)
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, true))
                        {
                            tbl_comCommissionCalculation oOldCommission =
                                tbl_comCommissionCalculation.Select(long.Parse(txtCommissionCalc.Tag.ToString()));
                            if (oOldCommission != null)
                            {
                                tbl_comCommissionCalculation_Cheque.DeleteAllByComCalcIndex(oOldCommission.ComCalcIndex);

                                tbl_comCommissionCalculation oCommission = new tbl_comCommissionCalculation(
                                    long.Parse(txtCommissionCalc.Tag.ToString()),
                                    long.Parse(txtComPeriod.Tag.ToString()),
                                    iRoleOfEmp,
                                    txtSalesExecutiveID.Tag != null ? txtSalesExecutiveID.Tag.ToString() : "default",
                                    txtAreaManager.Tag != null ? txtAreaManager.Tag.ToString() : "default",
                                    txtSalesManager.Tag != null ? txtSalesManager.Tag.ToString() : "default",
                                    txtCollector.Tag != null ? txtCollector.Tag.ToString() : "default",
                                    txtRemark.Text,
                                    int.Parse(txtFromDay.Text),
                                    int.Parse(txtToDay.Text),
                                    clsValidate.Validate_DecimalNumber(sComAmount_Gross_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_CRN_Ded_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_ChqData_Ded_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedThisp_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedPrvp_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_Security_Ded_withVAT),
                                    clsValidate.Validate_DecimalNumber(sComAmount_BillAdv_Ded_withVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Loan_Ded_withVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Adv_Ded_withVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Net_withVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Gross_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_CRN_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_ChqData_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedThisp_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedPrvp_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Security_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_BillAdv_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Loan_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Adv_Ded_noVAT),
                                     clsValidate.Validate_DecimalNumber(sComAmount_Net_noVAT),
                                    oOldCommission.IsChecked, oOldCommission.IsApproved, oOldCommission.IsDeleted,
                                    oOldCommission.CreateUser_ID, clsSecurity.UserIDLoged,
                                    oOldCommission.CheckedUser_ID,
                                    oOldCommission.ApprovedUser_ID, oOldCommission.DeletedUser_ID,
                                    oOldCommission.PrintedUser_ID,
                                    oOldCommission.CreateTerminal_ID, clsSecurity.TerminalID,
                                    oOldCommission.DeletedTerminal_ID,
                                    oOldCommission.PrintedTerminal_ID,
                                    oOldCommission.DateCreate, clsSecurity.getServerDateTime(),
                                    oOldCommission.DateChecked,
                                    oOldCommission.DateApproved, oOldCommission.DateDeleted, oOldCommission.DatePrinted,
                                    oOldCommission.PrintCount);
                                oCommission.Update();

                                Insert_Commission_Detail();

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    #endregion

                    #region Insert

                    else
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                        {
                            tbl_comCommissionCalculation oCommission = new tbl_comCommissionCalculation(
                                long.Parse(txtCommissionCalc.Tag.ToString()),
                                long.Parse(txtComPeriod.Tag.ToString()),
                                iRoleOfEmp,
                                txtSalesExecutiveID.Tag != null ? txtSalesExecutiveID.Tag.ToString() : "default",
                                txtAreaManager.Tag != null ? txtAreaManager.Tag.ToString() : "default",
                                txtSalesManager.Tag != null ? txtSalesManager.Tag.ToString() : "default",
                                txtCollector.Tag != null ? txtCollector.Tag.ToString() : "default",
                                txtRemark.Text,
                                int.Parse(txtFromDay.Text),
                                int.Parse(txtToDay.Text),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Gross_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_CRN_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_ChqData_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedThisp_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedPrvp_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Security_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_BillAdv_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Loan_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Adv_Ded_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Net_withVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Gross_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_CRN_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_ChqData_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedThisp_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_RchqData_DedPrvp_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Security_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_BillAdv_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Loan_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Adv_Ded_noVAT),
                                 clsValidate.Validate_DecimalNumber(sComAmount_Net_noVAT),
                                false, false, false, clsSecurity.UserIDLoged, "default", "default", "default",
                                "default",
                                "default",
                                clsSecurity.TerminalID, "default", "default", "default",
                                clsSecurity.getServerDateTime(), clsValidate.defaultDateTime,
                                clsValidate.defaultDateTime,
                                clsValidate.defaultDateTime, clsValidate.defaultDateTime,
                                clsValidate.defaultDateTime,
                                0);
                            oCommission.Insert();

                            Insert_Commission_Detail();

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone),
                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    #endregion
                }
                catch (Exception exception)
                {
                    SEACCException.Show(exception);
                }
                finally
                {
                    Fill_SavedCommission_Details(long.Parse(txtCommissionCalc.Tag.ToString()));
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnCheqDateDedLoad_Click(object sender, EventArgs e)
        {
            Refresh_Grids();
        }
        #endregion

        #region Clear Fields
        public void ClearFields()
        {
          

            IsUpdateMode = false;

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtComPeriod, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesExecutiveID, true);

            txtCommissionCalc.Tag = null;
            txtComPeriod.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtSalesManager.Tag = null;
            txtAreaManager.Tag = null;
            txtCollector.Tag = null;

            txtCommissionCalc.Text = "";
            txtComPeriod.Text = "";
            txtSalesExecutiveID.Text = "";
            txtSalesManager.Text = "";
            txtAreaManager.Text = "";
            txtCollector.Text = "";
            txtRemark.Text = "";

            txtCommissionCalc.Visible = false;

            txtSalesExecutiveID.Enabled = true;
            txtSalesManager.Enabled = true;
            txtAreaManager.Enabled = true;
            txtCollector.Enabled = true;

            expanderChequeDateDed.DisplayAmount = "0.00";
            expanderReturenChq.DisplayAmount = "0.00";
            expanderPreviousReturnChq.DisplayAmount = "0.00";

            dtChequeDateDed.Rows.Clear();
            dtReturnChequeDed.Rows.Clear();
            dtReturnedPreChequeDed.Rows.Clear();
            dtComissionCalc.Select().ToList<DataRow>().ForEach(r => { r["ComAmount"] = "0.00"; r["ComAmount_noVAT"] = "0.00"; });

            ComCalcIndex = -1;
        }
        #endregion

        #region Refresh Grids
        private void Refresh_Grids()
        {
            try
            {
                if (txtComPeriod.Tag != null)
                {
             
                    decimal.TryParse(textBox1.Text, out DeductionPresentage);

                    #region Role of Employee
                    int iRoleOfEmp = -1;
                    tbl_comCommissionPeriodMaster oPeriodMaster = tbl_comCommissionPeriodMaster.Select(long.Parse(txtComPeriod.Tag.ToString()));
                    if (txtSalesExecutiveID.Tag != null && txtSalesExecutiveID.Tag.ToString() != "default")
                    {
                        iRoleOfEmp = (int)SalesCommission_EmpRole.SalesRep;
                        Fill_ComissionGrids(iRoleOfEmp, txtSalesExecutiveID.Tag.ToString(), oPeriodMaster);
                    }
                    else if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString() != "default")
                    {
                        iRoleOfEmp = (int)SalesCommission_EmpRole.AreaManager;
                        Fill_ComissionGrids(iRoleOfEmp, txtAreaManager.Tag.ToString(), oPeriodMaster);
                    }
                    else if (txtSalesManager.Tag != null && txtSalesManager.Tag.ToString() != "default")
                    {
                        iRoleOfEmp = (int)SalesCommission_EmpRole.SalesManager;
                        Fill_ComissionGrids(iRoleOfEmp, txtSalesManager.Tag.ToString(), oPeriodMaster);
                    }
                    else if (txtCollector.Tag != null && txtCollector.Tag.ToString() != "default")
                    {
                        iRoleOfEmp = (int)SalesCommission_EmpRole.Collector;
                        Fill_ComissionGrids(iRoleOfEmp, txtCollector.Tag.ToString(), oPeriodMaster);
                    }
                    #endregion

                    Calculate_Totals();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            try
            {
                if (CheckValidity_EmptyField())
                    if (CheckValidity_PeriodClosed())
                        bStatus = true;
            }
            catch (Exception e)
            {
                SEACCException.Show(e);
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;

            if (!IsUpdateMode)
            {
                txtCommissionCalc.Tag = (tbl_comCommissionCalculation.SelectAll().Max(r => r.ComCalcIndex) + 1);
                txtCommissionCalc.Text = txtCommissionCalc.Tag.ToString();
            }

            if (clsValidate.ValidateTextBox_EmptyValue(txtCommissionCalc, "Comission Calculation ID"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtComPeriod, "Comission Period Name"))
                {
                    if ((txtSalesExecutiveID.Tag != null) ||
                        (txtAreaManager.Tag != null) ||
                        (txtSalesManager.Tag != null) ||
                        (txtCollector.Tag != null))
                    {
                        bStatus = true;
                    }
                    else
                    {
                        MessageBox.Show("Please select a Sales Rep or an Area Manager or a Sales Manager or a Collector...!!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        bStatus = false;
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_PeriodClosed()
        {
            bool bStatus = true;

            tbl_comCommissionPeriodMaster oPeriod = tbl_comCommissionPeriodMaster.Select(long.Parse(txtComPeriod.Tag.ToString()));
            if (oPeriod != null && oPeriod.IsPeriodClose)
            {
                MessageBox.Show("This Commission Period Closed...!!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        #region Fill Details

        //New Details
        private void Fill_ComissionGrids(int iRoleOfEmp, string sEmp_ID, tbl_comCommissionPeriodMaster oPeriodMaster)
        {
            try
            {
                #region Method Parameters
                Cursor = Cursors.WaitCursor;

                dtChequeDateDed.Rows.Clear();
                dtReturnChequeDed.Rows.Clear();
                dtReturnedPreChequeDed.Rows.Clear();
                dtComissionCalc.Select().ToList<DataRow>().ForEach(r => { r["ComAmount"] = "0.00"; });
                dtComissionCalc.Select().ToList<DataRow>().ForEach(r => { r["ComAmount_noVAT"] = "0.00"; });

                int iLineNo_DateDed = 0;
                int iLineNo_ReturnChq = 0;
                decimal dGrossComission_WithVAT = 0m;
                decimal dGrossComission_NoVAT = 0m;
                decimal dCreditNoteDeduction = 0m;
                decimal dReturnChqDedRate = 0m;

                int iDaysFrom = int.Parse(txtFromDay.Text);
                int iDaysTo = int.Parse(txtToDay.Text);
                #endregion

                if (oPeriodMaster != null)
                {

                    #region Method Parameters
                    //Invoice List Initialize
                    List<tbl_sasInvoice> lstInvoices = new List<tbl_sasInvoice>();
                    //SRN List Initialize
                    List<tbl_sasSalesReturnedNote> lstSRNs = new List<tbl_sasSalesReturnedNote>();
                    //Previous Period Return Cheques Table
                    DataTable dtPrvChqs = new DataTable();
                    #endregion

                    #region Sales Rep Data Fill
                    if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                    {
                        lstInvoices = tbl_sasInvoice.SelectAllByEmployee_ID(sEmp_ID).Where(r =>
                            !r.IsDeleted && !r.IsDebitNote
                                         && r.InvoiceDate.Date >= oPeriodMaster.DateFrom.Date
                                         && r.InvoiceDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        lstSRNs = tbl_sasSalesReturnedNote.SelectAllBySalesRep_ID(sEmp_ID).Where(r =>
                            r.SalesReturnedNoteDate.Date >= oPeriodMaster.DateFrom.Date &&
                            r.SalesReturnedNoteDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        dtPrvChqs = DBHandling.ExecQuery("sp_Commission_PreviousPeriod_ReturnedCheques '" + sEmp_ID + "' , '" + oPeriodMaster.DateFrom.ToString(clsFormatter.Format_Date) + "' ,  '" + txtComPeriod.Tag.ToString() + "'").Tables[0];
                    }
                    #endregion

                    #region Area Manager Data Fill
                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                    {
                        lstInvoices = tbl_sasInvoice.SelectAllByAreaManager_ID(sEmp_ID).Where(r =>
                                                                                        !r.IsDeleted && !r.IsDebitNote
                                                                                    && r.InvoiceDate.Date >= oPeriodMaster.DateFrom.Date
                                                                                    && r.InvoiceDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        lstSRNs = tbl_sasSalesReturnedNote.SelectAllByAreaManager_ID(sEmp_ID).Where(r =>
                            r.SalesReturnedNoteDate.Date >= oPeriodMaster.DateFrom.Date &&
                            r.SalesReturnedNoteDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        DataTable dtSRep = DBHandling.ExecQuery("sp_Commission_PreviousPeriod_ReturnedCheques_AreaManager '" + sEmp_ID + "' , '" + oPeriodMaster.DateFrom.ToString(clsFormatter.Format_Date) + "' ,  '" + txtComPeriod.Tag.ToString() + "'").Tables[0];
                        if (dtSRep.Rows.Count > 0)
                            dtPrvChqs.Merge(dtSRep);
                    }
                    #endregion

                    #region Sales Manager Data Fill
                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                    {
                        lstInvoices = tbl_sasInvoice.SelectAllBySalesManager_ID(sEmp_ID).Where(r =>
                                    !r.IsDeleted && !r.IsDebitNote
                                                 && r.InvoiceDate.Date >= oPeriodMaster.DateFrom.Date
                                                 && r.InvoiceDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        lstSRNs = tbl_sasSalesReturnedNote.SelectAllByAreaManager_ID(sEmp_ID).Where(r =>
                            r.SalesReturnedNoteDate.Date >= oPeriodMaster.DateFrom.Date &&
                            r.SalesReturnedNoteDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        DataTable dtSRep = DBHandling.ExecQuery("sp_Commission_PreviousPeriod_ReturnedCheques_SalesManager '" + sEmp_ID + "' , '" + oPeriodMaster.DateFrom.ToString(clsFormatter.Format_Date) + "' ,  '" + txtComPeriod.Tag.ToString() + "'").Tables[0];
                        if (dtSRep.Rows.Count > 0)
                            dtPrvChqs.Merge(dtSRep);

                    }
                    #endregion

                    #region Collector Data Fill
                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                    {

                        lstInvoices = tbl_sasInvoice.SelectAllByCollector_ID(sEmp_ID).Where(r =>
                            !r.IsDeleted && !r.IsDebitNote
                                         && r.InvoiceDate.Date >= oPeriodMaster.DateFrom.Date
                                         && r.InvoiceDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        lstSRNs = tbl_sasSalesReturnedNote.SelectAllByCollector_ID(sEmp_ID).Where(r =>
                            r.SalesReturnedNoteDate.Date >= oPeriodMaster.DateFrom.Date &&
                            r.SalesReturnedNoteDate.Date <= oPeriodMaster.DateTo.Date).ToList();

                        dtPrvChqs = DBHandling.ExecQuery("sp_Commission_PreviousPeriod_ReturnedCheques_Collector '" + txtCollector.Tag.ToString().Trim() + "' , '" + oPeriodMaster.DateFrom.ToString(clsFormatter.Format_Date) + "' ,  '" + txtComPeriod.Tag.ToString() + "'").Tables[0];
                    }
                    #endregion


                    #region Commission Calculation from Invoices & Returned Cheques in the Period
                    //Invoices and Return Cheques for 
                    foreach (var oInvoice in lstInvoices)
                    {
                        var DO = tbl_sasDeliveryOrder.Select(oInvoice.DeliveryOrder_ID);

                        dGrossComission_WithVAT += Commission_Invoice_WithVAT(iRoleOfEmp, oInvoice.Invoice_ID);//ref dtComInvoices
                        dGrossComission_NoVAT += Commission_Invoice_NoVAT(iRoleOfEmp, oInvoice);

                        foreach (var oInvSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID)
                            .Where(r => r.ChequeRegister_ID != "default"))
                        {
                            tbl_bpsChequeRegister oCheq = tbl_bpsChequeRegister.Select(oInvSettle.ChequeRegister_ID);
                            if (oCheq.PaymentMethod_ID == (int)(PaymentMethod.Cheque)|| oCheq.PaymentMethod_ID == (int)(PaymentMethod.Cash))
                            {
                                #region Fill Cheque Date Deduction Grid

                                if (!Is_ReturnedCheque(oCheq.ChequeRegister_ID)) //if (!oCheq.IsReturned)
                                {
                                    double dDateSlab = (oCheq.DateCheque.Date - DO.CustomerDeliveryDate.Date).TotalDays;
                                    dDateSlab = dDateSlab < 0 ? -dDateSlab : dDateSlab;

                                    if (dDateSlab < iDaysFrom || dDateSlab > iDaysTo)
                                    {
                                        decimal AllocationRatio = oInvSettle.SattledAmount / oInvoice.GrandTotal;
                                     //   var exdr = dtChequeDateDed.Select("Transaction like '%" + oInvoice.Invoice_ID + "%'");
                                    //     if (exdr == null || exdr.Length < 1)
                                        {
                                            try
                                            {
                                                DataRow[] exChqs = dtChequeDateDed.Select("CheqRegID = '" + oCheq.ChequeRegister_ID + "' ");
                                              //  if (exChqs == null || exChqs.Length < 1)
                                                {
                                                    dtChequeDateDed.Rows.Add(++iLineNo_DateDed,
                                                        "\uE0A2",
                                                        clsFormatter.FormatDecimal(decimal.Parse(dDateSlab.ToString()), 0),
                                                        oCheq.ChequeRegister_ID,
                                                        oCheq.ChequeNumber,
                                                        oCheq.DateCheque.ToString(clsFormatter.Format_Date2),
                                                        oInvoice.InvoiceDate.ToString(clsFormatter.Format_Date2),
                                                        DO.CustomerDeliveryDate.ToString(clsFormatter.Format_Date2),
                                                        clsFormatter.FormatDecimal(oCheq.Amount, 2),
                                                        clsFormatter.FormatDecimal(0, 2),
                                                        clsFormatter.FormatDecimal(Commission_Invoice_WithVAT_New(iRoleOfEmp, oInvSettle.Invoice_ID, AllocationRatio), 2),
                                                     clsFormatter.FormatDecimal(Commission_Invoice_WithVAT_New(iRoleOfEmp, oInvSettle.Invoice_ID, 1), 2),
                                                        oInvoice.Invoice_ID,
                                                        "",
                                                        clsGenaralName.getName_Customer(oCheq.Customer_ID)
                                                        , clsFormatter.FormatDecimal(oInvSettle.SattledAmount, 2));
                                                }
                                                //else
                                                //{
                                                //    DataRow exChq = exChqs.FirstOrDefault();
                                                //    if (exChq != null)
                                                //    {
                                                //        decimal dDedAmountChq = clsValidate.ValidateRowValue(exChq, "DedAmountChq", 0m);
                                                //        decimal dAllocatedAmount = clsValidate.ValidateRowValue(exChq, "AllocatedAmount", 0m);

                                                //        dDedAmountChq += Commission_Invoice_WithVAT_New(iRoleOfEmp, oInvSettle.Invoice_ID, AllocationRatio);
                                                //        dAllocatedAmount += oInvSettle.SattledAmount;

                                                //        string sTx = clsValidate.ValidateRowValue(exChq, "Transaction", "");
                                                //        sTx = sTx + (sTx.Trim() == "" ? oInvSettle.Invoice_ID : ", " + oInvSettle.Invoice_ID);

                                                //        exChq["DedAmountChq"] = clsFormatter.FormatDecimal(dDedAmountChq, 2);
                                                //        exChq["AllocatedAmount"] = clsFormatter.FormatDecimal(dAllocatedAmount, 2);
                                                //        exChq["Transaction"] = sTx;
                                                //    }
                                                //}
                                            }
                                            catch (Exception ex)
                                            {
                                                SEACCException.Show(ex);
                                            }
                                        }
                                    }
                                }

                                #endregion

                                #region Fill Return Cheque Deduction Grid - This Period

                                else
                                {
                                    if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                                        dReturnChqDedRate = clsConfig.dReturnChq_DeductionRate_SalesRep;
                                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                                        dReturnChqDedRate = clsConfig.dReturnChq_DeductionRate_AreaMgr;
                                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                                        dReturnChqDedRate = clsConfig.dReturnChq_DeductionRate_SalesMgr;
                                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                                        dReturnChqDedRate = clsConfig.dReturnChq_DeductionRate_Collector;

                                    DataRow[] drReturnChqs = dtReturnChequeDed.Select("ChequeNo = '" + oCheq.ChequeNumber + "'");
                                    if (drReturnChqs == null && drReturnChqs.Count() < 1)
                                    {
                                        dtReturnChequeDed.Rows.Add(
                                            ++iLineNo_ReturnChq, "\uE0A2",
                                            oCheq.ChequeRegister_ID, oCheq.ChequeNumber,
                                            oCheq.DateCheque.ToString(clsFormatter.Format_Date2),
                                            clsFormatter.FormatDecimal(oCheq.Amount, 2),
                                            clsFormatter.FormatDecimal(dReturnChqDedRate / 100, 2),
                                            clsFormatter.FormatDecimal(oCheq.Amount * dReturnChqDedRate / 100, 2), oInvoice.Invoice_ID,
                                            "");
                                    }
                                }

                                #endregion
                            }
                        }
                    }
                    #endregion

                    #region Commission Calculation Deduction from Sales Returns in the Period
                    //Deduct Sales Returns
                    if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                    {
                        foreach (tbl_sasSalesReturnedNote oSRN in lstSRNs)
                        {
                            foreach (var oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                            {
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                                if (oItem != null)
                                {
                                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                    if (oItemCategory != null)
                                    {
                                        if (oSRN_Detail.DiscountAmount > 0)
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.DiscountedSalesRate_SR);
                                        }
                                        else
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.NormalSalesRate_SR);
                                        }
                                    }
                                }

                            }
                        }
                    }

                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                    {
                        foreach (tbl_sasSalesReturnedNote oSRN in lstSRNs)
                        {
                            foreach (var oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                            {
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                                if (oItem != null)
                                {
                                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                    if (oItemCategory != null)
                                    {
                                        if (oSRN_Detail.DiscountAmount > 0)
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.DiscountedSalesRate_AM);
                                        }
                                        else
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.NormalSalesRate_AM);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                    {
                        foreach (tbl_sasSalesReturnedNote oSRN in lstSRNs)
                        {
                            foreach (var oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                            {
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                                if (oItem != null)
                                {
                                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                    if (oItemCategory != null)
                                    {
                                        if (oSRN_Detail.DiscountAmount > 0)
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.DiscountedSalesRate_SM);
                                        }
                                        else
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.NormalSalesRate_SM);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                    {
                        foreach (tbl_sasSalesReturnedNote oSRN in lstSRNs)
                        {

                            foreach (var oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                            {
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                                if (oItem != null)
                                {
                                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                                    if (oItemCategory != null)
                                    {
                                        if (oSRN_Detail.DiscountAmount > 0)
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.DiscountedSalesRate_Col);
                                        }
                                        else
                                        {
                                            dGrossComission_WithVAT -= oSRN_Detail.TatalAmount * (oItemCategory.NormalSalesRate_Col);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Commission Calculation Deduction from Returned Cheques Pervious Period
                    //Return Cheques for Previos Periods                    
                    dtReturnedPreChequeDed.Merge(dtPrvChqs);
                    #endregion


                    #region Display Gross Comission
                    DataRow dr_GrossCom = dtComissionCalc.Select("LineNo = " + 1 + "").FirstOrDefault();
                    if (dr_GrossCom != null)
                    {
                        dr_GrossCom["ComAmount"] = clsFormatter.FormatDecimal(dGrossComission_WithVAT, 2);
                        dr_GrossCom["ComAmount_noVAT"] = clsFormatter.FormatDecimal(dGrossComission_NoVAT, 2);
                    }

                    this.dgvCalcComission.Rows[0].Cells["ComAmount"].ReadOnly = true;
                    this.dgvCalcComission.Rows[0].Cells["ComAmount_noVAT"].ReadOnly = true;
                    #endregion


                    #region Credit Note Deduction

                    //Credit Note Deduction
                    dCreditNoteDeduction = 0;
                    //To Do

                    //Display Credit Note Deduction
                    DataRow dr_CRNDed = dtComissionCalc.Select("LineNo = " + 2 + "").FirstOrDefault();
                    if (dr_CRNDed != null)
                        dr_CRNDed["ComAmount"] = clsFormatter.FormatDecimal(dCreditNoteDeduction, 2);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        //Already Saved Details
        private void Fill_SavedCommission_Details(long lComCalcIndex)
        {
            tbl_comCommissionCalculation oCalculation = tbl_comCommissionCalculation.Select(lComCalcIndex);
            if (oCalculation != null && !oCalculation.IsDeleted)
            {
                IsUpdateMode = true;

                tbl_comCommissionPeriodMaster oPeriodMaster = tbl_comCommissionPeriodMaster.Select(oCalculation.PeriodIndex);
                if (oPeriodMaster == null)
                    return;

                txtCommissionCalc.Tag = oCalculation.ComCalcIndex;
                txtComPeriod.Tag = oCalculation.PeriodIndex;
                txtSalesExecutiveID.Tag = oCalculation.SalesRep_ID;
                txtAreaManager.Tag = oCalculation.AreaManger_ID;
                txtSalesManager.Tag = oCalculation.SalesManager_ID;
                txtCollector.Tag = oCalculation.Collector_ID;

                txtCommissionCalc.Text = oCalculation.ComCalcIndex.ToString();
                txtComPeriod.Text = oPeriodMaster.PeriodName;
                txtSalesExecutiveID.Text = oCalculation.SalesRep_ID != "default" ? clsGenaralName.getName_SalesRep(oCalculation.SalesRep_ID) : "-";
                txtAreaManager.Text = oCalculation.AreaManger_ID != "default" ? clsGenaralName.getName_AreaManager(oCalculation.AreaManger_ID) : "-";
                txtSalesManager.Text = oCalculation.SalesManager_ID != "default" ? clsGenaralName.getName_SalesManager(oCalculation.SalesManager_ID) : "-";
                txtCollector.Text = oCalculation.Collector_ID != "default" ? clsGenaralName.getName_SalesRep(oCalculation.Collector_ID) : "-";
                txtRemark.Text = oCalculation.Remarks;
                txtFromDay.Text = oCalculation.ChequePeriod_fromDays.ToString();
                txtToDay.Text = oCalculation.ChequePeriod_toDays.ToString();

                dtChequeDateDed.Rows.Clear();
                dtReturnChequeDed.Rows.Clear();
                dtReturnedPreChequeDed.Rows.Clear();
                dtComissionCalc.Select().ToList<DataRow>().ForEach(r => { r["ComAmount"] = "0.00"; r["ComAmount_noVAT"] = "0.00"; });

                int iLineNo_dtChequeDateDed = 0;
                int iLineNo_dtReturnChequeDed = 0;
                int iLineNo_dtReturnedPreChequeDed = 0;

                foreach (var vCheque in tbl_comCommissionCalculation_Cheque.SelectAllByComCalcIndex(oCalculation.ComCalcIndex))
                {
                    tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(vCheque.ChequeRegister_ID);
                    if (oChequeRegister != null)
                    {
                        if (vCheque.IsChequeDateDed)
                        {
                            dtChequeDateDed.Rows.Add(
                                ++iLineNo_dtChequeDateDed,
                                (vCheque.IsSelect_forDed ? "\uE0A2" : "\uE003"),
                                vCheque.DateSlab.ToString(),
                                vCheque.ChequeRegister_ID, oChequeRegister.ChequeNumber,
                                oChequeRegister.DateCheque.ToString(clsFormatter.Format_Date2),
                                clsFormatter.FormatDecimal(oChequeRegister.Amount, 2),
                                clsFormatter.FormatDecimal(vCheque.Ded_Rate, 4),
                                clsFormatter.FormatDecimal(vCheque.Ded_Amount, 2), vCheque.Invoice_ID, vCheque.Remarks,clsGenaralName.getName_Customer(oChequeRegister.Customer_ID),
                                clsFormatter.FormatDecimal(vCheque.allocatedAmount, 2));
                        }
                        else if (vCheque.IsRchequeDed_thisPeriod)
                        {
                            dtReturnChequeDed.Rows.Add(
                                ++iLineNo_dtReturnChequeDed,
                                (vCheque.IsSelect_forDed ? "\uE0A2" : "\uE003"),
                                vCheque.ChequeRegister_ID, oChequeRegister.ChequeNumber,
                                oChequeRegister.DateCheque.ToString(clsFormatter.Format_Date2),
                                clsFormatter.FormatDecimal(oChequeRegister.Amount, 2),
                                clsFormatter.FormatDecimal(vCheque.Ded_Rate, 4),
                                clsFormatter.FormatDecimal(vCheque.Ded_Amount, 2), vCheque.Invoice_ID, vCheque.Remarks);
                        }
                        else if (vCheque.IsRchequeDed_prvPeriod)
                        {
                            dtReturnedPreChequeDed.Rows.Add(
                                ++iLineNo_dtReturnedPreChequeDed,
                                (vCheque.IsSelect_forDed ? "\uE0A2" : "\uE003"),
                                vCheque.ChequeRegister_ID, oChequeRegister.ChequeNumber,
                                oChequeRegister.DateCheque.ToString(clsFormatter.Format_Date2),
                              clsFormatter.  FormatDecimal(oChequeRegister.Amount, 2),
                                clsFormatter.FormatDecimal(vCheque.Ded_Rate, 4),
                                clsFormatter.FormatDecimal(vCheque.Ded_Amount, 2), vCheque.Invoice_ID, vCheque.Remarks
                            );
                        }
                    }
                }
                DataRow dr_Net= dtComissionCalc.Select("LineNo = " + 0 + "").FirstOrDefault();
                if (dr_Net != null)
                {
                    dr_Net["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Gross_commission_withVAT, 2);
                    dr_Net["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Gross_commission_withoutVAT, 2);
                }
                DataRow dr_GrossCom = dtComissionCalc.Select("LineNo = " + 1 + "").FirstOrDefault();
                if (dr_GrossCom != null)
                {
                    dr_GrossCom["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Gross_commission_withVAT, 2);
                    dr_GrossCom["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Gross_commission_withoutVAT, 2);
                }

                DataRow dr_CRN_Ded = dtComissionCalc.Select("LineNo = " + 2 + "").FirstOrDefault();
                if (dr_CRN_Ded != null)
                {
                    dr_CRN_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_CRN_withVAT, 2);
                    dr_CRN_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_CRN_withoutVAT, 2);
                }

                DataRow dr_ChqDate_Ded = dtComissionCalc.Select("LineNo = " + 3 + "").FirstOrDefault();
                if (dr_ChqDate_Ded != null)
                {
                    dr_ChqDate_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_ChqDate_withVAT, 2);
                    dr_ChqDate_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_ChqDate_withoutVAT, 2);
                }

                DataRow dr_RChq_Ded = dtComissionCalc.Select("LineNo = " + 4 + "").FirstOrDefault();
                if (dr_RChq_Ded != null)
                {
                    dr_RChq_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_RchqThisPeriod_withVAT, 2);
                    dr_RChq_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_RchqThisPeriod_withoutVAT, 2);
                }

                DataRow dr_RChqPrv_Ded = dtComissionCalc.Select("LineNo = " + 5 + "").FirstOrDefault();
                if (dr_RChqPrv_Ded != null)
                {
                    dr_RChqPrv_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_RchqPrvPeriod_withVAT, 2);
                    dr_RChqPrv_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_RchqPrvPeriod_withoutVAT, 2);
                }

                DataRow dr_Security_Ded = dtComissionCalc.Select("LineNo = " + 6 + "").FirstOrDefault();
                if (dr_Security_Ded != null)
                {
                    dr_Security_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_SecurityDept_withVAT, 2);
                    dr_Security_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_SecurityDept_withoutVAT, 2);
                }

                DataRow dr_BillAdv_Ded = dtComissionCalc.Select("LineNo = " + 7 + "").FirstOrDefault();
                if (dr_BillAdv_Ded != null)
                {
                    dr_BillAdv_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_BillAdv_withVAT, 2);
                    dr_BillAdv_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_BillAdv_withoutVAT, 2);
                }

                DataRow dr_Loan_Ded = dtComissionCalc.Select("LineNo = " + 8 + "").FirstOrDefault();
                if (dr_Loan_Ded != null)
                {
                    dr_Loan_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_Loan_withVAT, 2);
                    dr_Loan_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_Loan_withoutVAT, 2);
                }

                DataRow dr_Adv_Ded = dtComissionCalc.Select("LineNo = " + 9 + "").FirstOrDefault();
                if (dr_Adv_Ded != null)
                {
                    dr_Adv_Ded["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Ded_Advance_withVAT, 2);
                    dr_Adv_Ded["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Ded_Advance_withoutVAT, 2);
                }

                DataRow dr_NetCom = dtComissionCalc.Select("LineNo = " + 10 + "").FirstOrDefault();
                if (dr_NetCom != null)
                {
                    dr_NetCom["ComAmount"] = clsFormatter.FormatDecimal(oCalculation.Net_commission_withVAT, 2);
                    dr_NetCom["ComAmount_noVAT"] = clsFormatter.FormatDecimal(oCalculation.Net_commission_withoutVAT, 2);
                }

                expanderChequeDateDed.DisplayAmount = clsFormatter.FormatDecimal(oCalculation.Ded_ChqDate_withVAT, 2);
                expanderReturenChq.DisplayAmount = clsFormatter.FormatDecimal(oCalculation.Ded_RchqThisPeriod_withVAT, 2);
                expanderPreviousReturnChq.DisplayAmount = clsFormatter.FormatDecimal(oCalculation.Ded_RchqPrvPeriod_withVAT, 2);

                this.dgvCalcComission.Rows[2].Cells["ComAmount"].ReadOnly = true;
                this.dgvCalcComission.Rows[3].Cells["ComAmount"].ReadOnly = true;
                this.dgvCalcComission.Rows[4].Cells["ComAmount"].ReadOnly = true;
                this.dgvCalcComission.Rows[2].Cells["ComAmount_noVAT"].ReadOnly = true;
                this.dgvCalcComission.Rows[3].Cells["ComAmount_noVAT"].ReadOnly = true;
                this.dgvCalcComission.Rows[4].Cells["ComAmount_noVAT"].ReadOnly = true;
                this.dgvCalcComission.Rows[9].DefaultCellStyle.Font = new Font("segoe ui", 9, FontStyle.Bold);
                this.dgvCalcComission.Rows[9].Cells["ComAmount"].ReadOnly = true;
                this.dgvCalcComission.Rows[9].Cells["ComAmount_noVAT"].ReadOnly = true;
            }
        }

        #endregion

        #region Grid Events 

        #region Cheque Date Deduction Grid
        private void dgvCheqDateDed_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCheqDateDed.RowCount > 0 && e.ColumnIndex == IsSelect.Index)
            {
                int ilineNo = int.Parse(dgvCheqDateDed.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr = dtChequeDateDed.Select("LineNo = " + ilineNo + "").FirstOrDefault();
                if (dr != null)
                {
                    if (dr["IsSelect"].ToString() == "\uE0A2")
                    {
                        dr["IsSelect"] = "\uE003";
                    }
                    else
                    {
                        dr["IsSelect"] = "\uE0A2";
                    }
                }

            }
            dgvCheqDateDed.Refresh();
            Calculate_Totals();
        }

        private void dgvCheqDateDed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate_Totals();
        }

        private void chkChqDateDed_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChqDateDed_SelectAll.Checked)
            {
                dtChequeDateDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelect"] = "\uE0A2"; });
            }
            else if (!chkChqDateDed_SelectAll.Checked)
            {
                dtChequeDateDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelect"] = "\uE003"; });
            }
            dgvPreReturnCheques.Refresh();
            Calculate_Totals();
        }
        #endregion

        #region Commission Calcaulated Grid
        private void dgvCalcComission_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            Calculate_Totals();
        }

        private void dgvCalcComission_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 1 should be your column index
            {
                decimal i;
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please Enter Valid Numeric Value...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // No need to validate
                    // the input is numeric 
                }
            }
        }
        #endregion

        #region Return Cheque Deduction Grid - This Period
        private void dgvReturnCheqDeduction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate_Totals();
        }

        private void dgvReturnCheqDeduction_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvReturnCheqDeduction.RowCount > 0 && e.ColumnIndex == IsSelectRChq.Index)
            {
                int ilineNo = int.Parse(dgvReturnCheqDeduction.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr = dtReturnChequeDed.Select("LineNo = " + ilineNo + "").FirstOrDefault();
                if (dr != null)
                {
                    if (dr["IsSelectRChq"].ToString() == "\uE0A2")
                    {
                        dr["IsSelectRChq"] = "\uE003";
                    }
                    else
                    {
                        dr["IsSelectRChq"] = "\uE0A2";
                    }
                }
            }
            dgvReturnCheqDeduction.Refresh();
            Calculate_Totals();
        }

        private void chkRetChq_All_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetChq_All.Checked)
            {
                dtReturnChequeDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelectRChq"] = "\uE0A2"; });
            }
            else if (!chkRetChq_All.Checked)
            {
                dtReturnChequeDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelectRChq"] = "\uE003"; });
            }
            dgvReturnCheqDeduction.Refresh();
            Calculate_Totals();
        }
        #endregion

        #region Return Cheque Deduction Grid - Previous Periods
        private void dgvPreReturnCheques_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate_Totals();
        }

        private void dgvPreReturnCheques_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvPreReturnCheques.RowCount > 0 && e.ColumnIndex == IsSelectRchqP.Index)
            {
                int ilineNo = int.Parse(dgvPreReturnCheques.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr = dtReturnedPreChequeDed.Select("LineNo = " + ilineNo + "").FirstOrDefault();
                if (dr != null)
                {
                    if (dr["IsSelectRchqP"].ToString() == "\uE0A2")
                    {
                        dr["IsSelectRchqP"] = "\uE003";
                    }
                    else
                    {
                        dr["IsSelectRchqP"] = "\uE0A2";
                    }
                }
            }
            dgvPreReturnCheques.Refresh();
            Calculate_Totals();
        }

        private void chkRtnChqPrvAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRtnChqPrvAll.Checked)
            {
                dtReturnedPreChequeDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelectRchqP"] = "\uE0A2"; });
            }
            else if (!chkRtnChqPrvAll.Checked)
            {
                dtReturnedPreChequeDed.Select().ToList<DataRow>().ForEach(r => { r["IsSelectRchqP"] = "\uE003"; });
            }
            dgvPreReturnCheques.Refresh();
            Calculate_Totals();
        }
        #endregion

        #endregion

        #region Search Events
        private void txtSalesExecutiveID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtComPeriod.Tag != null)
                {
                    clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);

                    txtAreaManager.Enabled = false;
                    txtSalesManager.Enabled = false;
                    txtCollector.Enabled = false;

                    if (txtSalesExecutiveID.Tag != null && txtSalesExecutiveID.Tag.ToString() != "default")
                    {
                        ComCalcIndex = -1;

                        //Alreday Saved Data Retriving
                        tbl_comCommissionCalculation oCommissionCalculation =
                            tbl_comCommissionCalculation.SelectAllByPeriodIndex(long.Parse(txtComPeriod.Tag.ToString()))
                            .Where(r => r.SalesRep_ID == txtSalesExecutiveID.Tag.ToString()).FirstOrDefault();
                        if (oCommissionCalculation != null)
                        {
                            ComCalcIndex = oCommissionCalculation.ComCalcIndex;
                            Fill_SavedCommission_Details(oCommissionCalculation.ComCalcIndex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select Commission Period First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("txtSalesExecutiveID_MouseDoubleClick event error", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtComPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterComissionPeriod(ref txtComPeriod);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Expander Format
        private void ExpanderFormat()
        {
            try
            {
                expanderChequeDateDed.InitializeSize();
                expanderReturenChq.InitializeSize();
                expanderPreviousReturnChq.InitializeSize();

                expanderPreviousReturnChq.ThemeColor = Color.FromArgb(117, 82, 107);
                expanderReturenChq.ThemeColor = Color.FromArgb(117, 82, 107);
                expanderChequeDateDed.ThemeColor = Color.FromArgb(117, 82, 107);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Help Methods
        private void Calculate_Totals()
        {
            #region CHQ Date Deduction Grid
            //Claculation
            if (dtChequeDateDed != null && dtChequeDateDed.Rows.Count > 0)
            {
                var vSelectedRows = dtChequeDateDed.Select("IsSelect = '\uE0A2'");
                if (vSelectedRows.Length > 0)
                {
                    decimal sum = vSelectedRows.AsEnumerable().Sum(x =>  clsValidate.Validate_DecimalNumber(x.Field<string>("DedAmountChq")));
                    expanderChequeDateDed.DisplayAmount = clsFormatter.FormatDecimal(sum, 2);
                }
                else
                {
                    expanderChequeDateDed.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
                }
            }
            else
            {
                expanderChequeDateDed.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
            }

            //Display
            DataRow dr_ChqDateDed = dtComissionCalc.Select("LineNo = " + 3 + "").FirstOrDefault();
            if (dr_ChqDateDed != null)
            {
                dr_ChqDateDed["ComAmount"] =
                    clsFormatter.FormatDecimal(
                         clsValidate.Validate_DecimalNumber(expanderChequeDateDed.DisplayAmount), 2);

                dr_ChqDateDed["ComAmount_noVAT"] =
                    clsFormatter.FormatDecimal(
                         clsValidate.Validate_DecimalNumber(expanderChequeDateDed.DisplayAmount) * 100m / 114m, 2);
            }

            this.dgvCalcComission.Rows[2].Cells["ComAmount"].ReadOnly = true;
            this.dgvCalcComission.Rows[2].Cells["ComAmount_noVAT"].ReadOnly = true;
            #endregion

            #region Return CHQ Deduction Grid - This Period
            //Claculation
            if (dtReturnChequeDed != null && dtReturnChequeDed.Rows.Count > 0)
            {
                var vSelectedRows = dtReturnChequeDed.Select("IsSelectRChq = '\uE0A2'");
                if (vSelectedRows.Length > 0)
                {
                    decimal sum = vSelectedRows.AsEnumerable().Sum(x =>  clsValidate.Validate_DecimalNumber(x.Field<string>("DeductionAmount")));
                    expanderReturenChq.DisplayAmount = clsFormatter.FormatDecimal(sum, 2);
                }
                else
                {
                    expanderReturenChq.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
                }
            }
            else
            {
                expanderReturenChq.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
            }

            //Display
            DataRow dr_ReturnCHQDed = dtComissionCalc.Select("LineNo = " + 4 + "").FirstOrDefault();
            if (dr_ReturnCHQDed != null)
            {
                dr_ReturnCHQDed["ComAmount"] =
                    clsFormatter.FormatDecimal(clsValidate.Validate_DecimalNumber(expanderReturenChq.DisplayAmount),                        2);

                dr_ReturnCHQDed["ComAmount_noVAT"] =
                    clsFormatter.FormatDecimal(clsValidate.Validate_DecimalNumber(expanderReturenChq.DisplayAmount),                        2);
            }

            this.dgvCalcComission.Rows[3].Cells["ComAmount"].ReadOnly = true;
            this.dgvCalcComission.Rows[3].Cells["ComAmount_noVAT"].ReadOnly = true;
            #endregion

            #region Return CHQ Deduction Grid - Previous Period
            //Claculation
            if (dtReturnedPreChequeDed != null && dtReturnedPreChequeDed.Rows.Count > 0)
            {
                var vSelectedRows = dtReturnedPreChequeDed.Select("IsSelectRchqP = '\uE0A2'");
                if (vSelectedRows.Length > 0)
                {
                    decimal sum = vSelectedRows.AsEnumerable().Sum(x =>  clsValidate.Validate_DecimalNumber(x.Field<string>("DeductionAmount")));
                    expanderPreviousReturnChq.DisplayAmount = clsFormatter.FormatDecimal(sum, 2);
                }
                else
                {
                    expanderPreviousReturnChq.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
                }
            }
            else
            {
                expanderPreviousReturnChq.DisplayAmount = clsFormatter.FormatDecimal(0, 2);
            }

            //Display
            DataRow dr_ReturnCHQDed_Prv = dtComissionCalc.Select("LineNo = " + 5 + "").FirstOrDefault();
            if (dr_ReturnCHQDed_Prv != null)
            {
                dr_ReturnCHQDed_Prv["ComAmount"] =
                    clsFormatter.FormatDecimal(
                         clsValidate.Validate_DecimalNumber(expanderPreviousReturnChq.DisplayAmount), 2);

                dr_ReturnCHQDed_Prv["ComAmount_noVAT"] =
                    clsFormatter.FormatDecimal(
                         clsValidate.Validate_DecimalNumber(expanderPreviousReturnChq.DisplayAmount), 2);
            }

            this.dgvCalcComission.Rows[4].Cells["ComAmount"].ReadOnly = true;
            this.dgvCalcComission.Rows[4].Cells["ComAmount_noVAT"].ReadOnly = true;
            #endregion


            decimal dSecurityDeptDed_VAT = 0;
            decimal dSecurityDeptDed_noVAT = 0;
            decimal dItmCatAmount_VAT = 0;
            decimal dItmCatAmount_noVAT = 0;
            decimal dChqDateDed_VAT = 0;
            decimal dChqDateDed_noVAT = 0;
            foreach (DataRow row in dtComissionCalc.Rows)
            {
                if (dtComissionCalc.Rows.IndexOf(row) == 0)
                {
                    dItmCatAmount_VAT =  clsValidate.Validate_DecimalNumber(row["ComAmount"].ToString());
                    dItmCatAmount_noVAT =  clsValidate.Validate_DecimalNumber(row["ComAmount_noVAT"].ToString());
                }

                if (dtComissionCalc.Rows.IndexOf(row) == 2)
                {
                    dChqDateDed_VAT =  clsValidate.Validate_DecimalNumber(row["ComAmount"].ToString());
                    dChqDateDed_noVAT =  clsValidate.Validate_DecimalNumber(row["ComAmount_noVAT"].ToString());
                }

                if (dtComissionCalc.Rows.IndexOf(row) == 5)
                {
                    dSecurityDeptDed_VAT = (dItmCatAmount_VAT - dChqDateDed_VAT) * 0.20m;
                    dSecurityDeptDed_noVAT = (dItmCatAmount_noVAT - dChqDateDed_noVAT) * 0.20m;

                    row["ComAmount"] = clsFormatter.FormatDecimal(dSecurityDeptDed_VAT, 2);
                    row["ComAmount_noVAT"] = clsFormatter.FormatDecimal(dSecurityDeptDed_noVAT, 2);
                }
            }

            decimal dNetComission_WithVAT = 0m;
            decimal dNetComission_NoVAT = 0m;

            foreach (DataRow row in dtComissionCalc.Rows)
            {
                if (dtComissionCalc.Rows.IndexOf(row) == 0)
                {
                    dNetComission_WithVAT += clsValidate.Validate_DecimalNumber(row["ComAmount"].ToString());
                    dNetComission_NoVAT += clsValidate.Validate_DecimalNumber(row["ComAmount_noVAT"].ToString());
                }

                else if (dtComissionCalc.Rows.IndexOf(row) < 9)
                {
                    dNetComission_WithVAT -= clsValidate.Validate_DecimalNumber(row["ComAmount"].ToString());
                    dNetComission_NoVAT -= clsValidate.Validate_DecimalNumber(row["ComAmount_noVAT"].ToString());
                }

                else if (dtComissionCalc.Rows.IndexOf(row) == 9)
                {
                    row["ComAmount"] = clsFormatter.FormatDecimal(dNetComission_WithVAT, 2);
                    row["ComAmount_noVAT"] = clsFormatter.FormatDecimal(dNetComission_NoVAT, 2);

                    this.dgvCalcComission.Rows[9].DefaultCellStyle.Font = new Font("segoe ui", 9, FontStyle.Bold);
                    this.dgvCalcComission.Rows[9].Cells["ComAmount"].ReadOnly = true;
                    this.dgvCalcComission.Rows[9].Cells["ComAmount_noVAT"].ReadOnly = true;
                }
            }
        }
        private decimal Commission_Invoice_WithVAT_New(int iRoleOfEmp, string sInvoice_ID,decimal AllocationRaitio)//ref DataTable dtComInvoices
        {
            decimal dCommission = 0m;
            decimal Rate = 0;
            foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoice_ID))
            {
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oInvoiceDetail.Item_ID);
                if (oItem != null)
                {
                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                    if (oItemCategory != null)
                    {
                        //switch (iRoleOfEmp)
                        //{
                        //    case (int)SalesCommission_EmpRole.SalesRep:
                        //        Rate = (oInvoiceDetail.DiscountAmount > 0) ? oItemCategory.DiscountedSalesRate_SR : oItemCategory.NormalSalesRate_SR;
                        //        break;

                        //    case (int)SalesCommission_EmpRole.AreaManager:
                        //        Rate = (oInvoiceDetail.DiscountAmount > 0) ? oItemCategory.DiscountedSalesRate_AM : oItemCategory.NormalSalesRate_AM;
                        //        break;

                        //    case (int)SalesCommission_EmpRole.SalesManager:
                        //        Rate = (oInvoiceDetail.DiscountAmount > 0) ? oItemCategory.DiscountedSalesRate_SM : oItemCategory.NormalSalesRate_SM;
                        //        break;

                        //    case (int)SalesCommission_EmpRole.Collector:
                        //        Rate = (oInvoiceDetail.DiscountAmount > 0) ? oItemCategory.DiscountedSalesRate_Col : oItemCategory.NormalSalesRate_Col;
                        //        break;
                        //}
dCommission += oInvoiceDetail.TatalAmount *  (DeductionPresentage/100)  * AllocationRaitio;
                     //   dCommission += oInvoiceDetail.TatalAmount * Rate* AllocationRaitio;
                       
                    }
                }
            }

            return dCommission;
        }
       
        private decimal Commission_Invoice_WithVAT(int iRoleOfEmp, string sInvoice_ID)//ref DataTable dtComInvoices
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("InvoiceID");
            //dt.Columns.Add("Line_No");
            //dt.Columns.Add("Item_ID");
            //dt.Columns.Add("Total_Amount");
            //dt.Columns.Add("ComPct");
            //dt.Columns.Add("ComAmount");

            decimal dCommission = 0m;
            foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoice_ID))
            {
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oInvoiceDetail.Item_ID);
                if (oItem != null)
                {
                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                    if (oItemCategory != null)
                    {
                        if (oInvoiceDetail.DiscountAmount > 0)
                        {
                            if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.DiscountedSalesRate_SR);
                                //dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.DiscountedSalesRate_SR, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.DiscountedSalesRate_AM);
                                //dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.DiscountedSalesRate_AM, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.DiscountedSalesRate_SM);
                                //dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.DiscountedSalesRate_SM, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.DiscountedSalesRate_Col);
                                // dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.DiscountedSalesRate_Col, dCommission);
                            }
                        }
                        else
                        {
                            if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.NormalSalesRate_SR);
                                // dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.NormalSalesRate_SR, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.NormalSalesRate_AM);
                                // dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.NormalSalesRate_AM, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.NormalSalesRate_SM);
                                // dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.NormalSalesRate_SM, dCommission);
                            }
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                            {
                                dCommission += oInvoiceDetail.TatalAmount * (oItemCategory.NormalSalesRate_Col);
                                // dt.Rows.Add(oInvoiceDetail.Invoice_ID, oInvoiceDetail.Line_No, oInvoiceDetail.Item_ID, oInvoiceDetail.TatalAmount, oItemCategory.NormalSalesRate_Col, dCommission);
                            }
                        }
                    }
                }
            }

            //dtComInvoices.Merge(dt);
            return dCommission;
        }

        private decimal Commission_Invoice_NoVAT(int iRoleOfEmp, tbl_sasInvoice oInvoice)
        {
            decimal dCommission_NoVAT = 0m;
            foreach (tbl_sasInvoice_Detail oInvoiceDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
            {
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oInvoiceDetail.Item_ID);
                if (oItem != null)
                {
                    tbl_comItemCategory_comissionRates oItemCategory = tbl_comItemCategory_comissionRates.Select(oItem.ItemCategory_ID);
                    if (oItemCategory != null)
                    {
                        if (oInvoiceDetail.DiscountAmount > 0)
                        {
                            if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.DiscountedSalesRate_SR);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.DiscountedSalesRate_AM);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.DiscountedSalesRate_SM);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.DiscountedSalesRate_Col);
                        }
                        else
                        {
                            if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesRep)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.NormalSalesRate_SR);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.AreaManager)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.NormalSalesRate_AM);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.SalesManager)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.NormalSalesRate_SM);
                            else if (iRoleOfEmp == (int)SalesCommission_EmpRole.Collector)
                                dCommission_NoVAT += Get_VAT_ExclusivePrice(oInvoiceDetail.TatalAmount, oInvoice.VatPercentage) * (oItemCategory.NormalSalesRate_Col);
                        }
                    }
                }
            }

            return dCommission_NoVAT;
        }

        private void Insert_Commission_Detail()
        {
            #region Role of Employee
            int iRoleOfEmp = -1;
            if (txtSalesExecutiveID.Tag != null)
                iRoleOfEmp = (int)SalesCommission_EmpRole.SalesRep;
            else if (txtAreaManager.Tag != null)
                iRoleOfEmp = (int)SalesCommission_EmpRole.AreaManager;
            else if (txtSalesManager.Tag != null)
                iRoleOfEmp = (int)SalesCommission_EmpRole.SalesManager;
            else if (txtCollector.Tag != null)
                iRoleOfEmp = (int)SalesCommission_EmpRole.Collector;
            #endregion

            long lComCalcChqIndex = -1;
            var vComCHQ = tbl_comCommissionCalculation_Cheque.SelectAll();

            if (vComCHQ.Count > 0)
                lComCalcChqIndex = vComCHQ.Max(r => r.ComCalcChqIndex);

            foreach (DataRow chqDR in dtChequeDateDed.Rows)
            {
                string sIsSelect = clsValidate.ValidateRowValue(chqDR, "IsSelect", "\uE003");
                string sDateSlab = clsValidate.ValidateRowValue(chqDR, "DateSlab", "");
                string sCheqRegID = clsValidate.ValidateRowValue(chqDR, "CheqRegID", "default");
                decimal dChqDedRate = clsValidate.ValidateRowValue(chqDR, "ChqDedRate", 0m);
                decimal dDedAmountChq = clsValidate.ValidateRowValue(chqDR, "DedAmountChq", 0m);
                string sTx = clsValidate.ValidateRowValue(chqDR, "Transaction", "default");
                decimal AllocatedAmount = clsValidate.ValidateRowValue(chqDR, "AllocatedAmount", 0m);
                string sRemark = clsValidate.ValidateRowValue(chqDR, "Remark", "");

                tbl_comCommissionCalculation_Cheque oChq = new tbl_comCommissionCalculation_Cheque(++lComCalcChqIndex,
                    long.Parse(txtCommissionCalc.Tag.ToString()), long.Parse(txtComPeriod.Tag.ToString()),
                    txtSalesExecutiveID.Tag != null ? txtSalesExecutiveID.Tag.ToString() : "default",
                    txtAreaManager.Tag != null ? txtAreaManager.Tag.ToString() : "default",
                    txtSalesManager.Tag != null ? txtSalesManager.Tag.ToString() : "default",
                    txtCollector.Tag != null ? txtCollector.Tag.ToString() : "default",
                    iRoleOfEmp, sCheqRegID, sTx, true, false, false, sIsSelect == "\uE003" ? false : true,
                    int.Parse(sDateSlab), dChqDedRate, dDedAmountChq, sRemark, AllocatedAmount);
                oChq.Insert();
            }

            foreach (DataRow chqDR in dtReturnChequeDed.Rows)
            {
                string sIsSelect = clsValidate.ValidateRowValue(chqDR, "IsSelectRChq", "\uE003");
                string sCheqRegID = clsValidate.ValidateRowValue(chqDR, "CheqRegID", "default");
                decimal dChqDedRate = clsValidate.ValidateRowValue(chqDR, "DeductionRate", 0m);
                decimal dDedAmountChq = clsValidate.ValidateRowValue(chqDR, "DeductionAmount", 0m);
                string sTx = clsValidate.ValidateRowValue(chqDR, "TransactionID", "default");
                string sRemark = clsValidate.ValidateRowValue(chqDR, "Remark", "");

                tbl_comCommissionCalculation_Cheque oChq = new tbl_comCommissionCalculation_Cheque(++lComCalcChqIndex,
                    long.Parse(txtCommissionCalc.Tag.ToString()), long.Parse(txtComPeriod.Tag.ToString()),
                    txtSalesExecutiveID.Tag != null ? txtSalesExecutiveID.Tag.ToString() : "default",
                    txtAreaManager.Tag != null ? txtAreaManager.Tag.ToString() : "default",
                    txtSalesManager.Tag != null ? txtSalesManager.Tag.ToString() : "default",
                    txtCollector.Tag != null ? txtCollector.Tag.ToString() : "default",
                    iRoleOfEmp,
                    sCheqRegID, sTx, false, true, false, sIsSelect == "\uE003" ? false : true, -1,
                    dChqDedRate, dDedAmountChq, sRemark,0);
                oChq.Insert();
            }

            foreach (DataRow chqDR in dtReturnedPreChequeDed.Rows)
            {
                string sIsSelect = clsValidate.ValidateRowValue(chqDR, "IsSelectRchqP", "\uE003");
                string sCheqRegID = clsValidate.ValidateRowValue(chqDR, "CheqRegID", "default");
                decimal dChqDedRate = clsValidate.ValidateRowValue(chqDR, "DeductionRate", 0m);
                decimal dDedAmountChq = clsValidate.ValidateRowValue(chqDR, "DeductionAmount", 0m);
                string sTx = clsValidate.ValidateRowValue(chqDR, "RTransactionID", "default");
                string sRemark = clsValidate.ValidateRowValue(chqDR, "Remark", "");

                tbl_comCommissionCalculation_Cheque oChq = new tbl_comCommissionCalculation_Cheque(++lComCalcChqIndex,
                    long.Parse(txtCommissionCalc.Tag.ToString()), long.Parse(txtComPeriod.Tag.ToString()),
                    txtSalesExecutiveID.Tag != null ? txtSalesExecutiveID.Tag.ToString() : "default",
                    txtAreaManager.Tag != null ? txtAreaManager.Tag.ToString() : "default",
                    txtSalesManager.Tag != null ? txtSalesManager.Tag.ToString() : "default",
                    txtCollector.Tag != null ? txtCollector.Tag.ToString() : "default",
                    iRoleOfEmp,
                    sCheqRegID, sTx, false, false, true, sIsSelect == "\uE003" ? false : true, -1,
                    dChqDedRate, dDedAmountChq, sRemark,0);
                oChq.Insert();
            }
        }

        private bool Is_ReturnedCheque(string sChqReg_ID)
        {
            bool bStatus = false;

            var vRecs = tbl_bpsChequeReconciliation_Detail.SelectAllByChequeRegister_ID(sChqReg_ID).Where(r =>
                 r.ChequeStatus_ID == "4" || r.ChequeStatus_ID == "5" || r.ChequeStatus_ID == "6");
            if (vRecs != null && vRecs.Count() > 0)
            {
                bStatus = true;
            }

            return bStatus;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
            {
                if (CheckValidity_EmptyField())
                {
                    tbl_comCommissionCalculation oCommissionCalculation =
                        tbl_comCommissionCalculation.Select(long.Parse(txtCommissionCalc.Tag.ToString()));
                    if (oCommissionCalculation != null)
                    {
                        if (!oCommissionCalculation.IsDeleted)
                        {
                            DialogResult msgResult = MessageBox.Show(
                                clsFormatter.GetMessageFrom(MessageType.AskForDelete,
                                    " Comission for " + txtComPeriod.Text + " - " + txtSalesExecutiveID.Text),
                                clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                            if (msgResult == DialogResult.Yes)
                            {
                                oCommissionCalculation.IsDeleted = true;
                                oCommissionCalculation.DateDeleted = clsSecurity.getServerDateTime();
                                oCommissionCalculation.DeletedTerminal_ID = clsSecurity.TerminalID;
                                oCommissionCalculation.DeletedUser_ID = clsSecurity.UserIDLoged;
                                oCommissionCalculation.Update();
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted),
                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        private decimal Get_VAT_ExclusivePrice(decimal dUnitPriceWith_VAT, decimal dVAT_Pct)
        {
            decimal dUnitPriceNo_VAT = 0m;
            dUnitPriceNo_VAT = Math.Round((dUnitPriceWith_VAT * 100 / (dVAT_Pct + 100m)), 2);
            return dUnitPriceNo_VAT;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                string sDuplicate = "";
                if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.COM_CommissionCalculationNP), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    glb_dts_CommissionNP.Clear();
                    glb_dtsReportExport.Clear();
                    Cursor = Cursors.WaitCursor;

                 //   bool bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.COM_CommissionCalculationNP));
                 //   if (bPermissinOkToPrint)
                    {
                        tbl_comCommissionCalculation oCommission = tbl_comCommissionCalculation.Select(int.Parse(txtCommissionCalc.Tag.ToString()));
                        if (oCommission != null)
                        {
                            string sEmpID = "";
                            string sEmpName = "";
                            if (txtSalesExecutiveID.Tag != null && txtSalesExecutiveID.Tag.ToString() != "default")
                            {
                                sEmpID = oCommission.SalesRep_ID;
                                sEmpName = txtSalesExecutiveID.Text.ToUpper();
                            }
                            else if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString() != "default")
                            {
                                sEmpID = oCommission.AreaManger_ID;
                                sEmpName = txtAreaManager.Text.ToUpper();
                            }
                            else if (txtSalesManager.Tag != null && txtSalesManager.Tag.ToString() != "default")
                            {
                                sEmpID = oCommission.SalesManager_ID;
                                sEmpName = txtSalesManager.Text.ToUpper();
                            }
                            else if (txtCollector.Tag != null && txtCollector.Tag.ToString() != "default")
                            {
                                sEmpID = oCommission.Collector_ID;
                                sEmpName = txtCollector.Text.ToUpper();
                            }

                            glb_dts_CommissionNP.dt_Commssion.Adddt_CommssionRow(txtComPeriod.Text.ToUpper(),
                                oCommission.PeriodIndex, sEmpID, sEmpName,
                                oCommission.Remarks, oCommission.ChequePeriod_fromDays, oCommission.ChequePeriod_toDays,
                                oCommission.Gross_commission_withVAT, oCommission.Ded_CRN_withVAT,
                                oCommission.Ded_ChqDate_withVAT, oCommission.Ded_RchqThisPeriod_withVAT,
                                oCommission.Ded_RchqPrvPeriod_withVAT, oCommission.Ded_SecurityDept_withVAT,
                                oCommission.Ded_BillAdv_withVAT, oCommission.Ded_Loan_withVAT,
                                oCommission.Ded_Advance_withVAT, oCommission.Net_commission_withVAT,
                                oCommission.Gross_commission_withoutVAT, oCommission.Ded_CRN_withoutVAT,
                                oCommission.Ded_ChqDate_withoutVAT, oCommission.Ded_RchqThisPeriod_withoutVAT,
                                oCommission.Ded_RchqPrvPeriod_withoutVAT, oCommission.Ded_SecurityDept_withoutVAT,
                                oCommission.Ded_BillAdv_withoutVAT, oCommission.Ded_Loan_withoutVAT,
                                oCommission.Ded_Advance_withoutVAT, oCommission.Net_commission_withoutVAT,
                                oCommission.IsApproved);

                            sCreateUser = "[ " + clsGenaralName.getName_User(oCommission.CreateUser_ID) + " | " + oCommission.DateCreate + " ]";
                            if (oCommission.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oCommission.CheckedUser_ID) + " | " + oCommission.DateChecked + "]";
                            if (oCommission.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oCommission.ApprovedUser_ID) + " | " + oCommission.DateApproved + "]";
                        }

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);
                        //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("LastModifiedDate", LastModifiedDate, true);
                        //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oCommission.IsDeleted ? "CANCELLED" : "", true);

                        #region Company Details Fill
                        string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                        byte[] bCompanyImage = clsCommon.getCompanyImage();

                        #region Draft Print - (Not Developped)
                        //if (bIsDraft)
                        //{
                        //    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                        //    {
                        //        sCompanyName = "";
                        //        sCompanyAddress1 = "";
                        //        sCompanyAddress2 = "";
                        //        bCompanyImage = null;

                        //        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                        //    }
                        //} 
                        #endregion

                        glb_dts_CommissionNP.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                        #endregion

                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                        rpt.print(sReportPath, glb_dts_CommissionNP, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.COM_CommissionCalculationNP));
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                glb_dts_CommissionNP.Clear();
                glb_dtsReportExport.Clear();
                Cursor = Cursors.Default;
            }
        }

        private void txtAreaManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtComPeriod.Tag != null)
                {
                    clsSearch.Search_AreaManager(ref txtAreaManager);

                    txtSalesExecutiveID.Enabled = false;
                    txtSalesManager.Enabled = false;
                    txtCollector.Enabled = false;

                    if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString() != "default")
                    {
                        //Alreday Saved Data Retriving
                        tbl_comCommissionCalculation oCommissionCalculation =
                            tbl_comCommissionCalculation.SelectAllByPeriodIndex(long.Parse(txtComPeriod.Tag.ToString()))
                                .Where(r => r.AreaManger_ID == txtAreaManager.Tag.ToString()).FirstOrDefault();
                        if (oCommissionCalculation != null)
                            Fill_SavedCommission_Details(oCommissionCalculation.ComCalcIndex);
                    }

                }
                else
                {
                    MessageBox.Show("Please select Commission Period First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("txtAreaManager_MouseDoubleClick event error", iFormID, ex);
                SEACCException.Show(ex);
            }

        }

        private void txtSalesManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtComPeriod.Tag != null)
                {
                    clsSearch.Search_SalesManager(ref txtSalesManager);
                    txtSalesExecutiveID.Enabled = false;
                    txtAreaManager.Enabled = false;
                    txtCollector.Enabled = false;

                    if (txtSalesManager.Tag != null && txtSalesManager.Tag.ToString() != "default")
                    {
                        //Alreday Saved Data Retriving
                        tbl_comCommissionCalculation oCommissionCalculation =
                            tbl_comCommissionCalculation.SelectAllByPeriodIndex(long.Parse(txtComPeriod.Tag.ToString()))
                                .Where(r => r.SalesManager_ID == txtSalesManager.Tag.ToString()).FirstOrDefault();
                        if (oCommissionCalculation != null)
                            Fill_SavedCommission_Details(oCommissionCalculation.ComCalcIndex);
                    }

                }
                else
                {
                    MessageBox.Show("Please select Commission Period First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("txtAreaManager_MouseDoubleClick event error", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCollector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (txtComPeriod.Tag != null)
                {
                    clsSearch.Search_MasterCollector(ref txtCollector);
                    txtSalesExecutiveID.Enabled = false;
                    txtAreaManager.Enabled = false;
                    txtSalesManager.Enabled = false;

                    if (txtCollector.Tag != null && txtCollector.Tag.ToString() != "default")
                    {
                        //Alreday Saved Data Retriving
                        tbl_comCommissionCalculation oCommissionCalculation =
                            tbl_comCommissionCalculation.SelectAllByPeriodIndex(long.Parse(txtComPeriod.Tag.ToString()))
                                .Where(r => r.Collector_ID == txtCollector.Tag.ToString()).FirstOrDefault();
                        if (oCommissionCalculation != null)
                            Fill_SavedCommission_Details(oCommissionCalculation.ComCalcIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Please select Commission Period First...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("txtCollector_MouseDoubleClick event error", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void btnPrintChqDeduction_Click(object sender, EventArgs e)
        {
            if (txtComPeriod.Text == "" || txtSalesExecutiveID.Text == "")
            {
                MessageBox.Show("Records not found..!");
                return;
            }
             if (ComCalcIndex == -1)
            {
                MessageBox.Show("Please save records before print this statement");
                return;
            }
        
            try
            {
                Cursor = Cursors.WaitCursor;

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                string sDuplicate = "";
                string Report_ID = clsAutocode.getReportID(enum_ReportName.COM_CommissionChqDeduction);

                if (clsHelpMethods_Local.GetReportPath(Report_ID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    dts_Unspecified glb_dts_sasDeliveryOrder = new dts_Unspecified();

                    Cursor = Cursors.WaitCursor;

                    glb_dts_sasDeliveryOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");

                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();                

                    string sQuary = "exec sp_GetRPT_CommissionChqDeduction " + ComCalcIndex;

                    glb_dts_sasDeliveryOrder.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("ComPeriod", txtComPeriod.Text, true);
                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("SalesRep", txtSalesExecutiveID.Text, true);

                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                    CRViwer.print(sReportPath, glb_dts_sasDeliveryOrder, glb_dts_ExportReport.dt_rptParameter, Report_ID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }



            
        }

        private void txtCollector_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
