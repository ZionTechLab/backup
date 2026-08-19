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


namespace Digiteq.Transaction_Forms.COM
{
    public partial class frm_masComComissionPeriod : MettroForm
    {
        #region Class Variables
        public int iFormID;
        public bool bNoAccess;
        public bool bHasApproved;
        static bool IsUpdateMode = false;

        private BindingSource SBind;
        DataTable dtPeriod;
        #endregion

        #region Form Load

        #region Init Form
        public frm_masComComissionPeriod()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Com_ComissionPeriodMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        } 
        #endregion

        private void frm_masComComissionPeriod_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            #region Init Data Table
            dtPeriod = new DataTable();
            dtPeriod.Columns.Add("LineNo", typeof(int));
            dtPeriod.Columns.Add("DateFrom", typeof(string));
            dtPeriod.Columns.Add("DateTo", typeof(string));
            dtPeriod.Columns.Add("PeriodId", typeof(string));
            dtPeriod.Columns.Add("PeriodName", typeof(string));
            dtPeriod.Columns.Add("IsPeriodClosed", typeof(string));
            #endregion

            #region Init Data Grid
            SBind = new BindingSource();
            dgvPeriods.AutoGenerateColumns = false;
            SBind.DataSource = dtPeriod;
            dgvPeriods.DataSource = SBind;
            #endregion

            ClearFields();
            RefreshGrid();
        } 
        #endregion

        #region Action Buttons
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long lIndex = 0;
            try
            {
                Cursor = Cursors.Arrow;

                if (CheckValidity())
                {
                    //Update
                    if (IsUpdateMode)
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, true))
                        {
                            tbl_comCommissionPeriodMaster oOldPeriod =
                                tbl_comCommissionPeriodMaster.Select(int.Parse(txtPeriodName.Tag.ToString()));
                            if (oOldPeriod != null)
                            {
                                tbl_comCommissionPeriodMaster oPeriodMaster = new tbl_comCommissionPeriodMaster(
                                    oOldPeriod.PeriodIndex, txtPeriodName.Text, dtpFromDate.Value.Date,
                                    dtpToDate.Value.Date, oOldPeriod.IsPeriodClose, oOldPeriod.ClosedUser_ID,
                                    clsCommon.defaultDateTime, oOldPeriod.CreateUser_ID, oOldPeriod.CreateTerminal_ID,
                                    clsSecurity.UserIDLoged, clsSecurity.TerminalID, oOldPeriod.CanceledUser_ID,
                                    oOldPeriod.CanceledTerminal_ID, oOldPeriod.DateCreate,
                                    clsSecurity.getServerDateTime(), clsCommon.defaultDateTime);
                                oPeriodMaster.Update();
                                clsHelpMethods.InsertTransactionHistory(iFormID, oOldPeriod.PeriodIndex.ToString(),
                                    TxnActivity.Update);
                                lIndex = oOldPeriod.PeriodIndex;
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    //Insert
                    else
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                        {
                            var oPeriods = tbl_comCommissionPeriodMaster.SelectAll();
                            long iNextIndex = 0;
                            if (oPeriods.Count > 0)
                                iNextIndex = oPeriods.Max(r => r.PeriodIndex) + 1;

                            tbl_comCommissionPeriodMaster oPeriodMaster = new tbl_comCommissionPeriodMaster(iNextIndex,
                                txtPeriodName.Text, dtpFromDate.Value.Date, dtpToDate.Value.Date, false, "default",
                                clsCommon.defaultDateTime, clsSecurity.UserIDLoged, clsSecurity.TerminalID, "default",
                                "default", "default", "default", clsSecurity.getServerDateTime(),
                                clsCommon.defaultDateTime, clsCommon.defaultDateTime);
                            oPeriodMaster.Insert();
                            clsHelpMethods.InsertTransactionHistory(iFormID, iNextIndex.ToString(), TxnActivity.Insert);
                            lIndex = oPeriodMaster.PeriodIndex;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone),
                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                Cursor = Cursors.Default;
                RefreshGrid();
                fillDetails(lIndex);
            }
        }

        private void btnPeriodClosed_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                {
                    if (txtPeriodName.Tag != null)
                    {
                        DialogResult msgResult =
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved),
                                clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            frmSetApproved login = new frmSetApproved();
                            login.iFormID = iFormID;
                            login.userID = clsSecurity.UserIDLoged;
                            login.ShowDialog();
                            if (frmSetApproved.bChecked)
                            {
                                bHasApproved = true;
                                if (IsUpdateMode)
                                {
                                    tbl_comCommissionPeriodMaster objDO =
                                        tbl_comCommissionPeriodMaster.Select(long.Parse(txtPeriodName.Tag.ToString()));
                                    if (objDO != null)
                                    {
                                        if (!objDO.IsPeriodClose)
                                        {
                                            objDO.IsPeriodClose = true;
                                            objDO.DateClosed = clsSecurity.getServerDateTime();
                                            objDO.ClosedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDO.Update();
                                        }
                                    }
                                }
                            }
                            else if (frmSetApproved.bReset)
                                bHasApproved = false;
                        }
                    }
                    else
                        MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(),
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove),
                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);

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

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdateMode = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoOfProcessedEmp, false);

            txtPeriodName.Tag = null;

            txtPeriodName.Text = "";
            txtNoOfProcessedEmp.Text = "";

            dtpFromDate.Value = clsSecurity.getServerDateTime();
            dtpToDate.Value = clsSecurity.getServerDateTime();

            txtNoOfProcessedEmp.Text = clsFormatter.FormatToNumberNoDecimal(0);
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtPeriod.Rows.Clear();
                int iLine_no = 0;
                foreach (tbl_comCommissionPeriodMaster oComPeriod in tbl_comCommissionPeriodMaster.SelectAll().Where(p => p.CanceledUser_ID == "default"))
                {
                    dtPeriod.Rows.Add(++iLine_no, oComPeriod.DateFrom.ToString("yyyy-MMM-dd"),
                        oComPeriod.DateTo.ToString("yyyy-MMM-dd"), oComPeriod.PeriodIndex, oComPeriod.PeriodName,
                        oComPeriod.IsPeriodClose ? "Yes" : "No"
                        );
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

            if (CheckValidity_EmptyField())
                if (CheckValidity_OverlapDatePeriod())
                    bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtPeriodName, "Comission Period Name"))
                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_OverlapDatePeriod()
        {
            bool bStatus = true;

            if (dtpToDate.Value.Date <= dtpFromDate.Value.Date)
            {
                bStatus = false;
            }

            var vPeriods = tbl_comCommissionPeriodMaster.SelectAll();
            tbl_comCommissionPeriodMaster vPeriod;
            if (IsUpdateMode)
                vPeriod = vPeriods.Where(r => r.PeriodIndex != int.Parse(txtPeriodName.Tag.ToString())).OrderByDescending(r => r.DateCreate).FirstOrDefault();
            else
                vPeriod = vPeriods.OrderByDescending(r => r.DateCreate).FirstOrDefault();




            if (vPeriods != null)
            {
                if (vPeriod.DateTo.Date > dtpFromDate.Value.Date)
                {
                    bStatus = false;
                }
            }

            if (bStatus == false)
                MessageBox.Show("Invalid Date From and Date To...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(long iIndex)
        {
            try
            {
                tbl_comCommissionPeriodMaster oPeriodMaster = tbl_comCommissionPeriodMaster.Select(iIndex);
                if (oPeriodMaster != null)
                {
                    IsUpdateMode = true;

                    txtPeriodName.Tag = oPeriodMaster.PeriodIndex;

                    txtPeriodName.Text = oPeriodMaster.PeriodName;
                    dtpFromDate.Value = oPeriodMaster.DateFrom.Date;
                    dtpToDate.Value = oPeriodMaster.DateTo.Date;

                    int iNoOfSalesRepsProcessed = tbl_comCommissionCalculation.SelectAllByPeriodIndex(iIndex).Where(r => !r.IsDeleted).Count();

                    txtNoOfProcessedEmp.Text = clsFormatter.FormatToNumberNoDecimal(iNoOfSalesRepsProcessed);

                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgvPeriods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int iLineNo = clsValidate.ValidateGridValue(dgvPeriods, "LineNo", e.RowIndex, 0);
                    if (iLineNo > 0 && dtPeriod.Rows.Count > 0)
                    {
                        DataRow dr = dtPeriod.Select("LineNo =" + iLineNo).FirstOrDefault();
                        if (dr != null)
                        {
                            int iIndex = clsValidate.ValidateRowValue(dr, "LineNo", 0);
                            fillDetails(iIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        #endregion
    }
}
