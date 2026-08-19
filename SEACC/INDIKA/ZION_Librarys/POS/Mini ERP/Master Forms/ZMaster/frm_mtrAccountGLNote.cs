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
    public partial class frm_mtrAccountGLNote : Form
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
        public frm_mtrAccountGLNote()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accGLNote);
            iFormID = clsSecurity.getFormID(FormName.accGLNote);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
            rdoBalanceSheet.Select();
        }
        private void frmItemMaster_Load(object sender, EventArgs e)
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
                if (txtGLNoteID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                     //   tbl_accGLMaster_Note detail = tbl_accGLMaster_Note.Select(txtGLNoteID.Text.Trim());
                      //  if (detail != null)
                        {
                      //      detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
                    }
                  
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                Cursor = Cursors.Default;
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 1)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
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
                if (CheckNumberValidity())
                {
                   if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;                            
                            if (txtGLNoteID.TextLength > 0)
                            {                               
                                if (IsUpdate)  //update records
                                {
                                  //  tbl_accGLMaster_Note oldRecord = tbl_accGLMaster_Note.Select(txtGLNoteID.Text.Trim());
                                 //   if (oldRecord != null)                                    
                                    {
                                        //GLNote Header
                                        //tbl_accGLMaster_Note detail = new tbl_accGLMaster_Note(txtGLNoteID.Text.Trim(), txtGLNoteName.Text.Trim().ToUpper(), oldRecord.GlAccountType_ID, oldRecord.GlSubCatagory_ID, oldRecord.GlMainCatagory_ID, rdoBalanceSheet.Checked, rdoProfitAndLost.Checked);
                                        //tbl_accGLMaster_Note detail = new tbl_accGLMaster_Note(txtGLNoteID.Text.Trim(), txtGLNoteName.Text.Trim().ToUpper(), "default", "default", "default", rdoBalanceSheet.Checked, rdoProfitAndLost.Checked);
                                        //detail.Update();
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                        
                                }
                                else  //insert records
                                {
                                  //  tbl_accGLMaster_Note oldRecordPure = tbl_accGLMaster_Note.Select(txtGLNoteID.Text.Trim());
                                  //  List<tbl_accGLMaster_Note> oldRecord = tbl_accGLMaster_Note.SelectAll();
                                  //  foreach (tbl_accGLMaster_Note Record in oldRecord)
                                   {
                                       //if (txtGLNoteName.Text.Trim().ToUpper() == Record.GlNoteName.ToUpper())
                                       //{
                                       //    MessageBox.Show("This GLNote is already exists", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                       //    return;
                                       //}                                      
                                       
                                   }

                                   if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                       txtGLNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                   //Inquiry Header
                                   
                                   //tbl_accGLMaster_Note detail = new tbl_accGLMaster_Note(txtGLNoteID.Text.Trim(), txtGLNoteName.Text.Trim().ToUpper(), "default", "default", "default", rdoBalanceSheet.Checked, rdoProfitAndLost.Checked);
                                   //detail.Insert();

                                   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("GLNote " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGLNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblGLNoteID, true);           
           
            txtGLNoteName.Clear();
            
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGLNoteID.Text = "<Auto Generate>";
            else
                txtGLNoteID.Clear();
            if (txtGLNoteID.Enabled)
            {
                txtGLNoteID.SelectAll();
                txtGLNoteID.Focus();
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

                List<tbl_accGLMaster_Note> details = tbl_accGLMaster_Note.SelectAll();
                foreach (tbl_accGLMaster_Note detail in details)
                {
                    //if (detail.GlNote_ID.Trim() != "default")
                    //{
                    //    dgvDetail.Rows.Add();
                    //    iRow = dgvDetail.Rows.Count - 1;
                    //    dgvDetail["glNote_ID", iRow].Value = detail.GlNote_ID;
                    //    dgvDetail["glNoteName", iRow].Value = detail.GlNoteName;
                        
                    //}
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
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                  //  tbl_accGLMaster_Note detail = tbl_accGLMaster_Note.Select(sID);
                  //  if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                     //   clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGLNoteID, false);
                        //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtglAccountType_ID, false);
                        //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtglSubCatagory_ID, false);
                        //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtglMainCatagory_ID, false);
                     //   clsCommon.SetEnableDisable_NormalLabel(lblGLNoteID, false);

                        //asign values
                     //   txtGLNoteID.Text = detail.GlNote_ID;
                     //   txtGLNoteName.Text = detail.GlNoteName;
                        //txtglAccountType_ID.Text = clsGenaralName.getName_SubGL(detail.GlAccountType_ID);
                        ////txtglAccountType_ID.Text = clsGenaralName.getName_GlAccountType(detail.GlAccountType_ID);
                        ////txtglSubCatagory_ID.Text = clsGenaralName.getName_GLSubCatagory(detail.GlSubCatagory_ID);
                        ////txtglMainCatagory_ID.Text = clsGenaralName.getName_GLMainCatagory(detail.GlMainCatagory_ID);
                       // if (detail.IsBalanceSheet)
                      //      rdoBalanceSheet.Select();
                      //  else if (detail.IsProfitAndLost)
                      //      rdoProfitAndLost.Select();

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

            if (txtGLNoteName.TextLength == 0)
            {
                strMessage += "\n" + "GL Note Name ";
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

        #region Events KeyDown
        private void txtGLNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtGLNoteID_DoubleClick(sender, e);
            }   
        }

        private void frm_accGLNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        #region Events DoubleClick
        private void txtGLNoteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.SearchMaster_GLNoteID(ref txtGLNoteID);
            if (txtGLNoteID.Tag != null)
            {
                txtGLNoteName.Text = txtGLNoteID.Text;
                txtGLNoteID.Text = txtGLNoteID.Tag.ToString();
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
                    string sID = dgvDetail["glNote_ID", e.RowIndex].Value.ToString();
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

        

      
        


      















    }
}
