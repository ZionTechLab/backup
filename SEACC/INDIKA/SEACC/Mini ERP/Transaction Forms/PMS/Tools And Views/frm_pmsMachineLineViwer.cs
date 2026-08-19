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
    public partial class frm_pmsMachineLineViwer : Form
    {

        
        //to manage update and insert
        //static bool IsUpdate = false;

        //to keep form detail       
        //string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        public string glbMachineID = "";
      

        #region Form Load
        public frm_pmsMachineLineViwer()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCombinationMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            ClearFields();
            if (glbMachineID.Length > 0)
            {
                FillDetails(glbMachineID);
            }
            CusDataGridViewFormat();
        } 
        #endregion


        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbMachineID.Length > 0)
                FillDetails(glbMachineID);
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailSection, Color.FromArgb(240, 190, 210), Color.FromArgb(99, 50, 50));
       
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblMaintainCycle.Text = "";
            lblMachineName.Text = "";
            lblMaxOutPutCapacityPeerHour.Text = "";
            lblMachineDisciption.Text = "";
            lblMachineCostPerHoures.Text = "";
            lblMinOutPutCapacityPeerHour.Text = "";
            lblAllowedOutputWatage.Text = "";
            lblAllowedStartUpWatage.Text = "";
            lblMaintainCycle.Text = "";
            lblElectercityConsumption.Text = "";
            lblMinOutPutCapacityPeerHour.Text = ""; 
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sMachineID)
        {
            tbl_genMachineMaster machine = tbl_genMachineMaster.Select(sMachineID);
            if (machine != null)
            {
                lblMachineName.Text = machine.MachineName;
                lblMachineDisciption.Text = machine.Description;
            }

            //List<tbl_pmsWorkInProgress_Machine_Shedule> details = tbl_pmsWorkInProgress_Machine_Shedule.SelectAll();
            //int iRow;
            //dgvDetailSection.Rows.Clear();
            //foreach (tbl_pmsWorkInProgress_Machine_Shedule detail in details)
            //{
            //    if (detail.Machine_ID == sMachineID)
            //    {
            //        dgvDetailSection.Rows.Add();
            //        iRow = dgvDetailSection.Rows.Count - 1;
            //        RefreshGridShedule(iRow, detail.DateStart, detail.DateEnd);
            //    }
            //}
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridShedule(int iRow,DateTime startDate,DateTime endDate)
        {
            try
            {
                dgvDetailSection["StartDate", iRow].Value = startDate.ToShortDateString();
                dgvDetailSection["StartTime", iRow].Value = startDate.ToShortTimeString();
                dgvDetailSection["EndDate", iRow].Value = endDate.ToShortDateString();
                dgvDetailSection["EndTime", iRow].Value = endDate.ToShortTimeString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        
        #endregion

    }
}
