using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEACC_PRODUCTION_POLY.Transactions
{
    /// <summary>
    /// Developed By Gayan
    /// 2017-05-22
    /// </summary>
    public partial class UC_MeterialRequisition : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_MeterialRequisition()
        {
            #region Usercontrol Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Prod_MeterialRequisition;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region BoM Table Initialize
            dtBoM.Columns.Add("LineNo", typeof(int));
            dtBoM.Columns.Add("IsSelect", typeof(bool));
            dtBoM.Columns.Add("BoM_No");
            dtBoM.Columns.Add("FG_Item");
            dtBoM.Columns.Add("FG_UoM");
            dtBoM.Columns.Add("FG_UoM_weight");
            dtBoM.Columns.Add("FG_Qty");
            dtBoM.Columns.Add("Customer");
            dtBoM.Columns.Add("COQty");
            dtBoM.Columns.Add("COWeight");
            dtBoM.Columns.Add("CO_ID");
            #endregion

            #region Meterial Table Initialize
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("BoM_Line_No");
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("UoM_ID_Weight");
            dtMeterials.Columns.Add("UoM_Weight");
            dtMeterials.Columns.Add("PlannedQty");
            dtMeterials.Columns.Add("IssuedQty");
            dtMeterials.Columns.Add("BalanceQty");
            dtMeterials.Columns.Add("MRQty");
            dtMeterials.Columns.Add("PlannedQty_Weight");
            dtMeterials.Columns.Add("IssuedQty_Weight");
            dtMeterials.Columns.Add("BalanceQty_Weight");
            dtMeterials.Columns.Add("MRQty_Weight");
            dtMeterials.Columns.Add("ReqdDate");
            dtMeterials.Columns.Add("Instructions");
            dtMeterials.Columns.Add("COQty");
            dtMeterials.Columns.Add("COWeight");
            dtMeterials.Columns.Add("StoreID");
            dtMeterials.Columns.Add("StroreName");
            #endregion

            #region Main Table Initialize
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("MR_NO");
            dgr_Main.dt.Columns.Add("MR_DATE");
            dgr_Main.dt.Columns.Add("SECTION");
            dgr_Main.dt.Columns.Add("PLAN_DATE_FROM");
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
            dgr_Main.Add_DatagridColoumn("MR NO", "MR_NO", 80);
            dgr_Main.Add_DatagridColoumn("MR DATE", "MR_DATE", 80);
            dgr_Main.Add_DatagridColoumn("SECTION", "SECTION", 150);
            dgr_Main.Add_DatagridColoumn("PLAN DATE", "PLAN_DATE_FROM", 80);
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
                            tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved && !oMR.IsCanceled)
                                {

                                    tbl_prod_polyTxMaterialRequision oOldMR = new tbl_prod_polyTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), oMR.IsChecked, oMR.IsApproved, oMR.IsCanceled, oMR.CreateUser_ID, clsSecurity.UserIDLoged, oMR.CheckedUser_ID, oMR.ApprovedUser_ID, oMR.CanceldUser_ID, oMR.DateCreate, clsSecurity.getServerDateTime(), oMR.DateChecked, oMR.DateApproved, oMR.DateCanceled, oMR.CreateUserTerminal_ID, clsSecurity.TerminalID, oMR.CheckedUserTerminal_ID, oMR.ApprovedUserTerminal_ID, oMR.CanceledUserTerminal_ID, oMR.CompanyID, oMR.CompanyBranchID);
                                    oOldMR.Update();

                                    tbl_prod_polyTxMaterialRequision_JobCard.DeleteAllByMr_No(oMR.Mr_No);
                                    tbl_prod_polyTxMaterialRequision_Material.DeleteAllByMr_No(oMR.Mr_No);

                                    foreach (DataRow row in dtBoM.Rows)
                                    {
                                        bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                        if (bSelect)
                                        {
                                            string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                            string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                            decimal dCO_Qty = clsValidate.ValidateRowValue(row, "COQty", 1);
                                            decimal dCO_Weight = clsValidate.ValidateRowValue(row, "COWeight", 0);

                                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sBoM_No);

                                            tbl_prod_polyTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prod_polyTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, (sCO_ID == "-" ? "default" : sCO_ID), (oJob != null ? oJob.Uom_ID : "default"), (oJob != null ? oJob.Item_Weight_UoM_ID : "default"), dCO_Qty, dCO_Weight);
                                            oNewMR_JobCard.Insert();
                                        }
                                    }

                                    foreach (DataRow row in dtMeterials.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                        int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0));
                                        string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        string sUoM_ID_Weight = clsValidate.ValidateRowValue(row, "UoM_ID_Weight", "default");
                                        decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0);
                                        decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0);
                                        decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0);
                                        decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0);
                                        decimal dPlannedWeight = clsValidate.ValidateRowValue(row, "PlannedQty_Weight", 0);
                                        decimal dIssuedWeight = clsValidate.ValidateRowValue(row, "IssuedQty_Weight", 0);
                                        decimal dBalanceWeight = clsValidate.ValidateRowValue(row, "BalanceQty_Weight", 0);
                                        decimal dMRWeight = clsValidate.ValidateRowValue(row, "MRQty_Weight", 0);
                                        DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                        string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                        string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                        tbl_prod_polyTxMaterialRequision_Material oProdMR_Materials = new tbl_prod_polyTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sItemNo, sUoM_ID, sUoM_ID_Weight,
                                            dPlannedQty, dIssuedQty, dBalanceQty, dMRQty,
                                            dPlannedWeight, dIssuedWeight,dBalanceWeight, dMRWeight, 
                                            dtmReqdDate, sInstructions, sStoreID);
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
                            tbl_prod_polyTxMaterialRequision oNewProdMR = new tbl_prod_polyTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                            oNewProdMR.Insert();

                            foreach (DataRow row in dtBoM.Rows)
                            {
                                bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                if (!bSelect)
                                    continue;

                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                decimal dCO_Qty = clsValidate.ValidateRowValue(row, "COQty", 1);
                                decimal dCO_Weight = clsValidate.ValidateRowValue(row, "COWeight", 0);

                                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sBoM_No);
                                tbl_prod_polyTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prod_polyTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, (sCO_ID == "-" ? "default" : sCO_ID), (oJob != null ? oJob.Uom_ID : "default"), (oJob != null ? oJob.Item_Weight_UoM_ID : "default"), dCO_Qty, dCO_Weight);
                                oNewMR_JobCard.Insert();
                            }

                            foreach (DataRow row in dtMeterials.Rows)
                            {
                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0));
                                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                string sUoM_ID_Weight = clsValidate.ValidateRowValue(row, "UoM_ID_Weight", "default");
                                decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0);
                                decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0);
                                decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0);
                                decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0);
                                decimal dPlannedWeight = clsValidate.ValidateRowValue(row, "PlannedQty_Weight", 0);
                                decimal dIssuedWeight = clsValidate.ValidateRowValue(row, "IssuedQty_Weight", 0);
                                decimal dBalanceWeight = clsValidate.ValidateRowValue(row, "BalanceQty_Weight", 0);
                                decimal dMRWeight = clsValidate.ValidateRowValue(row, "MRQty_Weight", 0);
                                DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                tbl_prod_polyTxMaterialRequision_Material oNewProdMR_Materials = new tbl_prod_polyTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sItemNo, 
                                    sUoM_ID, sUoM_ID_Weight,
                                    dPlannedQty, dIssuedQty, dBalanceQty, dMRQty,
                                    dPlannedWeight, dIssuedWeight, dBalanceWeight, dMRWeight,
                                    dtmReqdDate, sInstructions, sStoreID);
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
                    fillDetails(sMR_ID);
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
                        //Not Implemented
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
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMRNo.Tag.ToString());
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
                                fillDetails(oMR.Mr_No);
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
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMRNo.Tag.ToString());
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

            txtMRNo.Tag = null;
            txtSection.Tag = null;

            txtMRNo.Text = "";
            txtSection.Text = "";

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
                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_polyTxMaterialRequision oMR in tbl_prod_polyTxMaterialRequision.SelectAll().Where(p => p.Mr_No != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oMR.Mr_No, oMR.Mr_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Section(oMR.Section_ID), oMR.PlanDate_from.ToString(clsValidation.Format_Date), clsGenaralName.getName_User(oMR.CreateUser_ID), clsGenaralName.getName_User(oMR.ApprovedUser_ID), oMR.IsCanceled);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Refresh_BOM_Grid(string sProdSection_ID)
        {
            dtBoM.Clear();
            foreach (tbl_prod_polyTxJobCard oJob in tbl_prod_polyTxJobCard.SelectAll().Where(r => !r.IsCanceled && r.IsLocked && r.IsApproved3 && r.ProdJob_ID != "default" &&
                                                                                        r.ProdJobStatus != (int)prod_JobStatus.Cancelled &&
                                                                                        r.ProdJobStatus != (int)prod_JobStatus.Closed &&
                                                                                        r.ProdJobStatus != (int)prod_JobStatus.Obsolete).OrderByDescending(o => o.DateCreate))
            {

                if (tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.Section_ID == sProdSection_ID).Count() < 1)
                    continue;


                decimal dCusOrderQty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(oJob.ProdJob_ID);
                decimal dCusOrderWeight = (oJob.FGoodWeight / (oJob.FGoodQty != 0 ? oJob.FGoodQty : 1)) * dCusOrderQty;

                dtBoM.Rows.Add("0", false, oJob.ProdJob_ID,
                    clsGenaralName.getDescription_Item(oJob.Item_ID_FG),
                    clsGenaralName.getName_Uom(oJob.Uom_ID),
                    clsGenaralName.getName_Uom(oJob.Item_Weight_UoM_ID),
                    cls_Formater.FormatDecimal(oJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity),
                    clsGenaralName.getName_Customer(oJob.Customer_ID),
                    cls_Formater.FormatDecimal(dCusOrderQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dCusOrderWeight, clsConfig.sDecimalPlaces_Weight),
                    oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID);
            }

            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    bStatus = true;
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

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtMRNo.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtMRNo.Text = txtMRNo.Tag.ToString();
                }

                tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMRNo.Text);
                if (oMR != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details

        private void fillDetails(string sID)
        {
            try
            {
                tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(sID);
                if (oMR != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtMRNo.Tag = oMR.Mr_No;
                    txtSection.Tag = oMR.Section_ID;

                    txtMRNo.Text = oMR.Mr_No;
                    txtSection.Text = clsGenaralName.getName_Section(oMR.Section_ID);
                    dtpMR_Date.SetTime(oMR.Mr_Date);
                    dtpProdPlan_Date_From.SetTime(oMR.PlanDate_from);
                    dtpProdPlan_Date_To.SetTime(oMR.PlanDate_to);

                    txtSection.IsEnabled = false;

                    dtBoM.Rows.Clear();
                    foreach (tbl_prod_polyTxMaterialRequision_JobCard oDetail in tbl_prod_polyTxMaterialRequision_JobCard.SelectAllByMr_No(sID))
                    {
                        tbl_prod_polyTxJobCard oProdJob = tbl_prod_polyTxJobCard.Select(oDetail.ProdJob_ID);
                        dtBoM.Rows.Add("0",
                            true, oProdJob.ProdJob_ID,
                            clsGenaralName.getDescription_Item(oProdJob.Item_ID_FG),
                            clsGenaralName.getName_Uom(oDetail.Uom_ID),
                            clsGenaralName.getName_Uom(oDetail.Uom_ID_Weight),
                            cls_Formater.FormatDecimal(oProdJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity),
                            clsGenaralName.getName_Customer(oProdJob.Customer_ID),
                            cls_Formater.FormatDecimal(oDetail.FinishGood_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oDetail.FinishGood_Weight, clsConfig.sDecimalPlaces_Quantity),
                            oDetail.CustomerOrder_ID == "default" ? "-" : oDetail.CustomerOrder_ID);
                    }


                    dtMeterials.Rows.Clear();
                    foreach (tbl_prod_polyTxMaterialRequision_Material oMR_Meterials in tbl_prod_polyTxMaterialRequision_Material.SelectAllByMr_No(oMR.Mr_No))
                    {
                        var row = dtBoM.Select("BoM_No = '" + oMR_Meterials.ProdJob_ID + "'").FirstOrDefault();
                        if (row != null)
                            row["IsSelect"] = true;

                        //decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(oMR_Meterials.ProdJob_ID);
                        decimal dSO_Qty = clsValidation.Validate_DecimalNumber(row["COQty"].ToString());
                        decimal dSO_Weight = clsValidation.Validate_DecimalNumber(row["COWeight"].ToString());

                        dtMeterials.Rows.Add(oMR_Meterials.Line_No, oMR_Meterials.ProdJob_ID, oMR_Meterials.Line_No_JobWise, oMR_Meterials.Item_ID, clsGenaralName.getName_Item(oMR_Meterials.Item_ID),
                            oMR_Meterials.Uom_ID, clsGenaralName.getName_Uom(oMR_Meterials.Uom_ID),
                            oMR_Meterials.Uom_ID_Weight, clsGenaralName.getName_Uom(oMR_Meterials.Uom_ID_Weight),
                           cls_Formater.FormatDecimal(oMR_Meterials.Bom_Qty, clsConfig.sDecimalPlaces_Quantity), cls_Formater.FormatDecimal(oMR_Meterials.Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                           cls_Formater.FormatDecimal(oMR_Meterials.Balance_Qty, clsConfig.sDecimalPlaces_Quantity), cls_Formater.FormatDecimal(oMR_Meterials.Mr_Qty, clsConfig.sDecimalPlaces_Quantity),
                           cls_Formater.FormatDecimal(oMR_Meterials.Bom_Weight, clsConfig.sDecimalPlaces_Weight), cls_Formater.FormatDecimal(oMR_Meterials.Issued_Weight, clsConfig.sDecimalPlaces_Weight),
                           cls_Formater.FormatDecimal(oMR_Meterials.Balance_Weight, clsConfig.sDecimalPlaces_Weight), cls_Formater.FormatDecimal(oMR_Meterials.Mr_Weight, clsConfig.sDecimalPlaces_Weight),
                           oMR_Meterials.Required_Date.ToString(clsValidation.Format_Date), oMR_Meterials.Instructions,
                           cls_Formater.FormatDecimal(oMR_Meterials.Bom_Qty * dSO_Qty, clsConfig.sDecimalPlaces_Quantity),
                           cls_Formater.FormatDecimal(oMR_Meterials.Bom_Weight * dSO_Weight, clsConfig.sDecimalPlaces_Weight),
                           oMR_Meterials.Store_ID, clsGenaralName.getName_Store(oMR_Meterials.Store_ID));
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

        private void Fill_MeterialGrid_ForSelectedBoMs()
        {
            try
            {
                Cursor = Cursors.Wait;
                dtMeterials.Rows.Clear();
                var vSelectedBoMs = dtBoM.Select("IsSelect = True");

                string sMainStore_ID = "default";
                string sMainStore_Name = "<Select a Store>";
                tbl_genStoreMaster oMainStore = tbl_genStoreMaster.SelectAllByCompanyID(clsSecurity.CompanyID).Where(r => r.IsMainStore).FirstOrDefault();
                if (oMainStore != null)
                {
                    sMainStore_ID = oMainStore.Store_ID;
                    sMainStore_Name = oMainStore.StoreName;
                }

                foreach (DataRow rowBoM in vSelectedBoMs)
                {
                    int iBoM_Wise_Count = 0;
                    string sBoM_No = rowBoM["BoM_No"].ToString();
                    decimal dSO_Qty = clsValidation.Validate_DecimalNumber(rowBoM["COQty"].ToString());
                    decimal dSO_Weight = clsValidation.Validate_DecimalNumber(rowBoM["COWeight"].ToString());
                    //decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(sBoM_No);
                    foreach (tbl_prod_polyTxJobCard_Material oBoM_Meterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => !r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                    {
                        decimal dPrevious_Issued_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(sBoM_No, oBoM_Meterial.Item_ID);
                        decimal dBalance_Qty = oBoM_Meterial.TotalInputQty - dPrevious_Issued_Qty;

                        decimal dPrevious_Issued_Weight = clsHelpMethods_Prod.AlreadyIssuedWeight_formMRs(sBoM_No, oBoM_Meterial.Item_ID);
                        decimal dBalance_Weight = (oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100) - dPrevious_Issued_Weight;

                        dtMeterials.Rows.Add("0", oBoM_Meterial.ProdJob_ID, ++iBoM_Wise_Count, oBoM_Meterial.Item_ID, clsGenaralName.getName_Item(oBoM_Meterial.Item_ID), oBoM_Meterial.Uom_ID,
                            clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                            oBoM_Meterial.Uom_ID_Weight , clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID_Weight),
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //BoM Qty
                            cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),        //Issued Qty
                            cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //Balance Qty
                            cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //MR Qty
                            cls_Formater.FormatDecimal((oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100), clsConfig.sDecimalPlaces_Weight), //BoM Weight
                            cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Weight),        //Issued Weight
                            cls_Formater.FormatDecimal(dBalance_Weight < 0 ? 0 : dBalance_Weight, clsConfig.sDecimalPlaces_Weight), //Balance Weight
                            cls_Formater.FormatDecimal(dBalance_Weight < 0 ? 0 : dBalance_Weight, clsConfig.sDecimalPlaces_Weight), //MR Weight
                            clsSecurity.getServerDateTime().ToString(clsValidation.Format_Date), "",
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dSO_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal((oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100) * dSO_Weight, clsConfig.sDecimalPlaces_Weight),
                            sMainStore_ID, sMainStore_Name); //CO&SO Qty
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
                    fillDetails(GridID);
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

        #region BOM Grid
        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        private void dgr_BoMs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnName == "COQty" || sColumnName == "COWeight" )
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;

                object item = dgr_BoMs.SelectedItem;
                if (item != null)
                {
                    try
                    {
                        string sBoM_ID = (dgr_BoMs.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                        if (clsHelpMethods_Prod.IsProdJobBoM_MakeToSupply(sBoM_ID))
                        {
                            dQty = decimal.Parse(t.Text);
                        }
                        else
                        {
                            dQty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(sBoM_ID);
                            SEACCMessageBox.Show("Oops..!", "You can not change the SO quantity", MessageBoxButton.OK, "Red");
                        }
                    }
                    catch
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                Fill_MeterialGrid_ForSelectedBoMs();
            }

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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMeterialRequisition);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Tag = lstResult[0];
                txtSection.Text = lstResult[1];

                dtMeterials.Rows.Clear();
                Refresh_BOM_Grid(lstResult[0]);
                chk_selectAll.IsEnabled = true;
            }
        }
        #endregion

        #region Check Box Events
        private void BoM_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSection.Tag != null && txtSection.Tag.ToString() != "default")
                {

                    DataRowView dataRow = (DataRowView)dgr_BoMs.SelectedItem;
                    if (dataRow != null)
                    {
                        int BoM_Line_No = 0;
                        int iBoM_columnIndex = 2; //BoM Column
                        int iSOQty_coulnIndex = 8; //SO Qty Column
                        string sBoM_No = dataRow.Row.ItemArray[iBoM_columnIndex].ToString();

                        var rows = dtMeterials.Select("BoM_No = '" + sBoM_No + "'");
                        foreach (var row in rows)
                            row.Delete();

                        string sMainStore_ID = "default";
                        string sMainStore_Name = "<Select a Store>";
                        tbl_genStoreMaster oMainStore = tbl_genStoreMaster.SelectAllByCompanyID(clsSecurity.CompanyID).Where(r => r.IsMainStore).FirstOrDefault();
                        if (oMainStore != null)
                        {
                            sMainStore_ID = oMainStore.Store_ID;
                            sMainStore_Name = oMainStore.StoreName;
                        }

                        decimal dSO_Qty = clsValidation.Validate_DecimalNumber(dataRow.Row.ItemArray[iSOQty_coulnIndex].ToString());
                        decimal dSO_Weight = clsValidation.Validate_DecimalNumber(dataRow.Row.ItemArray[iSOQty_coulnIndex + 1].ToString());

                        //foreach (tbl_prod_polyTxJobCard_Material oBoM_Meterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => !r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                        //{
                        //    decimal dPrevious_Issued_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(sBoM_No, oBoM_Meterial.Item_ID);
                        //    decimal dBalance_Qty = (oBoM_Meterial.TotalInputQty * dSO_Qty) - dPrevious_Issued_Qty;

                        //    dtMeterials.Rows.Add("0", oBoM_Meterial.ProdJob_ID, ++BoM_Line_No, oBoM_Meterial.Item_ID, clsGenaralName.getName_Item(oBoM_Meterial.Item_ID), oBoM_Meterial.Uom_ID,
                        //        clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                        //        cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //BoM Qty
                        //        cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),        //Issued Qty
                        //        cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //Balance Qty
                        //        cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //MR Qty
                        //        clsSecurity.getServerDateTime().ToString(clsValidation.Format_Date), "",
                        //        cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dSO_Qty, clsConfig.sDecimalPlaces_Quantity),
                        //        sMainStore_ID, sMainStore_Name
                        //        );
                        //}
                        foreach (tbl_prod_polyTxJobCard_Material oBoM_Meterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => !r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                        {
                            decimal dPrevious_Issued_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(sBoM_No, oBoM_Meterial.Item_ID);
                            decimal dBalance_Qty = oBoM_Meterial.TotalInputQty - dPrevious_Issued_Qty;

                            decimal dPrevious_Issued_Weight = clsHelpMethods_Prod.AlreadyIssuedWeight_formMRs(sBoM_No, oBoM_Meterial.Item_ID);
                            decimal dBalance_Weight = (oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100) - dPrevious_Issued_Weight;

                            dtMeterials.Rows.Add("0", oBoM_Meterial.ProdJob_ID, ++BoM_Line_No, oBoM_Meterial.Item_ID, clsGenaralName.getName_Item(oBoM_Meterial.Item_ID), oBoM_Meterial.Uom_ID,
                                clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                                oBoM_Meterial.Uom_ID_Weight  , clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID_Weight),
                                cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //BoM Qty
                                cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),        //Issued Qty
                                cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //Balance Qty
                                cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //MR Qty
                                cls_Formater.FormatDecimal((oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100), clsConfig.sDecimalPlaces_Weight), //BoM Weight
                                cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Weight),        //Issued Weight
                                cls_Formater.FormatDecimal(dBalance_Weight < 0 ? 0 : dBalance_Weight, clsConfig.sDecimalPlaces_Weight), //Balance Weight
                                cls_Formater.FormatDecimal(dBalance_Weight < 0 ? 0 : dBalance_Weight, clsConfig.sDecimalPlaces_Weight), //MR Weight
                                clsSecurity.getServerDateTime().ToString(clsValidation.Format_Date), "",
                                cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dSO_Qty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal((oBoM_Meterial.InputWeight * (100 + oBoM_Meterial.WastagePercent) / 100) * dSO_Weight, clsConfig.sDecimalPlaces_Weight),
                                sMainStore_ID, sMainStore_Name); //CO&SO Qty
                        }
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Section not selected...", "Please select a production section", MessageBoxButton.OK, "Red");
                    dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = false);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void BoM_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dgr_BoMs.SelectedItem;
                if (dataRow != null)
                {
                    int index = 2; //BoM Column
                    string sBoM_No = dataRow.Row.ItemArray[index].ToString().Trim();

                    var rows = dtMeterials.Select("BoM_No = '" + sBoM_No + "'");
                    foreach (var row in rows)
                        row.Delete();
                }
                chk_selectAll.IsChecked = false;
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = true);
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

    }
}
