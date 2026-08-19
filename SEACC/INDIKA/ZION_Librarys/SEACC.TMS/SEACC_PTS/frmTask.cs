using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SEACC_PTS.NmsLogic;


namespace SEACC_PTS
{
    public partial class frm_Tasks : Form
    {
        #region Global Variables
        bool bIsmaximized = false;
        bool bLoadingCompleted = false;
        string sQuaryStatus = "", sQuaryCust = "", sQuaryUser = "", sQuaryType;
        //  string sAttachmentPath = "";
        public static int iOldAssignedUserID = 0;
        public static frmRightMenu frmMenu = null; 
        #endregion

        #region Form Load
        public frm_Tasks()
        {
            InitializeComponent();
            dgvStoryBoad.AutoGenerateColumns = false;
        }

        private void frm_Tasks_Load(object sender, EventArgs e)
        {
            #region Set Form State As Normal and Reset Location on Save and new Button
            //For get Hight and Width without Taskbar
            //int iHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Bottom;
            //int iWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right;

            //For get Hight and Variance with Taskbar
            //int iFullHeight = SystemInformation.VirtualScreen.Height;
            //int iRemainForTaskbar = iFullHeight - iHeight;


            //int iCurentHeight = pnlBottem.Height;
            //int iCurentWidth = pnlBottem.Width;


            //this.Width = iWidth;
            //this.Height = iHeight;
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //this.Left = 0;
            //this.Top = 0;
            //pnlBottem.Size = new System.Drawing.Size(iCurentWidth, iCurentHeight - iRemainForTaskbar);
            //btnSave.Location = new Point(btnSave.Location.X, (iCurentHeight - iRemainForTaskbar) + 10);
            //btnNew.Location = new Point(btnNew.Location.X, (iCurentHeight - iRemainForTaskbar) + 10);
            #endregion

            btn_Size_Click(null, null);
            ApplyGridFormat_New(dgvTasks);

            splitContainer1.SplitterDistance = splitContainer1.Width - 400;
            foreach (tbl_refStatus Status in tbl_refStatus.SelectAll())
            {
                ucChkListBox_Status.AddItem(Status.Status_ID, Status.Status, Status.isEnable_Task);
                cbxStatus1.Items.Add(Status.Status);
            }
            foreach (tbl_masClient Client in tbl_masClient.SelectAll())
            {
                ucChkListBox_Cust.AddItem(Client.Client_ID, Client.Client_Code, true);
            }
            foreach (tbl_refType Type in tbl_refType.SelectAll())
            {
                ucChkListBox_Type.AddItem(Type.Type_ID, Type.Type, true);
            }
            foreach (tbl_refFunction oFunc in tbl_refFunction.SelectAll())
            {
                ucChkListBox_Function.AddItem(oFunc.Function_ID, oFunc.Function_Name, true);
            }

            foreach (tbl_masUser oUser in tbl_masUser.SelectAll())
            {
                ucChkListBox_User.AddItem(oUser.User_ID, oUser.Display_Name, oUser.User_ID == settings.UserId_Loged);
            }
            if (settings.UserGroupID == 20)
            {
                txtAssignTo.Enabled = false;
                txtPriority.Enabled = false;
                dtpEstimateHours.Enabled = false;
                dtpDeadline.Enabled = false;
            }

            refreshGrid();
            ClearAll();

        } 
        #endregion

        #region Button Click Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sTaskId = "";
            int iMinute = dtpEstimateHours.Value.Hour * 60 + dtpEstimateHours.Value.Minute;
            bool bIsUpdate = false;
            if (txtTask.Text == "")
            {
                MessageBox.Show("Description ");
            }
            else if (txtClient.Text == "")
            {
                MessageBox.Show("Client ");
            }
            else if (txtProduct.Text == "")
            {
                MessageBox.Show("Product ");
            }
            else
            {
                int iAssignto = int.Parse(txtAssignTo.Tag.ToString());
                int iFunctionID = int.Parse(txtFunction.Tag.ToString());
                int iMainTaskID = int.Parse(txt_mainTask.Tag.ToString());
                bIsUpdate = btnSave.Tag != "0" ? true : false;

                if (btnSave.Tag == "0")//insert
                {
                    tbl_ptsTasks NewTask = new tbl_ptsTasks(0, settings.Organization_ID, settings.Branch_ID, iMainTaskID, txtTask.Text, rtf_Desc.FormatedText, rtb_TestCases.FormatedText, rtb_TechComments.FormatedText, TxtReff.Text, int.Parse(txtClient.Tag.ToString()), dtpReportedDate.Value.Date, txtReportedBy.Text, int.Parse(txtProduct.Tag.ToString()), iFunctionID, 0, int.Parse(txttaskType.Tag.ToString().Trim()), int.Parse(cbxStatus.Tag.ToString()), 0, iAssignto, iMinute, (txtPriority.Tag != null && txtPriority.Tag.ToString().Length > 0 ? int.Parse(txtPriority.Tag.ToString()) : 0), dtpDeadline.Value.Date, 0, settings.UserId_Loged, 0, DateTime.Now, DateTime.Now, "", "");
                    sTaskId = NewTask.Insert();

                    //clsUtillMaill.createEmail_AssignedTask(int.Parse(sTaskId), ref richTemp, bIsUpdate, iOldAssignedUserID);

                    MessageBox.Show("Inserted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//update
                {
                    tbl_ptsTasks Old = tbl_ptsTasks.Select(int.Parse(txtTaskId.Text));
                    if (Old != null)
                    {
                        sTaskId = Old.Task_ID.ToString();
                        tbl_ptsTasks OldTask = new tbl_ptsTasks(int.Parse(txtTaskId.Text), Old.Organization_ID, Old.Branch_ID, iMainTaskID, txtTask.Text, rtf_Desc.FormatedText, rtb_TestCases.FormatedText, rtb_TechComments.FormatedText, TxtReff.Text, int.Parse(txtClient.Tag.ToString()), dtpReportedDate.Value.Date, txtReportedBy.Text, int.Parse(txtProduct.Tag.ToString()), iFunctionID, 0, int.Parse(txttaskType.Tag.ToString().Trim()), int.Parse(cbxStatus.Tag.ToString()), Old.Progress, iAssignto, iMinute, (txtPriority.Tag != null && txtPriority.Tag.ToString().Length > 0 ? int.Parse(txtPriority.Tag.ToString()) : 0), dtpDeadline.Value.Date, Old.ActualHours, Old.CreateUser_ID, settings.UserId_Loged, Old.DateCreate, DateTime.Now, "", "");
                        OldTask.Update();
                        tbl_ptsTasksTracker oTrc = new tbl_ptsTasksTracker(0, int.Parse(txtTaskId.Text), DateTime.Now, 3, settings.UserId_Loged, 1);
                        oTrc.Insert();

                        #region Remove deleted files
                        string[] files = Directory.GetFiles("Attachments", OldTask.Task_ID + ".*");
                        if (files.Length != 0)
                        {
                            foreach (string s in files)
                            {
                                bool bIsDeletedFile = true;
                                foreach (DataGridViewRow row in dgvAttachment.Rows)
                                {
                                    if (row.Cells["isNew"].Value.ToString() != "True")
                                    {
                                        if (row.Cells["FilePath"].Value.ToString() == s)
                                        {
                                            bIsDeletedFile = false;
                                            break;
                                        }
                                    }
                                    else
                                        bIsDeletedFile = false;
                                }
                                if (bIsDeletedFile)
                                {
                                    File.Delete(s);
                                    foreach (tbl_ptsTasks_Attachments oAttachments in tbl_ptsTasks_Attachments.SelectAllByTask_ID(int.Parse(sTaskId)))
                                    {
                                        if (oAttachments.Attachment == s.Replace("Attachments\\", ""))
                                            oAttachments.Delete();
                                    }
                                }
                            }
                        }
                        #endregion

                        //Test for Identifiy new line in String
                        // string tmp =;

                        //clsUtillMaill.createEmail_AssignedTask(int.Parse(sTaskId), ref richTemp, bIsUpdate, iOldAssignedUserID);

                        MessageBox.Show("Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                #region Save new files
                foreach (DataGridViewRow row in dgvAttachment.Rows)
                {
                    if (row.Cells["isNew"].Value.ToString() == "True")
                    {
                        string SourcefilePath = row.Cells["FilePath"].Value.ToString();
                        string Sourcefilename = System.IO.Path.GetFileName(SourcefilePath);
                        int iAttachment_ID = GetAttachmentID(sTaskId);
                        string newFilePath = sTaskId + "." + iAttachment_ID + System.IO.Path.GetExtension(SourcefilePath);
                        File.Copy(SourcefilePath, @"Attachments\" + newFilePath);

                        tbl_ptsTasks_Attachments oAttachments = new tbl_ptsTasks_Attachments(int.Parse(sTaskId), iAttachment_ID, newFilePath, Sourcefilename);
                        oAttachments.Insert();
                    }
                }
                #endregion
                ClearAll();
                refreshGrid();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = (sQuaryStatus == "" ? "" : sQuaryStatus);
            s += (sQuaryCust == "" ? "" : (s != "" ? " And " : "") + sQuaryCust);
            s += (sQuaryUser == "" ? "" : (s != "" ? " And " : "") + sQuaryUser);
            s += (sQuaryType == "" ? "" : (s != "" ? " And " : "") + sQuaryType);
            if (s != "")
                (dgvTasks.DataSource as DataTable).DefaultView.RowFilter = s;  // "Status_ID in (0,1,2)";//string.Format("Status_ID = '{0,0,0}'", "0,1,2");
            toolStripStatusLabel1.Text = "Selected Tasks - " + dgvTasks.RowCount.ToString();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Add_AttachmentRow(openFileDialog1.FileName, System.IO.Path.GetFileName(openFileDialog1.FileName), true, 0, 0);
            }
        }
        private void btn_AttachmentDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvAttachment.SelectedRows.Count > 0)
            {
                dgvAttachment.Rows.RemoveAt(this.dgvAttachment.SelectedRows[0].Index);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearAll()
        {
            btnSave.Tag = "0";
            btnSave.Text = "Save";

            txtTaskId.Clear();
            txtTask.Clear();
            
            txt_mainTask.Tag = 0;
            txt_mainTask.Clear();

            rtf_Desc.FormatedText = "";
            rtb_TechComments.FormatedText = "";
            rtb_TestCases.FormatedText = "";
            TxtReff.Clear();
            txtClient.Clear();
            txtReportedBy.Clear();
            dtpReportedDate.Value = DateTime.Today;
            txtProduct.Clear();
            cbxStatus1.SelectedIndex = 0;

            txtAssignTo.Tag = 0;
            txtAssignTo.Clear();

            txtPriority.Tag = 0;
            txtPriority.Clear();

            txttaskType.Tag = 0;
            txttaskType.Clear();
            
            txtFunction.Tag = 0;
            txtFunction.Clear();

            dtpDeadline.Value = DateTime.Today;
            dtpEstimateHours.Value = DateTime.Parse("00:00:00");

            dgvAttachment.Rows.Clear();
            dgvStoryBoad.DataSource = null;
            
            cbxStatus.Tag = 0;
            cbxStatus.Text = "New";

        } 
        #endregion

        #region Refresh Grid
        private void refreshGrid()
        {
            tbl_ptsTasks Task = new tbl_ptsTasks();
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.DataSource = Task.SelectAll_TableWithRefference();
            bLoadingCompleted = true;
            toolStripStatusLabel1.Text = "Selected Tasks - " + dgvTasks.RowCount.ToString();
            sQuaryStatus = ucChkListBox_Status.GetFilterScript();
            sQuaryCust = ucChkListBox_Cust.GetFilterScript();
            sQuaryUser = ucChkListBox_User.GetFilterScript();
            sQuaryType = ucChkListBox_Type.GetFilterScript();
            button1_Click(null, null);
        } 
        #endregion

        #region Check Boxes Status Changed
        private void ucChkListBox_Type_aStatusChnged(string Quary)
        {
            sQuaryType = Quary;
            button1_Click(null, null);
        }
        private void ucChkListBox_User_aStatusChnged(string Quary)
        {
            sQuaryUser = Quary;
            button1_Click(null, null);
            // MessageBox.Show(Quary);
        }
        private void ucChkListBox_Status_aStatusChnged(string Quary)
        {
            sQuaryStatus = Quary;
            button1_Click(null, null);
        }
        private void ucChkListBox_Cust_aStatusChnged(string Quary)
        {
            sQuaryCust = Quary;
            button1_Click(null, null);
        } 
        #endregion

        #region Event Closed, Resize, Maximized and Minimize
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Size_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

            //  int iHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Bottom;
            //  int iWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right;

            if (!bIsmaximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;

                this.Width = Scr.WorkingArea.Width;
                this.Height = Scr.WorkingArea.Height;
                this.Left = Scr.Bounds.Location.X;
                this.Top = Scr.Bounds.Location.Y;

                bIsmaximized = true;
                btn_Size.Text = "";
            }
            else
            {
                this.Width = Scr.WorkingArea.Width / 3 * 2;
                this.Height = Scr.WorkingArea.Height / 3 * 2;
                this.Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4; ;
                this.Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;

                bIsmaximized = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                btn_Size.Text = "";
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_Tasks_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (bIsmaximized)
                    btn_Size_Click(null, null);
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                bIsmaximized = false;
                btn_Size_Click(null, null);
            }
        }
        private void btnPin_Click(object sender, EventArgs e)
        {
            if (TopMost)
                TopMost = false;
            else
                TopMost = true;
        }
        #endregion

        #region Data Grid Events
        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bLoadingCompleted)
                {
                    if (dgvTasks.RowCount > 0)
                    {
                        int iTaskId = int.Parse(dgvTasks.SelectedRows[0].Cells["Task_ID"].Value.ToString());

                        if (iTaskId.ToString() != txtTaskId.Text)
                        {
                            tbl_ptsTasks oTask = tbl_ptsTasks.Select(iTaskId);
                            if (oTask != null)
                            {
                                ClearAll();
                                txtTaskId.Text = oTask.Task_ID.ToString();
                                txtTask.Text = oTask.Task;
                                txt_mainTask.Text = oTask.Main_Task_ID.ToString();
                                rtf_Desc.FormatedText = oTask.Task_Desc;
                                rtb_TestCases.FormatedText = oTask.TestCases;
                                rtb_TechComments.FormatedText = oTask.DevComments;
                                TxtReff.Text = oTask.Reference_1;
                                txtFunction.Tag = dgvTasks.SelectedRows[0].Cells["Function_ID"].Value.ToString();
                                txtFunction.Text = dgvTasks.SelectedRows[0].Cells["Function_Name"].Value.ToString();

                                txtClient.Text = dgvTasks.SelectedRows[0].Cells["Client_Code"].Value.ToString();
                                txtClient.Tag = dgvTasks.SelectedRows[0].Cells["Client_ID"].Value.ToString();
                                txtReportedBy.Text = dgvTasks.SelectedRows[0].Cells["ReportedBy"].Value.ToString();
                                dtpReportedDate.Value = DateTime.Parse(dgvTasks.SelectedRows[0].Cells["ReportedDate"].Value.ToString());
                                txtProduct.Text = dgvTasks.SelectedRows[0].Cells["Product_Code"].Value.ToString();
                                txtProduct.Tag = dgvTasks.SelectedRows[0].Cells["Prod_ID"].Value.ToString();
                                cbxStatus.Tag = int.Parse(dgvTasks.SelectedRows[0].Cells["Status_ID"].Value.ToString());
                                cbxStatus.Text = clsGenaralNmaes.getNameStatus(int.Parse(cbxStatus.Tag.ToString()));

                                //cbxStatus1.SelectedIndex = int.Parse(dgvTasks.SelectedRows[0].Cells["Status_ID"].Value.ToString());
                                //   cbxTaskType.SelectedIndex = int.Parse(dgvTasks.SelectedRows[0].Cells["Type_ID"].Value.ToString());

                                txttaskType.Tag = dgvTasks.SelectedRows[0].Cells["Type_ID"].Value.ToString();
                                txttaskType.Text = dgvTasks.SelectedRows[0].Cells["Type"].Value.ToString();
                                txtAssignTo.Text = dgvTasks.SelectedRows[0].Cells["Assign_To_User_Name"].Value.ToString();
                                txtAssignTo.Tag = dgvTasks.SelectedRows[0].Cells["Assign_To_User_ID"].Value.ToString();
                                txtPriority.Text = clsGenaralNmaes.getNamePriorityType(int.Parse(dgvTasks.SelectedRows[0].Cells["Priority"].Value.ToString()));
                                txtPriority.Tag = int.Parse(dgvTasks.SelectedRows[0].Cells["Priority"].Value.ToString());
                                TimeSpan span = TimeSpan.FromMinutes(double.Parse(dgvTasks.SelectedRows[0].Cells["Estimate_Minutes"].Value.ToString()));
                                dtpEstimateHours.Value = DateTime.Parse(span.ToString());
                                dtpDeadline.Value = DateTime.Parse(dgvTasks.SelectedRows[0].Cells["Deadline"].Value.ToString());
                                btnSave.Text = "Update";
                                btnSave.Tag = "1";

                                proc_Tasktracking trc = new proc_Tasktracking();
                                dgvStoryBoad.DataSource = trc.SelectAllBy_TableTask_ID(int.Parse(txtTaskId.Text.ToString().Trim()));


                                //For global use 
                                iOldAssignedUserID = int.Parse(dgvTasks.SelectedRows[0].Cells["Assign_To_User_ID"].Value.ToString());
                                foreach (tbl_ptsTasks_Attachments oAttachments in tbl_ptsTasks_Attachments.SelectAllByTask_ID(iTaskId))
                                {
                                    Add_AttachmentRow(@"Attachments\" + oAttachments.Attachment, oAttachments.DipsplayName, false, oAttachments.Task_ID, oAttachments.Attachment_Index);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong####" + ex.Message);
            }
        }
        private void dgvAttachment_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            // {
            // System.Diagnostics.Process.Start(@"c:\textfile.txt");
        }

        private void dgvAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAttachment.RowCount > 0)
                {
                    string strTaskId = dgvAttachment.SelectedRows[0].Cells["FilePath"].Value.ToString();
                    System.Diagnostics.Process.Start(strTaskId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvAttachment_MouseUp(object sender, MouseEventArgs e)
        {
            #region Right Click Event
            if (e.Button == MouseButtons.Right)
            {
                #region Get File Path
                string sFilePath = "";
                if (this.dgvAttachment.SelectedRows.Count > 0)
                {
                    int iRowindex = dgvAttachment.CurrentCell.RowIndex;
                    sFilePath = dgvAttachment.Rows[iRowindex].Cells["FilePath"].Value.ToString();
                }
                #endregion

                // rightContext.Show(this, new Point(e.X, e.Y));

                #region Call RightClick
                if (frmMenu != null)
                {
                    frmMenu.Close();
                    frmMenu = null;
                    frmMenu = new frmRightMenu(sFilePath, e.X, e.Y);
                    frmMenu.Show();
                    // frmMenu.BringToFront();
                }
                else
                {
                    if (sFilePath != "" && sFilePath.Length > 0)
                    {
                        frmMenu = new frmRightMenu(sFilePath, e.X, e.Y);
                        frmMenu.Show();
                    }

                }
                #endregion
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (frmMenu != null)
                {
                    frmMenu.Close();
                    frmMenu = null;
                }
            }
            #endregion
        }

        private void dgvAttachment_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvAttachment.SelectedRows.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dgvAttachment.CurrentCell = dgvAttachment.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvAttachment.Rows[e.RowIndex].Selected = true;
                    dgvAttachment.Focus();
                }
            }
        } 
        #endregion

        #region Double Click Event
        private void pnlHeader_DoubleClick(object sender, EventArgs e)
        {
            btn_Size_Click(null, null);
        }
        private void ucTittleBar1_DoubleClick(object sender, EventArgs e)
        {
            btn_Size_Click(null, null);
        }


        //textbox double click event
        private void txt_mainTask_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("501");
            if (strResult.Count > 0)
            {
                txt_mainTask.Tag = strResult[0];
                txt_mainTask.Text = strResult[0];
            }
        }
        private void txtTask_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("502");
            if (strResult.Count > 0)
            {
                int iTaskId = int.Parse(strResult[0]);

                if (iTaskId.ToString() != txtTaskId.Text)
                {
                    tbl_ptsTasks oTask = tbl_ptsTasks.Select(iTaskId);
                    if (oTask != null)
                    {
                        ClearAll();
                        txtTaskId.Text = oTask.Task_ID.ToString();
                        txtTask.Text = oTask.Task;
                        txt_mainTask.Text = oTask.Main_Task_ID.ToString();
                        rtf_Desc.FormatedText = oTask.Task_Desc;
                        rtb_TestCases.FormatedText = oTask.TestCases;
                        rtb_TechComments.FormatedText = oTask.DevComments;
                        TxtReff.Text = oTask.Reference_1;

                        txtFunction.Tag = oTask.Function_ID;
                        txtFunction.Text = clsGenaralNmaes.getNameFunction(int.Parse(txtFunction.Tag.ToString()));
                        txtClient.Tag = oTask.Client_ID.ToString();
                        txtClient.Text = clsGenaralNmaes.getNameClient(int.Parse(oTask.Client_ID.ToString()));
                        txtProduct.Tag = oTask.Prod_ID;
                        txtProduct.Text = clsGenaralNmaes.getNameProduct(int.Parse(oTask.Prod_ID.ToString()));
                        cbxStatus.Tag = oTask.Status_ID;
                        cbxStatus.Text = clsGenaralNmaes.getNameStatus(int.Parse(cbxStatus.Tag.ToString()));
                        txttaskType.Tag = oTask.Type_ID;
                        txttaskType.Text = clsGenaralNmaes.getNameTaskType(int.Parse(txttaskType.Tag.ToString()));
                        txtAssignTo.Tag = oTask.Assign_To;
                        txtAssignTo.Text = clsGenaralNmaes.getNameEngineer(int.Parse(oTask.Assign_To.ToString()));
                        txtPriority.Tag = oTask.Priority;
                        txtPriority.Text = clsGenaralNmaes.getNamePriorityType(oTask.Priority);

                        txtReportedBy.Text = oTask.ReportedBy;
                        dtpReportedDate.Value = oTask.ReportedDate;

                        TimeSpan span = TimeSpan.FromMinutes(double.Parse(oTask.Estimate_Minutes.ToString()));
                        dtpEstimateHours.Value = DateTime.Parse(span.ToString());
                        dtpDeadline.Value = DateTime.Parse(oTask.Deadline.ToString());
                        btnSave.Text = "Update";
                        btnSave.Tag = "1";

                        proc_Tasktracking trc = new proc_Tasktracking();
                        dgvStoryBoad.DataSource = trc.SelectAllBy_TableTask_ID(int.Parse(txtTaskId.Text.ToString().Trim()));

                        //For global use 
                        iOldAssignedUserID = int.Parse(oTask.Assign_To.ToString());
                        foreach (tbl_ptsTasks_Attachments oAttachments in tbl_ptsTasks_Attachments.SelectAllByTask_ID(iTaskId))
                        {
                            Add_AttachmentRow(@"Attachments\" + oAttachments.Attachment, oAttachments.DipsplayName, false, oAttachments.Task_ID, oAttachments.Attachment_Index);
                        }
                    }
                }
            }
        }       
        private void txtProduct_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("105");
            if (strResult.Count > 0)
            {
                txtProduct.Tag = strResult[0];
                txtProduct.Text = strResult[2];
            }
        }
        private void txtFunction_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("610");
            if (strResult.Count > 0)
            {
                txtFunction.Tag = strResult[0];
                txtFunction.Text = strResult[1];
            }
        }
        private void cbxStatus_DoubleClick(object sender, EventArgs e)
        {

            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("612");
            if (strResult.Count > 0)
            {
                cbxStatus.Tag = strResult[0];
                cbxStatus.Text = strResult[1];
            }
        }


        //like drop down list
        private void txtClient_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txtClient);
            List<string> strResult = PickBx.Pick("100");
            if (strResult.Count > 0)
            {
                txtClient.Tag = strResult[0];
                txtClient.Text = strResult[2];
            }
        }
        private void txttaskType_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txttaskType);
            List<string> strResult = PickBx.Pick("605");
            if (strResult.Count > 0)
            {
                txttaskType.Tag = strResult[0];
                txttaskType.Text = strResult[1];
                if (txtTaskId.Text == "")
                {
                    txtAssignTo.Tag = strResult[2];
                    txtAssignTo.Text = configNames.GetUserName(int.Parse(strResult[2]));
                    if (txtAssignTo.Enabled != false)
                    {
                        cbxStatus1.SelectedIndex = 1;
                    }
                }
            }
        }
        private void txtAssignTo_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txtAssignTo);
            PickBx.Pick("110", ref txtAssignTo);
            //List<string> strResult = PickBx.Pick("110",ref txtAssignTo);
            //if (strResult.Count > 0)
            //{
            //    txtAssignTo.Tag = strResult[0];
            //    txtAssignTo.Text = strResult[1];
            //}
        }
        private void txtPriority_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txtAssignTo);
            PickBx.Pick("611", ref txtPriority);
        }
        #endregion

        #region Key Up Event
        private void txtClient_KeyUp(object sender, KeyEventArgs e)
        {
            frm_PickBox_Mini PickBx = new frm_PickBox_Mini(ref txtClient);
            List<string> strResult = PickBx.Pick("100");
            if (strResult.Count > 0)
            {
                txtClient.Tag = strResult[0];
                txtClient.Text = strResult[2];
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            (dgvTasks.DataSource as DataTable).DefaultView.RowFilter = "Task like '%" + txtSearch.Text + "%'";
        }
        #endregion


        #region Add Files to Attachment
        private void Add_AttachmentRow(string FilePath, string FileName, bool isNewItem, int task_id, int Attachment_id)
        {
            int iRow = dgvAttachment.Rows.Add();
            dgvAttachment["FilePath", iRow].Value = FilePath;
            dgvAttachment["FileName", iRow].Value = FileName;
            dgvAttachment["isNew", iRow].Value = isNewItem.ToString();
            if (!isNewItem)
            {
                dgvAttachment["Task_ID1", iRow].Value = task_id.ToString();
                dgvAttachment["Attachment_Index", iRow].Value = Attachment_id.ToString();
            }
            if (System.IO.Path.GetExtension(openFileDialog1.FileName) == ".pdf")
            {
                dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\PDF.PNG");

            }
            switch (System.IO.Path.GetExtension(openFileDialog1.FileName))
            {
                case ".pdf":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\PDF.PNG");
                    break;
                case ".doc":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\Doc.PNG");
                    break;
                case ".xls":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\xls.PNG");
                    break;
                case ".png":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\jpg.PNG");
                    break;
                case ".zip":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\zip.PNG");
                    break;
                case ".ppt":
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\ppt.PNG");
                    break;
                default:
                    dgvAttachment["icon", iRow].Value = Image.FromFile(@"image\others.PNG");
                    break;
            }
        }
        #endregion

        #region Data Grid Format
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
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        } 
        #endregion

        #region Get Attachment ID
        private int GetAttachmentID(String taskId)
        {
            int i = 1;
            string[] files = Directory.GetFiles("Attachments", taskId + "." + i + ".*");

            while (files.Length != 0)
            {
                i++;
                files = Directory.GetFiles("Attachments", taskId + "." + i + ".*");
            }

            return i;
        } 
        #endregion

    }
}
