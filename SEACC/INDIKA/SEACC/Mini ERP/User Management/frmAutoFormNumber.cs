using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;



namespace Digiteq
{
    public partial class frmAutoFormNumber : MettroForm
    {
        public bool bNoAccess;
        public int iFormID;
        public frmAutoFormNumber()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.AutoGenarateNumberSetting);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }
       

        private void frm_AutoNumber_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, "Auto Generate Number Setting", 2,0);
            ClearFields();

            //add data to the datagrid and format            
            RefreshGrid();
           // CusDataGridViewFormat();         
        }

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {                        
                        if (txtFormConfigID.TextLength > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            //update records
                            tbl_securityConfigForms config = new tbl_securityConfigForms(txtFormConfigID.Text.Trim(), int.Parse(txtCount.Text.Trim()), 
                                txtFormName.Text.Trim(), int.Parse(txtLength.Text.Trim()), txtPrefix1.Text.Trim(), txtSeperator1.Text.Trim(),
                                txtPrefix2.Text.Trim(), txtSeperator2.Text.Trim(), chkAutoGenerate.Checked,1,txtDoc.Text,txtTxn.Text);
                            config.Update();
                            
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", -1,ex);
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

        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id            
            txtFormConfigID.Enabled = true;

            txtFormConfigID.Clear();
            txtCount.Clear();
            txtFormName.Clear();
            txtLength.Clear();
            txtPrefix1.Clear();
            txtPrefix2.Clear();
            txtSeperator1.Clear();
            txtSeperator2.Clear();
            txtDoc.Clear();
            txtTxn.Clear();

            chkAutoGenerate.Checked = false;

            if (txtFormConfigID.Enabled)
                txtFormConfigID.Focus();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            List<tbl_securityConfigForms> details = tbl_securityConfigForms.SelectAll();
            foreach (tbl_securityConfigForms detail in details)
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                dgvDetail["FormNo", iRow].Value = detail.ConfigForm_ID;
                dgvDetail["FormName", iRow].Value = detail.ConfigName;
                dgvDetail["Prefix1", iRow].Value = detail.Prefix1;
                dgvDetail["Seperator1", iRow].Value = detail.Seperator1;
                dgvDetail["Prefix2", iRow].Value = detail.Prefix2;
                dgvDetail["Seperator2", iRow].Value = detail.Seperator2;
                dgvDetail["Length", iRow].Value = detail.Length.ToString();
                dgvDetail["Count", iRow].Value = detail.Counter.ToString();
                dgvDetail["AutoGenerate", iRow].Value = detail.IsAutoGenerate;   
                
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string s_ConfigID)
        {
            try
            {
                if (s_ConfigID.Length > 0)
                {
                    tbl_securityConfigForms detail = tbl_securityConfigForms.Select(s_ConfigID.Trim());

                    if (detail != null)
                    {
                        //asign values
                        txtCount.Text = detail.Counter.ToString();
                        txtFormConfigID.Text = detail.ConfigForm_ID;
                        txtFormName.Text = detail.ConfigName;
                        txtLength.Text = detail.Length.ToString();
                        txtPrefix1.Text = detail.Prefix1;
                        txtPrefix2.Text = detail.Prefix2;
                        txtSeperator1.Text = detail.Seperator1;
                        txtSeperator2.Text = detail.Seperator2;
                        chkAutoGenerate.Checked = detail.IsAutoGenerate;
                        txtDoc.Text = detail.DocumentCode;
                        txtTxn.Text = detail.TxnCode;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// " Please Enter the Details... ";
            bool bStatus = true;

            if (txtFormConfigID.TextLength == 0)
            {
                strMessage += "\n" + "Config ID ";
                bStatus = false;
            }

            if (txtPrefix1.TextLength == 0)
            {
                strMessage += "\n" + "Prifix";
                bStatus = false;
            }

            if (txtCount.TextLength == 0)
            {
                strMessage += "\n" + "Count";
                bStatus = false;
            }

            if (txtFormName.TextLength == 0)
            {
                strMessage += "\n" + "Form Name";
                bStatus = false;
            }

            if (txtLength.TextLength == 0)
            {
                strMessage += "\n" + "Length";
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
            string strMessage = " ";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCount.Text.Trim()))
                {
                    strMessage += "\n Counter";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtLength.Text.Trim()))
                {
                    strMessage += "\n Length";
                    bStatus = false;
                }
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorAdminHeaderColour, clsFormatter.colorDigiteqTheamColorAdminForColour);
            //clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["FormNo", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["FormNo", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        } 
        #endregion

        #region Events Keydown
        private void txtFormConfigID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ConfigForm();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {                    
                    FillDetails(frmSearchTransaction.s_SearchID);
                }
            }
        }

        private void frmAutoFormNumber_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion


    }
}