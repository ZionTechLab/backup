using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_masAccChartOfAccount : MettroForm
    {
        #region Variables
        private BindingSource sourceAccountCode = new BindingSource();
        private BindingSource sourceAccountType = new BindingSource();
        private BindingSource sourceAccountType2 = new BindingSource();
        private BindingSource sourceSubGeneralLedger = new BindingSource();
        private DataTable dtAllRecodesAccCode = new DataTable();
        private DataTable dtAllRecodesAccType = new DataTable();
        private DataTable dtAllRecodesAccType2 = new DataTable();
        private DataTable dtAllRecodesSubGeneralLedger = new DataTable();

        //to manage update and insert
        static bool IsUpdateGL = false;
        static bool IsUpdateSubGL = false;
        static bool IsUpdateAcctType = false;
        static bool IsUpdateAcctType2 = false;
        static bool IsUpadteAcctCode = false;
        static bool IsUpadteSubAccount = false;

        //to keep form detail       
        string sFormConfigCode;
        string aFormConfigCodeGL;


        public int iFormIDGL;
        int iFormIDSubGL;
        int iFormIDAcctType;
        int iFormIDAcctType2;
        int iFormIDAcct;
        int iFormIDAcctCode;

        string sCFormIDGL;
        string sCFormIDSubGL;
        string sCFormIDAcctType;
        string sCFormIDAcctType2;
        string sCFormIDAcct;
        string sCFormIDAcctCode;
        string selected;


        //for security handle
        public bool bNoAccess;

        //for Counters
        string prefix = "";
        string seperator = "";
        #endregion

        #region Form Load
        public frm_masAccChartOfAccount()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accGeneralLedger);
            aFormConfigCodeGL = clsAutocode.getConfigGlValue(GLValues.GLAddNumber);

            iFormIDGL = clsSecurity.getFormID(FormName.accGeneralLedger);
            iFormIDSubGL = clsSecurity.getFormID(FormName.accSubGeneralLedger);
            iFormIDAcctType = clsSecurity.getFormID(FormName.accAccountType1);
            iFormIDAcctType2 = clsSecurity.getFormID(FormName.accAccountType2);
            iFormIDAcct = clsSecurity.getFormID(FormName.accAccount);
            iFormIDAcctCode = clsSecurity.getFormID(FormName.accAccountCode);

            sCFormIDGL = clsAutocode.getFormConfigCode(FormName.accGeneralLedger);
            sCFormIDSubGL = clsAutocode.getFormConfigCode(FormName.accSubGeneralLedger);
            sCFormIDAcctType = clsAutocode.getFormConfigCode(FormName.accAccountType1);
            sCFormIDAcctType2 = clsAutocode.getFormConfigCode(FormName.accAccountType2);
            sCFormIDAcct = clsAutocode.getFormConfigCode(FormName.accAccount);
            sCFormIDAcctCode = clsAutocode.getFormConfigCode(FormName.accAccountCode);

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormIDGL))
                bNoAccess = true;

            InitializeComponent();

            //rdoDebtor.Checked = true;
            //rdoCredit.Checked = true;

            //populateTree();
        }
        private void frm_masChartOfAccountTab_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            tbcGL.TabPages.Remove(tabSubAccounts);

            CusDataGridViewFormat();
            CreateTableAccountCode();
            CreateTableAccountType();
            CreateTableAccountType2();
            CreateTableSubGeneralLedger();
            dgvAcct.DataSource = sourceAccountCode;

            dgvAcctType.DataSource = sourceAccountType;
            dgvAcctType2.DataSource = sourceAccountType2;
            dgvSubGL.DataSource = sourceSubGeneralLedger;

            ClearFields();
            populateTree();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            populateTree();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbcGL.SelectedTab == tabGL)
                DeleteGL();
            else if (tbcGL.SelectedTab == tabSubGL)
                DeleteSubGL();
            else if (tbcGL.SelectedTab == tabAccType1)
                DeleteAcctType();
            else if (tbcGL.SelectedTab == tabAccType2)
                DeleteAcctType2();
            else if (tbcGL.SelectedTab == tabAccCode)
                DeleteAcct();
        }

        private void DeleteAcct()
        {
            try
            {
                if (txtGledgerGlCode.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormIDAcct))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_accGLMaster detail = tbl_accGLMaster.Select(txtAcctCode.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                populateTree();
            }
        }
        private void DeleteAcctType()
        {
            try
            {
                if (txtGledgerGlCode.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormIDAcctType))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(txtAcctTypeCode.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormIDAcctType,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                populateTree();
            }
        }
        private void DeleteAcctType2()
        {
            try
            {
                if (txtAccType2Code.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormIDAcctType2))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(txtAccType2Code.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                 
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormIDAcctType2, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                populateTree();
            }
        }
        private void DeleteSubGL()
        {
            try
            {
                if (txtGledgerGlCode.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormIDSubGL))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zAccGLMaster_SubCatagory detail = tbl_zAccGLMaster_SubCatagory.Select(txtSubGledgerSubGlCode.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                populateTree();
            }
        }
        private void DeleteGL()
        {
            try
            {
                if (txtGledgerGlCode.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormIDGL))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zAccGLMaster_MainCatagory detail = tbl_zAccGLMaster_MainCatagory.Select(txtGledgerGlCode.Text.Trim());
                        if (detail != null)
                        {
                            detail.Delete();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                populateTree();
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbcGL.SelectedTab == tabGL)
                saveGL();
            else if (tbcGL.SelectedTab == tabSubGL)
                saveSubGL();
            else if (tbcGL.SelectedTab == tabAccType1)
                saveAcctType();
            else if (tbcGL.SelectedTab == tabAccCode)
                saveAcct();
            else if (tbcGL.SelectedTab == tabAccType2)
                saveAcctType2();
            else if (tbcGL.SelectedTab == tabSubAccounts)
                saveSubAccounts();
        }
        private void saveGL()
        {
            //Should not allove user to edit GL <<ANOJ 2017-02-20>>
            //if (CheckValidityGL())
            //{
            //    if (CheckStatusValidityGL())
            //    {
            //        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDGL, IsUpdateGL))
            //        {
            //            try
            //            {
            //                Cursor = Cursors.WaitCursor;
            //                if (txtGledgerGlCode.TextLength > 0)
            //                {
            //                    if (IsUpdateGL)  //update records
            //                    {
            //                        #region Update
            //                        tbl_zAccGLMaster_MainCatagory oldRecord = tbl_zAccGLMaster_MainCatagory.Select(txtGledgerGlCode.Text.Trim());
            //                        if (oldRecord != null)
            //                        {
            //                            //Chart Of accounts-GL
            //                            tbl_zAccGLMaster_MainCatagory detail = new tbl_zAccGLMaster_MainCatagory(oldRecord.Line_No, txtGledgerGlCode.Text.ToString(),
            //                                txtGledgerGlCode.Text.ToString(), txtGledgerGlName.Text.ToString(), clsMethods_GL.SendStatus(cmbGledgerStatus.Text.ToString()),
            //                                oldRecord.Counter, oldRecord.Length, oldRecord.Prefix, oldRecord.Seperator);

            //                            detail.Update();
            //                            clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditMessage.RecordModify), txtGledgerGlCode.Text.ToString(), txtGledgerGlName.Text.ToString(), "", "");
            //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                        #endregion
            //                    }
            //                    else  //insert records
            //                    {
            //                        #region Insert
            //                        int iCounter = 1, iLength = 2, iRowno = 0;
            //                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            //                            txtGledgerGlCode.Text = clsAutocode.getAutoGeneratedCode(sCFormIDGL);
            //                        //Chart Of accounts-GL
            //                        iRowno = clsMethods_Fin.GetMaxzimumLineNoGLMainCatagory();
            //                        tbl_zAccGLMaster_MainCatagory detail = new tbl_zAccGLMaster_MainCatagory((++iRowno), txtGledgerGlCode.Text.ToString(),
            //                            txtGledgerGlCode.Text.ToString(), txtGledgerGlName.Text.ToString(), clsMethods_GL.SendStatus(cmbGledgerStatus.Text.ToString()), iCounter, iLength, prefix, seperator);

            //                        detail.Insert();                                   

            //                        clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditMessage.RecordSave), txtGledgerGlCode.Text.ToString(), txtGledgerGlName.Text.ToString(), "", "");

            //                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information); 
            //                        #endregion
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Chat of Accounts - General Ledger " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                clsValidate.WriteErrorLog(ex.Message, iFormIDGL);
            //                SEACCException.Show(ex);
            //            }
            //            finally
            //            {
            //                Cursor = Cursors.Default;
            //                ClearFields();
            //            }
            //        }
            //    }
            //}
        }
        private void saveSubGL()
        {
            if (CheckValiditySubGL())
            {
                if (CheckStatusValiditySubGL())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDSubGL, IsUpdateSubGL))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtSubGledgerSubGlCode.TextLength > 0)
                            {
                                if (IsUpdateSubGL)
                                {
                                    #region update records
                                    tbl_zAccGLMaster_SubCatagory oldRecord = tbl_zAccGLMaster_SubCatagory.Select(txtSubGledgerSubGlCode.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSubGledgerSubGlCode.Text))
                                        {
                                            //Sub General Ledger
                                            tbl_zAccGLMaster_SubCatagory detail = new tbl_zAccGLMaster_SubCatagory(
                                                txtSubGledgerSubGlCode.Text.ToString(),
                                                txtSubGledgerSubGlName.Text.ToString(),
                                                clsMethods_GL.SendStatus(cmbSubGledgerStatus.Text.ToString()),
                                                txtSubGledgerGlCode.Text.ToString(), oldRecord.Line_No, oldRecord.Note);

                                            detail.Update();

                                            clsProcessMethods.Audit("GL",
                                                clsFormatter.GetMessageAudit(AuditStatus.RecordModify),
                                                txtSubGledgerSubGlCode.Text.ToString(),
                                                txtSubGledgerSubGlName.Text.ToString(), "", "");
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                        }
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region Insert records
                                    int iRowno = 0, iCounterSubGL = 1, iLength = 2;
                                    //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    //    txtGledgerGlCode.Text = clsAutocode.getAutoGeneratedCode(sCFormIDSubGL);
                                    if (clsAutocode.IsAutoGenerated(sCFormIDSubGL))
                                        txtSubGledgerSubGlCode.Text = clsAutocode.getAutoGeneratedCode(sCFormIDSubGL);

                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtSubGledgerSubGlCode.Text))
                                    {
                                        //Sub General Ledger
                                        iRowno = clsHelpMethods.GetMaxzimumLineNoSubGL(txtSubGledgerGlCode.Text.Trim());
                                        //tbl_zAccGLMaster_SubCatagory detail = new tbl_zAccGLMaster_SubCatagory( txtGledgerGlCode.Text.ToString(),
                                        tbl_zAccGLMaster_SubCatagory detail = new tbl_zAccGLMaster_SubCatagory(
                                            txtSubGledgerSubGlCode.Text.ToString(),
                                            txtSubGledgerSubGlName.Text.ToString(),
                                            clsMethods_GL.SendStatus(cmbSubGledgerStatus.Text.ToString()),
                                            txtSubGledgerGlCode.Text.ToString(), (++iRowno), 0);

                                        detail.Insert();

                                        clsProcessMethods.Audit("GL",
                                            clsFormatter.GetMessageAudit(AuditStatus.RecordSave),
                                            txtSubGledgerSubGlCode.Text.ToString(),
                                            txtSubGledgerSubGlName.Text.ToString(), "", "");

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone),
                                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chart Of Account - Sub General Ledger " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            populateTree();
                        }
                    }
                }
            }
        }
        private void saveAcctType()
        {
            if (CheckValidityAcctType())
            {
                if (CheckStatusValidityAcctType())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDAcctType, IsUpdateAcctType))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtAcctTypeCode.TextLength > 0)
                            {
                                if (IsUpdateAcctType)
                                {
                                    #region update
                                    bool IsCredit, IsActive;
                                    IsCredit = clsMethods_GL.SendDrCr(cmbAcctType.Text.ToString());
                                    IsActive = clsMethods_GL.SendStatus(cmbAcctTypeStatus.Text.ToString());

                                    tbl_zAccGLMaster_AccountType oldRecord = tbl_zAccGLMaster_AccountType.Select(txtAcctTypeCode.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Chart Of accounts-GL
                                        tbl_zAccGLMaster_AccountType detail = new tbl_zAccGLMaster_AccountType(txtAcctTypeCode.Text.Trim(),
                                            txtAcctTypeName.Text.Trim(), IsCredit, IsActive,
                                            txtAcctTypeSubGlCode.Text.Trim(), oldRecord.Line_No, oldRecord.Note, oldRecord.Counter, oldRecord.Parent_ID);

                                        detail.Update();

                                        clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordModify), txtAcctTypeCode.Text.ToString(), txtAcctTypeName.Text.ToString(), "", "");

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region insert
                                    int iRowno = 0, iCounterAcctType = 1, iLength = 3;
                                    bool IsCredit, IsActive;
                                    IsCredit = clsMethods_GL.SendDrCr(cmbAcctType.Text.ToString());
                                    IsActive = clsMethods_GL.SendStatus(cmbAcctTypeStatus.Text.ToString());

                                    //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    if (clsAutocode.IsAutoGenerated(sCFormIDAcctType))
                                        txtAcctTypeCode.Text = clsAutocode.getAutoGeneratedCode(sCFormIDAcctType);// clsAutocode.getFormConfigCode(FormName.accGeneralLedger, FormName.accAccountType);

                                    //Chart Of accounts-GL
                                    iRowno = clsHelpMethods.GetMaxzimumLineNoAcctType(txtAcctTypeSubGlCode.Text.Trim());
                                    tbl_zAccGLMaster_AccountType detail = new tbl_zAccGLMaster_AccountType(txtAcctTypeCode.Text.Trim(),
                                           txtAcctTypeName.Text.Trim(), IsCredit, IsActive,
                                            txtAcctTypeSubGlCode.Text.Trim(), (++iRowno), 0, 1, "default");

                                    detail.Insert();

                                    clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordSave), txtAcctTypeCode.Text.ToString(), txtAcctTypeName.Text.ToString(), "", "");

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    #endregion
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chat of Accounts - Acct Type " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            populateTree();
                        }
                    }
                }
            }
        }
        private void saveAcctType2()
        {
            if (CheckValidityAcctType2())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDAcctType2, IsUpdateAcctType2))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        if (txtAccType2Code.TextLength > 0)
                        {
                            if (IsUpdateAcctType2)
                            {
                                #region update
                                bool IsActive;
                                IsActive = clsMethods_GL.SendStatus(cmbAcctType2Status.Text.ToString());

                                tbl_zAccGLMaster_AccountType oldRecord = tbl_zAccGLMaster_AccountType.Select(txtAccType2Code.Text.Trim());
                                if (oldRecord != null)
                                {
                                    //Chart Of accounts-GL
                                    tbl_zAccGLMaster_AccountType detail = new tbl_zAccGLMaster_AccountType(txtAccType2Code.Text.Trim(),
                                        txtAccType2Name.Text.Trim(), true, IsActive,
                                        txtAccType2SubGLCode.Text.Trim(), oldRecord.Line_No, oldRecord.Note, oldRecord.Counter, oldRecord.Parent_ID);

                                    detail.Update();

                                    clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordModify), txtAccType2Code.Text.ToString(), txtAccType2Name.Text.ToString(), "", "");

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                #endregion
                            }
                            else
                            {
                                #region insert
                                int iRowno = 0, iCounterAcctType = 1, iLength = 3;
                                bool IsActive;
                                IsActive = clsMethods_GL.SendStatus(cmbAcctType2Status.Text.ToString());

                                //if (clsAutocode.IsAutoGenerated(sCFormIDAcctType2))
                                //    txtAccType2Code.Text = clsAutocode.getAutoGeneratedCode(sCFormIDAcctType2);
                                txtAccType2Code.Text = txtAccType2AccType1Code.Text.Trim() + "1";

                                //Chart Of accounts-GL
                                iRowno = clsHelpMethods.GetMaxzimumLineNoAcctType(txtAccType2SubGLCode.Text.Trim());
                                tbl_zAccGLMaster_AccountType detail = new tbl_zAccGLMaster_AccountType(txtAccType2Code.Text.Trim(),
                                       txtAccType2Name.Text.Trim(), true, IsActive,
                                        txtAccType2SubGLCode.Text.Trim(), (++iRowno), 0, 1, txtAccType2AccType1Code.Text.Trim());

                                detail.Insert();

                                clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordSave), txtAccType2Code.Text.ToString(), txtAccType2Name.Text.ToString(), "", "");

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                #endregion
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chat of Accounts - Acct Type " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        ClearFields();
                        populateTree();
                    }
                }
            }
        }
        private void saveAcct()
        {
            if (CheckValidityAcct())
            {
                if (CheckStatusValidityAcct())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDAcct, IsUpadteAcctCode))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtAcctCode.TextLength > 0)
                            {
                                if (IsUpadteAcctCode)  //update records
                                {
                                    #region Update records
                                    tbl_accGLMaster oldRecord = tbl_accGLMaster.Select(txtAcctCode.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        bool IsActive = false, IsTmade = false, bStatus = true;
                                        string sControlAccType = "";
                                        int iRowno = 0;
                                        IsActive = clsMethods_GL.SendStatus(cmbAcctCodeStatus.Text.ToString());

                                        #region Status - Active
                                        if (!IsActive)
                                        {
                                            List<tbl_accGLPosting_Detail> oPostingDetail = tbl_accGLPosting_Detail.SelectAllByGl_ID(oldRecord.Gl_ID).ToList();
                                            if (oPostingDetail != null && oPostingDetail.Count > 0)
                                            {
                                                bStatus = false;
                                            }

                                            else
                                            {
                                                //List<tbl_accGLPosting_Detail_Tmp> oPostingDetailTemp = tbl_accGLPosting_Detail_Tmp.SelectAllByGl_ID(oldRecord.Gl_ID).ToList();
                                                //if (oPostingDetailTemp != null && oPostingDetailTemp.Count > 0)
                                                //{
                                                //    bStatus = false;
                                                //}
                                            }

                                            if (bStatus == false)
                                                MessageBox.Show("There are records for this Acc. Code." + "\n" + "Cannot Inactive !!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        #endregion

                                        if (bStatus)
                                        {
                                            if (txtSortOrder.TextLength > 0)
                                                iRowno = int.Parse(txtSortOrder.Text.ToString());
                                            else
                                                iRowno = oldRecord.Line_No;

                                            #region Control Account Type Select
                                            
                                            if (cmbControlAcc.SelectedIndex == 0)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other);
                                            if (cmbControlAcc.SelectedIndex == 1)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor);
                                            if (cmbControlAcc.SelectedIndex == 2)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor);
                                            if (cmbControlAcc.SelectedIndex == 3)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank);
                                            if (cmbControlAcc.SelectedIndex == 4)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash);
                                            if (cmbControlAcc.SelectedIndex == 5)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Inventory);
                                            if (cmbControlAcc.SelectedIndex == 6)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.SalesAccount);
                                            if (cmbControlAcc.SelectedIndex == 7)
                                                sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Tax);
                                            #endregion

                                            //Chart Of accounts-Acct Code
                                            tbl_accGLMaster detail = new tbl_accGLMaster(iRowno, txtAcctCode.Text.Trim(), txtAcctCodeName.Text.ToString(),
                                                oldRecord.GlAccountType_ID, txtGLNoteID.Tag.ToString().Trim(), clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                                clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), !IsActive, sControlAccType);
                                            detail.Update();

                                            #region Update GL ID to Masters
                                            //if (txtCustomerID.Tag != null)
                                            //{
                                            //    tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(txtCustomerID.Text.ToString());
                                            //    if (CusDetail != null)
                                            //    {
                                            //        CusDetail.Gl_ID = txtAcctCode.Text.Trim();
                                            //        CusDetail.Update();
                                            //    }
                                            //}

                                            //if (txtSupplireID.Tag != null)
                                            //{
                                            //    tbl_genSupplierMaster SupDetail1 = tbl_genSupplierMaster.Select(txtSupplireID.Text.ToString());//u
                                            //    if (SupDetail1 != null)
                                            //    {
                                            //        SupDetail1.Gl_ID = txtAcctCode.Text.Trim();
                                            //        SupDetail1.Update();
                                            //    }
                                            //}

                                            //if (txtEmployeeID.Tag != null)
                                            //{
                                            //    tbl_genEmployeeMaster EmpDetail = tbl_genEmployeeMaster.Select(txtEmployeeID.Text.ToString());
                                            //    if (EmpDetail != null)
                                            //    {
                                            //        EmpDetail.Gl_ID = txtAcctCode.Text.Trim();
                                            //        EmpDetail.Update();
                                            //    }
                                            //}

                                            //if (txtBankAccNo.Tag != null)
                                            //{
                                            //    tbl_genCompanyAccount bankDetail = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, txtBankAccNo.Text.ToString());
                                            //    if (bankDetail != null)
                                            //    {
                                            //        bankDetail.ControlAcc = txtAcctCode.Text.Trim();
                                            //        bankDetail.Update();
                                            //    }
                                            //}
                                            #endregion

                                            clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordModify), txtAcctCode.Text.ToString(), txtAcctCodeName.Text.ToString(), "", "");

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region Insert  records
                                    int iRowno = 0;
                                    bool IsActive = true, IsTmade = false;
                                    string sControlAccType = "";

                                    #region Control Account Type Select
                                    
                                    if (cmbControlAcc.SelectedIndex == 0)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other);
                                    if (cmbControlAcc.SelectedIndex == 1)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor);
                                    if (cmbControlAcc.SelectedIndex == 2)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor);
                                    if (cmbControlAcc.SelectedIndex == 3)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank);
                                    if (cmbControlAcc.SelectedIndex == 4)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash);
                                    if (cmbControlAcc.SelectedIndex == 5)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Inventory);
                                    if (cmbControlAcc.SelectedIndex == 6)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.SalesAccount);
                                    if (cmbControlAcc.SelectedIndex == 7)
                                        sControlAccType = clsAutocode.getControlAccount_Types(enum_ControlAccountType.Tax);
                                    #endregion

                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        //txtAcctCode.Text = clsAutocode.getAutoGeneratedCode(sCFormIDAcct); ;//sFormConfigCodeAcctCodeReduCode, sFormConfigCodeAcctCodeAddCode);
                                        //txtAcctCode.Text = clsAutocode.getAutoGeneratedCode(txtAcctCodeGlCode.Text.ToString(), txtAcctCodeSubGlCode.Text.ToString(), txtAcctCodeTypeCode.Text.ToString());


                                        if (clsAutocode.IsAutoGenerated(sCFormIDAcctCode))
                                            txtAcctCode.Text = clsAutocode.getAutoGeneratedCode_AccCode(sCFormIDAcctCode, txtAcctCodeGlCode.Text, txtAcctCodeSubGlCode.Text, txtAcctCodeTypeCode.Text);


                                    //Chart Of accounts-Acct Code                                   
                                    iRowno = clsHelpMethods.GetMaxzimumLineNoAcctCode(txtAcctCodeTypeCode.Text.Trim());
                                    if (txtSortOrder.TextLength > 0)
                                        iRowno = int.Parse(txtSortOrder.Text.ToString());

                                    tbl_accGLMaster detail = new tbl_accGLMaster((++iRowno), txtAcctCode.Text.Trim(),
                                         txtAcctCodeName.Text.ToString(), txtAcctCodeType2Code.Text.Trim(), txtGLNoteID.Tag.ToString().Trim(), clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, sControlAccType);
                                    detail.Insert();

                                    #region Update GL ID to Masters
                                    if (txtCustomerID.Tag != null)
                                    {
                                        tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                                        if (CusDetail != null)
                                        {
                                            CusDetail.Gl_ID = txtAcctCode.Text.Trim();
                                            CusDetail.Update();
                                        }
                                    }

                                    //if (txtSupplireID.Tag != null)
                                    //{
                                    //    tbl_genSupplierMaster SupDetail = tbl_genSupplierMaster.Select(txtSupplireID.Tag.ToString());
                                    //    if (SupDetail != null)
                                    //    {
                                    //        SupDetail.Gl_ID = txtAcctCode.Text.Trim();
                                    //        SupDetail.Update();
                                    //    }
                                    //}

                                    if (txtEmployeeID.Tag != null)
                                    {
                                        tbl_genEmployeeMaster EmpDetail = tbl_genEmployeeMaster.Select(txtEmployeeID.Tag.ToString());
                                        if (EmpDetail != null)
                                        {
                                            EmpDetail.Gl_ID = txtAcctCode.Text.Trim();
                                            EmpDetail.Update();
                                        }
                                    }

                                    if (txtBankAccNo.Tag != null)
                                    {
                                        tbl_genCompanyAccount bankDetail = tbl_genCompanyAccount.Select( txtBankAccNo.Text.ToString());
                                        if (bankDetail != null)
                                        {
                                            bankDetail.ControlAcc = txtAcctCode.Text.Trim();
                                            bankDetail.Update();
                                        }
                                    }
                                    #endregion

                                    clsProcessMethods.Audit("GL", clsFormatter.GetMessageAudit(AuditStatus.RecordSave), txtAcctCode.Text.ToString(), txtAcctCodeName.Text.ToString(), "", "");
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    #endregion
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chart of Accounts - Acct Code " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormIDAcct, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            populateTree();
                        }
                    }
                }
            }
        }
        private void saveSubAccounts()
        {
            if (CheckValiditySubAccount())
            {
                if (CheckStatusValiditySubAccount())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormIDAcctType, IsUpadteSubAccount))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (txtAcctCode1.TextLength > 0)
                            {
                                if (true)
                                {
                                    bool bStatus = true;
                                    string sCustomer = "";

                                    #region insert
                                    tbl_accGLMaster oGL = tbl_accGLMaster.Select(txtAcctCode1.Text.Trim());
                                    if (oGL != null && oGL.Gl_ID != "default")
                                    {
                                        #region Customer
                                        string sError = "";
                                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                                        {
                                            string sCustomerCode = clsValidate.ValidateGridValue(dgvCustomer, "CustomerCode", row.Index, "default");
                                            tbl_accGLMaster_Customer oCustomer = tbl_accGLMaster_Customer.Select(sCustomerCode);
                                            if (oCustomer == null)
                                            {
                                                tbl_accGLMaster_Customer oCustomerAcc = new tbl_accGLMaster_Customer(sCustomerCode, txtAcctCode1.Text.Trim(), true);
                                                oCustomerAcc.Insert();
                                            }
                                            else
                                            {
                                                sError += sCustomerCode + " - " + clsGenaralName.getName_Customer(sCustomerCode) + "\n";
                                            }
                                        }
                                        if (sError != "")
                                        {
                                            MessageBox.Show("Following Customers are already assigned." + "\n" + sError, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        #endregion

                                        #region Suppliers
                                        tbl_accGLMaster_Supplier.DeleteAllByGl_ID(oGL.Gl_ID);
                                        foreach (DataGridViewRow row in dgvSupplier.Rows)
                                        {
                                            tbl_accGLMaster_Supplier detail = new tbl_accGLMaster_Supplier(oGL.Gl_ID, clsValidate.ValidateGridValue(dgvSupplier, "SupplierCode", row.Index, "default"), true);
                                            detail.Insert();
                                        }
                                        #endregion

                                        #region Employees
                                        tbl_accGLMaster_Employee.DeleteAllByGl_ID(oGL.Gl_ID);
                                        foreach (DataGridViewRow row in dgvEmployee.Rows)
                                        {
                                            tbl_accGLMaster_Employee detail = new tbl_accGLMaster_Employee(oGL.Gl_ID, clsValidate.ValidateGridValue(dgvEmployee, "EmployeeCode", row.Index, "default"), true);
                                            detail.Insert();
                                        }
                                        #endregion

                                        #region Banks
                                        tbl_accGLMaster_Bank.DeleteAllByGl_ID(oGL.Gl_ID);
                                        foreach (DataGridViewRow row in dgvBank.Rows)
                                        {
                                            tbl_accGLMaster_Bank detail = new tbl_accGLMaster_Bank(oGL.Gl_ID, clsValidate.ValidateGridValue(dgvBank, "BankNo", row.Index, "default"), true);
                                            detail.Insert();
                                        }
                                        #endregion

                                        #region CostCenter 1
                                        tbl_accGLMaster_CostCenter1.DeleteAllByGl_ID(oGL.Gl_ID);
                                        foreach (DataGridViewRow row in dgvCostCenter1.Rows)
                                        {
                                            tbl_accGLMaster_CostCenter1 detail = new tbl_accGLMaster_CostCenter1(oGL.Gl_ID, clsValidate.ValidateGridValue(dgvCostCenter1, "CostCenter1Code", row.Index, "default"), true);
                                            detail.Insert();
                                        }
                                        #endregion

                                        #region CostCenter 2
                                        tbl_accGLMaster_CostCenter2.DeleteAllByGl_ID(oGL.Gl_ID);
                                        foreach (DataGridViewRow row in dgvCostCenter2.Rows)
                                        {
                                            tbl_accGLMaster_CostCenter2 detail = new tbl_accGLMaster_CostCenter2(oGL.Gl_ID, clsValidate.ValidateGridValue(dgvCostCenter2, "CostCenter2Code", row.Index, "default"), true);
                                            detail.Insert();
                                        }
                                        #endregion

                                    }

                                    if (bStatus)
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (!bStatus)
                                        MessageBox.Show("Following customers are not saved as they are not in the database \n" + sCustomer, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    #endregion
                                }
                            }
                            else
                                MessageBox.Show("GL Account Code" + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            populateTree();
                        }
                    }
                }
            }
        }
        #endregion

        #region btn Expand All
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            bookTree.ExpandAll();
        }
        #endregion

        #region btn Collapse
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            bookTree.CollapseAll();
        }
        #endregion

        #region btn Sort
        private void btnSort_Click(object sender, EventArgs e)
        {
            bookTree.Sort();
        }
        #endregion

        #region btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bookTree.Refresh();
        }
        #endregion

        #region Treeview Tab Click
        private void tbcGL_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbcGL.SelectedTab == tabSubAccounts)
            {

            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            //clsFormatter.ApplyGridFormat(dgvDetail);
            //clsFormatter.ApplyGridFormat(dgvSubGL);
            //clsFormatter.ApplyGridFormat(dgvAcctType);
            //clsFormatter.ApplyGridFormat(dgvAcctType2);
            //clsFormatter.ApplyGridFormat(dgvAcct);

            clsFormatter.ApplyGridFormat(dgvCostCenter1);
            clsFormatter.ApplyGridFormat(dgvCostCenter2);
            clsFormatter.ApplyGridFormat(dgvSupplier);
            clsFormatter.ApplyGridFormat(dgvCustomer);
            clsFormatter.ApplyGridFormat(dgvEmployee);
            clsFormatter.ApplyGridFormat(dgvBank);

            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvSubGL);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvAcctType);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvAcctType2);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvAcct);            
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdateGL = false;
            IsUpdateSubGL = false;
            IsUpdateAcctType = false;
            IsUpdateAcctType2 = false;
            IsUpadteAcctCode = false;
            IsUpadteSubAccount = false;
            txtGLNoteID.Tag = "default";
            txtAcctCode.Text = "default";
            pnlContralButtons.Visible = true;

            try
            {
                if (tbcGL.SelectedTab == tabGL)
                    SetFormForGeneralLedger();
                else if (tbcGL.SelectedTab == tabSubGL)
                    SetFormForSubGeneralLedger();
                else if (tbcGL.SelectedTab == tabAccType1)
                    SetFormForAcctType();
                else if (tbcGL.SelectedTab == tabAccType2)
                    SetFormForAcctType2();
                else if (tbcGL.SelectedTab == tabAccCode)
                    SetFormForAcct();
                else if (tbcGL.SelectedTab == tabSubAccounts)
                    SetFormForSubAccount();

                //bookTree.Nodes.Clear();
                //populateTree();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Clear Accounts Fields
        private void ClearAccountsFields()
        {
            txtCustomerID.Clear();
            txtEmployeeID.Clear();
            txtSupplireID.Clear();
            txtBankAccNo.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridGeneralLedger()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                foreach (tbl_zAccGLMaster_MainCatagory detail in tbl_zAccGLMaster_MainCatagory.SelectAll())
                {
                    if (detail.GlMainCatagory_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["GLCode", iRow].Value = detail.GlMainCatagory_ID;
                        dgvDetail["GLName", iRow].Value = detail.GlMainCatagoryName;
                        dgvDetail["GLStatus", iRow].Value = clsMethods_GL.GetSatus(detail.IsActive);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridSubGeneralLedger()
        {
            try
            {
                //int iRow;
                //dgvSubGL.Rows.Clear();
                sourceSubGeneralLedger.Filter = "";
                dtAllRecodesSubGeneralLedger.Rows.Clear();

                List<tbl_zAccGLMaster_SubCatagory> details = tbl_zAccGLMaster_SubCatagory.SelectAll();
                foreach (tbl_zAccGLMaster_SubCatagory detail in details)
                {
                    //if (detail.GlSubCatagory_ID.Trim() != "default")
                    //{
                    //    dgvSubGL.Rows.Add();
                    //    iRow = dgvSubGL.Rows.Count - 1;
                    //    dgvSubGL["SubGLCode", iRow].Value = detail.GlSubCatagory_ID;
                    //    dgvSubGL["SubGLName", iRow].Value = detail.GlSubCatagoryName;
                    //    dgvSubGL["SubGLStatus", iRow].Value = clsMethods_GL.GetSatus(detail.IsActive);
                    //}
                    if (detail.GlSubCatagory_ID.Trim() != "default")
                        dtAllRecodesSubGeneralLedger.Rows.Add(detail.GlSubCatagory_ID, detail.GlSubCatagoryName, clsMethods_GL.GetSatus(detail.IsActive), detail.GlMainCatagory_ID);
                }
                sourceSubGeneralLedger.DataSource = dtAllRecodesSubGeneralLedger;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridAcctType()
        {
            try
            {
                //int iRow;
                //dgvAcctType.Rows.Clear();

                sourceAccountType.Filter = "";
                //dtAllRecodesAccType.Rows.Clear();

                //List<tbl_zAccGLMaster_AccountType> details = tbl_zAccGLMaster_AccountType.SelectAll();
                //foreach (tbl_zAccGLMaster_AccountType detail in details)
                //{
                //    //if (detail.GlAccountType_ID.Trim() != "default")
                //    //{
                //    //    dgvAcctType.Rows.Add();
                //    //    iRow = dgvAcctType.Rows.Count - 1;
                //    //    dgvAcctType["AcctTypeCode", iRow].Value = detail.GlAccountType_ID;
                //    //    dgvAcctType["AcctTypeName", iRow].Value = detail.GlAccountTypeName;
                //    //    dgvAcctType["AcctTypeStatus", iRow].Value = clsMethods_GL.GetSatus(detail.IsActive);
                //    //    dgvAcctType["AcctType", iRow].Value = clsHelpMethods.GetDrCr(detail.IsCredit);
                //    //    dgvAcctType["GLSubCatagory_ID2", iRow].Value = detail.GlSubCatagory_ID;

                //    //}
                //if (detail.GlAccountType_ID.Trim() != "default")
                //dtAllRecodesAccType.Rows.Add(detail.GlAccountType_ID, detail.GlAccountTypeName, clsMethods_GL.GetSatus(detail.IsActive), clsMethods_GL.GetDrCr(detail.IsCredit), detail.GlSubCatagory_ID);
                //}
                sourceAccountType.DataSource = DBHandling.ExecQuery("SELECT glAccountType_ID as AcctTypeCode, glAccountTypeName as AcctTypeName, CASE WHEN isActive = 'true' THEN 'Active' ELSE  'In-Active' END as AcctTypeStatus, glSubCatagory_ID as GLSubCatagory_ID2 FROM vw_AccGLMaster_AccountType1").Tables[0];
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridAcctType2()
        {
            try
            {
                sourceAccountType2.Filter = "";
                sourceAccountType2.DataSource = DBHandling.ExecQuery("SELECT glAccountType_ID as AcctType2Code, glAccountTypeName as AcctType2Name, CASE WHEN isActive = 'true' THEN 'Active' ELSE  'In-Active' END as AcctType2Status, glSubCatagory_ID as GLSubCatagory_ID2 FROM vw_AccGLMaster_AccountType2").Tables[0];
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridAcct()
        {
            try
            {
                sourceAccountCode.Filter = "";
                dtAllRecodesAccCode.Rows.Clear();
                List<tbl_accGLMaster> details = tbl_accGLMaster.SelectAll();
                foreach (tbl_accGLMaster detail in details)
                {
                    if (detail.Gl_ID.Trim() != "default")
                        //dtAllRecodesAccCode.Rows.Add(detail.Gl_ID, detail.GlName, "", clsMethods_GL.GetSatus(true), clsGenaralName.getID_GlAccountType2ByParentID(detail.GlAccountType_ID), detail.GlAccountType_ID, "", "");
                        dtAllRecodesAccCode.Rows.Add(detail.Gl_ID, detail.GlName, "", clsMethods_GL.GetSatus(!detail.IsDeleted), clsGenaralName.getID_GlAccountType2ByParentID(detail.GlAccountType_ID), detail.GlAccountType_ID, "", "");
                }
                sourceAccountCode.DataSource = dtAllRecodesAccCode;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcct, ex);
                SEACCException.Show(ex);
            }
        }

        #region Refresh Grid Other
        private void RefreshGridCustomer(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sCustomerID)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvCustomer.Rows.Clear();
                    //List<tbl_genCustomerMaster> details = tbl_genCustomerMaster.SelectAll();
                    //foreach (tbl_genCustomerMaster detail in details)
                    //{
                    //    if (detail.Customer_ID.Trim() != "default")
                    //    {
                    //        dgvCustomer.Rows.Add();
                    //        iRow = dgvCustomer.Rows.Count - 1;
                    //        dgvCustomer["CustomerCode", iRow].Value = detail.Customer_ID;
                    //        dgvCustomer["CustomerName", iRow].Value = detail.CustomerName;
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow = 0;
                    //dgvCustomer.Rows.Clear();
                    //List<tbl_accGLMaster_Customer> details = tbl_accGLMaster_Customer.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_Customer detail in details)
                    //{
                    //    if (detail.Customer_ID.Trim() != "default")
                    //    {
                    //        dgvCustomer.Rows.Add();
                    //        iRow = dgvCustomer.Rows.Count - 1;
                    //        dgvCustomer["CustomerCode", iRow].Value = detail.Customer_ID;
                    //        dgvCustomer["CustomerName", iRow].Value = clsGenaralName.getName_Customer(detail.Customer_ID);
                    //    }
                    //}
                }
                else if (sCustomerID != "default" && sCustomerID.Length > 0)
                {
                    //dgvCustomer.Rows.Add();
                    //int iRow = dgvCustomer.Rows.Count - 1;
                    //dgvCustomer["CustomerCode", iRow].Value = sCustomerID;
                    //dgvCustomer["CustomerName", iRow].Value = clsGenaralName.getName_Customer(sCustomerID);
                }

                //if (dgvCustomer.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpCustomers;
                //    tpCustomers.Text = "Customers - " + "(" + dgvCustomer.Rows.Count.ToString() + ")";
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridSupplier(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sSupplierID)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvSupplier.Rows.Clear();
                    //List<tbl_genSupplierMaster> details = tbl_genSupplierMaster.SelectAll();
                    //foreach (tbl_genSupplierMaster detail in details)
                    //{
                    //    if (detail.Supplier_ID.Trim() != "default")
                    //    {
                    //        dgvSupplier.Rows.Add();
                    //        iRow = dgvSupplier.Rows.Count - 1;
                    //        dgvSupplier["SupplierCode", iRow].Value = detail.Supplier_ID;
                    //        dgvSupplier["SupplierName", iRow].Value = detail.SupplierName;
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow;
                    //dgvSupplier.Rows.Clear();
                    //List<tbl_accGLMaster_Supplier> details = tbl_accGLMaster_Supplier.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_Supplier detail in details)
                    //{
                    //    if (detail.Supplier_ID.Trim() != "default")
                    //    {
                    //        dgvSupplier.Rows.Add();
                    //        iRow = dgvSupplier.Rows.Count - 1;
                    //        dgvSupplier["SupplierCode", iRow].Value = detail.Supplier_ID;
                    //        dgvSupplier["SupplierName", iRow].Value = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    //    }
                    //}
                }
                else if (sSupplierID != "default" && sSupplierID.Length > 0)
                {
                    //dgvSupplier.Rows.Add();
                    //int iRow = dgvSupplier.Rows.Count - 1;
                    //dgvSupplier["SupplierCode", iRow].Value = sSupplierID;
                    //dgvSupplier["SupplierName", iRow].Value = clsGenaralName.getName_Supplier(sSupplierID);
                }

                //if (dgvSupplier.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpSuppliers;
                //    tpSuppliers.Text = "Suppliers - " + "(" + dgvSupplier.Rows.Count.ToString() + ")";

                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridEmployee(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sEmployeeID)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvEmployee.Rows.Clear();
                    //List<tbl_genEmployeeMaster> details = tbl_genEmployeeMaster.SelectAll();
                    //foreach (tbl_genEmployeeMaster detail in details)
                    //{
                    //    if (detail.Employee_ID.Trim() != "default")
                    //    {
                    //        dgvEmployee.Rows.Add();
                    //        iRow = dgvEmployee.Rows.Count - 1;
                    //        dgvEmployee["EmployeeCode", iRow].Value = detail.Employee_ID;
                    //        dgvEmployee["EmployeeName", iRow].Value = detail.EmployeeName;
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow;
                    //dgvEmployee.Rows.Clear();
                    //List<tbl_accGLMaster_Employee> details = tbl_accGLMaster_Employee.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_Employee detail in details)
                    //{
                    //    if (detail.Employee_ID.Trim() != "default")
                    //    {
                    //        dgvEmployee.Rows.Add();
                    //        iRow = dgvEmployee.Rows.Count - 1;
                    //        dgvEmployee["EmployeeCode", iRow].Value = detail.Employee_ID;
                    //        dgvEmployee["EmployeeName", iRow].Value = clsGenaralName.getName_Employee(detail.Employee_ID);
                    //    }
                    //}
                }
                //else if (sEmployeeID != "default" && sEmployeeID.Length > 0)
                //{
                //    dgvEmployee.Rows.Add();
                //    int iRow = dgvEmployee.Rows.Count - 1;
                //    dgvEmployee["EmployeeCode", iRow].Value = sEmployeeID;
                //    dgvEmployee["EmployeeName", iRow].Value = clsGenaralName.getName_Employee(sEmployeeID);
                //}

                //if (dgvEmployee.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpEmployees;
                //    tpEmployees.Text = "Employees - " + "(" + dgvEmployee.Rows.Count.ToString() + ")";
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridBank(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sBankAccNo)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvBank.Rows.Clear();
                    //List<tbl_genCompanyAccount> details = tbl_genCompanyAccount.SelectAll();
                    //foreach (tbl_genCompanyAccount detail in details)
                    //{
                    //    if (detail.AccountNumber.Trim() != "default" && detail.CompanyID.Trim() != "default")
                    //    {
                    //        dgvBank.Rows.Add();
                    //        iRow = dgvBank.Rows.Count - 1;
                    //        dgvBank["BankNo", iRow].Value = detail.AccountNumber;
                    //        dgvBank["BankName", iRow].Value = clsGenaralName.getName_Bank(detail.Bank_ID);
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow;
                    //dgvBank.Rows.Clear();
                    //List<tbl_accGLMaster_Bank> details = tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_Bank detail in details)
                    //{
                    //    if (detail.AccountNumber.Trim() != "default")
                    //    {
                    //        dgvBank.Rows.Add();
                    //        iRow = dgvBank.Rows.Count - 1;
                    //        dgvBank["BankNo", iRow].Value = detail.AccountNumber;
                    //        dgvBank["BankName", iRow].Value = clsGenaralName.getName_CompanyBankNameByAccountNo(detail.AccountNumber);
                    //    }
                    //}
                }
                else if (sBankAccNo != "default" && sBankAccNo.Length > 0)
                {
                    //dgvBank.Rows.Add();
                    //int iRow = dgvBank.Rows.Count - 1;
                    //dgvBank["BankNo", iRow].Value = sBankAccNo;
                    //dgvBank["BankName", iRow].Value = clsGenaralName.getName_CompanyBankNameByAccountNo(sBankAccNo);
                }

                //if (dgvBank.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpBanks;
                //    tpBanks.Text = "Banks - " + "(" + dgvBank.Rows.Count.ToString() + ")";
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridCostCenter1(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sCostCenter1)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvCostCenter1.Rows.Clear();
                    //List<tbl_zAccCostCenter1> details = tbl_zAccCostCenter1.SelectAll();
                    //foreach (tbl_zAccCostCenter1 detail in details)
                    //{
                    //    if (detail.CostCenter1_ID.Trim() != "default" && detail.CostCenter1_ID.Trim() != "default")
                    //    {
                    //        dgvCostCenter1.Rows.Add();
                    //        iRow = dgvCostCenter1.Rows.Count - 1;
                    //        dgvCostCenter1["CostCenter1Code", iRow].Value = detail.CostCenter1_ID;
                    //        dgvCostCenter1["CostCenter1Name", iRow].Value = clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID);
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow;
                    //dgvCostCenter1.Rows.Clear();
                    //List<tbl_accGLMaster_CostCenter1> details = tbl_accGLMaster_CostCenter1.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_CostCenter1 detail in details)
                    //{
                    //    if (detail.CostCenter1_ID.Trim() != "default")
                    //    {
                    //        dgvCostCenter1.Rows.Add();
                    //        iRow = dgvCostCenter1.Rows.Count - 1;
                    //        dgvCostCenter1["CostCenter1Code", iRow].Value = detail.CostCenter1_ID;
                    //        dgvCostCenter1["CostCenter1Name", iRow].Value = clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID);
                    //    }
                    //}
                }
                else if (sCostCenter1 != "default" && sCostCenter1.Length > 0)
                {
                    //dgvCostCenter1.Rows.Add();
                    //int iRow = dgvCostCenter1.Rows.Count - 1;
                    //dgvCostCenter1["CostCenter1Code", iRow].Value = sCostCenter1;
                    //dgvCostCenter1["CostCenter1Name", iRow].Value = clsGenaralName.getName_AccCostCenter1(sCostCenter1);
                }

                //if (dgvCostCenter1.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpCostCenter1;
                //    tpCostCenter1.Text = "Cost Center-1 - " + "(" + dgvCostCenter1.Rows.Count.ToString() + ")";
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridCostCenter2(bool bAddAll, bool bFillFromGLCode, string sGLCode, string sCostCenter2)
        {
            try
            {
                if (bAddAll)
                {
                    int iRow;
                    //dgvCostCenter2.Rows.Clear();
                    //List<tbl_zAccCostCenter2> details = tbl_zAccCostCenter2.SelectAll();
                    //foreach (tbl_zAccCostCenter2 detail in details)
                    //{
                    //    if (detail.CostCenter2_ID.Trim() != "default" && detail.CostCenter2_ID.Trim() != "default")
                    //    {
                    //        dgvCostCenter2.Rows.Add();
                    //        iRow = dgvCostCenter2.Rows.Count - 1;
                    //        dgvCostCenter2["CostCenter2Code", iRow].Value = detail.CostCenter2_ID;
                    //        dgvCostCenter2["CostCenter2Name", iRow].Value = clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID);
                    //    }
                    //}
                }
                else if (bFillFromGLCode)
                {
                    int iRow;
                    //dgvCostCenter2.Rows.Clear();
                    //List<tbl_accGLMaster_CostCenter2> details = tbl_accGLMaster_CostCenter2.SelectAllByGl_ID(sGLCode);
                    //foreach (tbl_accGLMaster_CostCenter2 detail in details)
                    //{
                    //    if (detail.CostCenter2_ID.Trim() != "default")
                    //    {
                    //        dgvCostCenter2.Rows.Add();
                    //        iRow = dgvCostCenter2.Rows.Count - 1;
                    //        dgvCostCenter2["CostCenter2Code", iRow].Value = detail.CostCenter2_ID;
                    //        dgvCostCenter2["CostCenter2Name", iRow].Value = clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID);
                    //    }
                    //}
                }
                else if (sCostCenter2 != "default" && sCostCenter2.Length > 0)
                {
                    //dgvCostCenter2.Rows.Add();
                    //int iRow = dgvCostCenter2.Rows.Count - 1;
                    //dgvCostCenter2["CostCenter2Code", iRow].Value = sCostCenter2;
                    //dgvCostCenter2["CostCenter2Name", iRow].Value = clsGenaralName.getName_AccCostCenter2(sCostCenter2);
                }

                //if (dgvCostCenter2.Rows.Count > 0)
                //{
                //    tbcSubAccounts.SelectedTab = tpCostCenter2;
                //    tpCostCenter2.Text = "Cost Center - 2 - " + "(" + dgvCostCenter2.Rows.Count.ToString() + ")";
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #endregion

        #region Fill Details
        private void FillDetailsGL(string sGL)
        {
            try
            {
                if (sGL.Length > 0)
                {
                    tbl_zAccGLMaster_MainCatagory detail = tbl_zAccGLMaster_MainCatagory.Select(sGL);
                    if (detail != null)
                    {
                        IsUpdateGL = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGledgerGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblGledgerGlCode, false);

                        txtGledgerGlCode.Text = detail.GlMainCatagory_ID;
                        txtGledgerGlName.Text = detail.GlMainCatagoryName;
                        cmbGledgerStatus.Text = clsMethods_GL.GetSatus(detail.IsActive);

                        if (!detail.IsPNLAccount)
                            cmbGLType.SelectedIndex = 0;
                        else
                            cmbGLType.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsSubGL(string sSubGL)
        {
            try
            {
                if (sSubGL.Length > 0)
                {
                    //sourceSubGeneralLedger.Filter = "";
                    tbl_zAccGLMaster_SubCatagory detail = tbl_zAccGLMaster_SubCatagory.Select(sSubGL);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateSubGL = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSubGledgerGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSubGledgerGlCode, false);
                        clsFormatter.Format_TextBox_DisableMode(txtSubGledgerGlName);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSubGledgerSubGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSubGledgerSubGlCode, false);

                        //asign values
                        txtSubGledgerSubGlCode.Text = detail.GlSubCatagory_ID;
                        txtSubGledgerSubGlName.Text = detail.GlSubCatagoryName;
                        txtSubGledgerGlCode.Text = detail.GlMainCatagory_ID;
                        txtSubGledgerGlName.Text = clsGenaralName.getName_GLMainCatagory(detail.GlMainCatagory_ID);
                        cmbSubGledgerStatus.Text = clsMethods_GL.GetSatus(detail.IsActive);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsAcctType(string sAcctCode)
        {
            try
            {
                if (sAcctCode.Length > 0)
                {
                    //sourceAccountType.Filter = "";

                    tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(sAcctCode);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateAcctType = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAcctTypeGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctTypeGlCode, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAcctTypeSubGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctTypeSubGlCode, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAcctTypeCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctTypeCode, false);

                        //asign values                        
                        txtAcctTypeSubGlName.Text = clsGenaralName.getName_GLSubCatagory(detail.GlSubCatagory_ID);
                        txtAcctTypeCode.Text = detail.GlAccountType_ID;
                        txtAcctTypeName.Text = detail.GlAccountTypeName;
                        cmbSubGledgerStatus.Text = clsMethods_GL.GetSatus(detail.IsActive);//txtAcctTypeSubGlCode

                        tbl_zAccGLMaster_SubCatagory detail1 = tbl_zAccGLMaster_SubCatagory.Select(detail.GlSubCatagory_ID);
                        if (detail1 != null)
                            txtAcctTypeGlCode.Text = detail1.GlMainCatagory_ID;

                        txtAcctTypeGlName.Text = clsGenaralName.getName_GLMainCatagory(txtAcctTypeGlCode.Text.Trim());//clsGenaralName.getName_GL(detail.GlMainCatagory_ID);
                        txtAcctTypeSubGlCode.Text = detail.GlSubCatagory_ID;

                        cmbAcctTypeStatus.Text = clsMethods_GL.GetSatus(detail.IsActive);
                        cmbAcctType.Text = clsMethods_GL.GetDrCr(detail.IsCredit);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsAcctType2(string sAcctType2)
        {
            try
            {
                if (sAcctType2.Length > 0)
                {
                    //sourceAccountType2.Filter = "";

                    tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(sAcctType2);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateAcctType2 = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccType2GLCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAccType2GLCode, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccType2SubGLCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAccType2SubGLCode, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccType2AccType1Code, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAccType2AccType1Code, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccType2Code, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAccType2Code, false);

                        //asign values                        
                        txtAccType2Code.Text = detail.GlAccountType_ID;
                        txtAccType2Name.Text = detail.GlAccountTypeName;
                        cmbAcctType2Status.Text = clsMethods_GL.GetSatus(detail.IsActive);

                        txtAccType2GLCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(detail.GlSubCatagory_ID);
                        txtAccType2GLName.Text = clsGenaralName.getName_GLMainCatagory(txtAccType2GLCode.Text.Trim());

                        txtAccType2SubGLCode.Text = detail.GlSubCatagory_ID;
                        txtAccType2SubGLName.Text = clsGenaralName.getName_GLSubCatagory(detail.GlSubCatagory_ID);

                        txtAccType2AccType1Code.Text = detail.Parent_ID;
                        txtAccType2AccType1Name.Text = clsGenaralName.getName_GlAccountType1(detail.Parent_ID);

                        cmbAcctTypeStatus.Text = clsMethods_GL.GetSatus(detail.IsActive);
                        cmbAcctType.Text = clsMethods_GL.GetDrCr(detail.IsCredit);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsAcctCode(string sAcct)
        {
            try
            {
                if (sAcct.Length > 0)
                {

                    //sourceAccountCode.Filter = "";

                    tbl_accGLMaster detail = tbl_accGLMaster.Select(sAcct);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpadteAcctCode = true;

                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCodeGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCodeSubGlCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCodeTypeCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCodeType2Code, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCode, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCodeName, true);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeGlCode, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeGlName, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeSubGlCode, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeSubGLName, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeTypeCode, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeTypeName, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeType2Code, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeType2Name, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCode, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeName, true);

                        tbl_zAccGLMaster_AccountType oAccType = tbl_zAccGLMaster_AccountType.Select(detail.GlAccountType_ID);
                        if (oAccType != null)
                        {
                            tbl_zAccGLMaster_SubCatagory oAccSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(oAccType.GlSubCatagory_ID);
                            if (oAccSubCatagory != null)
                            {
                                txtAcctCodeGlCode.Text = oAccSubCatagory.GlMainCatagory_ID;
                                txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(oAccSubCatagory.GlMainCatagory_ID);

                                txtAcctCodeSubGlCode.Text = oAccSubCatagory.GlSubCatagory_ID;
                                txtAcctCodeSubGLName.Text = oAccSubCatagory.GlSubCatagoryName;// clsGenaralName.getName_GLSubCatagory(detail.GlSubCatagory_ID);
                            }
                        }
                        //asign values

                        txtAcctCodeTypeCode.Text = clsGenaralName.getID_GlAccountType2ParentID(detail.GlAccountType_ID);
                        txtAcctCodeTypeName.Text = clsGenaralName.getName_GlAccountType1(txtAcctCodeTypeCode.Text);

                        txtAcctCodeType2Code.Text = detail.GlAccountType_ID;
                        txtAcctCodeType2Name.Text = clsGenaralName.getName_GlAccountType1(detail.GlAccountType_ID);


                        txtGLNoteID.Tag = detail.GlNote_ID;
                        //txtGLNoteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_GLNoteID(detail.GlNote_ID));

                        txtAcctCode.Text = detail.Gl_ID;
                        txtAcctCodeName.Text = detail.GlName;
                        cmbAcctCodeStatus.SelectedItem = clsMethods_GL.GetSatus(!detail.IsDeleted);

                        txtSortOrder.Text = detail.Line_No.ToString();

                        //rdoCredit.Checked = detail.IsCredit;
                        //rdoDebit.Checked = !detail.IsCredit;
                        //rdoCash.Checked = detail.IsCashAccount;
                        //rdoBank.Checked = detail.IsBankAccount;
                                                                                               
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 1;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 2;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Cash) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 4;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 3;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Inventory) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 5;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 0;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.SalesAccount) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 6;
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Tax) == detail.ControlAcc_Type)
                            cmbControlAcc.SelectedIndex = 7;

                        //bank detail
                        foreach (tbl_genCompanyAccount oCompany in tbl_genCompanyAccount.SelectAll().Where(p => p.CompanyID != "default"))
                        {
                            if (oCompany.ControlAcc == detail.Gl_ID)
                            {
                                txtBankAccNo.Text = oCompany.AccountNumber;
                                txtBankAccNo.Text = clsGenaralName.getName_Bank(oCompany.Bank_ID);
                            }
                        }

                        //customer detail
                        foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default"))
                        {
                            if (oCustomer.Gl_ID == detail.Gl_ID)
                            {
                                txtCustomerID.Tag = oCustomer.Customer_ID;
                                txtCustomerID.Text = oCustomer.CustomerName;
                            }
                        }

                        ////supplier detail
                        //foreach (tbl_genSupplierMaster oSupplier in tbl_genSupplierMaster.SelectAll().Where(p => p.Supplier_ID != "default"))
                        //{
                        //    if (oSupplier.Gl_ID == detail.Gl_ID)
                        //    {
                        //        txtSupplireID.Tag = oSupplier.Supplier_ID;
                        //        txtSupplireID.Text = oSupplier.SupplierName;
                        //    }
                        //}

                        //Employee detail
                        foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default"))
                        {
                            if (oEmployee.Gl_ID == detail.Gl_ID)
                            {
                                txtEmployeeID.Tag = oEmployee.Employee_ID;
                                txtEmployeeID.Text = oEmployee.EmployeeName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcct, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsSubAccount(string sGLCode)
        {
            try
            {
                if (sGLCode.Length > 0)
                {
                    tbl_accGLMaster detail = tbl_accGLMaster.Select(sGLCode);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpadteSubAccount = true;
                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAcctCode1, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAcctCode1, false);

                        ////Fill GL Code
                        txtAcctCode1.Text = detail.Gl_ID;
                        txtAcctCodeName1.Text = detail.GlName;

                        //Fill Grild
                        RefreshGridCustomer(false, true, sGLCode, "default");
                        RefreshGridSupplier(false, true, sGLCode, "default");
                        RefreshGridEmployee(false, true, sGLCode, "default");
                        RefreshGridBank(false, true, sGLCode, "default");
                        RefreshGridCostCenter1(false, true, sGLCode, "default");
                        RefreshGridCostCenter2(false, true, sGLCode, "default");
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Event DoubleClick

        #region GL Code
        private void txtGledgerGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtGledgerGlCode, txtGledgerGlName, true);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Sub GL
        private void txtSubGledgerGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtSubGledgerGlCode, txtSubGledgerGlName, true);
                createFilterQuaryForSubGeneralLedger(txtSubGledgerGlCode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtSubGledgerSubGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_SubGLCode(txtSubGledgerSubGlCode, txtSubGledgerSubGlName, "", true);
                if (txtSubGledgerSubGlCode.Text.Trim().Length > 0)
                    FillDetailsSubGL(txtSubGledgerSubGlCode.Text.Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Account Type 1
        private void txtAcctTypeGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtAcctTypeGlCode, txtAcctTypeGlName, true);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctTypeSubGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAcctTypeGlCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_SubGLCode(txtAcctTypeSubGlCode, txtAcctTypeSubGlName, txtAcctTypeGlCode.Text.ToString(), true);
                    createFilterQuaryForAccountType(txtAcctTypeSubGlCode);
                }
                else
                {
                    clsSearch.Search_SubGLCode(txtAcctTypeSubGlCode, txtAcctTypeSubGlName, "", true);
                }
                if (txtAcctTypeSubGlCode.Text.Trim().Length > 0)
                {
                    txtAcctTypeGlCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAcctTypeSubGlCode.Text.Trim());
                    txtAcctTypeGlName.Text = clsGenaralName.getName_GLMainCatagory(txtAcctTypeGlCode.Text.Trim());
                    createFilterQuaryForAccountType(txtAcctTypeSubGlCode);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctTypeCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_AccountType(txtAcctTypeCode, txtAcctTypeName, "", true);
                if (txtAcctTypeCode.Text.Trim().Length > 0)
                {
                    FillDetailsAcctType(txtAcctTypeCode.Text.Trim());
                    createFilterQuaryForAccountType(txtAcctTypeCode);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Account Type 2
        private void txtAccType2GLCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtAccType2GLCode, txtAccType2GLName, true);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAccType2SubGLCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAccType2GLCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_SubGLCode(txtAccType2SubGLCode, txtAccType2SubGLName, txtAccType2GLCode.Text.ToString(), true);
                }
                else
                {
                    clsSearch.Search_SubGLCode(txtAccType2SubGLCode, txtAccType2SubGLName, "", true);
                    if (txtAccType2SubGLCode.Text.Trim().Length > 0)
                    {
                        txtAccType2GLCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAccType2SubGLCode.Text.Trim());
                        txtAccType2GLCode.Text = clsGenaralName.getName_GLMainCatagory(txtAccType2SubGLCode.Text.Trim());
                    }
                }
                createFilterQuaryForAccountType2(txtAccType2SubGLCode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAccType2AccType1Code_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAccType2SubGLCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_AccountType(txtAccType2AccType1Code, txtAccType2AccType1Name, txtAccType2SubGLCode.Text.ToString(), true);
                }
                else
                {
                    clsSearch.Search_AccountType(txtAccType2AccType1Code, txtAccType2AccType1Name, "", true);
                    if (txtAccType2AccType1Code.Text.Trim().Length > 0)
                    {
                        txtAccType2SubGLCode.Text = clsGenaralName.getName_GLSubCatagoryByAccountTypeID(txtAccType2AccType1Code.Text.Trim());
                        txtAccType2SubGLName.Text = clsGenaralName.getName_GLSubCatagory(txtAccType2SubGLCode.Text.Trim());

                        txtAccType2GLCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAccType2SubGLCode.Text.Trim());
                        txtAccType2GLName.Text = clsGenaralName.getName_GLMainCatagory(txtAccType2GLCode.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAccType2Code_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_AccountType2(txtAccType2Code, txtAccType2Name, "", true);

                if (txtAccType2Code.Text.Trim().Length > 0)
                {
                    FillDetailsAcctType2(txtAccType2Code.Text.Trim());
                }
                createFilterQuaryForAccountType2(txtAccType2Code);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Acount Code
        private void txtAcctCodeGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_GLCode(txtAcctCodeGlCode, txtAcctCodeGlName, true);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctCodeSubGlCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (txtAcctCodeGlCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_SubGLCode(txtAcctCodeSubGlCode, txtAcctCodeSubGLName, txtAcctCodeGlCode.Text.ToString(), true);
                    createFilterQuaryForAccountType(txtAcctCodeSubGlCode);
                }
                else
                {
                    clsSearch.Search_SubGLCode(txtAcctCodeSubGlCode, txtAcctCodeSubGLName, "", true);
                    if (txtAcctCodeSubGlCode.Text.Trim().Length > 0)
                    {
                        txtAcctCodeGlCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAcctCodeSubGlCode.Text.Trim());
                        txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(txtAcctCodeGlCode.Text.Trim());
                    }
                    createFilterQuaryForAccountType(txtAcctCodeSubGlCode);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctCodeTypeCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAcctCodeSubGlCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_AccountType(txtAcctCodeTypeCode, txtAcctCodeTypeName, txtAcctCodeSubGlCode.Text.ToString(), true);
                    createFilterQuaryForAccountCode(txtAcctCodeTypeCode);
                }
                else
                {
                    clsSearch.Search_AccountType(txtAcctCodeTypeCode, txtAcctCodeTypeName, "", true);
                    if (txtAcctCodeTypeCode.Text.Trim().Length > 0)
                    {
                        txtAcctCodeSubGlCode.Text = clsGenaralName.getName_GLSubCatagoryByAccountTypeID(txtAcctCodeTypeCode.Text.Trim());
                        txtAcctCodeSubGLName.Text = clsGenaralName.getName_GLSubCatagory(txtAcctCodeSubGlCode.Text.Trim());

                        txtAcctCodeGlCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAcctCodeSubGlCode.Text.Trim());
                        txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(txtAcctCodeGlCode.Text.Trim());
                    }
                    createFilterQuaryForAccountCode(txtAcctCodeTypeCode);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctCodeType2Code_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAcctCodeSubGlCode.Text.Trim().Length > 0)
                {
                    clsSearch.Search_AccountType2(txtAcctCodeType2Code, txtAcctCodeType2Name, txtAcctCodeSubGlCode.Text.ToString(), true);
                    createFilterQuaryForAccountCode(txtAcctCodeType2Code);
                }
                else
                {
                    clsSearch.Search_AccountType2(txtAcctCodeType2Code, txtAcctCodeType2Name, "", true);
                    if (txtAcctCodeType2Code.Text.Trim().Length > 0)
                    {
                        txtAcctCodeTypeCode.Text = clsGenaralName.getID_GlAccountType2ParentID(txtAcctCodeType2Code.Text.Trim());
                        txtAcctCodeTypeName.Text = clsGenaralName.getName_GlAccountType1(txtAcctCodeTypeCode.Text.Trim());

                        txtAcctCodeSubGlCode.Text = clsGenaralName.getName_GLSubCatagoryByAccountTypeID(txtAcctCodeTypeCode.Text.Trim());
                        txtAcctCodeSubGLName.Text = clsGenaralName.getName_GLSubCatagory(txtAcctCodeSubGlCode.Text.Trim());

                        txtAcctCodeGlCode.Text = clsGenaralName.getID_GLMainCatagoryBySubGLID(txtAcctCodeSubGlCode.Text.Trim());
                        txtAcctCodeGlName.Text = clsGenaralName.getName_GLMainCatagory(txtAcctCodeGlCode.Text.Trim());
                    }
                    createFilterQuaryForAccountCode(txtAcctCodeType2Code);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, "", "");

                if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                {
                    FillDetailsAcctCode(txtAcctCode.Tag.ToString().Trim());
                    createFilterQuaryForAccountCode(txtAcctCodeName);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Sub Acct
        private void txtAcctCode1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtAcctCode1, "", "");
                if (txtAcctCode1.Tag != null && txtAcctCode1.Tag.ToString().Trim().Length > 0)
                {
                    txtAcctCode1.Text = txtAcctCode1.Tag.ToString().Trim();
                    txtAcctCodeName1.Text = clsGenaralName.getName_AccountName(txtAcctCode1.Tag.ToString().Trim());
                    FillDetailsSubAccount(txtAcctCode1.Tag.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Other Double Clicks
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            selected = "Customer";
            SelectedOne();
            clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
            if (txtCustomerID.Tag != null)
            {
                txtSupplireID.Tag = null;
                txtSupplireID.Clear();
                txtEmployeeID.Tag = null;
                txtEmployeeID.Clear();
            }
        }
        private void txtSupplireID_DoubleClick(object sender, EventArgs e)
        {
            selected = "Supplire";
            SelectedOne();
            clsSearch.Search_MasterSupplier(ref txtSupplireID);
            if (txtSupplireID.Tag != null)
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();
                txtEmployeeID.Tag = null;
                txtEmployeeID.Clear();
            }
        }
        private void txtEmployeeID_DoubleClick(object sender, EventArgs e)
        {
            selected = "Employee";
            SelectedOne();
            clsSearch.Search_MasterEmployee(ref txtEmployeeID);
            if (txtEmployeeID.Tag != null)
            {
                txtSupplireID.Tag = null;
                txtSupplireID.Clear();
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();
            }
        }
        private void txtCostCenter2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter2(ref txtCostCenter2);
        }
        private void txtGLNoteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.SearchMaster_GLNoteID(ref txtGLNoteID);
        }

        private void txtBankAccNo_DoubleClick(object sender, EventArgs e)
        {
            selected = "Bank";
            SelectedOne();
            clsSearch.SearchMaster_CompanyAccount(ref txtBankAccNo, "", "");

        }
        private void txtCostCenter1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter1);
        }
        #endregion

        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["GLCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                        FillDetailsGL(sID.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvSubGL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvSubGL["SubGLCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetailsSubGL(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvAcctType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvAcctType["AcctTypeCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetailsAcctType(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvAcctType2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvAcctType2["AcctType2Code", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetailsAcctType2(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvAcct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvAcct["AcctCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        ClearAccountsFields();
                        FillDetailsAcctCode(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Events KeyUp
        private void txtAcctCodeName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuaryForAccountCode(txtAcctCodeName);
        }

        #endregion

        #region Events KeyPress
        private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        #endregion

        #region Events KeyDown

        #region GL
        private void txtGledgerGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtGledgerGlCode_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Sub GL
        private void txtSubGledgerGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtSubGledgerGlCode_DoubleClick(sender, e);
            }
        }
        private void txtSubGledgerSubGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtSubGledgerSubGlCode_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Account Type 1
        private void txtAcctTypeGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctTypeGlCode_DoubleClick(sender, e);
            }
        }
        private void txtAcctTypeSubGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctTypeSubGlCode_DoubleClick(sender, e);
            }
        }
        private void txtAcctTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAcctTypeCode_DoubleClick(sender, e);
        }
        #endregion

        #region Account Type 2
        private void txtAccType2GLCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAccType2SubGLCode_DoubleClick(sender, e);
            }
        }

        private void txtAccType2SubGLCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAccType2SubGLCode_DoubleClick(sender, e);
            }
        }

        private void txtAccType2AccType1Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAccType2AccType1Code_DoubleClick(sender, e);
            }
        }
        private void txtAccType2Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAccType2Code_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Account Code
        private void txtAcctCodeGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctCodeGlCode_DoubleClick(sender, e);
            }
        }
        private void txtAcctCodeSubGlCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctCodeSubGlCode_DoubleClick(sender, e);
            }
        }
        private void txtAcctCodeTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctCodeTypeCode_DoubleClick(sender, e);
            }
        }
        private void txtAcctCodeType2Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAcctCodeType2Code_DoubleClick(sender, e);
            }
        }
        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAcctCode_DoubleClick(sender, e);
        }

        #endregion

        #region Sub Account Code
        private void txtAcctCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAcctCode1_DoubleClick(sender, e);
        }
        #endregion

        #region Other Keydown
        private void txtCostCenter1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCostCenter1_DoubleClick(sender, e);
            }
        }
        private void txtCostCenter2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCostCenter2_DoubleClick(sender, e);
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCustomerID_DoubleClick(sender, e);
            }
        }
        private void txtSupplireID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSupplireID_DoubleClick(sender, e);
        }
        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtEmployeeID_DoubleClick(sender, e);
        }

        private void txtGLNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtGLNoteID_DoubleClick(sender, e);
            }
        }
        private void txtBankAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtBankAccNo_DoubleClick(sender, e);
            }
        }
        #endregion

        #endregion

        #region Events Click
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null)
                RefreshGridCustomer(false, false, txtAcctCode1.Text.Trim(), txtCustomerID.Tag.ToString());
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (txtSupplireID.Tag != null)
                RefreshGridSupplier(false, false, txtAcctCode1.Text.Trim(), txtSupplireID.Tag.ToString());
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Tag != null)
                RefreshGridEmployee(false, false, txtAcctCode1.Text.Trim(), txtEmployeeID.Tag.ToString());
        }
        private void btnAddBank_Click(object sender, EventArgs e)
        {
            if (txtBankAccNo.Tag != null)
                RefreshGridBank(false, false, txtAcctCode1.Text.Trim(), txtBankAccNo.Tag.ToString());
        }
        #endregion

        #region Tree_Node_MouseClick
        private void bookTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (bookTree.SelectedNode != null)
            //{
            //    Cursor = Cursors.WaitCursor;
            //    tbl_accGLMaster detail = tbl_accGLMaster.Select(e.Node.Name);// (bookTree.SelectedNode.Name);
            //    if (detail != null && detail.Gl_ID != "default")
            //        FillDetailsSubAccount(detail.Gl_ID);
            //    Cursor = Cursors.Default;
            //}

            if (e.Node.SelectedImageIndex == 2)
            {
                FillDetailsAcctCode(e.Node.Name);
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidityGL()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtGledgerGlCode.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }
            if (txtGledgerGlName.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValiditySubGL()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtSubGledgerGlCode.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }
            if (txtSubGledgerGlName.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }

            if (txtSubGledgerSubGlCode.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Code ";
                bStatus = false;
            }

            if (txtSubGledgerSubGlName.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Name ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValidityAcctType()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAcctTypeGlCode.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }

            if (txtAcctTypeGlName.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }

            if (txtAcctTypeSubGlCode.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Code ";
                bStatus = false;
            }

            if (txtAcctTypeSubGlName.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Name ";
                bStatus = false;
            }

            if (txtAcctTypeCode.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type Code ";
                bStatus = false;
            }

            if (txtAcctTypeName.Text.Length == 0)
            {
                strMessage += "\n" + "Acct.Type Name ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValidityAcctType2()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAccType2GLCode.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }

            if (txtAccType2GLName.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }

            if (txtAccType2SubGLCode.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Code ";
                bStatus = false;
            }

            if (txtAccType2SubGLName.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Name ";
                bStatus = false;
            }

            if (txtAccType2AccType1Code.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type 1 Code ";
                bStatus = false;
            }

            if (txtAccType2AccType1Name.Text.Length == 0)
            {
                strMessage += "\n" + "Acct.Type 1 Name ";
                bStatus = false;
            }

            if (txtAccType2Code.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type 2 Code ";
                bStatus = false;
            }

            if (txtAccType2Name.Text.Length == 0)
            {
                strMessage += "\n" + "Acct.Type 2 Name ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValidityAcct()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAcctCodeGlCode.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }

            if (txtAcctCodeGlName.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }

            if (txtAcctCodeSubGlCode.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Code ";
                bStatus = false;
            }

            if (txtAcctCodeSubGLName.TextLength == 0)
            {
                strMessage += "\n" + "SubGL Name ";
                bStatus = false;
            }

            if (txtAcctCodeTypeCode.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type 1 Code ";
                bStatus = false;
            }

            if (txtAcctCodeTypeName.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type 1 Name ";
                bStatus = false;
            }

            if (txtAcctCodeType2Code.TextLength == 0)
            {
                strMessage += "\n" + "Acct.Type 2 Code ";
                bStatus = false;
            }

            if (txtAcctCodeType2Name.Text.Length == 0)
            {
                strMessage += "\n" + "Acct.Type 2 Name ";
                bStatus = false;
            }

            if (txtAcctCode.TextLength == 0)
            {
                strMessage += "\n" + "Acct Code ";
                bStatus = false;
            }

            if (txtAcctCodeName.TextLength == 0)
            {
                strMessage += "\n" + "Acct Name ";
                bStatus = false;
            }

            //if (txtGLNoteID.TextLength == 0)
            //{
            //    strMessage += "\n" + "GL Note ID ";
            //    bStatus = false;
            //}

            //if (txtGLNoteID.Tag == null || txtGLNoteID.Tag.ToString().Trim().Length ==0)
            //{
            //    strMessage += "\n" + "Acct Name ";
            //    bStatus = false;
            //}

            if (cmbControlAcc.SelectedIndex == 3 && cmbControlAcc.SelectedIndex == 4) 
            {
                strMessage += "\n" + "Acct Type ";
                bStatus = false;
            }

            //if (rdoCash.Checked && rdoBank.Checked)
            //{
            //    strMessage += "\n" + "Acct Type ";
            //    bStatus = false;
            //}


            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }
        private bool CheckStatusValidityGL()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckStatusValiditySubGL()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog( "", iFormIDSubGL, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckStatusValidityAcctType()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckStatusValidityAcct()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctType2, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValiditySubAccount()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAcctCode1.TextLength == 0)
            {
                strMessage += "\n" + "GL Code ";
                bStatus = false;
            }

            if (txtAcctCodeName1.TextLength == 0)
            {
                strMessage += "\n" + "GL Name ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckStatusValiditySubAccount()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcct, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckInActiveValidityAcctCode()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDAcctCode, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Tab Control
        private void tbcGL_Selected(object sender, TabControlEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Set Form Design
        private void SetFormForAcct()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeGlCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeSubGlCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtGLNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtBankAccNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtEmployeeID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeType2Code, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctCodeTypeCode, true);

            clsFormatter.Format_TextBox_DisableMode(txtAcctCodeGlName);
            clsFormatter.Format_TextBox_DisableMode(txtAcctCodeSubGLName);
            clsFormatter.Format_TextBox_DisableMode(txtAcctCodeTypeName);
            clsFormatter.Format_TextBox_DisableMode(txtAcctCodeTypeName);
            clsFormatter.Format_TextBox_DisableMode(txtAcctCodeType2Name);


            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAcctCode, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtAcctCodeName, true);

            clsCommon.SetEnableDisable_NormalComboBox(cmbAcctCodeStatus, true);

            txtAcctCodeGlCode.Clear();
            txtAcctCodeGlName.Clear();
            txtAcctCodeSubGlCode.Clear();
            txtAcctCodeSubGLName.Clear();
            txtAcctCodeTypeCode.Clear();
            txtAcctCodeTypeName.Clear();
            txtAcctCodeType2Code.Clear();
            txtAcctCodeType2Name.Clear();
            txtAcctCode.Clear();
            txtAcctCodeName.Clear();
            txtGLNoteID.Clear();
            txtBankAccNo.Clear();
            txtEmployeeID.Clear();
            txtCustomerID.Clear();
            txtSupplireID.Clear();
            txtSortOrder.Clear();
            
            cmbAcctCodeStatus.Items.Clear();
            cmbAcctCodeStatus.Items.Add("Active");
            cmbAcctCodeStatus.Items.Add("In-Active");
            cmbAcctCodeStatus.SelectedItem = "Active";

            clsFill.FillEnumDescription(typeof(enum_ControlAccountType_Description), ref cmbControlAcc); // Fill Control Acc.            

            ////txtCustomerID.Tag = null;
            ////txtSupplireID.Tag = null;
            ////txtEmployeeID.Tag = null;

            //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            if (clsAutocode.IsAutoGenerated(sCFormIDAcctCode))
                txtAcctCode.Text = "<Auto Generate>";
            else
                txtAcctCode.Clear();
            if (txtAcctCode.Enabled)
            {
                txtAcctCode.SelectAll();
                txtAcctCode.Focus();
            }
            RefreshGridAcct();
        }
        private void SetFormForAcctType()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctTypeGlCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAcctTypeSubGlCode, true);
            clsFormatter.Format_TextBox_DisableMode(txtAcctTypeGlName);
            clsFormatter.Format_TextBox_DisableMode(txtAcctTypeSubGlName);

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAcctTypeCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAcctCodeTypeName, true);
            clsCommon.SetEnableDisable_NormalComboBox(cmbAcctTypeStatus, true);
            clsCommon.SetEnableDisable_NormalComboBox(cmbAcctType, true);

            txtAcctTypeGlCode.Clear();
            txtAcctTypeGlName.Clear();
            txtAcctTypeSubGlCode.Clear();
            txtAcctTypeSubGlName.Clear();
            txtAcctTypeGlCode.Clear();
            txtAcctCodeTypeName.Clear();
            txtAcctTypeName.Clear();
            cmbAcctTypeStatus.Items.Clear();
            cmbAcctTypeStatus.Items.Add("Active");
            cmbAcctTypeStatus.Items.Add("In-Active");
            cmbAcctTypeStatus.SelectedItem = "Active";
            cmbAcctType.Items.Clear();
            cmbAcctType.Items.Add("Credit");
            cmbAcctType.Items.Add("Debit");
            cmbAcctType.SelectedItem = "Credit";

            //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            if (clsAutocode.IsAutoGenerated(sCFormIDAcctType))
                txtAcctTypeCode.Text = "<Auto Generate>";
            else
                txtAcctTypeCode.Clear();
            if (txtAcctTypeCode.Enabled)
            {
                txtAcctTypeCode.SelectAll();
                txtAcctTypeCode.Focus();
            }
            RefreshGridAcctType();
        }
        private void SetFormForAcctType2()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAccType2GLCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAccType2SubGLCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAccType2AccType1Code, true);
            clsFormatter.Format_TextBox_DisableMode(txtAccType2GLName);
            clsFormatter.Format_TextBox_DisableMode(txtAccType2SubGLName);
            clsFormatter.Format_TextBox_DisableMode(txtAccType2AccType1Name);

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccType2Code, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtAccType2Name, true);

            clsCommon.SetEnableDisable_NormalComboBox(cmbAcctType2Status, true);

            txtAccType2GLCode.Clear();
            txtAccType2GLName.Clear();

            txtAccType2SubGLCode.Clear();
            txtAccType2SubGLName.Clear();

            txtAccType2AccType1Code.Clear();
            txtAccType2AccType1Name.Clear();

            txtAccType2Code.Clear();
            txtAccType2Name.Clear();

            cmbAcctType2Status.Items.Clear();
            cmbAcctType2Status.Items.Add("Active");
            cmbAcctType2Status.Items.Add("In-Active");
            cmbAcctType2Status.SelectedItem = "Active";


            //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            if (clsAutocode.IsAutoGenerated(sCFormIDAcctType2))
                txtAccType2Code.Text = "<Auto Generate>";
            else
                txtAccType2Code.Clear();
            if (txtAccType2Code.Enabled)
            {
                txtAccType2Code.SelectAll();
                txtAccType2Code.Focus();
            }
            RefreshGridAcctType2();
        }
        private void SetFormForSubGeneralLedger()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSubGledgerGlCode, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSubGledgerGlCode, true);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSubGledgerGlName, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSubGledgerSubGlCode, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSubGledgerSubGlName, true);
            clsFormatter.Format_TextBox_DisableMode(txtSubGledgerGlName);

            txtSubGledgerGlCode.Clear();
            txtSubGledgerGlName.Clear();
            txtSubGledgerGlName.Clear();
            txtSubGledgerSubGlName.Clear();
            cmbSubGledgerStatus.Items.Clear();
            cmbSubGledgerStatus.Items.Add("Active");
            cmbSubGledgerStatus.Items.Add("In-Active");
            cmbSubGledgerStatus.SelectedItem = "Active";

            //if (clsAutocode.IsAutoGenerated(sFormConfigCode))
            if (clsAutocode.IsAutoGenerated(sCFormIDSubGL))
                txtSubGledgerSubGlCode.Text = "<Auto Generate>";
            else
                txtSubGledgerSubGlCode.Clear();
            if (txtSubGledgerSubGlCode.Enabled)
            {
                txtSubGledgerSubGlCode.SelectAll();
                txtSubGledgerSubGlCode.Focus();
            }
            RefreshGridSubGeneralLedger();
        }
        private void SetFormForGeneralLedger()
        {
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtGledgerGlCode, true);
            clsCommon.SetEnableDisable_NormalLabel(lblGledgerGlCode, true);

            txtGledgerGlCode.Clear();
            txtGledgerGlName.Clear();
            cmbGledgerStatus.Items.Clear();
            cmbGledgerStatus.Items.Add("Active");
            cmbGledgerStatus.Items.Add("In-Active");
            cmbGledgerStatus.SelectedItem = "Active";

            cmbGLType.Items.Clear();
            cmbGLType.Items.Add("Balance Sheet Acc.");
            cmbGLType.Items.Add("Income Statement Acc.");
            cmbGLType.SelectedItem = "Balance Sheet Acc.";

            pnlContralButtons.Visible = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtGledgerGlCode.Text = "<Auto Generate>";
            else
                txtGledgerGlCode.Clear();
            if (txtGledgerGlCode.Enabled)
            {
                txtGledgerGlCode.SelectAll();
                txtGledgerGlCode.Focus();
            }
            RefreshGridGeneralLedger();
        }
        private void SetFormForSubAccount()
        {
            IsUpadteSubAccount = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAcctCode1, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAcctCode1, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAcctCodeName1, false);

            txtAcctCode1.Tag = null;
            txtAcctCodeName1.Tag = null;
            txtCostCenter1.Tag = null;
            txtCostCenter2.Tag = null;
            txtCustomerID.Tag = null;
            txtSupplireID.Tag = null;
            txtEmployeeID.Tag = null;
            txtBankAccNo.Tag = null;

            txtAcctCode1.Clear();
            txtAcctCodeName1.Clear();
            txtCostCenter1.Clear();
            txtCostCenter2.Clear();
            txtCustomerID.Clear();
            txtSupplireID.Clear();
            txtEmployeeID.Clear();
            txtBankAccNo.Clear();

            dgvCostCenter1.Rows.Clear();
            dgvCostCenter2.Rows.Clear();
            dgvCustomer.Rows.Clear();
            dgvSupplier.Rows.Clear();
            dgvEmployee.Rows.Clear();
            dgvBank.Rows.Clear();

            tpBanks.Text = "Banks";
            tpCostCenter1.Text = "Sub Accounts-1";
            tpCostCenter2.Text = "Sub Accounts-2";
            tpCustomers.Text = "Customers";
            tpEmployees.Text = "Employees";
            tpSuppliers.Text = "Suppliers";
        }
        #endregion

        #region Create Table
        private void CreateTableAccountCode()
        {
            dtAllRecodesAccCode.Columns.Clear();
            dtAllRecodesAccCode.Columns.Add("AcctCode", typeof(string));
            dtAllRecodesAccCode.Columns.Add("AcctCodeName", typeof(string));
            dtAllRecodesAccCode.Columns.Add("AcctCodeDrCr", typeof(string));
            dtAllRecodesAccCode.Columns.Add("AcctCodeStatus", typeof(string));

            dtAllRecodesAccCode.Columns.Add("glAccountType_ID", typeof(string));
            dtAllRecodesAccCode.Columns.Add("glAccountType2_ID", typeof(string));
            dtAllRecodesAccCode.Columns.Add("glSubCatagory_ID", typeof(string));
            dtAllRecodesAccCode.Columns.Add("glMainCatagory_ID", typeof(string));
        }
        private void CreateTableAccountType()
        {
            dtAllRecodesAccType.Columns.Clear();
            dtAllRecodesAccType.Columns.Add("AcctTypeCode", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctTypeName", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctTypeStatus", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctType", typeof(string));

            dtAllRecodesAccType.Columns.Add("GLSubCatagory_ID2", typeof(string));
        }
        private void CreateTableAccountType2()
        {
            dtAllRecodesAccType.Columns.Clear();
            dtAllRecodesAccType.Columns.Add("AcctType2Code", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctType2Name", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctType2Status", typeof(string));
            dtAllRecodesAccType.Columns.Add("AcctType2", typeof(string));

            dtAllRecodesAccType.Columns.Add("AcctType1_Code", typeof(string));
            dtAllRecodesAccType.Columns.Add("GLSubCatagory_ID2", typeof(string));
        }
        private void CreateTableSubGeneralLedger()
        {
            dtAllRecodesSubGeneralLedger.Columns.Clear();
            dtAllRecodesSubGeneralLedger.Columns.Add("SubGLCode", typeof(string));
            dtAllRecodesSubGeneralLedger.Columns.Add("SubGLName", typeof(string));
            dtAllRecodesSubGeneralLedger.Columns.Add("SubGLStatus", typeof(string));

            dtAllRecodesSubGeneralLedger.Columns.Add("GLCodeSGLedger", typeof(string));
        }

        #endregion

        #region Binding Filter
        private void createFilterQuaryForSubGeneralLedger(TextBox txtbox)
        {
            try
            {
                string sTemp = "";

                if (txtSubGledgerGlCode.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " GLCodeSGLedger = '" + txtSubGledgerGlCode.Text + "'";
                        sourceSubGeneralLedger.Filter = "";
                        sourceSubGeneralLedger.Filter = sTemp;
                    }
                }
                sourceSubGeneralLedger.DataSource = dtAllRecodesSubGeneralLedger;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void createFilterQuaryForAccountType(TextBox txtbox)
        {
            try
            {
                string sTemp = "";
                if (txtbox.Text.Trim().Length > 0)
                {
                    if (txtAcctTypeSubGlCode.Name == txtbox.Name)
                    {
                        sTemp = " GLSubCatagory_ID2 = '" + txtAcctTypeSubGlCode.Text + "'";
                    }
                    if (txtAcctTypeCode.Name == txtbox.Name)
                    {
                        sTemp = " AcctTypeCode = '" + txtAcctTypeCode.Text + "'";
                    }
                    sourceAccountType.Filter = "";
                    sourceAccountType.Filter = sTemp;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void createFilterQuaryForAccountType2(TextBox txtbox)
        {
            try
            {
                string sTemp = "";
                if (txtbox.Text.Trim().Length > 0)
                {
                    if (txtAccType2SubGLCode.Name == txtbox.Name)
                    {
                        sTemp = " GLSubCatagory_ID2 = '" + txtbox.Text + "'";
                    }
                    if (txtAccType2Code.Name == txtbox.Name)
                    {
                        sTemp = " AcctType2Code = '" + txtbox.Text + "'";
                    }
                    sourceAccountType2.Filter = "";
                    sourceAccountType2.Filter = sTemp;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        private void createFilterQuaryForAccountCode(TextBox txtbox)
        {
            try
            {
                #region Lod
                //string sTemp = "";
                //if (txtbox.Text.Trim().Length > 0)
                //{
                //    sourceAccountCode.Filter = "";
                //    if (txtAcctCodeTypeCode.Name == txtbox.Name)
                //    {
                //        sTemp = " glAccountType_ID = '" + txtAcctCodeTypeCode.Text + "'";
                //    }

                //    if (txtAcctCodeType2Code.Name == txtbox.Name)
                //    {
                //        sTemp = " glAccountType2_ID = '" + txtAcctCodeType2Code.Text + "'";
                //    }

                //    if (txtAcctCodeName.Name == txtbox.Name)
                //    {
                //        sTemp = " AcctCodeName LIKE '%" + txtAcctCodeName.Text + "%'";
                //    }
                //    sourceAccountCode.Filter = sTemp;
                //    sourceAccountCode.DataSource = dtAllRecodesAccCode;
                //} 
                #endregion

                string sTemp = "";
                
                if (txtbox.Text.Trim().Length > 0)
                {
                    sourceAccountCode.Filter = "";
                    if (txtAcctCodeTypeCode.Name == txtbox.Name)
                    {
                        sTemp = " glAccountType_ID = '" + txtAcctCodeTypeCode.Text + "'";
                    }

                    if (txtAcctCodeType2Code.Name == txtbox.Name)
                    {
                        sTemp = " glAccountType2_ID = '" + txtAcctCodeType2Code.Text + "'";
                    }

                    if (txtAcctCodeName.Name == txtbox.Name)
                    {
                        //sTemp = " AcctCodeName LIKE '%" + txtAcctCodeName.Text + "%'";

                        string value = txtAcctCodeName.Text.Trim();
                        string sCheckedValue = clsHelpMethods.CheckValue(value);
                        if (txtbox.Name == "txtAcctCodeName")
                            sTemp = " AcctCodeName LIKE '%" + sCheckedValue + "%'";
                    }
                    sourceAccountCode.Filter = sTemp;
                    sourceAccountCode.DataSource = dtAllRecodesAccCode;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormIDGL, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Select the textbox to be Filled
        private void SelectedOne()
        {
            switch (selected)
            {
                case "Customer":
                    txtEmployeeID.Clear();
                    txtSupplireID.Clear();
                    txtBankAccNo.Clear();
                    break;

                case "Supplire":
                    txtCustomerID.Clear();
                    txtEmployeeID.Clear();
                    txtBankAccNo.Clear();
                    break;

                case "Employee":
                    txtCustomerID.Clear();
                    txtSupplireID.Clear();
                    txtBankAccNo.Clear();
                    break;

                case "Bank":
                    txtCustomerID.Clear();
                    txtEmployeeID.Clear();
                    txtSupplireID.Clear();
                    break;
            }
        }
        #endregion

        #region Populate Tree
        private void populateTree()
        {
            bookTree.Nodes.Clear();

            List<tbl_zAccGLMaster_MainCatagory> mainDetails = tbl_zAccGLMaster_MainCatagory.SelectAll();
            foreach (tbl_zAccGLMaster_MainCatagory detail in mainDetails)
            {
                if (detail.GlMainCatagory_ID != "default")
                {
                    TreeNode TParent = new TreeNode(detail.GlMainCatagoryName, 4, 4);
                    TParent.Name = detail.GlMainCatagory_ID;
                    TParent.ForeColor = Color.Black;

                    List<tbl_zAccGLMaster_SubCatagory> subDetails = tbl_zAccGLMaster_SubCatagory.SelectAllByGlMainCatagory_ID(detail.GlMainCatagory_ID);
                    foreach (tbl_zAccGLMaster_SubCatagory sdetail in subDetails)
                    {
                        TreeNode SubItem = new TreeNode(sdetail.GlSubCatagoryName, 1, 1);
                        SubItem.Name = sdetail.GlSubCatagory_ID;
                        SubItem.ForeColor = Color.Green;

                        List<tbl_zAccGLMaster_AccountType> subsubDetails = tbl_zAccGLMaster_AccountType.SelectAllByGlSubCatagory_ID(sdetail.GlSubCatagory_ID).Where(p => p.Parent_ID == "default").ToList();
                        foreach (tbl_zAccGLMaster_AccountType ssDetail in subsubDetails)
                        {
                            TreeNode SubSubItem = new TreeNode(ssDetail.GlAccountTypeName, 0, 0);
                            SubSubItem.Name = ssDetail.GlAccountType_ID;
                            SubSubItem.ForeColor = Color.Red;

                        List<tbl_zAccGLMaster_AccountType> subsubDetails2 = tbl_zAccGLMaster_AccountType.SelectAllByGlSubCatagory_ID(sdetail.GlSubCatagory_ID).Where(p => p.Parent_ID != "default").ToList();
                        foreach (tbl_zAccGLMaster_AccountType ssDetail2 in subsubDetails2)
                        {
                            TreeNode SubSubItem2 = new TreeNode(ssDetail2.GlAccountTypeName, 0, 0);
                            SubSubItem2.Name = ssDetail2.GlAccountType_ID;
                            SubSubItem2.ForeColor = Color.Red;

                            List<tbl_accGLMaster> subsubsubcDetails = tbl_accGLMaster.SelectAllByGlAccountType_ID(ssDetail2.GlAccountType_ID);
                            foreach (tbl_accGLMaster sssDetails in subsubsubcDetails)
                            {
                                TreeNode SubSubSubItem = new TreeNode(sssDetails.GlName, 2, 2);
                                SubSubSubItem.Name = sssDetails.Gl_ID;
                                SubSubSubItem.ForeColor = Color.Blue;
                                SubSubItem2.Nodes.Add(SubSubSubItem);
                            }
                            SubSubItem.Nodes.Add(SubSubItem2);
                        }
                        SubItem.Nodes.Add(SubSubItem);
                        }
                        TParent.Nodes.Add(SubItem);
                    }
                    bookTree.Nodes.Add(TParent);
                }
            }
        }
        #endregion

        #region Btn SubGLCodes Add All
        private void btnAddAllCostCenter1_Click(object sender, EventArgs e)
        {
            RefreshGridCostCenter1(true, false, "default", "default");
        }
        private void btnAddAllCostCenter2_Click(object sender, EventArgs e)
        {
            RefreshGridCostCenter2(true, false, "default", "default");
        }
        private void btnAddAllCustomer_Click(object sender, EventArgs e)
        {
            RefreshGridCustomer(true, false, "default", "default");
        }
        private void btnAddAllSupplier_Click(object sender, EventArgs e)
        {
            RefreshGridSupplier(true, false, "default", "default");
        }
        private void btnAddAllEmployee_Click(object sender, EventArgs e)
        {
            RefreshGridEmployee(true, false, "default", "default");
        }
        private void btnAddAllBank_Click(object sender, EventArgs e)
        {
            RefreshGridBank(true, false, "default", "default");
        }
        #endregion

        #region Btn SubGLCodes Remove
        private void btnRemoveCostCenter1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCostCenter1.SelectedCells.Count != 0)
                {
                    if (dgvCostCenter1.Rows.Count > 0)
                        dgvCostCenter1.Rows.RemoveAt(dgvCostCenter1.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void btnRemoveCostCenter2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCostCenter2.SelectedCells.Count != 0)
                {
                    if (dgvCostCenter2.Rows.Count > 0)
                        dgvCostCenter2.Rows.RemoveAt(dgvCostCenter2.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedCells.Count != 0)
                {
                    if (dgvCustomer.Rows.Count > 0)
                        dgvCustomer.Rows.RemoveAt(dgvCustomer.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplier.SelectedCells.Count != 0)
                {
                    if (dgvSupplier.Rows.Count > 0)
                        dgvSupplier.Rows.RemoveAt(dgvSupplier.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.SelectedCells.Count != 0)
                {
                    if (dgvEmployee.Rows.Count > 0)
                        dgvEmployee.Rows.RemoveAt(dgvEmployee.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void btnRemoveBanks_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBank.SelectedCells.Count != 0)
                {
                    if (dgvBank.Rows.Count > 0)
                        dgvBank.Rows.RemoveAt(dgvBank.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Display Control Accounts UI's
        private void btnDebtorCA_Click(object sender, EventArgs e)
        {
            frm_masAccCustomerControlAccounts frm = new frm_masAccCustomerControlAccounts();
            frm.Show();
        }

        private void btnCreditorCA_Click(object sender, EventArgs e)
        {
            frm_masAccSupplierControlAccounts frm = new frm_masAccSupplierControlAccounts();
            frm.Show();
        }

        private void btnBankCA_Click(object sender, EventArgs e)
        {
            frmCompanyBankAccount frm = new frmCompanyBankAccount();
            frm.Show();
        }
        #endregion

    }
}
