using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_Alert_EmailConfig : MettroForm
    {

        
        //to manage update and insert

        public string glbUserID = "";



        #region Form Load

        public frm_Alert_EmailConfig()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ConfigMail);
            iFormID = clsSecurity.getFormID(FormName.ConfigMail);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_EmailConfig_Load(object sender, EventArgs e)
        {
           // clsFormatter.setFormatForm(this, "Email Server Config", 2, iFormID);
            ClearFileds();
        } 

        #endregion

        #region Clear Fields

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFileds();
        } 

        #endregion

        #region Btn Delete

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        if (DialogResult.Yes == MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "User ID : " + txtUserID.Text.Trim()), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_utlEmailConfig detail = tbl_utlEmailConfig.Select(txtUserID.Text.Trim());
                            if (detail != null)
                            {
                                detail.Delete();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }
                        }                        
                    }
                }
            }
            catch(Exception ex)
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
        
        #region Btn Save

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {

                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        if (txtUserID.Text.Trim().Length > 0)
                        {
                            #region Update

                            if (IsUpdate)
                            {
                                tbl_utlEmailConfig oldRecords = tbl_utlEmailConfig.Select(txtUserID.Tag.ToString());
                                if (oldRecords != null)
                                {
                                    tbl_utlEmailConfig  detail = new tbl_utlEmailConfig(oldRecords.User_ID,txtEmailAddress.Text.Trim(),txtElies.Text.Trim(),clsGenaralName.getName_User(oldRecords.User_ID),
                                        clsSecurity.encryptPassword(txtPassword.Text.Trim()),txtSubject.Text.Trim(),txtBody.Text,txtSignature.Text,txtSmtpClient.Text.Trim(),int.Parse(txtSmtpPort.Text.Trim()));

                                    detail.Update(); 

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            } 

                            #endregion

                            #region Insert

                            else
                            {
                                 tbl_utlEmailConfig  detail = new tbl_utlEmailConfig(txtUserID.Tag.ToString(),txtEmailAddress.Text.Trim(),txtElies.Text.Trim(),clsGenaralName.getName_User(txtUserID.Tag.ToString()),
                                        clsSecurity.encryptPassword(txtPassword.Text.Trim()),txtSubject.Text.Trim(),txtBody.Text,txtSignature.Text,txtSmtpClient.Text.Trim(),int.Parse(txtSmtpPort.Text.Trim()));
                                detail.Insert();
                                 MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            #endregion
                        }
                    }
                    catch(Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        } 

        #endregion

        #region Clear Filed

        private void ClearFileds()
        {
            IsUpdate = false;
            txtUserID.Tag = null;

            txtUserID.Clear();
            txtEmailAddress.Clear();
            txtElies.Clear();
            txtPassword.Clear();
            txtSmtpClient.Clear();
            txtSmtpPort.Clear();
            txtSubject.Clear();
            txtSignature.Clear();
            txtBody.Clear();
        } 

        #endregion

        #region Fill Detail

        private void FillDetail(string sID)
        {
            IsUpdate = true;
            if (sID.Length > 0)
            {
                tbl_utlEmailConfig detail = tbl_utlEmailConfig.Select(sID);

                if (detail != null)
                {
                    txtUserID.Tag = detail.User_ID;
                    txtUserID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.User_ID));
                    txtEmailAddress.Text = detail.EmailAddress;
                    txtElies.Text = detail.EliesName;
                    txtPassword.Text = clsSecurity.decryptPassword(detail.EmailPassword);
                    txtSmtpPort.Text = detail.SmtpPort.ToString();
                    txtSmtpClient.Text = detail.SmtpClient;
                    txtSubject.Text = detail.EmailSubject;
                    txtSignature.Text = detail.EmailSignature;
                    txtBody.Text = detail.EmailBody;
                }
            }
        }   

        #endregion  

        #region Events Double Clicks

        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterUser(ref txtUserID);
            if (txtUserID.Tag != null)
            {
                FillDetail(txtUserID.Tag.ToString());
            }
        } 

        #endregion

        #region Check Validity

        private bool CheckValidity()
        {
            string strMassage = "";
            bool bStatus = true;

            if (txtUserID.Text.Trim().Length == 0)
            {
                strMassage += "User ID";
                bStatus = false;
            }

            if (txtEmailAddress.Text.Trim().Length == 0)
            {
                strMassage += "\n " + "Email Address";
                bStatus = false;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                strMassage += "\n " + "Password";
                bStatus = false;
            }

            if (txtElies.Text.Trim().Length == 0)
            {
                strMassage += "\n " + "Elies";
                bStatus = false;
            }
            if (txtSmtpPort.Text.Trim().Length == 0)
            {
                strMassage += "\n " + "SMTP Port";
                bStatus = false;
            }
            if (txtSmtpClient.Text.Trim().Length == 0)
            {
                strMassage += "\n " + "SMTP Client";
                bStatus = false;
            }
            if (!bStatus)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMassage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        } 
        #endregion      

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserID.Tag != null)
            {
                //clsProcessMethods.SendMail(txtUserID.Tag.ToString(), "coo-vijitha@digiteq.biz", "");
            }
        }  

    }
}