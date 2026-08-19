using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SEACC.DATA.Data.CFG;

namespace Digiteq
{
    public partial class frmMyPortal : Form
    {

        

        public int iFormID;
        public bool bNoAccess;

        string s_FileName;
        Byte[] img = new byte[0];

        UserData oData = new UserData();
   

        #region Form Load
        public frmMyPortal()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCustomer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            ClearFields();
            FillDetails(clsSecurity.UserIDLoged);

            var result = oData.GetTheme_ID(txtUserID.Text.Trim());
            if (result.IsSuccess)
            {
                int Theme_ID = int.Parse(result.ReturnValue);
                if (Theme_ID == 0)
                    rdoLegacy.Checked = true;
                else
                    rdoMetro.Checked = true;
            }
            else
                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOk = true, bChangePassword = false, bPinChange = false, bChangeUserDetails = false;
                if (txtPassword1.TextLength > 0 || txtPassword2.TextLength > 0)
                {
                    if (ValidateChangePassword())
                    {
                        bChangePassword = true;
                        bChangeUserDetails = true;
                    }
                    else
                        bOk = false;
                }
                else if (txtOldPin.TextLength > 0 && txtNewPin.TextLength > 0)
                {
                    if (CheckPinNumberValidity())
                        bPinChange = true;
                }
                else
                {
                    if (txtPassword.Text.Trim().Length > 0)
                    {
                        bChangeUserDetails = true;
                    }
                    else
                    {
                        bChangeUserDetails = false;
                        MessageBox.Show("Please Enter The Password to Modify The Changes", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (bOk && txtUserID.TextLength > 0)
                {
                    tbl_securityUserMaster user = tbl_securityUserMaster.Select(txtUserID.Text.Trim());
                    if (user != null)
                    {
                        if (bChangeUserDetails)
                        {
                            if (string.Compare(user.Password, clsSecurity.encryptPassword(txtPassword.Text.Trim()), true) == 0)
                            {
                                user.UserName = txtUserName.Text.Trim();
                                if (bChangePassword)
                                {
                                    user.Password = clsSecurity.encryptPassword(txtPassword2.Text.Trim());
                                    user.LastPWChangedDateTime = clsSecurity.getServerDateTime();
                                    user.LastPWChangedUser_ID = clsSecurity.UserIDLoged;
                                    user.LastPWChangedTerminal_ID = clsSecurity.TerminalID;
                                }

                                //image
                                if (s_FileName.Length > 0)
                                {
                                    FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                    img = new Byte[fs.Length];
                                    fs.Read(img, 0, (int)fs.Length);
                                    fs.Close();
                                }
                                else if (user.Image != null && user.Image.Length > 0)
                                {
                                    img = user.Image;
                                }
                                user.Image = img;
                                user.Update();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillDetails(clsSecurity.UserIDLoged);
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (txtPassword.Enabled)
                                {
                                    txtPassword.SelectAll();
                                    txtPassword.Focus();
                                }
                            }
                        }

                        if (bPinChange)
                        {
                            if (CheckPinNumberValidity(clsSecurity.decryptPassword(user.Password2), txtOldPin.Text.Trim()))
                            {
                                user.Password2 = clsSecurity.encryptPassword(txtNewPin.Text.Trim());
                                user.Update();

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillDetails(clsSecurity.UserIDLoged);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Go
        private void btnGo_Click(object sender, EventArgs e)
        {
            //    if (txtAddress.TextLength > 0)
            //           GoToWebpage(txtAddress.Text.Trim());
        }
        #endregion

        #region Load Image
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

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtUserID.Clear();
            //   txtAddress.Clear();
            txtPassword.Clear();
            txtPassword1.Clear();
            txtPassword2.Clear();
            txtUserName.Clear();

            txtNewPin.Clear();
            txtOldPin.Clear();

            s_FileName = "";
            pbxImage.Image = Digiteq.Properties.Resources.no_image;
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sUserID)
        {
            ClearFields();
            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sUserID);
            if (detail != null)
            {
                txtUserID.Text = detail.User_ID;
                txtUserName.Text = detail.UserName;

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
        #endregion

        #region Check Validity
        private bool ValidateChangePassword()
        {
            bool bChangePassword = false;
            if (txtPassword1.TextLength > 0)
            {
                if (txtPassword2.TextLength == 0)
                    MessageBox.Show("Please Re Type New Password, in the Re-Enter Password Field", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (String.Compare(txtPassword1.Text.Trim(), txtPassword2.Text.Trim(), false) == 0)
                    bChangePassword = true;
                else
                    MessageBox.Show("New Passwords are Not Matching", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return bChangePassword;
        }

        private bool CheckPinNumberValidity()
        {
            bool bStatus = true;

            if (txtOldPin.TextLength != 4 && txtNewPin.TextLength != 4)
            {
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show("PIN Number must be included 4 digits", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckPinNumberValidity(string OldDbPin, string OldPin)
        {
            bool bStatus = true;

            if (string.Compare(OldDbPin, OldPin, true) != 0)
            {
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show("Invalid PIN Number", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtOldPin.Enabled)
                {
                    txtOldPin.SelectAll();
                    txtOldPin.Focus();
                }
            }

            return bStatus;
        }
        #endregion

        #region Events DocumentCompleted
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //    txtAddress.Text = webBrowser1.Url.ToString();
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events Navigating
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
        }
        #endregion

        #region Events ProgressChanged
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                //progressBar1.Value = (int)e.CurrentProgress;
            }
            catch (Exception) { }
        }
        #endregion

        #region Events KeyDown
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //    if (txtAddress.TextLength > 0)
                //         GoToWebpage(txtAddress.Text.Trim());
            }
        }
        #endregion

        #region Go To Webpage
        private void GoToWebpage(string sUrl)
        {
            if (!sUrl.StartsWith("http://") &&
               !sUrl.StartsWith("https://"))
            {
                sUrl = "http://" + sUrl;
            }

            //webBrowser1.Navigate(new Uri(sUrl));
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            //open a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            //openFileDialog.Filter = "Webpages|*.html|All Files|*.*";         
            openFileDialog.Title = "Open Webpage";
            // if (openFileDialog.ShowDialog(this) == DialogResult.OK)          
            //      webBrowser1.DocumentText = System.IO.File.ReadAllText(openFileDialog.FileName);            
        }

        private void btnUpdateTheme_Click(object sender, EventArgs e)
        {
            int Theme_id = 0;
            if (rdoMetro.Checked)
                Theme_id = 1;

        
            var result = oData.Save_Theme_ID(txtUserID.Text.Trim(), Theme_id);
            if (result.IsSuccess)
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
