using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_masRouteMaster : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_masRouteMaster()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZRoute);
            iFormID = clsSecurity.getFormID(FormName.ZRoute);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrRoute_Load(object sender, EventArgs e)
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
                if (txtRouteID.TextLength > 0 && int.Parse(txtRouteID.Tag.ToString()) != -1)
                {
                    if (CheckValidity())
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_genRoute detail = tbl_genRoute.Select(int.Parse(txtRouteID.Tag.ToString()));
                            if (detail != null)
                            {
                                tbl_genRoute_Town.DeleteAllByRoute_ID(int.Parse(txtRouteID.Tag.ToString()));
                                detail.Delete();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtRouteID.Text, TxnActivity.Cancel);
                            }

                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }
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
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        if (txtRouteID.TextLength > 0)
                        {
                            if (IsUpdate)  //update records
                            {
                                tbl_genRoute oldRecord = tbl_genRoute.Select(int.Parse(txtRouteID.Tag.ToString()));
                                if (oldRecord != null)
                                {
                                    tbl_genRoute_Town.DeleteAllByRoute_ID(int.Parse(txtRouteID.Tag.ToString()));

                                    tbl_genRoute detail = new tbl_genRoute(int.Parse(txtRouteID.Tag.ToString()), txtRouteID.Text.Trim(), txtRouteName.Text.Trim());
                                    detail.Update();

                                    foreach (DataGridViewRow row in dgvTown.Rows)
                                    {
                                        string sTownID = clsValidate.ValidateGridTag(dgvTown, "TownID", row.Index, "default");
                                        tbl_genRoute_Town oTown = new tbl_genRoute_Town(int.Parse(txtRouteID.Tag.ToString()), sTownID);
                                        oTown.Insert();
                                    }
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtRouteID.Text, TxnActivity.Update);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else  //insert records
                            {
                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    txtRouteID.Tag = clsAutocode.getAutoGeneratedCode_Number(sFormConfigCode).ToString();

                                //Inquiry Header
                                tbl_genRoute detail = new tbl_genRoute(int.Parse(txtRouteID.Tag.ToString()), txtRouteID.Text.Trim(), txtRouteName.Text.Trim());
                                detail.Insert();

                                foreach (DataGridViewRow row in dgvTown.Rows)
                                {
                                    string sTownID = clsValidate.ValidateGridTag(dgvTown, "TownID", row.Index, "default");
                                    tbl_genRoute_Town oTown = new tbl_genRoute_Town(int.Parse(txtRouteID.Tag.ToString()), sTownID);
                                    oTown.Insert();
                                }
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtRouteID.Text, TxnActivity.Insert);
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Route" + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        ClearFields();
                        RefreshGrid();
                    }
                }
            }
        }
        #endregion

        #region Button Remove
        private void btnRemove_Click(object sender, EventArgs e)
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        #endregion

        #region Button Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTown);
            if (txtTown.Tag != null)
            {
                int iRow;
                dgvTown.Rows.Add();
                iRow = dgvTown.Rows.Count - 1;
                dgvTown["TownID", iRow].Tag = txtTown.Tag.ToString();
                dgvTown["TownID", iRow].Value = txtTown.Text;
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, clsFormatter.colorMasters);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvTown, clsFormatter.colorGrid, clsFormatter.colorMasters);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtRouteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRouteID, true);

            txtRouteName.Clear();
            txtRouteID.Tag = null;
            txtRouteID.Clear();

            dgvTown.Rows.Clear();

            if (txtRouteID.Enabled)
            {
                txtRouteID.SelectAll();
                txtRouteID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_genRoute> details = tbl_genRoute.SelectAll();
                foreach (tbl_genRoute detail in details)
                {
                    if (detail.Route_ID >= 0)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["RouteID", iRow].Value = detail.Route_ID;
                        dgvDetail["RouteCode", iRow].Value = detail.Route_Code;
                        dgvDetail["RouteName", iRow].Value = detail.RouteName;
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

        #region Fill Details
        private void FillDetails(int sID)
        {
            try
            {
                if (sID != -1 && sID != null)
                {
                    tbl_genRoute odetails = tbl_genRoute.Select(sID);
                    if (odetails != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtRouteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRouteID, false);

                        //asign values.
                        txtRouteID.Tag = odetails.Route_ID.ToString();
                        txtRouteID.Text = odetails.Route_Code;
                        txtRouteName.Text = odetails.RouteName;

                        int iRow;
                        dgvTown.Rows.Clear();
                        List<tbl_genRoute_Town> details = tbl_genRoute_Town.SelectAllByRoute_ID(odetails.Route_ID);
                        foreach (tbl_genRoute_Town detail in details)
                        {
                            dgvTown.Rows.Add();
                            iRow = dgvTown.Rows.Count - 1;
                            dgvTown["TownID", iRow].Tag = detail.Town_ID;
                            dgvTown["TownID", iRow].Value = clsGenaralName.getName_Town(detail.Town_ID);
                        }
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

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtRouteID.TextLength == 0)
                {
                    strMessage += "\n" + "Route Code ";
                    bStatus = false;
                }
                if (txtRouteName.TextLength == 0)
                {
                    strMessage += "\n" + "Route Name ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_RouteID();
            }
        }
        private void frm_mtrRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteID();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int sID = int.Parse(dgvDetail["RouteID", e.RowIndex].Value.ToString());
                    if (sID != -1 && sID != null)
                    {
                        FillDetails(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region Search Methods
        private void Search_RouteID()
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRouteID);
                if (txtRouteID.Tag != null)
                    FillDetails(int.Parse(txtRouteID.Tag.ToString()));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

    }
}
