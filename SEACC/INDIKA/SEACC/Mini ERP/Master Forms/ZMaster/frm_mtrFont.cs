using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DataTire;
using System.IO;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using Zion.ERP.Reports.DataSets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_mtrFont : MettroForm
    {


        #region Form Load
        public frm_mtrFont()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZFontType);
            iFormID = clsSecurity.getFormID(FormName.ZFontType);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_zFont_Load(object sender, EventArgs e)
        {
            #region Fill Combo boxes
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFontName.Items.Add(font.Name.ToString());
            }
            cmbFontStyle.DataSource = Enum.GetValues(typeof(FontStyle));
            #endregion

            CusDataGridViewFormat();
            RefreshGrid();
            ClearFilds();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFilds();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFontTypeID.TextLength > 0)
                {
                    if (CheckValidity_Number())
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zFont detail = tbl_zFont.Select(txtFontTypeID.Text);
                            if (detail != null)
                            {
                                detail.Delete();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtFontTypeID.Text, TxnActivity.Cancel);
                            }

                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFilds();
                            RefreshGrid();
                            cmbFontStyle.SelectedItem = "Regular";
                        }
                        else //if no permission to delete
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                if (sqlException.Number == 547)
                    MessageBox.Show("Unable to delete the recode.\nPlease remove Item Master references befor delete seleted data. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    clsValidate.WriteErrorLog("", iFormID, sqlException);
                    SEACCException.Show(sqlException);
                }
            }
            catch (Exception ex)
            {

                SEACCException.Show(ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidity_Number())
                {
                    if (CheckValidity_FontName())
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {

                            Cursor = Cursors.WaitCursor;
                            if (txtFontTypeID.TextLength > 0)
                            {
                                if (IsUpdate)  //update records
                                {
                                    tbl_zFont oldRecord = tbl_zFont.Select(txtFontTypeID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Country Header
                                        tbl_zFont detail = new tbl_zFont(Convert.ToInt32(this.txtFontTypeID.Text), txtFontTypeName.Text.Trim(), cmbFontName.SelectedItem.ToString(), Convert.ToInt32(this.txtFontSize.Text), cmbFontStyle.SelectedItem.ToString());
                                        detail.Update();
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtFontTypeID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else  //insert records
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtFontTypeID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                    //Inquiry Header
                                    tbl_zFont detail = new tbl_zFont(Convert.ToInt32(this.txtFontTypeID.Text), txtFontTypeName.Text.Trim(), cmbFontName.SelectedItem.ToString(), Convert.ToInt32(this.txtFontSize.Text), cmbFontStyle.SelectedItem.ToString());
                                    detail.Insert();
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtFontTypeID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Font Type " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                ClearFilds();
                RefreshGrid();

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
        private void ClearFilds()
        {
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtFontTypeID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblFontTypeID, true);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtFontTypeID.Text = "<Auto Generate>";
            else
                txtFontTypeID.Clear();

            rchtFontPreview.Font = new Font("Segoe UI", 12.0f);
            cmbFontStyle.SelectedItem = "Regular";
            txtFontTypeName.Clear();
            cmbFontName.Text = "";
            txtFontSize.Text = "12";

            rchtFontPreview.ReadOnly = true;
        }
        #endregion

        #region Check Validity
        #region Check Validity Number
        private bool CheckValidity_Number()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtFontTypeName.TextLength == 0)
            {
                strMessage += "\n" + "Font Type Name ";
                bStatus = false;
            }
            if (cmbFontName.SelectedItem == null)
            {
                strMessage += "\n" + "Font Name ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Check Validity Font Type Name
        private bool CheckValidity_FontName()
        {
            bool bStatus = true;
            foreach (tbl_zFont detail in tbl_zFont.SelectAll().Where(p => p.FontType_ID != -1))
            {
                if (txtFontTypeName.Text.Trim() == detail.FontType_Name)
                {
                    bStatus = false;
                    break;
                }
            }

            if (bStatus == false)
                MessageBox.Show("Can't Duplicate Font Type Name...!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


            return bStatus;
        }
        #endregion
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();
            foreach (tbl_zFont detail in tbl_zFont.SelectAll().Where(p => p.FontType_ID != -1))
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                dgvDetail["FontType_ID", iRow].Value = detail.FontType_ID;
                dgvDetail["FontType_Name", iRow].Value = detail.FontType_Name;
                dgvDetail["Font_Name", iRow].Value = detail.FontName;
                dgvDetail["Size", iRow].Value = detail.Size;
                dgvDetail["Style", iRow].Value = detail.Style;
            }
        }
        #endregion

        #region Fill Textboxes
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region Font Size Validity
        private void txtFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_zFont detail = tbl_zFont.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtFontTypeID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblFontTypeID, false);

                    //asign values
                    txtFontTypeID.Text = Convert.ToString(detail.FontType_ID);
                    txtFontTypeName.Text = detail.FontType_Name;
                    cmbFontName.Text = detail.FontName;
                    txtFontSize.Text = Convert.ToString(detail.Size);
                    cmbFontStyle.Text = detail.Style;
                    FontStyleChange();
                    //  FontSizeChange();
                }
            }
        }
        #endregion

        #region Event Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["FontType_ID", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void Search_FontTypeID()
        {
            string sFontid = "", sFontname = "";
            clsSearch.Search_FontType(ref sFontid, ref sFontname);

            txtFontTypeID.Tag = sFontid;
            if (txtFontTypeID.Tag != null)
            {
                FillDetails(sFontid);
            }
        }

        private void txtFontTypeID_DoubleClick(object sender, EventArgs e)
        {
            Search_FontTypeID();
        }
        #endregion

        #region Font Style
        public void FontStyleChange()
        {
            FontStyle FontStyle = (FontStyle)cmbFontStyle.SelectedItem;
            int iFontSize = 12;
            if (txtFontSize.Text.Length > 0)
                iFontSize = int.Parse(txtFontSize.Text);
            rchtFontPreview.Font = new Font(cmbFontName.Text, iFontSize, FontStyle);
        }
        #endregion

        #region Event KeyUp
        private void txtFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            FontStyleChange();
        }
        #endregion

        #region Events SelectedIndexChanged
        private void cmbFontName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FontStyleChange();
        }
        private void cmbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontStyleChange();
        }
        #endregion

    }
}
