using DataTire;
using Digiteq_Logic;

using SEACC.DATA.Data.CFG;
using SEACC.DATA.Domain.CFG;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.User_Management.Permission
{
    public partial class frm_RouteWiseUserPermission : MettroForm
    {
        #region  Variables
        static bool IsUpdate = false;
        public bool bNoAccess;
        public int iFormID;
        #endregion

        public frm_RouteWiseUserPermission()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.UserPermissionRouteWise);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

           

            InitializeComponent();
            dgvDetail.AutoGenerateColumns = false;
        }

        private void frm_RouteWiseUserPermission_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;

            txtUserID.Tag = null;
            txtUserID.Clear();
            txtUserName.Clear();

            txtUserID.ReadOnly = true;

            chkApprovableAll.Checked = false;
            chkCheckableAll.Checked = false;
            chkDeleteAll.Checked = false;
            chkAll.Checked = false;
            chkReadAll.Checked = false;
            chkWriteAll.Checked = false;
            chkEditAll.Checked = false;

            dgvDetail.DataSource = DBHandling.ExecQuery("exec sp_get_securityRoutePermission '" + "'").Tables[0];
        }


        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
            Search_UserID();
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
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtUserID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtUserID.Tag = frmSearchMaster.s_SearchID;
                    FillDetailsUser(frmSearchMaster.s_SearchID);
                }
            }
        }

        private void FillDetailsUser(string sUserID)
        {
            if (sUserID.Length > 0)
            {
                tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sUserID);
                if (detail != null)
                {
                    txtUserID.Text = detail.User_ID;
                    txtUserName.Text = detail.UserName;
                }

                dgvDetail.DataSource = DBHandling.ExecQuery("exec sp_get_securityRoutePermission '" + sUserID + "'").Tables[0];
            }
        }
        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtUserID.TextLength == 0)
            {
                strMessage += "\n" + "User Name ";
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

            try
            {

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        if (txtUserID.TextLength > 0)
                        {
                            var para = new List<tbl_securityRoutePermission>();

                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                var a = new tbl_securityRoutePermission()
                                {
                                    user_ID = txtUserID.Tag.ToString(),
                                    route_ID = clsValidate.ValidateGridValue(dgvDetail, "route_ID", row.Index, 0),
                                    allowRead = clsValidate.ValidateGridValue(dgvDetail, "allowRead", row.Index, false),
                                    allowWrite = clsValidate.ValidateGridValue(dgvDetail, "allowWrite", row.Index, false),
                                    allowDelete = clsValidate.ValidateGridValue(dgvDetail, "allowDelete", row.Index, false),
                                    allowUpdate = clsValidate.ValidateGridValue(dgvDetail, "allowUpdate", row.Index, false),
                                    allowCheckable = clsValidate.ValidateGridValue(dgvDetail, "allowCheckable", row.Index, false),
                                    allowApprovable = clsValidate.ValidateGridValue(dgvDetail, "allowApprovable", row.Index, false),
                                };
                                para.Add(a);
                            }
                            var oData = new securityRoutePermission();
                            var result = oData.Save(para);

                            if (result.IsSuccess)
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("User " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        var User_ID = txtUserID.Tag.ToString().Trim();


                        FillDetailsUser(User_ID);

                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                row.Cells["allowWrite"].Value = chkAll.Checked;
            }
        }
    }
}