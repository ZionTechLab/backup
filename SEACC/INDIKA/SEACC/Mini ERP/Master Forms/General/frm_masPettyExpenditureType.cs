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
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_masPettyExpenditureType : MettroForm
    {

        #region Variables
        //to manage update and insert

        static bool IsUpdate_Tab_1 = false;
        static bool IsUpdate_Level_2 = false;
        static bool IsUpdate_Level_3 = false;
        static bool IsUpdate_Level_4 = false;
        static bool IsUpdate_Income = false;
        static bool IsUpdateCostCenter = false;

        //to keep form detail       

        string sFormConfigCodeIncomeType;
        string sFormConfigCodeLevel_1;
        string sFormConfigCodeLevel_2;
        string sFormConfigCodeLevel_3;
        string sFormConfigCodeLevel_4;
        string sFormConfigCodeCost;


        #endregion

        #region Form Load
        public frm_masPettyExpenditureType()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.zPettyCashExpenditureType);

            sFormConfigCodeIncomeType = clsAutocode.getFormConfigCode(FormName.zPettyCashIncomeType);
            sFormConfigCodeLevel_1 = clsAutocode.getFormConfigCode(FormName.Level_1);
            sFormConfigCodeLevel_2 = clsAutocode.getFormConfigCode(FormName.Level_2);
            sFormConfigCodeLevel_3 = clsAutocode.getFormConfigCode(FormName.Level_3);
            sFormConfigCodeLevel_4 = clsAutocode.getFormConfigCode(FormName.Level_4);
            sFormConfigCodeCost = clsAutocode.getFormConfigCode(FormName.Cost);

            iFormID = clsSecurity.getFormID(FormName.zPettyCashExpenditureType);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_mtrBank_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format
            RefreshGrid();
            RefreshGrid_Tab_1();
            RefreshGrid_Level_2();
            RefreshGrid_Level_3();
            //  RefreshGrid_Level_4();
            RefreshGrid_Income();
            RefreshGrid_CostCenter();


            CusDataGridViewFormat();
            CusDataGridViewFormat_Income();
            CusDataGridViewFormat_Level_2();
            CusDataGridViewFormat_Level_3();
            //    CusDataGridViewFormat_Level_4();
            CusDataGridViewFormat_CostCenter();

            ClearFields();
            ClearFields_Tab_1();
            ClearFields_Level_2();
            ClearFields_Level_3();
            //   ClearFields_Level_4();
            ClearFields_Tab_3();
            //   ClearFields_Tab_4();
            ClearFields_Income();
            ClearFields_CostCenter();

            this.TabCashBook.SelectedTab = tbpExpenditureType;

            TabCashBook.TabPages["tblCostCenter2"].Text = clsConfig.sCostCenter2;
            TabCashBook.TabPages["tblCostCenter3"].Text = clsConfig.sCostCenter3;
            btnCostCenter2.Text = clsConfig.sCostCenter2;
            btnCostCenter3.Text = clsConfig.sCostCenter3;
        }
        #endregion

        #region Petty Cash leval 1 and Expenditure Type from

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnNew_Tab1_Click(object sender, EventArgs e)
        {
            ClearFields_Tab_1();
        }
        private void btnNew_Tab2_Click(object sender, EventArgs e)
        {
            ClearFields_Tab_2();
        }

        private void btnNew_Tab3_Click(object sender, EventArgs e)
        {
            ClearFields_Tab_3();
        }
        //private void btnNew_Tab4_Click(object sender, EventArgs e)
        //{
        //    ClearFields_Tab_4();
        //}
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPettyCashExpenditureTypeID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zPettyCashExpenditureType detail = tbl_zPettyCashExpenditureType.Select(txtPettyCashExpenditureTypeID.Text.Trim());
                            if (detail != null)
                            {
                                detail.Delete();
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

        private void btnDelete_Tab1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLevel_1_ID_Tab1.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zPettyCash_Level_1 detail = tbl_zPettyCash_Level_1.Select(txtLevel_1_ID_Tab1.Text.Trim());
                            if (detail != null)
                            {
                                detail.Delete();
                            }
                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields_Tab_1();
                            RefreshGrid_Tab_1();
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
            if (CheckValidityExpenditure())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtPettyCashExpenditureTypeID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zPettyCashExpenditureType oldRecord = tbl_zPettyCashExpenditureType.Select(txtPettyCashExpenditureTypeID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zPettyCashExpenditureType detail = new tbl_zPettyCashExpenditureType(txtPettyCashExpenditureTypeID.Text.Trim(), txtPettyCashExpenditureTypeName.Text.Trim(), txtLevel3Name.Tag.ToString());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtPettyCashExpenditureTypeID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zPettyCashExpenditureType detail = new tbl_zPettyCashExpenditureType(txtPettyCashExpenditureTypeID.Text.Trim(), txtPettyCashExpenditureTypeName.Text.Trim(), txtLevel3Name.Tag.ToString());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bank " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Tab1_Click(object sender, EventArgs e)
        {
            if (CheckValidity_Tab_1())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate_Tab_1))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtLevel_1_ID_Tab1.TextLength > 0)
                            {
                                if (IsUpdate_Tab_1)  //update records
                                {
                                    tbl_zPettyCash_Level_1 oldRecord = tbl_zPettyCash_Level_1.Select(txtLevel_1_ID_Tab1.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Level_1 Header
                                        tbl_zPettyCash_Level_1 detail = new tbl_zPettyCash_Level_1(txtLevel_1_ID_Tab1.Text.Trim(), txtLevel_1_Name_Tab1.Text.Trim());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeLevel_1))
                                        txtLevel_1_ID_Tab1.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeLevel_1);

                                    //Inquiry Header
                                    tbl_zPettyCash_Level_1 detail = new tbl_zPettyCash_Level_1(txtLevel_1_ID_Tab1.Text.Trim(), txtLevel_1_Name_Tab1.Text.Trim());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Level_1" + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields_Tab_1();
                            RefreshGrid_Tab_1();
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
            clsFormatter.ApplyGridFormat(dgvDetailTab1);
            //clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterForColour);
            //clsFormatter.ApplyGridFormat(dgvDetailTab1, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterForColour);
            //clsFormatter.ApplyGridFormat(dgvDetailTab2, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterForColour);
            //clsFormatter.ApplyGridFormat(dgvDetailTab3, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterForColour);
            //clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterForColour);
        }
        #endregion

        #region Clear Fields

        #region ClearFields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPettyCashExpenditureTypeID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblBankID, true);

            txtPettyCashExpenditureTypeName.Clear();
            txtLevel1Name.Clear();
            txtLevel2Name.Clear();
            txtLevel3Name.Clear();
            // txtLevel4Name.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPettyCashExpenditureTypeID.Text = "<Auto Generate>";
            else
                txtPettyCashExpenditureTypeID.Clear();
            if (txtPettyCashExpenditureTypeID.Enabled)
            {
                txtPettyCashExpenditureTypeID.SelectAll();
                txtPettyCashExpenditureTypeID.Focus();
            }
        }
        #endregion

        #region ClearFields Tab_1
        private void ClearFields_Tab_1()
        {
            //set the flag and enble the id
            IsUpdate_Tab_1 = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_1_ID_Tab1, true);
            clsCommon.SetEnableDisable_NormalLabel(Level_1_Tab_1, true);

            txtLevel_1_Name_Tab1.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtLevel_1_ID_Tab1.Text = "<Auto Generate>";
            else
                txtLevel_1_ID_Tab1.Clear();
            if (txtLevel_1_ID_Tab1.Enabled)
            {
                txtLevel_1_ID_Tab1.SelectAll();
                txtLevel_1_ID_Tab1.Focus();
            }
        }
        #endregion

        #region ClearFields Tab_2
        private void ClearFields_Tab_2()
        {
            //set the flag and enble the id
            IsUpdate_Tab_1 = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_2_ID_Tab2, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLevel_2, true);

            txtLevel_2_Name_Tab2.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtLevel_2_ID_Tab2.Text = "<Auto Generate>";
            else
                txtLevel_2_ID_Tab2.Clear();
            if (txtLevel_2_ID_Tab2.Enabled)
            {
                txtLevel_2_ID_Tab2.SelectAll();
                txtLevel_2_ID_Tab2.Focus();
            }
        }
        #endregion

        #region ClearFields Tab_3
        private void ClearFields_Tab_3()
        {
            //set the flag and enble the id
            IsUpdate_Tab_1 = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_3_ID_Tab3, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLevel3, true);

            txtLevel_3_Name_Tab3.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtLevel_3_ID_Tab3.Text = "<Auto Generate>";
            else
                txtLevel_3_ID_Tab3.Clear();
            if (txtLevel_3_ID_Tab3.Enabled)
            {
                txtLevel_3_ID_Tab3.SelectAll();
                txtLevel_3_ID_Tab3.Focus();
            }
        }
        #endregion

        #region ClearFields Tab_4
        //private void ClearFields_Tab_4()
        //{
        //    //set the flag and enble the id
        //    IsUpdate_Tab_1 = false;
        //    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_4_ID_Tab4, true);
        //    clsCommon.SetEnableDisable_NormalLabel(Level_4_Tab_4, true);

        //    txtLevel_4_Name_Tab4.Clear();

        //    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
        //        txtLevel_4_ID_Tab4.Text = "<Auto Generate>";
        //    else
        //        txtLevel_4_ID_Tab4.Clear();
        //    if (txtLevel_4_ID_Tab4.Enabled)
        //    {
        //        txtLevel_4_ID_Tab4.SelectAll();
        //        txtLevel_4_ID_Tab4.Focus();
        //    }
        //}
        #endregion

        #endregion


        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_zPettyCashExpenditureType> details = tbl_zPettyCashExpenditureType.SelectAll();
                foreach (tbl_zPettyCashExpenditureType detail in details)
                {
                    if (detail.PettyCashExpenditureType_ID != "default")
                    {

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["BankID", iRow].Value = detail.PettyCashExpenditureType_ID;
                        dgvDetail["BankName", iRow].Value = detail.PettyCashExpenditureTypeName;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void RefreshGrid_Tab_1()
        {
            try
            {
                int iRow;
                dgvDetailTab1.Rows.Clear();
                List<tbl_zPettyCash_Level_1> details = tbl_zPettyCash_Level_1.SelectAll();
                foreach (tbl_zPettyCash_Level_1 detail in details)
                {
                    if (detail.PettyCash_Level_1_ID != "default")
                    {
                        dgvDetailTab1.Rows.Add();
                        iRow = dgvDetailTab1.Rows.Count - 1;
                        dgvDetailTab1["Level_1_ID", iRow].Value = detail.PettyCash_Level_1_ID;
                        dgvDetailTab1["Level_1_Name", iRow].Value = detail.PettyCash_Level_1Name;
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
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zPettyCashExpenditureType detail = tbl_zPettyCashExpenditureType.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPettyCashExpenditureTypeID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblBankID, false);

                        //asign values
                        txtPettyCashExpenditureTypeID.Text = detail.PettyCashExpenditureType_ID;
                        txtPettyCashExpenditureTypeName.Text = detail.PettyCashExpenditureTypeName;

                        //  txtLevel4Name.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_4(detail.PettyCash_Level_3_ID));

                        tbl_zPettyCash_Level_3 detail_4 = tbl_zPettyCash_Level_3.Select(detail.PettyCash_Level_3_ID);
                        if (detail_4 != null)
                        {
                            txtLevel3Name.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_3(detail_4.PettyCash_Level_3_ID));
                            txtLevel3Name.Tag = detail_4.PettyCash_Level_3_ID;
                        }
                        tbl_zPettyCash_Level_3 detail_3 = tbl_zPettyCash_Level_3.Select(detail_4.PettyCash_Level_3_ID);
                        if (detail_3 != null)
                        {
                            txtLevel2Name.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_2(detail_3.PettyCash_Level_2_ID));
                        }
                        tbl_zPettyCash_Level_2 detail_2 = tbl_zPettyCash_Level_2.Select(detail_3.PettyCash_Level_2_ID);
                        if (detail_2 != null)
                        {
                            txtLevel1Name.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_1(detail_2.PettyCash_Level_1_ID));
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
        private void FillDetails_Tab_1(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zPettyCash_Level_1 detail = tbl_zPettyCash_Level_1.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate_Tab_1 = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_1_ID_Tab1, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLeval1, false);

                        //asign values
                        txtLevel_1_ID_Tab1.Text = detail.PettyCash_Level_1_ID;
                        txtLevel_1_Name_Tab1.Text = detail.PettyCash_Level_1Name;
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

            if (txtPettyCashExpenditureTypeName.TextLength == 0)
            {
                strMessage += "\n" + "Bank Name ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckValidityExpenditure()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtPettyCashExpenditureTypeName.TextLength == 0)
            {
                strMessage += "\n" + "Expenditure Type Name";
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

        private bool CheckValidity_Tab_1()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtLevel_1_Name_Tab1.TextLength == 0)
            {
                strMessage += "\n" + "Level 1 Name";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtBankID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashExpenditureType(ref txtPettyCashExpenditureTypeID);
                if (txtPettyCashExpenditureTypeID.Tag != null)
                    FillDetails(txtPettyCashExpenditureTypeID.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtBankID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashExpenditureType(ref txtPettyCashExpenditureTypeID);
            if (txtPettyCashExpenditureTypeID.Tag != null)
                FillDetails(txtPettyCashExpenditureTypeID.Tag.ToString());
        }
        private void txtLevel_1_ID_Tab1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel_1_ID_Tab1);
            if (txtLevel_1_ID_Tab1.Tag != null)
                FillDetails_Tab_1(txtLevel_1_ID_Tab1.Tag.ToString());
        }
        private void txtLevel1Name_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel1Name);
        }
        private void txtLevel2Name_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel2Name);
        }
        private void txtLevel3Name_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel3Name);
        }

        #endregion

        #region Events Datagrid

        #region dgvDetail
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["BankID", e.RowIndex].Value.ToString();
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

        #region dgvDetail_Tab1
        private void dgvDetailTab1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetailTab1["Level_1_ID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails_Tab_1(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvDetailTab1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailTab1_CellClick(sender, e);
        }
        #endregion

        #endregion 
        #endregion

        #region Petty Cash Income Type from 

        #region Btn New
        private void btnNew_Income_Click(object sender, EventArgs e)
        {
            ClearFields_Income();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Income_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPettyCashIncomeTypeID_Income.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zPettyCashIncomeType detail = tbl_zPettyCashIncomeType.Select(txtPettyCashIncomeTypeID_Income.Text.Trim());
                            if (detail != null)
                            {
                                detail.Delete();
                            }
                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields_Income();
                            RefreshGrid_Income();
                        }
                        else if (msgResult == DialogResult.No)
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnSave_Income_Click(object sender, EventArgs e)
        {
            if (CheckValidityFillDetails_Income())
            {
                if (CheckNumberValidity_Income())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate_Income))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtPettyCashIncomeTypeID_Income.TextLength > 0)
                            {
                                if (IsUpdate_Income)  //update records
                                {
                                    tbl_zPettyCashIncomeType oldRecord = tbl_zPettyCashIncomeType.Select(txtPettyCashIncomeTypeID_Income.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zPettyCashIncomeType detail = new tbl_zPettyCashIncomeType(txtPettyCashIncomeTypeID_Income.Text.Trim(), txtPettyCashIncomeTypeName_Income.Text.Trim());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeIncomeType))
                                        txtPettyCashIncomeTypeID_Income.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeIncomeType);

                                    //Inquiry Header
                                    tbl_zPettyCashIncomeType detail = new tbl_zPettyCashIncomeType(txtPettyCashIncomeTypeID_Income.Text.Trim(), txtPettyCashIncomeTypeName_Income.Text.Trim());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bank " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields_Income();
                            RefreshGrid_Income();
                        }
                    }
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat_Income()
        {
            clsFormatter.ApplyGridFormat(dgvDetail_Income);
        }
        #endregion

        #region Clear Fields
        private void ClearFields_Income()
        {
            //set the flag and enble the id
            IsUpdate_Income = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPettyCashIncomeTypeID_Income, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIncomeTypeID, true);

            txtPettyCashIncomeTypeName_Income.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPettyCashIncomeTypeID_Income.Text = "<Auto Generate>";
            else
                txtPettyCashIncomeTypeID_Income.Clear();
            if (txtPettyCashIncomeTypeID_Income.Enabled)
            {
                txtPettyCashIncomeTypeID_Income.SelectAll();
                txtPettyCashIncomeTypeID_Income.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Income()
        {
            try
            {
                int iRow;
                dgvDetail_Income.Rows.Clear();
                List<tbl_zPettyCashIncomeType> details = tbl_zPettyCashIncomeType.SelectAll();
                foreach (tbl_zPettyCashIncomeType detail in details)
                {
                    if (detail.PettyCashIncomeType_ID != "default")
                    {

                        dgvDetail_Income.Rows.Add();
                        iRow = dgvDetail_Income.Rows.Count - 1;
                        dgvDetail_Income["TypeID", iRow].Value = detail.PettyCashIncomeType_ID;
                        dgvDetail_Income["PettyIncomeType", iRow].Value = detail.PettyCashIncomeTypeName;
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
        private void FillDetails_Income(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zPettyCashIncomeType detail = tbl_zPettyCashIncomeType.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate_Income = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPettyCashIncomeTypeID_Income, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIncomeTypeID, false);

                        //asign values
                        txtPettyCashIncomeTypeID_Income.Text = detail.PettyCashIncomeType_ID;
                        txtPettyCashIncomeTypeName_Income.Text = detail.PettyCashIncomeTypeName;
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
        private bool CheckValidityFillDetails_Income()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtPettyCashIncomeTypeName_Income.TextLength == 0)
            {
                strMessage += "\n" + "Petty Cash Income TypeName ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity_Income()
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
        private void txtPettyCashIncomeTypeID_Income_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashIncomeType(ref txtPettyCashIncomeTypeID_Income);
                if (txtPettyCashIncomeTypeID_Income.Tag != null)
                    FillDetails_Income(txtPettyCashIncomeTypeID_Income.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtPettyCashIncomeTypeID_Income_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashIncomeType(ref txtPettyCashIncomeTypeID_Income);
            if (txtPettyCashIncomeTypeID_Income.Tag != null)
                FillDetails_Income(txtPettyCashIncomeTypeID_Income.Tag.ToString());
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_Income_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail_Income["TypeID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails_Income(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_Income_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_Income_CellClick(sender, e);
        }
        #endregion


        #endregion

        #region Petty Cash leval 2 from
        #region Btn New
        private void btnNew_Level_2_Click(object sender, EventArgs e)
        {
            ClearFields_Level_2();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Level_2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLevel_2_ID_Tab2.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zPettyCash_Level_2 detail = tbl_zPettyCash_Level_2.Select(txtLevel_2_ID_Tab2.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields_Level_2();
                        RefreshGrid_Level_2();
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
        private void btnSave_Level_2_Click(object sender, EventArgs e)
        {
            if (CheckValidity_Level_2())
            {
                if (CheckNumberValidity_Level_2())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate_Level_2))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtLevel_2_ID_Tab2.TextLength > 0)
                            {
                                if (IsUpdate_Level_2)  //update records
                                {

                                    tbl_zPettyCash_Level_2 oldRecord = tbl_zPettyCash_Level_2.Select(txtLevel_2_ID_Tab2.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zPettyCash_Level_2 detail = new tbl_zPettyCash_Level_2(txtLevel_2_ID_Tab2.Text.Trim(), txtLevel_2_Name_Tab2.Text.Trim(), txtLevel_1_Name_Tab2.Tag.ToString());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeLevel_2))
                                        txtLevel_2_ID_Tab2.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeLevel_2);

                                    //Inquiry Header
                                    tbl_zPettyCash_Level_2 detail = new tbl_zPettyCash_Level_2(txtLevel_2_ID_Tab2.Text.Trim(), txtLevel_2_Name_Tab2.Text.Trim(), txtLevel_1_Name_Tab2.Tag.ToString());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Branch " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields_Level_2();
                            RefreshGrid_Level_2();
                        }
                    }
                }
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat_Level_2()
        {
            clsFormatter.ApplyGridFormat(dgvDetailTab2);
        }
        #endregion

        #region Clear Fields
        private void ClearFields_Level_2()
        {
            //set the flag and enble the id
            IsUpdate_Level_2 = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_2_ID_Tab2, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLevel_2, true);

            txtLevel_1_Name_Tab2.Tag = null;
            txtLevel_1_Name_Tab2.Clear();
            txtLevel_2_Name_Tab2.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtLevel_2_ID_Tab2.Text = "<Auto Generate>";
            else
                txtLevel_2_ID_Tab2.Clear();
            if (txtLevel_2_ID_Tab2.Enabled)
            {
                txtLevel_2_ID_Tab2.SelectAll();
                txtLevel_2_ID_Tab2.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Level_2()
        {
            try
            {
                int iRow;
                dgvDetailTab2.Rows.Clear();
                List<tbl_zPettyCash_Level_2> details = tbl_zPettyCash_Level_2.SelectAll();
                foreach (tbl_zPettyCash_Level_2 detail in details)
                {
                    //MessageBox.Show("ok");
                    if (detail.PettyCash_Level_2_ID.Trim() != "default")
                    {
                        dgvDetailTab2.Rows.Add();
                        iRow = dgvDetailTab2.Rows.Count - 1;
                        dgvDetailTab2["Level_2_ID", iRow].Value = detail.PettyCash_Level_2_ID;
                        dgvDetailTab2["Level_2_Name", iRow].Value = detail.PettyCash_Level_2Name;
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
        private void FillDetails_Level_2(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zPettyCash_Level_2 detail = tbl_zPettyCash_Level_2.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate_Level_2 = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_2_ID_Tab2, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLevel_2, false);

                        //asign values
                        txtLevel_1_Name_Tab2.Tag = detail.PettyCash_Level_1_ID;
                        txtLevel_1_Name_Tab2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_1(detail.PettyCash_Level_1_ID));
                        txtLevel_2_ID_Tab2.Text = detail.PettyCash_Level_2_ID;
                        txtLevel_2_Name_Tab2.Text = detail.PettyCash_Level_2Name;
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
        private bool CheckValidity_Level_2()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtLevel_1_Name_Tab2.TextLength == 0)
                {
                    strMessage += "\n" + "Level 1 Name ";
                    bStatus = false;
                }
                if (txtLevel_2_Name_Tab2.TextLength == 0)
                {
                    strMessage += "\n" + "Level 2 Name ";
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

        private bool CheckNumberValidity_Level_2()
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
        private void txtLevel_1_Name_Tab2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel_1_Name_Tab2);
            }
        }
        private void txtLevel_2_ID_Tab2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel_2_ID_Tab2);
                if (txtLevel_2_ID_Tab2.Tag != null)
                    FillDetails_Level_2(txtLevel_2_ID_Tab2.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtLevel_2_ID_Tab2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel_2_ID_Tab2);
            if (txtLevel_2_ID_Tab2.Tag != null)
                FillDetails_Level_2(txtLevel_2_ID_Tab2.Tag.ToString());
        }
        private void txtLevel_1_Name_Tab2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel_1_Name_Tab2);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetailTab2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetailTab2["Level_2_ID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails_Level_2(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvDetailTab2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailTab2_CellClick(sender, e);
        }
        #endregion
        #endregion

        #region  Petty Cash leval 3 from
        #region Btn New
        private void btnNew_Level_3_Click(object sender, EventArgs e)
        {
            ClearFields_Level_3();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Level_3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLevel_3_ID_Tab3.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zPettyCash_Level_3 detail = tbl_zPettyCash_Level_3.Select(txtLevel_3_ID_Tab3.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields_Level_3();
                        RefreshGrid_Level_3();
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
        private void btnSave_Level_3_Click(object sender, EventArgs e)
        {
            if (CheckValidity_Level_3())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate_Level_3))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtLevel_3_ID_Tab3.TextLength > 0)
                            {
                                if (IsUpdate_Level_3)  //update records
                                {

                                    tbl_zPettyCash_Level_3 oldRecord = tbl_zPettyCash_Level_3.Select(txtLevel_3_ID_Tab3.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zPettyCash_Level_3 detail = new tbl_zPettyCash_Level_3(txtLevel_3_ID_Tab3.Text.Trim(), txtLevel_3_Name_Tab3.Text.Trim(), txtLevel_2_Name_Tab3.Tag.ToString());
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeLevel_3))
                                        txtLevel_3_ID_Tab3.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeLevel_3);

                                    //Inquiry Header
                                    tbl_zPettyCash_Level_3 detail = new tbl_zPettyCash_Level_3(txtLevel_3_ID_Tab3.Text.Trim(), txtLevel_3_Name_Tab3.Text.Trim(), txtLevel_2_Name_Tab3.Tag.ToString());
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Level 3 " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields_Level_3();
                            RefreshGrid_Level_3();
                        }
                    }
                }
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat_Level_3()
        {
            clsFormatter.ApplyGridFormat(dgvDetailTab3);
        }
        #endregion

        #region Clear Fields
        private void ClearFields_Level_3()
        {
            //set the flag and enble the id
            IsUpdate_Level_3 = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_3_ID_Tab3, true);
            clsCommon.SetEnableDisable_NormalLabel(lblLevel3, true);

            txtLevel_2_Name_Tab3.Tag = null;
            txtLevel_2_Name_Tab3.Clear();
            txtLevel_3_Name_Tab3.Clear();
            txtLevel_1_Name_Tab3.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtLevel_3_ID_Tab3.Text = "<Auto Generate>";
            else
                txtLevel_3_ID_Tab3.Clear();
            if (txtLevel_3_ID_Tab3.Enabled)
            {
                txtLevel_3_ID_Tab3.SelectAll();
                txtLevel_3_ID_Tab3.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Level_3()
        {
            try
            {
                int iRow;
                dgvDetailTab3.Rows.Clear();
                List<tbl_zPettyCash_Level_3> details = tbl_zPettyCash_Level_3.SelectAll();
                foreach (tbl_zPettyCash_Level_3 detail in details)
                {
                    //MessageBox.Show("ok");
                    if (detail.PettyCash_Level_3_ID.Trim() != "default")
                    {
                        dgvDetailTab3.Rows.Add();
                        iRow = dgvDetailTab3.Rows.Count - 1;
                        dgvDetailTab3["Level_3_ID", iRow].Value = detail.PettyCash_Level_3_ID;
                        dgvDetailTab3["Level_3_Name", iRow].Value = detail.PettyCash_Level_3Name;
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
        private void FillDetails_Level_3(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zPettyCash_Level_3 detail = tbl_zPettyCash_Level_3.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate_Level_3 = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_3_ID_Tab3, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblLevel3, false);

                        //asign values
                        txtLevel_2_Name_Tab3.Tag = detail.PettyCash_Level_2_ID;
                        txtLevel_2_Name_Tab3.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_2(detail.PettyCash_Level_2_ID));

                        tbl_zPettyCash_Level_2 detail_2 = tbl_zPettyCash_Level_2.Select(detail.PettyCash_Level_2_ID);
                        if (detail_2 != null)
                        {
                            txtLevel_1_Name_Tab3.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_1(detail_2.PettyCash_Level_1_ID));
                        }
                        txtLevel_3_ID_Tab3.Text = detail.PettyCash_Level_3_ID;
                        txtLevel_3_Name_Tab3.Text = detail.PettyCash_Level_3Name;
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
        private bool CheckValidity_Level_3()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtLevel_2_Name_Tab3.TextLength == 0)
                {
                    strMessage += "\n" + "Level 2 Name";
                    bStatus = false;
                }
                if (txtLevel_3_Name_Tab3.TextLength == 0)
                {
                    strMessage += "\n" + "Level 3 Name";
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
        private void txtLevel_2_Name_Tab3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel_2_Name_Tab3);
            }
        }
        private void txtLevel_3_ID_Tab3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel_3_ID_Tab3);
                if (txtLevel_3_ID_Tab3.Tag != null)
                    FillDetails_Level_3(txtLevel_3_ID_Tab3.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtLevel_2_Name_Tab3_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel_2_Name_Tab3);
            if (txtLevel_2_Name_Tab3.Tag != null)
            {
                tbl_zPettyCash_Level_2 detail_2 = tbl_zPettyCash_Level_2.Select(txtLevel_2_Name_Tab3.Tag.ToString());
                if (detail_2 != null)
                {
                    txtLevel_1_Name_Tab3.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_1(detail_2.PettyCash_Level_1_ID));
                }
            }
        }
        private void txtLevel_3_ID_Tab3_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel_3_ID_Tab3);
            if (txtLevel_3_ID_Tab3.Tag != null)
                FillDetails_Level_3(txtLevel_3_ID_Tab3.Tag.ToString());
        }
        private void txtLevel_1_Name_Tab3_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel_1_Name_Tab3);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetailTab3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetailTab3["Level_3_ID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails_Level_3(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetailTab3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailTab3_CellClick(sender, e);
        }
        #endregion
        #endregion

        #region Petty Cash leval 4 from
        #region Btn New
        //private void btnNew_Level_4_Click(object sender, EventArgs e)
        //{
        //    ClearFields_Level_4();
        //}
        #endregion

        #region Btn Delete
        //private void btnDelete_Level_4_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtLevel_4_ID_Tab4.TextLength > 0)
        //        {
        //            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
        //            {
        //                //delete one record
        //                Cursor = Cursors.WaitCursor;
        //                tbl_zPettyCash_Level_4 detail = tbl_zPettyCash_Level_4.Select(txtLevel_4_ID_Tab4.Text.Trim());
        //                if (detail != null)
        //                {
        //                    detail.Delete();
        //                }

        //                Cursor = Cursors.Default;
        //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                ClearFields_Level_4();
        //                RefreshGrid_Level_4();
        //            }
        //            else //if no permission to delete
        //            {
        //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //}
        #endregion

        #region Btn Save
        //private void btnSave_Level_4_Click(object sender, EventArgs e)
        //{
        //    if (CheckValidity_Level_4())
        //    {
        //        if (CheckNumberValidity_Level_4())
        //        {
        //           if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate_Level_4))
        //            {
        //                try
        //                {
        //                    Cursor = Cursors.WaitCursor;
        //                    if (txtLevel_4_ID_Tab4.TextLength > 0)
        //                    {
        //                        if (IsUpdate_Level_4)  //update records
        //                        {

        //                            tbl_zPettyCash_Level_4 oldRecord = tbl_zPettyCash_Level_4.Select(txtLevel_4_ID_Tab4.Text.Trim());
        //                            if (oldRecord != null)
        //                            {
        //                                //Country Header
        //                                tbl_zPettyCash_Level_4 detail = new tbl_zPettyCash_Level_4(txtLevel_4_ID_Tab4.Text.Trim(), txtLevel_4_Name_Tab4.Text.Trim(), txtLevel_3_Name_Tab4.Tag.ToString());
        //                                detail.Update();
        //                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            }
        //                        }
        //                        else  //insert records
        //                        {
        //                            if (clsAutocode.IsAutoGenerated(sFormConfigCodeLevel_4))
        //                                txtLevel_4_ID_Tab4.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeLevel_4);

        //                            //Inquiry Header
        //                            tbl_zPettyCash_Level_4 detail = new tbl_zPettyCash_Level_4(txtLevel_4_ID_Tab4.Text.Trim(), txtLevel_4_Name_Tab4.Text.Trim(), txtLevel_3_Name_Tab4.Tag.ToString());
        //                            detail.Insert();
        //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Branch " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    clsValidate.WriteErrorLog("", iFormID,ex);
        //                    SEACCException.Show(ex);
        //                }
        //                finally
        //                {
        //                    Cursor = Cursors.Default;
        //                    ClearFields_Level_4();
        //                    RefreshGrid_Level_4();
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion


        //#region Datagrid Format
        //private void CusDataGridViewFormat_Level_4()
        //{
        //    clsFormatter.ApplyGridFormat(dgvDetailTab4);
        //}
        //#endregion

        #region Clear Fields
        //private void ClearFields_Level_4()
        //{
        //    //set the flag and enble the id
        //    IsUpdate_Level_4 = false;
        //    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_4_ID_Tab4, true);
        //    clsCommon.SetEnableDisable_NormalLabel(Level_4_Tab_4, true);

        //    txtLevel_3_Name_Tab4.Tag = null;
        //    txtLevel_1_Name_Tab4.Clear();
        //    txtLevel_2_Name_Tab4.Clear();
        //    txtLevel_3_Name_Tab4.Clear();
        //    txtLevel_4_Name_Tab4.Clear();

        //    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
        //        txtLevel_4_ID_Tab4.Text = "<Auto Generate>";
        //    else
        //        txtLevel_4_ID_Tab4.Clear();
        //    if (txtLevel_4_ID_Tab4.Enabled)
        //    {
        //        txtLevel_4_ID_Tab4.SelectAll();
        //        txtLevel_4_ID_Tab4.Focus();
        //    }
        //}
        #endregion

        #region Refresh Grid
        //private void RefreshGrid_Level_4()
        //{
        //    try
        //    {
        //        int iRow;
        //        dgvDetailTab4.Rows.Clear();
        //        List<tbl_zPettyCash_Level_4> details = tbl_zPettyCash_Level_4.SelectAll();
        //        foreach (tbl_zPettyCash_Level_4 detail in details)
        //        {
        //            //MessageBox.Show("ok");
        //            if (detail.PettyCash_Level_4_ID.Trim() != "default")
        //            {
        //                dgvDetailTab4.Rows.Add();
        //                iRow = dgvDetailTab4.Rows.Count - 1;
        //                dgvDetailTab4["Level_4_ID", iRow].Value = detail.PettyCash_Level_4_ID;
        //                dgvDetailTab4["Level_4_Name", iRow].Value = detail.PettyCash_Level_4Name;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //}
        #endregion

        #region Fill Details
        //private void FillDetails_Level_4(string sID)
        //{
        //    try
        //    {
        //        if (sID.Length > 0)
        //        {
        //            tbl_zPettyCash_Level_4 detail = tbl_zPettyCash_Level_4.Select(sID);
        //            if (detail != null)
        //            {
        //                //set the update flag and Locked
        //                IsUpdate_Level_4 = true;
        //                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLevel_4_ID_Tab4, false);
        //                clsCommon.SetEnableDisable_NormalLabel(Level_4_Tab_4, false);

        //                //asign values
        //                txtLevel_3_Name_Tab4.Tag = detail.PettyCash_Level_3_ID;
        //                txtLevel_3_Name_Tab4.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_3(detail.PettyCash_Level_3_ID));
        //                txtLevel_4_ID_Tab4.Text = detail.PettyCash_Level_4_ID;
        //                txtLevel_4_Name_Tab4.Text = detail.PettyCash_Level_4Name;

        //                tbl_zPettyCash_Level_3 detail_3 = tbl_zPettyCash_Level_3.Select(detail.PettyCash_Level_3_ID);
        //                if (detail_3 != null)
        //                {
        //                    txtLevel_2_Name_Tab4.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_2(detail_3.PettyCash_Level_2_ID));
        //                }
        //                tbl_zPettyCash_Level_2 detail_2 = tbl_zPettyCash_Level_2.Select(detail_3.PettyCash_Level_2_ID);
        //                if (detail_2 != null)
        //                {
        //                    txtLevel_1_Name_Tab4.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PettyCash_Level_1(detail_2.PettyCash_Level_1_ID));
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //}
        #endregion


        #region Check Validity
        //private bool CheckValidity_Level_4()
        //{
        //    string strMessage = "";
        //    bool bStatus = true;
        //    try
        //    {
        //        if (txtLevel_3_Name_Tab4.TextLength == 0)
        //        {
        //            strMessage += "\n" + "Level 3 Name ";
        //            bStatus = false;
        //        }
        //        if (txtLevel_4_Name_Tab4.TextLength == 0)
        //        {
        //            strMessage += "\n" + "Level 4 Name ";
        //            bStatus = false;
        //        }
        //        if (bStatus == false)
        //        {
        //            MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //    return bStatus;
        //}

        private bool CheckNumberValidity_Level_4()
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
        //private void txtLevel_4_ID_Tab4_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        clsSearch.Search_MasterPettyCashLeval_4(ref txtLevel_4_ID_Tab4);
        //        if (txtLevel_4_ID_Tab4.Tag != null)
        //            FillDetails_Level_4(txtLevel_4_ID_Tab4.Tag.ToString());
        //    }
        //}
        //private void txtLevel_3_Name_Tab4_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel_3_Name_Tab4);
        //    }
        //}
        #endregion

        #region Events DoubleClick
        //private void txtLevel_4_ID_Tab4_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterPettyCashLeval_4(ref txtLevel_4_ID_Tab4);
        //    if (txtLevel_4_ID_Tab4.Tag != null)
        //        FillDetails_Level_4(txtLevel_4_ID_Tab4.Tag.ToString());
        //}
        //private void txtLevel_3_Name_Tab4_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterPettyCashLeval_3(ref txtLevel_3_Name_Tab4);
        //}
        //private void txtLevel_1_Name_Tab4_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterPettyCashLeval_1(ref txtLevel_1_Name_Tab4);
        //}
        //private void txtLevel_2_Name_Tab4_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterPettyCashLeval_2(ref txtLevel_2_Name_Tab4);
        //}
        #endregion

        #region Events Datagrid

        //private void dgvDetailTab4_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            string sID = dgvDetailTab4["Level_4_ID", e.RowIndex].Value.ToString();
        //            if (sID.Length > 0)
        //            {
        //                //fills the values to controls
        //                FillDetails_Level_4(sID.Trim());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }
        //}
        //private void dgvDetailTab4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dgvDetailTab4_CellClick(sender, e);
        //}

        #endregion
        #endregion

        #region Cost Center
        #region Btn New
        private void btnNewCostCenter_Click(object sender, EventArgs e)
        {
            ClearFields_CostCenter();
        }
        #endregion

        #region Btn Delete
        private void btnDeleteCostCenter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCostCenterID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zCost_Center1 detail = tbl_zCost_Center1.Select(txtCostCenterID.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields_CostCenter();
                        RefreshGrid_CostCenter();
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
        private void btnSaveCostCenter_Click(object sender, EventArgs e)
        {
            if (CheckValidity_CostCenter())
            {
                if (CheckNumberValidity_CostCenter())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateCostCenter))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtCostCenterID.TextLength > 0)
                            {
                                if (IsUpdateCostCenter)  //update records
                                {
                                    tbl_zCost_Center1 oldRecord = tbl_zCost_Center1.Select(txtCostCenterID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zCost_Center1 detail = new tbl_zCost_Center1(txtCostCenterID.Text.Trim(), txtCostCenterName.Text.Trim(), oldRecord.IsCanceled);
                                        detail.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeCost))
                                        txtCostCenterID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeCost);

                                    //Inquiry Header
                                    tbl_zCost_Center1 detail = new tbl_zCost_Center1(txtCostCenterID.Text.Trim(), txtCostCenterName.Text.Trim(), false);
                                    detail.Insert();
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bank " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            ClearFields_CostCenter();
                            RefreshGrid_CostCenter();
                        }
                    }
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat_CostCenter()
        {
            clsFormatter.ApplyGridFormat(dgvDetailCostCenter);
        }
        #endregion

        #region Clear Fields
        private void ClearFields_CostCenter()
        {
            //set the flag and enble the id
            IsUpdateCostCenter = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCostCenterID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCostCenterID, true);

            txtCostCenterName.Clear();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCostCenterID.Text = "<Auto Generate>";
            else
                txtCostCenterID.Clear();
            if (txtCostCenterID.Enabled)
            {
                txtCostCenterID.SelectAll();
                txtCostCenterID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_CostCenter()
        {
            try
            {
                int iRow;
                dgvDetailCostCenter.Rows.Clear();
                List<tbl_zCost_Center1> details = tbl_zCost_Center1.SelectAll();
                foreach (tbl_zCost_Center1 detail in details)
                {
                    if (detail.Cost_Center1_ID != "default")
                    {

                        dgvDetailCostCenter.Rows.Add();
                        iRow = dgvDetailCostCenter.Rows.Count - 1;
                        dgvDetailCostCenter["CostCenterID", iRow].Value = detail.Cost_Center1_ID;
                        dgvDetailCostCenter["CostCenterName", iRow].Value = detail.Cost_Center1_Name;
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
        private void FillDetails_CostCenter(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zCost_Center1 detail = tbl_zCost_Center1.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateCostCenter = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCostCenterID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCostCenterID, false);

                        //asign values
                        txtCostCenterID.Text = detail.Cost_Center1_ID;
                        txtCostCenterName.Text = detail.Cost_Center1_Name;
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
        private bool CheckValidity_CostCenter()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtCostCenterName.TextLength == 0)
            {
                strMessage += "\n" + "Cost Center Name";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity_CostCenter()
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
        private void txtCostCenterID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasteCost_CenterType(ref txtCostCenterID, clsConfig.sCostCenter1);
                if (txtCostCenterID.Tag != null)
                    FillDetails_CostCenter(txtCostCenterID.Tag.ToString());
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtCostCenterID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasteCost_CenterType(ref txtCostCenterID, clsConfig.sCostCenter1);
            if (txtCostCenterID.Tag != null)
                FillDetails_CostCenter(txtCostCenterID.Tag.ToString());
        }
        #endregion

        #region Events Datagrid
        private void dgvDetailCostCenter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetailCostCenter["CostCenterID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails_CostCenter(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetailCostCenter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailCostCenter_CellClick(sender, e);
        }
        #endregion

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region btn Cost Center 3
        private void btnCostCenter3_Click(object sender, EventArgs e)
        {
            UC_MtrCostCenter3 frm = new UC_MtrCostCenter3(FormName.Cost_Center3);
            //Form mf = new Form();
            //mf.StartPosition = 0;
            //mf.Controls.Add(frm);
            //mf.MdiParent = this;
            //mf.Show();

            //Form mf = new Form();
            //mf.StartPosition = 0;
            //mf.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //mf.Width = frm.Width + 16;
            //mf.Height = frm.Height + 12;
            //mf.Controls.Add(frm);
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            ////mf.MdiParent = this;
            //mf.Show();
                     
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region btn Cost Center 2
        private void btnCostCenter2_Click(object sender, EventArgs e)
        {
            //UC_MtrCostCenter2 frm = new UC_MtrCostCenter2(FormName.Cost_Center3);
            //Form mf = new Form();
            //mf.StartPosition = 0;
            //mf.Controls.Add(frm);
            ////mf.MdiParent = this;
            //mf.Show();

            UC_MtrCostCenter2 frm = new UC_MtrCostCenter2(FormName.Cost_Center3);
            //Form mf = new Form();
            //mf.StartPosition = 0;
            //mf.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //mf.Width = frm.Width + 16;
            //mf.Height = frm.Height + 12;
            //mf.Controls.Add(frm);
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            ////mf.MdiParent = this;
            //mf.Show();
                        
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), frm.iFormID + "-" + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();

        }
        #endregion

    }
}
