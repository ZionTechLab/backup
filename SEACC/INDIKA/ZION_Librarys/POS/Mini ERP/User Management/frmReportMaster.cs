using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;


namespace Digiteq
{
    public partial class frmReportMaster : Form
    {
        
        #region Variables
        //to keep form detail  
        DataTable dt = new DataTable();
        BindingSource source = new BindingSource();
        string s_FileName;
        #endregion

        #region Form Load
        public frmReportMaster()
        {
            InitializeComponent();
        }

        private void frmReportMaster_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            dgvDetail.DataSource = source;
            ClearFields();

            //add data to the datagrid and format            
            RefreshGrid();
            CusDataGridViewFormat();   
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        ValidateEmptyForeignKey();
                        if (txtReportID.TextLength > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_securityReportMaster oldRecord = tbl_securityReportMaster.Select(txtReportID.Text.Trim());
                            if (oldRecord != null)
                            {                               
                                //update records
                                tbl_securityReportMaster detail = new tbl_securityReportMaster(txtReportID.Text.Trim(), int.Parse(txtOrder.Text.Trim()),
                                    txtReportName.Text.Trim(), txtReportCategory.Tag.ToString(), oldRecord.DisplayName,oldRecord.DisplayName2, oldRecord.ReportPath, chkActivate.Checked,
                                    chkSetPaper.Checked, chkSetPrinter.Checked, chkSetTerminal.Checked, chkSetUser.Checked, chkDefaultPrinter.Checked,oldRecord.PrintCount);
                                detail.Update();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", -1,ex);
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
        #endregion

        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Intialize Datatable
        private void CreateDataTable()
        {
            dt.Columns.Add("ReportID");
            dt.Columns.Add("ReportName");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("SortOrder");
            dt.Columns.Add("ReportCategory");
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id            
            txtReportID.Enabled = true;
            txtReportID.Clear();           
            txtReportCategory.Clear(); 
            txtReportName.Clear();
            txtReportName.Tag = null;
            txtReportCategory.Tag = null;

            txtOrder.Clear();

            s_FileName = "";           
            chkActivate.Checked = false;
            chkSetPaper.Checked = false;
            chkSetTerminal.Checked = false;
            chkSetPrinter.Checked = false;
            chkSetUser.Checked = false;
            chkDefaultPrinter.Checked = false;

            if (txtReportID.Enabled)
                txtReportID.Focus();

            source.Filter = string.Empty;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            //dgvDetail.Rows.Clear();
            dt.Clear();

            List<tbl_securityReportMaster> details = tbl_securityReportMaster.SelectAll();    
            foreach (tbl_securityReportMaster detail in details)
            {
                if(detail.ReportName!="default"){

                    //dgvDetail.Rows.Add();
                    //iRow = dgvDetail.Rows.Count - 1;
                    //dgvDetail["ReportID", iRow].Value = detail.Report_ID;
                    //dgvDetail["ReportName", iRow].Value = detail.ReportName;
                    //dgvDetail["DisplayName", iRow].Value = detail.DisplayName;
                    //dgvDetail["SortOrder", iRow].Value = detail.SortOrder.ToString();
                    //dgvDetail["ReportCategory", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ReportCategory(detail.ReportCategory_ID));

                    dt.Rows.Add(detail.Report_ID, detail.ReportName, detail.DisplayName, detail.SortOrder.ToString(), clsCommon.GetForeignKeyValue(clsGenaralName.getName_ReportCategory(detail.ReportCategory_ID)));
                }  
            }
            source.DataSource = dt;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string iFormID)
        {
            try
            {
                if (iFormID.Length > 0)
                {
                    tbl_securityReportMaster detail = tbl_securityReportMaster.Select(iFormID);
                    if (detail != null)
                    {
                        //asign values

                        txtReportID.Text = detail.Report_ID.ToString();
                        txtReportID.Tag = detail.Report_ID.ToString();
                        txtReportCategory.Tag = detail.ReportCategory_ID.ToString();
                        txtReportCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ReportCategory(detail.ReportCategory_ID));
                                
                        txtOrder.Text = detail.SortOrder.ToString();

                        chkActivate.Checked = detail.IsEnable;
                        chkSetPaper.Checked = detail.IsSetPaper;
                        chkSetPrinter.Checked = detail.IsSetPrinter;
                        chkSetTerminal.Checked = detail.IsSetTerminal;
                        chkSetUser.Checked = detail.IsSetUser;
                        chkDefaultPrinter.Checked = detail.IsDefaultPrinter;
                        
                        txtReportName.Tag = detail.Report_ID;
                        txtReportName.Text = detail.ReportName;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// " Please Enter the Details... ";
            bool bStatus = true;

            if (txtReportCategory.TextLength == 0)
            {
                strMessage += "\n" + "Report Name ";
                bStatus = false;
            }

            if (txtReportName.TextLength == 0)
            {
                strMessage += "\n" + "Report Category Name";
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
            string strMessage = " ";
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
            try
            {  
                clsCommon.ValidateForeignKey(ref txtReportName);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);           
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["ReportID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["ReportID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        } 
        #endregion

        #region Event Double Click
        private void txtReportID_DoubleClick(object sender, EventArgs e)
        {
            Search_Report();
        }

        private void txtReportName_DoubleClick(object sender, EventArgs e)
        {
            Search_Report();
        }

        private void txtReportCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_CategoryReport();
        } 
        #endregion

        #region Events Keydown
        private void txtReportID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Report();
            }
        }

        private void txtReportName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Report();
            }
        }

        private void txtReportCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CategoryReport();
            }
        }
        private void frmReportMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Event Keyup
        private void txtReportName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary();
        }
        #endregion

        #region Search Methods
        private void Search_CategoryReport()
        {
            clsSearch.Search_MasterReportCategory(ref txtReportCategory);
            createFilterQuary();
        }

        private void Search_Report()
        {
            clsSearch.Search_MasterReports(ref txtReportID);
            if (txtReportID.Tag != null && txtReportID.Tag.ToString().Trim().Length > 0)
            {
                FillDetails(txtReportID.Tag.ToString().Trim());
                createFilterQuary();
            }
        }
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary()
        {
            string sFinalQuary = "";
            source.Filter = string.Empty;

            if (txtReportCategory.Tag != null)
            {
                sFinalQuary = "ReportCategory LIKE '%" + txtReportCategory.Text.Trim() + "%'";

                if (txtReportName.TextLength > 0)
                    sFinalQuary += "AND ReportName LIKE '%" + txtReportName.Text.Trim() + "%'";

                source.Filter = sFinalQuary;
            }
            else
            {
                sFinalQuary = "ReportName LIKE '%" + txtReportName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
        }
        #endregion
    }
}