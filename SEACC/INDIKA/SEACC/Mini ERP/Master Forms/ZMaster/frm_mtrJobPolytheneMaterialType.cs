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
    public partial class frm_mtrJobPolytheneMaterialType : MettroForm
    {


        #region Form Load 
        public frm_mtrJobPolytheneMaterialType()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.JobPolytheneMeterialType);
            iFormID = clsSecurity.getFormID(FormName.JobPolytheneMeterialType);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrJobPolytheneMaterialType_Load(object sender, EventArgs e)
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
                if (txtJobPolythenMaterialTypeID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zJobPolytheneMaterialType detail = tbl_zJobPolytheneMaterialType.Select(txtJobPolythenMaterialTypeID.Text.Trim());
                        if (detail != null)
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "Job polythene meterial code : " + detail.PolytheneMaterailType_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                            if (msgResult == DialogResult.Yes)
                            {
                                detail.Delete();
                                Cursor = Cursors.Default;
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                                RefreshGrid();
                            }
                        }


                    }
                    else //if no permission to delete
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                ClearFields();
                RefreshGrid();
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Btn Save 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtJobPolythenMaterialTypeID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                    tbl_zJobPolytheneMaterialType oldRecord = tbl_zJobPolytheneMaterialType.Select(txtJobPolythenMaterialTypeID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zJobPolytheneMaterialType detail = new tbl_zJobPolytheneMaterialType(txtJobPolythenMaterialTypeID.Text.Trim(), txtPolytheneMaterailTypeName.Text.Trim(), decimal.Parse(txtDencity.Text));
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtJobPolythenMaterialTypeID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zJobPolytheneMaterialType detail = new tbl_zJobPolytheneMaterialType(txtJobPolythenMaterialTypeID.Text.Trim(), txtPolytheneMaterailTypeName.Text.Trim(), decimal.Parse(txtDencity.Text));
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Job Polythen Material " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //set the flag and enble the id

            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJobPolythenMaterialTypeID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJobPolytheneMaterialTypeID, true);

            txtPolytheneMaterailTypeName.Clear();
            txtDencity.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtJobPolythenMaterialTypeID.Text = "<Auto Generate>";
            else
                txtJobPolythenMaterialTypeID.Clear();

            if (txtJobPolythenMaterialTypeID.Enabled)
            {
                txtJobPolythenMaterialTypeID.SelectAll();
                txtJobPolythenMaterialTypeID.Focus();
            }
            //txtClassID.Text = "ok";
        }
        #endregion

        #region Refresh Grid 
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
            List<tbl_zJobPolytheneMaterialType> details = tbl_zJobPolytheneMaterialType.SelectAll();
            foreach (tbl_zJobPolytheneMaterialType detail in details)
            {
                if (detail.PolytheneMaterailType_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["polytheneMaterailType_ID", iRow].Value = detail.PolytheneMaterailType_ID;
                    dgvDetail["polytheneMaterailTypeName", iRow].Value = detail.PolytheneMaterailTypeName;
                    dgvDetail["Dencity", iRow].Value = detail.Dencity.ToString("0.000");
                }
            }
        }
        #endregion

        #region Fill Details 
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_zJobPolytheneMaterialType detail = tbl_zJobPolytheneMaterialType.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJobPolythenMaterialTypeID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblJobPolytheneMaterialTypeID, false);

                    //asign values
                    txtJobPolythenMaterialTypeID.Text = detail.PolytheneMaterailType_ID;
                    txtPolytheneMaterailTypeName.Text = detail.PolytheneMaterailTypeName;
                    txtDencity.Text = detail.Dencity.ToString("0.000");
                }
            }
        }
        #endregion

        #region Check Validity 
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtPolytheneMaterailTypeName.Text.Trim().Length == 0)
            {
                strMessage += "\n" + "Polythene Material Type Name";
                bStatus = false;
                txtPolytheneMaterailTypeName.Focus();                
            }
            else if (txtDencity.TextLength == 0)
            {
                strMessage += "\n" + "Dencity Value ";
                bStatus = false;
                txtDencity.Focus();
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


        #region Event KeyDown 
        private void txtJobPolythenMaterialTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterJobPolytheneMaterialType(ref txtJobPolythenMaterialTypeID);
                if (txtJobPolythenMaterialTypeID.Tag != null)
                    FillDetails(txtJobPolythenMaterialTypeID.Tag.ToString());
            }
        }

        private void frm_mtrJobPolytheneMaterialType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterJobPolytheneMaterialType(ref txtJobPolythenMaterialTypeID);
                if (txtJobPolythenMaterialTypeID.Tag != null)
                    FillDetails(txtJobPolythenMaterialTypeID.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick 
        private void txtJobPolythenMaterialTypeID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterJobPolytheneMaterialType(ref txtJobPolythenMaterialTypeID);
            if (txtJobPolythenMaterialTypeID.Tag != null)
                FillDetails(txtJobPolythenMaterialTypeID.Tag.ToString());
        }        
        #endregion

        #region Event DataGrid 
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["polytheneMaterailType_ID", e.RowIndex].Value.ToString();
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
        } 
        #endregion

        #region Event key Press 
        private void txtDencity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 3);
        } 
        #endregion

        

        
        


    }
}
