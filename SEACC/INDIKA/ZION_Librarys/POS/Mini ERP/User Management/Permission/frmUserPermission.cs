using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmUserPermission : MettroForm
    {
        #region  Variables
        //to manage update and insert
        static bool IsUpdate = false;
        public bool bNoAccess;
        public int iFormID;

        string sFinalQuary = "";
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable(); 
        #endregion

        #region Form Load
        public frmUserPermission()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.UserPermission);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmUserPermission_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAdmin;

            //clsFormatter.ApplyGridFormatModify(dgvDetail);
            CreateDataTable();
            ClearFields();
            dgvDetail.DataSource = source;
        }

        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save      
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        ValidateEmptyForeignKey();
                        if (txtUserID.TextLength > 0)
                        {
                            if (IsUpdate)  //update records
                            {
                                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                                {
                                    try
                                    {
                                        string sFormCode = dgvDetail["FormCode", x].Value.ToString();
                                        bool bAllowRead = bool.Parse(dgvDetail["AllowRead", x].Value.ToString()),
                                            bAllowWrite = bool.Parse(dgvDetail["AllowWrite", x].Value.ToString()),
                                            bAllowDelete = bool.Parse(dgvDetail["AllowDelete", x].Value.ToString()),
                                            bAllowUpdate = bool.Parse(dgvDetail["AllowUpdate", x].Value.ToString()),
                                            bAllowCheckable = bool.Parse(dgvDetail["AllowCheckable", x].Value.ToString()),
                                            bAllowApprovable = bool.Parse(dgvDetail["AllowApprovable", x].Value.ToString());

                                        tbl_securityUserPermission oldRecord = tbl_securityUserPermission.Select(txtUserID.Tag.ToString(), int.Parse(sFormCode), txtCompany.Tag.ToString(), txtBranch.Tag.ToString());
                                        if (oldRecord != null)
                                        {
                                            tbl_securityUserPermission oldRecordNew = new tbl_securityUserPermission(txtUserID.Tag.ToString(),
                                               int.Parse(sFormCode), txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowRead, bAllowWrite, bAllowDelete, bAllowApprovable, bAllowCheckable, bAllowUpdate, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateDeleted);
                                            oldRecordNew.Update();
                                        }
                                        else
                                        {
                                            tbl_securityUserPermission detail = new tbl_securityUserPermission(txtUserID.Tag.ToString(),
                                                int.Parse(sFormCode), txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowRead, bAllowWrite, bAllowDelete, bAllowApprovable, bAllowCheckable, bAllowUpdate, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                            detail.Insert();
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show(ex.Message);
                                    } //if last raw is null
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else  //insert records
                            {
                                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                                {
                                    try
                                    {
                                        string sFormCode = dgvDetail["FormCode", x].Value.ToString();
                                        bool bAllowRead = bool.Parse(dgvDetail["AllowRead", x].Value.ToString()),
                                            bAllowWrite = bool.Parse(dgvDetail["AllowWrite", x].Value.ToString()),
                                            bAllowDelete = bool.Parse(dgvDetail["AllowDelete", x].Value.ToString()),
                                            bAllowUpdate = bool.Parse(dgvDetail["AllowUpdate", x].Value.ToString()),
                                            bAllowCheckable = bool.Parse(dgvDetail["AllowCheckable", x].Value.ToString()),
                                            bAllowApprovable = bool.Parse(dgvDetail["AllowApprovable", x].Value.ToString());

                                        tbl_securityUserPermission detail = new tbl_securityUserPermission(txtUserID.Tag.ToString(),
                                            int.Parse(sFormCode), txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowRead, bAllowWrite, bAllowDelete, bAllowApprovable, bAllowCheckable, bAllowUpdate, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                        detail.Insert();
                                    }
                                    catch (Exception) { } //if last raw is null
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtUserID.Tag != null && txtUserID.Tag.ToString().Trim().Length > 0)
                        {
                            txtUserTemplate.Tag = null;
                            txtUserTemplate.Clear();
                            FillDetailsUser(txtUserID.Tag.ToString(), false);
                        }
                    }
                }
            }
        }
        #endregion       

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;           

            //txtUserID.Tag = null;
            txtUserID.Tag = null;           
            txtDepartment.Tag = null;
            txtUserLevel.Tag = null;
            txtCategory.Tag = null;
            txtUserTemplate.Tag = null;
            txtCompany.Tag = null;
            txtBranch.Tag = null;

            txtUserID.Clear();
            txtUserTemplate.Clear();
            txtDepartment.Clear();
            txtUserLevel.Clear();
            txtUserName.Clear();
            txtCategory.Clear();
            txtFormName.Clear();
            txtCompany.Clear();
            txtBranch.Clear();
            dtAllRecodes.Clear();            
            
            source.RemoveFilter();
            txtUserID.ReadOnly = true;

            chkIsUser.Checked = true;
            chkApprovableAll.Checked = false;
            chkCheckableAll.Checked = false;
            chkDeleteAll.Checked = false;
            chkNone.Checked = false;
            chkReadAll.Checked = false;
            chkWriteAll.Checked = false;
            chkEditAll.Checked = false;

            FillDataGrid();

            if (txtUserID.Enabled)
            {
                txtUserID.SelectAll();
                txtUserID.Focus();
            }

            txtCompany.Tag = clsSecurity.CompanyID;
            txtCompany.Text = clsGenaralName.getName_Company(clsSecurity.CompanyID);
            txtBranch.Tag = clsSecurity.BranchID;
            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
        }
        #endregion

        #region Fill Data Grid
        private void FillDataGrid()
        {                 
            dtAllRecodes.Clear();
            dtAllRecodes.Merge(DBHandling.ExecQuery("exec sp_FormMasterLoad").Tables[0]);
            source.DataSource = dtAllRecodes;

            #region old
            //List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAll();
            //foreach (tbl_securityFormMaster detail in details)
            //{
            //    int iFormId = detail.Form_ID;
            //    string sFormName, sCategoryId;
            //    bool bAllowRead, bAllowWrite, bAllowDelete, bAllowEdit, bAllowCheckable, bAllowApprovable;

            //    if (detail != null && detail.IsEnable)
            //    {
            //        iFormId = detail.Form_ID;
            //        sFormName = clsGenaralName.getName_FormMaster(detail.Form_ID);
            //        sCategoryId = detail.FormCategory_ID;
            //        bAllowRead = false;
            //        bAllowWrite = false;
            //        bAllowDelete = false;
            //        bAllowCheckable = false;
            //        bAllowApprovable = false;
            //        bAllowEdit = false;

            //        dtAllRecodes.Rows.Add(iFormId, sFormName, sCategoryId, bAllowRead, bAllowWrite, bAllowDelete, bAllowEdit, bAllowCheckable, bAllowApprovable);
            //    }
            //}
            //source.DataSource = dtAllRecodes; 
            #endregion
        }

        private void FillDetailsUser(string sUserID,bool bIsTemplate)
        {
            if (sUserID.Length > 0)
            {
                if (!bIsTemplate)
                {
                    tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sUserID);
                    if (detail != null)
                    {
                        txtUserID.Text = detail.User_ID;
                        txtUserName.Text = detail.UserName;
                        txtDepartment.Text = clsGenaralName.getName_UserDepartment(detail.Group_ID);
                        txtUserLevel.Text = clsGenaralName.getName_Group(detail.Group_ID);
                        txtUserLevel.Tag = detail.Group_ID;
                    }
                }

                List<tbl_securityUserPermission> permission = tbl_securityUserPermission.SelectAllByUser_ID(sUserID);
                if (permission.Count > 0)
                {
                    IsUpdate = true;
                    RefreshGrid_UserPermission(sUserID);
                }
                else
                {
                    IsUpdate = false;
                    FillDataGrid();
                }
            }
        }

        private void FillDetailsRole(string sRoleID)
        {
            if (sRoleID.Length > 0)
            {
                tbl_securityUserRole detail = tbl_securityUserRole.Select(sRoleID);
                if (detail != null)
                {
                    txtUserID.Text = detail.UserRole_ID;
                    txtUserName.Text = detail.UserRoleName;
                    txtDepartment.Clear();
                    txtUserLevel.Clear();
                    txtUserLevel.Tag = null;
                }

                List<tbl_securityUserRole_Permission> permission = tbl_securityUserRole_Permission.SelectAllByUserRole_ID(sRoleID);
                if (permission.Count > 0)
                {
                    IsUpdate = true;
                    RefreshGrid_RolePermission(sRoleID);
                }
                else
                {
                    IsUpdate = false;
                    FillDataGrid();
                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_UserPermission(string sUserID)
        {
            dtAllRecodes.Clear();
            dtAllRecodes.Merge(DBHandling.ExecQuery("exec sp_FormMasterLoad_Permission '" + clsSecurity.CompanyID + "','" + clsSecurity.BranchID + "','" + sUserID + "'").Tables[0]);
            source.DataSource = dtAllRecodes;           

            #region old
            //dtAllRecodes.Clear();
            //dgvDetail.DataSource = source;
            //int iFormId;
            //string sFormName = "", sCategoryId = "";
            //bool bAllowRead, bAllowWrite, bAllowDelete, bAllowUpdate, bAllowCheckable, bAllowApprovable;

            //List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAll();
            //foreach (tbl_securityFormMaster detail in details)
            //{
            //    if (detail != null && detail.IsEnable)
            //    {
            //         iFormId = detail.Form_ID;
            //         sFormName = detail.FormName;
            //         sCategoryId = detail.FormCategory_ID;
            //         tbl_securityUserPermission permission = tbl_securityUserPermission.Select(sUserID, detail.Form_ID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString());
            //        if (permission != null)
            //        {
            //            bAllowRead = permission.AllowRead;
            //            bAllowWrite = permission.AllowWrite;
            //            bAllowDelete = permission.AllowDelete;
            //            bAllowCheckable = permission.AllowCheckable;
            //            bAllowApprovable = permission.AllowApprovable;
            //            bAllowUpdate = permission.AllowUpdate;
            //        }
            //        else
            //        {
            //            bAllowRead = false;
            //            bAllowWrite = false;
            //            bAllowDelete = false;
            //            bAllowUpdate = false;
            //            bAllowCheckable = false;
            //            bAllowApprovable = false;
            //        }
            //        dtAllRecodes.Rows.Add(iFormId, sFormName, sCategoryId, bAllowRead, bAllowWrite, bAllowDelete, bAllowUpdate, bAllowCheckable, bAllowApprovable);
            //    }
            //}
            //source.DataSource = dtAllRecodes;            
            #endregion
        }

        private void RefreshGrid_RolePermission(string sRoleID)
        {
            dtAllRecodes.Clear();
            dgvDetail.DataSource = source;
            List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAll();
            foreach (tbl_securityFormMaster detail in details)
            {
                if (detail != null)
                {

                    int iFormId = detail.Form_ID;
                    string sFormName, sCategoryId;
                    bool bAllowRead, bAllowWrite, bAllowDelete, bAllowCheckable, bAllowApprovable;//bAllowUpdate,

                    tbl_securityUserRole_Permission permission = tbl_securityUserRole_Permission.Select(sRoleID, detail.Form_ID);
                    iFormId = detail.Form_ID;
                    sFormName = clsGenaralName.getName_FormMaster(detail.Form_ID);
                    sCategoryId = detail.FormCategory_ID;

                    if (permission != null)
                    {
                        bAllowRead = permission.AllowRead;
                        bAllowWrite = permission.AllowWrite;
                        bAllowDelete = permission.AllowDelete;
                        //bAllowUpdate = permission.all
                        bAllowApprovable = permission.AllowApprovable;
                        bAllowCheckable = permission.AllowCheckable;
                    }
                    else
                    {
                        bAllowRead = false;
                        bAllowWrite = false;
                        bAllowDelete = false;
                 //       bAllowUpdate = false;
                        bAllowApprovable = false;
                        bAllowCheckable = false;
                    }
                }
            }
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("FormCode", typeof(int));
            dtAllRecodes.Columns.Add("FormName", typeof(string));
            dtAllRecodes.Columns.Add("formCategory_ID", typeof(string));
            dtAllRecodes.Columns.Add("AllowRead", typeof(bool));
            dtAllRecodes.Columns.Add("AllowWrite", typeof(bool));
            dtAllRecodes.Columns.Add("AllowDelete", typeof(bool));
            dtAllRecodes.Columns.Add("AllowUpdate", typeof(bool));
            dtAllRecodes.Columns.Add("AllowCheckable", typeof(bool));
            dtAllRecodes.Columns.Add("AllowApprovable", typeof(bool));
        }
        #endregion


        #region Events Keydown
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtUserID_DoubleClick(null, null);
        }

        private void txtUserTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtUserTemplate_DoubleClick(null, null);
        }

        private void frm_sasInquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_SecurityFormCategory(ref txtCategory);

                if (txtCategory != null)
                    if (CheckValidity())
                        RefreshGrid_UserPermission(txtUserID.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
            if (chkIsUser.Checked)
                Search_UserID();
            else
                Search_RoleID();
        }
        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_SecurityFormCategory(ref txtCategory);
            if (txtCategory.Tag != null)
                createFilterQuary();
        }
        private void txtUserTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (txtUserID.Tag != null)
                Search_UserId_Temolate();
        }
        #endregion

        #region Events Datagrid
        private void SeachItemDetail(int ColumnIndex, int RowIndex)
        {
            if (ColumnIndex == 0)
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    dgvDetail["ItemName", RowIndex].Value = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    dgvDetail["ItemCode", RowIndex].Value = frmSearchMaster.s_SearchID;
                    dgvDetail["Quantity", RowIndex].Value = "1";
                    dgvDetail["Remark", RowIndex].Value = "";
                }
            }
            if (ColumnIndex == 1)
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    dgvDetail["ItemName", RowIndex].Value = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    dgvDetail["ItemCode", RowIndex].Value = frmSearchMaster.s_SearchID;
                    dgvDetail["Quantity", RowIndex].Value = "1";
                    dgvDetail["Remark", RowIndex].Value = "";
                }
            }
            if (ColumnIndex == 2)
            {
                string sItemCode = "";
                try
                {
                    sItemCode = dgvDetail["ItemCode", RowIndex].Value.ToString();
                }
                catch (Exception) { }
                if (sItemCode.Length <= 0)
                    MessageBox.Show("Please Select the Item Code or Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Events CheckChange
        private void chkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNone.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    dgvDetail["AllowRead", x].Value = false;
                    dgvDetail["AllowWrite", x].Value = false;
                    dgvDetail["AllowDelete", x].Value = false;
                    dgvDetail["AllowApprovable", x].Value = false;
                    dgvDetail["AllowCheckable", x].Value = false;
                    dgvDetail["AllowUpdate", x].Value = false;
                }
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    dgvDetail["AllowRead", x].Value = true;
                    dgvDetail["AllowWrite", x].Value = true;
                    dgvDetail["AllowDelete", x].Value = true;
                    dgvDetail["AllowApprovable", x].Value = true;
                    dgvDetail["AllowCheckable", x].Value = true;
                    dgvDetail["AllowUpdate", x].Value = true;
                }
            }
        }

        private void chkReadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkReadAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowRead", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowRead", x].Value = true;
            }
        }

        private void chkWriteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkWriteAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowWrite", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowWrite", x].Value = true;
            }
        }

        private void chkDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDeleteAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowDelete", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowDelete", x].Value = true;
            }
        }

        private void chkEditAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEditAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowUpdate", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowUpdate", x].Value = true;
            }
        }
        private void chkCheckableAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCheckableAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowCheckable", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowCheckable", x].Value = true;
            }
        }

        private void chkApprovableAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkApprovableAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowApprovable", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowApprovable", x].Value = true;
            }
        }
        #endregion

        #region Event key Up
        private void txtFormName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary();
        }
        #endregion
       

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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtUserID);            
        }
        #endregion

        #region Search Methods
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
                    FillDetailsUser(frmSearchMaster.s_SearchID,false);
                }
            }
        }
        private void Search_UserId_Temolate()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_User(true);
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtUserTemplate.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtUserTemplate.Tag = frmSearchMaster.s_SearchID;
                    FillDetailsUser(frmSearchMaster.s_SearchID,true);
                }
            }
        }

        private void Search_RoleID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Role();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtUserID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtUserID.Tag = frmSearchMaster.s_SearchID;
                    FillDetailsRole(frmSearchMaster.s_SearchID);
                }
            }
        }
        #endregion

     
        #region BindingSource Filtering
        private void createFilterQuary()
        {
            // If Category selected
            if (txtCategory.Tag != null)
            {
                sFinalQuary = "formCategory_ID LIKE '%" + txtCategory.Tag.ToString() + "%'";

                if (txtFormName.TextLength > 0)
                    sFinalQuary += "AND formName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
            else
            {
                sFinalQuary = "formName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
        }
        #endregion

        private void txtCompany_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_Company(ref txtCompany);
        }

        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCompany_DoubleClick(null, null);
        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtBranch_DoubleClick(null, null);
        }
                       
    }
}