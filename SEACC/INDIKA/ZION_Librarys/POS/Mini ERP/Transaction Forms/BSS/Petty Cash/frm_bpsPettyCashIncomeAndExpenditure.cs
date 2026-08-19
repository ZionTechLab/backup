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
using System.IO;


namespace Digiteq
{
    public partial class frm_bpsPettyCash_IncomeAndExpenditure : MettroForm
    {

        #region Variable
        //to manage update and insert
        static bool IsUpdate = false;
        static bool IsUpdateDataGrid = false;
        string sExpenditure = "";
        string sIncome = "";

        //to keep form detail       
        public int iFormID;
        int iRow = 0;
        int iline = -1;

        public bool bNoAccess;
        public string gblPettyCashID;
        public string gblPettyCashName;
        public string gblPettyCashUserName;

        //for security handle
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        decimal dPettyBalace;

        #endregion

        #region Form Load
        public frm_bpsPettyCash_IncomeAndExpenditure()
        {
            iFormID = clsSecurity.getFormID(FormName.UpdatePettyCashAccounts);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsPettyCash_IncomeAndExpenditure_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Cash Book Entries", 2, iFormID);
            CusDataGridViewFormat();
            ClearFields();

            //RefreshGrid();
            CalculateBalace();
            txtPettyCashAccountID.Text = gblPettyCashID;
            txtPettyCashAccountName.Text = gblPettyCashName;
            tbl_bpsPettyCashAccount detail = tbl_bpsPettyCashAccount.Select(gblPettyCashID);
            txtAssignedUserID.Text = detail.AssignedUser_ID;
            txtFloatAmout.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.FloatAmount);

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIouName, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtExpendicherType, true);

            // Configurations
            lblPrettyType2.Text = clsConfig.sCostCenter2;
            lblCostCenter.Text = clsConfig.sCostCenter1;
            lblPrettyType3.Text = clsConfig.sCostCenter3;



        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (true)
            {
                if (true)
                {
                    if (clsSecurity.PermissionToWritePettyCash(gblPettyCashID, clsSecurity.UserIDLoged))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKey();

                            if (IsUpdate)  //update records
                            {

                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {

                                    string sIncomeType = "", sExpenditureType = "", sNarration = "", sSpentEmployee_Id = "", sSpentEmployee_Name = "", sVoucherNo = "", sIOUID = "", sCostsenter = ""
                                    , sCostsenter2 = "", sCostsenter3 = "", sCostsenter4 = "", sInvoiceNo = "";
                                    string[] constCenter = new string[5];
                                    decimal dAmount = 0;
                                    int iLine_No = 0;

                                    bool bCanceled, bExpenditure, bIncome;
                                    DateTime dDateCreated;

                                    dDateCreated = DateTime.Parse(dgvDetail["DateCreated", row.Index].Tag.ToString());

                                    sExpenditureType = clsValidate.ValidateGridTag(dgvDetail, "ExpenditureTag", row.Index, "default");
                                    sIncomeType = clsValidate.ValidateGridTag(dgvDetail, "IncomeTag", row.Index, "default");
                                    sNarration = clsValidate.ValidateGridValue(dgvDetail, "Narration", row.Index, "");
                                    sVoucherNo = clsValidate.ValidateGridValue(dgvDetail, "VoucherNo", row.Index, "");
                                    sSpentEmployee_Id = clsValidate.ValidateGridValue(dgvDetail, "User_Id", row.Index, "default");
                                    sSpentEmployee_Name = clsValidate.ValidateGridValue(dgvDetail, "User", row.Index, "");
                                    sIOUID = clsValidate.ValidateGridTag(dgvDetail, "IouID", row.Index, "default");
                                    sCostsenter = clsValidate.ValidateGridTag(dgvDetail, "CostCenter", row.Index, "default");
                                    sCostsenter2 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter2", row.Index, "default");
                                    sCostsenter3 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter3", row.Index, "default");
                                    sCostsenter4 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter4", row.Index, "default");
                                    sInvoiceNo = clsValidate.ValidateGridValue(dgvDetail, "InvoiceNo", row.Index, "");

                                    bCanceled = clsValidate.ValidateGridValue(dgvDetail, "IsCanceled", row.Index, false);
                                    bIncome = bool.Parse(dgvDetail["isIncome", row.Index].Value.ToString());
                                    bExpenditure = bool.Parse(dgvDetail["isExpenditure", row.Index].Value.ToString());

                                    iLine_No = clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0"));

                                    tbl_bpsPettyCashAccount_Transaction Transactiondetail = tbl_bpsPettyCashAccount_Transaction.Select(iLine_No, gblPettyCashID);
                                    if (Transactiondetail != null)
                                    {
                                    }
                                    else
                                    {
                                        if (bIncome)
                                            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Income", row.Index, decimal.Parse("0.00"));

                                        else if (bExpenditure)
                                            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Expendicher", row.Index, decimal.Parse("0.00"));

                                        //int iLineNo = -9999;
                                        //iLineNo = clsHelpMethods.GetMaxzimumLineNo_PettyCashTransaction(gblPettyCashID);
                                        tbl_bpsPettyCashAccount_Transaction Grid = new tbl_bpsPettyCashAccount_Transaction(iLine_No, gblPettyCashID, sExpenditureType, sIncomeType,
                                        dDateCreated, sNarration, sSpentEmployee_Id, sSpentEmployee_Name, sVoucherNo, sInvoiceNo, dAmount, sIOUID, sCostsenter, sCostsenter2, sCostsenter3, sCostsenter4, "default", clsSecurity.UserIDLoged,
                                        clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, bCanceled, false, bIncome, bExpenditure);
                                        Grid.Insert();
                                    }
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else  //insert records
                            {
                                #region insert
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {

                                    string sIncomeType = "", sExpenditureType = "", sNarration = "", sSpentEmployee_Id = "", sSpentEmployee_Name = "", sVoucherNo = "",
                                   sIOUID = "", sCostsenter = "", sCostsenter2 = "", sCostsenter3 = "", sCostsenter4 = "", sInvoiceNo = "";

                                    string[] constCenter = new string[5];
                                    decimal dAmount = 0;
                                    bool bCanceled, bExpenditure, bIncome;
                                    DateTime dDateCreated;
                                    int iLine_No = 0;

                                    dDateCreated = DateTime.Parse(dgvDetail["DateCreated", row.Index].Tag.ToString());

                                    sExpenditureType = clsValidate.ValidateGridTag(dgvDetail, "ExpenditureTag", row.Index, "default");
                                    sIncomeType = clsValidate.ValidateGridTag(dgvDetail, "IncomeTag", row.Index, "default");
                                    sNarration = clsValidate.ValidateGridValue(dgvDetail, "Narration", row.Index, "");
                                    sVoucherNo = clsValidate.ValidateGridValue(dgvDetail, "VoucherNo", row.Index, "");
                                    sSpentEmployee_Id = clsValidate.ValidateGridValue(dgvDetail, "User_Id", row.Index, "");
                                    sSpentEmployee_Name = clsValidate.ValidateGridValue(dgvDetail, "User", row.Index, "");
                                    sIOUID = clsValidate.ValidateGridTag(dgvDetail, "IouID", row.Index, "default");
                                    sCostsenter = clsValidate.ValidateGridTag(dgvDetail, "CostCenter", row.Index, "");
                                    sCostsenter2 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter2", row.Index, "default");
                                    sCostsenter3 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter3", row.Index, "default");
                                    sCostsenter4 = clsValidate.ValidateGridTag(dgvDetail, "clmCostCenter4", row.Index, "default");
                                    sInvoiceNo = clsValidate.ValidateGridValue(dgvDetail, "InvoiceNo", row.Index, "");

                                    bCanceled = clsValidate.ValidateGridValue(dgvDetail, "IsCanceled", row.Index, false);
                                    bIncome = bool.Parse(dgvDetail["isIncome", row.Index].Value.ToString());
                                    bExpenditure = bool.Parse(dgvDetail["isExpenditure", row.Index].Value.ToString());

                                    iLine_No = clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0"));
                                    //int iLineNo = -9999;
                                    //iLineNo = clsHelpMethods.GetMaxzimumLineNo_PettyCashTransaction(gblPettyCashID);

                                    if (bIncome)
                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Income", row.Index, decimal.Parse("0.00"));

                                    else if (bExpenditure)
                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Expendicher", row.Index, decimal.Parse("0.00"));

                                    tbl_bpsPettyCashAccount_Transaction Grid = new tbl_bpsPettyCashAccount_Transaction(iLine_No, gblPettyCashID, sExpenditureType, sIncomeType,
                                    dDateCreated, sNarration, sSpentEmployee_Id, sSpentEmployee_Name, sVoucherNo, sInvoiceNo, dAmount, sIOUID, sCostsenter, sCostsenter2, sCostsenter3, sCostsenter4, "default", clsSecurity.UserIDLoged,
                                    clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(),
                                    clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, bCanceled, false, bIncome, bExpenditure);
                                    Grid.Insert();
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            CalculateBalace();
                            //RefreshGrid();
                            if (dgvDetail.Rows.Count > 0)
                            {
                                dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                                dgvDetail.FirstDisplayedScrollingRowIndex = dgvDetail.Rows.Count - 1;
                            }
                        }
                    }
                    else //if no permission to write
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        #region Btn Delete
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToDeletePettyCash(gblPettyCashID, clsSecurity.UserIDLoged))
                {
                    ValidateEmptyForeignKey();
                    //delete one record
                    string strMessage = "";
                    Cursor = Cursors.WaitCursor;
                    if (iline >= 0)
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            tbl_bpsPettyCashAccount_Transaction oTransaction = tbl_bpsPettyCashAccount_Transaction.Select(iline, gblPettyCashID);
                            if (oTransaction != null)
                            {
                                if (oTransaction.ReimbRequest_ID == "default")
                                {
                                    //detail.IsDeleted = true;
                                    //detail.Delete();
                                    oTransaction.IsDeleted = true;
                                    oTransaction.Update();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearFields();
                                    RefreshGrid();
                                }
                                else
                                {
                                    MessageBox.Show("You can't delete This line as already reimbursed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //tbl_bpsPettyCashReimbursement remdetail = tbl_bpsPettyCashReimbursement.Select(detail.ReimbRequest_ID);
                                }
                            }
                        }
                        //else if (msgResult == DialogResult.No)
                        //{
                        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                    else
                    {
                        strMessage += "\n" + "Please select the record ";
                        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
                RefreshGrid();
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

        #region Btn Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //old
            //int iRow;
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    RefershGridAdd();
                }
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn IOU
        private void btnIOU_Click(object sender, EventArgs e)
        {
            frm_bpsPettyCashIOU detail = new frm_bpsPettyCashIOU();
            detail.gblPettyCash = gblPettyCashID;
            detail.ShowDialog();
            decimal IOUAmount = 0;
            List<tbl_bpsPettyCashAccount_IOU> IOUdetail = tbl_bpsPettyCashAccount_IOU.SelectAllByPettyCashAccount_ID(gblPettyCashID);
            foreach (tbl_bpsPettyCashAccount_IOU Idetail in IOUdetail)
            {
                IOUAmount = IOUAmount + Idetail.BalanceAmount;
            }
            txtIouTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(IOUAmount);
            txtCashInHand.Text = clsFormatter.FormatToCurrecyWithThousendSep(IOUAmount + dPettyBalace);
        }
        #endregion

        #region btn View All
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_NormalTextbox(txtFloatAmout, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSpentBy, true);

            txtIncomeType.Clear();
            txtAmount.Clear();
            txtExpendicherType.Clear();
            txtNaration.Clear();
            txtIouName.Clear();
            txtCostCenter.Clear();
            txtActivity.Clear();
            txtSuplier.Clear();
            txtInvoiceNo.Clear();
            txtSpentBy.Clear();

            txtCostCenter.Tag = null;
            txtIncomeType.Tag = null;
            txtExpendicherType.Tag = null;
            txtNaration.Text = null;
            txtIouName.Tag = null;
            txtActivity.Tag = null;
            txtSuplier.Tag = null;
            txtSpentBy.Tag = null;

            dgvDetail.Rows.Clear();
            iline = -1;
        }
        #endregion

        #region Clear Field Contact
        private void ClearFieldContact()
        {
            //set the flag and enble the id
            IsUpdateDataGrid = false;
            txtExpendicherType.Tag = null;
            txtIncomeType.Tag = null;
            txtIouName.Tag = null;
            txtCostCenter.Tag = null;
            txtSuplier.Tag = null;
            txtActivity.Tag = null;

            txtCostCenter.Clear();
            txtIncomeType.Clear();
            txtNaration.Clear();
            txtAmount.Clear();
            txtExpendicherType.Clear();
            txtSpentBy.Clear();
            txtVoucherNo.Clear();
            txtInvoiceNo.Clear();
            txtIouName.Clear();
            txtSuplier.Clear();
            txtActivity.Clear();
            dtpDate.Value = clsSecurity.getServerDateTime();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //configuration colom names

            dgvDetail.Columns["clmCostCenter2"].HeaderText = clsConfig.sCostCenter2;
            dgvDetail.Columns["clmCostCenter3"].HeaderText = clsConfig.sCostCenter3;
            dgvDetail.Columns["clmCostCenter4"].HeaderText = clsConfig.sCostCenter4;

            IsUpdate = true;
            int iRownew;
            dgvDetail.Rows.Clear();
            decimal dBalance = 0;

            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(gblPettyCashID);
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
            {
                dgvDetail.Rows.Add();
                iRownew = dgvDetail.Rows.Count - 1;

                if (detail.IsDeleted)
                {
                    DataGridViewRow row = dgvDetail.Rows[iRownew];
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }

                dgvDetail["DateCreated", iRownew].Value = detail.TransactionDate.ToShortDateString();
                dgvDetail["DateCreated", iRownew].Tag = detail.TransactionDate;
                dgvDetail["Narration", iRownew].Value = detail.Remark;
                dgvDetail["line_No", iRownew].Value = detail.Line_No;
                dgvDetail["IsCanceled", iRownew].Value = detail.IsDeleted;
                dgvDetail["User_Id", iRownew].Value = detail.SpentUserID;
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
                    if (!detail.IsDeleted)
                        dBalance = dBalance + detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);

                    dgvDetail["IouID", iRownew].Value = "";
                    dgvDetail["IouID", iRownew].Tag = "default";
                }
                else if (detail.IsExpenditure)
                {
                    dgvDetail["isIncome", iRownew].Value = detail.IsIncome;
                    dgvDetail["isExpenditure", iRownew].Value = detail.IsExpenditure;
                    dgvDetail["Type", iRownew].Value = clsGenaralName.getName_ExpenditureType(detail.PettyCashExpenditureType_ID);
                    dgvDetail["ExpenditureTag", iRownew].Tag = detail.PettyCashExpenditureType_ID;
                    dgvDetail["IncomeTag", iRownew].Tag = "default";
                    dgvDetail["Expendicher", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    if (!detail.IsDeleted)
                        dBalance = dBalance - detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);

                    tbl_bpsPettyCashAccount_IOU IOUdetails = tbl_bpsPettyCashAccount_IOU.Select(detail.IouAccount_ID);
                    if (IOUdetails != null)
                        dgvDetail["IouID", iRownew].Value = IOUdetails.Remark;
                    dgvDetail["IouID", iRownew].Tag = detail.IouAccount_ID;
                }
            }
            decimal IOUAmount = 0;
            List<tbl_bpsPettyCashAccount_IOU> IOUdetail = tbl_bpsPettyCashAccount_IOU.SelectAllByPettyCashAccount_ID(gblPettyCashID);
            foreach (tbl_bpsPettyCashAccount_IOU detail in IOUdetail)
            {
                IOUAmount = IOUAmount + detail.BalanceAmount;
            }
            txtBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
            txtIouTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(IOUAmount);
            txtCashInHand.Text = clsFormatter.FormatToCurrecyWithThousendSep(dBalance + IOUAmount);
            dPettyBalace = dBalance;

            #region Select Add Row
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = false;
                dgvDetail.FirstDisplayedScrollingRowIndex = dgvDetail.Rows.Count - 1;
            }
            #endregion
        }
        private void RefershGridAdd()
        {
            int iLineNo = 0;
            if (IsUpdateDataGrid)
            {
                iRow = int.Parse(txtRowNo1.Text.Trim());
                iLineNo = GetGridMaxLineNo();
            }
            else
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                iLineNo = GetGridMaxLineNo();

            }

            dgvDetail["DateCreated", iRow].Value = dtpDate.Text.Trim();
            dgvDetail["DateCreated", iRow].Tag = dtpDate.Value.ToString();
            dgvDetail["Narration", iRow].Value = txtNaration.Text.Trim();
            dgvDetail["VoucherNo", iRow].Value = txtVoucherNo.Text.Trim();
            dgvDetail["InvoiceNo", iRow].Value = txtInvoiceNo.Text.Trim();
            dgvDetail["line_No", iRow].Value = iLineNo;
            dgvDetail["IsCanceled", iRow].Value = false;

            //add to grid ..
            dgvDetail["clmCostCenter2", iRow].Value = txtSuplier.Text.Trim();
            dgvDetail["clmCostCenter2", iRow].Tag = txtSuplier.Tag;

            dgvDetail["clmCostCenter3", iRow].Value = txtActivity.Text.Trim();
            dgvDetail["clmCostCenter3", iRow].Tag = txtActivity.Tag;

            dgvDetail["clmCostCenter4", iRow].Value = "default";// TODO CHANGE THIS VALUE LATER ...
            dgvDetail["clmCostCenter4", iRow].Tag = "default";

            if (txtCostCenter.Tag != null)
            {
                dgvDetail["CostCenter", iRow].Value = txtCostCenter.Text.Trim();
                dgvDetail["CostCenter", iRow].Tag = txtCostCenter.Tag.ToString();
            }
            else
            {
                dgvDetail["CostCenter", iRow].Value = "";
                dgvDetail["CostCenter", iRow].Tag = "default";
            }

            if (rdoIncome.Checked)
            {
                #region Income
                decimal dIncome = 0;
                decimal dbalance = 0;
                dgvDetail["Type", iRow].Value = txtIncomeType.Text.Trim();
                dgvDetail["IncomeTag", iRow].Tag = txtIncomeType.Tag.ToString();
                dgvDetail["Income", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtAmount.Text.Trim()));
                dgvDetail["ExpenditureTag", iRow].Tag = "default";
                dgvDetail["isIncome", iRow].Value = "true";
                dgvDetail["isExpenditure", iRow].Value = "false";
                dgvDetail["User_Id", iRow].Value = txtSpentBy.Tag != null ? txtSpentBy.Tag.ToString() : "default";
                dgvDetail["User", iRow].Value = txtSpentBy.Text;
                dgvDetail["IouID", iRow].Value = "";
                dgvDetail["IouID", iRow].Tag = "default";

                if (iRow > 0)
                    dbalance = decimal.Parse(dgvDetail["Balance", iRow - 1].Value.ToString());
                else
                    dbalance = CalculateBalace();

                if (txtAmount.TextLength > 0)
                    dIncome = decimal.Parse(txtAmount.Text.Trim());

                dgvDetail["Balance", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance + dIncome);
                #endregion
            }
            else if (rdoExpenditure.Checked)
            {
                #region Expenditure
                decimal dIncome = 0;
                decimal dbalance = 0;

                dgvDetail["Type", iRow].Value = txtExpendicherType.Text.Trim();
                dgvDetail["ExpenditureTag", iRow].Tag = txtExpendicherType.Tag.ToString();
                dgvDetail["Expendicher", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtAmount.Text.Trim()));
                dgvDetail["IncomeTag", iRow].Tag = "default";
                dgvDetail["isIncome", iRow].Value = "false";
                dgvDetail["isExpenditure", iRow].Value = "true";
                dgvDetail["User_Id", iRow].Value = txtSpentBy.Tag != null ? txtSpentBy.Tag.ToString() : "default";
                dgvDetail["User", iRow].Value = txtSpentBy.Text;
                if (txtIouName.Tag != null)
                {
                    dgvDetail["IouID", iRow].Value = txtIouName.Text.Trim();
                    dgvDetail["IouID", iRow].Tag = txtIouName.Tag.ToString().Trim();
                }
                else
                {
                    dgvDetail["IouID", iRow].Value = "";
                    dgvDetail["IouID", iRow].Tag = "default";
                }

                if (iRow > 0)
                    dbalance = decimal.Parse(dgvDetail["Balance", iRow - 1].Value.ToString());
                else
                    dbalance = CalculateBalace();

                if (txtAmount.TextLength > 0)
                    dIncome = decimal.Parse(txtAmount.Text.Trim());
                dgvDetail["Balance", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dbalance - dIncome);
                #endregion
            }

            ClearFieldContact();

            #region Select Add Row
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                dgvDetail.FirstDisplayedScrollingRowIndex = dgvDetail.Rows.Count - 1;
            }
            #endregion
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sExpenditure = dgvDetail["ExpenditureTag", e.RowIndex].Tag.ToString();
                sIncome = dgvDetail["IncomeTag", e.RowIndex].Tag.ToString();
                iline = int.Parse(dgvDetail["line_No", e.RowIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region Event Double Click
        private void txtIncomeType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashIncomeType(ref txtIncomeType);
        }
        private void txtExpendicherType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashExpenditureTypeWithLevel(ref txtExpendicherType);
        }
        private void txtIouName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount_IOUByPettyCashID(ref txtIouName, gblPettyCashID);
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtCostCenter_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType(ref txtCostCenter, clsConfig.sCostCenter1);
        }
        private void txSpentBy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_MasterEmployee(ref txtSpentBy);
        }
        #endregion

        #region Key Down
        private void txtExpendicherType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashExpenditureTypeWithLevel(ref txtExpendicherType);
            }
        }
        private void txtIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashIncomeType(ref txtIncomeType);
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void txtIouName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPettyCashAccount_IOUByPettyCashID(ref txtIouName, gblPettyCashID);
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }


        private void txtSuplier_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType2(ref txtSuplier, clsConfig.sCostCenter2);
        }

        private void txtActivity_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType3(ref txtActivity, clsConfig.sCostCenter3);
        }

        private void txtSuplier_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCostCenter_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtActivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasteCost_CenterType3(ref txtActivity, clsConfig.sCostCenter3);
            }
        }

        private void txtSpentBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterEmployee(ref txtSpentBy);
            }
        }
        #endregion

        #region Key Press
        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtAmount.Text, e);

            if (((e.KeyChar > 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8))
            {
                txtAmount.BackColor = Color.White;
            }
        }
        #endregion

        #region Rdo Checked Changed
        private void rdoExpenditure_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExpenditure.Checked)
            {
                rdoIncome.Checked = false;
                txtExpendicherType.Enabled = true;
                txtIouName.Enabled = true;
                txtIncomeType.Enabled = false;
                txtIncomeType.Tag = null;
                txtIncomeType.Clear();

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIouName, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtExpendicherType, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIncomeType, false);
            }
        }

        private void rdoIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIncome.Checked)
            {
                rdoExpenditure.Checked = false;
                txtIncomeType.Enabled = true;
                txtExpendicherType.Enabled = false;
                txtIouName.Enabled = false;
                txtExpendicherType.Tag = null;
                txtIouName.Tag = null;
                txtExpendicherType.Clear();
                txtIouName.Clear();

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIouName, false);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtIncomeType, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtExpendicherType, false);
            }
        }
        #endregion

        #region Search Methods
        private void Search_ApprovedBy()
        {
            try
            {
                frmSetApproved login = new frmSetApproved();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetApproved.bChecked)
                {
                    bHasApproved = true;
                    glbApprovedDate = clsSecurity.getServerDateTime();
                    dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                    txtApprovedBy.Text = frmSetApproved.sApprovedUserName;
                    txtApprovedBy.Tag = frmSetApproved.sApprovedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                }
                else if (frmSetApproved.bReset)
                {
                    txtDateApprovedBy.Visible = true;
                    txtApprovedBy.Text = "";
                    txtApprovedBy.Tag = null;
                    bHasApproved = false;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                frmSetChecked login = new frmSetChecked();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetChecked.bChecked)
                {
                    bHasChecked = true;
                    glbCheckedDate = clsSecurity.getServerDateTime();
                    dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                    txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
                    txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                }
                else if (frmSetChecked.bReset)
                {
                    txtCheckedBy.Text = "";
                    txtCheckedBy.Tag = null;
                    bHasChecked = false;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAmount.Text.Trim().Length == 0)
            {
                strMessage += "\n" + " Amount ";
                bStatus = false;
            }
            if (txtNaration.Text.Trim().Length == 0)
            {
                strMessage += "\n" + " Naration ";
                bStatus = false;
            }
            if (txtIncomeType.Text.Trim().Length == 0 && txtExpendicherType.Text.Trim().Length == 0)
            {
                strMessage += "\n" + " Type ";
                bStatus = false;
            }
            if (txtSpentBy.Text.Trim().Length == 0 && txtIncomeType.Text.Trim().Length == 0)
            {
                strMessage += "\n" + " Spent By ";
                bStatus = false;
            }

            //if (txtSuplier.Text.Trim().Length == 0 && txtIncomeType.Text.Trim().Length == 0)
            //{
            //    strMessage += "\n" + " "+lblPrettyType2.Text+"  ";
            //    bStatus = false;
            //}
            //if (txtActivity.Text.Trim().Length == 0 && txtIncomeType.Text.Trim().Length == 0)
            //{
            //    strMessage += "\n" + " " + lblPrettyType3.Text + " By ";
            //    bStatus = false;
            //}

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

            try
            {
                if (decimal.Parse(txtAmount.Text) == 0)
                {
                    txtAmount.BackColor = Color.Red;
                    bStatus = false;
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);

            clsCommon.ValidateForeignKey(ref txtSuplier);
            clsCommon.ValidateForeignKey(ref txtCostCenter);
            clsCommon.ValidateForeignKey(ref txtActivity);
        }
        #endregion   

        #region Calculate Methoeds
        private int GetGridMaxLineNo()
        {
            int iLineNo = clsHelpMethods.GetMaxzimumLineNo_PettyCashTransaction(gblPettyCashID); ;
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0")) >= iLineNo)
                        iLineNo = 1 + clsValidate.ValidateGridValue(dgvDetail, "line_No", row.Index, int.Parse("0"));
                }
            }
            catch (Exception)
            {
                return -999;
            }
            return iLineNo;
        }

        private decimal CalculateBalace()
        {
            decimal dBalance = 0;
            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(gblPettyCashID);
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details.Where(r => !r.IsDeleted))
            {
                if (detail.IsIncome)
                {
                    dBalance = dBalance + detail.Amount;
                }
                else if (detail.IsExpenditure)
                {
                    dBalance = dBalance - detail.Amount;
                }
            }
            decimal IOUAmount = 0;
            List<tbl_bpsPettyCashAccount_IOU> IOUdetail = tbl_bpsPettyCashAccount_IOU.SelectAllByPettyCashAccount_ID(gblPettyCashID);
            foreach (tbl_bpsPettyCashAccount_IOU detail in IOUdetail)
            {
                IOUAmount = IOUAmount + detail.BalanceAmount;
            }
            txtBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
            txtIouTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(IOUAmount);
            txtCashInHand.Text = clsFormatter.FormatToCurrecyWithThousendSep(dBalance + IOUAmount);
            dPettyBalace = dBalance;

            return dBalance;
        }
        #endregion

    }
}
