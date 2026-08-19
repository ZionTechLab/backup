using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class SEACC_Form : UserControl
    {
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;

        public DateTime glbApprovedDate;
        public DateTime glbCheckedDate;

        public bool IsUpdate = false;
        public int iFormID;
        public FormName enmForm;
        //  public bool bNoAccess;
        public string sFormConfigCode = "";
        public int sSlotID;
        public string Name;
        public Color UI_Color;

        public delegate void dBtnClick(object sender, EventArgs e);
        public event dBtnClick SF_newButton_Click;
        public event dBtnClick SF_saveButton_Click;
        public event dBtnClick SF_cancelButton_Click;
        public event dBtnClick SF_printButton_Click;
        public event dBtnClick SF_draftButton_Click;
        public event dBtnClick SF_checkButton_Click;
        public event dBtnClick SF_approveButton_Click;
        public event dBtnClick SF_History_Click;
        public event dBtnClick SF_tempButton_Click;

        public SEACC_Form()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            iFormID = clsSecurity.getFormID(enmForm);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToUpdate), iFormID + " - " + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Name = clsGenaralName.getName_FormMaster(iFormID);
            sFormConfigCode = clsAutocode.getFormConfigCode(enmForm);

            Attachments.iFormID = iFormID;
            glbApprovedDate = clsSecurity.getServerDateTime();
            glbCheckedDate = clsSecurity.getServerDateTime();
        }

        public void SetVisibility_ActionButons(bool button_New, bool button_Print, bool button_Draft, bool button_Save, bool button_Cancle, bool button_Approve, bool button_Check, bool button_Attachment, bool button_Temp)
        {
            if (!button_Print)
                btnPrint.Visible = false;
            if (!button_Draft)
                btnDraft.Visible = false;
            if (!button_New)
                btnNew.Visible = false;
            if (!button_Save)
                btnSave.Visible = false;
            if (!button_Cancle)
                btnCancel.Visible = false;
            if (!button_Approve)
                btnApproved.Visible = false;
            if (!button_Check)
                btnChecked.Visible = false;
            if (!button_Approve || !button_Check)
                btnUserDetails.Visible = false;
            if (!button_Attachment)
                Attachments.Visible = false;
            if (!button_Temp)
                btnTemp.Visible = false;
        }

        #region Event Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                SF_newButton_Click(sender, e);
                Attachments.btnAttachment.BackColor = Color.LightGray;
                Attachments.btnAttachment.ForeColor = Color.Maroon;
            }
            catch (Exception)
            { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SF_saveButton_Click(sender, e);
            }
            catch (Exception ex)
            { }
        } 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SF_cancelButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        private void btnPrt_Click(object sender, EventArgs e)
        {
            try
            {
                SF_printButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {
                SF_checkButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        private void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                SF_approveButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            try
            {
                SF_History_Click(sender, e);
            }
            catch (Exception)
            { }

        }
        private void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                SF_draftButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        private void btnTemp_Click(object sender, EventArgs e)
        {
            try
            {
                SF_tempButton_Click(sender, e);
            }
            catch (Exception)
            { }
        }
        #endregion

        #region User Details Color Changes
        public void userDetailsColorChanges()
        {
            if (bHasApproved)
            {
                this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
                this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
                btnApproved.Enabled = false;
                btnChecked.Enabled = false;

            }
            if (bHasChecked)
            {
                this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
                btnChecked.Enabled = false;
            }
            if (!bHasApproved && !bHasChecked)
            {
                this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
                this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
                this.btnApproved.BackColor = System.Drawing.Color.LightGray;
                this.btnChecked.BackColor = System.Drawing.Color.LightGray;
                btnApproved.Enabled = true;
                btnChecked.Enabled = true;
            }
        }
        #endregion

        public virtual void SettingsClick()
        { }

        //public void ButtonsStyle(Color color)
        //{
        //    btnApproved.ForeColor = color;
        //    btnNew.ForeColor = color;
        //    btnCancel.ForeColor = color;
        //    btnSave.ForeColor = color;
        //    btnPrint.ForeColor = color;
        //    btnChecked.ForeColor = color;
        //    btnApproved.ForeColor = color;
        //    btnDraft.ForeColor = color;
        //    btnUserDetails.ForeColor = color;

        //    btnApproved.FlatAppearance.BorderColor = color;
        //    btnNew.FlatAppearance.BorderColor = color;
        //    btnCancel.FlatAppearance.BorderColor = color;
        //    btnSave.FlatAppearance.BorderColor = color;
        //    btnPrint.FlatAppearance.BorderColor = color;
        //    btnChecked.FlatAppearance.BorderColor = color;
        //    btnApproved.FlatAppearance.BorderColor = color;
        //    btnDraft.FlatAppearance.BorderColor = color;
        //    btnUserDetails.FlatAppearance.BorderColor = color;
        //}

    }
}