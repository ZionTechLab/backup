using DataTire;
using Digiteq_Logic;
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
    /// Developed By Gayan
    /// 2017-05-22
    /// </summary>
    public partial class UC_Production_MeterialRequisition : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_MR glb_dtsMR = new dts_MR();
        #endregion

        #region Form Load
        public UC_Production_MeterialRequisition()
        {
            #region Usercontrol Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ProdPharma_MeterialRequisition;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region BoM Table Initialize
            dtBoM.Columns.Add("LineNo", typeof(int));
            dtBoM.Columns.Add("IsSelect");
            dtBoM.Columns.Add("BoM_No");
            dtBoM.Columns.Add("Batch_No");
            dtBoM.Columns.Add("FG_ItemID");
            dtBoM.Columns.Add("FG_Item");
            dtBoM.Columns.Add("FG_UoM");
            dtBoM.Columns.Add("FG_Qty");
            dtBoM.Columns.Add("Customer");
            dtBoM.Columns.Add("COQty");
            dtBoM.Columns.Add("CO_ID");
            dtBoM.Columns.Add("MRQty");
            #endregion

            #region Meterial Table Initialize
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("BoM_Line_No");
            dtMeterials.Columns.Add("Batch_No");
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("PlannedQty");
            dtMeterials.Columns.Add("IssuedQty");
            dtMeterials.Columns.Add("BalanceQty");
            dtMeterials.Columns.Add("MRQty");
            dtMeterials.Columns.Add("ReqdDate");
            dtMeterials.Columns.Add("Instructions");
            dtMeterials.Columns.Add("StoreID");
            dtMeterials.Columns.Add("StroreName");
            dtMeterials.Columns.Add("AlreadyPGIN_Qty");
            #endregion

            #region Main Table Initialize
            dgr_Main.dt.Columns.Add("LINE_NO");
            dgr_Main.dt.Columns.Add("MR_NO");
            dgr_Main.dt.Columns.Add("MR_DATE");
            dgr_Main.dt.Columns.Add("SECTION");
            dgr_Main.dt.Columns.Add("PLAN_DATE_FROM");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            dgr_Main.dt.Columns.Add("IS_UNSETTLED");
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LINE_NO", 25, true, true);
            dgr_Main.Add_DatagridColoumn("MR NO", "MR_NO", 80);
            dgr_Main.Add_DatagridColoumn("MR DATE", "MR_DATE", 80);
            dgr_Main.Add_DatagridColoumn("SECTION", "SECTION", 150);
            dgr_Main.Add_DatagridColoumn("PLAN DATE", "PLAN_DATE_FROM", 80);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            dgr_Main.Add_DatagridColoumn("Is Unsettled", "IS_UNSETTLED", 100, false);
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
            string sMR_ID = "";
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved && !oMR.IsCanceled)
                                {

                                    tbl_prod_pharmaTxMaterialRequision oOldMR = new tbl_prod_pharmaTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), oMR.IsChecked, oMR.IsApproved, oMR.IsCanceled, oMR.CreateUser_ID, clsSecurity.UserIDLoged, oMR.CheckedUser_ID, oMR.ApprovedUser_ID, oMR.CanceldUser_ID, oMR.DateCreate, clsSecurity.getServerDateTime(), oMR.DateChecked, oMR.DateApproved, oMR.DateCanceled, oMR.CreateUserTerminal_ID, clsSecurity.TerminalID, oMR.CheckedUserTerminal_ID, oMR.ApprovedUserTerminal_ID, oMR.CanceledUserTerminal_ID, oMR.CompanyID, oMR.CompanyBranchID, txtRemarks.Text);
                                    oOldMR.Update();

                                    tbl_prod_pharmaTxMaterialRequision_JobCard.DeleteAllByMr_No(oMR.Mr_No);
                                    tbl_prod_pharmaTxMaterialRequision_Material.DeleteAllByMr_No(oMR.Mr_No);

                                    foreach (DataRow row in dtBoM.Rows)
                                    {
                                        bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                        if (bSelect)
                                        {
                                            string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                            string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                            string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                            decimal dMR_FG_Qty = clsValidate.ValidateRowValue(row, "MRQty", 0m);

                                            tbl_prod_pharmaTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prod_pharmaTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, sBatch_No, (sCO_ID == "-" ? "default" : sCO_ID), dMR_FG_Qty, clsGenaralName.getID_PharmaBoM_UoM(sBoM_No), clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(sBoM_No));
                                            oNewMR_JobCard.Insert();
                                        }
                                    }

                                    foreach (DataRow row in dtMeterials.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                        string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                        int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0m));
                                        string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                        string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0m);
                                        decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0m);
                                        decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0m);
                                        decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                        DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                        string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                        string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                        tbl_prod_pharmaTxMaterialRequision_Material oProdMR_Materials = new tbl_prod_pharmaTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sBatch_No, sItemNo, sUoM_ID, dPlannedQty, dIssuedQty, dBalanceQty, dMRQty, dtmReqdDate, sInstructions, sStoreID);
                                        oProdMR_Materials.Insert();
                                    }
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oMR.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected MR has been approved", MessageBoxButton.OK, "Red");
                                    else if (oMR.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Mr has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            sMR_ID = oMR.Mr_No;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prod_pharmaTxMaterialRequision oNewProdMR = new tbl_prod_pharmaTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID, txtRemarks.Text);
                            oNewProdMR.Insert();

                            foreach (DataRow row in dtBoM.Rows)
                            {
                                bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                if (!bSelect)
                                    continue;

                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                decimal dMR_FG_Qty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");

                                tbl_prod_pharmaTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prod_pharmaTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, sBatch_No, (sCO_ID == "-" ? "default" : sCO_ID), dMR_FG_Qty, clsGenaralName.getID_PharmaBoM_UoM(sBoM_No), clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(sBoM_No));
                                oNewMR_JobCard.Insert();
                            }

                            foreach (DataRow row in dtMeterials.Rows)
                            {
                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0m));
                                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0m);
                                decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0m);
                                decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0m);
                                decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                tbl_prod_pharmaTxMaterialRequision_Material oNewProdMR_Materials = new tbl_prod_pharmaTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sBatch_No, sItemNo, sUoM_ID, dPlannedQty, dIssuedQty, dBalanceQty, dMRQty, dtmReqdDate, sInstructions, sStoreID);
                                oNewProdMR_Materials.Insert();
                            }

                            sMR_ID = oNewProdMR.Mr_No;
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                    FillDetails(sMR_ID);
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
                        glb_dtsMR.Clear();
                        string sDraft = "", sCanceled = "", sDuplicateCopy = "", sPGIN_ID = "";
                        bool bDuplicateCopy = false;
                        int iDuplcateCopyCount = 0;

                        tbl_securityFunctionMaster_Report oNotePrint = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.ProdPharma_MR);
                        tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oNotePrint.Function_ID);

                        if (oNotePrint != null && oUserPermission != null)
                        {
                            tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Text);
                            if (oMR != null)
                            {
                                clsHelpMethods_Prod.PrintCount_Update(SEACC_Form.enmFormName, enum_ReportName.ProdPharma_PGIN, oMR.Mr_No, ref bDuplicateCopy, ref iDuplcateCopyCount);
                                if (bDuplicateCopy)
                                    sDuplicateCopy = "Duplicate Copy " + iDuplcateCopyCount;

                                if (oMR.IsCanceled)
                                {
                                    sCanceled = "CANCELLED";
                                    sDuplicateCopy = "";
                                }

                                foreach (var vPGIN in tbl_prod_pharmaTxGoodIssueNote.SelectAllByMr_No(oMR.Mr_No))
                                {
                                    if (sPGIN_ID == "")
                                        sPGIN_ID += vPGIN.PGIN_No;
                                    else
                                        sPGIN_ID += ", " + vPGIN.PGIN_No;
                                }


                                glb_dtsMR.dt_MeterialRequisition.Adddt_MeterialRequisitionRow(
                                    oMR.Mr_No,
                                    oMR.Mr_Date.ToString(cls_Formater.Format_Date),
                                    oMR.Section_ID, clsGenaralName.getName_Section(oMR.Section_ID),
                                    oMR.PlanDate_from, oMR.PlanDate_to, oMR.Remarks,
                                    sDraft, sDuplicateCopy, sCanceled,
                                    clsGenaralName.getName_User(oMR.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oMR.DateCreate),
                                    clsGenaralName.getName_User(oMR.CheckedUser_ID), clsHelpMethods_Prod.Format_DateTime(oMR.DateChecked),
                                    clsGenaralName.getName_User(oMR.ApprovedUser_ID), clsHelpMethods_Prod.Format_DateTime(oMR.DateApproved),
                                    sPGIN_ID
                                    );

                                foreach (tbl_prod_pharmaTxMaterialRequision_JobCard oJobCard in tbl_prod_pharmaTxMaterialRequision_JobCard.SelectAllByMr_No(oMR.Mr_No))
                                {
                                    foreach (tbl_prod_pharmaTxMaterialRequision_Material oMaterials in tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByProdBatch_ID(oJobCard.ProdBatch_ID).Where(p => p.Mr_No == oMR.Mr_No))
                                    {
                                        tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(oMaterials.ProdJob_ID);
                                        if (oProdJob != null)
                                        {
                                            glb_dtsMR.dt_MeterialRequisition_Detail.Adddt_MeterialRequisition_DetailRow(
                                                oMR.Mr_No, oJobCard.ProdBatch_ID, oJobCard.ProdJob_ID,
                                                oProdJob.Item_ID_FG, clsGenaralName.getName_Item(oProdJob.Item_ID_FG), oJobCard.Mr_FGQty,
                                                oMaterials.Item_ID, clsGenaralName.getDescription_Item(oMaterials.Item_ID), clsGenaralName.getName_Item(oMaterials.Item_ID),
                                                oMaterials.Uom_ID, clsGenaralName.getName_Uom(oMaterials.Uom_ID),
                                                oMaterials.Mr_Qty, oMaterials.Issued_Qty, oMaterials.Bom_Qty, oMaterials.Required_Date,
                                                oMaterials.Instructions);
                                        }
                                    }
                                }

                                #region Company Details Fill
                                glb_dtsMR.dt_company.Adddt_companyRow(
                                    clsSecurity.DigiteqName,
                                    clsSecurity.DigiteqEmail,
                                    clsSecurity.CompanyName,
                                    clsSecurity.CompanyAddress1,
                                    clsSecurity.CompanyAddress2,
                                    clsCommon.getCompanyImage(),
                                    oNotePrint.DisplayName, oNotePrint.DisplayName2, "",
                                    clsSecurity.UserNameLoged, "",
                                    clsCommon.getCompanyEmail(), clsCommon.getCompanyWeb(), clsCommon.getCompanyBusinessRegisterNo());
                                #endregion

                                frm_ReportViewer rpt = new frm_ReportViewer();
                                rpt.print(oNotePrint.ReportPath, glb_dtsMR, glb_dtsReportExport.dt_rptParameter, oUserPermission);
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
                    if (txtMRNo.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oMR.IsApproved = true;
                                            oMR.DateApproved = clsSecurity.getServerDateTime();
                                            oMR.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oMR.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oMR.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected MR has already been approved", MessageBoxButton.OK, "Red");
                                }
                                ClearFields();
                                RefreshGrid();
                                FillDetails(oMR.Mr_No);
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

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtMRNo.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved)
                                {
                                    if (!oMR.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oMR.IsCanceled = true;
                                                oMR.DateCanceled = clsSecurity.getServerDateTime();
                                                oMR.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oMR.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oMR.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        RefreshGrid();
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
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtMRNo, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtMRNo.Tag = null;
            txtSection.Tag = null;

            txtMRNo.Text = "";
            txtSection.Text = "";
            txtRemarks.Text = "";

            dtpMR_Date.SetTime(clsSecurity.getServerDateTime());
            dtpProdPlan_Date_From.SetTime(clsSecurity.getServerDateTime());
            dtpProdPlan_Date_To.SetTime(clsSecurity.getServerDateTime());

            dtBoM.Clear();
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;

            dtMeterials.Clear();
            dgr_Meterials.ItemsSource = dtMeterials.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            chk_selectAll.IsChecked = false;
            chk_selectAll.IsEnabled = false;

            txtSection.IsEnabled = true;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtMRNo.setReadOnlyStatus(true);
                txtMRNo.Text = "<Auto Generate>";
            }
            else
                txtMRNo.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                DataTable dt_Unsettled_MRs = DBHandling.ExecQuery("Exec Get_Unsettled_MRs").Tables[0];

                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_pharmaTxMaterialRequision oMR in tbl_prod_pharmaTxMaterialRequision.SelectAll().Where(p => p.Mr_No != "default").OrderByDescending(o => o.DateCreate))
                {
                    bool bUnsettled_MR = false;
                    var Dr = dt_Unsettled_MRs.Select("mr_No = '" + oMR.Mr_No + "'");
                    if (Dr != null && Dr.Count() > 0)
                    {
                        bUnsettled_MR = true;
                    }

                    dgr_Main.dt.Rows.Add(++iCount, oMR.Mr_No, oMR.Mr_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Section(oMR.Section_ID), oMR.PlanDate_from.ToString(clsValidation.Format_Date), clsGenaralName.getName_User(oMR.CreateUser_ID), clsGenaralName.getName_User(oMR.ApprovedUser_ID), oMR.IsCanceled , bUnsettled_MR);
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
            {
                if (CheckPlannedQtyWithMRQty())
                {
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (clsValidate.CheckValidity_TransactionCodeLength(txtMRNo.Text))
                        {
                            bStatus = true;
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtMRNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSection))
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
                    txtMRNo.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtMRNo.Text = txtMRNo.Tag.ToString();
                }

                tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Text);
                if (oMR != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckPlannedQtyWithMRQty()
        {
            bool bReturn = true;
            string sMessage = "";
            foreach (DataRow dr in dtMeterials.Rows)
            {
                string sItemNo = clsValidate.ValidateRowValue(dr, "ItemNo", "default");
                decimal dPlannedQty = clsValidate.ValidateRowValue(dr, "PlannedQty", 0m);
                decimal dIssuedQty = clsValidate.ValidateRowValue(dr, "IssuedQty", 0m);
                decimal dMRQty = clsValidate.ValidateRowValue(dr, "MRQty", 0m);

                if (dPlannedQty < (dMRQty + dIssuedQty))
                {
                    sMessage += "Material ID :" + sItemNo + ", Material Name :" + clsGenaralName.getName_Item(sItemNo) + "\n";
                }
            }

            if (sMessage.Length > 3)
            {
                bReturn = SEACCMessageBox.Show("Planned Quantity Exceeded!!!",
                    "MR Qty. of Following Materials have been exceeded more than planned Qty. \n" + sMessage + "\nAre you sure to continue?",
                    MessageBoxButton.YesNo, "#FF5B6B76");
            }

            return bReturn;
        }
        #endregion

        #region Fill Details

        private void FillDetails(string sID)
        {
            try
            {
                tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(sID);
                if (oMR != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtMRNo.Tag = oMR.Mr_No;
                    txtSection.Tag = oMR.Section_ID;

                    txtMRNo.Text = oMR.Mr_No;
                    txtSection.Text = clsGenaralName.getName_Section(oMR.Section_ID);
                    txtRemarks.Text = oMR.Remarks;
                    dtpMR_Date.SetTime(oMR.Mr_Date);
                    dtpProdPlan_Date_From.SetTime(oMR.PlanDate_from);
                    dtpProdPlan_Date_To.SetTime(oMR.PlanDate_to);

                    txtSection.IsEnabled = false;

                    dtBoM.Rows.Clear();
                    foreach (tbl_prod_pharmaTxMaterialRequision_JobCard oDetail in tbl_prod_pharmaTxMaterialRequision_JobCard.SelectAllByMr_No(sID))
                    {
                        tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(oDetail.ProdJob_ID);
                        tbl_prod_pharmaTxBatch oProdBatch = tbl_prod_pharmaTxBatch.Select(oDetail.ProdBatch_ID);
                        dtBoM.Rows.Add("0", true, oProdJob.ProdJob_ID, oDetail.ProdBatch_ID, oProdJob.Item_ID_FG,
                            clsGenaralName.getName_Item(oProdJob.Item_ID_FG),
                            clsGenaralName.getName_Uom(oProdJob.Uom_ID),
                            cls_Formater.FormatDecimal(oProdBatch.BatchQty * oProdJob.FGoodQty, 0),
                            clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oProdBatch.CustomerOrder_ID)),
                            cls_Formater.FormatDecimal(oProdBatch.CustomerOrder_Qty, 0),
                            oDetail.CustomerOrder_ID == "default" ? "-" : oDetail.CustomerOrder_ID,
                            cls_Formater.FormatDecimal(oDetail.Mr_FGQty, 0));
                    }

                    dtMeterials.Rows.Clear();
                    foreach (tbl_prod_pharmaTxMaterialRequision_Material oMR_Meterials in tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByMr_No(oMR.Mr_No))
                    {
                        var row = dtBoM.Select("BoM_No = '" + oMR_Meterials.ProdJob_ID + "' AND Batch_No = '" + oMR_Meterials.ProdBatch_ID + "'").FirstOrDefault();
                        if (row != null)
                            row["IsSelect"] = "\uE0A2";

                        dtMeterials.Rows.Add(oMR_Meterials.Line_No, oMR_Meterials.ProdJob_ID,
                            oMR_Meterials.Line_No_JobWise, oMR_Meterials.ProdBatch_ID,
                            oMR_Meterials.Item_ID, clsGenaralName.getName_Item(oMR_Meterials.Item_ID),
                            oMR_Meterials.Uom_ID, clsGenaralName.getName_Uom(oMR_Meterials.Uom_ID),
                            cls_Formater.FormatDecimal(oMR_Meterials.Bom_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Balance_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Mr_Qty, clsConfig.sDecimalPlaces_Quantity),
                            oMR_Meterials.Required_Date.ToString(clsValidation.Format_Date),
                            oMR_Meterials.Instructions,
                            oMR_Meterials.Store_ID,
                            clsGenaralName.getName_Store(oMR_Meterials.Store_ID),
                            cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oMR_Meterials.ProdJob_ID, oMR_Meterials.ProdBatch_ID, oMR_Meterials.Item_ID, oMR.DateCreate), clsConfig.sDecimalPlaces_Quantity)
                            );
                    }

                    if (oMR.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oMR.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_BOM_Grid(string sProdSection_ID)
        {
            dtBoM.Clear();
            foreach (tbl_prod_pharmaTxJobCard oJob in tbl_prod_pharmaTxJobCard.SelectAll().Where(r => !r.IsCanceled && r.IsLocked && r.IsApproved3 && r.ProdJob_ID != "default" &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Cancelled &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Closed &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Suspended &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Obsolete).OrderByDescending(o => o.DateCreate))
            {

                if (tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oJob.ProdJob_ID).Count(r => r.Section_ID == sProdSection_ID) < 1)
                    continue;

                foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.IsApproved && !r.IsCanceled).OrderByDescending(o => o.DateCreate))
                {
                    if (oBatch.BatchStatus == (int)prod_Batch_Status.Open)
                    {
                        dtBoM.Rows.Add("0", "\uE003",
                            oJob.ProdJob_ID, oBatch.ProdBatch_ID, oJob.Item_ID_FG,
                            clsGenaralName.getName_Item(oJob.Item_ID_FG), clsGenaralName.getName_Uom(oJob.Uom_ID),
                            cls_Formater.FormatDecimal(oBatch.BatchQty * oJob.FGoodQty, 0),
                            clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID)),
                            cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, 0),
                            oBatch.CustomerOrder_ID == "default" ? "-" : oBatch.CustomerOrder_ID,
                            cls_Formater.FormatDecimal(oBatch.BatchQty * oJob.FGoodQty, 0)
                        );
                    }
                }
            }
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
        }

        private void Fill_MeterialGrid_ForSelectedBoMs()
        {
            try
            {
                Cursor = Cursors.Wait;
                dtMeterials.Rows.Clear();
                var vSelectedBoMs = dtBoM.Select("IsSelect = '\uE0A2'");

                //Selected Raw Materials for Whole Section Tracking
                DataTable dtSelectedRowMaerials = new DataTable();
                dtSelectedRowMaerials.Columns.Add("ItemNo");
                dtSelectedRowMaerials.Columns.Add("PlannedQty");
                dtSelectedRowMaerials.Columns.Add("IssuedQty");
                dtSelectedRowMaerials.Columns.Add("MRQty");

                string sMainStore_ID = "default";
                string sMainStore_Name = "<Select a Store>";
                tbl_genStoreMaster oMainStore = tbl_genStoreMaster.SelectAllByCompanyID(clsSecurity.CompanyID).FirstOrDefault(r => r.IsMainStore);
                if (oMainStore != null)
                {
                    sMainStore_ID = oMainStore.Store_ID;
                    sMainStore_Name = oMainStore.StoreName;
                }

                foreach (DataRow rowBoM in vSelectedBoMs)
                {
                    int iBoM_Wise_Count = 0;
                    string sBoM_No = rowBoM["BoM_No"].ToString();
                    string sBatch_No = rowBoM["Batch_No"].ToString();

                    decimal dMR_FG_Qty = clsValidation.Validate_DecimalNumber(rowBoM["MRQty"].ToString());
                    decimal dJob_FG_Qty = clsValidation.Validate_DecimalNumber(rowBoM["FG_Qty"].ToString());

                    tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(sBoM_No);
                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(sBatch_No);

                    decimal dQty_Ratio_ForMRQty = decimal.Round(dMR_FG_Qty / oBoM.FGoodQty, clsConfig.sDecimalPlaces_Quantity);
                    decimal dQty_Ratio_ForFGQty = decimal.Round(dJob_FG_Qty / oBoM.FGoodQty, clsConfig.sDecimalPlaces_Quantity);

                    //Iterate Selected Bathch Materials
                    foreach (var oBoM_Meterial in tbl_prod_pharmaTxBatch_Material.SelectAllByProdBatch_ID(sBatch_No)
                        .Where(r => r.IsSelected && !r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                    {
                        decimal dAlreadyIssued_PGINQty = 0m;
                        decimal dPrevious_MR_Qty = 0;

                        if (!SEACC_Form.IsUpdateMode)
                        {
                            dAlreadyIssued_PGINQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oBoM.ProdJob_ID, oBatch.ProdBatch_ID, oBoM_Meterial.Item_ID);
                            dPrevious_MR_Qty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(sBoM_No, sBatch_No, oBoM_Meterial.Item_ID, txtSection.Tag.ToString());
                        }
                        else
                        {
                            tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                                dAlreadyIssued_PGINQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oBoM.ProdJob_ID, oBatch.ProdBatch_ID, oBoM_Meterial.Item_ID, oMR.DateCreate);

                            dPrevious_MR_Qty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(sBoM_No, sBatch_No, txtMRNo.Text.Trim(), oBoM_Meterial.Item_ID, txtSection.Tag.ToString());
                        }
                        decimal dBalance_Qty = (oBoM_Meterial.TotalInputQty * dQty_Ratio_ForFGQty) - dPrevious_MR_Qty;

                        dtMeterials.Rows.Add("0", oBoM_Meterial.ProdJob_ID, ++iBoM_Wise_Count, sBatch_No, oBoM_Meterial.Item_ID, clsGenaralName.getName_Item(oBoM_Meterial.Item_ID), oBoM_Meterial.Uom_ID, clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * oBatch.BatchQty, clsConfig.sDecimalPlaces_Quantity), //BoM Qty (Planed Qty)
                            cls_Formater.FormatDecimal(dPrevious_MR_Qty, clsConfig.sDecimalPlaces_Quantity),        //Previous MR Qty
                            cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //Balance Qty
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dQty_Ratio_ForMRQty, clsConfig.sDecimalPlaces_Quantity), //MR Qty
                            clsSecurity.getServerDateTime().ToString(clsValidation.Format_Date), "",
                            sMainStore_ID, sMainStore_Name, cls_Formater.FormatDecimal(dAlreadyIssued_PGINQty, clsConfig.sDecimalPlaces_Quantity)
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
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
                //Settled MR
                if (!(Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[8].ToString())))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#a0ffa0");
                }
                //Cancelled MR
                else if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[7].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
                else
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region BOM Grid
        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        private void dgr_BoMs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            switch (sColumnName)
            {
                case "MRQty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;

                    object item = dgr_BoMs.SelectedItem;
                    if (item != null)
                    {
                        try
                        {
                            if (t != null) dQty = decimal.Parse(t.Text);
                        }
                        catch
                        {
                            SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                        }
                    }
                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, 0);

                    Fill_MeterialGrid_ForSelectedBoMs();
                    break;
            }
        }

        private void dgr_BoMs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_BoMs.SelectedIndex;
            var vDG_Cell = dgr_BoMs.CurrentCell;
            try
            {
                switch (vDG_Cell.Column.SortMemberPath)
                {
                    case "IsSelect":
                        bool bIsChecked;
                        bIsChecked = dtBoM.Rows[irowID]["IsSelect"].ToString() == "\uE0A2";
                        dtBoM.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";

                        Fill_MeterialGrid_ForSelectedBoMs();

                        if (dtBoM.Select("IsSelect = '\uE10A' ").Any())
                            chk_selectAll.IsChecked = false;
                        break;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region Meterial Grid
        private void dgr_Meterials_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;

            if (sColumnName == "MRQty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;

                object item = dgr_Meterials.SelectedItem;
                if (item != null)
                {
                    try
                    {
                        dQty = decimal.Parse(t.Text);

                        string sItem_ID = (dgr_Meterials.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                        string sItem_Name = (dgr_Meterials.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                        string sBalanceQty = (dgr_Meterials.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                        decimal dBalanceQty = clsValidation.Validate_DecimalNumber(sBalanceQty);

                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                        if (oItem != null && oItem.IsAccessories)
                        {
                            if (dBalanceQty < dQty)
                            {
                                SEACCMessageBox.Show("Oops..!", sItem_Name + " is an accessory. It can not be exceeded Balance Quantity", MessageBoxButton.OK, "Red");
                                dQty = dBalanceQty;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }

            if (sColumnName == "ReqdDate")
            {
                t = e.EditingElement as TextBox;
                DateTime dtmTime = clsSecurity.getServerDateTime();
                try
                {
                    dtmTime = DateTime.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter valid date", MessageBoxButton.OK);
                }
                t.Text = dtmTime.ToString(clsValidation.Format_Date);
            }
        }

        private void dgr_Meterials_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }

        private void dgr_Meterials_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Meterials.SelectedIndex;
            var vDG_Cell = dgr_Meterials.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "StroreName")
                {
                    frm_search RowDataSearch = new frm_search();
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtMeterials.Rows[irowID]["StoreID"] = lstResult[0];
                        dtMeterials.Rows[irowID]["StroreName"] = lstResult[1];
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #endregion

        #region Search Events
        private void txtMRNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMeterialRequisition);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails(lstResult[0]);
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Tag = lstResult[0];
                txtSection.Text = lstResult[1];

                dtMeterials.Rows.Clear();
                Fill_BOM_Grid(lstResult[0]);
                chk_selectAll.IsEnabled = true;
            }
        }
        #endregion

        #region Check Box Events
        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
            Fill_MeterialGrid_ForSelectedBoMs();
        }

        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
            Fill_MeterialGrid_ForSelectedBoMs();
        }
        #endregion

        #region Other Text Box Events
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


        #endregion

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
