using DataTire;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEACC.DATA.Data.ACC;
using SEACC.DATA.Domain.ACC;

namespace Digiteq.Transaction_Forms.ACC.Tools_And_Views
{
    public partial class frm_accChequeDateChangeTool : MettroForm
    {
        #region Class Variables
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load

        #region Init Form
        public frm_accChequeDateChangeTool()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.accChqDateChange);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }
        #endregion

        private void frm_accChequeDateChangeTool_Load(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Action Buttons

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.Arrow;

                if (CheckValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, true))
                    {
                        AccChequeDate_Data oData = new AccChequeDate_Data();
                        tbl_accChequeDate oCD = new tbl_accChequeDate();

                        oCD.chequeRegister_ID = txtChequeNo.Tag.ToString();
                        oCD.dateRegister_New = dtpChequeDate.Value;
                        oCD.modifiedTerminal_ID = clsSecurity.TerminalID;
                        oCD.modifiedUser_ID = clsSecurity.UserIDLoged;

                        var result = oData.Save(oCD, true);
                        if (!result.IsSuccess)
                            MessageBox.Show(result.OutMsg);
                        else
                            MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.Afterupdate, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        #endregion

        #region ClearFields
        private void ClearFields()
        {
            txtChequeNo.Clear();
            txtChequeNo.Tag = null;
            dtpChequeDate.Value = DateTime.Now;

        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;

            if (CheckValidity_EmptyField())
                if (CheckValidity_Status())
                    bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtChequeNo, "Cheque No"))
                bStatus = true;
            
            return bStatus;
        }

        private bool CheckValidity_Status()
        {
            bool bStatus = false;
            if (txtChequeNo.Tag != null)
            {
                tbl_accChequeRegister detail = tbl_accChequeRegister.Select(txtChequeNo.Tag.ToString());
                if (detail != null)
                {
                    if (detail.ChequeStatus_ID == "0")
                        bStatus = true;
                }
            }
            else
                MessageBox.Show("Invalid Cheque No", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return bStatus;
        }

        #endregion

        private void txtChequeNo1_KeyDown(object sender, KeyEventArgs e)
        {
            txtChequeNo.Tag = null;
            txtChequeNo_DoubleClick(sender, e);
        }
              
        private void txtChequeNo_DoubleClick(object sender, EventArgs e)
        {            
            clsSearch.Search_AccMasterChequeNo(ref txtChequeNo);
        }

        
    }
}
