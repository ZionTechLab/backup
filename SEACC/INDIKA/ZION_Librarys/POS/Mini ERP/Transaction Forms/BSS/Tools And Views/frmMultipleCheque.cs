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
    public partial class frmMultipleCheque : Form
    {
        #region Variables
        //public Variables

        public static DataTable dtRecodes = new DataTable();       
        private BindingSource source = new BindingSource();
        public decimal dTotal = 0;
        public static bool bClear = false;
        int iRow;

        public static string glbDrAmount="0";
        public static int glbiChqueCounnt=0;
        public static string glbReceiptID = "";
        public DataTable glb_dtSubTotal = new DataTable();

        private bool bIsLockChequeDetails = false;
        #endregion

        #region Form Load
        public frmMultipleCheque(bool bIsLock)
        {
            InitializeComponent();
            bIsLockChequeDetails = bIsLock;

        }

        private void frmMultipleCheque_Load(object sender, EventArgs e)
        {            
            if(!bClear)
                ClearFields();

            if (bIsLockChequeDetails)
                DisableControl_ChequeDetails();

            CreateDataTable_Account();
            if (dtRecodes.Rows.Count == 0)
            {
                CreateDataTable();
                dtRecodes.Clear();
            }
            else
                RefreshGrid();

            if (glbReceiptID.Trim().Length > 0)
                RefershWithReceiptID();

            txtChequeType.Tag = 0;
            txtChequeType.Text = "Cash Cheque";

            if (clsConfig.bIsCompanyChequeBankType)
                txtAccountNo.BackColor = Color.LightGray;
        }                      
        #endregion


        #region Btn Ok
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckValidityForBank())
                {
                    if (!CheckGrid())
                    {
                        // iRow = clsHelpMethods.GetMaxzimumLineNoCheque(frm_trnSabeelReceipt.ID);
                        dtRecodes.Clear();
                        dtRecodes.Rows.Add(txtAccountNo.Text.Trim(), txtBankName.Text, txtChequeNo.Text.Trim(), dtpChequeDate.Value, txtChequeType.Tag.ToString(),
                       clsHelpMethods.getSavePrice(decimal.Parse(txtAmount.Text.ToString()), txtExRate),
                            txtBankName.Tag.ToString(), txtBranchName.Tag.ToString(), txtBranchName.Text, (++iRow), txtChqregisterNo.Text, txtRemark.Text);
                        RefreshGrid();
                        CalculateDrAmount();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                AsignDetails_SubTotals();
            }
        }
        #endregion        


        #region Grid Check
        private bool CheckGrid()
        {
            bool bhasRow = false;
            foreach (DataGridViewRow dRow in dgvDetail.Rows)
            {
                if (txtBankName.Tag.ToString() == dRow.Cells[5].Value.ToString() && txtChequeNo.Text == dRow.Cells[1].Value.ToString())
                {
                    MessageBox.Show("Can't Add Duplicate Cheque Number");
                    bhasRow = true;
                }
            }
            return bhasRow;
        }

        #endregion

        #region Btn GridDelete
        private void btnGridDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                    {
                        //dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);                        
                        CalculateDrAmount();
                        //dtRecodes.Rows.RemoveAt(dgvDetail.CurrentRow.Index);
                        if (dgvDetail.SelectedRows.Count > 0)
                        {
                            dtRecodes.Rows.RemoveAt(dgvDetail.SelectedRows[0].Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }           
            RefreshGrid();
            CalculateDrAmount(); 
        }
        #endregion               

        #region Btn Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            AsignDetails_SubTotals();
            bClear = true;
            this.Close();
        }
        #endregion


        #region ClearFields
        private void ClearFields()
        {
            txtBankName.Tag = null;
            txtBankName.Clear();
            txtBranchName.Tag = null;
            txtBranchName.Clear();
            txtChequeType.Tag = null;
            //  txtAmount.Clear();
            dtpChequeDate.Value = clsSecurity.getServerDateTime();
            txtChequeNo.Clear();
            txtAccountNo.Clear();
            txtChequeType.Clear();
            txtChqregisterNo.Tag = null;
            txtChqregisterNo.Clear();
            txtRemark.Clear();
            DisableControl();            
            bClear = false;
        }

        private void DisableControl()
        {
            txtBranchName.Enabled = false;
            txtBankName.Enabled = false;
            txtChequeType.Enabled = false;
            lblChequeType.Enabled = false;
            lblBranch.Enabled = false;
            lblBank.Enabled = false;           
        }

        private void DisableControl_ChequeDetails()
        {
            txtAccountNo.Enabled = false;
            dtpChequeDate.Enabled = false;
            txtChequeNo.Enabled = false;
            txtAmount.Enabled = false;
            txtRemark.Enabled = false;
        }


        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            dTotal = 0;
            try
            {                         
                dgvDetail.DataSource = dtRecodes;
                clsFormatter.ApplyGridFormatCheque(dgvDetail);

                dgvDetail.Columns["AccountNo"].Visible = true;
                dgvDetail.Columns["AccountNo"].HeaderText = "Account No.";
                dgvDetail.Columns["AccountNo"].Width = 80;
                dgvDetail.Columns["Amount"].Width = 80;
                dgvDetail.Columns["ChequeNo"].HeaderText = "Cheque No.";
                dgvDetail.Columns["Bank"].HeaderText = "Bank Name";
                dgvDetail.Columns["ChequeDate"].HeaderText = "Bank Name";
                dgvDetail.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetail.Columns["ChequeNo"].Width = 80;
                dgvDetail.Columns["ChequeType"].Visible = false;
                dgvDetail.Columns["BankID"].Visible = false;
                dgvDetail.Columns["BranchID"].Visible = false;
                dgvDetail.Columns["Branch"].Visible = false;
                dgvDetail.Columns["LineNo"].Visible = false;
                dgvDetail.Columns["ChequeRegisterID"].Visible = false;

                foreach (DataRow row in dtRecodes.Rows)
                {
                    txtAccountNo.Text = row["AccountNo"].ToString();
                    txtAmount.Text = clsHelpMethods.getDisplayPrice(decimal.Parse(row["Amount"].ToString().Trim()),txtExRate).ToString();
                    txtBankName.Tag = row["BankID"].ToString();
                    txtBranchName.Tag = row["BranchID"].ToString();
                    txtChequeNo.Text = row["ChequeNo"].ToString();
                    txtChequeType.Text = row["ChequeType"].ToString();
                    txtChqregisterNo.Text = row["ChequeRegisterID"].ToString();
                    txtBankName.Text = clsGenaralName.getName_Bank(row["BankID"].ToString());
                    txtBranchName.Text = clsGenaralName.getName_BankBranch(row["BranchID"].ToString());
                    dtpChequeDate.Value = DateTime.Parse(row["ChequeDate"].ToString());
                    txtRemark.Text = row["Remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
            foreach (DataGridViewRow iRow in dgvDetail.Rows)
            {
                dTotal += Convert.ToDecimal(dgvDetail["Amount", iRow.Index].Value);
            }
            txtTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotal);
        }

        private void RefershWithReceiptID()
        {
            
            List<tbl_accReceiptMultiple_Cheque> detailMultipleCheque = tbl_accReceiptMultiple_Cheque.SelectAllByReceipt_ID(glbReceiptID);
            dtRecodes.Rows.Clear();
            foreach (tbl_accReceiptMultiple_Cheque detailC in detailMultipleCheque)
            {
                if (detailC.Receipt_ID.Trim() != "default")
                {
                    dtRecodes.Rows.Add(detailC.Line_No,
                        clsGenaralName.getName_Bank(detailC.Bank_ID),
                        clsGenaralName.getName_BankBranch(detailC.Branch_ID),
                        detailC.DateCheque,
                        detailC.ChequeNo,
                        detailC.ChequeAmount);
                }
            }            
        } 
        #endregion


        #region Event Double Click
        private void txtBankName_DoubleClick(object sender, EventArgs e)
        {
            try
            {                
                if (clsConfig.bIsCompanyChequeBankType)
                {
                    clsSearch.SearchMaster_CompanyBank(ref txtBankName);
                    if(txtBankName.Tag != null)
                    txtBranchName.Enabled = true;
                }
                else
                {
                    clsSearch.Search_Bank(ref txtBankName);
                    if (txtBankName.Tag != null)
                    txtBranchName.Enabled = true;
                }
                //clsSearch.Search_Bank(ref txtBankID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
                
        private void txtBranchName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (clsConfig.bIsCompanyChequeBankType)
                {
                    clsSearch.SearchMaster_CompanyBankBranchesByBankID(ref txtBranchName, txtBankName.Tag.ToString());                    
                }
                else 
                {
                    clsSearch.Search_BankBranch(ref txtBranchName, txtBankName.Tag.ToString());                    
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        private void txtChequeType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ChequeType(ref txtChequeType);
        }

        private void txtAccountNo_DoubleClick(object sender, EventArgs e)
        {
            if (clsConfig.bIsCompanyChequeBankType)
            {
                clsSearch.SearchMaster_CompanyAccount(ref txtAccountNo, "", "");
                //clsSearch.SearchMaser_CompanyAccount(ref txtAccountNo);
                if (txtAccountNo.Tag != null)
                {
                    tbl_genCompanyAccount detial = tbl_genCompanyAccount.Select(txtAccountNo.Tag.ToString());
                    if (detial != null)
                    {
                        txtBankName.Tag = detial.Bank_ID;
                        txtBranchName.Tag = detial.Branch_ID;

                        txtBankName.Text = clsGenaralName.getName_Bank(detial.Bank_ID);
                        txtBranchName.Text = clsGenaralName.getName_BankBranch(detial.Branch_ID);
                    }
                }
            }
        }
        #endregion

        #region Events KeyPress
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtAmount.Text.Trim(), e);
        }

        private void txtChequeDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        #endregion        

        #region CreateDataTable
        public static void CreateDataTable()
        {
            dtRecodes.Columns.Clear();            
            dtRecodes.Columns.Add("AccountNo", typeof(string));
            dtRecodes.Columns.Add("Bank", typeof(string));
            dtRecodes.Columns.Add("ChequeNo", typeof(string));
            dtRecodes.Columns.Add("ChequeDate", typeof(string));  
            dtRecodes.Columns.Add("ChequeType", typeof(string));
            dtRecodes.Columns.Add("Amount", typeof(decimal));
            dtRecodes.Columns.Add("BankID", typeof(string));
            dtRecodes.Columns.Add("BranchID", typeof(string));            
            dtRecodes.Columns.Add("Branch", typeof(string));  
            dtRecodes.Columns.Add("LineNo", typeof(int));
            dtRecodes.Columns.Add("ChequeRegisterID", typeof(string));
            dtRecodes.Columns.Add("Remarks", typeof(string));
        }
        private void CreateDataTable_Account()
        {
            glb_dtSubTotal = new DataTable();
            glb_dtSubTotal.Columns.Add("Line_No", typeof(int));
            glb_dtSubTotal.Columns.Add("GLCode", typeof(string));
            glb_dtSubTotal.Columns.Add("GLName", typeof(string));
            glb_dtSubTotal.Columns.Add("GLAmount", typeof(decimal));
            glb_dtSubTotal.Columns.Add("SubAcct1", typeof(string));
            glb_dtSubTotal.Columns.Add("SubAcct2", typeof(string));
            glb_dtSubTotal.Columns.Add("Employee", typeof(string));
            glb_dtSubTotal.Columns.Add("OtherCr", typeof(string));
            glb_dtSubTotal.Columns.Add("CategoryID", typeof(int));
            glb_dtSubTotal.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("Employee_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("APN_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("Remarks", typeof(string));
        }             
        #endregion        
        
        #region Validate
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtBankName.TextLength == 0)
            {
                strMessage += "\n" + "Bank Name ";
                bStatus = false;
            }
            if (txtChequeType.TextLength == 0)
            {
                strMessage += "\n" + "Cheque Type ";
                bStatus = false;
            }
            if (txtBranchName.TextLength == 0)
            {
                strMessage += "\n" + "Branch Name ";
                bStatus = false;
            }
            if (txtAmount.TextLength == 0 || Convert.ToDecimal(txtAmount.Text) <= 0)
            {
                strMessage += "\n" + "Amount Cannot be Zero";
                bStatus = false;
            }
            if (txtChequeNo.TextLength == 0)
            {
                strMessage += "\n" + "Cheque No ";
                bStatus = false;
            }
            if (txtAccountNo.TextLength == 0)
                txtAccountNo.Text = "0";

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            return bStatus;
        }
        private bool CheckValidityForBank()
        {
            bool bStatus = true;

            string sBankGLCode = clsMethods_GL.getAccountCode_Bank(txtAccountNo.Text.Trim());
            if (sBankGLCode.Equals("default"))
            {
                MessageBox.Show("This bank needs to have a GL Account. Please create/tag an appropriate bank Account Code.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                bStatus = false;
            }
            return bStatus;
        }
        #endregion

        #region CalculateDrAmount
        private void CalculateDrAmount()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (dgvDetail["Amount", x].Value != null && dgvDetail["Amount", x].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Value.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Value.ToString());
                    }
                }
                glbDrAmount = Amount.ToString();
                glbiChqueCounnt = dgvDetail.Rows.Count;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion                             
       

        #region dgv CellClick
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                txtBankName.Tag = dgvDetail[6, dgvDetail.SelectedRows[0].Index].Value.ToString();
                txtBankName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(txtBankName.Tag.ToString()));
                txtBranchName.Tag = dgvDetail[7, dgvDetail.SelectedRows[0].Index].Value.ToString();
                txtBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(txtBranchName.Tag.ToString()));
                txtChequeType.Tag = dgvDetail[4, dgvDetail.SelectedRows[0].Index].Value.ToString();
                txtChequeType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeType(txtChequeType.Tag.ToString()));
                txtAccountNo.Text = dgvDetail[0, dgvDetail.SelectedRows[0].Index].Value.ToString();
                txtChequeNo.Text = dgvDetail[2, dgvDetail.SelectedRows[0].Index].Value.ToString();
                txtAmount.Text = dgvDetail[5, dgvDetail.SelectedRows[0].Index].Value.ToString();
                dtpChequeDate.Value = Convert.ToDateTime(dgvDetail[3, dgvDetail.SelectedRows[0].Index].Value);

                if (txtBankName.Tag != null)
                    txtBranchName.Enabled = true;

                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedRows[0].Index);
            }
        }

        #endregion

        #region KeyDown
        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBankName_DoubleClick(sender, e);
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranchName_DoubleClick(sender, e);
        }

        private void txtChequeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtChequeType_DoubleClick(sender, e);
        }
        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAccountNo_DoubleClick(sender, e);
        }

        #endregion     

        #region Asing glb SubTotal
        private void AsignDetails_SubTotals()
        {
            try
            {
                if (dgvDetail.Rows.Count > 0)
                {
                    glb_dtSubTotal.Rows.Clear();
                    dTotal = 0;
                    decimal dAmount = 0;
                    foreach (DataGridViewRow Row in dgvDetail.Rows)
                    {
                        string sAccCode = clsMethods_GL.getAccountCode_Bank(clsValidate.ValidateGridValue(dgvDetail, "AccountNo", Row.Index, "default"));
                        string sRemark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", Row.Index, "");
                        dAmount =  clsValidate.ValidateGridValue(dgvDetail, "Amount", Row.Index, decimal.Parse("0"));
                        glb_dtSubTotal.Rows.Add(glb_dtSubTotal.Rows.Count + 1, sAccCode, clsGenaralName.getName_AccountName(sAccCode), dAmount, "default", "default", "default", "default", clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque), "default", "default", "default", "default",sRemark);
                    }
                    dTotal += clsHelpMethods.getDisplayPrice(dAmount,txtExRate);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion       
    }
}