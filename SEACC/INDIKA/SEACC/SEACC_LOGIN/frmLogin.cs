using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;
using System.Linq;

using SEACC_LOGIN;
using SEACC_LOGIN.Common;
using SEACC_LOGIN.DataTire;

namespace SEACC_LOGIN
{
    public partial class frmLogin : Form
    {
        
        public static string sConnection = "";
     

        #region Form Load
        public frmLogin()
        {
            InitializeComponent();

            this.BackColor = clsSecurity_Login.color;
            this.ActiveControl = txtUserName;
            txtUserName.Focus();

            Refresh_BranchCmb();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CheckValidityWorkStationBranch();
            //Program.IsLogOff = false;
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            bool bStatus = true;
            try
            {
                Cursor = Cursors.WaitCursor;

                if (CheckValidityUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    if (txtCompanyBranchID.Tag != null)
                    {
                        if (CheckValidity_Branch(txtCompanyBranchID.Tag.ToString()))
                        {
                            if (bStatus)
                            {
                                Program.IsLoginOk = true;
                                Savetolog(true, "Correctly Login");
                                this.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    Savetolog(false, "Username or password wrong");
                }

            }
            catch (Exception ex)
            {
                Savetolog(false, ex.Message);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Login Audit
        void Savetolog(bool bLoginStatus, string sMessege)
        {
            string sPassword = (txtPassword.Text == "") ? "" : clsSecurity_Login.encryptPassword(txtPassword.Text);
            string sTerminalID = clsSecurity_Login.TerminalID;
            
            try
            {
                tbl_atlLoginAttempts oLogin = new tbl_atlLoginAttempts(sTerminalID, txtUserName.Text, sPassword, bLoginStatus, clsSecurity_Login.getServerDateTime(), sMessege);
                oLogin.Insert();
            }
            catch (Exception ex)
            {
                tbl_atlLoginAttempts oLogin = new tbl_atlLoginAttempts(sTerminalID, txtUserName.Text, sPassword, bLoginStatus, clsSecurity_Login.getServerDateTime(), ex.Message.ToString());
                oLogin.Insert();
            }
        }
        #endregion

        #region Btn Cancel
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Program.IsLoginOk = false;
            this.Dispose();
            Application.Exit();
        }
        #endregion

        #region Events FormClosing
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.IsLoginOk = false;
            this.Dispose();
            Application.Exit();
        }
        #endregion

        #region Events Keydown
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnLogon_Click(sender, e);
        }
        #endregion

        #region Check Validity Branch
        private bool CheckValidity_Branch(string sBranchID)
        {
            bool bValid = false;
            try
            {
                if (sBranchID.Trim() != "default")
                {
                    tbl_genCompanyBranchMaster company = tbl_genCompanyBranchMaster.Select(txtCompanyBranchID.Tag.ToString());
                    if (company != null)
                    {
                        clsSecurity_Login.CompanyBranchID = company.CompanyBranch_ID;
                        bValid = true;
                    }
                }
                //if (!bValid)
                //{
                //    // MessageBox.Show("Invalid Branch Name", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                bValid = false;
                SEACCException.Show(ex);
                // clsValidate.WriteErrorLog("", 0,ex);
                //MessageBox.Show(ex.ToString());
                //  MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DataBaseError, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bValid;
        }
        #endregion

        #region Check Validity Username and Password
        private bool CheckValidityUsernameAndPassword(string sUserName, string sPassword)
        {
            bool bIsPass = false;
            try
            {
                if (txtUserName.TextLength > 0)
                {
                    tbl_securityUserMaster oUser = tbl_securityUserMaster.Select(sUserName);
                    if (oUser != null)
                    {
                        if (string.Compare(oUser.Password, clsSecurity_Login.encryptPassword(sPassword), true) == 0)
                        {
                            if (CheckValidityTerminal(oUser.User_ID))
                            {
                                if (oUser.IsBlocked)
                                {
                                    string sMsg = "This User account has been expired,  Please contact your Systems Administrator or email to sales@digiteq.biz";
                                    MessageBox.Show(sMsg, "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    //Username & ID
                                    clsSecurity_Login.UserIDLoged = oUser.User_ID;
                                    clsSecurity_Login.UserNameLoged = oUser.UserName;

                                    //User Group
                                    tbl_securityGroup grp = tbl_securityGroup.Select(oUser.Group_ID);
                                    clsSecurity_Login.UserGroupLoged = grp.GroupName;
                                    clsSecurity_Login.UserGroupIDLoged = oUser.Group_ID;

                                    bIsPass = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You don't have valid session", "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password", "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (txtPassword.Enabled)
                            {
                                txtPassword.SelectAll();
                                txtPassword.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserID", "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txtUserName.Enabled)
                        {
                            txtUserName.SelectAll();
                            txtUserName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                bIsPass = false;
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
            return bIsPass;
        }
        #endregion

        #region Check Validity Terminal
        private bool CheckValidityTerminal(string sUserID)
        {
            bool bStatus = false;
            try
            {
                //User, Terminal Session Index
                int iSession_Index = 0;

                tbl_securityTerminalMaster objTerminal = tbl_securityTerminalMaster.Select(clsSecurity_Login.TerminalID);
                if (objTerminal == null)
                {
                    tbl_securityTerminalMaster objTerminalNew = new tbl_securityTerminalMaster(clsSecurity_Login.TerminalID, clsSecurity_Login.HostName, clsSecurity_Login.IPAddress, clsSecurity_Login.MacAddress);
                    objTerminalNew.Insert();
                }

                var vUserLogins = tbl_utlUserPool.SelectAllByUser_ID(sUserID);
                tbl_utlUserPool oLastuPool = vUserLogins.Where(r => r.Terminal_ID == clsSecurity_Login.TerminalID).OrderByDescending(r => r.LogedTime).FirstOrDefault();
                if (oLastuPool != null)
                {
                    bool bPrev_UPool = SEACC_WPFControls.SEACCMessageBox.Show("Unclosed Previous Login Session Identified",
                        "Your last login time is " + oLastuPool.LogedTime.ToString("dddd, dd MMMM yyyy HH:mm")
                        + ".\nDo you want to close previous login sessions?", System.Windows.MessageBoxButton.OKCancel, "#FF5B6B76");

                    if (bPrev_UPool)
                    {
                        tbl_utlUserPool.DeleteAllByUser_ID(sUserID);
                    }
                    else
                    {
                        iSession_Index = vUserLogins.Max(r => r.Line_no) + 1;
                    }
                }

                tbl_utlUserPool uPoolNew = new tbl_utlUserPool(iSession_Index, sUserID, clsSecurity_Login.TerminalID, 1, "1", clsSecurity_Login.getServerDateTime(), false, false, true);
                uPoolNew.Insert();

                clsSecurity_Login.LoginSession_Index = iSession_Index.ToString();
                bStatus = true;


            }
            catch (Exception ex)
            {
                bStatus = false;
                clsValidate.WriteErrorLog("",-1,ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        #endregion

        #region Check Validity Workstation
        private void CheckValidityWorkStationBranch()
        {
            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(Program.sCompanyBranchID);
            if (oBranch != null && oBranch.IsHeadOffice)
            {
                cmbCompanyBranchID.Enabled = true;
                Refresh_BranchCmb();
            }
            else
            {
                cmbCompanyBranchID.Items.Clear();
                if (Program.sCompanyBranchID != "default")
                    cmbCompanyBranchID.Items.Add(new ComboBoxItem(Program.sCompanyBranchID, oBranch.BranchName));

                if (cmbCompanyBranchID.Items.Count > 0)
                    cmbCompanyBranchID.SelectedIndex = 0;

                cmbCompanyBranchID.Enabled = false;
            }
        }
        #endregion

        #region Combo Box Initialize and Events
        private void Refresh_BranchCmb()
        {
            cmbCompanyBranchID.Items.Clear();
            cmbCompanyBranchID.DisplayMember = "Value";
            cmbCompanyBranchID.ValueMember = "Text";
            List<tbl_genCompanyBranchMaster> branches = tbl_genCompanyBranchMaster.SelectAll();
            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                    cmbCompanyBranchID.Items.Add(new ComboBoxItem(oDetail.CompanyBranch_ID, oDetail.BranchName));
            }
            if (cmbCompanyBranchID.Items.Count > 0)
                cmbCompanyBranchID.SelectedIndex = 0;
        }

        private void cmbCompanyBranchID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCompanyBranchID.Tag = ((ComboBoxItem)cmbCompanyBranchID.SelectedItem).Value;
        }

        public class ComboBoxItem
        {
            public string Value;
            public string Text;

            public ComboBoxItem(string val, string text)
            {
                Value = val;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        #endregion

    }
}

#region Password Reminder
//private bool CheckValidity_PasswordReminder()
//{
//    bool bReminder = false;
//    try
//    {
//        if (txtUserName.TextLength > 0)
//        {
//            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserName.Text.Trim());
//            if (detail != null)
//            {
//                DateTime dtLastPWChangedDateTime = detail.LastPWChangedDateTime;
//                DateTime dtToday = DateTime.Now;
//                double dTotal = (dtToday - dtLastPWChangedDateTime).TotalDays;

//                //if (dTotal >= 30)
//                //{
//                //DialogResult dr = MessageBox.Show("Please Change Your Password. \n We recommend you to change it now.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
//                //if (dr == DialogResult.OK)
//                //{
//                //    bReminder = true;
//                //    frmMyPortal frm = new frmMyPortal();
//                //    frm.Show();
//                //}
//                //else
//                //{
//                //    bReminder = false;
//                //}

//                //   DialogResult dr = SEACCReminderMessageBox.Show("Please Change Your Password.", "We recommend you to change it now.", clsFormatter.GetMessageCaption());
//                //   if (dr == DialogResult.OK)
//                // {
//                //      bReminder = true;
//                //     frmMyPortal frm = new frmMyPortal();
//                //    frm.Show();
//                // }
//                // else
//                // {
//                //     bReminder = false;
//                // }
//                //}
//            }
//            else
//            {
//                //     MessageBox.Show("Invalid UserID", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                if (txtUserName.Enabled)
//                {
//                    txtUserName.SelectAll();
//                    txtUserName.Focus();
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        //   clsValidate.WriteErrorLog(ex.Message);
//        //       SEACCException.Show(ex);
//    }

//    return bReminder;
//} 
#endregion