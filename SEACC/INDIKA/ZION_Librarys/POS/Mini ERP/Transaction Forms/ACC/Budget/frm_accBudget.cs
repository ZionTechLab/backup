using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_accBudget : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        public int iFormID = 0;
        public bool bNoAccess = false;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        private BindingSource bsBudget = new BindingSource();
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public frm_accBudget()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Budget);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

        }
        private void frm_accBudget_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Budget Plan [BP]", 2, iFormID);
            ThemeColor = clsFormatter.colorAccounts;
            CusDataGridViewFormat();
            ClearFields();
            DataTable_Initilization();
        }
        #endregion

        #region btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        #endregion

        #region btn Delete
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        //change save method
        #region btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (CheckValidity())
                {
                    Cursor = Cursors.WaitCursor;
                    //ValidateEmptyForeignKey();
                    ValidateUpdateInsert();
                    if (IsUpdate)  //update records
                    {
                        #region Update
                        try
                        {
                            tbl_accBudget oldRecord = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                            if (oldRecord != null)
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsDeleted)
                                {
                                    //Write Audit Trial Log
                                    clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.BudgetPlan), oldRecord.FinancialYear_ID, "Budget Plan");

                                    #region Update Old Detail
                                    List<tbl_accBudget_detail> oOlddetail = tbl_accBudget_detail.SelectAllByFinancialYear_ID(oldRecord.FinancialYear_ID);
                                    foreach (tbl_accBudget_detail odetail in oOlddetail)
                                    {
                                        #region Variable
                                        bool bHasItem = false;
                                        decimal dAccJan = 0, dAccFeb = 0, dAccMar = 0, dAccApr = 0, dAccMay = 0, dAccJun = 0, dAccJul = 0, dAccAug = 0, dAccSep = 0, dAccOct = 0, dAccNov = 0, dAccDec = 0, dAccQuar1 = 0, dAccQuar2 = 0, dAccQuar3 = 0, dAccYear = 0;//dAccQuar4 = 0,
                                        string sAccCode = "", sAccName = "", sAccRev = "";
                                        #endregion

                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            sAccCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                            sAccName = clsValidate.ValidateGridValue(dgvDetail, "accName", row.Index, "");

                                            dAccJan = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accJan", row.Index, ""));
                                            dAccFeb = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accFeb", row.Index, ""));
                                            dAccMar = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accMar", row.Index, ""));
                                            dAccApr = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accApr", row.Index, ""));
                                            dAccMay = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accMay", row.Index, ""));
                                            dAccJun = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accJun", row.Index, ""));
                                            dAccJul = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accJul", row.Index, ""));
                                            dAccAug = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accAug", row.Index, ""));
                                            dAccSep = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accSep", row.Index, ""));
                                            dAccOct = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accOct", row.Index, ""));
                                            dAccNov = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accNov", row.Index, ""));
                                            dAccDec = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accDec", row.Index, ""));

                                            dAccQuar1 = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accQuarter1", row.Index, ""));
                                            dAccQuar2 = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accQuarter2", row.Index, ""));
                                            dAccQuar3 = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accQuarter3", row.Index, ""));
                                            dAccYear = decimal.Parse(clsValidate.ValidateGridValue(dgvDetail, "accYear", row.Index, ""));

                                            if (odetail.Gl_ID == sAccCode)
                                            {
                                                bHasItem = true;
                                                dgvDetail.Rows.RemoveAt(row.Index);
                                                break;
                                            }
                                        }
                                        if (bHasItem)
                                        {
                                            if (odetail.Value_Jan != dAccJan || odetail.Value_Feb != dAccFeb || odetail.Value_Mar != dAccMar || odetail.Value_Apr != dAccApr || odetail.Value_May != dAccMay || odetail.Value_Jun != dAccJun || odetail.Value_Jul != dAccJul || odetail.Value_Aug != dAccAug || odetail.Value_Sep != dAccSep || odetail.Value_Oct != dAccOct || odetail.Value_Nov != dAccNov || odetail.Value_Dec != dAccDec || odetail.Value_Quarter_1 != dAccQuar1 || odetail.Value_Quarter_2 != dAccQuar2 || odetail.Value_Quarter_3 != dAccQuar3 || odetail.Value_Year != dAccYear)
                                                odetail.RevisionCount += 1;

                                            odetail.Value_Jan = dAccJan;
                                            odetail.Value_Feb = dAccFeb;
                                            odetail.Value_Mar = dAccMar;
                                            odetail.Value_Apr = dAccApr;
                                            odetail.Value_May = dAccMay;
                                            odetail.Value_Jun = dAccJun;
                                            odetail.Value_Jul = dAccJul;
                                            odetail.Value_Aug = dAccAug;
                                            odetail.Value_Sep = dAccSep;
                                            odetail.Value_Oct = dAccOct;
                                            odetail.Value_Nov = dAccNov;
                                            odetail.Value_Dec = dAccDec;

                                            odetail.Value_Quarter_1 = dAccQuar1;
                                            odetail.Value_Quarter_2 = dAccQuar2;
                                            odetail.Value_Quarter_3 = dAccQuar3;
                                            odetail.Value_Year = dAccYear;

                                            odetail.Update();
                                        }
                                        else
                                        {
                                            //odetail.Delete();
                                        }
                                    }
                                    #endregion

                                    #region Insert Newly Added Data
                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                    {
                                        decimal dAccJan = 0, dAccFeb = 0, dAccMar = 0, dAccApr = 0, dAccMay = 0, dAccJun = 0, dAccJul = 0, dAccAug = 0, dAccSep = 0, dAccOct = 0, dAccNov = 0, dAccDec = 0, dAccQuar1 = 0, dAccQuar2 = 0, dAccQuar3 = 0, dAccYear = 0;
                                        string sAccCode = "", sAccName = "";

                                        sAccCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                        sAccName = clsValidate.ValidateGridValue(dgvDetail, "accName", row.Index, "");

                                        dAccJan = clsValidate.ValidateGridValue(dgvDetail, "accJan", row.Index, decimal.Parse("0.00"));
                                        dAccFeb = clsValidate.ValidateGridValue(dgvDetail, "accFeb", row.Index, decimal.Parse("0.00"));
                                        dAccMar = clsValidate.ValidateGridValue(dgvDetail, "accMar", row.Index, decimal.Parse("0.00"));
                                        dAccApr = clsValidate.ValidateGridValue(dgvDetail, "accApr", row.Index, decimal.Parse("0.00"));
                                        dAccMay = clsValidate.ValidateGridValue(dgvDetail, "accMay", row.Index, decimal.Parse("0.00"));
                                        dAccJun = clsValidate.ValidateGridValue(dgvDetail, "accJun", row.Index, decimal.Parse("0.00"));
                                        dAccJul = clsValidate.ValidateGridValue(dgvDetail, "accJul", row.Index, decimal.Parse("0.00"));
                                        dAccAug = clsValidate.ValidateGridValue(dgvDetail, "accAug", row.Index, decimal.Parse("0.00"));
                                        dAccSep = clsValidate.ValidateGridValue(dgvDetail, "accSep", row.Index, decimal.Parse("0.00"));
                                        dAccOct = clsValidate.ValidateGridValue(dgvDetail, "accOct", row.Index, decimal.Parse("0.00"));
                                        dAccNov = clsValidate.ValidateGridValue(dgvDetail, "accNov", row.Index, decimal.Parse("0.00"));
                                        dAccDec = clsValidate.ValidateGridValue(dgvDetail, "accDec", row.Index, decimal.Parse("0.00"));

                                        dAccQuar1 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter1", row.Index, decimal.Parse("0.00"));
                                        dAccQuar2 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter2", row.Index, decimal.Parse("0.00"));
                                        dAccQuar3 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter3", row.Index, decimal.Parse("0.00"));
                                        dAccYear = clsValidate.ValidateGridValue(dgvDetail, "accYear", row.Index, decimal.Parse("0.00"));

                                        if (sAccName.Length > 0)
                                        {
                                            tbl_accBudget_detail odetail = new tbl_accBudget_detail(txtFinYear.Tag.ToString(), sAccCode, 0, dAccJan, dAccFeb, dAccMar, dAccApr, dAccMay, dAccJun, dAccJul, dAccAug, dAccSep, dAccOct, dAccNov, dAccDec, dAccYear, dAccQuar1, dAccQuar2, dAccQuar3);
                                            odetail.Insert();
                                        }
                                    }
                                    #endregion

                                    #region Budget Header
                                    tbl_accBudget oBudget = new tbl_accBudget(txtFinYear.Tag.ToString(), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                        oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                                        clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                                        oldRecord.IsDeleted, oldRecord.IsLocked, rdoMonthlyBudgeted.Checked, rdoQuarterlyBudgeted.Checked, rdoAnnuallyBudgeted.Checked);
                                    oBudget.Update();
                                    #endregion
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            //Attachments.Insert(iFormID, oldRecord.FinancialYear_ID);
                            //Attachments.Remove(iFormID, oldRecord.FinancialYear_ID);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            SEACCException.Show(ex);
                            clsValidate.WriteErrorLog("", iFormID,ex);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Insert
                        try
                        {
                            #region Budget Header
                            tbl_accBudget oBudget = new tbl_accBudget(txtFinYear.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                        clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                        false, false, false, false, false, rdoMonthlyBudgeted.Checked, rdoQuarterlyBudgeted.Checked, rdoAnnuallyBudgeted.Checked);
                            oBudget.Insert();
                            #endregion

                            #region Budget Detail
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                decimal dAccJan = 0, dAccFeb = 0, dAccMar = 0, dAccApr = 0, dAccMay = 0, dAccJun = 0, dAccJul = 0,
                                    dAccAug = 0, dAccSep = 0, dAccOct = 0, dAccNov = 0, dAccDec = 0, dAccQuar1 = 0, dAccQuar2 = 0,
                                    dAccQuar3 = 0, dAccYear = 0;
                                string sAccCode = "", sAccName = "";
                                int iAccRev = 0;


                                sAccCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                sAccName = clsValidate.ValidateGridValue(dgvDetail, "accName", row.Index, "");
                                iAccRev = clsValidate.ValidateGridValue(dgvDetail, "accREV", row.Index, int.Parse("0"));

                                dAccJan = clsValidate.ValidateGridValue(dgvDetail, "accJan", row.Index, decimal.Parse("0.00"));
                                dAccFeb = clsValidate.ValidateGridValue(dgvDetail, "accFeb", row.Index, decimal.Parse("0.00"));
                                dAccMar = clsValidate.ValidateGridValue(dgvDetail, "accMar", row.Index, decimal.Parse("0.00"));
                                dAccApr = clsValidate.ValidateGridValue(dgvDetail, "accApr", row.Index, decimal.Parse("0.00"));
                                dAccMay = clsValidate.ValidateGridValue(dgvDetail, "accMay", row.Index, decimal.Parse("0.00"));
                                dAccJun = clsValidate.ValidateGridValue(dgvDetail, "accJun", row.Index, decimal.Parse("0.00"));
                                dAccJul = clsValidate.ValidateGridValue(dgvDetail, "accJul", row.Index, decimal.Parse("0.00"));
                                dAccAug = clsValidate.ValidateGridValue(dgvDetail, "accAug", row.Index, decimal.Parse("0.00"));
                                dAccSep = clsValidate.ValidateGridValue(dgvDetail, "accSep", row.Index, decimal.Parse("0.00"));
                                dAccOct = clsValidate.ValidateGridValue(dgvDetail, "accOct", row.Index, decimal.Parse("0.00"));
                                dAccNov = clsValidate.ValidateGridValue(dgvDetail, "accNov", row.Index, decimal.Parse("0.00"));
                                dAccDec = clsValidate.ValidateGridValue(dgvDetail, "accDec", row.Index, decimal.Parse("0.00"));

                                dAccQuar1 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter1", row.Index, decimal.Parse("0.00"));
                                dAccQuar2 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter2", row.Index, decimal.Parse("0.00"));
                                dAccQuar3 = clsValidate.ValidateGridValue(dgvDetail, "accQuarter3", row.Index, decimal.Parse("0.00"));
                                dAccYear = clsValidate.ValidateGridValue(dgvDetail, "accYear", row.Index, decimal.Parse("0.00"));

                                if (sAccName.Length > 0)
                                {
                                    tbl_accBudget_detail odetail = new tbl_accBudget_detail(txtFinYear.Tag.ToString(), sAccCode, iAccRev, dAccJan, dAccFeb, dAccMar, dAccApr, dAccMay, dAccJun, dAccJul, dAccAug, dAccSep, dAccOct, dAccNov, dAccDec, dAccYear, dAccQuar1, dAccQuar2, dAccQuar3);
                                    odetail.Insert();
                                }

                            }
                            #endregion

                            Attachments.Insert(txtFinYear.Text.ToString());

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            SEACCException.Show(ex);
                            clsValidate.WriteErrorLog("", iFormID,ex);
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                //ClearFilters();
                RefreshGrid();
                Cursor = Cursors.Default;
            }

        }
        #endregion

        #region btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Btn Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDetails();
        }
        #endregion

        #region Btn Filters
        private void btnFilters_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtFinYear, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAcctCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAccType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSubGLID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGLID, true);

            txtFinYear.Tag = null;
            txtAccType.Tag = null;
            txtAcctCode.Tag = null;
            txtSubGLID.Tag = null;

            txtFinYear.Clear();
            txtAcctCode.Clear();
            txtSubGLID.Clear();
            txtAccType.Clear();
            txtGLID.Clear();

            txtRemark.Clear();
            bHasApproved = false;
            bHasChecked = false;
          //  userDetailsColorChanges();

            chkShowSettle.Checked = false;

            dt.Rows.Clear();
            dt.DefaultView.RowFilter = string.Empty;
            rdoMonthlyBudgeted.Checked = true;

            Attachments.Clear();
        }
        private void ClearFilters()
        {
            txtAccType.Tag = null;
            txtAcctCode.Tag = null;
            txtSubGLID.Tag = null;
            txtGLID.Tag = null;

            txtAcctCode.Clear();
            txtSubGLID.Clear();
            txtAccType.Clear();
            txtGLID.Clear();

            dt.DefaultView.RowFilter = string.Empty;
        }
        #endregion

        #region DataTable Initialize
        private void DataTable_Initilization()
        {
            dt.Columns.Add("LineNo");
            dt.Columns.Add("accGLName");
            dt.Columns.Add("accSubGLName");
            dt.Columns.Add("accAccountType");
            dt.Columns.Add("accCode");
            dt.Columns.Add("accName");
            dt.Columns.Add("accREV");
            dt.Columns.Add("accApr");
            dt.Columns.Add("accMay");
            dt.Columns.Add("accJun");
            dt.Columns.Add("accJul");
            dt.Columns.Add("accAug");
            dt.Columns.Add("accSep");
            dt.Columns.Add("accOct");
            dt.Columns.Add("accNov");
            dt.Columns.Add("accDec");
            dt.Columns.Add("accJan");
            dt.Columns.Add("accFeb");
            dt.Columns.Add("accMar");
            dt.Columns.Add("accQuarter1");
            dt.Columns.Add("accQuarter2");
            dt.Columns.Add("accQuarter3");
            dt.Columns.Add("accYear");
            dt.Columns.Add("accAnnual");
            dgvDetail.DataSource = dt.DefaultView;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Trim().Length > 0 && txtFinYear.Tag.ToString().Trim() != "default")
                {
                    dt.Clear();

                    #region Variables
                    int iRow;
                    #endregion

                    //List<tbl_accGLMaster> details = new List<tbl_accGLMaster>();
                    //if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0 && txtAcctCode.Tag.ToString().Trim() != "default")
                    //    details.Add(tbl_accGLMaster.Select(txtAcctCode.Tag.ToString()));
                    //else if (txtAccType.Tag != null && txtAccType.Tag.ToString().Trim().Length > 0 && txtAccType.Tag.ToString().Trim() != "default")
                    //    details = tbl_accGLMaster.SelectAllByGlAccountType_ID(txtAccType.Tag.ToString());


                    foreach (tbl_accGLMaster detail in tbl_accGLMaster.SelectAll().Where(p => p.Gl_ID != "default" && !p.IsDeleted))
                    {
                        tbl_zAccGLMaster_AccountType oAccountType = tbl_zAccGLMaster_AccountType.Select(detail.GlAccountType_ID);
                        if (oAccountType != null)
                        {
                            tbl_zAccGLMaster_SubCatagory oAccountSubType = tbl_zAccGLMaster_SubCatagory.Select(oAccountType.GlSubCatagory_ID);
                            if (oAccountSubType != null)
                            {
                                decimal dAnnual = 0, dJan = 0, dFeb = 0, dMar = 0, dApr = 0, dMay = 0, dJun = 0, dJul = 0, dAug = 0, dSep = 0, dOct = 0, dNov = 0, dDec = 0;
                                decimal dQuater1 = 0, dQuater2 = 0, dQuater = 0, dYear = 0;

                                #region Selected Filters
                                //if (txtSubGLID.Tag != null && txtSubGLID.Tag.ToString().Trim().Length > 0 && txtSubGLID.Tag.ToString().Trim() != "default")
                                //    if (oAccountType.GlSubCatagory_ID != txtSubGLID.Tag.ToString())
                                //        continue;
                                //if (txtGLID.Tag != null && txtGLID.Tag.ToString().Trim().Length > 0 && txtGLID.Tag.ToString().Trim() != "default")
                                //    if (oAccountSubType.GlMainCatagory_ID != txtGLID.Tag.ToString())
                                //        continue;
                                #endregion

                                tbl_accBudget oBudget = tbl_accBudget.Select(txtFinYear.Tag.ToString().Trim());
                                if (oBudget != null && oBudget.FinancialYear_ID != "default")
                                {
                                    tbl_accBudget_detail oBudgetDetail = tbl_accBudget_detail.Select(oBudget.FinancialYear_ID, detail.Gl_ID);
                                    if (oBudgetDetail != null)
                                    {
                                        dJan = oBudgetDetail.Value_Jan;
                                        dFeb = oBudgetDetail.Value_Feb;
                                        dMar = oBudgetDetail.Value_Mar;
                                        dApr = oBudgetDetail.Value_Apr;
                                        dMay = oBudgetDetail.Value_May;
                                        dJun = oBudgetDetail.Value_Jun;
                                        dJul = oBudgetDetail.Value_Jul;
                                        dAug = oBudgetDetail.Value_Aug;
                                        dSep = oBudgetDetail.Value_Sep;
                                        dOct = oBudgetDetail.Value_Oct;
                                        dNov = oBudgetDetail.Value_Nov;
                                        dDec = oBudgetDetail.Value_Dec;

                                        dAnnual = dJan + dFeb + dMar + dApr + dMay + dJun + dJul + dAug + dSep + dOct + dNov + dDec;
                                    }
                                }

                                iRow = dt.Rows.Count - 1;
                                string sGLSubCat = clsGenaralName.getName_GLSubCatagoryByAccountTypeID(detail.GlAccountType_ID);

                                Fill_Datagrid(iRow, clsGenaralName.getID_GLMainCatagoryBySubGLID(sGLSubCat), sGLSubCat, detail.GlAccountType_ID,
                                    detail.Gl_ID, detail.GlName, 0, dJan, dFeb, dMar, dApr, dMay, dJun, dJul, dAug, dSep, dOct, dNov, dDec, 0, 0, 0, 0, dAnnual);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails()
        {
            //try
            //{
            //    dt.Clear();

            //    int iRow;
            //    bool bIsUpdate = false;
            //    decimal dAnnual = 0;
            //    List<tbl_accGLMaster> details = new List<tbl_accGLMaster>();

            //    if (txtFinYear.Tag != null && txtFinYear.Tag.ToString().Trim().Length > 0 && txtFinYear.Tag.ToString().Trim() != "default")
            //    {
            //        #region existing record
            //        tbl_accBudget oBudget = tbl_accBudget.Select(txtFinYear.Tag.ToString().Trim());
            //        if (oBudget != null && oBudget.FinancialYear_ID != "default")
            //        {
            //            bIsUpdate = true;
            //            foreach (tbl_accBudget_detail oBudgetDetail in tbl_accBudget_detail.SelectAllByFinancialYear_ID(oBudget.FinancialYear_ID))
            //            {
            //                tbl_accGLMaster oAccount = tbl_accGLMaster.Select(oBudgetDetail.Gl_ID);
            //                if (oAccount != null && oAccount.Gl_ID != "default")
            //                {
            //                    tbl_zAccGLMaster_AccountType oAccountType = tbl_zAccGLMaster_AccountType.Select(oAccount.GlAccountType_ID);
            //                    if (oAccountType != null)
            //                    {
            //                        tbl_zAccGLMaster_SubCatagory oAccountSubType = tbl_zAccGLMaster_SubCatagory.Select(oAccountType.GlSubCatagory_ID);
            //                        if (oAccount != null)
            //                        {
            //                            #region Filters
            //                            //if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0 && txtAcctCode.Tag.ToString().Trim() != "default")
            //                            //{
            //                            //    if (oAccount.Gl_ID != txtAcctCode.Tag.ToString().Trim())
            //                            //        continue;
            //                            //}
            //                            //else if (txtAccType.Tag != null && txtAccType.Tag.ToString().Trim().Length > 0 && txtAccType.Tag.ToString().Trim() != "default")
            //                            //{
            //                            //    if (oAccount.GlAccountType_ID != txtAccType.Tag.ToString().Trim())
            //                            //        continue;
            //                            //}
            //                            //else if (txtSubGLID.Tag != null && txtSubGLID.Tag.ToString().Trim().Length > 0 && txtSubGLID.Tag.ToString().Trim() != "default")
            //                            //{
            //                            //    if (oAccountType.GlSubCatagory_ID != txtSubGLID.Tag.ToString().Trim())
            //                            //        continue;
            //                            //}
            //                            //else if (txtGLID.Tag != null && txtGLID.Tag.ToString().Trim().Length > 0 && txtGLID.Tag.ToString().Trim() != "default")
            //                            //{
            //                            //    if (oAccountSubType.GlMainCatagory_ID != txtGLID.Tag.ToString().Trim())
            //                            //        continue;
            //                            //}
            //                            //if (!chkShowSettle.Checked)
            //                            //{
            //                            //    if (oBudgetDetail.Value_Jan == 0 && oBudgetDetail.Value_Feb == 0 && oBudgetDetail.Value_Mar == 0 && oBudgetDetail.Value_Apr == 0 && oBudgetDetail.Value_May == 0 && oBudgetDetail.Value_Jun == 0 && oBudgetDetail.Value_Jul == 0 && oBudgetDetail.Value_Aug == 0 && oBudgetDetail.Value_Sep == 0 && oBudgetDetail.Value_Oct == 0 && oBudgetDetail.Value_Nov == 0 && oBudgetDetail.Value_Dec == 0 && oBudgetDetail.Value_Quarter_1 == 0 && oBudgetDetail.Value_Quarter_2 == 0 && oBudgetDetail.Value_Quarter_3 == 0 && oBudgetDetail.Value_Year == 0)
            //                            //        continue;
            //                            //}
            //                            #endregion

            //                            dAnnual = oBudgetDetail.Value_Apr + oBudgetDetail.Value_Mar + oBudgetDetail.Value_Jun + oBudgetDetail.Value_Jul +
            //                                oBudgetDetail.Value_Aug + oBudgetDetail.Value_Sep + oBudgetDetail.Value_Oct + oBudgetDetail.Value_Nov + 
            //                                oBudgetDetail.Value_Dec + oBudgetDetail.Value_Jan + oBudgetDetail.Value_Feb + oBudgetDetail.Value_Mar;

            //                            //dgvDetail.Rows.Add();
            //                            iRow = dt.Rows.Count - 1;

            //                            Fill_Datagrid(iRow, oAccountSubType.GlMainCatagory_ID, oAccountSubType.GlSubCatagory_ID, oAccountType.GlAccountType_ID, oBudgetDetail.Gl_ID, clsGenaralName.getName_AccountName(oBudgetDetail.Gl_ID), 
            //                                oBudgetDetail.RevisionCount, oBudgetDetail.Value_Jan, oBudgetDetail.Value_Feb, oBudgetDetail.Value_Mar, 
            //                                oBudgetDetail.Value_Apr, oBudgetDetail.Value_May, oBudgetDetail.Value_Jun, oBudgetDetail.Value_Jul, 
            //                                oBudgetDetail.Value_Aug, oBudgetDetail.Value_Sep, oBudgetDetail.Value_Oct, oBudgetDetail.Value_Nov, 
            //                                oBudgetDetail.Value_Dec, oBudgetDetail.Value_Quarter_1, oBudgetDetail.Value_Quarter_2, 
            //                                oBudgetDetail.Value_Quarter_3, oBudgetDetail.Value_Year, dAnnual);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        #endregion
            //    }

            //    if (!bIsUpdate)
            //    {
            //        #region new record
            //        if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0 && txtAcctCode.Tag.ToString().Trim() != "default")
            //        {
            //            tbl_accGLMaster oAccount = tbl_accGLMaster.Select(txtAcctCode.Tag.ToString().Trim());
            //            details.Add(tbl_accGLMaster.Select(txtAcctCode.Tag.ToString()));
            //        }
            //        else if (txtAccType.Tag != null && txtAccType.Tag.ToString().Trim().Length > 0 && txtAccType.Tag.ToString().Trim() != "default")
            //            details = tbl_accGLMaster.SelectAllByGlAccountType_ID(txtAccType.Tag.ToString());

            //        //else if (txtSubGLID.Tag != null && txtSubGLID.Tag.ToString().Trim().Length > 0 && txtSubGLID.Tag.ToString().Trim() != "default")
            //        //    details = tbl_accGLMaster.SelectAllByGlSubCatagory_ID(txtSubGLID.Tag.ToString());
            //        //else if (txtGLID.Tag != null && txtGLID.Tag.ToString().Trim().Length > 0 && txtGLID.Tag.ToString().Trim() != "default")
            //        //    details = tbl_accGLMaster.SelectAllByGlMainCatagory_ID(txtGLID.Tag.ToString());

            //        else
            //            details = tbl_accGLMaster.SelectAll().Where(p => p.Gl_ID != "default" && !p.IsDeleted).ToList();

            //        foreach (tbl_accGLMaster detail in details)
            //        {
            //            iRow = dt.Rows.Count - 1;
            //            //dgvDetail.Rows.Add();
            //            string sGLSubCat = clsGenaralName.getName_GLSubCatagoryByAccountTypeID(detail.GlAccountType_ID);

            //            Fill_Datagrid(iRow, clsGenaralName.getName_GLMainCatagoryBySubGLID(sGLSubCat), sGLSubCat, detail.GlAccountType_ID, 
            //                detail.Gl_ID, detail.GlName, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //        }
            //        #endregion
            //    }

            //    //Attachments.FillAttachments(iFormID, sID);

            //}
            //catch (Exception ex)
            //{
            //    SEACCException.Show(ex);
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //}
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string GLName, string SubGLName, string AccountType, string AccountCode, string AccountName, int RevNo, decimal Jan, decimal Feb, decimal Mar, decimal Apr, decimal May, decimal Jun, decimal Jul, decimal Aug, decimal Sep, decimal Oct, decimal Nov, decimal Dec, decimal Quarter1, decimal Quarter2, decimal Quarter3, decimal Year, decimal Annual)
        {
            try
            {
                //foreach (DataRow row in dt.Rows)
                //{
                //    string sAccountCode = "";
                //    int index = dt.Rows.IndexOf(row);
                //    sAccountCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", index, "default");
                //    if (AccountCode == sAccountCode)
                //    {
                //        dgvDetail.Rows.RemoveAt(iRow);
                //        iRow = index;
                //    }
                //}

                dt.Rows.Add(iRow + 1, GLName, SubGLName, AccountType, AccountCode, AccountName,
                    clsFormatter.FormatToNumberNoDecimal(RevNo),
                    clsFormatter.FormatDecimalPlaces_Price(Apr),
                    clsFormatter.FormatDecimalPlaces_Price(May),
                    clsFormatter.FormatDecimalPlaces_Price(Jun),
                    clsFormatter.FormatDecimalPlaces_Price(Jul),
                    clsFormatter.FormatDecimalPlaces_Price(Aug),
                    clsFormatter.FormatDecimalPlaces_Price(Sep),
                    clsFormatter.FormatDecimalPlaces_Price(Oct),
                    clsFormatter.FormatDecimalPlaces_Price(Nov),
                    clsFormatter.FormatDecimalPlaces_Price(Dec),
                    clsFormatter.FormatDecimalPlaces_Price(Jan),
                    clsFormatter.FormatDecimalPlaces_Price(Feb),
                    clsFormatter.FormatDecimalPlaces_Price(Mar),
                    clsFormatter.FormatDecimalPlaces_Price(Quarter1),
                    clsFormatter.FormatDecimalPlaces_Price(Quarter2),
                    clsFormatter.FormatDecimalPlaces_Price(Quarter3),
                    clsFormatter.FormatDecimalPlaces_Price(Year),
                    clsFormatter.FormatDecimalPlaces_Price(Annual));

                //dgvDetail["LineNo", iRow].Value = iRow + 1;
                //dgvDetail["accGLName", iRow].Value = GLName;
                //dgvDetail["accSubGLName", iRow].Value = SubGLName;
                //dgvDetail["accAccountType", iRow].Value = AccountType;
                //dgvDetail["accCode", iRow].Value = AccountCode;
                //dgvDetail["accName", iRow].Value = AccountName;
                //dgvDetail["accRev", iRow].Value = clsFormatter.FormatToNumberNoDecimal(RevNo);
                //dgvDetail["accJan", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Jan);
                //dgvDetail["accFeb", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Feb);
                //dgvDetail["accMar", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Mar);
                //dgvDetail["accApr", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Apr);
                //dgvDetail["accMay", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(May);
                //dgvDetail["accJun", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Jun);
                //dgvDetail["accJul", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Jul);
                //dgvDetail["accAug", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Aug);
                //dgvDetail["accSep", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Sep);
                //dgvDetail["accOct", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Oct);
                //dgvDetail["accNov", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Nov);
                //dgvDetail["accDec", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Dec);
                //dgvDetail["accQuarter1", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Quarter1);
                //dgvDetail["accQuarter2", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Quarter2);
                //dgvDetail["accQuarter3", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Quarter3);
                //dgvDetail["accYear", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Year);
                //dgvDetail["accAnnual", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(Annual);
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
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (CheckValidation_FinancialYear())
                    bStatus = true;

            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool isValid = false;
            if (true)
            {
                isValid = true;
            }
            return isValid;
        }
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtGLID);
            clsCommon.ValidateForeignKey(ref txtSubGLID);
            clsCommon.ValidateForeignKey(ref txtFinYear);
            clsCommon.ValidateForeignKey(ref txtAcctCode);
            clsCommon.ValidateForeignKey(ref txtAccType);
        }
        private void ValidateUpdateInsert()
        {
            tbl_accBudget oBudget = tbl_accBudget.Select(txtFinYear.Tag.ToString());
            if (oBudget != null)
                IsUpdate = true;
            else
                IsUpdate = false;
        }
        private bool CheckValidation_FinancialYear()
        {
            bool bStatus = true;

            tbl_accFinancialYearMaster oFinYear = tbl_accFinancialYearMaster.Select(txtFinYear.Tag.ToString());
            if (oFinYear.StatusID == 3)
            {
                bStatus = false;
            }

            if (!bStatus)
                MessageBox.Show("This financial year already closed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion

        #region  Events Key Down
        private void txtGLID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtGLID_DoubleClick(sender, e);
        }
        private void txtSubGLID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSubGLID_DoubleClick(sender, e);
        }
        private void txtAccType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAccType_DoubleClick(sender, e);
        }
        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAcctCode_DoubleClick(sender, e);
        }
        private void txtFinYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_FinacialYearID();
            }
        }
        #endregion

        #region Events Double Click
        private void txtGLID_DoubleClick(object sender, EventArgs e)
        {
            Search_GLIDCode();
        }
        private void txtSubGLID_DoubleClick(object sender, EventArgs e)
        {
            Search_SubGLIDCode();
        }
        private void txtAccType_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountTypeCode();
        }
        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountCode();
        }
        private void txtFinYear_DoubleClick(object sender, EventArgs e)
        {
            Search_FinacialYearID();

        }
        #endregion

        #region Events data Grid
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                decimal dAnnual = 0;
                decimal dApr = decimal.Parse(dgvDetail["accApr", e.RowIndex].Value.ToString());
                decimal dMay = decimal.Parse(dgvDetail["accMay", e.RowIndex].Value.ToString());
                decimal dJun = decimal.Parse(dgvDetail["accJun", e.RowIndex].Value.ToString());
                decimal dJul = decimal.Parse(dgvDetail["accJul", e.RowIndex].Value.ToString());
                decimal dAug = decimal.Parse(dgvDetail["accAug", e.RowIndex].Value.ToString());
                decimal dSep = decimal.Parse(dgvDetail["accSep", e.RowIndex].Value.ToString());
                decimal dOct = decimal.Parse(dgvDetail["accOct", e.RowIndex].Value.ToString());
                decimal dNov = decimal.Parse(dgvDetail["accNov", e.RowIndex].Value.ToString());
                decimal dDec = decimal.Parse(dgvDetail["accDec", e.RowIndex].Value.ToString());
                decimal dJan = decimal.Parse(dgvDetail["accJan", e.RowIndex].Value.ToString());
                decimal dFeb = decimal.Parse(dgvDetail["accFeb", e.RowIndex].Value.ToString());
                decimal dMar = decimal.Parse(dgvDetail["accMar", e.RowIndex].Value.ToString());

                #region Add Column Amount
                switch (sColName)
                {
                    case "accApr":
                        dgvDetail["accApr", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dApr);
                        break;
                    case "accMay":
                        dgvDetail["accMay", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dMay);
                        break;
                    case "accJun":
                        dgvDetail["accJun", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dJun);
                        break;
                    case "accJul":
                        dgvDetail["accJul", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dJul);
                        break;
                    case "accAug":
                        dgvDetail["accAug", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAug);
                        break;
                    case "accSep":
                        dgvDetail["accSep", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dSep);
                        break;
                    case "accOct":
                        dgvDetail["accOct", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dOct);
                        break;
                    case "accNov":
                        dgvDetail["accNov", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dNov);
                        break;
                    case "accDec":
                        dgvDetail["accDec", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDec);
                        break;
                    case "accJan":
                        dgvDetail["accJan", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dJan);
                        break;
                    case "accFeb":
                        dgvDetail["accFeb", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dFeb);
                        break;
                    case "accMar":
                        dgvDetail["accMar", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dMar);
                        break;
                }
                dAnnual = dApr + dMay + dJun + dJul + dAug + dSep + dOct + dNov + dDec + dJan + dFeb + dMar;//calculate annual total
                dgvDetail["accAnnual", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAnnual);
                #endregion
            }
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (!clsCommon.isCurrency(e.Value.ToString()))
                {
                    switch (sColName)
                    {
                        case "accApr":
                            dgvDetail["accApr", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accMay":
                            dgvDetail["accMay", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accJun":
                            dgvDetail["accJun", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accJul":
                            dgvDetail["accJul", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accAug":
                            dgvDetail["accAug", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accSep":
                            dgvDetail["accSep", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accOct":
                            dgvDetail["accOct", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accNov":
                            dgvDetail["accNov", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accDec":
                            dgvDetail["accDec", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accJan":
                            dgvDetail["accJan", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accFeb":
                            dgvDetail["accFeb", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                        case "accMar":
                            dgvDetail["accMar", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            break;
                    }
                }
                
            }
            catch (Exception) { }
        }
        #endregion

        #region Events Checked Changed
        private void rdoMonthlyBudgeted_CheckedChanged(object sender, EventArgs e)
        {

            dgvDetail.Columns["accJan"].Visible = true;
            dgvDetail.Columns["accFeb"].Visible = true;
            dgvDetail.Columns["accMar"].Visible = true;
            dgvDetail.Columns["accApr"].Visible = true;
            dgvDetail.Columns["accMay"].Visible = true;
            dgvDetail.Columns["accJun"].Visible = true;
            dgvDetail.Columns["accJul"].Visible = true;
            dgvDetail.Columns["accAug"].Visible = true;
            dgvDetail.Columns["accSep"].Visible = true;
            dgvDetail.Columns["accOct"].Visible = true;
            dgvDetail.Columns["accNov"].Visible = true;
            dgvDetail.Columns["accDec"].Visible = true;


            dgvDetail.Columns["accQuarter1"].Visible = false;
            dgvDetail.Columns["accQuarter2"].Visible = false;
            dgvDetail.Columns["accQuarter3"].Visible = false;

            dgvDetail.Columns["accYear"].Visible = false;


            dgvDetail.Columns["accName"].Width = 230;
            dgvDetail.Columns["accREV"].Width = 70;
            dgvDetail.Columns["accYear"].Width = 100;
        }
        private void rdoQuarterlyBudgeted_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetail.Columns["accJan"].Visible = false;
            dgvDetail.Columns["accFeb"].Visible = false;
            dgvDetail.Columns["accMar"].Visible = false;
            dgvDetail.Columns["accApr"].Visible = false;
            dgvDetail.Columns["accMay"].Visible = false;
            dgvDetail.Columns["accJun"].Visible = false;
            dgvDetail.Columns["accJul"].Visible = false;
            dgvDetail.Columns["accAug"].Visible = false;
            dgvDetail.Columns["accSep"].Visible = false;
            dgvDetail.Columns["accOct"].Visible = false;
            dgvDetail.Columns["accNov"].Visible = false;
            dgvDetail.Columns["accDec"].Visible = false;


            dgvDetail.Columns["accQuarter1"].Visible = true;
            dgvDetail.Columns["accQuarter2"].Visible = true;
            dgvDetail.Columns["accQuarter3"].Visible = true;

            dgvDetail.Columns["accYear"].Visible = false;


            dgvDetail.Columns["accName"].Width = 318;
            dgvDetail.Columns["accREV"].Width = 70;
            dgvDetail.Columns["accYear"].Width = 200;

            dgvDetail.Columns["accQuarter1"].Width = 91;
            dgvDetail.Columns["accQuarter2"].Width = 91;
            dgvDetail.Columns["accQuarter3"].Width = 91;

        }
        private void rdoAnnuallyBudgeted_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetail.Columns["accJan"].Visible = false;
            dgvDetail.Columns["accFeb"].Visible = false;
            dgvDetail.Columns["accMar"].Visible = false;
            dgvDetail.Columns["accApr"].Visible = false;
            dgvDetail.Columns["accMay"].Visible = false;
            dgvDetail.Columns["accJun"].Visible = false;
            dgvDetail.Columns["accJul"].Visible = false;
            dgvDetail.Columns["accAug"].Visible = false;
            dgvDetail.Columns["accSep"].Visible = false;
            dgvDetail.Columns["accOct"].Visible = false;
            dgvDetail.Columns["accNov"].Visible = false;
            dgvDetail.Columns["accDec"].Visible = false;


            dgvDetail.Columns["accQuarter1"].Visible = false;
            dgvDetail.Columns["accQuarter2"].Visible = false;
            dgvDetail.Columns["accQuarter3"].Visible = false;

            dgvDetail.Columns["accYear"].Visible = true;

            dgvDetail.Columns["accName"].Width = 442;
            dgvDetail.Columns["accREV"].Width = 70;
            dgvDetail.Columns["accYear"].Width = 150;



        }
        #endregion

        #region Search Methods
        private void Search_GLIDCode()
        {
            try
            {
                txtAcctCode.Clear();
                txtSubGLID.Clear();
                txtAccType.Clear();

                txtAcctCode.Tag = null;
                txtSubGLID.Tag = null;
                txtAccType.Tag = null;

                clsSearch.Search_GLCode(txtGLID, null, false);
                if (txtGLID.Tag != null && txtGLID.Text.Length > 0)
                    createFilterQuary("accGLName", txtGLID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SubGLIDCode()
        {
            try
            {
                txtAcctCode.Clear();
                txtAccType.Clear();

                txtAcctCode.Tag = null;
                txtAccType.Tag = null;

                if (txtGLID.Tag != null && txtGLID.Tag.ToString().Trim().Length > 0)
                {
                    clsSearch.Search_SubGLCode(txtSubGLID, null, txtGLID.Tag.ToString(), false);
                    if (txtSubGLID.Tag != null && txtSubGLID.Text.Length > 0)
                        createFilterQuary("accSubGLName", txtSubGLID);
                }
                else
                {
                    clsSearch.Search_SubGLCode(txtSubGLID, null, "", false);
                    if (txtSubGLID.Tag != null && txtSubGLID.Text.Length > 0)
                        createFilterQuary("accSubGLName", txtSubGLID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountTypeCode()
        {
            try
            {
                txtAcctCode.Clear();
                txtAcctCode.Tag = null;

                if (txtSubGLID.Tag != null && txtSubGLID.Tag.ToString().Trim().Length > 0)
                {
                    clsSearch.Search_AccountType(txtAccType, null, txtSubGLID.Tag.ToString(), false);
                    if (txtAccType.Tag != null && txtAccType.Text.Length > 0)
                        createFilterQuary("accAccountType", txtAccType);
                }
                else
                {
                    clsSearch.Search_AccountType(txtAccType, null, "", false);
                    if (txtAccType.Tag != null && txtAccType.Text.Length > 0)
                        createFilterQuary("accAccountType", txtAccType);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountCode()
        {
            try
            {
                if (txtAccType.Tag != null && txtAccType.Tag.ToString().Trim().Length > 0)
                {
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, txtAccType.Tag.ToString(), "");
                    if (txtAcctCode.Tag != null && txtAcctCode.Text.Length > 0)
                        createFilterQuary("accCode", txtAcctCode);
                }
                else
                {
                    clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, "", "");
                    if (txtAcctCode.Tag != null && txtAcctCode.Text.Length > 0)
                        createFilterQuary("accCode", txtAcctCode);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_FinacialYearID()
        {
            try
            {
                ClearFields();
                clsSearch.Search_FinancialID(ref txtFinYear);
                if (txtFinYear != null && txtFinYear.TextLength > 0)
                    RefreshGrid();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region DataGrid Filter
        private void createFilterQuary(string sColumnName, TextBox txtBox)
        {
            string sFinalQuery = "";
            try
            {
                string sValue = txtBox.Tag.ToString();
                //string sValue = EscapeLikeValue(txtBox.Tag.ToString());
                //string ChekedValue = clsHelpMethods.CheckValue(txtBox.Tag.ToString());
                //sFinalQuery = String.Format(" " + sColumnName + " like '&{0}&'", sValue);
                sFinalQuery = " " + sColumnName + " like '%" + sValue + "%'";
                dt.DefaultView.RowFilter = sFinalQuery;
            }
            catch (Exception ex)
            { clsValidate.WriteErrorLog("", iFormID,ex); SEACCException.Show(ex); }
        }
        public static string EscapeLikeValue(string sValue)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sValue.Length; i++)
            {
                char c = sValue[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else if (c == '/')
                    sb.Append(c + "\'");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        #endregion

        #region Form Closing
        private void frm_accBudget_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }
        #endregion

        #region User Checked Approve Details
        private void btnChecked_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtFinYear.Text != null && txtFinYear.TextLength > 0 && txtFinYear.Text != "<Auto Generate>")
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            frmSetApproved login = new frmSetApproved();
                            login.iFormID = iFormID;
                            login.userID = clsSecurity.UserIDLoged;
                            login.ShowDialog();
                            if (frmSetApproved.bChecked)
                            {
                                bHasApproved = true;
                                glbApprovedDate = clsSecurity.getServerDateTime();
                                if (IsUpdate)
                                {
                                    //userDetailsColorChanges();

                                    tbl_accBudget objDO = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                                    if (objDO != null)
                                    {
                                        objDO.IsApproved = true;
                                        objDO.DateApproved = clsSecurity.getServerDateTime();
                                        objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                        objDO.Update();
                                    }
                                }
                            }
                            else if (frmSetApproved.bReset)
                                bHasApproved = false;
                        }
                    }
                    else
                        MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtFinYear.Text != null && txtFinYear.TextLength > 0 && txtFinYear.Text != "<Auto Generate>")
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            frmSetChecked login = new frmSetChecked();
                            login.iFormID = iFormID;
                            login.userID = clsSecurity.UserIDLoged;
                            login.ShowDialog();
                            if (frmSetChecked.bChecked)
                            {
                                bHasChecked = true;
                                glbCheckedDate = clsSecurity.getServerDateTime();

                                if (IsUpdate)
                                {
                                    //userDetailsColorChanges();

                                    tbl_accBudget objDO = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                                    if (objDO != null)
                                    {
                                        objDO.IsChecked = true;
                                        objDO.DateChecked = clsSecurity.getServerDateTime();
                                        objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                        objDO.Update();
                                    }
                                }

                            }
                            else if (frmSetChecked.bReset)
                                bHasChecked = false;
                        }
                    }
                    else
                        MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            if (txtFinYear.Text != "" || txtFinYear.Text != "<Auto Generate>")
            {
                tbl_accBudget detail = tbl_accBudget.Select(txtFinYear.Tag.ToString());
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                    if (detail.IsDeleted)
                        dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
            }
        }

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion
    }
}
