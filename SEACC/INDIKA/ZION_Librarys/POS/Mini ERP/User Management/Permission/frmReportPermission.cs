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
    public partial class frmReportPermission : MettroForm
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
        public frmReportPermission()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.ReportPermission);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAdmin;
            //format Form
            clsFormatter.setFormatForm(this, "Report Permission", 1,0);

            //add data to the datagrid and format            
            // CusDataGridViewFormat();
            CreateDataTable();
            ClearFields();            
            dgvDetail.DataSource = source;
            //RefreshGrid();
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

        #region Btn Delete

        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                // if (CheckNumberValidity())
                // {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (txtUserID.TextLength > 0)
                    {
                        if (IsUpdate)  //update records
                        {
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sReportID = row.Cells["ReportID"].Value.ToString();
                                    bool bAllowView = clsValidate.ValidateRowValue(row, "AllowView", false),
                                           bAllowPrint = clsValidate.ValidateRowValue(row, "AllowPrint", false),
                                           bAllowRePrint = clsValidate.ValidateRowValue(row, "AllowRePrint", false),
                                           bAllowExport = clsValidate.ValidateRowValue(row, "AllowExport", false),
                                           bEnableDefaultPrinter = clsValidate.ValidateRowValue(row, "EnableDefaultPrinter", false),
                                           bPrintOriginal = clsValidate.ValidateRowValue(row, "PrintOriginal", false);

                                    tbl_securityReportPermission oldRecord = tbl_securityReportPermission.Select(txtUserID.Tag.ToString(), sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString());
                                    if (oldRecord != null)
                                    {
                                        tbl_securityReportPermission oldRecordNew = new tbl_securityReportPermission(txtUserID.Tag.ToString(),
                                           sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowPrint, bAllowRePrint, bAllowExport, bAllowView, bEnableDefaultPrinter, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateDeleted, bPrintOriginal);
                                        oldRecordNew.Update();
                                    }
                                    else
                                    {
                                        tbl_securityReportPermission detail = new tbl_securityReportPermission(txtUserID.Tag.ToString(),
                                            sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowPrint, bAllowRePrint, bAllowExport, bAllowView, bEnableDefaultPrinter, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bPrintOriginal);
                                        detail.Insert();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);

                                } //if last raw is null

                            }

                            //     for (int x = 0; x < dgvDetail.Rows.Count; x++)
                            // {
                            //try
                            //{
                            //    string sReportID = dgvDetail["ReportID", x].Value.ToString();
                            //    bool bAllowView = clsValidate.ValidateGridValue(dgvDetail, "AllowView", x, false), //bool.Parse(dgvDetail["AllowView", x].Value.ToString()),
                            //        bAllowPrint = clsValidate.ValidateGridValue(dgvDetail, "AllowPrint", x, false), // bool.Parse(dgvDetail["AllowPrint", x].Value.ToString()),
                            //        bAllowRePrint = clsValidate.ValidateGridValue(dgvDetail, "AllowRePrint", x, false), //bool.Parse(dgvDetail["AllowRePrint", x].Value.ToString()),
                            //        bAllowExport = clsValidate.ValidateGridValue(dgvDetail, "AllowExport", x, false), // bool.Parse(dgvDetail["AllowExport", x].Value.ToString()),
                            //        bEnableDefaultPrinter = clsValidate.ValidateGridValue(dgvDetail, "EnableDefaultPrinter", x, false), // bool.Parse(dgvDetail["EnableDefaultPrinter", x].Value.ToString());
                            //        bPrintOriginal = clsValidate.ValidateGridValue(dgvDetail, "PrintOriginal", x, false);

                            //    tbl_securityReportPermission oldRecord = tbl_securityReportPermission.Select(txtUserID.Tag.ToString(), sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString());
                            //    if (oldRecord != null)
                            //    {
                            //        tbl_securityReportPermission oldRecordNew = new tbl_securityReportPermission(txtUserID.Tag.ToString(),
                            //           sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowPrint, bAllowRePrint, bAllowExport, bAllowView, bEnableDefaultPrinter, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateDeleted, bPrintOriginal);
                            //        oldRecordNew.Update();
                            //    }
                            //    else
                            //    {
                            //        tbl_securityReportPermission detail = new tbl_securityReportPermission(txtUserID.Tag.ToString(),
                            //            sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowPrint, bAllowRePrint, bAllowExport, bAllowView, bEnableDefaultPrinter, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bPrintOriginal);
                            //        detail.Insert();
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);

                            //} //if last raw is null
                            //  }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else  //insert records
                        {
                            for (int x = 0; x < dgvDetail.Rows.Count; x++)
                            {
                                try
                                {
                                    string sReportID = dgvDetail["ReportID", x].Value.ToString();
                                    bool bAllowView = bool.Parse(dgvDetail["AllowView", x].Value.ToString()),
                                        bAllowPrint = bool.Parse(dgvDetail["AllowPrint", x].Value.ToString()),
                                        bAllowRePrint = bool.Parse(dgvDetail["AllowRePrint", x].Value.ToString()),
                                        bAllowExport = bool.Parse(dgvDetail["AllowExport", x].Value.ToString()),
                                        bEnableDefaultPrinter = bool.Parse(dgvDetail["EnableDefaultPrinter", x].Value.ToString()),
                                        bPrintOriginal = clsValidate.ValidateGridValue(dgvDetail, "PrintOriginal", x, false);


                                    tbl_securityReportPermission detail = new tbl_securityReportPermission(txtUserID.Tag.ToString(),
                                        sReportID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString(), bAllowPrint, bAllowRePrint, bAllowExport, bAllowView, bEnableDefaultPrinter, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bPrintOriginal);
                                    detail.Insert();
                                }
                                catch (Exception) { } //if last raw is null
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Report " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    {
                        txtUserTemplate.Tag = null;
                        txtUserTemplate.Clear();
                        FillDetailsUser(txtUserID.Tag.ToString(), false);
                    }
                }
                //  }
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
            
            chkEnableDFAll.Checked = false;
            chkRePrintAll.Checked = false;
            chkNone.Checked = false;
            chkViewAll.Checked = false;
            chkPrintAll.Checked = false;
            chkExportAll.Checked = false;
            chkPrintOriginal.Checked = false;

            FillDataGrid();

            if (txtUserID.Enabled)
            {
                txtUserID.SelectAll();
                txtUserID.Focus();
            }

            txtCompany.Tag = clsSecurity.CompanyID;
            txtCompany.Text = clsSecurity.CompanyName;//  clsGenaralName.getName_Company(clsSecurity.CompanyID);
            txtBranch.Tag = clsSecurity.BranchID;
            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
        }
        #endregion

        #region Fill Data Grid
        private void FillDataGrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dtAllRecodes.Clear();
                dgvDetail.DataSource = source;

                foreach (tbl_securityReportMaster detail in tbl_securityReportMaster.SelectAll())
                {
                 //   string iReportID = detail.Report_ID;
                  //  string  sReportCategory = "";//sReportName = "",
                    bool bAllowView = false, bAllowPrint = false, bAllowRePrint = false, bAllowExport = false, bEnableDefaultPrinter = false, bPrintOriginal = false;

                    if (detail.IsEnable)
                    {
                       // iReportID = detail.Report_ID;
                      //  sReportName = clsGenaralName.getName_ReportMaster(detail.Report_ID);
                       // sReportCategory = clsGenaralName.getName_ReportCategory(detail.ReportCategory_ID);

                        //bAllowView = false;
                        //bAllowPrint = false;
                        //bAllowRePrint = false;
                        //bAllowExport = false;
                        //bEnableDefaultPrinter = false;
                        //bPrintOriginal = false;

                        dtAllRecodes.Rows.Add(detail.Report_ID, detail.ReportName, detail.ReportCategory_ID, bAllowView, bAllowPrint, bAllowRePrint, bAllowExport, bEnableDefaultPrinter, bPrintOriginal);
                    }

                }
                source.DataSource = dtAllRecodes;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FillDetailsUser(string sUserID,bool bisTemplate)
        {
            if (sUserID.Length > 0)
            {
                if (!bisTemplate)
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
            dgvDetail.DataSource = source;
        //    string iRportID;
        //    string sReportName = "", sCategoryId = "";
            bool bAllowView=false, bAllowPrint = false, bAllowRePrint = false, bAllowExport = false, bEnableDefaultPrinter = false, bPrintOriginal = false;

            foreach (tbl_securityReportMaster detail in tbl_securityReportMaster.SelectAll())
            {
                if (detail.IsEnable)
                {
                 //   iRportID = detail.Report_ID;
                 //   sReportName = detail.ReportName;
                  //  sCategoryId = clsGenaralName.getName_ReportCategory(detail.ReportCategory_ID);

                    tbl_securityReportPermission permission = tbl_securityReportPermission.Select(sUserID, detail.Report_ID, txtCompany.Tag.ToString(), txtBranch.Tag.ToString());
                    if (permission != null)
                    {
                        bAllowView = permission.AllowView;
                        bAllowPrint = permission.AllowPrint;
                        bAllowRePrint = permission.AllowRePrint;
                        bAllowExport = permission.AllowExport;
                        bEnableDefaultPrinter = permission.IsEnableDefaultPrinter;
                        bPrintOriginal = permission.AllowPrintOriginal;
                    }
                    //else
                    //{
                    //    bAllowView = false;
                    //    bAllowPrint = false;
                    //    bAllowRePrint = false;
                    //    bAllowExport = false;
                    //    bEnableDefaultPrinter = false;
                    //    bPrintOriginal = false;
                    //}
                    dtAllRecodes.Rows.Add(detail.Report_ID, detail.ReportName, detail.ReportCategory_ID, bAllowView, bAllowPrint, bAllowRePrint, bAllowExport, bEnableDefaultPrinter, bPrintOriginal);
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
                    bool bAllowRead, bAllowWrite, bAllowDelete, bAllowUpdate, bAllowCheckable, bAllowApprovable;

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
                        bAllowUpdate = false;
                        bAllowApprovable = false;
                        bAllowCheckable = false;
                    }
                }
            }
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("ReportID", typeof(string));
            dtAllRecodes.Columns.Add("ReportName", typeof(string));
            dtAllRecodes.Columns.Add("ReportCategory", typeof(string));
            dtAllRecodes.Columns.Add("AllowView", typeof(bool));
            dtAllRecodes.Columns.Add("AllowPrint", typeof(bool));
            dtAllRecodes.Columns.Add("AllowRePrint", typeof(bool));
            dtAllRecodes.Columns.Add("AllowExport", typeof(bool));
            dtAllRecodes.Columns.Add("EnableDefaultPrinter", typeof(bool));
            dtAllRecodes.Columns.Add("PrintOriginal", typeof(bool));
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
                clsSearch.Search_MasterReportCategory(ref txtCategory);

                if (txtCategory != null)
                    if (CheckValidity())
                        RefreshGrid_UserPermission(txtUserID.Tag.ToString());
            }
        }
        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCompany_DoubleClick(null, null);
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtBranch_DoubleClick(null, null);
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
        private void txtUserTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (txtUserID.Tag != null)
                Search_UserID_Template();
        }
        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterReportCategory(ref txtCategory);
            if (txtCategory.Tag != null)
                createFilterQuary();
        }
        private void txtCompany_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_Company(ref txtCompany);
        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
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
                    dgvDetail["AllowView", x].Value = false;
                    dgvDetail["AllowPrint", x].Value = false;
                    dgvDetail["AllowRePrint", x].Value = false;
                    dgvDetail["AllowExport", x].Value = false;
                    dgvDetail["EnableDefaultPrinter", x].Value = false;
                    dgvDetail["PrintOriginal", x].Value = false;
                }
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    dgvDetail["AllowView", x].Value = true;
                    dgvDetail["AllowPrint", x].Value = true;
                    dgvDetail["AllowRePrint", x].Value = true;
                    dgvDetail["AllowExport", x].Value = true;
                    dgvDetail["EnableDefaultPrinter", x].Value = true;
                    dgvDetail["PrintOriginal", x].Value = false;
                }
            }
        }

        private void chkReadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkViewAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowView", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowView", x].Value = true;
            }
        }

        private void chkWriteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPrintAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowPrint", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowPrint", x].Value = true;
            }
        }

        private void chkDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRePrintAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowRePrint", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowRePrint", x].Value = true;
            }
        }

        private void chkEditAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkExportAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowExport", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["AllowExport", x].Value = true;
            }
        }
        private void chkCheckableAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEnableDFAll.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["EnableDefaultPrinter", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["EnableDefaultPrinter", x].Value = true;
            }
        }

        private void chkPrintOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPrintOriginal.Checked)
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["PrintOriginal", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    dgvDetail["PrintOriginal", x].Value = true;
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
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void Search_UserID_Template()
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
                sFinalQuary = "ReportCategory = '" + txtCategory.Tag.ToString() + "'";

                if (txtFormName.TextLength > 0)
                    sFinalQuary += "AND ReportName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
            else
            {
                sFinalQuary = "ReportName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        //    frmReportEnabler ofrmReportEnabler = new frmReportEnabler();
         //   ofrmReportEnabler.Show();
        }

    }
}
