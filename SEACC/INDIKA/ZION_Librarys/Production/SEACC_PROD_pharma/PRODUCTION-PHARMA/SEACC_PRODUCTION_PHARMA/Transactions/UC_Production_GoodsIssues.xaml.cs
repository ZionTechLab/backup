 using DataTire;
using Digiteq_Logic;
using SEACC.PROD.DATA.Data.SCS;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.DataSets;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_PRODUCTION_PHARMA.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_PHARMA.Transactions
{
    /// <summary>
    /// Developped By Gayan
    /// 2017-05-23
    /// </summary>
    public partial class UC_Production_GoodsIssues : UserControl
    {
        #region Class Variables
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_PGIN glb_dtsPGIN = new dts_PGIN();

        InventoryTxnData oData = new InventoryTxnData();
        #endregion

        #region Form Load
        public UC_Production_GoodsIssues()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_GoodsIssues;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Meterial Data Table
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("Batch_No");
            dtMeterials.Columns.Add("FG_ItemID");
            dtMeterials.Columns.Add("FG_ItemName");
            dtMeterials.Columns.Add("Item_ID");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("StoreBalance_Qty");
            dtMeterials.Columns.Add("PGIN_Qty");
            dtMeterials.Columns.Add("MR_Qty");
            dtMeterials.Columns.Add("PrvPGIN_Qty");
            dtMeterials.Columns.Add("PrvPGRN_Qty");
            dtMeterials.Columns.Add("Pending_Qty");
            dtMeterials.Columns.Add("Remarks");
            #endregion

            #region Main Data Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("PGIN_NO");
            dgr_Main.dt.Columns.Add("PGIN_DATE");
            dgr_Main.dt.Columns.Add("ISSUED_LOCATION");
            dgr_Main.dt.Columns.Add("MR_NO");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("pGIN No", "PGIN_NO", 80);
            dgr_Main.Add_DatagridColoumn("pGIN Date", "PGIN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Issued Store", "ISSUED_LOCATION", 150);
            dgr_Main.Add_DatagridColoumn("MR No", "MR_NO", 80);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sPGIN_No = "";
            if (CheckValidity())
            {
                try
                {
                    tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMR.Tag.ToString());
                    if (oMR != null)
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prod_pharmaTxGoodIssueNote oOldPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                                if (oOldPGIN != null)
                                {
                                    if (!oOldPGIN.IsApproved && !oOldPGIN.IsCanceled)
                                    {
                                        tbl_prod_pharmaTxGoodIssueNote oPGIN = new tbl_prod_pharmaTxGoodIssueNote(txtPGINId.Tag.ToString(), dtpPGIN_Date.GetDateTime(),
                                        txtIssuedStore.Tag != null ? txtIssuedStore.Tag.ToString() : "default",
                                        txtOrderedBy.Tag != null ? txtOrderedBy.Tag.ToString() : "default",
                                        txtMR.Tag.ToString(),
                                        txtItemsCollectedBy.Tag != null ? txtItemsCollectedBy.Tag.ToString() : "default", txtRemark.Text,
                                        oOldPGIN.IsChecked, oOldPGIN.IsApproved, oOldPGIN.IsCanceled,
                                        oOldPGIN.CreateUser_ID, clsSecurity.UserIDLoged, oOldPGIN.CheckedUser_ID, oOldPGIN.ApprovedUser_ID, oOldPGIN.CanceldUser_ID,
                                        oOldPGIN.DateCreate, clsSecurity.getServerDateTime(), oOldPGIN.DateChecked, oOldPGIN.DateApproved, oOldPGIN.DateCanceled,
                                        oOldPGIN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldPGIN.CheckedUserTerminal_ID, oOldPGIN.ApprovedUserTerminal_ID, oOldPGIN.CanceledUserTerminal_ID,
                                        oOldPGIN.CompanyID, oOldPGIN.CompanyBranchID
                                        );
                                        oPGIN.Update();

                                        foreach (tbl_prod_pharmaTxGoodIssueNote_Material oMat in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByPGIN_No(oPGIN.PGIN_No))
                                        {
                                            clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                            clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                            oMat.Delete();
                                        }

                                        PGIN_InsertMaterials(oMR);

                                        var responce = oData.Update_InventoryTxn(SEACC_Form.Function_ID, oPGIN.PGIN_No, SEACC_Form.IsUpdateMode);
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(oPGIN.PGIN_No + " - " + responce.OutMsg, SEACC_Form.Function_ID, null);
                                            MessageBox.Show(responce.OutMsg);
                                        }

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldPGIN.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected PGIN has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldPGIN.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected PGIN has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                sPGIN_No = oOldPGIN.PGIN_No;
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                tbl_prod_pharmaTxGoodIssueNote oPGIN = new tbl_prod_pharmaTxGoodIssueNote(txtPGINId.Tag.ToString(), dtpPGIN_Date.GetDateTime(),
                                       txtIssuedStore.Tag != null ? txtIssuedStore.Tag.ToString() : "default",
                                       txtOrderedBy.Tag != null ? txtOrderedBy.Tag.ToString() : "default",
                                       txtMR.Tag.ToString(),
                                       txtItemsCollectedBy.Tag != null ? txtItemsCollectedBy.Tag.ToString() : "default", txtRemark.Text,
                                      false, false, false,
                                       clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                       clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                       clsSecurity.TerminalID, "default", "default", "default", "default",
                                       clsSecurity.CompanyID, clsSecurity.BranchID
                                       );
                                oPGIN.Insert();

                                PGIN_InsertMaterials(oMR);

                                var responce = oData.Update_InventoryTxn(SEACC_Form.Function_ID, oPGIN.PGIN_No, SEACC_Form.IsUpdateMode);
                                if (!responce.IsSuccess)
                                {
                                    clsValidate.WriteErrorLog(oPGIN.PGIN_No + " - " + responce.OutMsg, SEACC_Form.Function_ID, null);
                                    MessageBox.Show(responce.OutMsg);
                                }


                                sPGIN_No = oPGIN.PGIN_No;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                    FillDetails(sPGIN_No);
                }
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        glb_dtsPGIN.Clear();
                        string sDraft = "", sCanceled = "", sDuplicateCopy = "";
                        bool bDuplicateCopy = false;
                        int iDuplcateCopyCount = 0;

                        tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.ProdPharma_PGIN);
                        tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReport.Function_ID);

                        if (oReport != null && oUserPermission != null)
                        {
                            tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(txtPGINId.Text.Trim());
                            if (oPGIN != null)
                            {
                                clsHelpMethods_Prod.PrintCount_Update(SEACC_Form.enmFormName, enum_ReportName.ProdPharma_PGIN, oPGIN.PGIN_No, ref bDuplicateCopy, ref iDuplcateCopyCount);
                                if (bDuplicateCopy)
                                    sDuplicateCopy = "Duplicate Copy " + iDuplcateCopyCount;

                                if (oPGIN.IsCanceled)
                                {
                                    sCanceled = "CANCELLED";
                                    sDuplicateCopy = "";
                                }

                                tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(oPGIN.Mr_No);

                                glb_dtsPGIN.dt_ProductGoodIssueNote.Adddt_ProductGoodIssueNoteRow(oPGIN.PGIN_No, oPGIN.PGIN_Date.ToString(cls_Formater.Format_Date2),
                                    oPGIN.Store_ID, clsGenaralName.getName_Store(oPGIN.Store_ID), oMR.Section_ID, clsGenaralName.getName_Section(oMR.Section_ID),
                                    oPGIN.Mr_No, oPGIN.Remark,
                                    sDraft, sDuplicateCopy, sCanceled,
                                    clsGenaralName.getName_User(oPGIN.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oPGIN.DateCreate),
                                    clsGenaralName.getName_User(oPGIN.CheckedUser_ID), clsHelpMethods_Prod.Format_DateTime(oPGIN.DateChecked),
                                    clsGenaralName.getName_User(oPGIN.ApprovedUser_ID), clsHelpMethods_Prod.Format_DateTime(oPGIN.DateApproved));

                                foreach (tbl_prod_pharmaTxGoodIssueNote_Material oPGIN_Materials in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByPGIN_No(oPGIN.PGIN_No))
                                {
                                    tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(oPGIN_Materials.ProdJob_ID);
                                    if (oProdJob != null)
                                    {
                                        glb_dtsPGIN.dt_ProductGoodIssueNote_Detail.Adddt_ProductGoodIssueNote_DetailRow(oPGIN.PGIN_No, oPGIN.Mr_No, oPGIN_Materials.ProdBatch_ID, oPGIN_Materials.ProdJob_ID,
                                            oProdJob.Item_ID_FG, clsGenaralName.getName_Item(oProdJob.Item_ID_FG), oProdJob.FGoodQty,
                                            oPGIN_Materials.Item_ID, clsGenaralName.getDescription_Item(oPGIN_Materials.Item_ID), clsGenaralName.getName_Item(oPGIN_Materials.Item_ID),
                                            oPGIN_Materials.Uom_ID, clsGenaralName.getName_Uom(oPGIN_Materials.Uom_ID),
                                            oPGIN_Materials.PGIN_Qty, oPGIN_Materials.Issued_Qty, 0, 0,
                                            oPGIN_Materials.Remark);
                                    }
                                }

                                #region Company Details Fill
                                glb_dtsPGIN.dt_company.Adddt_companyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, "", clsCommon.getCompanyEmail(), clsCommon.getCompanyWeb(), clsCommon.getCompanyBusinessRegisterNo());
                                #endregion

                                frm_ReportViewer rpt = new frm_ReportViewer();
                                rpt.print(oReport.ReportPath, glb_dtsPGIN, glb_dtsReportExport.dt_rptParameter, oUserPermission);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (txtPGINId.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                            if (oPGIN != null)
                            {
                                if (!oPGIN.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oPGIN.IsApproved = true;
                                            oPGIN.DateApproved = clsSecurity.getServerDateTime();
                                            oPGIN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oPGIN.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oPGIN.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oPGIN.PGIN_No);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected pGIN has already been approved", MessageBoxButton.OK, "Red");
                                }
                            }
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Alreay Approved", "Selected pGIN has already been approved", MessageBoxButton.OK, "Red");
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtPGINId.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                            if (oPGIN != null)
                            {
                                if (!oPGIN.IsApproved)
                                {
                                    if (!oPGIN.IsCanceled)
                                    {
                                        tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMR.Tag.ToString());
                                        if (oMR != null)
                                        {
                                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                            if (bMessegeBoxResult)
                                            {
                                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                                frmTwoStepVerify.ShowDialog();
                                                if (frmTwoStepVerify.bVerified)
                                                {
                                                    oPGIN.IsCanceled = true;
                                                    oPGIN.DateCanceled = clsSecurity.getServerDateTime();
                                                    oPGIN.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                    oPGIN.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                    //foreach (tbl_prod_pharmaTxGoodIssueNote_Material oMat in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByPGIN_No(oPGIN.PGIN_No))
                                                    //{
                                                    //    clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                                    //    clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                                    //}

                                                    oPGIN.Update();

                                                    var responce = oData.Delete_InventoryTxn(SEACC_Form.Function_ID, txtMR.Tag.ToString());
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtMR.Tag.ToString() + " - " + responce.OutMsg, SEACC_Form.Function_ID, null);
                                                    }

                                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                                }
                                                frmTwoStepVerify.Close();
                                            }
                                            ClearFields();
                                            RefreshGrid();
                                        }
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyApproved);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPGINId, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtIssuedStore, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMR, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtOrderedBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemsCollectedBy, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtPGINId.Tag = null;
            txtIssuedStore.Tag = null;
            txtMR.Tag = null;
            txtOrderedBy.Tag = null;
            txtItemsCollectedBy.Tag = null;

            txtPGINId.Text = "";
            txtIssuedStore.Text = "";
            txtMR.Text = "";
            txtOrderedBy.Text = "";
            txtItemsCollectedBy.Text = "";
            txtRemark.Text = "";

            dtMeterials.Clear();
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;

            txtIssuedStore.IsEnabled = true;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPGINId.setReadOnlyStatus(true);
                txtPGINId.Text = "<Auto Generate>";
            }
            else
                txtPGINId.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_pharmaTxGoodIssueNote oPGIN in tbl_prod_pharmaTxGoodIssueNote.SelectAll().Where(p => p.Mr_No != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oPGIN.PGIN_No, oPGIN.PGIN_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Store(oPGIN.Store_ID), oPGIN.Mr_No, clsGenaralName.getName_User(oPGIN.CreateUser_ID), clsGenaralName.getName_User(oPGIN.ApprovedUser_ID), oPGIN.IsCanceled);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (Check_EnteredPGINQty_Validation())
                    if (CheckFloorStock())
                        if (CheckValidity_DuplicateFiled())
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtPGINId.Text))
                                bStatus = true;
                            

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtPGINId))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtIssuedStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMR))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtPGINId.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtPGINId.Text = txtPGINId.Tag.ToString();
                }

                tbl_prod_pharmaTxGoodIssueNote oJob = tbl_prod_pharmaTxGoodIssueNote.Select(txtPGINId.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool Check_EnteredPGINQty_Validation()
        {
            bool bReturn = false;

            foreach (DataRow dr in dtMeterials.Rows)
            {
                int iLineNo = clsValidate.ValidateRowValue(dr, "LineNo", -1);
                string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                string sItemName = clsValidate.ValidateRowValue(dr, "ItemName", "");
                decimal dEnteredQty = clsValidate.ValidateRowValue(dr, "PGIN_Qty", 0m);
                decimal dBase_Qty = clsValidate.ValidateRowValue(dr, "MR_Qty", 0m);
                decimal dPreviousQty = clsValidate.ValidateRowValue(dr, "PrvPGIN_Qty", 0m);

                if (dEnteredQty == 0)
                {
                    bReturn = true;
                }
                else if (clsConfig.dDataGrid_EditedQuantity_Validation_WithPecentage < 0m)
                {
                    bReturn = true;
                }
                else
                {
                    decimal dMargin_Qty = Math.Round(dBase_Qty * clsConfig.dDataGrid_EditedQuantity_Validation_WithPecentage / 100, clsConfig.sDecimalPlaces_Quantity);
                    if ((dEnteredQty + dPreviousQty) <= (dBase_Qty + dMargin_Qty) && (dEnteredQty + dPreviousQty) >= ((dBase_Qty - dMargin_Qty)))
                    {
                        bReturn = true;
                    }
                    else
                    {
                        decimal dLowerMargin = (dBase_Qty - dMargin_Qty) - dPreviousQty;
                        decimal dUpperMargin = (dBase_Qty + dMargin_Qty) - dPreviousQty;

                        SEACCMessageBox.Show("Not Valid Qty...!", "Please Enter a valid quantity between "
                            + cls_Formater.FormatDecimal(dLowerMargin < 0 ? 0 : dLowerMargin, clsConfig.sDecimalPlaces_Quantity)
                            + " and "
                            + cls_Formater.FormatDecimal(dUpperMargin < 0 ? 0 : dUpperMargin, clsConfig.sDecimalPlaces_Quantity)
                            + "\nLine No: " + iLineNo + ", Material: " + sItem_ID + " - " + sItemName
                            , MessageBoxButton.OK, "Red");

                        bReturn = false;

                        break;
                    }
                }
            }

            return bReturn;
        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            DataTable dtFloorStock = new DataTable();
            dtFloorStock = clsHelpMethods_Prod.GetItemGroupedItemFloorstockTable(dtMeterials, "PGIN_Qty", txtIssuedStore.Tag.ToString());

            if (SEACC_Form.IsUpdateMode)
            {
                foreach (DataRow dr in dtFloorStock.Rows)
                {
                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                    dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByPGIN_No(txtPGINId.Text).Where(r => r.Item_ID == sItem_ID).Sum(x => x.PGIN_Qty), clsConfig.sDecimalPlaces_Quantity);
                }
            }

            bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);

            return bReturn;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(sID);
                if (oPGIN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtPGINId.Tag = oPGIN.PGIN_No;
                    txtIssuedStore.Tag = oPGIN.Store_ID;
                    txtOrderedBy.Tag = oPGIN.Ordered_HOD;
                    txtMR.Tag = oPGIN.Mr_No;
                    txtItemsCollectedBy.Tag = oPGIN.ItemCollectedBy;

                    dtpPGIN_Date.SetTime(oPGIN.PGIN_Date);

                    txtPGINId.Text = oPGIN.PGIN_No;
                    txtIssuedStore.Text = clsGenaralName.getName_Store(oPGIN.Store_ID);
                    txtOrderedBy.Text = clsGenaralName.getName_Employee(oPGIN.Ordered_HOD);
                    txtMR.Text = oPGIN.Mr_No;
                    txtItemsCollectedBy.Text = clsGenaralName.getName_Employee(oPGIN.ItemCollectedBy);
                    txtRemark.Text = oPGIN.Remark;

                    txtIssuedStore.IsEnabled = false;

                    if (oPGIN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oPGIN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    FillMaterialGrid_form_PGIN(sID, oPGIN.Mr_No);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FillMaterialGrid_form_MR(string sMR_No)
        {
            try
            {

                dtMeterials.Clear();
                foreach (tbl_prod_pharmaTxMaterialRequision_Material oMaterial in tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByMr_No(sMR_No).Where(r => r.Store_ID == txtIssuedStore.Tag.ToString()))
                {
                    decimal dstockQty = 0, dPrvIssuedPGINQty = 0, dPendingQty = 0;

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMaterial.Item_ID);
                    if (oItem != null)
                    {
                        dstockQty = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(txtIssuedStore.Tag.ToString(), oItem.Item_ID);
                        dPrvIssuedPGINQty = AlreadyIssuedQty_formPGINs_AgainstMR(oMaterial.Mr_No, oMaterial.Item_ID);
                        dPendingQty = oMaterial.Mr_Qty - dPrvIssuedPGINQty;
                    }
                    string sFG_ID = clsGenaralName.getID_PharmaBoM_FinishedGood(oMaterial.ProdJob_ID);
                    dtMeterials.Rows.Add("0", oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID,
                        sFG_ID, clsGenaralName.getName_Item(sFG_ID),
                        oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID),
                        oMaterial.Uom_ID, clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                        cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity),
                        (dstockQty > oMaterial.Mr_Qty ? cls_Formater.FormatDecimal(oMaterial.Mr_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity)),
                        cls_Formater.FormatDecimal(oMaterial.Mr_Qty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(dPrvIssuedPGINQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(ReturnedQty_formPGRNs(oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID, oMaterial.Item_ID, clsSecurity.getServerDateTime()), clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(dPendingQty >= 0 ? dPendingQty : 0, clsConfig.sDecimalPlaces_Quantity)
                        );
                }
                dgr_Meterial.ItemsSource = dtMeterials.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FillMaterialGrid_form_PGIN(string sPGIN_No, string sMR_No)
        {
            dtMeterials.Clear();
            foreach (tbl_prod_pharmaTxGoodIssueNote_Material oMaterial in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByPGIN_No(sPGIN_No))
            {
                tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(sPGIN_No);
                tbl_prod_pharmaTxMaterialRequision_Material oMR_Material = tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByMr_No(sMR_No).Where(r => r.Item_ID == oMaterial.Item_ID && r.ProdJob_ID == oMaterial.ProdJob_ID).FirstOrDefault();

                decimal dstockQty = oMaterial.StoreBalance_Qty;
                decimal dPendingQty = oMR_Material.Mr_Qty - oMaterial.Issued_Qty;

                string sFG_ID = clsGenaralName.getID_PharmaBoM_FinishedGood(oMaterial.ProdJob_ID);
                dtMeterials.Rows.Add("0", oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID,
                    sFG_ID, clsGenaralName.getName_Item(sFG_ID),
                    oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID),
                    oMaterial.Uom_ID, clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                    cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oMaterial.PGIN_Qty, clsConfig.sDecimalPlaces_Quantity),
                    oMR_Material != null ? cls_Formater.FormatDecimal(oMR_Material.Mr_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oMaterial.Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(ReturnedQty_formPGRNs(oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID, oMaterial.Item_ID, oPGIN.DateCreate), clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dPendingQty >= 0 ? dPendingQty : 0, clsConfig.sDecimalPlaces_Quantity)
                    );
            }
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;
        }
        #endregion

        #region Grid Events
        #region Main Grid

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    ClearFields();
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[7].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Meterial Grid
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }

        private void dgr_Meterial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;

            if (sColumnName == "PGIN_Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    object item = dgr_Meterial.SelectedItem;
                    if (item != null)
                    {
                        dQty = decimal.Parse(t.Text);

                        string sStock_Qty = (dgr_Meterial.SelectedCells[9].Column.GetCellContent(item) as TextBlock)?.Text;
                        decimal dStock_Qty = clsValidation.Validate_DecimalNumber(sStock_Qty);
                        if (dStock_Qty < dQty)
                        {
                            dQty = dStock_Qty;
                            SEACCMessageBox.Show("Oops..!", "Store Balance Quantity : " + dStock_Qty + "\nQuantity should be less than or equal to Store Balance Quantity", MessageBoxButton.OK);
                        }
                        else
                        {
                            string sMR_Qty = (dgr_Meterial.SelectedCells[10].Column.GetCellContent(item) as TextBlock)?.Text;
                            string sPrevious_IssuedQty = (dgr_Meterial.SelectedCells[11].Column.GetCellContent(item) as TextBlock)?.Text;

                            decimal dMR_Qty = clsValidation.Validate_DecimalNumber(sMR_Qty);
                            decimal dPrevious_IssuedQty = clsValidation.Validate_DecimalNumber(sPrevious_IssuedQty);

                            dQty = clsHelpMethods_Prod.DataGrid_EditedQuantity_Validation(dQty, dPrevious_IssuedQty, dMR_Qty, clsConfig.dDataGrid_EditedQuantity_Validation_WithPecentage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }
        }

        #endregion
        #endregion

        #region Search Events
        private void txtIssuedLocation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtIssuedStore.Tag = lstResult[0];
                txtIssuedStore.Text = lstResult[1];
            }
        }

        private void txtMR_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtIssuedStore.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMeterialRequisition);
                if (RowDataSearch.DialogResult == true)
                {
                    txtMR.Tag = lstResult[0];
                    txtMR.Text = lstResult[0];

                    FillMaterialGrid_form_MR(lstResult[0]);

                    txtIssuedStore.IsEnabled = false;
                }
            }
            else
            {
                SEACCMessageBox.Show("Issued Location Can not Empty", "Please select an issued location/store before selecting a MR", MessageBoxButton.OK, "Red");
            }
        }

        private void txtOrderedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Employees);
            if (RowDataSearch.DialogResult == true)
            {
                txtOrderedBy.Tag = lstResult[0];
                txtOrderedBy.Text = lstResult[1];
            }
        }

        private void txtItemsCollectedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Employees);
            if (RowDataSearch.DialogResult == true)
            {
                txtItemsCollectedBy.Tag = lstResult[0];
                txtItemsCollectedBy.Text = lstResult[1];
            }
        }
        #endregion

        #region Help Methods
        private void PGIN_InsertMaterials(tbl_prod_pharmaTxMaterialRequision oMR)
        {
            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sItemID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dStoreBalance_Qty = clsValidate.ValidateRowValue(row, "StoreBalance_Qty", 0m);
                decimal dPGIN_Qty = clsValidate.ValidateRowValue(row, "PGIN_Qty", 0m);
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                decimal dIssuedPGIN_Qty = clsValidate.ValidateRowValue(row, "PrvPGIN_Qty", 0m);
                string sRemarks = clsValidate.ValidateRowValue(row, "Remarks", "");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItemID);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dPGIN_Qty;
                }

                tbl_prod_pharmaTxGoodIssueNote_Material oPGIN_Materials = new tbl_prod_pharmaTxGoodIssueNote_Material(iLine_no, txtPGINId.Tag.ToString(), sItemID, sUoM_ID, dIssuedPGIN_Qty, dStoreBalance_Qty, dPGIN_Qty, 0, dUnitPrice, 0, dTotalAmount, false, sRemarks, sBoM_No, sBatch_No);
                oPGIN_Materials.Insert();

              //  clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), sItemID, -dPGIN_Qty);
             //   clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, sItemID, dPGIN_Qty);
            }
        }

        private static decimal ReturnedQty_formPGRNs(string sBoM_No, string sBatch_No, string sItem_ID, DateTime dtmToDateTime)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxGoodReturnNote oPGRN in tbl_prod_pharmaTxGoodReturnNote.SelectAllByProdJob_ID(sBoM_No).Where(r => r.DateCreate <= dtmToDateTime && r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxGoodReturnNote_Material oMeterial in tbl_prod_pharmaTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No).Where(r => r.Item_ID == sItem_ID))
                    dQty += oMeterial.PGRN_Qty;
            }
            return dQty;
        }

        private decimal AlreadyIssuedQty_formPGINs_AgainstMR(string sMR_ID, string sItem_ID)
        {
            string sQuary = "select [dbo].[GetProd_PharmaPrvPGIN_Qty] ('" + sMR_ID + "', '" + sItem_ID + "')";
            string sQty = DBHandling.ExecQuery_ReturnString(sQuary);
            return clsValidation.Validate_DecimalNumber(sQty);
        }

        #endregion

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Return == e.Key &&
                0 < (ModifierKeys.Shift & e.KeyboardDevice.Modifiers))
            {
                var tb = (TextBox)sender;
                var caret = tb.CaretIndex;
                tb.Text = tb.Text.Insert(caret, Environment.NewLine);
                tb.CaretIndex = caret + 1;
                e.Handled = true;
            }
        }

        #region Key Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        #region Scroll Event
        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scv = sender as ScrollViewer;
            if (scv == null) return;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        #endregion
    }
}
