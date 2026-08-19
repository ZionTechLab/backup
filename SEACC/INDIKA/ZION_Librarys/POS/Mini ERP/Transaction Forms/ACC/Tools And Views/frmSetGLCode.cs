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

namespace Digiteq
{
    public partial class frmSetGLCode : Form
    {
        public static string glbGLCode = "default";
        public static string glbGLName = "default";
        public decimal glbAmount = 0;
        public static bool bChanged;
        public static bool bCancel;
        public static int iTCatID = 0;
        public int iFormID;
        public int iSendFormId = 0;
        public decimal dExchangeRate = 0;

        #region DataTable
        public static DataTable glb_SubTotal;
        public static DataTable glb_NBT;
        public static DataTable glb_VAT;
        public static DataTable glb_SVAT;
        public static DataTable glb_GrandTotal;
        public static DataTable glb_Cash;
        public static DataTable glb_Cheque;
        public static DataTable glb_Other_Cr;
        public static DataTable glb_Suppler;
        public static DataTable glb_Customer;
        public static DataTable glb_CreditEntry;
        public static DataTable glb_DebitEntry;
        #endregion

        #region Form Load
        public frmSetGLCode()
        {
            bChanged = false;
            bCancel = false;
            InitializeComponent();
        }
        private void frmSetGLCode_Load(object sender, EventArgs e)
        {
            ClearFields();
            //FillDetails(glbGLCode);
            FillDetails();
            CusDataGridViewFormat();
        }
        #endregion

        #region Btn Change
        private void btnChange_Click(object sender, EventArgs e)
        {
            //tbl_accGLMaster detail = tbl_accGLMaster.Select(txtGLCode.Text.Trim());
            //if (detail != null)
            //    glbGLCode = detail.Gl_ID;
            //    glbGLName = clsCommon.GetForeignKeyValue(detail.GlName);
            AsignDetails_ForDataTable();

            this.Close();
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bCancel = true;
            this.Close();
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtGLCode, true);

            txtAcctCodeGlName.Clear();
            txtAcctCodeSubGLName.Clear();
            txtAcctCodeTypeName.Clear();
            txtAmount.Text = "0.00";
            txtGLName.Clear();
            txtGLCode.Clear();
            txtCostCenter1.Clear();
            txtCostCenter2.Clear();
            txtEmployes.Clear();
            txtCr.Clear();
            txtRemarks.Clear();

            if (txtGLCode.Enabled)
                txtGLCode.Focus();

            dExchangeRate = decimal.Parse(txtCurrencyRate.Text);
        }
        private void ClearFieldsSubAccGL()
        {
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGLCode, true);
            txtCostCenter1.Text = "0.00";
            //txtGLName.Clear();
            //txtGLCode.Clear();

            if (txtGLCode.Enabled)
            {
                txtGLCode.Focus();
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sGLCode)
        {
            try
            {
                if (sGLCode.Length > 0)
                {
                    tbl_accGLMaster detail = tbl_accGLMaster.Select(sGLCode);
                    if (detail != null && detail.Gl_ID != "default")
                    {
                        tbl_zAccGLMaster_AccountType oAccType = tbl_zAccGLMaster_AccountType.Select(detail.GlAccountType_ID);
                        if (oAccType != null)
                        {
                            tbl_zAccGLMaster_SubCatagory oAccSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(oAccType.GlSubCatagory_ID);
                            if (oAccSubCatagory != null)
                            {
                                txtGLCode.Text = detail.Gl_ID;
                                txtGLName.Text = clsCommon.GetForeignKeyValue(detail.GlName);

                                //Asign Other Values                       
                                txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(oAccSubCatagory.GlMainCatagory_ID);
                                txtAcctCodeSubGLName.Text = clsGenaralName.getName_GLSubCatagory(oAccType.GlSubCatagory_ID);
                                txtAcctCodeTypeName.Text = clsGenaralName.getName_GlAccountType1(detail.GlAccountType_ID);

                                txtAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(glbAmount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetails()
        {
            try
            {
                if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal))
                    FillDetail(glb_SubTotal, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT))
                    FillDetail(glb_NBT, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT))
                    FillDetail(glb_VAT, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT))
                    FillDetail(glb_SVAT, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal))
                    FillDetail(glb_GrandTotal, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cash))
                    FillDetail(glb_Cash, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque))
                    FillDetail(glb_Cheque, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr))
                    FillDetail(glb_Other_Cr, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier))
                    FillDetail(glb_Suppler, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Customer))
                    FillDetail(glb_Customer, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.CreditEntry))
                    FillDetail(glb_CreditEntry, iSendFormId);

                else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.DebitEntry))
                    FillDetail(glb_DebitEntry, iSendFormId);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsAcctType(string sGLAcctTypeID)
        {
            try
            {
                if (sGLAcctTypeID.Length > 0)
                {
                    tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(sGLAcctTypeID);

                    if (detail != null && detail.GlAccountType_ID != "default")
                    {
                        //txtGLCode.Text = detail.GlAccountType_ID;
                        //txtGLName.Text = clsCommon.GetForeignKeyValue(detail.GlAccountTypeName);

                        //Asign Other Values
                        tbl_zAccGLMaster_SubCatagory detailSub = tbl_zAccGLMaster_SubCatagory.Select(detail.GlSubCatagory_ID);
                        if (detailSub != null && detailSub.GlSubCatagory_ID != "default")
                        {
                            txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(detailSub.GlMainCatagory_ID);
                            txtAcctCodeSubGLName.Text = clsGenaralName.getName_GLSubCatagory(detail.GlSubCatagory_ID);
                            //txtAcctCodeTypeName.Text = clsGenaralName.getName_GlAccountType(detail.GlAccountType_ID);
                            //txtAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(glbAmount);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtCostCenter1_DoubleClick(object sender, EventArgs e)
        {
            Search_CostCenter1ID();
        }
        private void txtCostCenter2_DoubleClick(object sender, EventArgs e)
        {
            Search_CostCenter2ID();
        }
        private void txtEmployes_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterEmployee(ref txtEmployes);
        }
        private void txtCr_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtGLCode_DoubleClick(object sender, EventArgs e)
        {
            SearchAcctTypeToAccountCode();
        }
        private void txtAcctCodeTypeName_DoubleClick(object sender, EventArgs e)
        {
            SearchSubGLToAccountType();
        }
        #endregion

        #region Events KeyDown
        private void frmSetChecked_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCostCenter1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CostCenter1ID();
            }
        }
        private void txtCostCenter2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CostCenter2ID();
            }

        }
        private void txtEmployes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterEmployee(ref txtEmployes);
            }

        }
        private void txtCr_KeyDown(object sender, KeyEventArgs e)
        {
            Search_CustomerID();
        }
        #endregion

        #region Events KeyPress
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Search Methods
        private void SearchSubGLToAccountType()
        {
            try
            {
                clsSearch.Search_AccountType(txtAcctCodeTypeName, null, null, false);
                if (txtAcctCodeTypeName.Tag != null && txtAcctCodeTypeName.Tag.ToString().Trim().Length > 0)
                    FillDetailsAcctType(txtAcctCodeTypeName.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void SearchAcctTypeToAccountCode()
        {
            try
            {
                //if (txtAcctCodeTypeName.Tag != null && txtAcctCodeTypeName.Tag.ToString().Trim().Length > 0)
                //{
                //    clsSearch.Search_MasterAccountGLCode(ref txtGLCode, txtAcctCodeTypeName.Tag.ToString().Trim(), "");//2018-01-09 change parameters - janith
                //    if (txtGLCode.Tag != null && txtGLCode.Tag.ToString().Trim().Length > 0)
                //        FillDetails(txtGLCode.Tag.ToString().Trim());
                //}
                //else
                //{
                clsSearch.Search_MasterAccountGLCode(ref txtGLCode, txtAcctCodeTypeName.Tag != null ? txtAcctCodeTypeName.Tag.ToString() : "", "");//2018-01-09 change parameters - janith
                    if (txtGLCode.Tag != null && txtGLCode.Tag.ToString().Trim().Length > 0)
                        FillDetails(txtGLCode.Tag.ToString().Trim());
                //}

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CostCenter1ID()
        {
            try
            {
                clsSearch.Search_costCenter1(ref txtCostCenter1);
                //if (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Trim().Length > 0)
                //txtCostCenter1_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter1ID(txtCostCenter1.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CostCenter2ID()
        {
            try
            {
                clsSearch.Search_costCenter2(ref txtCostCenter2);
                //if (txtCostCenter2.Tag != null && txtCostCenter2.Tag.ToString().Trim().Length > 0)
                //txtCostCenter2_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter2ID(txtCostCenter2.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                clsSearch.Search_MasterCustomer(ref txtCr, false);

                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.passValue_CustomerMaster();
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //{
                //    if (frmSearchMaster.s_SearchText.Length > 0)
                //        txtCr.Text = frmSearchMaster.s_SearchText;
                //    if (frmSearchMaster.s_SearchID.Length > 0)
                //    {
                //        txtCr.Tag = frmSearchMaster.s_SearchID;
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Asing glb SubTotal
        private void AsignDetails_ForDataTable()
        {
            try
            {
                if (dgvDetail.Rows.Count > 0)
                {
                    if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal))
                        FillDataTableDetails(glb_SubTotal, TransactionCategory.SubTotal, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT))
                        FillDataTableDetails(glb_NBT, TransactionCategory.NBT, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT))
                        FillDataTableDetails(glb_VAT, TransactionCategory.VAT, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT))
                        FillDataTableDetails(glb_SVAT, TransactionCategory.SVAT, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal))
                        FillDataTableDetails(glb_GrandTotal, TransactionCategory.GrandTotal, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cash))
                        FillDataTableDetails(glb_Cash, TransactionCategory.Cash, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque))
                        FillDataTableDetails(glb_Cheque, TransactionCategory.Cheque, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr))
                        FillDataTableDetails(glb_Other_Cr, TransactionCategory.Other_Cr, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier))
                        FillDataTableDetails(glb_Suppler, TransactionCategory.Supplier, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.Customer))
                        FillDataTableDetails(glb_Customer, TransactionCategory.Customer, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.CreditEntry))
                        FillDataTableDetails(glb_CreditEntry, TransactionCategory.CreditEntry, iSendFormId);

                    else if (iTCatID == clsAutocode.getTransactionCategoryID(TransactionCategory.DebitEntry))
                        FillDataTableDetails(glb_DebitEntry, TransactionCategory.DebitEntry, iSendFormId);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        private void btnAddGL_Click(object sender, EventArgs e)
        {
            if (txtGLCode.Text.Trim() != "")
            {
                if (txtAcctCodeTypeName.Text.Trim() != "")
                {
                    if (decimal.Parse(txtAmount.Text.Trim()) > 0 && clsCommon.isCurrency(txtAmount.Text.Trim()))
                    {
                        int iRow;
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        dgvDetail["Line_No", iRow].Value = iRow + 1;
                        dgvDetail["accCode", iRow].Value = txtGLCode.Text.Trim();
                        dgvDetail["accName", iRow].Value = txtGLName.Text.Trim();

                        dgvDetail["subAcc1", iRow].Value = (txtCostCenter1.Text.Trim() != "") ? txtCostCenter1.Text.Trim() : "default";
                        dgvDetail["subAcc1", iRow].Tag = (txtCostCenter1.Text.Trim() != "") ? txtCostCenter1.Tag.ToString().Trim() : "default";

                        dgvDetail["subAcc2", iRow].Value = (txtCostCenter2.Text.Trim() != "") ? txtCostCenter2.Text.Trim() : "default";
                        dgvDetail["subAcc2", iRow].Tag = (txtCostCenter2.Text.Trim() != "") ? txtCostCenter2.Tag.ToString().Trim() : "default";

                        dgvDetail["employee", iRow].Value = (txtEmployes.Text.Trim() != "") ? txtEmployes.Text.Trim() : "default";
                        dgvDetail["employee", iRow].Tag = (txtEmployes.Text.Trim() != "") ? txtEmployes.Tag.ToString().Trim() : "default";
                        dgvDetail["otherCr", iRow].Value = (txtCr.Text.Trim() != "") ? txtCr.Text.Trim() : "default";
                        dgvDetail["amount", iRow].Value = decimal.Parse(txtAmount.Text.Trim()) * dExchangeRate;
                        dgvDetail["remarks", iRow].Value = txtRemarks.Text.Trim();
                        ClearFields();

                    }
                    else
                        MessageBox.Show("Please enter valid Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Invalid GL Code\nPlease Contact System Administrator...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please enter Accont Code", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region Btn Remove Contact
        private void btnRemoveGL_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count >= 1)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception) { }
        }
        #endregion


        private void FillDataTableDetails(DataTable glb_DataTable, TransactionCategory TransCatCode, int iSendFormId)
        {
            glb_DataTable.Rows.Clear();
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                string sAccCode = "", sAccName = "", sSubAcct1 = "", sSubAcct2 = "", sEmployee = "", sOtherCr = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sRemarks = "", sAPNID = "";
                int LineNo, iTransCatCode = 0;
                decimal dAmount;

                sAccCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "default");
                sAccName = clsValidate.ValidateGridValue(dgvDetail, "accName", row.Index, "");
                dAmount = clsValidate.ValidateGridValue(dgvDetail, "amount", row.Index, decimal.Parse("0"));
                sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "default");
                sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "default");
                sEmployee = clsValidate.ValidateGridValue(dgvDetail, "employee", row.Index, "default");
                sOtherCr = clsValidate.ValidateGridValue(dgvDetail, "otherCr", row.Index, "default");
                LineNo = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, 1);
                sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index, "default");
                sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index, "default");
                sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "remarks", row.Index, "");
                sAPNID = clsValidate.ValidateGridValue(dgvDetail, "APNID", row.Index, "");

                iTransCatCode = clsAutocode.getTransactionCategoryID(TransCatCode);
                //  if (TransCatCode == TransactionCategory.CreditEntry || TransCatCode == TransactionCategory.DebitEntry)
                // {
                if (iSendFormId == clsSecurity.getFormID(FormName.accPaymentVoucher))
                    glb_DataTable.Rows.Add(LineNo, sAccCode, sAccName, dAmount, sSubAcct1, sSubAcct2, sEmployee, sOtherCr, iTransCatCode, sSubAcct1_ID, sSubAcct2_ID, sEmployee_ID, sAPNID, sRemarks);
                else
                    glb_DataTable.Rows.Add(LineNo, sAccCode, sAccName, dAmount, sSubAcct1, sSubAcct2, sEmployee, sOtherCr, iTransCatCode, sSubAcct1_ID, sSubAcct2_ID, sEmployee_ID, sRemarks);
                //}
                //else
                //{
                //    if (iSendFormId == clsSecurity.getFormID(FormName.accPaymentVoucher))
                //        glb_DataTable.Rows.Add(LineNo, sAccCode, sAccName, dAmount, sSubAcct1, sSubAcct2, sEmployee, sOtherCr, iTransCatCode, sSubAcct1_ID, sSubAcct2_ID, sEmployee_ID, sAPNID, sRemarks);
                //    else
                //        glb_DataTable.Rows.Add(LineNo, sAccCode, sAccName, dAmount, sSubAcct1, sSubAcct2, sEmployee, sOtherCr, iTransCatCode, sSubAcct1_ID, sSubAcct2_ID, sEmployee_ID);
                //}                 
            }
        }

        private void FillDetail(DataTable glb_DataTable, int iSendFormId)
        {
            decimal dAmount = 0;
            if (glb_DataTable != null && glb_DataTable.Rows.Count > 0)
            {
                foreach (DataRow row in glb_DataTable.Rows)
                {
                    int iRow;
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    dgvDetail["Line_No", iRow].Value = row["Line_No"].ToString();
                    dgvDetail["accCode", iRow].Value = row["GLCode"].ToString();
                    dgvDetail["accName", iRow].Value = row["GLName"].ToString();
                    dgvDetail["amount", iRow].Value = row["GLAmount"].ToString();
                    dgvDetail["subAcc1", iRow].Value = row["SubAcct1"].ToString();
                    dgvDetail["subAcc2", iRow].Value = row["SubAcct2"].ToString();
                    dgvDetail["employee", iRow].Value = row["Employee"].ToString();
                    dgvDetail["otherCr", iRow].Value = row["OtherCr"].ToString();
                    dgvDetail["subAcc1", iRow].Tag = row["SubAcct1_ID"].ToString();
                    dgvDetail["subAcc2", iRow].Tag = row["SubAcct2_ID"].ToString();
                    dgvDetail["employee", iRow].Tag = row["Employee_ID"].ToString();
                    dgvDetail["employee", iRow].Tag = row["Employee_ID"].ToString();

                    if (iSendFormId == clsSecurity.getFormID(FormName.accPaymentVoucher))
                    {
                        dgvDetail["APNID", iRow].Value = row["APN_ID"].ToString();
                        dgvDetail["remarks", iRow].Value = row["remarks"].ToString();
                    }
                    dAmount += decimal.Parse(row["GLAmount"].ToString());

                    if (glb_DebitEntry == glb_DataTable || glb_CreditEntry == glb_DataTable)
                        dgvDetail["remarks", iRow].Value = row["Remarks"].ToString();
                }
            }

            //set txtAmount
            if ((glbAmount - dAmount) > 0)
                txtAmount.Text = (glbAmount - dAmount).ToString();
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sTransactionID = "", sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "subAcc1")
                {
                    sTransactionID = clsValidate.ValidateGridValue(dgvDetail, "accCode", e.RowIndex, "default");
                    if (e.RowIndex >= 0)
                    {
                        string sID = dgvDetail["accCode", e.RowIndex].Value.ToString();
                        if (sID.Length > 0)
                        {
                            Search_CostCenter1ID();
                            dgvDetail["subAcc1", e.RowIndex].Value = txtCostCenter1.Text.Trim();
                            dgvDetail["subAcc1", e.RowIndex].Tag = txtCostCenter1.Tag.ToString();
                            ClearFields();
                        }
                    }
                }
                else if (sColName == "subAcc2")
                {
                    sTransactionID = clsValidate.ValidateGridValue(dgvDetail, "accCode", e.RowIndex, "default");
                    if (e.RowIndex >= 0)
                    {
                        string sID = dgvDetail["accCode", e.RowIndex].Value.ToString();
                        if (sID.Length > 0)
                        {
                            Search_CostCenter2ID();
                            dgvDetail["subAcc2", e.RowIndex].Value = txtCostCenter2.Text.Trim();
                            dgvDetail["subAcc2", e.RowIndex].Tag = txtCostCenter2.Tag.ToString();
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }

    }
}
