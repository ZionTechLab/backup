using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class frmTimeSheet : Form
    {
        #region Global Variables
        bool bLoadingCompleted = false;
        string sFilter_User = "CreateUser_ID in (" + settings.UserId_Loged + ")"; 
        #endregion

        #region Form Load
        public frmTimeSheet()
        {
            InitializeComponent();
        }

        private void frmTimeSheet_Load(object sender, EventArgs e)
        {
            ApplyGridFormat_New(dgvTasks);
            refreshGrid();
            ClearAll();
        } 
        #endregion

        #region Action Buttons
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessege = "";

            if (txtTaskID.Text != null)
            {
                int iTaskID = int.Parse(txtTaskID.Text);
                int iMinute = dtpActivityHours.Value.Hour * 60 + dtpActivityHours.Value.Minute;
                TimeSpan span = TimeSpan.FromMinutes(double.Parse((iMinute).ToString()));
                int iStatusID = int.Parse(txtStatus.Tag.ToString().Trim());
                int iPTS_TD = txtTSID.Text != "" ? int.Parse(txtTSID.Text) : 0;

                tbl_ptsTasks oTask = tbl_ptsTasks.Select(iTaskID);
                if (oTask != null)
                {
                    if (span.Hours == 0 && span.Minutes == 0)
                        sMessege = "Please Set utilized Hours";

                    else if (iStatusID == 0 || iStatusID == 1)
                        sMessege = "Please Set Status";

                    else if (oTask.Progress > int.Parse(txtProgress.Text.Trim()))
                        sMessege = "Current progress cannot less than Previus progress";
                    //send email alert
                    else
                    {
                        int iAccumilatedMts = 0;
                        foreach (tbl_ptsTimeSheet oPTSall in tbl_ptsTimeSheet.SelectAllByTask_ID(iTaskID).Where(p => p.TS_ID != iPTS_TD))
                        {
                            iAccumilatedMts += oPTSall.TS_Utilized_Mts;
                        }

                        if (btnSave.Tag.ToString() == "0")//insert
                        {
                            tbl_ptsTimeSheet PTS = new tbl_ptsTimeSheet(0, dtpTSDate.Value.Date, iTaskID, settings.UserId_Loged, settings.Organization_ID, settings.Branch_ID, txtRem.Text, 0, iMinute, iMinute, iAccumilatedMts, settings.UserId_Loged, 0, 0, 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, false, false, false, "", "", "", "", "");
                            PTS.Insert();
                        }
                        else
                        {
                            tbl_ptsTimeSheet Old = tbl_ptsTimeSheet.Select(iPTS_TD);
                            if (Old != null)
                            {
                                tbl_ptsTimeSheet PTS = new tbl_ptsTimeSheet(Old.TS_ID, dtpTSDate.Value.Date, iTaskID, Old.User_ID, Old.Organization_ID, Old.Branch_ID, txtRem.Text, 0, iMinute, iMinute, iAccumilatedMts, Old.CreateUser_ID, settings.UserId_Loged, Old.CheckedUser_ID, Old.ApprovedUser_ID, Old.DeletedUser_ID, Old.DateCreate, DateTime.Now, Old.DateChecked, Old.DateApproved, Old.DateDeleted, Old.IsChecked, Old.IsApproved, Old.IsDeleted, Old.CreateTerminal_ID, Old.ModifiedTerminal_ID, Old.DeletedTerminal_ID, Old.CheckedTerminal_ID, Old.ApprovedTerminal_ID); PTS.Update();
                            }
                        }
                        oTask.Status_ID = int.Parse(txtStatus.Tag.ToString().Trim());
                        oTask.Progress = int.Parse(txtProgress.Text.Trim());
                        oTask.Update();
                        refreshGrid();
                        sMessege = "Updated Successfully";
                        if (txtStatus.TextLength > 0)
                        {
                            if (txtStatus.Tag.ToString() == "25" || txtStatus.Tag.ToString() == "120" || txtStatus.Tag.ToString() == "200")
                                clsUtillMaill.createEmail_CompleatTask(iTaskID, txtStatus.Text);
                        }
                        ClearAll();
                    }
                }
                else
                    sMessege = "Invalied Task ID";





            }
            else
                sMessege = "Invalied Task ID";

            MessageBox.Show(sMessege);

            //if (txtTaskID.Text == null)
            //{
            //    MessageBox.Show("task Id ");
            //}
            //else if (span.Hours == 0 && span.Minutes == 0)
            //{
            //    MessageBox.Show("Hours ");
            //}
            //else if (iStatusID ==0 || iStatusID==1)
            //{
            //    MessageBox.Show("Please Change the Status ");
            //}
            //else
            //{ 

            //    if (btnSave.Tag == "0")//insert
            //    {
            //        tbl_ptsTimeSheet PTS = new tbl_ptsTimeSheet(0, dtpTSDate.Value,iTaskID, 0, 0, txtRem.Text, 0, iMinute, settings.UserId_Loged, 0, 0, 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, false, false, false, "", "", "", "", "");
            //        PTS.Insert();
            //    }
            //    else
            //    {
            //        tbl_ptsTimeSheet Old = tbl_ptsTimeSheet.Select(int.Parse(txtTSID.Text));
            //        if (Old != null)
            //        {
            //            tbl_ptsTimeSheet PTS = new tbl_ptsTimeSheet(Old.TS_ID, dtpTSDate.Value, iTaskID, 0, 0, txtRem.Text, 0, iMinute, Old.CreateUser_ID, settings.UserId_Loged, Old.CheckedUser_ID, Old.ApprovedUser_ID, Old.DeletedUser_ID, Old.DateCreate, DateTime.Now, Old.DateChecked, Old.DateApproved, Old.DateDeleted, Old.IsChecked, Old.IsApproved, Old.IsDeleted, Old.CreateTerminal_ID, Old.ModifiedTerminal_ID, Old.DeletedTerminal_ID, Old.CheckedTerminal_ID, Old.ApprovedTerminal_ID); PTS.Update();
            //        }
            //    }
            //    tbl_ptsTasks oTask = tbl_ptsTasks.Select(iTaskID);
            //    if (oTask != null)
            //    {
            //        oTask.Status_ID = int.Parse(txtStatus.Tag.ToString().Trim());
            //        oTask.Progress = int.Parse(txtProgress.Text.Trim());
            //        oTask.Update();
            //    }
            //    refreshGrid();
            //    ClearAll();

            //    MessageBox.Show("Updated Successfully");
            //}

        } 
        #endregion

        #region Clear Fields
        private void ClearAll()
        {
            btnSave.Tag = "0";
            btnSave.Text = "Save";
            txtTSID.Clear();
            dtpTSDate.Value = DateTime.Now;
            txtTaskID.Clear();
            txtTask.Clear();
            txtRem.Clear();
            txtProgress.Clear();
            txtStatus.Clear();
            dtpActivityHours.Value = DateTime.Parse("00:00:00");
        } 
        #endregion

        #region Refresh Grid
        private void refreshGrid()
        {
            tbl_ptsTimeSheet PTS = new tbl_ptsTimeSheet();
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.DataSource = PTS.SelectAll_Table2();

            Filter();
            // (dgvTasks.DataSource as DataTable).DefaultView.RowFilter = "CreateUser_ID in (" + settings.iLogedUserId + ")";//string.Format("Status_ID = '{0,0,0}'", "0,1,2");
            bLoadingCompleted = true;
            UpdateSummary();
        } 
        #endregion

        #region Event Closed and Minimize
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Value Changed Event
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            Filter();
        } 
        #endregion

        #region Filters
        private void Filter()
        {
            try
            {
                string s = "(TS_Date >= '" + dtpFrom.Value.Date.ToString("MM/dd/yyyy") + "' and TS_Date <= '" + dtpTo.Value.Date.ToString("MM/dd/yyyy") + "') AND " + sFilter_User;
                (dgvTasks.DataSource as DataTable).DefaultView.RowFilter = s;
                UpdateSummary();
            }
            catch (Exception)
            {

                //throw;
            }
        } 
        #endregion

        #region Update Summary
        private void UpdateSummary()
        {
            try
            {
                int iDateCount = int.Parse((dtpTo.Value.Date - dtpFrom.Value.Date).ToString("dd")) + 1;
                toolStripStatusLabel_NoOfDays.Text = "No Of Days(Selected) :" + iDateCount.ToString();
                toolStripStatusLabel_EstimatedHr.Text = "    Estimate Hr. :" + (iDateCount * 9).ToString();
                double dActualWorkHr = 0;
                foreach (DataGridViewRow row in dgvTasks.Rows)
                {
                    dActualWorkHr += double.Parse(row.Cells["TS_Activity_Minutes"].Value.ToString());
                }
                TimeSpan span = TimeSpan.FromMinutes(dActualWorkHr);
                toolStripStatusLabelActualHr.Text = "    Actual Hr. :" + span.Hours.ToString() + ":" + span.Minutes.ToString("00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion

        #region Double Click Event
        private void txtTaskID_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("500");
            if (strResult.Count > 0)
            {
                txtTaskID.Text = strResult[0];
                txtTaskID.Tag = strResult[0];
                txtTask.Text = strResult[2];

                tbl_ptsTasks oTask = tbl_ptsTasks.Select(int.Parse(txtTaskID.Text.ToString()));
                if (oTask != null)
                {
                    txtStatus.Tag = oTask.Status_ID;
                    tbl_refStatus oStatus = tbl_refStatus.Select(oTask.Status_ID);
                    txtStatus.Text = oStatus.Status;
                    txtProgress.Text = oTask.Progress.ToString();
                }
            }

        }
        private void txtStatus_DoubleClick(object sender, EventArgs e)
        {
            if (txtTaskID.Text != "")
            {
                frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txtStatus);
                List<string> strResult = PickBx.Pick("600");
                if (strResult.Count > 0)
                {
                    txtStatus.Text = strResult[1];
                    txtStatus.Tag = strResult[0];
                    if (strResult[3] == "True")
                    {
                        txtProgress.Text = strResult[2];
                        txtProgress.Enabled = false;
                    }
                    else
                        txtProgress.Enabled = true;
                }
            }
        }
        #endregion

        #region Key Down Event
        private void txtTaskID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtTaskID_DoubleClick(null, null);
            }
        } 
        #endregion

        #region Datagrid Events
        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bLoadingCompleted)
                {
                    if (dgvTasks.RowCount > 0)
                    {
                        string strTSId = dgvTasks.SelectedRows[0].Cells["TS_ID"].Value.ToString();
                        if (strTSId != txtTSID.Text)
                        {
                            txtTSID.Text = strTSId;
                            dtpTSDate.Value = DateTime.Parse(dgvTasks.SelectedRows[0].Cells["TS_Date"].Value.ToString());
                            txtTaskID.Text = dgvTasks.SelectedRows[0].Cells["Task_ID"].Value.ToString();

                            txtRem.Text = dgvTasks.SelectedRows[0].Cells["Remarks"].Value.ToString();

                            TimeSpan span = TimeSpan.FromMinutes(double.Parse(dgvTasks.SelectedRows[0].Cells["TS_Activity_Minutes"].Value.ToString()));
                            dtpActivityHours.Value = DateTime.Parse(span.ToString());

                            tbl_ptsTasks oTask = tbl_ptsTasks.Select(int.Parse(txtTaskID.Text.ToString()));
                            if (oTask != null)
                            {
                                txtTask.Text = oTask.Task;
                                txtStatus.Tag = oTask.Status_ID;
                                tbl_refStatus oStatus = tbl_refStatus.Select(oTask.Status_ID);
                                if (oStatus != null)
                                {
                                    txtStatus.Text = oStatus.Status;
                                    if (oStatus.isPresentageFixed)
                                    {
                                        txtProgress.Enabled = false;
                                        txtProgress.Text = oStatus.Presentage.ToString();
                                    }
                                    else
                                        txtProgress.Enabled = true;
                                }
                                txtProgress.Text = oTask.Progress.ToString();
                            }



                            btnSave.Text = "Update";
                            btnSave.Tag = "1";
                        }
                    }
                }
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.ToString());
            }
        } 
        #endregion

        #region Datagrid Format
        public static void ApplyGridFormat_New(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.DarkGray;
            dataGridView.BorderStyle = BorderStyle.None;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView.DefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        } 
        #endregion

        private void frmTimeSheet_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
