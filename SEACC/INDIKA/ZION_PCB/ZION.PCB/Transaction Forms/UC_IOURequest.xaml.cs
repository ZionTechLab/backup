using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZION.PCB.Reports;

namespace SEACC_PCB
{
    /// <summary>
    /// Interaction logic for UC_IOURequest.xaml
    /// </summary>
    public partial class UC_IOURequest : UserControl
    {
        #region Form Load
        public UC_IOURequest()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_IOURequest;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ReqID");
            dgr_Main.dt.Columns.Add("ReqDate");
            dgr_Main.dt.Columns.Add("ReqBy");
            dgr_Main.dt.Columns.Add("Remarks");
            dgr_Main.dt.Columns.Add("Amount", typeof(decimal));
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, true);
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Request ID", "ReqID", 100);
            dgr_Main.Add_DatagridColoumn("Request Date", "ReqDate", 100);
            dgr_Main.Add_DatagridColoumn("Requested By", "ReqBy", 120);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 220);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "Amount", 100, true, true);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtReqID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enum_ReportName.pcb_IOURequst);
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.pcb_IOURequst);
                        if (oReports != null)
                        {

                            ZION.PCB.Reports.DataSets.dts_ReportExport glb_dts_ExportReport = new ZION.PCB.Reports.DataSets.dts_ReportExport();
                            ZION.PCB.Reports.DataSets.dts_PettyCash dts_pettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                            dts_pettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            tbl_pcbTxIOURequest oIOURequest = tbl_pcbTxIOURequest.Select(txtReqID.Tag.ToString());
                            if (oIOURequest != null)
                            {
                                //dts_pettyCash.dt_IOU.Adddt_IOURow("", oIOURequest.IouRequestDate, "", "", "", "", "", "", 0, 0, "", false, oIOURequest.IouRequest_ID, oIOURequest.IouRequestDate, oIOURequest.IouRequestedUser_ID, clsGenaralName.getName_User(oIOURequest.IouRequestedUser_ID), "Cost Centre ID", "", oIOURequest.Remarks, oIOURequest.RequestAmount, oIOURequest.IsSettled ? "Settled" : "UnSettled");
                                dts_pettyCash.dt_IOURequest.Adddt_IOURequestRow(oIOURequest.IouRequest_ID, oIOURequest.IouRequestDate, oIOURequest.IouRequestedUser_ID, clsGenaralName.getName_User(oIOURequest.IouRequestedUser_ID), "Cost Centre ID", "", oIOURequest.Remarks, oIOURequest.RequestAmount, oIOURequest.IsSettled ? "Settled" : "UnSettled", "");

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Cancel", oIOURequest.IsCanceled ? "Cancelled" : "", true);
                                frm_ReportViewer RepViwer = new frm_ReportViewer();
                                RepViwer.print(oReports.ReportPath, dts_pettyCash, glb_dts_ExportReport.dt_rptParameter);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }  
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }       

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_pcbTxIOURequest oOldReq = tbl_pcbTxIOURequest.Select(txtReqID.Tag.ToString());
                            if (oOldReq != null)
                            {
                                if (!oOldReq.IsCanceled)
                                {
                                    if (!oOldReq.IsSettled)
                                    {
                                        tbl_pcbTxIOURequest oReq = new tbl_pcbTxIOURequest(txtReqID.Tag.ToString(), dtpReq_Date.GetDateTime().Date, txtRequestedBy.Tag.ToString(), txtRemarks.Text, decimal.Parse(txtAmount.Text), false, oOldReq.IsCanceled, oOldReq.CreateUser_ID, clsSecurity.UserIDLoged, oOldReq.CanceldUser_ID, oOldReq.DateCreate, clsSecurity.getServerDateTime(), oOldReq.DateCanceled, oOldReq.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldReq.CanceledUserTerminal_ID);
                                        oReq.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Update..", "This Request is already settled", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Update..", "This Request is already cancelled", MessageBoxButton.OK);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (SEACC_Form.isAutoGenaratedCode)
                                txtReqID.Tag = SEACC_Form.getAutoGeneratedCode();

                            tbl_pcbTxIOURequest oNewReq = new tbl_pcbTxIOURequest(txtReqID.Tag.ToString(), dtpReq_Date.GetDateTime().Date, txtRequestedBy.Tag.ToString(), txtRemarks.Text, decimal.Parse(txtAmount.Text), false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                            oNewReq.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    //fillDetails(txtReqID.Tag.ToString());
                    RefreshGrid();
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtReqID.Tag != null)
                    {
                        //List<tbl_pcbTxIOU> oExp = tbl_pcbTxIOU.SelectAllByIouRequest_ID(txtReqID.Tag.ToString()).ToList();
                        //if (oExp.Count > 0)
                        //{
                        //    SEACCMessageBox.Show("Can not Cancel !!", "You cannot cancel selected IOU request as its already settled", MessageBoxButton.OK);
                        //}

                        //else
                        //{
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_pcbTxIOURequest Details = tbl_pcbTxIOURequest.Select(txtReqID.Tag.ToString());
                            if (Details != null)
                            {
                                if (!Details.IsCanceled)
                                {
                                    if (!Details.IsSettled)
                                    {
                                        Details.IsCanceled = true;
                                        Details.DateCanceled = clsSecurity.getServerDateTime();
                                        Details.CanceldUser_ID = clsSecurity.UserIDLoged;
                                        Details.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                        Details.Update();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                        ClearFields();
                                        RefreshGrid();
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Cancel..", "This Request is already settled", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Cancel..", "This Request is already cancelled", MessageBoxButton.OK);
                            }
                        }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_Amount())
                    //{
                    //    if (CheckValidity_DuplicateFiled())
                    //    {
                    //        if (ChekValidity_DuplicateNames())
                    bStatus = true;
                //    }
                //}
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtRequestedBy))
                bStatus = false;            

            return bStatus;
        }

        private bool CheckValidity_Amount()
        {
            bool bStatus = true;

            if (decimal.Parse(txtAmount.Text) == 0)
            {
                SEACCMessageBox.Show("", "Amount should be greater than 0", MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtReqID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtReqID.Text = txtReqID.Tag.ToString();
                }

                //tbl_genDepartmentMaster oDept = tbl_genDepartmentMaster.Select(txtAccountCode.Text);
                //if (oDept != null)
                //{
                //    bStatus = false;
                //    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //}
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            //foreach (tbl_genDepartmentMaster oDept in tbl_genDepartmentMaster.SelectAll().Where(p => p.DepartmentName == txtDeptName.Text && p.Department_ID != txtDepartmentID.Text))
            //{
            //    bStatus = false;
            //    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
            //    break;
            //}
            return bStatus;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            //cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtReqID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReqID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRequestedBy, false, false, false);            
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, true, true, false);

            dtpReq_Date.SetTime(clsSecurity.getServerDateTime());
            lblCancel.Visibility = Visibility.Collapsed;

            txtReqID.Tag = null;
            txtRequestedBy.Tag = clsSecurity.UserIDLoged;

            txtReqID.Text = "";
            txtRequestedBy.Text = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
            txtRemarks.Text = "";
            txtAmount.Text = "0.00";            

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtReqID.setReadOnlyStatus(true);
                txtReqID.Text = "<Auto Generate>";
            }
            else
                txtReqID.setReadOnlyStatus(false);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_pcbTxIOURequest detail in tbl_pcbTxIOURequest.SelectAll().Where(p => p.IouRequest_ID != "default" && !p.IsCanceled && !p.IsSettled))
                {
                    dgr_Main.dt.Rows.Add(detail.IouRequest_ID, clsFormatter.FormatDate_Short(detail.IouRequestDate), clsGenaralName.getName_User(detail.IouRequestedUser_ID), detail.Remarks, clsFormatter.FormatDecimalPlaces_Price(detail.RequestAmount));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbTxIOURequest detail = tbl_pcbTxIOURequest.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReqID, false, false, false);

                        txtReqID.Text = detail.IouRequest_ID;
                        txtReqID.Tag = detail.IouRequest_ID;
                        dtpReq_Date.SetTime(detail.IouRequestDate);

                        txtRequestedBy.Tag = detail.IouRequestedUser_ID;
                        txtRequestedBy.Text = clsGenaralName.getName_User(detail.IouRequestedUser_ID);
                        txtRemarks.Text = detail.Remarks;
                        txtAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.RequestAmount);

                        if (detail.IsCanceled)
                            lblCancel.Visibility = Visibility.Visible;
                        else
                            lblCancel.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Search Events
        private void txtRequestedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
                RefreshGrid();
            }
        }

        private void txtReqID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOURequest);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }
}