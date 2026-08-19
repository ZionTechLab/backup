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

namespace Digiteq
{
    public partial class frm_mtrReportExpenditureNameSearch : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        //string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        List<string> expenditureID;
        public static string s_SearchText="";
        public static string s_SearchID="";


        #region Form Load
        public frm_mtrReportExpenditureNameSearch(List<string> exID)
        {
            iFormID = clsSecurity.getFormID(FormName.accReportBuilder);
            expenditureID = new List<string>();
            expenditureID = exID;
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrReportExpenditureNameSearch_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format
            RefreshGrid();
            CusDataGridViewFormat();
            ClearFields();         
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                s_SearchText = "";
                s_SearchID = "";
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            
                   if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            //Cursor = Cursors.Default;
                            //ClearFields();
                            //RefreshGrid();
                        }
                    }
            
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
             List<tbl_accGLMaster> details;

            if (txtSearch.Text.Trim().Length > 0)
                details = tbl_accGLMaster.SelectAll().Where(p=> p.GlName.Contains(txtSearch.Text.ToUpper())).ToList();
            else
                details = tbl_accGLMaster.SelectAll();
           
            foreach (tbl_accGLMaster detail in details)
            {
                bool isOk = true;
                if (detail.Gl_ID.Trim() != "default")
                {
                    foreach (string sCatID in expenditureID)
                    {
                        if (sCatID == detail.Gl_ID)                        
                            isOk = false;
                    }
                    if (isOk)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["ExpenditureCode", iRow].Value = detail.Gl_ID;
                        dgvDetail["ExpenditureType", iRow].Value = detail.GlName;
                    }
                }
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try

            {
                if (sID.Length > 0)
                {
                    tbl_accGLMaster detail = tbl_accGLMaster.Select(sID);
                    if (detail != null)
                    {                      
                        s_SearchID = detail.Gl_ID;
                        s_SearchText = detail.GlName;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["ExpenditureCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim());
                    }
                } 
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
            btnSave_Click(sender, e);
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Key Press
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        } 
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

    }
}
