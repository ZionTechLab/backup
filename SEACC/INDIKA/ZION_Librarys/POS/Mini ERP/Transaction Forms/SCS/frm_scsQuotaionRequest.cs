using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;


namespace Digiteq
{
    public partial class frm_scsQuotaionRequest : Form
    {
        #region Variables
        //to manage update and insert
      //  static bool IsUpdate = false;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
     //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
     //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        public frm_scsQuotaionRequest()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsQuotaionRequest);
            iFormID = clsSecurity.getFormID(FormName.scsQuotaionRequest);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasQuotaionRequest_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Sales Quotation Request Form", 2, iFormID);
            CusDataGridViewFormat(); 
        }

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

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
            //try
            //{
            //    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
            //    {
            //        if (txtAccountReceiptID.Text != null && txtAccountReceiptID.TextLength > 0)
            //        {
            //            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (msgResult == DialogResult.Yes)
            //            {
            //                frmSetApproved login = new frmSetApproved();
            //                login.iFormID = iFormID;
            //                login.userID = clsSecurity.UserIDLoged;
            //                login.ShowDialog();
            //                if (frmSetApproved.bChecked)
            //                {
            //                    bHasApproved = true;
            //                    glbApprovedDate = clsSecurity.getServerDateTime();
            //                    if (IsUpdate)
            //                    {
            //                        userDetailsColorChanges();

            //                        tbl_accAccountReceipt objDO = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
            //                        if (objDO != null)
            //                        {
            //                            objDO.IsApproved = true;
            //                            objDO.DateApproved = clsSecurity.getServerDateTime();
            //                            objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
            //                            objDO.Update();
            //                        }
            //                    }
            //                }
            //                else if (frmSetApproved.bReset)
            //                    bHasApproved = false;
            //            }
            //        }
            //        else
            //            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    }
            //    else
            //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void Search_CheckedBy()
        {
            //try
            //{
            //    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
            //    {
            //        if (txtAccountReceiptID.Text != null && txtAccountReceiptID.TextLength > 0)
            //        {
            //            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (msgResult == DialogResult.Yes)
            //            {
            //                frmSetChecked login = new frmSetChecked();
            //                login.iFormID = iFormID;
            //                login.userID = clsSecurity.UserIDLoged;
            //                login.ShowDialog();
            //                if (frmSetChecked.bChecked)
            //                {
            //                    bHasChecked = true;
            //                    glbCheckedDate = clsSecurity.getServerDateTime();

            //                    if (IsUpdate)
            //                    {
            //                        userDetailsColorChanges();

            //                        tbl_accAccountReceipt objDO = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
            //                        if (objDO != null)
            //                        {
            //                            objDO.IsChecked = true;
            //                            objDO.DateChecked = clsSecurity.getServerDateTime();
            //                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
            //                            objDO.Update();
            //                        }
            //                    }

            //                }
            //                else if (frmSetChecked.bReset)
            //                    bHasChecked = false;
            //            }
            //        }
            //        else
            //            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    }
            //    else
            //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            //if (txtAccountReceiptID.Text != "" || txtAccountReceiptID.Text != "<Auto Generate>")
            //{
            //    tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text);
            //    if (detail != null)
            //    {
            //        DataTable dt_UserDetails = new DataTable();
            //        dt_UserDetails.Columns.Add("usertype", typeof(string));
            //        dt_UserDetails.Columns.Add("Column1", typeof(string));
            //        dt_UserDetails.Columns.Add("user", typeof(string));
            //        dt_UserDetails.Columns.Add("Column2", typeof(string));
            //        dt_UserDetails.Columns.Add("datetime", typeof(string));

            //        dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

            //        if (detail.DateCreate != detail.DateModified)
            //            dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

            //        if (detail.IsChecked)
            //            dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

            //        if (detail.IsApproved)
            //            dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

            //        if (detail.IsDeleted)
            //            dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

            //        Point startPoint = this.PointToScreen(new Point());

            //        frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
            //        frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
            //    }
            //}
        }

        #region User Details Color Changes
        private void userDetailsColorChanges()
        {
            if (bHasApproved)
            {
                btnApproved.Enabled = false;
                btnChecked.Enabled = false;
                this.btnApproved.ForeColor = System.Drawing.Color.FromArgb(3, 87, 11);
                this.btnChecked.ForeColor = System.Drawing.Color.DarkGray;
                //this.btnApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(87)))), ((int)(((byte)(11)))));

            }
            if (bHasChecked)
            {
                btnChecked.Enabled = false;
                this.btnChecked.ForeColor = System.Drawing.Color.FromArgb(3, 87, 11);
                //this.btnChecked.ForeColor = System.Drawing.SystemColors.Gray;
            }
            if (!bHasApproved && !bHasChecked)
            {
                btnApproved.Enabled = true;
                btnChecked.Enabled = true;
                this.btnApproved.ForeColor = System.Drawing.Color.Red;
                this.btnChecked.ForeColor = System.Drawing.Color.Red;
                this.btnApproved.BackColor = System.Drawing.Color.White;
                this.btnChecked.BackColor = System.Drawing.Color.White;
            }
        }
        #endregion
        #endregion
    }
}
