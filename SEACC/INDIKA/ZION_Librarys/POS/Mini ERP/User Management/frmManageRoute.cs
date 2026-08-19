using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmManageRoute : Form
    {

        #region Variable
        //to manage update and insert
        static bool IsUpdate = false;
        static bool IsUpdateTown = false;
        static bool IsUpdateSchedule = false;
        string s_FileName;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frmManageRoute()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ManageRoute);
            iFormID = clsSecurity.getFormID(FormName.ManageRoute);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frmManageRoute_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Manage Route - [MRT]", 2, iFormID);
            ClearFields();
            CusDataGridViewFormat();
         
        }
        #endregion


        #region Btn Add Contact 1
        private void btnAddContact1_Click(object sender, EventArgs e)
        {
            if (CheckValidityTown())
            {
                int iRow;

                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                dgvDetail["RouteName", iRow].Value = txtRouteName.Text.Trim();
                dgvDetail["TwonName", iRow].Value = txtTown.Text.Trim();
                dgvDetail["TwonName", iRow].Tag = txtTown.Tag.ToString().Trim();

                ClearTown();
            }
        }
        #endregion

        #region btn Add Contact 2
        private void btnAddContact2_Click(object sender, EventArgs e)
        {
            if (CheckValiditySchedule())
            {
                int iRow;
                if (IsUpdateSchedule)
                    iRow = int.Parse(txtRowNo2.Text.Trim());
                else
                {
                    dgvSchedule.Rows.Add();
                    iRow = dgvSchedule.Rows.Count - 1;
                }
                dgvSchedule["ScheduleName", iRow].Value = txtScheduleName.Text.Trim();
                dgvSchedule["sRouteName", iRow].Value = txtRouteName.Text.Trim();
                dgvSchedule["StartTime", iRow].Value = dtpStartDate.Value.ToString();
                dgvSchedule["EndTime", iRow].Value = dtpEndDate.Value.ToString();
                ClearSchedule();
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                tbl_genRouteMaster detail = tbl_genRouteMaster.Select(txtRouteID.Text.Trim());
                if (detail != null && detail.Route_ID != "default")
                {
                    //delete old records
                    tbl_genRouteMaster_Town.DeleteAllByRoute_ID(detail.Route_ID);

                    //add new records
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        string sTownID = "";                        

                        sTownID = clsValidate.ValidateGridTag(dgvDetail, "TwonName", row.Index, "default");
                        if (sTownID.Length > 0 && sTownID != "default")
                        {
                            tbl_genRouteMaster_Town oTown = new tbl_genRouteMaster_Town(detail.Route_ID, sTownID, true);
                            oTown.Insert();
                        }
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                RefreshGridTownByRouteID(txtRouteID.Text);
            }

        }
        #endregion

        #region Btn Clear Town
        private void btnClearContact1_Click(object sender, EventArgs e)
        {
            ClearTown();
        }
        #endregion

        #region Btn Remove Town
        private void btnRemoveContact1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                    {
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
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

        #region Btn Clear Contact2
        private void btnClearContact2_Click(object sender, EventArgs e)
        {
            ClearSchedule();
        }
        #endregion



        #region Clear Field Contact
        private void ClearFields()
        {
            txtRouteID.Tag = null;
            txtScheduleName.Tag = null;
            txtTown.Tag = null;

            txtScheduleName.Clear();
            txtTown.Clear();
            txtRouteID.Clear();
            txtRouteName.Clear();

            dgvDetail.Rows.Clear();
            dgvSchedule.Rows.Clear();
            
        }
        private void ClearSchedule()
        {
            //set the flag and enble the id
            IsUpdateSchedule = false;
            txtScheduleName.Clear();
        }
        private void ClearTown()
        {
            //set the flag and enble the id
            IsUpdateTown = false;
            txtTown.Clear();
        }
        #endregion  

        #region Refresh Grid
        private void RefreshGridSchedule()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genRouteMaster_Schedule> details = tbl_genRouteMaster_Schedule.SelectAll();
                foreach (tbl_genRouteMaster_Schedule detail in details)
                {
                    if (detail.Route_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["RouteName", iRow].Value = clsGenaralName.getName_Route(detail.Route_ID);
                        dgvDetail["ScheduleName", iRow].Value = clsGenaralName.getName_Schedule(detail.Schedule_ID);
                        dgvDetail["RouteName", iRow].Tag = detail.Route_ID;
                        dgvDetail["ScheduleName", iRow].Tag = detail.Schedule_ID;
                        dgvDetail["StartTime", iRow].Value = detail.StartDate;
                        dgvDetail["EndTime", iRow].Value = detail.EndDate;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridTwon()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genRouteMaster_Town> details = tbl_genRouteMaster_Town.SelectAll();
                foreach (tbl_genRouteMaster_Town detail in details)
                {
                    if (detail.Route_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["RouteName", iRow].Value = clsGenaralName.getName_Route(detail.Route_ID);
                        dgvDetail["TwonName", iRow].Value = clsGenaralName.getName_Town(detail.Town_ID);
                        dgvDetail["RouteName", iRow].Tag = detail.Route_ID;
                        dgvDetail["TwonName", iRow].Tag = detail.Town_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridTownByRouteID(string sRouteID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genRouteMaster_Town> details = tbl_genRouteMaster_Town.SelectAllByRoute_ID(sRouteID);
                foreach (tbl_genRouteMaster_Town detail in details)
                {
                    if (detail.Route_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["RouteName", iRow].Value = clsGenaralName.getName_Route(detail.Route_ID);
                        dgvDetail["TwonName", iRow].Value = clsGenaralName.getName_Town(detail.Town_ID);
                        dgvDetail["RouteName", iRow].Tag = detail.Route_ID;
                        dgvDetail["TwonName", iRow].Tag = detail.Town_ID;
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

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1GridHeader, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvSchedule, clsFormatter.colorDigiteqTheamColorSales1GridHeader, clsFormatter.colorDigiteqTheamColorSales1ForColour); 
        }
        #endregion


        #region Key Down
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_Route();
        }
        private void txtScheduleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterSchedule(ref txtScheduleName);
            }
        }

      
        #endregion

        #region Double click
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            Search_Route();
        }
        private void txtTown_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionTown(ref txtTown);
        }     
        private void txtScheduleName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSchedule(ref txtScheduleName);
        }
        #endregion

        #region Check Validity
        private bool CheckValidityTown()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtTown.TextLength == 0 || txtTown.Tag == null)
            {
                strMessage += "\n" + "Town Name";
                bStatus = false;
            }
            if (txtRouteID.TextLength == 0)
            {
                strMessage += "\n" + "Route ID";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckValiditySchedule()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtScheduleName.TextLength == 0)
            {
                strMessage += "\n" + "Schedule  Name";
                bStatus = false;
            }
            if (txtRouteID.TextLength == 0)
            {
                strMessage += "\n" + "Route ID";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion


        #region Search Methods
        private void Search_Route()
        {
            clsSearch.Search_MasterRoute(ref txtRouteID);
            if (txtRouteID.Tag != null)
            {
                txtRouteID.Text = txtRouteID.Tag.ToString();
                txtRouteName.Text = clsGenaralName.getName_Route(txtRouteID.Tag.ToString());

                RefreshGridTownByRouteID(txtRouteID.Text.Trim());
            }
        }       
        #endregion

        private void txtTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionTown(ref txtTown);
            }
        }

      

      


    }
}
