using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmSelectSection : Form
    {
        #region Variable
        public static string sApprovedUserName;
        public static string sApprovedUserID;
        public static bool bChecked;
        public static bool bReset;
        public static bool bCancel;
       public int iFormID;
        public static List<string> sectionList; 
        #endregion

        #region frmSelectSection
        public frmSelectSection()
        {
            sApprovedUserName = "";
            sApprovedUserID = "";
            bChecked = false;
            bReset = false;
            InitializeComponent();
        } 
        #endregion

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            DataGridViewFormat();
            RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            sectionList =new List<string>();
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if(row.Cells["Select"].Value.ToString()=="True")
                    sectionList.Add(row.Cells["Section"].Value.ToString());
            }
            this.Close();
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion      

        #region Refresh grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genSectionMaster> details = tbl_genSectionMaster.SelectAll();
                foreach (tbl_genSectionMaster detail in details)
                {
                    if (detail.Section_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["Section", iRow].Value = detail.SectionName;
                        dgvDetail["Section", iRow].Tag = detail.Section_ID;
                        dgvDetail["Select", iRow].Value = false;
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


        #region Btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            bReset = true;
            this.Close();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {

        }
        #endregion

        #region CheckedChanged 
        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dgvDetail["Select", row.Index].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dgvDetail["Select", row.Index].Value = false;
                }
            }
        }
        
        #endregion

        #region Datagrid Format
        private void DataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

    }
}
