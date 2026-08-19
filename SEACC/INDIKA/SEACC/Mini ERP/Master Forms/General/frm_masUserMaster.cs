using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_masUserMaster : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        string s_FileName;
        public int iFormID;

        Byte[] img = new byte[0];
        #endregion

        #region Form Load
        public frm_masUserMaster()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.UserMaster);
            iFormID = clsSecurity.getFormID(FormName.UserMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrBranch_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAdmin;
            //format Form
            // clsFormatter.setFormatForm(this, "User Master", 1, iFormID);

            //add data to the datagrid and format
            RefreshGrid();
            //CusDataGridViewFormat();
            ClearFields();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                            clsHelpMethods.InsertTransactionHistory(iFormID, txtUserID.Text, TxnActivity.Cancel);
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtUserID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_securityUserMaster oldRecord = tbl_securityUserMaster.Select(txtUserID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        if (s_FileName.Length > 0)
                                        {
                                            FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                            img = new Byte[fs.Length];
                                            fs.Read(img, 0, (int)fs.Length);
                                            fs.Close();
                                        }
                                        else if (oldRecord.Image != null && oldRecord.Image.Length > 0)
                                        {
                                            img = oldRecord.Image;
                                        }

                                        //in db field called password2 set to Pin No
                                        tbl_securityUserMaster detail = new tbl_securityUserMaster(txtUserID.Text, tetUserName.Text.Trim(), clsSecurity.encryptPassword(txtPassword.Text.Trim()), clsSecurity.encryptPassword(txtPinNo.Text),
                                        tetEmployeeCode.Text.Trim(), txtEmail.Text.Trim(), txtMoible.Text.Trim(), txtComputerName.Text.Trim(), txtComputerIp.Text.Trim(),
                                        dtpLastLogTime.Value, chkLoged.Checked, chkBlocked.Checked, chkLocked.Checked, txtGroupName.Tag.ToString(), img, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtUserID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {

                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtUserID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    if (s_FileName.Length > 0)
                                    {
                                        FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                        img = new Byte[fs.Length];
                                        fs.Read(img, 0, (int)fs.Length);
                                        fs.Close();
                                    }

                                    //User Master
                                    //in db field called password2 set to Pin No
                                    tbl_securityUserMaster detail = new tbl_securityUserMaster(txtUserID.Text, tetUserName.Text.Trim(), clsSecurity.encryptPassword(txtPassword.Text.Trim()), clsSecurity.encryptPassword(txtPinNo.Text),
                                    tetEmployeeCode.Text.Trim(), txtEmail.Text.Trim(), txtMoible.Text.Trim(), txtComputerName.Text.Trim(), txtComputerIp.Text.Trim(),
                                    dtpLastLogTime.Value, chkLoged.Checked, chkBlocked.Checked, chkLocked.Checked, txtGroupName.Tag.ToString(), img, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtUserID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" User " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            RefreshGrid();
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn LoadImage
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();

            // filedialog.Filter = "JPG Files|*.Jpg|" + "JPEG Files|*.Jpeg";
            filedialog.ShowDialog();
            s_FileName = filedialog.FileName;
            pbxImage.ImageLocation = s_FileName;
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorAdminHeaderColour, clsFormatter.colorDigiteqTheamColorAdminForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtUserID, true);
            clsCommon.SetEnableDisable_NormalLabel(lbluserID, true);

            txtGroupName.Tag = null;
            txtGroupName.Clear();
            tetUserName.Clear();
            txtGroupName.Clear();
            txtPassword.Clear();
            txtPinNo.Clear();
            tetEmployeeCode.Clear();
            txtMoible.Clear();
            txtComputerName.Clear();
            txtComputerIp.Clear();
            txtEmail.Clear();
            chkLoged.Checked = false;
            chkBlocked.Checked = false;
            chkLocked.Checked = false;
            dtpLastLogTime.Value = clsSecurity.getServerDateTime();
            s_FileName = "";//pbxImage
            pbxImage.Image = Digiteq.Properties.Resources.no_image;
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtUserID.Text = "<Auto Generate>";
            else
                txtUserID.Clear();

            if (txtUserID.Enabled)
            {
                txtUserID.SelectAll();
                txtUserID.Focus();
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtUserID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lbluserID, false);

                    //asign values
                    txtGroupName.Tag = detail.Group_ID;
                    txtGroupName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Group(detail.Group_ID));
                    txtUserID.Text = detail.User_ID;
                    txtPassword.Text = clsSecurity.decryptPassword(detail.Password);

                    //in db field called password2 set to Pin No
                    txtPinNo.Text = clsSecurity.decryptPassword(detail.Password2);
                    tetUserName.Text = detail.UserName;
                    tetEmployeeCode.Text = detail.EmployeeID;
                    txtMoible.Text = detail.Moible;
                    txtComputerName.Text = detail.ComputerName;
                    txtComputerIp.Text = detail.ComputerIP;
                    txtEmail.Text = detail.Email;
                    dtpLastLogTime.Text = detail.LastLogedDateTime.ToString();
                    chkLoged.Checked = detail.IsLoged;
                    chkBlocked.Checked = detail.IsBlocked;
                    chkLocked.Checked = detail.IsLocked;

                    //Image                    
                    if (detail.Image != null)
                    {
                        if (detail.Image.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(detail.Image);
                            pbxImage.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbxImage.Image = pbxImage.InitialImage;
                        }
                    }
                    else
                    {
                        pbxImage.Image = pbxImage.InitialImage;
                    }

                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            List<tbl_securityUserMaster> details = tbl_securityUserMaster.SelectAll();
            foreach (tbl_securityUserMaster detail in details)
            {
                if (detail.User_ID != "default" && detail.User_ID != "digiteq")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["UserID", iRow].Value = detail.User_ID;
                    dgvDetail["UserName", iRow].Value = detail.UserName;
                    dgvDetail["GroupID", iRow].Value = detail.Group_ID;
                    dgvDetail["Mobile", iRow].Value = detail.Moible;
                    dgvDetail["ComputerName", iRow].Value = detail.ComputerName;
                    dgvDetail["ComputerIP", iRow].Value = detail.ComputerIP;
                    dgvDetail["Email", iRow].Value = detail.Email;
                    dgvDetail["LastLogTime", iRow].Value = detail.LastLogedDateTime;
                    dgvDetail["Blocked", iRow].Value = detail.IsBlocked;
                    dgvDetail["Locked", iRow].Value = detail.IsLocked;
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtGroupName.TextLength == 0)
            {
                strMessage += "\n" + "Group Name";
                bStatus = false;
            }
            if (txtPassword.TextLength == 0)
            {
                strMessage += "\n" + "Password";
                bStatus = false;
            }

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

            if (txtPinNo.TextLength != 4)
            {
                strMessage += "\n" + "PIN Number";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show("PIN Number must be included 4 digits", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_UserID();
            }
        }
        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_GroupID();
            }
        }
        private void frm_mtrUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
            Search_UserID();
        }
        private void txtGroupName_DoubleClick(object sender, EventArgs e)
        {
            Search_GroupID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["UserID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    FillDetails(sID.Trim());
                }
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

        #region Search Methods
        private void Search_GroupID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Group();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtGroupName.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtGroupName.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void Search_UserID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                clsSearch.passValue_User(false);
            else
                clsSearch.passValue_User(true);
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtUserID.Text = frmSearchMaster.s_SearchID;
                FillDetails(frmSearchMaster.s_SearchID);
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
