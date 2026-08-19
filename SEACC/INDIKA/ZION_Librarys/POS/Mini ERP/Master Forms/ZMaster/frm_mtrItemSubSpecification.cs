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
    public partial class frm_mtrItemSubSpecification : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        string sItemSubCategoryID = "";
           public int iFormID;
        public bool bNoAccess;
        string sSpecificationID ="";
        #endregion

        #region Form Load
        public frm_mtrItemSubSpecification()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZItemSubSpecification);
            iFormID = clsSecurity.getFormID(FormName.ZItemSubSpecification);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_mtrMachineType_Load(object sender, EventArgs e)
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
                if (txtCategoryID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zItemCategory_Sub_Specification detail = tbl_zItemCategory_Sub_Specification.Select(txtSubCategoryID.Tag.ToString(), sSpecificationID);
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
                    }
                    else //if no permission to delete
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (txtCategoryID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {

                                      foreach (DataGridViewRow row in dgvSpecification.Rows)
                                      {
                                          string  SpecificationID = "", SpecificationValue = "", sSubcategoryID ="";

                                          
                                          SpecificationID = clsValidate.ValidateGridTag(dgvSpecification, "SpecificationID", row.Index, "").Trim();
                                          SpecificationValue = clsValidate.ValidateGridValue(dgvSpecification, "SpecificationValue", row.Index, "");
                                          sSubcategoryID = clsValidate.ValidateGridValue(dgvSpecification, "SubCategoryID", row.Index, "");
                                          tbl_zItemCategory_Sub_Specification specification = new tbl_zItemCategory_Sub_Specification(sSubcategoryID, SpecificationID, SpecificationValue);

                                              if (dgvSpecification["SpecificationValue", row.Index].Tag.ToString() == "true")
                                                  specification.Update();
                                              else if (SpecificationValue != "")
                                                  specification.Insert();
                                    
                                      }
                                      MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else  //insert records
                                {
                               
                                    foreach (DataGridViewRow row in dgvSpecification.Rows)
                                    {
                                        string SpecificationID = "", SpecificationValue = "", sSubcategoryID = "";


                                        SpecificationID = clsValidate.ValidateGridTag(dgvSpecification, "SpecificationID", row.Index, "");
                                        sSubcategoryID = clsValidate.ValidateGridValue(dgvSpecification, "SubCategoryID", row.Index, "");
                                        SpecificationValue = clsValidate.ValidateGridValue(dgvSpecification, "SpecificationValue", row.Index, "");
                                        tbl_zItemCategory_Sub_Specification specification = new tbl_zItemCategory_Sub_Specification(SpecificationValue, SpecificationID, SpecificationValue);
                                        if (SpecificationValue != "")
                                        specification.Insert();
                           
                                    }
                                     
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Item Specification " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsFormatter.ApplyGridFormatModify(dgvSpecification);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCategoryID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSupplierTypeID, true);

            txtSubCategoryID.Tag = null;
            txtSubCategoryID.Clear();
            sItemSubCategoryID = "";
            //dgvSpecification.cl

            txtCategoryID.Clear();
              

            if (txtCategoryID.Enabled)
            {
                txtCategoryID.SelectAll();
                txtCategoryID.Focus();
            }

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvSpecification.Rows.Clear();
                List<tbl_zItemCategory_Sub_Specification> details = tbl_zItemCategory_Sub_Specification.SelectAll();
                foreach (tbl_zItemCategory_Sub_Specification detail in details)
                {
                    if (detail.ItemSepcification_ID.Trim() != "default")
                    {
                        dgvSpecification.Rows.Add();
                        iRow = dgvSpecification.Rows.Count - 1;
                        dgvSpecification["SpecificationID", iRow].Value = clsGenaralName.getName_SpesificationID(detail.ItemSepcification_ID);
                        dgvSpecification["SpecificationID", iRow].Tag = detail.ItemSepcification_ID;
                        dgvSpecification["SpecificationValue", iRow].Value = detail.SpecificationValue;
                        dgvSpecification["SubCategoryID", iRow].Value = detail.ItemCategorySub_ID;
                        dgvSpecification["SpecificationValue", iRow].Tag = "true";
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGrid_Specification(string sItemCategoryID, string sItemSubCategoryID)
        {
            try
            {
                int iRow;
                dgvSpecification.Rows.Clear();
                List<tbl_zItemSpecification> details = tbl_zItemSpecification.SelectAllByItemCategory_ID(sItemCategoryID);
                foreach (tbl_zItemSpecification detail in details)
                {
                    dgvSpecification.Rows.Add();
                    iRow = dgvSpecification.Rows.Count - 1;
                    tbl_zItemCategory_Sub_Specification specification = tbl_zItemCategory_Sub_Specification.Select(sItemSubCategoryID, detail.ItemSepcification_ID);
                    if (specification != null)
                    {
                        dgvSpecification["SpecificationValue", iRow].Value = specification.SpecificationValue;
                        dgvSpecification["SpecificationValue", iRow].Tag = "true";
                    }
                    else
                    {
                        dgvSpecification["SpecificationValue", iRow].Value = "";
                        dgvSpecification["SpecificationValue", iRow].Tag = "false";
                    }
                    dgvSpecification["SpecificationID", iRow].Value = clsGenaralName.getName_SpesificationID(detail.ItemSepcification_ID);
                    dgvSpecification["SpecificationID", iRow].Tag = detail.ItemSepcification_ID;
                    dgvSpecification["SubCategoryID", iRow].Value = sItemSubCategoryID;

                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }



        private void RefreshGrid_Specification(string sItemCategoryID)
        {
            try
            {
                int iRow;
                dgvSpecification.Rows.Clear();

                List<tbl_zItemSpecification> details = tbl_zItemSpecification.SelectAllByItemCategory_ID(sItemCategoryID);
                foreach (tbl_zItemSpecification detail in details)
                {
                    dgvSpecification.Rows.Add();
                    iRow = dgvSpecification.Rows.Count - 1;

                    //dgvSpecification["SubCategoryID", iRow].Value = detail.ItemCategory_ID;
                    dgvSpecification["SpecificationID", iRow].Tag = detail.ItemSepcification_ID;
                    dgvSpecification["SpecificationID", iRow].Value = clsGenaralName.getName_SpesificationID(detail.ItemSepcification_ID);

                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGrid_SpecificationValue(string sItemSubCategoryID)
        {
            try
            {
                int iRow;
                dgvSpecification.Rows.Clear();
                List<tbl_zItemCategory_Sub_Specification> details = tbl_zItemCategory_Sub_Specification.SelectAllByItemCategorySub_ID(sItemSubCategoryID);
                foreach (tbl_zItemCategory_Sub_Specification detail in details)
                {
                    dgvSpecification.Rows.Add();
                    iRow = dgvSpecification.Rows.Count - 1;
                    dgvSpecification["SpecificationValue", iRow].Value = detail.SpecificationValue;
                    dgvSpecification["SpecificationID", iRow].Tag = detail.ItemSepcification_ID;
                    dgvSpecification["SpecificationID", iRow].Value = clsGenaralName.getName_SpesificationID(detail.ItemSepcification_ID);

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
        private void FillDetails(string SubCategoryID, string sSpecificationID)
        {
            try
            {
                if (sSpecificationID.Length > 0)
                {
                    tbl_zItemCategory_Sub_Specification detail = tbl_zItemCategory_Sub_Specification.Select(SubCategoryID, sSpecificationID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;

                        //asign values
                        txtSubCategoryID.Text = clsGenaralName.getName_ItemSubCategory(detail.ItemCategorySub_ID);
                        txtSubCategoryID.Tag = detail.ItemCategorySub_ID;
                        string sCategoryID = clsGenaralName.getCategoryID_ItemSubCategory(detail.ItemCategorySub_ID);
                        txtCategoryID.Text = clsGenaralName.getName_ItemCategory(sCategoryID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            //RefreshGrid_Specification(detail.MachineCategory_ID, detail.Machine_ID);
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtSubCategoryID.TextLength == 0)
                {
                    strMessage += "\n" + "Item Category Name ";
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
        private void txtItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_MachineCategoryID();
            }   
        }
        private void frm_mtrItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtClassName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                Search_MachineSubCategoryID();
            } 
        }
        #endregion

        #region Events DoubleClick

        private void txtItemType_DoubleClick(object sender, EventArgs e)
        {
            Search_MachineCategoryID();
        }

        private void txtClassName_DoubleClick(object sender, EventArgs e)
        {
            if (txtCategoryID.TextLength > 0)
            {
            Search_MachineSubCategoryID();
            }
            else{
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "please Select Item Category "), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sSpecificationID = dgvSpecification["SpecificationID", e.RowIndex].Tag.ToString().Trim();
                    string sSubCategoryID = dgvSpecification["SubCategoryID", e.RowIndex].Value.ToString().Trim();

                    if (sSpecificationID.Length > 0)
                    {
                        if (sSubCategoryID.Length > 0 && sSpecificationID.Length > 0)
                        {
                            FillDetails(sSubCategoryID, sSpecificationID);
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
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region Search Methods

        private void Search_MachineCategoryID()
        {
            try
            {
                //IsUpdate = true;
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemCategory();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCategoryID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtCategoryID.Tag = frmSearchMaster.s_SearchID;
                    RefreshGrid_Specification(txtCategoryID.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }

        private void Search_MachineSubCategoryID()
        {
            try
            {
                IsUpdate = true;
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemSubCategoryByCategoryID(txtCategoryID.Tag.ToString());

                frmhelpsearch.ShowDialog();
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtSubCategoryID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    sItemSubCategoryID = frmSearchMaster.s_SearchID;
                    txtSubCategoryID.Tag = frmSearchMaster.s_SearchID;
                    //txtCategoryID.Tag = clsGenaralName.getCategoryID_ItemSubCategory(sItemSubCategoryID);
                    //txtCategoryID.Text = clsGenaralName.getName_ItemCategory(txtCategoryID.Tag.ToString());
                    RefreshGrid_Specification(txtCategoryID.Tag.ToString(), sItemSubCategoryID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
     

        #endregion

        #region Add Specification
        private void btnSpecification_Click(object sender, EventArgs e)
        {
            frm_mtrItemSpecification detail = new frm_mtrItemSpecification();
            detail.ShowDialog();
        } 
        #endregion


    }
}
