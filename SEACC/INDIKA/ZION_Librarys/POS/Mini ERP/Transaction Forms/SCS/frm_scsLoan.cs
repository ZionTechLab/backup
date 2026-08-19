using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq.DataSets.SCS;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_scsLoan : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;


        //form manage
        string sFormConfigCode_LoanIn, sFormConfigCode_LoanOut;
        public int iFormID;


        //to keep glob ref no        
        public string glbOrderRefNo = "";
        public bool glbIsLoanIn = true;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();


        //For consum of Settlement Form
        public static string sLoanInID = "";
        public static string sLonOutID = "";
        public static string sLoanInIDAll = "";
        public static string sLonOutIDAll = "";
        public static string sAllocationID = "";
        public static bool isLoanIn = false;
        public static string sStorkID = "";

        dts_scsLoanInLoanOut glbdts_scsLoanInLoanOut = new dts_scsLoanInLoanOut();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_scsLoan()
        {
            sFormConfigCode_LoanIn = clsAutocode.getFormConfigCode(FormName.LoanIn);
            sFormConfigCode_LoanOut = clsAutocode.getFormConfigCode(FormName.LoanOut);
            iFormID = clsSecurity.getFormID(FormName.LoanIn);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Loan In/Out", 4, iFormID);
            ClearFields();
            CusDataGridViewFormat();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            rdoLoanIn.Checked = glbIsLoanIn;
            rdoLoanOut.Checked = !glbIsLoanIn;

            if (rdoLoanIn.Checked)
                isLoanIn = true;
            else
                isLoanIn = false;
        }
        #endregion

        #region Enable Reciver
        private void EnableReciver()
        {
            clearReciver();
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtOther, false);

            if (rdoCustomer.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            }
            if (rdoSupplier.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            }
            if (rdoOther.Checked)
            {
                clsCommon.SetEnableDisable_NormalTextbox(txtOther, true);
            }
        }
        #endregion

        #region Enable/Desable All Reciver
        private void EnableDesableAllReciver(bool bArg)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bArg);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, bArg);
            clsCommon.SetEnableDisable_NormalTextbox(txtOther, bArg);


            rdoCustomer.Enabled = bArg;
            rdoSupplier.Enabled = bArg;

            rdoOther.Enabled = bArg;
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
                if (txtLoanID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;

                            #region Loan In
                            if (rdoLoanIn.Checked)
                            {
                                tbl_scsLoanIn detail = tbl_scsLoanIn.Select(txtLoanID.Text.Trim());

                                if (detail != null)
                                {
                                    if (!detail.IsLocked && !detail.IsApproved && !detail.IsFinished && !detail.IsDeleted)
                                    {
                                        if (CheckSupplierSaveValidity())
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GIN : " + txtLoanID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();

                                                //Stock Settlement
                                                // foreach (tbl_scsLoanIn_Detail oItem in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(detail.LoanIn_ID))
                                                // {
                                                ////     clsHelpMethods.UpdateOrInsertStoreStock(true, true, oItem.Item_ID, oItem.ItemSubCategory_ID, oItem.ItemSubCategory2_ID, oItem.ItemSerialNo, oItem.ItemSerialNo2, "default", txtStoreID.Tag.ToString(), oItem.Qty, oItem.Weight, 0, 0, false, false, true);
                                                // }
                                            }
                                        }//Check  Supplier Validity
                                    }//For Check Validation
                                }
                            }
                            #endregion

                            #region Loan Out
                            else if (rdoLoanOut.Checked)
                            {
                                tbl_scsLoanOut detail = tbl_scsLoanOut.Select(txtLoanID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked && !detail.IsApproved && !detail.IsFinished && !detail.IsDeleted)
                                    {
                                        if (CheckSupplierSaveValidity())
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " GIN : " + txtLoanID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();
                                                //Stock Settlement
                                                //foreach (tbl_scsLoanOut_Detail oItem in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(detail.LoanOut_ID))
                                                //{
                                                //    clsHelpMethods.UpdateOrInsertStoreStock(true, true, oItem.Item_ID, oItem.ItemSubCategory_ID, oItem.ItemSubCategory2_ID, oItem.ItemSerialNo, oItem.ItemSerialNo2, "default", txtStoreID.Tag.ToString(), oItem.Qty, oItem.Weight, 0, 0, false, true, true);
                                                //}
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
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
                    if (dgvDetail.Rows.Count > 0)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (CheckGridCountValidity())
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckSupplierSaveValidity())
                        {
                            if (CheckStockValidity())
                            {
                                //if (clsValidate.CheckFinancialYearValidity(clsSecurity.FinancialYearID, dtpGINDate.Value))
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            ValidateEmptyForeignKey();
                                            if (glbOrderRefNo.Length <= 0)
                                                glbOrderRefNo = "default";

                                            #region Update
                                            if (IsUpdate)  //update records
                                            {
                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtLoanID.Text))
                                                {
                                                    if (rdoLoanIn.Checked)
                                                    {
                                                        #region Update LoanIn

                                                        tbl_scsLoanIn oldRecord =
                                                            tbl_scsLoanIn.Select(txtLoanID.Text.Trim());
                                                        if (oldRecord != null &&
                                                            clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                        {
                                                            if (!oldRecord.IsLocked && !oldRecord.IsApproved &&
                                                                !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                            {
                                                                //Update LoanIn Details

                                                                #region Update Old LoanIn Items

                                                                decimal dTot_Qty = 0,
                                                                    dTot_Weight = 0,
                                                                    dTot_UnitPrice = 0,
                                                                    dTot_WeightPrice = 0;
                                                                List<tbl_scsLoanIn_Detail> oldDetails =
                                                                    tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(
                                                                        txtLoanID.Text.Trim());
                                                                foreach (tbl_scsLoanIn_Detail oldDetail in oldDetails)
                                                                {
                                                                    string sJobCode = "default",
                                                                        sItemCode = "",
                                                                        sItemSubCategoryID1 = "",
                                                                        sItemSubCategoryID2 = "",
                                                                        sItemSerialNo1 = "",
                                                                        sItemSerialNo2 = "",
                                                                        sUom = "",
                                                                        sRemarks =
                                                                            ""; //sPOID = "", sPRNID = "", sBatch = "",
                                                                    decimal dQty = 0,
                                                                        dUnitPrice = 0,
                                                                        dWeight = 0,
                                                                        dAmount = 0,
                                                                        dWeidhtPrice = 0; //dWaranty = 0,
                                                                    bool bHasItemInDB = false;

                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        sItemCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "ItemCode", row.Index, "");
                                                                        sItemSubCategoryID1 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID1", row.Index,
                                                                                "default");
                                                                        sItemSubCategoryID2 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID2", row.Index,
                                                                                "default");
                                                                        sItemSerialNo1 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo1", row.Index, "0");
                                                                        sItemSerialNo2 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo2", row.Index, "0");
                                                                        sUom = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "UOM", row.Index, "default");
                                                                        dQty = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "Quantity", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dUnitPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "UnitPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeidhtPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "WeightPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeight = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Weight", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dAmount = clsValidate.ValidateGridTag(dgvDetail,
                                                                            "Amount", row.Index, decimal.Parse("0.00"));
                                                                        sRemarks = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Remarks", row.Index, "");

                                                                        //update total values
                                                                        dTot_Qty += dQty;
                                                                        dTot_Weight += dWeight;
                                                                        dTot_UnitPrice += dUnitPrice;
                                                                        dTot_WeightPrice += dWeidhtPrice;

                                                                        if (oldDetail.LoanIn_ID ==
                                                                            txtLoanID.Text.Trim() &&
                                                                            oldDetail.Item_ID == sItemCode &&
                                                                            oldDetail.ItemSubCategory_ID ==
                                                                            sItemSubCategoryID1 &&
                                                                            oldDetail.ItemSubCategory2_ID ==
                                                                            sItemSubCategoryID2 &&
                                                                            oldDetail.ItemSerialNo == sItemSerialNo1 &&
                                                                            oldDetail.ItemSerialNo2 == sItemSerialNo2)
                                                                        {
                                                                            bHasItemInDB = true;
                                                                            dgvDetail.Rows.RemoveAt(row.Index);
                                                                            break; //database contain this item
                                                                        }
                                                                    }

                                                                    if (bHasItemInDB)
                                                                    {
                                                                        #region Update old item details

                                                                        //Update store stock when user modify the old recode
                                                                        //Don't put this region below update 

                                                                        #region Update Store Stock

                                                                        //    clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, oldDetail.Qty, oldDetail.Weight, true, true, true);

                                                                        #endregion

                                                                        oldDetail.Item_ID = sItemCode;
                                                                        oldDetail.ItemSubCategory_ID =
                                                                            sItemSubCategoryID1;
                                                                        oldDetail.ItemSubCategory2_ID =
                                                                            sItemSubCategoryID2;
                                                                        oldDetail.ItemSerialNo = sItemSerialNo1;
                                                                        oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                                        oldDetail.Qty = dQty;
                                                                        oldDetail.Weight = dWeight;
                                                                        oldDetail.WeightPrice = dWeidhtPrice;
                                                                        oldDetail.UnitPrice = dUnitPrice;
                                                                        oldDetail.TotalAmount = dAmount;
                                                                        oldDetail.Remark = sRemarks;
                                                                        oldDetail.Update();

                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        #region Delete old item detail

                                                                        //Update Store Stock if user delete old inserted item

                                                                        #region Update Store Stock If User Delete the old Input

                                                                        //   clsHelpMethods.UpdateOrInsertStoreStock(true, true, oldDetail.Item_ID, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, "default", txtStoreID.Tag.ToString(), oldDetail.Qty, oldDetail.Weight, 0, 0, false, false, true);

                                                                        #endregion

                                                                        oldDetail.Delete();

                                                                        #endregion
                                                                    }
                                                                }

                                                                #endregion

                                                                #region Insert Newly Added Items

                                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                {
                                                                    string sJobCode = "default",
                                                                        sItemCode = "",
                                                                        sItemSubCategoryID1 = "",
                                                                        sItemSubCategoryID2 = "",
                                                                        sItemSerialNo1 = "",
                                                                        sItemSerialNo2 = "",
                                                                        sUom = "",
                                                                        sRemarks =
                                                                            ""; //sPOID = "", sPRNID = "", sBatch = "",
                                                                    decimal dQty = 0,
                                                                        dUnitPrice = 0,
                                                                        dWeight = 0,
                                                                        dAmount = 0,
                                                                        dWeidhtPrice = 0; //dWaranty = 0,


                                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "ItemCode", row.Index, "");
                                                                    sItemSubCategoryID1 =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "ItemSubCategoryID1", row.Index, "default");
                                                                    sItemSubCategoryID2 =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "ItemSubCategoryID2", row.Index, "default");
                                                                    sItemSerialNo1 =
                                                                        clsValidate.ValidateGridValue(dgvDetail,
                                                                            "ItemSerialNo1", row.Index, "0");
                                                                    sItemSerialNo2 =
                                                                        clsValidate.ValidateGridValue(dgvDetail,
                                                                            "ItemSerialNo2", row.Index, "0");
                                                                    sUom = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "UOM", row.Index, "default");
                                                                    dQty = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Quantity", row.Index, decimal.Parse("0.00"));
                                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail,
                                                                        "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                                    dWeidhtPrice =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "WeightPrice", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Weight", row.Index, decimal.Parse("0.00"));
                                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail,
                                                                        "Amount", row.Index, decimal.Parse("0.00"));
                                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Remarks", row.Index, "");

                                                                    tbl_scsLoanIn_Detail detail =
                                                                        new tbl_scsLoanIn_Detail(
                                                                            clsHelpMethods
                                                                                .GetMaxzimumLineNoLoanIN(
                                                                                    txtLoanID.Text.Trim()),
                                                                            txtLoanID.Text.Trim(),
                                                                            sItemCode, sItemSubCategoryID1,
                                                                            sItemSubCategoryID2, sItemSerialNo1,
                                                                            sItemSerialNo2, dQty, 0, dWeight, 0,
                                                                            dUnitPrice, 0, dWeidhtPrice, 0, dAmount,
                                                                            sRemarks);
                                                                    detail.Insert();

                                                                    #region Update Stock

                                                                    //    clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, 0, 0, false, true, true);

                                                                    #endregion

                                                                }

                                                                #endregion


                                                                //Update LoanIn Header

                                                                #region Update LoanIn Header

                                                                tbl_scsLoanIn oLoan = new tbl_scsLoanIn(
                                                                    txtLoanID.Text.Trim(), dtpGINDate.Value,
                                                                    txtRemark.Text.Trim(), getReciverName(),
                                                                    glbOrderRefNo,
                                                                    txtStoreID.Tag.ToString(),
                                                                    txtSupplierID.Tag.ToString(),
                                                                    txtCustomerID.Tag.ToString(), dTot_UnitPrice,
                                                                    dTot_WeightPrice, dTot_Qty, dTot_Weight,
                                                                    oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                                    oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                                    clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                    oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                                    clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                    oldRecord.DateCreate,
                                                                    clsSecurity.getServerDateTime(), glbCheckedDate,
                                                                    glbApprovedDate, clsSecurity.getServerDateTime(),
                                                                    clsSecurity.getServerDateTime(),
                                                                    bHasChecked, bHasApproved, oldRecord.IsFinished,
                                                                    oldRecord.IsDeleted, oldRecord.IsLocked,
                                                                    oldRecord.IsSeattled, oldRecord.SeattleAmount,
                                                                    oldRecord.PrintCount,
                                                                    rdoSupplier.Checked, rdoOther.Checked,
                                                                    rdoCustomer.Checked, !chkUnitPricing.Checked,
                                                                    chkIsFirstDocument.Checked, oldRecord.CompanyID,
                                                                    oldRecord.CompanyBranch_ID);
                                                                oLoan.Update();

                                                                #endregion

                                                                //LoanIn/Out Settlement

                                                                #region Update Settlement

                                                                //foreach (DataGridViewRow row in dgvInvoice.Rows)
                                                                //{
                                                                //    string sLoan_ID = clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "");

                                                                //    //Remove Settlement
                                                                //    clsHelpMethods.AutoSettledLoanInOut_Remove(sLoan_ID, txtLoanID.Text.Trim());
                                                                //    //Create Settlement
                                                                //    clsHelpMethods.AutoSettledLoanInOut_Create(sLoan_ID, txtLoanID.Text.Trim());
                                                                //}

                                                                #endregion

                                                                //Attachments.Insert(iFormID, oldRecord.LoanIn_ID);
                                                                //Attachments.Remove(iFormID, oldRecord.LoanIn_ID);

                                                                MessageBox.Show(
                                                                    clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                                    clsFormatter.GetMessageCaption(),
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            }
                                                            else
                                                                MessageBox.Show(
                                                                    clsFormatter.GetMessageFrom(
                                                                        MessageType.RecordLocked),
                                                                    clsFormatter.GetMessageCaption(),
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }

                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region Update LoanOut

                                                        decimal dTot_Qty = 0,
                                                            dTot_Weight = 0,
                                                            dTot_UnitPrice = 0,
                                                            dTot_WeightPrice = 0;
                                                        tbl_scsLoanOut oldRecord =
                                                            tbl_scsLoanOut.Select(txtLoanID.Text.Trim());
                                                        if (oldRecord != null &&
                                                            clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                        {
                                                            if (!oldRecord.IsLocked && !oldRecord.IsApproved &&
                                                                !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                            {
                                                                //Update LoanIn Details

                                                                #region Update Old EGIN Items

                                                                List<tbl_scsLoanOut_Detail> oldDetails =
                                                                    tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(
                                                                        txtLoanID.Text.Trim());
                                                                foreach (tbl_scsLoanOut_Detail oldDetail in oldDetails)
                                                                {
                                                                    string sJobCode = "default",
                                                                        sItemCode = "",
                                                                        sItemSubCategoryID1 = "",
                                                                        sItemSubCategoryID2 = "",
                                                                        sItemSerialNo1 = "",
                                                                        sItemSerialNo2 = "",
                                                                        sUom = "",
                                                                        sRemarks =
                                                                            ""; //sPOID = "", sPRNID = "", sBatch = "",
                                                                    decimal dQty = 0,
                                                                        dUnitPrice = 0,
                                                                        dWeight = 0,
                                                                        dAmount = 0,
                                                                        dWeidhtPrice = 0; // dWaranty = 0,
                                                                    bool bHasItemInDB = false;

                                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                    {
                                                                        sItemCode = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "ItemCode", row.Index, "");
                                                                        sItemSubCategoryID1 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID1", row.Index,
                                                                                "default");
                                                                        sItemSubCategoryID2 =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "ItemSubCategoryID2", row.Index,
                                                                                "default");
                                                                        sItemSerialNo1 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo1", row.Index, "0");
                                                                        sItemSerialNo2 =
                                                                            clsValidate.ValidateGridValue(dgvDetail,
                                                                                "ItemSerialNo2", row.Index, "0");
                                                                        sUom = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "UOM", row.Index, "default");
                                                                        dQty = clsValidate.ValidateGridValue(dgvDetail,
                                                                            "Quantity", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dUnitPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "UnitPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeidhtPrice =
                                                                            clsValidate.ValidateGridTag(dgvDetail,
                                                                                "WeightPrice", row.Index,
                                                                                decimal.Parse("0.00"));
                                                                        dWeight = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Weight", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                        dAmount = clsValidate.ValidateGridTag(dgvDetail,
                                                                            "Amount", row.Index, decimal.Parse("0.00"));
                                                                        sRemarks = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "Remarks", row.Index, "");

                                                                        //update total values
                                                                        dTot_Qty += dQty;
                                                                        dTot_Weight += dWeight;
                                                                        dTot_UnitPrice += dUnitPrice;
                                                                        dTot_WeightPrice += dWeidhtPrice;

                                                                        if (oldDetail.LoanOut_ID ==
                                                                            txtLoanID.Text.Trim() &&
                                                                            oldDetail.Item_ID == sItemCode &&
                                                                            oldDetail.ItemSubCategory_ID ==
                                                                            sItemSubCategoryID1 &&
                                                                            oldDetail.ItemSubCategory2_ID ==
                                                                            sItemSubCategoryID2 &&
                                                                            oldDetail.ItemSerialNo == sItemSerialNo1 &&
                                                                            oldDetail.ItemSerialNo2 == sItemSerialNo2)
                                                                        {
                                                                            bHasItemInDB = true;
                                                                            dgvDetail.Rows.RemoveAt(row.Index);
                                                                            break; //database contain this item
                                                                        }
                                                                    }

                                                                    if (bHasItemInDB)
                                                                    {
                                                                        #region Update old item detailsk

                                                                        //Get Unit Price as weighted avarage cost

                                                                        #region Get weight avarage cost as unit price

                                                                        if (!chkUnitPricing.Checked)
                                                                        {
                                                                            dWeidhtPrice =                                                                                clsProcessMethods                                                                                    .GetItemWeightedAvarageCostPrice(                                                                                        sItemCode);
                                                                            dAmount = dWeidhtPrice * dWeight;
                                                                        }
                                                                        else
                                                                        {
                                                                            dUnitPrice =                                                                                clsProcessMethods                                                                                    .GetItemWeightedAvarageCostPrice(                                                                                        sItemCode);
                                                                            dAmount = dUnitPrice * dQty;
                                                                        }

                                                                        #endregion

                                                                        //Update store stock when user modify the old recode
                                                                        //Don't put this region below update 

                                                                        #region Update Store Stock

                                                                        //   clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, oldDetail.Qty, oldDetail.Weight, true, true, true);

                                                                        #endregion

                                                                        oldDetail.Item_ID = sItemCode;
                                                                        oldDetail.ItemSubCategory_ID =                                                                            sItemSubCategoryID1;
                                                                        oldDetail.ItemSubCategory2_ID =                                                                            sItemSubCategoryID2;
                                                                        oldDetail.ItemSerialNo = sItemSerialNo1;
                                                                        oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                                        oldDetail.Qty = dQty;
                                                                        oldDetail.Weight = dWeight;
                                                                        oldDetail.WeightPrice = dWeidhtPrice;
                                                                        oldDetail.UnitPrice = dUnitPrice;
                                                                        oldDetail.TotalAmount = dAmount;
                                                                        oldDetail.Remark = sRemarks;
                                                                        oldDetail.Update();

                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        #region Delete old item detail

                                                                        //Update Store Stock if user delete old inserted item

                                                                        #region Update Store Stock If User Delete the old Input

                                                                        //  clsHelpMethods.UpdateOrInsertStoreStock(true, true, oldDetail.Item_ID, oldDetail.ItemSubCategory_ID, oldDetail.ItemSubCategory2_ID, oldDetail.ItemSerialNo, oldDetail.ItemSerialNo2, "default", txtStoreID.Tag.ToString(), oldDetail.Qty, oldDetail.Weight, 0, 0, false, false, true);

                                                                        #endregion

                                                                        oldDetail.Delete();

                                                                        #endregion
                                                                    }
                                                                }

                                                                #endregion

                                                                #region Insert Newly Added Items

                                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                                {
                                                                    string sJobCode = "default",
                                                                        sItemCode = "",
                                                                        sItemSubCategoryID1 = "",
                                                                        sItemSubCategoryID2 = "",
                                                                        sItemSerialNo1 = "",
                                                                        sItemSerialNo2 = "",
                                                                        sUom = "",
                                                                        sRemarks =
                                                                            ""; //sPOID = "", sPRNID = "", sBatch = "",
                                                                    decimal dQty = 0,
                                                                        dUnitPrice = 0,
                                                                        dWeight = 0,
                                                                        dAmount = 0,
                                                                        dWeidhtPrice = 0; // dWaranty = 0,


                                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "ItemCode", row.Index, "");
                                                                    sItemSubCategoryID1 =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "ItemSubCategoryID1", row.Index, "default");
                                                                    sItemSubCategoryID2 =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "ItemSubCategoryID2", row.Index, "default");
                                                                    sItemSerialNo1 =
                                                                        clsValidate.ValidateGridValue(dgvDetail,
                                                                            "ItemSerialNo1", row.Index, "0");
                                                                    sItemSerialNo2 =
                                                                        clsValidate.ValidateGridValue(dgvDetail,
                                                                            "ItemSerialNo2", row.Index, "0");
                                                                    sUom = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "UOM", row.Index, "default");
                                                                    dQty = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Quantity", row.Index, decimal.Parse("0.00"));
                                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail,
                                                                        "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                                    dWeidhtPrice =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "WeightPrice", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Weight", row.Index, decimal.Parse("0.00"));
                                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail,
                                                                        "Amount", row.Index, decimal.Parse("0.00"));
                                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Remarks", row.Index, "");


                                                                    //Get Unit Price as weighted avarage cost

                                                                    #region Get weight avarage cost as unit price

                                                                    if (!chkUnitPricing.Checked)
                                                                    {
                                                                        dWeidhtPrice =                                                                            clsProcessMethods                                                                                .GetItemWeightedAvarageCostPrice(                                                                                    sItemCode);
                                                                        dAmount = dWeidhtPrice * dWeight;
                                                                    }
                                                                    else
                                                                    {
                                                                        dUnitPrice =                                                                            clsProcessMethods                                                                                .GetItemWeightedAvarageCostPrice(                                                                                    sItemCode);
                                                                        dAmount = dUnitPrice * dQty;
                                                                    }

                                                                    #endregion

                                                                    tbl_scsLoanOut_Detail detail =                                                                        new tbl_scsLoanOut_Detail(                                                                            clsHelpMethods                                                                               .GetMaxzimumLineNoLoanOut(                                                                                    txtLoanID.Text.Trim()),                                                                            txtLoanID.Text.Trim(),                                                                            sItemCode, sItemSubCategoryID1,                                                                            sItemSubCategoryID2, sItemSerialNo1,                                                                            sItemSerialNo2, dQty, 0, dWeight, 0,                                                                            dUnitPrice, 0, dWeidhtPrice, 0, dAmount,                                                                            sRemarks);
                                                                    detail.Insert();

                                                                    #region Update Stock

                                                                    //   clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, 0, 0, false, true, true);

                                                                    #endregion

                                                                }

                                                                #endregion


                                                                //Update LoanIn Header

                                                                #region Update LoanOut Header

                                                                tbl_scsLoanOut oLoan = new tbl_scsLoanOut(
                                                                    txtLoanID.Text.Trim(), dtpGINDate.Value,
                                                                    txtRemark.Text.Trim(), getReciverName(),
                                                                    glbOrderRefNo,
                                                                    txtStoreID.Tag.ToString(),
                                                                    txtSupplierID.Tag.ToString(),
                                                                    txtCustomerID.Tag.ToString(), dTot_UnitPrice,
                                                                    dTot_WeightPrice, dTot_Qty, dTot_Weight,
                                                                    oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                                    oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                                    clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                    oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                                    clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                    oldRecord.DateCreate,
                                                                    clsSecurity.getServerDateTime(), glbCheckedDate,
                                                                    glbApprovedDate, clsSecurity.getServerDateTime(),
                                                                    clsSecurity.getServerDateTime(),
                                                                    bHasChecked, bHasApproved, oldRecord.IsFinished,
                                                                    oldRecord.IsDeleted, oldRecord.IsLocked,
                                                                    oldRecord.IsSeattled, oldRecord.SeattleAmount,
                                                                    oldRecord.PrintCount,
                                                                    rdoSupplier.Checked, rdoOther.Checked,
                                                                    rdoCustomer.Checked, !chkUnitPricing.Checked,
                                                                    chkIsFirstDocument.Checked, oldRecord.CompanyID,
                                                                    oldRecord.CompanyBranch_ID);
                                                                oLoan.Update();

                                                                #endregion

                                                                //LoanIn/Out Settlement

                                                                #region Update Settlement

                                                                //foreach (DataGridViewRow row in dgvInvoice.Rows)
                                                                //{
                                                                //    string sLoan_ID = clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "");

                                                                //    //Remove Settlement
                                                                //    clsHelpMethods.AutoSettledLoanInOut_Remove(sLoan_ID, txtLoanID.Text.Trim());
                                                                //    //Create Settlement
                                                                //    clsHelpMethods.AutoSettledLoanInOut_Create(sLoan_ID, txtLoanID.Text.Trim());
                                                                //}

                                                                #endregion

                                                                Attachments.Insert(oldRecord.LoanOut_ID);                                                                MessageBox.Show(                                                                    clsFormatter.GetMessageFrom(MessageType.ModifyDone),                                                                    clsFormatter.GetMessageCaption(),                                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            }
                                                            else
                                                                MessageBox.Show(                                                                    clsFormatter.GetMessageFrom(                                                                        MessageType.RecordLocked),                                                                    clsFormatter.GetMessageCaption(),                                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }

                                                        #endregion
                                                    }
                                                }
                                            }
                                            #endregion
                                            #region insert
                                            else //insert recode
                                            {
                                                #region Insert LoanIn/Out
                                                if (rdoLoanIn.Checked)
                                                {
                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode_LoanIn))
                                                        txtLoanID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode_LoanIn);
                                                }
                                                else
                                                {
                                                    if (clsAutocode.IsAutoGenerated(sFormConfigCode_LoanOut))
                                                        txtLoanID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode_LoanOut);
                                                }
                                                //create order ref number
                                                if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                                {
                                                    glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                                                    tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(glbOrderRefNo, txtSupplierRefNo.Text.Trim());
                                                    orf.Insert();
                                                }


                                                if (clsValidate.CheckValidity_TransactionCodeLength(txtLoanID.Text)) //if (txtLoanID.Text.Trim().Length > 0)
                                                {
                                                    decimal dTot_Qty = 0, dTot_Weight = 0, dTot_UnitPrice = 0, dTot_WeightPrice = 0;

                                                    //insert LoanIN/Out Header
                                                    #region Insert Header
                                                    if (rdoLoanIn.Checked)
                                                    {
                                                        tbl_scsLoanIn oLoan = new tbl_scsLoanIn(txtLoanID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(), getReciverName(), glbOrderRefNo,
                                                            txtStoreID.Tag.ToString(), txtSupplierID.Tag.ToString(), txtCustomerID.Tag.ToString(), dTot_UnitPrice, dTot_WeightPrice, dTot_Qty, dTot_Weight,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                            bHasChecked, bHasApproved, false, false, false, false, 0, 0, rdoSupplier.Checked, rdoOther.Checked, rdoCustomer.Checked, !chkUnitPricing.Checked, chkIsFirstDocument.Checked, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                        oLoan.Insert();
                                                    }
                                                    else
                                                    {
                                                        tbl_scsLoanOut oLoan = new tbl_scsLoanOut(txtLoanID.Text.Trim(), dtpGINDate.Value, txtRemark.Text.Trim(), getReciverName(), glbOrderRefNo,
                                                            txtStoreID.Tag.ToString(), txtSupplierID.Tag.ToString(), txtCustomerID.Tag.ToString(), dTot_UnitPrice, dTot_WeightPrice, dTot_Qty, dTot_Weight,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                            bHasChecked, bHasApproved, false, false, false, false, 0, 0, rdoSupplier.Checked, rdoOther.Checked, rdoCustomer.Checked, !chkUnitPricing.Checked, chkIsFirstDocument.Checked, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                        oLoan.Insert();
                                                    }
                                                    #endregion

                                                    //insert LoanIN/Out Details
                                                    #region Insert Detail
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        string sJobCode = "default", sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sPOID = "", sPRNID = "", sBatch = "", sUom = "", sRemarks = "";
                                                        decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dAmount = 0, dWaranty = 0, dWeidhtPrice = 0;

                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                        sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                        sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                        sPOID = clsValidate.ValidateGridValue(dgvDetail, "POID", row.Index, "default");
                                                        sPRNID = clsValidate.ValidateGridValue(dgvDetail, "PRNID", row.Index, "default");
                                                        sBatch = clsValidate.ValidateGridValue(dgvDetail, "Batch", row.Index, "");
                                                        sUom = clsValidate.ValidateGridValue(dgvDetail, "UOM", row.Index, "default");
                                                        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                        dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                        dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                        dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                        dWaranty = clsValidate.ValidateGridValue(dgvDetail, "Warranty", row.Index, decimal.Parse("0.00"));
                                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                        //update total values
                                                        dTot_Qty += dQty; dTot_Weight += dWeight; dTot_UnitPrice += dUnitPrice; dTot_WeightPrice += dWeidhtPrice;

                                                        #region Update Detail
                                                        if (rdoLoanIn.Checked)
                                                        {
                                                            tbl_scsLoanIn_Detail detail = new tbl_scsLoanIn_Detail(clsHelpMethods.GetMaxzimumLineNoLoanIN(txtLoanID.Text.Trim()), txtLoanID.Text.Trim(),
                                                                sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty, 0, dWeight, 0, dUnitPrice, 0, dWeidhtPrice, 0, dAmount, sRemarks);
                                                            detail.Insert();
                                                        }
                                                        else
                                                        {
                                                            tbl_scsLoanOut_Detail detail = new tbl_scsLoanOut_Detail(clsHelpMethods.GetMaxzimumLineNoLoanOut(txtLoanID.Text.Trim()), txtLoanID.Text.Trim(),
                                                                sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, dQty, 0, dWeight, 0, dUnitPrice, 0, dWeidhtPrice, 0, dAmount, sRemarks);
                                                            detail.Insert();
                                                        }
                                                        #endregion

                                                        #region Update Stock
                                                        //if (rdoLoanIn.Checked)
                                                        //    clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, 0, 0, false, true, true);
                                                        //else
                                                        //    clsHelpMethods.UpdateOrInsertStoreStock(true, true, sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2, sJobCode, txtStoreID.Tag.ToString(), dQty, dWeight, 0, 0, false, false, true);
                                                        #endregion

                                                        #region Update LoanIn/Out Headers
                                                        if (rdoLoanIn.Checked)
                                                        {
                                                            tbl_scsLoanIn oHeader = tbl_scsLoanIn.Select(txtLoanID.Text.Trim());
                                                            if (oHeader != null)
                                                            {
                                                                oHeader.TotalUnitPrice = dTot_UnitPrice;
                                                                oHeader.TotalWeightPrice = dTot_WeightPrice;
                                                                oHeader.TotalQty = dTot_Qty;
                                                                oHeader.TotalWeight = dTot_Weight;
                                                                oHeader.Update();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            tbl_scsLoanOut oHeader = tbl_scsLoanOut.Select(txtLoanID.Text.Trim());
                                                            if (oHeader != null)
                                                            {
                                                                oHeader.TotalUnitPrice = dTot_UnitPrice;
                                                                oHeader.TotalWeightPrice = dTot_WeightPrice;
                                                                oHeader.TotalQty = dTot_Qty;
                                                                oHeader.TotalWeight = dTot_Weight;
                                                                oHeader.Update();
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    //LoanIn/Out Settlement
                                                    #region Update Settlement
                                                    //foreach (DataGridViewRow row in dgvInvoice.Rows)
                                                    //{
                                                    //    string sLoan_ID = clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "");

                                                    //    //Remove Settlement
                                                    //    clsHelpMethods.AutoSettledLoanInOut_Remove(sLoan_ID, txtLoanID.Text.Trim());
                                                    //    //Create Settlement
                                                    // clsHelpMethods.AutoSettledLoanInOut_Create(sLoan_ID, txtLoanID.Text.Trim());
                                                    //}
                                                    #endregion

                                                    Attachments.Insert(txtLoanID.Text.ToString());

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                //else
                                                //{
                                                //    MessageBox.Show("Loan In/Out " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //}
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        catch (Exception ex)
                                        {
                                            SEACCException.Show(ex);
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                        }
                                        finally
                                        {
                                            Cursor = Cursors.Default;
                                            if (rdoLoanIn.Checked)
                                            {
                                                tbl_scsLoanIn oldRecord = tbl_scsLoanIn.Select(txtLoanID.Text.Trim());
                                                ClearFields();
                                                if (oldRecord != null)
                                                    FillDetailsLoanIn(oldRecord.LoanIn_ID);
                                            }
                                            else
                                            {
                                                tbl_scsLoanOut oldRecord = tbl_scsLoanOut.Select(txtLoanID.Text.Trim());
                                                ClearFields();
                                                if (oldRecord != null)
                                                    FillDetailsLoanOut(oldRecord.LoanOut_ID);
                                            }
                                        }
                                    }
                                }
                            }//Check Stock Validity
                        }//check supplier save validity
                    }//check number validity
                }//Check Grid Count Validity
            }//check validity
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region Select Report
            string sGetRptPath = "";
            bool bIsDataSet = false;
            if (rdoLoanIn.Checked)
            {
                sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.ST_LoanIN));
            }
            else
            {
                sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.ST_LoanOut));
            }
            #endregion

            try
            {
                if (txtLoanID.TextLength > 0 && txtLoanID.Text != "<Auto Generate>")
                {

                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    string s_Path = "", sReportTitle = "Loan Out", sFormula = ""; //string isRemark = "";
                    bool bIsDuplicate = false;
                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                    if (rdoLoanIn.Checked)
                    {
                        tbl_scsLoanIn order = tbl_scsLoanIn.Select(txtLoanID.Text.Trim());
                        if (order != null)
                        {
                            //Write Audit Trial Log
                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.LoanIn), order.LoanIn_ID);

                            sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                            if (order.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                            if (order.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                            if (order.PrintCount > 0)
                                bIsDuplicate = true;
                            order.PrintCount++;
                            order.DatePrinted = clsSecurity.getServerDateTime();
                            order.PrintedTerminal_ID = clsSecurity.TerminalID;
                            order.PrintedUser_ID = clsSecurity.UserIDLoged;
                            order.Update();

                            sReportTitle = "Loan-In Note";
                            sFormula = "{vw_rpt_scsLoanIn.loanIn_ID}= '" + txtLoanID.Text.Trim() + "'";

                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                s_Path += sGetRptPath;
                            else
                            {
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanIn.rpt";
                                else
                                    s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanIn.rpt";
                            }
                        }
                    }
                    else
                    {
                        tbl_scsLoanOut order = tbl_scsLoanOut.Select(txtLoanID.Text.Trim());
                        if (order != null)
                        {
                            #region OLD
                            /*
                            //Write Audit Trial Log
                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.LoanOut), order.LoanOut_ID);

                            sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                            if (order.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                            if (order.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                            if (order.PrintCount > 0)
                                bIsDuplicate = true;
                            order.PrintCount++;
                            order.DatePrinted = clsSecurity.getServerDateTime();
                            order.PrintedTerminal_ID = clsSecurity.TerminalID;
                            order.PrintedUser_ID = clsSecurity.UserIDLoged;
                            order.Update();

                            sReportTitle = "Loan-Out Note";
                            sFormula = "{vw_rpt_scsLoanOut.loanOut_ID}= '" + txtLoanID.Text.Trim() + "'";
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanOut_AKT.rpt";
                            else
                                s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanOut_AKT.rpt"; 
                           */
                            #endregion


                            try
                            {
                                glbdts_scsLoanInLoanOut.Clear();
                                Cursor = Cursors.WaitCursor;
                                string sReceiver = "", sIssuedRefNo = "", sCus_SupName = "";


                                clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.LoanOut), order.LoanOut_ID);

                                #region Set Print User Data
                                sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                                if (order.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                                if (order.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";

                                if (order.PrintCount > 0)
                                    bIsDuplicate = true;
                                order.PrintCount++;
                                order.DatePrinted = clsSecurity.getServerDateTime();
                                order.PrintedTerminal_ID = clsSecurity.TerminalID;
                                order.PrintedUser_ID = clsSecurity.UserIDLoged;
                                order.Update();

                                sReportTitle = "Loan-Out Note";
                                #endregion

                                // sFormula = "{vw_rpt_scsLoanOut.loanOut_ID}= '" + txtLoanID.Text.Trim() + "'";                              
                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                {
                                    s_Path += sGetRptPath;
                                    bIsDataSet = true;
                                }
                                else
                                {

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                        //  s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanOut_AKT.rpt";
                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanOut_AKT_DataSet.rpt";
                                    else
                                    {

                                        //Write Audit Trial Log
                                        clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.LoanOut), order.LoanOut_ID);

                                        sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                                        if (order.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                                        if (order.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                                        if (order.PrintCount > 0)
                                            bIsDuplicate = true;
                                        order.PrintCount++;
                                        order.DatePrinted = clsSecurity.getServerDateTime();
                                        order.PrintedTerminal_ID = clsSecurity.TerminalID;
                                        order.PrintedUser_ID = clsSecurity.UserIDLoged;
                                        order.Update();

                                        sReportTitle = "Loan-Out Note";
                                        sFormula = "{vw_rpt_scsLoanOut.loanOut_ID}= '" + txtLoanID.Text.Trim() + "'";

                                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasLoanOut_AKT.rpt";
                                    }
                                }


                                #region Get Register Address
                                if (order.Customer_ID != "default")
                                {
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(order.Customer_ID);
                                    if (oCustomer != null)
                                    {
                                        sReceiver = oCustomer.AddressRegister;
                                        sCus_SupName = oCustomer.CustomerName;
                                    }
                                }
                                else if (order.Supplier_ID != "default")
                                {
                                    tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(order.Supplier_ID);
                                    if (oSupplier != null)
                                    {
                                        sReceiver = oSupplier.AddressRegister;
                                        sCus_SupName = oSupplier.SupplierName;
                                    }
                                }
                                #endregion


                                #region Get Issued Reff No
                                tbl_zIssuedRefNo oRef = tbl_zIssuedRefNo.Select(order.IssuedRefNo_ID);
                                if (oRef != null && oRef.IssuedRefNo != "default")
                                    sIssuedRefNo = oRef.IssuedRefNo;
                                #endregion

                                glbdts_scsLoanInLoanOut.dt_LoanOut.Adddt_LoanOutRow(order.LoanOut_ID, sCus_SupName, sReceiver, order.LoanOutDate.Date, sIssuedRefNo, order.IsDeleted);

                                #region Detail
                                foreach (tbl_scsLoanOut_Detail oDetail in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(order.LoanOut_ID).Where(p => p.LoanOut_ID != "default"))
                                {
                                    string sUom = "";
                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                    if (oItem != null && oItem.Item_ID != "default")
                                        sUom = oItem.Uom_ID;
                                    glbdts_scsLoanInLoanOut.dt_LoanOutDetail.Adddt_LoanOutDetailRow(oDetail.LoanOut_ID, oDetail.Item_ID, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Qty, oDetail.Weight, order.Remark);

                                }
                                #endregion


                                #region Fill Loan IN Detail
                                foreach (tbl_scsLoanSettle item in tbl_scsLoanSettle.SelectAllByLoanOut_ID(order.LoanOut_ID))
                                {
                                    tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(item.LoanIn_ID);
                                    if (oLoanIn != null)
                                    {
                                        glbdts_scsLoanInLoanOut.dt_LoanHeader_NotePrint.Adddt_LoanHeader_NotePrintRow(item.AllocationID, oLoanIn.LoanIn_ID, oLoanIn.LoanInDate, oLoanIn.ReceiverName, true, oLoanIn.IsWeightCalculation, oLoanIn.IsDeleted);//, false

                                        foreach (tbl_scsLoanIn_Detail oItems in tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(oLoanIn.LoanIn_ID))
                                        {
                                            glbdts_scsLoanInLoanOut.dt_LoanDetail_NotePrint.Adddt_LoanDetail_NotePrintRow(item.AllocationID, oItems.LoanIn_ID, oItems.ItemSerialNo, clsGenaralName.getName_Item(oItems.Item_ID), oItems.Qty != 0 ? oItems.Qty : oItems.Weight, oItems.UnitPrice, true);
                                        }

                                    }
                                }
                                #endregion


                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)                                    
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SubCategory", clsConfig.sItemSubCategory, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);
                                if (bIsDuplicate)
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", "Duplicate Copy", true,false);

                                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                ReportViewer.print(s_Path, glbdts_scsLoanInLoanOut, glb_dtsReportExport.dt_rptParameter, sGetRptPath);

                                //print(s_Path, bIsDuplicate, glbdts_scsLoanInLoanOut, sReportTitle, sCreateUser, sCheckedUser, sApprovedUser);


                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", iFormID, ex);
                                SEACCException.Show(ex);
                            }
                            finally
                            {
                                glbdts_scsLoanInLoanOut.Clear();
                                Cursor = Cursors.Default;
                            }


                        }
                    }

                    if ((!rdoLoanOut.Checked || clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()) && !bIsDataSet)
                    {

                        //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                        //    isRemark = "r";
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                        //    isRemark = "r";
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                        //    isRemark = "r";
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                        //    isRemark = "s";
                        //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                        //    isRemark = "r";


                        frm_ReportViewer viewer = new frm_ReportViewer();
                        RD.Load(s_Path);
                        clsSecurity.LogonServer(ref RD);
                        RD.Refresh();

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                            RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                        //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                        //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                        // RD.DataDefinition.FormulaFields["lqty"].Text = clsCommon.fncsetstring("QTY/Weight");
                        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                        RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_User(clsSecurity.UserIDLoged));
                        if (bIsDuplicate)
                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

                        viewer.crystalReportViewer1.ReportSource = RD;
                        viewer.crystalReportViewer1.SelectionFormula = sFormula;
                        viewer.crystalReportViewer1.Visible = true;
                        viewer.crystalReportViewer1.DisplayToolbar = true;
                        viewer.crystalReportViewer1.CloseView(false);
                        viewer.WindowState = FormWindowState.Maximized;

                        viewer.ShowDialog();

                        RD.Close();
                        RD.Dispose();
                    }
                }
                else
                    MessageBox.Show("Please Select the Loan No To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Drafft
        private void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoanID.TextLength > 0 && txtLoanID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    tbl_scsExternalGoodIssueNote order = tbl_scsExternalGoodIssueNote.Select(txtLoanID.Text.Trim());
                    if (order != null)
                    {
                        sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                        if (order.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                        if (order.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";

                    }

                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sReportTitle = "Goods Issued Note", sFormula = ""; //string isRemark = "";
                    if (txtLoanID.TextLength > 0)
                        sFormula = "{vw_rpt_scsExternalGoodIssuedNote.externalGoodIssueNote_ID}= '" + txtLoanID.Text.Trim() + "'";

                    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                    //    isRemark = "r";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                    //    isRemark = "s";
                    //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                    //    isRemark = "r";

                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasExtranalGoodIssueeNote_WSC.rpt";
                    else
                        s_Path += "\\Reports\\SCS\\NotePrinting\\rpt_sasExtranalGoodIssueeNote.rpt";

                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path);
                    clsSecurity.LogonServer(ref RD);
                    RD.Refresh();

                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                    //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                    RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getSupplerTelephoneAndFax(order.Supplier_ID));
                    RD.DataDefinition.FormulaFields["isDraft"].Text = "'DRAFT'";

                    viewer.crystalReportViewer1.ReportSource = RD;
                    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                    viewer.crystalReportViewer1.Visible = true;
                    viewer.crystalReportViewer1.DisplayToolbar = true;
                    viewer.crystalReportViewer1.CloseView(false);
                    viewer.WindowState = FormWindowState.Maximized;

                    viewer.ShowDialog();

                    RD.Close();
                    RD.Dispose();
                }
                else
                    MessageBox.Show("Please Select the GIN To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
            {
                RefreshGridByItemID(txtItemID.Tag.ToString());
            }
        }
        #endregion


        #region Btn Add LoanIN/Out
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTmpLoanID.Tag != null && txtTmpLoanID.Tag.ToString().Trim().Length > 0)
            {
                if (CheckTmpLoanINOutValidity())
                {
                    if (rdoLoanIn.Checked)
                    {
                        tbl_scsLoanOut detail = tbl_scsLoanOut.Select(txtTmpLoanID.Tag.ToString());
                        if (detail != null)
                        {
                            int iRow = 0;

                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;
                            dgvInvoice["LoanNo", iRow].Value = detail.LoanOut_ID;
                            dgvInvoice["LoanDate", iRow].Value = clsFormatter.FormatDate_Short(detail.LoanOutDate);

                            //set the orderdetail/salesrep                        
                            tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                            if (order != null)
                                glbOrderRefNo = detail.IssuedRefNo_ID;
                        }
                    }
                    else
                    {
                        tbl_scsLoanIn detail = tbl_scsLoanIn.Select(txtTmpLoanID.Tag.ToString());
                        if (detail != null)
                        {
                            int iRow = 0;

                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;
                            dgvInvoice["LoanNo", iRow].Value = detail.LoanIn_ID;
                            dgvInvoice["LoanDate", iRow].Value = clsFormatter.FormatDate_Short(detail.LoanInDate);

                            //set the orderdetail/salesrep                        
                            tbl_zIssuedRefNo order = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                            if (order != null)
                                glbOrderRefNo = detail.IssuedRefNo_ID;
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Remove LoanIN/Out
        private void btnDelete_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dgvInvoice.SelectedCells.Count != 0)
                {
                    if (dgvInvoice.Rows.Count > 0)
                        dgvInvoice.Rows.RemoveAt(dgvInvoice.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsHelpMethods.FormatGrid_Stock_External(dgvDetail);

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["ItemName"].Width = 345;
        }


        private void CusDataGirdViewFormatForCalucation(DataGridView dgv, bool bWeightCalculation)
        {
            if (bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = true;
                dgv.Columns["WeightPrice"].Visible = true;
                dgv.Columns["Quantity"].Visible = false;
                dgv.Columns["UnitPrice"].Visible = false;
            }
            else if (!bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = false;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = true;
                dgv.Columns["UnitPrice"].Visible = true;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLoanID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStoreID, true);

            txtItemID.Tag = null;
            txtStoreID.Tag = null;
            txtSupplierRefNo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtTmpLoanID.Tag = null;

            clearReciver();
            EnableDesableAllReciver(true);

            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtItemID.Clear();
            txtStoreID.Clear();
            glbOrderRefNo = "";
            txtRemark.Clear();
            txtSupplierRefNo.Clear();
            txtTmpLoanID.Clear();
            dtpGINDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            chkShowSettle.Checked = false;

            chkIsFirstDocument.Enabled = true;
            chkIsFirstDocument.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            //      userDetailsColorChanges();

            dgvDetail.Rows.Clear();
            dgvInvoice.Rows.Clear();

            //rdoLoanIn.Checked = true;
            rdoOther.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode_LoanIn) && clsAutocode.IsAutoGenerated(sFormConfigCode_LoanOut))
                txtLoanID.Text = "<Auto Generate>";
            else
                txtLoanID.Clear();
            if (txtLoanID.Enabled)
            {
                txtLoanID.SelectAll();
                txtLoanID.Focus();
            }

            // This Variables consuming in Lon Settle Form
            sLoanInID = "";
            sLonOutID = "";
            sAllocationID = "";

            if (clsConfig.bEnable_OtherTextBox_LoanOutForm == "0")
            {
                txtOther.Enabled = false;
                rdoOther.Enabled = false;
            }

            Attachments.Clear();
        }
        #endregion

        #region Clear Reciver
        private void clearReciver()
        {
            txtCustomerID.Tag = null;
            txtSupplierID.Tag = null;

            txtCustomerID.Clear();
            txtSupplierID.Clear();
            txtOther.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetailsLoanIn(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsLoanIn detail = tbl_scsLoanIn.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLoanID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreID, false);


                        //fill order detials
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //asign values
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        glbOrderRefNo = detail.IssuedRefNo_ID;

                        txtLoanID.Text = detail.LoanIn_ID;
                        txtLoanID.Tag = detail.LoanIn_ID;

                        dtpGINDate.Value = detail.LoanInDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkIsFirstDocument.Checked = detail.IsFirstDocument;
                        chkIsFirstDocument.Enabled = false;

                        txtRemark.Text = detail.Remark;
                        rdoLoanIn.Checked = true;

                        //Assign Reciver
                        if (detail.IsForCustomer)
                        {
                            rdoCustomer.Checked = true;
                            txtCustomerID.Tag = detail.Customer_ID;
                            txtCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                        }
                        if (detail.IsForSupplier)
                        {
                            rdoSupplier.Checked = true;
                            txtSupplierID.Tag = detail.Supplier_ID;
                            txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        }
                        if (detail.IsForOther)
                        {
                            rdoOther.Checked = true;
                            txtOther.Text = detail.ReceiverName;
                        }

                        EnableDesableAllReciver(false);

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        //userDetailsColorChanges();

                        //fill item details
                        RefreshGridLoanIn(detail.LoanIn_ID);
                        RefreshGridLoanSettle_ByLoanIn_ID(detail.LoanIn_ID);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsLoanOut(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsLoanOut detail = tbl_scsLoanOut.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtLoanID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtSupplierRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStoreID, false);


                        //fill order detials
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtSupplierRefNo.Tag = detail.IssuedRefNo_ID;
                            txtSupplierRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        }

                        //asign values
                        txtStoreID.Tag = detail.Store_ID;
                        txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);
                        glbOrderRefNo = detail.IssuedRefNo_ID;

                        txtLoanID.Text = detail.LoanOut_ID;
                        txtLoanID.Tag = detail.LoanOut_ID;

                        dtpGINDate.Value = detail.LoanOutDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkIsFirstDocument.Checked = detail.IsFirstDocument;
                        chkIsFirstDocument.Enabled = false;

                        txtRemark.Text = detail.Remark;
                        rdoLoanOut.Checked = true;

                        //Assign Reciver
                        if (detail.IsForCustomer)
                        {
                            rdoCustomer.Checked = true;
                            txtCustomerID.Tag = detail.Customer_ID;
                            txtCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                        }
                        if (detail.IsForSupplier)
                        {
                            rdoSupplier.Checked = true;
                            txtSupplierID.Tag = detail.Supplier_ID;
                            txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        }
                        if (detail.IsForOther)
                        {
                            rdoOther.Checked = true;
                            txtOther.Text = detail.ReceiverName;
                        }

                        EnableDesableAllReciver(false);

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        //fill item details
                        RefreshGridLoanOut(detail.LoanOut_ID);
                        RefreshGridLoanSettle_ByLoanOut_ID(detail.LoanOut_ID);
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

        #region Refresh Grid
        private void RefreshGridLoanIn(string sGrnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_scsLoanIn_Detail> details = tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(sGrnID);
                foreach (tbl_scsLoanIn_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 0;
                        dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Qty, detail.UnitPrice, detail.WeightPrice, detail.Weight, detail.TotalAmount, detail.Remark);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridLoanOut(string sGrnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_scsLoanOut_Detail> details = tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(sGrnID);
                foreach (tbl_scsLoanOut_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (detail != null)
                    {
                        decimal dExRate = 0;
                        dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Qty, detail.UnitPrice, detail.WeightPrice, detail.Weight, detail.TotalAmount, detail.Remark);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridLoanSettle_ByLoanIn_ID(string sLoanIn_ID)
        {
            try
            {
                List<tbl_scsLoanSettle> details = tbl_scsLoanSettle.SelectAllByLoanIn_ID(sLoanIn_ID);
                foreach (tbl_scsLoanSettle detail in details)
                {
                    int iRow = 0;
                    dgvInvoice.Rows.Add();
                    iRow = dgvInvoice.Rows.Count - 1;
                    dgvInvoice["LoanNo", iRow].Value = detail.LoanOut_ID;
                    tbl_scsLoanOut oLoan = tbl_scsLoanOut.Select(detail.LoanOut_ID);
                    if (oLoan != null)
                        dgvInvoice["LoanDate", iRow].Value = clsFormatter.FormatDate_Short(oLoan.LoanOutDate);

                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridLoanSettle_ByLoanOut_ID(string sLoanOut_ID)
        {
            try
            {
                List<tbl_scsLoanSettle> details = tbl_scsLoanSettle.SelectAllByLoanOut_ID(sLoanOut_ID);
                foreach (tbl_scsLoanSettle detail in details)
                {
                    int iRow = 0;
                    dgvInvoice.Rows.Add();
                    iRow = dgvInvoice.Rows.Count - 1;
                    dgvInvoice["LoanNo", iRow].Value = detail.LoanIn_ID;
                    tbl_scsLoanIn oLoan = tbl_scsLoanIn.Select(detail.LoanIn_ID);
                    if (oLoan != null)
                        dgvInvoice["LoanDate", iRow].Value = clsFormatter.FormatDate_Short(oLoan.LoanInDate);

                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByItemID(string sItemrID)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemrID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemrID);
                if (detail != null && oItemF != null)
                {
                    decimal dExRate = 0;
                    dExRate = clsCommon.getCurrencyRate(clsConfig.sLocalCurrencyCode);
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                    Fill_Datagrid(iRow, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), 0, oItemF.SellingPrice1, oItemF.SellingPrice6, 0, 0, detail.Description);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion




        #region Events KeyDown
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (rdoLoanIn.Checked)
                    Search_LoanIN();
                else
                    Search_LoanOut();
            }
        }
        private void txtTmpLoanID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (rdoLoanIn.Checked)
                    Search_LoanOut_Tmp(true);
                else
                    Search_LoanIN_Tmp(true);
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }

        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ApprovedBy();
        }

        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Item();
        }

        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store();
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Customer();
        }

        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Supplier();
        }
        #endregion

        #region Events Double Click
        private void txtLoanID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (rdoLoanIn.Checked)
                {
                    Search_LoanIN();
                    if (txtLoanID.Tag != null)
                    {
                        sStorkID = txtStoreID.Tag.ToString();
                        sLoanInID = txtLoanID.Tag.ToString().Trim();
                    }
                }
                else
                {
                    Search_LoanOut();
                    if (txtLoanID.Tag != null)
                    {
                        sLonOutID = txtLoanID.Tag.ToString().Trim();
                        sStorkID = txtStoreID.Tag.ToString();
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void txtTmpLoanID_DoubleClick(object sender, EventArgs e)
        {
            if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Length > 0)
            {
                if (!checkIsFirstDocument(rdoLoanIn.Checked, txtLoanID.Tag.ToString()))
                {
                    if (rdoLoanIn.Checked)
                    {
                        Search_LoanOut_Tmp(true);
                        /*  if (txtTmpLoanID.Tag != null)
                              sLonOutID += txtTmpLoanID.Tag.ToString().Trim()+",";*/
                    }
                    else
                    {
                        Search_LoanIN_Tmp(true);
                        /* if (txtTmpLoanID.Tag != null)
                             sLoanInID += txtTmpLoanID.Tag.ToString().Trim()+",";*/
                    }
                }
            }

        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Item();
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_Customer();
        }

        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_Supplier();
        }
        private void btnSettle_Click(object sender, EventArgs e)
        {
            bool bisOktoSettle = true;

            #region Check LoanIN or Out
            if (rdoLoanIn.Checked)
                isLoanIn = true;
            else if (rdoLoanOut.Checked)
                isLoanIn = false;
            #endregion

            #region Set Loan IDs
            if (rdoLoanIn.Checked)
            {
                sLonOutID = "";
                bool bisUpdate = false;

                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    string sLoanoutID_For_LoanIN = clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "");
                    sLonOutIDAll += sLoanoutID_For_LoanIN + ",";//this For Settlement process
                    int iContinueCount = 0;

                    #region Update

                    #region Check Loan In
                    foreach (tbl_scsLoanSettle oItem in tbl_scsLoanSettle.SelectAllByLoanIn_ID(txtLoanID.Tag.ToString()))
                    {
                        bisUpdate = true;//For this Form determine is record exsist or not                        
                        if (oItem.LoanOut_ID == sLoanoutID_For_LoanIN)
                        {
                            iContinueCount++;
                            continue;
                        }

                    }
                    #endregion

                    #region Check Loan Out
                    foreach (tbl_scsLoanSettle oItem in tbl_scsLoanSettle.SelectAllByLoanOut_ID(sLoanoutID_For_LoanIN))
                    {
                        bisUpdate = true;

                        if (oItem.LoanIn_ID == txtLoanID.Tag.ToString())
                        {
                            iContinueCount++;
                            continue;
                        }

                    }
                    #endregion

                    if (iContinueCount == 0 && bisUpdate)
                    {
                        tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(sLoanoutID_For_LoanIN);
                        if (oLoanOut != null)
                        {

                            if (!oLoanOut.IsSeattled)
                                sLonOutID += sLoanoutID_For_LoanIN + ",";
                        }
                    }
                    #endregion

                    #region Insert
                    if (!bisUpdate)
                    {
                        tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(sLoanoutID_For_LoanIN);
                        if (oLoanOut != null)
                        {

                            if (!oLoanOut.IsSeattled)
                                sLonOutID += sLoanoutID_For_LoanIN + ",";
                        }
                    }
                    #endregion


                }

                if (sLonOutID == "" && sLonOutID.Length <= 0)
                {
                    MessageBox.Show("There is No New LoanOut Note For Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bisOktoSettle = false;
                }

            }
            else
            {
                sLoanInID = "";
                bool bisUpdate = false;

                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    string sLoanInID_ForLoanOutID = clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "");
                    sLoanInIDAll += sLoanInID_ForLoanOutID + ",";//this For Settlement process
                    int iContinueCount = 0;

                    #region Update

                    #region Check Notes are used
                    #region Check Loan Out
                    foreach (tbl_scsLoanSettle oItem in tbl_scsLoanSettle.SelectAllByLoanOut_ID(txtLoanID.Tag.ToString()))
                    {
                        bisUpdate = true;//For this Form determine is record exsist or not                     
                        if (oItem.LoanIn_ID == sLoanInID_ForLoanOutID)
                        {
                            iContinueCount++;
                            continue;
                        }

                    }
                    #endregion

                    #region Check Loan In
                    foreach (tbl_scsLoanSettle oInItem in tbl_scsLoanSettle.SelectAllByLoanIn_ID(sLoanInID_ForLoanOutID))
                    {
                        bisUpdate = true;
                        if (oInItem.LoanOut_ID == txtLoanID.Tag.ToString())
                        {
                            iContinueCount++;
                            continue;
                        }
                    }
                    #endregion
                    #endregion

                    if (iContinueCount == 0 && bisUpdate)
                    {
                        tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(sLoanInID_ForLoanOutID);
                        if (oLoanIn != null)
                        {

                            if (!oLoanIn.IsSeattled)
                                sLoanInID += sLoanInID_ForLoanOutID + ",";

                            //oLoanIn.IsSeattled = true;                       
                            //oLoanIn.Update();
                        }
                    }
                    #endregion

                    #region Insert

                    if (!bisUpdate)
                    {
                        tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(sLoanInID_ForLoanOutID);
                        if (oLoanIn != null)
                        {

                            if (!oLoanIn.IsSeattled)
                                sLoanInID += sLoanInID_ForLoanOutID + ",";

                            //oLoanIn.IsSeattled = true;                       
                            //oLoanIn.Update();
                        }
                    }

                    #endregion
                }

                if (sLoanInID == "" && sLoanInID.Length <= 0)
                {
                    MessageBox.Show("There is No New LoanIN Note For Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bisOktoSettle = false;
                }

            }
            #endregion

            if (bisOktoSettle)
            {
                frm_LoanSettlemnet frmLoan = new frm_LoanSettlemnet();
                if (!frmLoan.bNoAccess)
                    frmLoan.ShowDialog();
                else
                    MessageBox.Show("You haven't Permission to Accses This Settlement Form", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Events CheckedChanged
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //call cellend events for all records
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
            }
        }

        private void rdoDepartment_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            EnableReciver();
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_External_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        #endregion



        #region Search Methods
        private void Search_LoanIN()
        {
            clsSearch.Search_TransactionLoanIn_Direct(ref txtLoanID, chkShowSettle.Checked, false);
            if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Trim().Length > 0)
                FillDetailsLoanIn(txtLoanID.Tag.ToString());
        }
        private void Search_LoanOut()
        {
            clsSearch.Search_TransactionLoanOut_Direct(ref txtLoanID, chkShowSettle.Checked, false);
            if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Trim().Length > 0)
                FillDetailsLoanOut(txtLoanID.Tag.ToString());
        }
        private void Search_LoanIN_Tmp(bool isSecondDocument)
        {
            clsSearch.Search_TransactionLoanIn_Direct(ref txtTmpLoanID, false, isSecondDocument);
            if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Trim().Length > 0)
                btnAdd_Click(null, new EventArgs());
        }
        private void Search_LoanOut_Tmp(bool isSecondDocument)
        {
            clsSearch.Search_TransactionLoanOut_Direct(ref txtTmpLoanID, false, isSecondDocument);
            if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Trim().Length > 0)
                btnAdd_Click(null, new EventArgs());
        }
        private void Search_Item()
        {
            //clsSearch.Search_MasterItem(ref txtItemID);

            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString() != "default")
            {
                if (rdoLoanOut.Checked)
                {
                    string sStoreID = "", sSectionID = "", sDepartmentID = "";
                    if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                        sStoreID = txtStoreID.Tag.ToString();

                    clsHelpMethods.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, sStoreID, sSectionID, sDepartmentID);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else
                {
                    clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Please seclect store first!!!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStoreID.Focus();
            }

        }

        private void Search_Customer()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
        }
        private void Search_Supplier()
        {
            clsSearch.Search_MasterSupplier(ref txtSupplierID);
        }
        private void Search_Store()
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Length > 0)
                sStorkID = txtStoreID.Tag.ToString();
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierRefNo, "Ref. No"))
                {
                    if (rdoCustomer.Checked)
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer"))
                        { bStatus = true; }
                    }
                    if (rdoSupplier.Checked)
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier"))
                        { bStatus = true; }
                    }
                    if (rdoOther.Checked)
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtOther, "Others"))
                        { bStatus = true; }
                    }

                }
            }
            return bStatus;
        }
        private bool CheckSupplierSaveValidity()
        {
            bool rtn = true;
            if (rdoSupplier.Checked)
            {
                if (txtSupplierID.Tag != null)
                {
                    if (clsValidate.isSupplierBlackListed(txtSupplierID.Tag.ToString()))
                        rtn = false;
                    else if (clsValidate.isSupplierSuspended(txtSupplierID.Tag.ToString()))
                        rtn = false;
                }
            }
            return rtn;
        }
        private bool CheckNumberValidity()
        {
            //string strMessage = "";
            bool bStatus = true;

            return bStatus;
        }

        private bool CheckStockValidity()
        {
            string strMessage = "", sItemCode = "", sItemStatus = "", sSubCategoryID1 = "", sSubCategoryID2 = "", sSerialNo1 = "", sSerialNo2 = "", sJobCode = "default";//, sOriginalItemCode = ""
            decimal dWeightActual = 0;
            decimal dQty = 0;
            bool bStatus = true;

            if (rdoLoanOut.Checked)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    #region variables
                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    dWeightActual = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    sSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                    sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");
                    #endregion

                    if (!clsConfig.bStoreStockWithJobID)
                        sJobCode = "default";

                    #region Validate Stock Details
                    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sSubCategoryID1, sSubCategoryID2, sSerialNo1, sSerialNo2);
                    if (stock != null)
                    {
                        if (txtLoanID.Tag != null && txtLoanID.Tag.ToString().Trim().Length > 0)
                        {
                            foreach (tbl_scsLoanOut_Detail oOldDetail in tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(txtLoanID.Tag.ToString().Trim()).Where(p => p.LoanOut_ID != "default"))
                            {
                                tbl_scsLoanOut oOldLonOut = tbl_scsLoanOut.Select(oOldDetail.LoanOut_ID);
                                bool bIsWeight = false;
                                if (oOldLonOut != null && oOldLonOut.LoanOut_ID != "default")
                                    bIsWeight = oOldLonOut.IsWeightCalculation;

                                #region Validate Exsisting Itemes
                                if (oOldDetail.Item_ID == sItemCode && oOldDetail.ItemSubCategory_ID == sSubCategoryID1 && oOldDetail.ItemSubCategory2_ID == sSubCategoryID2 && oOldDetail.ItemSerialNo == sSerialNo1 && oOldDetail.ItemSerialNo2 == sSerialNo2)
                                {
                                    decimal dVeriance = 0;
                                    if (!bIsWeight) //check whether stock enabled - qty
                                    {
                                        #region Old Items Quantity Validation
                                        if (oOldDetail.Qty < dQty)
                                            dVeriance = dQty - oOldDetail.Qty;

                                        if (stock.Qty < dVeriance)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                    if (bIsWeight) //check whether stock enabled - weight
                                    {
                                        ////weight part
                                        #region Old Items Weight Validation
                                        if (oOldDetail.Weight < dWeightActual)
                                            dVeriance = dWeightActual - oOldDetail.Weight;

                                        if (stock.Weight < dVeriance)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                }
                                #endregion

                                #region Validate Newly added Item
                                else
                                {
                                    #region New Item Stock Validation
                                    if (stock.Weight < dWeightActual && clsConfig.bStockValidateWeight_eGIN && rdoLoanOut.Checked) //check whether stock enabled - qty
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                    if (stock.Qty < dQty && clsConfig.bStockValidateQty_eGIN) //check whether stock enabled - weight
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            //  strMessage += "Please Select Loan In for Setoff";
                            #region Validate Newly added Item

                            #region New Item Stock Validation
                            if (stock.Weight < dWeightActual && clsConfig.bStockValidateWeight_eGIN && rdoLoanOut.Checked) //check whether stock enabled - qty
                            {
                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            if (stock.Qty < dQty && clsConfig.bStockValidateQty_eGIN) //check whether stock enabled - weight
                            {
                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                bStatus = false;
                            }
                            #endregion

                            #endregion
                        }


                    }
                    else
                    {
                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
                        bStatus = false;
                    }

                    #region Must Remove
                    //if (stock != null)
                    //{
                    //    if (sItemStatus.ToLower() == "o") //new item
                    //    {
                    //        #region Old Items Stock Validation
                    //        List<tbl_scsExternalGoodIssueNote_Detail> oldDetails = tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(txtLoanID.Text.Trim());
                    //        foreach (tbl_scsExternalGoodIssueNote_Detail oldDetail in oldDetails)
                    //        {
                    //            if (oldDetail.Item_ID == sItemCode && oldDetail.ItemSubCategory_ID == sSubCategoryID1 && oldDetail.ItemSubCategory2_ID == sSubCategoryID2 && oldDetail.ItemSerialNo == sSerialNo1 && oldDetail.ItemSerialNo2 == sSerialNo2)
                    //            {
                    //                decimal dVeriance = 0;
                    //                if (clsConfig.bStockValidateQty_eGIN) //check whether stock enabled - qty
                    //                {
                    //                    #region Old Items Quantity Validation
                    //                    if (oldDetail.Qty < dQty)
                    //                        dVeriance = dQty - oldDetail.Qty;

                    //                    if (stock.Qty < dVeriance)
                    //                    {
                    //                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                    //                        bStatus = false;
                    //                    }
                    //                    #endregion
                    //                }
                    //                if (clsConfig.bStockValidateWeight_eGIN) //check whether stock enabled - weight
                    //                {
                    //                    ////weight part
                    //                    #region Old Items Weight Validation
                    //                    if (oldDetail.Weight < dWeightActual)
                    //                        dVeriance = dWeightActual - oldDetail.Weight;

                    //                    if (stock.Weight < dVeriance)
                    //                    {
                    //                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                    //                        bStatus = false;
                    //                    }
                    //                    #endregion
                    //                }
                    //            }
                    //        }
                    //        #endregion
                    //    }
                    //    else
                    //    {
                    //        #region New Item Stock Validation
                    //        if (stock.Weight < dWeightActual && clsConfig.bStockValidateWeight_eGIN && rdoLoanOut.Checked) //check whether stock enabled - qty
                    //        {
                    //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                    //            bStatus = false;
                    //        }
                    //        if (stock.Qty < dQty && clsConfig.bStockValidateQty_eGIN) //check whether stock enabled - weight
                    //        {
                    //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                    //            bStatus = false;
                    //        }
                    //        #endregion
                    //    }
                    //}

                    //else
                    //{
                    //    strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
                    //    bStatus = false;
                    //}
                    #endregion

                    #endregion
                }
            }

            if (bStatus == false)
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckTmpLoanINOutValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    if (clsValidate.ValidateGridValue(dgvInvoice, "LoanNo", row.Index, "").ToString() == txtTmpLoanID.Text.Trim())
                    {
                        strMessage += "\n" + "You have already entered this LoanNo  " + txtTmpLoanID.Text.Trim();
                        bStatus = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckGridCountValidity()
        {
            bool bIsOK = true;
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
            {
                int iGrid = dgvDetail.Rows.Count;
                if (iGrid >= 2)
                {
                    bIsOK = false;
                    MessageBox.Show("You Can't Add more than one Item", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return bIsOK;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtStoreID);
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                clsCommon.ValidateForeignKey(ref txtCustomerID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight, decimal Amount, string Remark)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (ItemID == sItemID && ItemSubCategoryID1 == sItemSub && ItemSubCategoryID2 == sItemSub2 && ItemSerialNo1 == sSerial && ItemSerialNo2 == sSerial2)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Quantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }


                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                //
                dgvDetail["ItemSubCategoryID1", iRow].Tag = ItemSubCategoryID1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = ItemSubCategoryID2;
                //
                dgvDetail["ItemSerialNo1", iRow].Value = ItemSerialNo1;
                dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);
                dgvDetail["Remarks", iRow].Value = Remark;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Quantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                dgvDetail["Amount", iRow].Tag = clsFormatter.FormatToCurrecyWithThousendSep(Amount);

                dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                dgvDetail["UnitPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);
                dgvDetail["WeightPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Get Reciver Name
        private string getReciverName()
        {
            string rtn = "";
            if (rdoCustomer.Checked)
                rtn = clsGenaralName.getName_Customer(txtCustomerID.Tag.ToString());
            if (rdoSupplier.Checked)
                rtn = clsGenaralName.getName_Supplier(txtSupplierID.Tag.ToString());
            if (rdoOther.Checked)
                rtn = txtOther.Text.Trim();
            return rtn;
        }
        #endregion

        #region Radio button Checked Event
        private void rdoLoanIn_CheckedChanged(object sender, EventArgs e)
        {
            // if (rdoLoanIn.Checked)
            // isLoanIn = true;
        }
        private void rdoLoanOut_CheckedChanged(object sender, EventArgs e)
        {
            // isLoanIn = false;
        }
        #endregion


        private bool checkIsFirstDocument(bool isLoanIn, string sLoanID)
        {
            bool bIsFirstDoc = false;

            if (isLoanIn)
            {
                tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(sLoanID.Trim());
                if (oLoanIn != null && oLoanIn.LoanIn_ID != "default")
                    bIsFirstDoc = oLoanIn.IsFirstDocument;
            }
            else
            {
                tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(sLoanID.Trim());
                if (oLoanOut != null && oLoanOut.LoanOut_ID != "default")
                    bIsFirstDoc = oLoanOut.IsFirstDocument;
            }

            return bIsFirstDoc;

        }

        #region
        private void print(string s_Path, bool bIsDuplicate, DataSet dt, string sReportTitle, string sCreateUser, string sCheckedUser, string sApprovedUser)
        {

            frm_ReportViewer viewer = new frm_ReportViewer();
            ReportDocument RD = new ReportDocument();
            RD.Load(s_Path);
            RD.SetDataSource(dt);
            // clsSecurity.LogonServer(ref RD);
            // RD.Refresh();

            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

            //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
            RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
            //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
            RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
            RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
            RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
            RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
            RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
            RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
            RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_User(clsSecurity.UserIDLoged));
            if (bIsDuplicate)
                RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

            viewer.crystalReportViewer1.ReportSource = RD;
            //viewer.crystalReportViewer1.SelectionFormula = sFormula;
            viewer.crystalReportViewer1.Visible = true;
            viewer.crystalReportViewer1.DisplayToolbar = true;
            viewer.crystalReportViewer1.CloseView(false);
            viewer.WindowState = FormWindowState.Maximized;

            viewer.ShowDialog();

            RD.Close();
            RD.Dispose();


        }
        #endregion

        private void frm_scsLoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void btnChecked_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtLoanID.Text != null && txtLoanID.TextLength > 0 && txtLoanID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    glbApprovedDate = clsSecurity.getServerDateTime();
                                    if (IsUpdate)
                                    {
                                        //userDetailsColorChanges();

                                        tbl_scsExternalGoodIssueNote objCO = tbl_scsExternalGoodIssueNote.Select(txtLoanID.Text.Trim());
                                        if (objCO != null)
                                        {
                                            objCO.IsApproved = true;
                                            objCO.DateApproved = clsSecurity.getServerDateTime();
                                            objCO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objCO.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpGINDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtLoanID.Text != null && txtLoanID.TextLength > 0 && txtLoanID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    glbCheckedDate = clsSecurity.getServerDateTime();

                                    if (IsUpdate)
                                    {
                                        //userDetailsColorChanges();

                                        tbl_scsExternalGoodIssueNote objCO = tbl_scsExternalGoodIssueNote.Select(txtLoanID.Text.Trim());
                                        if (objCO != null)
                                        {
                                            objCO.IsChecked = true;
                                            objCO.DateChecked = clsSecurity.getServerDateTime();
                                            objCO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objCO.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            if (txtLoanID.Text != "" || txtLoanID.Text != "<Auto Generate>")
            {
                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(txtLoanID.Text.Trim());
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
            }
        }

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion
    }

}
