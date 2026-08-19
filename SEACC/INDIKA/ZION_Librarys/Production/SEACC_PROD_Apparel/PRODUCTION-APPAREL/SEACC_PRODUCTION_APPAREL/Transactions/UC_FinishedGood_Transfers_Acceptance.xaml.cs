using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_APPAREL
{
    /// <summary>
    /// Interaction logic for UC_FinishedGood_Transfers_Acceptance.xaml
    /// </summary>
    public partial class UC_FinishedGood_Transfers_Acceptance : UserControl
    {
        #region Class Variables
        BrushConverter bcon = new BrushConverter();
        DataTable dtMeterials = new DataTable();
        private string sBoM_No;
        #endregion

        #region Form Load
        public UC_FinishedGood_Transfers_Acceptance()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_FGTN_Acceptance;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("Acpt_No");
            dgr_Main.dt.Columns.Add("Acpt_Date");
            dgr_Main.dt.Columns.Add("Store");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("PREPARED_DATE");
            dgr_Main.dt.Columns.Add("MODIFIED_BY");
            dgr_Main.dt.Columns.Add("MODIFIED_DATE");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_DATE");
            dgr_Main.dt.Columns.Add("Is_Cancelled");

            #region Meterial Table Initialize
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("IsSelect");
            dtMeterials.Columns.Add("fgtn_ID");
            dtMeterials.Columns.Add("prodJob_ID");
            dtMeterials.Columns.Add("prodBatch_ID");
            dtMeterials.Columns.Add("item_ID_FG");
            dtMeterials.Columns.Add("itemName");

            dtMeterials.Columns.Add("from_Store_ID");
            dtMeterials.Columns.Add("storeName");

            dtMeterials.Columns.Add("uom_ID");
            dtMeterials.Columns.Add("uomName");

            dtMeterials.Columns.Add("fgtnQty");
            dtMeterials.Columns.Add("prevAcceptance_Qty");
            dtMeterials.Columns.Add("pendingFGTNQty");
            dtMeterials.Columns.Add("acceptanceQty");

            dtMeterials.Columns.Add("remarks");
            dgr_Mererial.ItemsSource = dtMeterials.DefaultView;
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Acceptance #", "Acpt_No", 80);
            dgr_Main.Add_DatagridColoumn("Date", "Acpt_Date", 80);
            dgr_Main.Add_DatagridColoumn("Store", "Store", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "PREPARED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "MODIFIED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "MODIFIED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved Date", "APPROVED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "Is_Cancelled", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
            RefreshGrid_FGTN("%%");
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
            RefreshGrid_FGTN("%%");
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (txtAcceptance_ID.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxFinishedGoodTransferAcceptance oAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oAcceptance != null)
                            {
                                if (!oAcceptance.IsApproved)
                                {
                                    if (!oAcceptance.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                if (CheckCancelValidity_WATollarance())
                                                {
                                                    oAcceptance.IsCanceled = true;
                                                    oAcceptance.DateCanceled = clsSecurity.getServerDateTime();
                                                    oAcceptance.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                    oAcceptance.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                    oAcceptance.Update();


                                                    foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(oAcceptance.Acceptance_ID))
                                                    {
                                                        clsHelpMethods_Prod.UpdateStock(oDetail.To_Store_ID, oDetail.Item_ID_FG, -oDetail.AcceptanceQty);
                                                        clsHelpMethods_Prod.Update_ItemFinanceCosts(oDetail.Item_ID_FG, oDetail.UnitPrice, 0m, oDetail.AcceptanceQty);
                                                    }

                                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                                }
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
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sAcceptance_ID = "";
            if (CheckValidity())
            {
                bool bExecClearFields = true;
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxFinishedGoodTransferAcceptance oOldAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oOldAcceptance != null)
                            {
                                if (!oOldAcceptance.IsApproved && !oOldAcceptance.IsCanceled)
                                {
                                    #region Remove Old Items
                                    foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oOldDetails in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(txtAcceptance_ID.Text.Trim()))
                                    {
                                        clsHelpMethods_Prod.UpdateStock(oOldDetails.To_Store_ID, oOldDetails.Item_ID_FG, -oOldDetails.AcceptanceQty);
                                        oOldDetails.Delete();
                                    }
                                    #endregion

                                    tbl_prodTxFinishedGoodTransferAcceptance oAccepatnce = new tbl_prodTxFinishedGoodTransferAcceptance(
                                            txtAcceptance_ID.Text, dtpAcpt_Date.GetDateTime(), txtRemarks.Text,
                                            oOldAcceptance.IsChecked, oOldAcceptance.IsApproved, oOldAcceptance.IsCanceled,
                                            oOldAcceptance.CreateUser_ID, clsSecurity.UserIDLoged, oOldAcceptance.CheckedUser_ID, oOldAcceptance.ApprovedUser_ID, oOldAcceptance.CanceldUser_ID,
                                            oOldAcceptance.DateCreate, clsSecurity.getServerDateTime(), oOldAcceptance.DateChecked, oOldAcceptance.DateApproved, oOldAcceptance.DateCanceled,
                                            oOldAcceptance.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldAcceptance.CheckedUserTerminal_ID, oOldAcceptance.ApprovedUserTerminal_ID, oOldAcceptance.CanceledUserTerminal_ID,
                                            oOldAcceptance.CompanyID, oOldAcceptance.CompanyBranchID);
                                    oAccepatnce.Update();

                                    #region Update Details
                                    foreach (DataRow row in dtMeterials.Rows)
                                    {
                                        bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                        if (!bSelect)
                                            continue;

                                        decimal dItem_Id_FG_UnitCost = 0;

                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sBoM_No = clsValidate.ValidateRowValue(row, "prodJob_ID", "default");
                                        string sBatch_No = clsValidate.ValidateRowValue(row, "prodBatch_ID", "default");
                                        string sFGTN_No = clsValidate.ValidateRowValue(row, "fgtn_ID", "default");
                                        string sItemNo = clsValidate.ValidateRowValue(row, "item_ID_FG", "default");
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "uom_ID", "default");

                                        decimal dFGTNQty = clsValidate.ValidateRowValue(row, "fgtnQty", 0m);
                                        decimal dPrevAcceptanceQty = clsValidate.ValidateRowValue(row, "prevAcceptance_Qty", 0m);
                                        decimal dPendingFGTNQty = clsValidate.ValidateRowValue(row, "pendingFGTNQty", 0m);
                                        decimal dAcceptanceQty = clsValidate.ValidateRowValue(row, "acceptanceQty", 0m);

                                        string sStoreID = clsValidate.ValidateRowValue(row, "from_Store_ID", "default");
                                        string sRemarks = clsValidate.ValidateRowValue(row, "remarks", "");

                                        tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(sFGTN_No);
                                        if (oFGTN != null)
                                            dItem_Id_FG_UnitCost = oFGTN.UnitPrice;

                                        tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail = new tbl_prodTxFinishedGoodTransferAcceptance_Detail(
                                            iLine_no, txtAcceptance_ID.Text, sBoM_No, sBatch_No, sFGTN_No, sItemNo, sUoM_ID,
                                            dFGTNQty, dPendingFGTNQty, dPrevAcceptanceQty, dAcceptanceQty, 0, dItem_Id_FG_UnitCost, 0, dItem_Id_FG_UnitCost * dAcceptanceQty,
                                            sStoreID, txtToStore.Tag.ToString(), sRemarks
                                            );
                                        oDetail.Insert();

                                        // Weight Avg. Cost Update
                                        clsHelpMethods_Prod.Update_ItemFinanceCosts(sItemNo, dItem_Id_FG_UnitCost, dAcceptanceQty, dPrevAcceptanceQty);
                                        clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), sItemNo, dAcceptanceQty);
                                    }
                                    #endregion

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    sAcceptance_ID = oOldAcceptance.Acceptance_ID;
                                }
                                else
                                {
                                    if (oOldAcceptance.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been approved",
                                            MessageBoxButton.OK, "Red");
                                    else if (oOldAcceptance.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been cancelled",
                                            MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prodTxFinishedGoodTransferAcceptance oNew_FGTN_Accepatance = new tbl_prodTxFinishedGoodTransferAcceptance(txtAcceptance_ID.Text, dtpAcpt_Date.GetDateTime(),
                                txtRemarks.Text, false, false, false,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID);
                            oNew_FGTN_Accepatance.Insert();

                            #region Save Detail Table
                            int iLine_no = 1;
                            foreach (DataRow row in dtMeterials.Rows)
                            {
                                bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                if (!bSelect)
                                    continue;

                                decimal dItem_Id_FG_UnitCost = 0;

                                //int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                string sBoM_No = clsValidate.ValidateRowValue(row, "prodJob_ID", "default");
                                string sBatch_No = clsValidate.ValidateRowValue(row, "prodBatch_ID", "default");
                                string sFGTN_No = clsValidate.ValidateRowValue(row, "fgtn_ID", "default");
                                string sItemNo = clsValidate.ValidateRowValue(row, "item_ID_FG", "default");
                                string sUoM_ID = clsValidate.ValidateRowValue(row, "uom_ID", "default");

                                decimal dFGTNQty = clsValidate.ValidateRowValue(row, "fgtnQty", 0m);
                                decimal dPrevAcceptanceQty = clsValidate.ValidateRowValue(row, "prevAcceptance_Qty", 0m);
                                decimal dPendingFGTNQty = clsValidate.ValidateRowValue(row, "pendingFGTNQty", 0m);
                                decimal dAcceptanceQty = clsValidate.ValidateRowValue(row, "acceptanceQty", 0m);

                                string sStoreID = clsValidate.ValidateRowValue(row, "from_Store_ID", "default");
                                string sRemarks = clsValidate.ValidateRowValue(row, "remarks", "");

                                tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(sFGTN_No);
                                if (oFGTN != null)
                                    dItem_Id_FG_UnitCost = oFGTN.UnitPrice;

                                tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail = new tbl_prodTxFinishedGoodTransferAcceptance_Detail(
                                    iLine_no, txtAcceptance_ID.Text, sBoM_No, sBatch_No, sFGTN_No, sItemNo, sUoM_ID,
                                    dFGTNQty, dPendingFGTNQty, dPrevAcceptanceQty, dAcceptanceQty, 0, dItem_Id_FG_UnitCost, 0, dItem_Id_FG_UnitCost * dAcceptanceQty,
                                    sStoreID, txtToStore.Tag.ToString(), sRemarks
                                    );
                                oDetail.Insert();

                                //Weight Avg. Cost Update
                                clsHelpMethods_Prod.Update_ItemFinanceCosts(sItemNo, dItem_Id_FG_UnitCost, dAcceptanceQty, 0m);
                                clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), sItemNo, dAcceptanceQty);

                                iLine_no++;
                            }
                            #endregion

                            sAcceptance_ID = oNew_FGTN_Accepatance.Acceptance_ID;
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
                    if (bExecClearFields)
                    {
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sAcceptance_ID);
                    }
                }
            }
        }

        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (txtAcceptance_ID.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxFinishedGoodTransferAcceptance oAccepatance = tbl_prodTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oAccepatance != null)
                            {
                                if (!oAccepatance.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oAccepatance.IsApproved = true;
                                            oAccepatance.DateApproved = clsSecurity.getServerDateTime();
                                            oAccepatance.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oAccepatance.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oAccepatance.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }

                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oAccepatance.Acceptance_ID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected FGTN Accepatance has already been approved", MessageBoxButton.OK, "Red");
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtAcceptance_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtToStore, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtAcceptance_ID.Tag = null;
            txtToStore.Text = "";
            txtRemarks.Text = "";

            dtpAcpt_Date.SetTime(DateTime.Now);

            btnGridItemAdd.Visibility = Visibility.Collapsed;
            btnGridItemDelete.Visibility = Visibility.Collapsed;

            SEACC_Form.btn_Approved.Background = (Brush)bcon.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bcon.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtAcceptance_ID.setReadOnlyStatus(true);
                txtAcceptance_ID.Text = "<Auto Generate>";
            }
            else
                txtAcceptance_ID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                //int iCount = 0;
                //foreach (tbl_prodTxFinishedGoodTransferAcceptance oAcceptance in tbl_prodTxFinishedGoodTransferAcceptance.SelectAll().Where(p => p.Acceptance_ID != "default").OrderByDescending(o => o.DateCreate))
                //{
                //    dgr_Main.dt.Rows.Add(++iCount, oAcceptance.Acceptance_ID, oAcceptance.Acceptance_Date.ToString(clsValidation.Format_Date), 
                //        clsGenaralName.getName_Item(oAcceptance.Item_ID_FG), cls_Formater.FormatDecimal(oAcceptance.AcceptanceQty, clsConfig.sDecimalPlaces_Quantity), 
                //        clsGenaralName.getName_Store(oAcceptance.To_Store_ID),
                //        clsGenaralName.getName_User(oAcceptance.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oAcceptance.DateCreate),
                //        clsGenaralName.getName_User(oAcceptance.ModifiedUser_ID), clsHelpMethods_Prod.Format_DateTime(oAcceptance.DateModified),
                //        clsGenaralName.getName_User(oAcceptance.ApprovedUser_ID), clsHelpMethods_Prod.Format_DateTime(oAcceptance.DateApproved),
                //        oAcceptance.IsCanceled);
                //}

                string sQuery = "Exec sp_FGTN_ActDetails";
                dgr_Main.dt.Merge(DBHandling.ExecQuery(sQuery).Tables[0]);
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void RefreshGrid_FGTN(string sStored_ID)
        {
            try
            {
                dtMeterials.Clear();
                dtMeterials.Merge(DBHandling.ExecQuery("SELECT * FROM vw_prodFgtnSearchForAcceptance WHERE to_Store_ID like '" + sStored_ID + "'").Tables[0]);
                ResetLineNo_UnSelectedFields();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sId)
        {
            try
            {
                tbl_prodTxFinishedGoodTransferAcceptance oAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(sId);
                if (oAcceptance != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtAcceptance_ID.Tag = oAcceptance.Acceptance_ID;
                    txtAcceptance_ID.Text = oAcceptance.Acceptance_ID;

                    var oDetails = tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(oAcceptance.Acceptance_ID).FirstOrDefault();
                    if (oDetails != null)
                    {
                        txtToStore.Tag = oDetails.To_Store_ID;
                        txtToStore.Text = clsGenaralName.getName_Store(oDetails.To_Store_ID);
                    }

                    txtRemarks.Text = oAcceptance.Remark;
                    dtpAcpt_Date.SetTime(oAcceptance.Acceptance_Date);

                    FillDetails_ByAcceptanceID(sId);

                    btnGridItemAdd.Visibility = Visibility.Visible;
                    btnGridItemDelete.Visibility = Visibility.Visible;

                    if (oAcceptance.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bcon.ConvertFrom("#3DFF3D");
                    if (oAcceptance.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bcon.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void FillDetails_ByAcceptanceID(string sId)
        {
            if (sId != null)
            {
                dtMeterials.Clear();
                foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(sId))
                {
                    dtMeterials.Rows.Add(oDetail.Line_No, "\uE0A2", oDetail.Fgtn_ID, oDetail.ProdJob_ID, oDetail.ProdBatch_ID,
                        oDetail.Item_ID_FG,
                        clsGenaralName.getName_Item(oDetail.Item_ID_FG),
                        oDetail.From_Store_ID, clsGenaralName.getName_Store(oDetail.From_Store_ID),
                        oDetail.Uom_ID, clsGenaralName.getName_Uom(oDetail.Uom_ID),
                        cls_Formater.FormatDecimal(oDetail.FgtnQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oDetail.PrevAcceptanceQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oDetail.Fgtn_PendigQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oDetail.AcceptanceQty, clsConfig.sDecimalPlaces_Quantity),
                        oDetail.Remark);
                }
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_GridSelectedCount())
                {
                    if (CheckValidity_GridSelectRow_AccptQty())
                    {
                        if (CheckValidity_DuplicateFiled())
                        {
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtAcceptance_ID.Text))
                            {
                                if (CheckValidity_WATollarance())
                                {
                                    bStatus = true;
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtAcceptance_ID))
                bStatus = false;

            if (!clsValidation.Validate_EmptyValue(txtToStore))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_GridSelectRow_AccptQty()
        {
            bool bStatus = true;

            List<string> oList = new List<string>();

            var vSelectedRows = dtMeterials.Select("IsSelect = '\uE0A2'");
            if (vSelectedRows != null)
            {
                foreach (DataRow row in vSelectedRows)
                {
                    string sAcceptanceQty = clsValidate.ValidateRowValue(row, "acceptanceQty", "");
                    if (sAcceptanceQty == "" ||  clsValidation.Validate_DecimalNumber(sAcceptanceQty) == 0)
                    {
                        bStatus = false;
                        string sfgtn_ID = clsValidate.ValidateRowValue(row, "fgtn_ID", "");
                        oList.Add(sfgtn_ID);
                    }
                }
            }

            if (!bStatus)
                SEACCMessageBox.Show("Oops..!", "Please Enter Valid Acceptance Qty To Selected FGTN\n" + String.Join(",\n", oList) + "", MessageBoxButton.OK, "Red");

            return bStatus;
        }

        private bool CheckValidity_GridSelectedCount()
        {
            bool bStatus = false;
            List<DataRow> vSelectedRows = dtMeterials.Select("IsSelect = '\uE0A2'").ToList();

            if (vSelectedRows.Count > 0)
                bStatus = true;

            if (!bStatus)
                SEACCMessageBox.Show("Oops..!", "Please Select Items and Enter Acceptance Quantity....", MessageBoxButton.OK, "Red");

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtAcceptance_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtAcceptance_ID.Text = txtAcceptance_ID.Tag.ToString();
                }

                tbl_prodTxFinishedGoodTransferAcceptance oAccepatance = tbl_prodTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                if (oAccepatance != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckValidity_WATollarance()
        {
            #region Variables
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("LineNo");
            dtGrid.Columns.Add("ItemCode");
            dtGrid.Columns.Add("Quantity");
            dtGrid.Columns.Add("UnitPrice");

            List<tbl_Detail> DB = new List<tbl_Detail>();
            #endregion

            #region Copy grid
            int iLine_no = 0;
            foreach (DataRow row in dtMeterials.Rows)
            {
                bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                if (!bSelect)
                    continue;

                decimal dItem_Id_FG_UnitCost = 0;

                string sFGTN_No = clsValidate.ValidateRowValue(row, "fgtn_ID", "default");
                string sItemNo = clsValidate.ValidateRowValue(row, "item_ID_FG", "default");
                decimal dFGTNQty = clsValidate.ValidateRowValue(row, "fgtnQty", 0m);


                tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(sFGTN_No);
                if (oFGTN != null)
                    dItem_Id_FG_UnitCost = oFGTN.UnitPrice;

                dtGrid.Rows.Add(++iLine_no, sItemNo, dFGTNQty, dItem_Id_FG_UnitCost);
            }
            #endregion

            #region Copy Saved value
            foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(txtAcceptance_ID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID_FG, oDetail.AcceptanceQty, oDetail.UnitPrice));
            }
            #endregion

            return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);
        }

        private bool CheckCancelValidity_WATollarance()
        {
            List<tbl_Detail> DB = new List<tbl_Detail>();
            foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByAcceptance_ID(txtAcceptance_ID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID_FG, oDetail.AcceptanceQty, oDetail.UnitPrice));
            }
            return clsHelpMethods.CheckCancelValidity_WATollarance(DB);
        }

        #endregion

        #region Grid Events
        #region Dgr Main
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string gridId = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;
                    ClearFields();
                    FillDetails(gridId);
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row["Is_Cancelled"].ToString()))
                {
                    e.Row.Foreground = (Brush)bcon.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Dgr Material
        private void dgr_Mererial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            object item = dgr_Mererial.SelectedItem;
            int irowID = dgr_Mererial.SelectedIndex;

            if (item != null)
            {
                string sColumnName = e.Column.SortMemberPath;
                switch (sColumnName)
                {
                    case "acceptanceQty":
                        var txt = e.EditingElement as TextBox;
                        decimal dAccptQty = 0m;

                        try
                        {
                            int iLineNo = int.Parse((dgr_Mererial.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                            decimal dPendingQty = clsValidation.Validate_DecimalNumber((dgr_Mererial.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text);
                            decimal dPrevAcceptanceQty = clsValidation.Validate_DecimalNumber((dgr_Mererial.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text);
                            if (clsValidate.isCurrency(txt.Text))
                            {
                                if (txt != null) dAccptQty = decimal.Parse(txt.Text);
                                if (dAccptQty > 0)
                                {
                                    if (SEACC_Form.IsUpdateMode)
                                    {
                                        if (dAccptQty > (dPendingQty + dPrevAcceptanceQty))
                                        {
                                            bool bStatus = SEACCMessageBox.Show("FGTN Quantity Exceeded....!", "Are you sure to exceed the FGTN Quantity?", MessageBoxButton.YesNo, "#FF5B6B76");
                                            if (!bStatus)
                                                dAccptQty = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (dAccptQty > dPendingQty)
                                        {
                                            bool bStatus = SEACCMessageBox.Show("FGTN Quantity Exceeded....!", "Are you sure to exceed the FGTN Quantity?", MessageBoxButton.YesNo, "#FF5B6B76");
                                            if (!bStatus)
                                                dAccptQty = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity...", MessageBoxButton.OK, "Red");
                                    dAccptQty = 0;
                                }
                            }
                        }
                        catch
                        {
                            SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity...", MessageBoxButton.OK, "Red");
                            dAccptQty = 0;
                        }

                        if (txt != null) txt.Text = cls_Formater.FormatDecimal(dAccptQty, clsConfig.sDecimalPlaces_Quantity);
                        break;
                }
            }
        }

        private void dgr_Mererial_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Mererial.SelectedIndex;
            var vDG_Cell = dgr_Mererial.CurrentCell;
            try
            {
                switch (vDG_Cell.Column.SortMemberPath)
                {
                    case "IsSelect":
                        bool bIsChecked;
                        bIsChecked = dtMeterials.Rows[irowID]["IsSelect"].ToString() == "\uE0A2";
                        dtMeterials.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";

                        if (dtMeterials.Select("IsSelect = '\uE10A' ").Any())
                            chk_selectAll.IsChecked = false;
                        break;
                }
            }
            catch (Exception) { }
        }
        #endregion
        #endregion

        #region Search Events
        private void txtAcceptance_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_FGTNAcceptance);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails(lstResult[0]);
            }
        }
        private void txtToStore_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoreMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtToStore.Tag = lstResult[0];
                txtToStore.Text = lstResult[1];

                RefreshGrid_FGTN(lstResult[0]);
            }
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        #region Check Box Events
        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtMeterials.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
        }

        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtMeterials.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
        }
        #endregion

        #region Item Click Events
        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Mererial.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_Mererial.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;

                DataRow[] items = dtMeterials.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtMeterials.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
            }
        }

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Show(Digiteq_Logic.Search.Prod_FGTNforStoresAcceptance, true);
            RowDataSearch.RowSelected += RowMaterialSearch_RowSelected;
        }

        private void RowMaterialSearch_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bItem = false;
                DataRow[] row = dtMeterials.Select("fgtn_ID ='" + lstResult[0] + "'");
                if (row.Length == 0)
                    bItem = true;
                else
                {
                    string sLineNo = row[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Finished Good Transfer Note Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bItem = true;
                }

                if (bItem)
                {
                    dtMeterials.Merge(DBHandling.ExecQuery("SELECT * FROM vw_prodFgtnSearchForAcceptance WHERE fgtn_ID = '" + lstResult[0] + "'").Tables[0]);
                    ResetLineNo_SelectedFields();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Help Methods
        private void ResetLineNo_UnSelectedFields()
        {
            long i = 0;
            foreach (DataRow row in dtMeterials.Rows)
            {
                row["LineNo"] = ++i;
                row["IsSelect"] = "\uE003";
            }
        }

        private void ResetLineNo_SelectedFields()
        {
            long i = 0;
            foreach (DataRow row in dtMeterials.Rows)
            {
                row["LineNo"] = ++i;
                row["IsSelect"] = "\uE0A2";
            }
        }
        #endregion
    }
}