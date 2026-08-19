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
    public partial class frmCheckingPermission : Form
    {

        #region  Variables
        //to manage update and insert
        static bool IsUpdate = false;
        string sFinalQuary = "";
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        public bool bNoAccess;
        public int iFormID;
        #endregion

        #region Form Load
        public frmCheckingPermission()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.UserPermission_PendingChecking);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }


            InitializeComponent();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "User Checking Permission", 1,0);

            //add data to the datagrid and format            
            CusDataGridViewFormat();
            CreateDataTable();
            ClearFields();            
            dgvDetail.DataSource = source;
            //RefreshGrid();
        } 
        #endregion


        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Btn Delete

        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
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
                                        bool bAllowRead = bool.Parse(dgvDetail["AllowRead", x].Value.ToString());

                                        tbl_securityCheckingPermission oldRecord = tbl_securityCheckingPermission.Select(txtUserID.Tag.ToString(), int.Parse(sFormCode));
                                        if (oldRecord != null)
                                        {
                                            tbl_securityCheckingPermission oldRecordNew = new tbl_securityCheckingPermission(txtUserID.Tag.ToString(), int.Parse(sFormCode), bAllowRead);
                                            oldRecordNew.Update();
                                        }
                                        else
                                        {
                                            tbl_securityCheckingPermission detail = new tbl_securityCheckingPermission(txtUserID.Tag.ToString(), int.Parse(sFormCode), bAllowRead);
                                            detail.Insert();
                                        }
                                    }
                                    catch (Exception) { } //if last raw is null
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
                                        bool bAllowRead = bool.Parse(dgvDetail["AllowRead", x].Value.ToString());

                                        tbl_securityCheckingPermission detail = new tbl_securityCheckingPermission(txtUserID.Tag.ToString(), int.Parse(sFormCode), bAllowRead);
                                        detail.Insert();
                                    }
                                    catch (Exception){} //if last raw is null
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
                        clsValidate.WriteErrorLog("", 0,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        if (txtUserID.Tag != null && txtUserID.Tag.ToString().Trim().Length > 0)
                            FillDetailsUser(txtUserID.Tag.ToString());
                    }
                }
            }
            
        }        
        #endregion



        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail);
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

            
            txtUserID.Clear();   
            txtDepartment.Clear();
            txtUserLevel.Clear();
            txtUserName.Clear();
            txtCategory.Clear();
            txtFormName.Clear();
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
        }

        
        #endregion

        #region Fill Data Grid
        private void FillDataGrid()
        {
            dtAllRecodes.Clear();
            dgvDetail.DataSource = source;
            List<tbl_securityProcessNoteMaster> details = tbl_securityProcessNoteMaster.SelectAll();
            foreach (tbl_securityProcessNoteMaster detail in details)
            {
                int iFormId = detail.ProcessNote_ID, iCategoryID = 0;
                string sFormName, sCategoryName;
                bool bAllowRead;

                if (detail != null)
                {
                    iFormId = detail.ProcessNote_ID;
                    sFormName = clsGenaralName.getName_ProcessNote(detail.ProcessNote_ID);
                    iCategoryID = detail.ProcessNoteCategory_ID;
                    sCategoryName = clsGenaralName.getName_ProcessNoteCategory(detail.ProcessNoteCategory_ID);
                    bAllowRead = false;                  

                    dtAllRecodes.Rows.Add(iFormId, sFormName, iCategoryID, sCategoryName, bAllowRead);
                }
            }
            source.DataSource = dtAllRecodes;

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
                    txtDepartment.Text = clsGenaralName.getName_UserDepartment(detail.Group_ID);
                    txtUserLevel.Text = clsGenaralName.getName_Group(detail.Group_ID);
                    txtUserLevel.Tag = detail.Group_ID;
                }

                List<tbl_securityCheckingPermission> permission = tbl_securityCheckingPermission.SelectAllByUser_ID(sUserID);
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
        #endregion

        #region Refresh Grid
        private void RefreshGrid_UserPermission(string sUserID)
        {
            dtAllRecodes.Clear();
            dgvDetail.DataSource = source;
            int iFormId, iCategoryId = 0;
            string sFormName = "", sCategoryName = "";
            bool bAllowRead;

            List<tbl_securityProcessNoteMaster> details = tbl_securityProcessNoteMaster.SelectAll();
            foreach (tbl_securityProcessNoteMaster detail in details)
            {
                if (detail != null)
                {
                     iFormId = detail.ProcessNote_ID;
                     sFormName = detail.ProcessNoteName;
                     iCategoryId = detail.ProcessNoteCategory_ID;
                     sCategoryName = clsGenaralName.getName_ProcessNoteCategory(detail.ProcessNoteCategory_ID);
                     tbl_securityCheckingPermission permission = tbl_securityCheckingPermission.Select(txtUserID.Tag.ToString(), detail.ProcessNote_ID);
                    if (permission != null)                    
                        bAllowRead = permission.IsAllow;                                          
                    else                    
                        bAllowRead = false;

                    dtAllRecodes.Rows.Add(iFormId, sFormName, iCategoryId, sCategoryName, bAllowRead);
                }
            }
            source.DataSource = dtAllRecodes;           
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
                        //bAllowUpdate = false;
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
            dtAllRecodes.Columns.Add("formCategory_ID", typeof(int));
            dtAllRecodes.Columns.Add("CategoryName", typeof(string));
            dtAllRecodes.Columns.Add("AllowRead", typeof(bool));            
        }
        #endregion


        #region Events Keydown
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (chkIsUser.Checked)
                    Search_UserID();
                else
                    Search_RoleID();
            }
        }
        private void frm_sasInquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_SecurityFormCategory(ref txtCategory);

                if (txtCategory != null)
                    if (CheckValidity())
                    {
                        RefreshGrid_UserPermission(txtUserID.Tag.ToString());
                    }
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
                clsValidate.WriteErrorLog("", 0,ex);
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
                   FillDetailsUser(frmSearchMaster.s_SearchID);
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
                    //FillDetailsRole(frmSearchMaster.s_SearchID);
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

        
 
    }
}
