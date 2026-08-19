using DataTire;
using Digiteq_Logic;
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
    public partial class frm_masAccFinancialYear_New : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess; 
        #endregion

        #region Form Load
        public frm_masAccFinancialYear_New()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accFinancial);
            iFormID = clsSecurity.getFormID(FormName.accFinancial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_accMasFinancialYear_New_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            clsFormatter.setFormatForm(this, "Financial Year Configuration", 3, iFormID);
            RefreshGrid();
            GridFormat();
        }
        #endregion

        #region Grid Format
        private void GridFormat()
        {
            dgvFinancialYear.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            dgvFinancialYear.RowsDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);

            dgvFinancialMonth.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            dgvFinancialMonth.RowsDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
        } 
        #endregion

        #region Action Buttons
        #region Close Year Button
        private void btnCloseYear_Click(object sender, EventArgs e)
        {
            string sSelectedFinYear = ""; 
            int sStatus = 0;
            try
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    DialogResult msgResult = MessageBox.Show("Do you want to closed this Financial Year?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (msgResult == DialogResult.Yes)
                    {
                        sSelectedFinYear = dgvFinancialYear.SelectedCells[0].Value.ToString();
                        if (sSelectedFinYear != null)
                        {
                            if (CheckStatusValidity_FinYear())
                            {
                                if (CheckAlreadyClosedYear())
                                {
                                    if (CheckReconcilationValidity_FinYear())
                                    {
                                        tbl_accFinancialYearMaster oFinYear = tbl_accFinancialYearMaster.Select(sSelectedFinYear);
                                        if (oFinYear != null)
                                        {
                                            oFinYear.StatusID = 3;
                                            oFinYear.ClosedUser_ID = clsSecurity.UserIDLoged;
                                            oFinYear.DateClosed = clsSecurity.getServerDateTime();
                                            oFinYear.Update();

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
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
            finally
            {
                RefreshGrid();
            }
        }
        #endregion

        #region Close Month Button
        private void btnCloseMonth_Click(object sender, EventArgs e)
        {
            string sSelectedFinYear = "", sSelectedFinYearMonth = "";
            try
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    DialogResult msgResult = MessageBox.Show("Do you want to closed this Financial Month?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (msgResult == DialogResult.Yes)
                    {
                        sSelectedFinYear = dgvFinancialYear.SelectedCells[0].Value.ToString();
                        sSelectedFinYearMonth = dgvFinancialMonth.SelectedCells[0].Value.ToString();
                        if (sSelectedFinYear != null && sSelectedFinYearMonth != null)
                        {
                            if (CheckStatusValidity_FinYearMonth())
                            {
                                if (CheckAlreadyClosedMonth())
                                {
                                    if (CheckReconcilationValidity_FinYearMonth())
                                    {
                                        tbl_accFinancialYearMaster_Month FYMClosing = tbl_accFinancialYearMaster_Month.Select(sSelectedFinYear, sSelectedFinYearMonth);
                                        if (FYMClosing != null)
                                        {
                                            FYMClosing.IsMonthClose = true;
                                            FYMClosing.ClosedUser_ID = clsSecurity.UserIDLoged;
                                            FYMClosing.DateClosed = clsSecurity.getServerDateTime();
                                            FYMClosing.Update();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
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
            finally
            {
                RefreshGrid_FinYearMonth(sSelectedFinYear);
            }
        }
        #endregion

        #region Create New Financial Year
        private void btnNewFinancialYear_Click(object sender, EventArgs e)
        {
            string sFinYear = "", sFinYear_Title = "";
            DateTime dtYearStartDate = DateTime.Now;
            DateTime dtYearEndDate = DateTime.Now;

            try
            {
                bool bFinYearStatus = getAutoGeneratedFinYear_New(sFormConfigCode, ref sFinYear, ref dtYearStartDate, ref dtYearEndDate);

                if (bFinYearStatus && sFinYear != null)
                {
                    sFinYear_Title = "Financial Year - " + sFinYear;
                    #region Header
                    tbl_accFinancialYearMaster detail = new tbl_accFinancialYearMaster(sFinYear,
                                        sFinYear_Title,
                                        dtYearStartDate,
                                        dtYearEndDate, 1,
                                        clsSecurity.UserIDLoged,
                                        clsSecurity.getServerDateTime(),
                                        clsSecurity.UserIDLoged,
                                        clsSecurity.TerminalID,
                                        clsSecurity.UserIDLoged,
                                        clsSecurity.TerminalID,
                                        clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime());

                    detail.Insert();
                    #endregion

                    AddFinancialYearMonths(sFinYear, dtYearStartDate, dtYearEndDate);

                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                RefreshGrid();
            }
        } 
        #endregion

        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvFinancialYear.Rows.Clear();

                foreach (tbl_accFinancialYearMaster detail in tbl_accFinancialYearMaster.SelectAll())
                {
                    if (detail.FinancialYear_ID.Trim() != "default")
                    {
                        dgvFinancialYear.Rows.Add();
                        iRow = dgvFinancialYear.Rows.Count - 1;
                        dgvFinancialYear["FinancialYear", iRow].Value = detail.FinancialYear_ID;
                        dgvFinancialYear["Title", iRow].Value = detail.FinancialYearName;
                        dgvFinancialYear["startDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", detail.DateStart);
                        dgvFinancialYear["endDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", detail.DateEnd);
                        dgvFinancialYear["status", iRow].Value = clsGenaralName.GetStatusName(detail.StatusID);
                        dgvFinancialYear["ClosedBy", iRow].Value = detail.StatusID == 3 ?  clsGenaralName.getName_User(detail.ClosedUser_ID) : "-";
                        dgvFinancialYear["ClosedDate", iRow].Value = detail.StatusID == 3 ? String.Format("{0:MM/dd/yyyy}", detail.DateClosed) : "-";
                    }
                }
                DataGridColor();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void RefreshGrid_FinYearMonth(string sFinYear)
        {
            try
            {
                int iRow;
                dgvFinancialMonth.Rows.Clear();

                foreach (tbl_accFinancialYearMaster_Month detail in tbl_accFinancialYearMaster_Month.SelectAllByFinancialYear_ID(sFinYear).OrderBy(p => p.DateStart))
                {
                    if (detail.FinancialYear_ID.Trim() != "default")
                    {
                        dgvFinancialMonth.Rows.Add();
                        iRow = dgvFinancialMonth.Rows.Count - 1;
                        dgvFinancialMonth["MonthID", iRow].Value = detail.Month_ID;
                        dgvFinancialMonth["monthStartDate", iRow].Value = String.Format("{0:MM/dd/yyyy}", detail.DateStart);
                        dgvFinancialMonth["monthEndDate", iRow].Value = String.Format("{0:MM/dd/yyyy}",  detail.DateEnd);
                        dgvFinancialMonth["monthStatus", iRow].Value = detail.IsMonthClose == true ? "Closed" : "Active";
                        dgvFinancialMonth["monthClosedBy", iRow].Value = detail.IsMonthClose == true ? clsGenaralName.getName_User(detail.ClosedUser_ID) : "-";
                        dgvFinancialMonth["monthClosedDate", iRow].Value = detail.IsMonthClose == true ? String.Format("{0:MM/dd/yyyy}", detail.DateClosed) : "-";
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

        #region Grid Events
        private void dgvFinancialYear_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sFinYear = dgvFinancialYear["FinancialYear", e.RowIndex].Value.ToString();
                    if (sFinYear.Length > 0)
                    {
                        //fills the values to controls
                        RefreshGrid_FinYearMonth(sFinYear.Trim());
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

        #region Check Validity
        private bool CheckStatusValidity_FinYear()
        {
            bool bStatus = true;
            bool isFyLocked = true;
            DateTime dtStartDate = DateTime.Now;
            DateTime dtSelectedStartDate = DateTime.Now;
            string sFinYear = "", sSelectedFinYear;

            try
            {
                dtSelectedStartDate = DateTime.Parse(dgvFinancialYear.SelectedCells[2].Value.ToString());
                foreach (tbl_accFinancialYearMaster detail in tbl_accFinancialYearMaster.SelectAll())
                {
                    if (detail.DateStart.Date < dtSelectedStartDate.Date)
                    {
                        if (detail.StatusID != 3)
                        {
                            sFinYear = detail.FinancialYear_ID;
                            bStatus = false;
                        }
                        else
                            bStatus = true;
                    }
                    else
                        continue;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Please Closed Previous " + sFinYear + " Year", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckStatusValidity_FinYearMonth()
        {
            bool bStatus = true;
            bool isFyLocked = true;
            DateTime dtStartDate;
            DateTime dtPreviousMonth;
            string sFinYear = "", sFinYearMonth = "";
            List<string> MonthList = new List<string>();

            try
            {
                //sFinYear = dgvFinancialYear.SelectedCells[0].Value.ToString();
                dtStartDate = DateTime.Parse(dgvFinancialMonth.SelectedCells[1].Value.ToString());
                dtPreviousMonth = dtStartDate.Date.AddMonths(-1);
                if (dtStartDate.Date != dtPreviousMonth.Date)
                {
                    tbl_accFinancialYearMaster_Month oMonth = tbl_accFinancialYearMaster_Month.SelectAll().Where(p => p.DateStart.Date == dtPreviousMonth.Date).FirstOrDefault();
                    if (oMonth != null)
                    {
                        if (oMonth.IsMonthClose != true)
                        {
                            sFinYearMonth = oMonth.Month_ID;
                            sFinYear = oMonth.FinancialYear_ID;
                            bStatus = false;
                        }
                        else
                            bStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Please Closed Previous Month " + sFinYearMonth  + " of " + sFinYear, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckReconcilationValidity_FinYearMonth()
        {
            bool bStatus = true;
            DateTime dtEndDate;
            string sBankAcc = "";

            try
            {
                dtEndDate = DateTime.Parse(dgvFinancialMonth.SelectedCells[2].Value.ToString());
                                
                foreach (tbl_genCompanyAccount oCom in tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyAccount_ID != -1))
                {
                    string sQuary = "SELECT dbo.GetLastReconcilation(" + oCom.CompanyAccount_ID + ")";
                    int iLastRecID = DBHandling.ExecQuery_ReturnInt(sQuary);

                    tbl_bpsBankReconciliation oRec = tbl_bpsBankReconciliation.Select(oCom.CompanyAccount_ID, iLastRecID);
                    if (oRec != null)
                    {
                        if (oRec.DateTo.Date < dtEndDate)
                        {
                            bStatus = false;
                            sBankAcc += oCom.AccountNumber + "\n";
                            continue;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Following Bank Accounts should be Reconcile before Month close..\n\n" + sBankAcc, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckReconcilationValidity_FinYear()
        {
            bool bStatus = true;
            DateTime dtEndDate;
            string sBankAcc = "";
            try
            {
                dtEndDate = DateTime.Parse(dgvFinancialYear.SelectedCells[3].Value.ToString());

                foreach (tbl_genCompanyAccount oCom in tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyAccount_ID != -1))
                {
                    string sQuary = "SELECT dbo.GetLastReconcilation(" + oCom.CompanyAccount_ID + ")";
                    int iLastRecID = DBHandling.ExecQuery_ReturnInt(sQuary);

                    tbl_bpsBankReconciliation oRec = tbl_bpsBankReconciliation.Select(oCom.CompanyAccount_ID, iLastRecID);
                    if (oRec != null)
                    {
                        if (oRec.DateTo.Date < dtEndDate)
                        {
                            bStatus = false;
                            sBankAcc += oCom.AccountNumber + "\n";
                            continue;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Following Bank Accounts should be Reconcile before Year close..\n\n" + sBankAcc, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckAlreadyClosedYear()
        {
            bool bStatus = true;
            string sFinYear = "";
            try
            {
                int iCurrentCell = dgvFinancialYear.CurrentCell.RowIndex;
                string sCurrentCellValue = dgvFinancialYear["status", iCurrentCell].Value.ToString();
                if (sCurrentCellValue == "Closed")
                {
                    sFinYear = dgvFinancialYear["FinancialYear", iCurrentCell].Value.ToString();
                    bStatus = false;
                }
                else
                    bStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Already closed this " + sFinYear + " Year", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }
        private bool CheckAlreadyClosedMonth()
        {
            bool bStatus = true;
            string sFinYearMonth = "";
            try
            {
                int iCurrentCell = dgvFinancialMonth.CurrentCell.RowIndex;
                string sCurrentCellValue = dgvFinancialMonth["monthStatus", iCurrentCell].Value.ToString();
                if (sCurrentCellValue == "Closed")
                {
                    sFinYearMonth = dgvFinancialMonth["MonthID", iCurrentCell].Value.ToString();
                    bStatus = false;
                }
                else
                    bStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show("Already closed this " + sFinYearMonth + " Month", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }
        #endregion

        #region Grid Color Changes
        private void DataGridColor()
        {
            foreach (DataGridViewRow row in dgvFinancialYear.Rows)
            {
                if (row.Cells["status"].Value == "Closed")
                    row.DefaultCellStyle.BackColor = Color.SlateGray;
                if (row.Cells["status"].Value == "Active")
                    row.DefaultCellStyle.BackColor = Color.Gray;
            }
        }
        #endregion

        #region Save Financial Year Months
        private void AddFinancialYearMonths(string sFinYear, DateTime dtStartDate, DateTime dtEndDate)
        {
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            int iMonth = 0, iDay = 1;

            for (StartDate = dtStartDate; StartDate <= dtEndDate; StartDate = dtStartDate.AddMonths(iMonth))
            {
                EndDate = StartDate.AddMonths(1).AddDays(-1);
                if (StartDate < EndDate)
                {
                    tbl_accFinancialYearMaster_Month Mdetail = new tbl_accFinancialYearMaster_Month(sFinYear, StartDate.ToString("MMMM"),
                        StartDate,
                        EndDate,
                        false,
                        clsSecurity.UserIDLoged,
                        clsSecurity.getServerDateTime(),
                        clsSecurity.UserIDLoged,
                        clsSecurity.UserIDLoged,
                        clsSecurity.TerminalID,
                        clsSecurity.TerminalID,
                        clsSecurity.getServerDateTime(),
                        clsSecurity.getServerDateTime());

                    Mdetail.Insert();
                }

                iMonth++;
            }
        }
        #endregion

        #region Get Auto Generated Financial year
        private bool getAutoGeneratedFinYear_New(string sFormConfigValueCode, ref string sFY_code, ref DateTime dtFinYearStartDate, ref DateTime dtFinYearEndDate)
        {
            bool bStatus = false;
            DateTime dtFinYearStart = DateTime.Now;
            int iYearStartMonth = int.Parse(clsConfig.sFinancialYear_StartMonth);

            tbl_securityConfigForms detail = tbl_securityConfigForms.Select(sFormConfigValueCode);
            if (detail.Counter != 0)
            {
                sFY_code = Convert.ToString(detail.Counter) + "/" + Convert.ToString(detail.Counter + 1);
                dtFinYearStartDate = new DateTime(detail.Counter, iYearStartMonth, 1);
                dtFinYearEndDate = dtFinYearStartDate.AddYears(1).AddDays(-1);

                detail.Counter++;
                detail.Update();

                bStatus = true;
            }

            return bStatus;
        }
        #endregion

    }
}
