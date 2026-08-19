using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
using SEACC_WPFControls;
using ZION.PCB.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PCB.Transaction_Forms
{
    /// <summary>
    /// Interaction logic for frm_IOURefund.xaml
    /// </summary>
    public partial class frm_IOURefund : Window
    {
        #region Class Variables 
        public event EventHandler Updated;
        DataTable dtIOURefund = new DataTable();
        public string sPCAccountID;
        int iSelectedRow = -1;
        #endregion

        #region Form Load
        public frm_IOURefund(string _PCAccountID)
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_IOURefund;
            SEACC_Form.Initialize();
            sPCAccountID = _PCAccountID;
            #endregion

            #region PCB Data Table
            dtIOURefund.Columns.Add("IOUNo");
            dtIOURefund.Columns.Add("Amnt");
            dtIOURefund.Columns.Add("UnSetAmnt");
            dtIOURefund.Columns.Add("AlloAmnt");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, true);
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRefundID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enum_ReportName.pcb_Refund);
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.pcb_Refund);
                        if (oReports != null)
                        {
                            ZION.PCB.Reports.DataSets.dts_ReportExport glb_dts_ExportReport = new ZION.PCB.Reports.DataSets.dts_ReportExport();
                            ZION.PCB.Reports.DataSets.dts_PettyCash dts_pettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                            dts_pettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            tbl_pcbTxIOURefund details = tbl_pcbTxIOURefund.Select(txtRefundID.Tag.ToString());
                            if (details != null)
                            {
                                dts_pettyCash.dt_IOURefund.Adddt_IOURefundRow(details.Refund_ID, details.RefundDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID),details.User_ID, clsGenaralName.getName_User(details.User_ID), details.Amount, details.Remarks, "");
                                string s = "";
                                foreach (tbl_pcbTxIOUSettlement oIOUSet in tbl_pcbTxIOUSettlement.SelectAllByRefund_ID(details.Refund_ID))
                                {
                                    s = oIOUSet.IouSettlementID;
                                    dts_pettyCash.dt_IOUSettlement.Adddt_IOUSettlementRow(oIOUSet.IouSettlementID, "", oIOUSet.Expenditure_ID, oIOUSet.Refund_ID, oIOUSet.Iou_ID, 0, oIOUSet.AllocatedAmount);
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Set", s, true);
                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Cancel", details.IsCanceled ? "Cancelled" : "", true);
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
                            tbl_pcbTxIOURefund oOldRefund = tbl_pcbTxIOURefund.Select(txtRefundID.Tag.ToString());
                            if (oOldRefund != null)
                            {
                                if (!oOldRefund.IsCanceled)
                                {
                                    //if (!oOldRef.IsReimbursment)
                                    //{

                                    #region Remove Settlement
                                    //decimal dOldAllocatedAmount = 0;
                                    foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByRefund_ID(txtRefundID.Tag.ToString()))
                                    {
                                        //dOldAllocatedAmount -= oSet.AllocatedAmount;

                                        #region IOU Update
                                        tbl_pcbTxIOU oOldIOU = tbl_pcbTxIOU.Select(oSet.Iou_ID);
                                        oOldIOU.IsSettled = false;
                                        oOldIOU.SettledAmount -= oSet.AllocatedAmount;
                                        oOldIOU.Update();
                                        #endregion

                                        oSet.Delete();
                                    }
                                    #endregion

                                    decimal dRefundAmount = decimal.Parse(txtAmount.Text);
                                    decimal dExpAllocateAmnt = 0;

                                    #region IOU Settlement
                                    foreach (DataRow row in dtIOURefund.Rows)
                                    {
                                        string sIOUID = row["IOUNo"].ToString();
                                        //       decimal dAmountIOU = decimal.Parse(row["Amnt"].ToString());

                                        decimal dAllocatedAmount = 0;

                                        tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                        if (oIOU != null)
                                        {
                                            decimal dAmountIOU_UnSettled = oIOU.IouAmount - oIOU.SettledAmount;// decimal.Parse(row["UnSetAmnt"].ToString());
                                            if (dRefundAmount < dAmountIOU_UnSettled)
                                            {
                                                dAllocatedAmount = dRefundAmount;
                                                oIOU.SettledAmount += dAllocatedAmount;

                                            }
                                            else
                                            {
                                                dAllocatedAmount = dAmountIOU_UnSettled;
                                                oIOU.SettledAmount = dAllocatedAmount;
                                                oIOU.IsSettled = true;
                                                //  dRefundAmount -= dAmountIOU_UnSettled;

                                            }
                                            oIOU.Update();

                                            SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                            tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), "default", sIOUID, txtRefundID.Tag.ToString(), dAllocatedAmount);
                                            oIOUSet.Insert();

                                            dRefundAmount -= dAllocatedAmount;
                                            dExpAllocateAmnt += dAllocatedAmount;
                                            SEACC_Form.enmFormName = FormName.PCB_IOURefund;
                                        }

                                    }

                                    #endregion

                                    bool bIsSettled = false;
                                    if (decimal.Parse(txtAmount.Text) == dExpAllocateAmnt)
                                        bIsSettled = true;

                                    tbl_pcbTxIOURefund oExp = new tbl_pcbTxIOURefund(txtRefundID.Tag.ToString(), dtpRefundDate.GetDateTime().Date, sPCAccountID, txtUser.Tag.ToString(), txtRemarks.Text,
                                        decimal.Parse(txtAmount.Text), dExpAllocateAmnt, bIsSettled, oOldRefund.IsCanceled, oOldRefund.CreateUser_ID, clsSecurity.UserIDLoged, oOldRefund.CanceldUser_ID, oOldRefund.DateCreate, clsSecurity.getServerDateTime(), oOldRefund.DateCanceled, oOldRefund.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldRefund.CanceledUserTerminal_ID);
                                    oExp.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);                                   
                                }
                                else
                                    SEACCMessageBox.Show("Can not Update..", "This Refund is already cancelled", MessageBoxButton.OK);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (dtIOURefund.Rows.Count > 0)
                            {
                                if (SEACC_Form.isAutoGenaratedCode)
                                    txtRefundID.Tag = SEACC_Form.getAutoGeneratedCode();

                                decimal dRefundAmount = decimal.Parse(txtAmount.Text);
                                decimal dExpAllocateAmnt = 0;

                                tbl_pcbTxIOURefund oNewRef = new tbl_pcbTxIOURefund(txtRefundID.Tag.ToString(), dtpRefundDate.GetDateTime().Date, sPCAccountID, txtUser.Tag.ToString(), txtRemarks.Text, dRefundAmount, dExpAllocateAmnt, false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                                oNewRef.Insert();

                                #region IOU Settlement
                                foreach (DataRow row in dtIOURefund.Rows)
                                {
                                    string sIOUID = row["IOUNo"].ToString();
                             //       decimal dAmountIOU = decimal.Parse(row["Amnt"].ToString());
                                   
                                    decimal dAllocatedAmount = 0;

                                    tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                    if (oIOU != null)
                                    {
                                        decimal dAmountIOU_UnSettled = oIOU.IouAmount - oIOU.SettledAmount;// decimal.Parse(row["UnSetAmnt"].ToString());
                                        if (dRefundAmount < dAmountIOU_UnSettled)
                                        {
                                            dAllocatedAmount = dRefundAmount;
                                            oIOU.SettledAmount += dAllocatedAmount;
                                            
                                        }
                                        else
                                        {
                                            dAllocatedAmount = dAmountIOU_UnSettled;
                                            oIOU.SettledAmount = dAllocatedAmount;
                                            oIOU.IsSettled = true;
                                          //  dRefundAmount -= dAmountIOU_UnSettled;
                                            
                                        }
                                        oIOU.Update();

                                        SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                        tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), "default", sIOUID, txtRefundID.Tag.ToString(), dAllocatedAmount);
                                        oIOUSet.Insert();

                                        dRefundAmount -= dAllocatedAmount;
                                        dExpAllocateAmnt += dAllocatedAmount;
                                        SEACC_Form.enmFormName = FormName.PCB_IOURefund;
                                    }

                                }

                                #endregion

                                tbl_pcbTxIOURefund oOldRef = tbl_pcbTxIOURefund.Select(txtRefundID.Tag.ToString());
                                oOldRef.SettledAmount = dExpAllocateAmnt;
                                if (oOldRef.Amount == oOldRef.SettledAmount)
                                    oOldRef.IsSettled = true;

                                oOldRef.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                                SEACCMessageBox.Show("Can not Save..", "Please select IOU(s) to add a IOU Refund", MessageBoxButton.OK);
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
                    if(txtRefundID.Tag!=null)
                    fillDetails(txtRefundID.Tag.ToString());

                    try
                    {
                        Updated(sender, e);
                    }
                    catch { }                   
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtRefundID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_pcbTxIOURefund Details = tbl_pcbTxIOURefund.Select(txtRefundID.Tag.ToString());
                            if (Details != null)
                            {
                                if (!Details.IsCanceled)
                                {
                                    #region Remove Settlement

                                    decimal dOldAllocatedAmount = 0;
                                    foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByRefund_ID(txtRefundID.Tag.ToString()))
                                    {
                                        dOldAllocatedAmount += oSet.AllocatedAmount;

                                        #region IOU Update
                                        tbl_pcbTxIOU oOldIOU = tbl_pcbTxIOU.Select(oSet.Iou_ID);
                                        oOldIOU.IsSettled = false;
                                        oOldIOU.SettledAmount -= oSet.AllocatedAmount;
                                        oOldIOU.Update();
                                        #endregion

                                        oSet.Delete();
                                    }
                                    #endregion

                                    Details.IsCanceled = true;
                                    Details.DateCanceled = clsSecurity.getServerDateTime();
                                    Details.CanceldUser_ID = clsSecurity.UserIDLoged;
                                    Details.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                    Details.SettledAmount -= dOldAllocatedAmount;
                                    Details.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Cancel..", "This Refund is already cancelled", MessageBoxButton.OK);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
            finally
            {
                ClearFields();

                try
                {
                    Updated(sender, e);
                }
                catch { }
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

            if (!clsValidation.Validate_EmptyValue(txtUser))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_Amount()
        {
            bool bStatus = true;

            if (txtAmount.Text == "0.00")
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
                //if (SEACC_Form.isAutoGenaratedCode)
                //{
                //    txtDepartmentID.Tag = SEACC_Form.getAutoGeneratedCode();
                //    txtDepartmentID.Text = txtDepartmentID.Tag.ToString();
                //}

                //tbl_genDepartmentMaster oDept = tbl_genDepartmentMaster.Select(txtDepartmentID.Text);
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

            //cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtRefundID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRefundID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUser, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, true, true, false);

            dtpRefundDate.SetTime(clsSecurity.getServerDateTime());

            lblCancel.Visibility = Visibility.Collapsed;

            txtRefundID.Tag = null;
            txtUser.Tag = null;

            txtRefundID.Text = "";
            txtUser.Text = "";
            txtRemarks.Text = "";
            txtAmount.Text = "0.00";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtRefundID.setReadOnlyStatus(true);
                txtRefundID.Text = "<Auto Generate>";
            }
            else
                txtRefundID.setReadOnlyStatus(false);

            dtIOURefund.Rows.Clear();

        }
        #endregion

        #region FillDetails
        public void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbTxIOURefund detail = tbl_pcbTxIOURefund.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRefundID, false, false, false);

                        txtRefundID.Tag = detail.Refund_ID;
                        txtRefundID.Text = detail.Refund_ID;
                        txtUser.Tag = detail.User_ID;
                        txtUser.Text = clsGenaralName.getName_User(detail.User_ID);
                        txtRemarks.Text = detail.Remarks;
                        txtAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.Amount).ToString();
                        dtpRefundDate.SetTime(detail.RefundDate);

                        if (detail.IsCanceled)
                            lblCancel.Visibility = Visibility.Visible;
                        else
                            lblCancel.Visibility = Visibility.Collapsed;

                        dtIOURefund.Rows.Clear();

                        foreach (tbl_pcbTxIOUSettlement details_Sett in tbl_pcbTxIOUSettlement.SelectAllByRefund_ID(detail.Refund_ID))
                        {
                            tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(details_Sett.Iou_ID);
                            dtIOURefund.Rows.Add(details_Sett.Iou_ID, clsFormatter.FormatDecimalPlaces_Price(oIOU.IouAmount), clsFormatter.FormatDecimalPlaces_Price(oIOU.IouAmount - oIOU.SettledAmount), clsFormatter.FormatDecimalPlaces_Price(details_Sett.AllocatedAmount));
                            dgr_IOURefund.ItemsSource = dtIOURefund.DefaultView;
                        }
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

        #region Search events
        private void txtRefundID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOURefund);
            if (RowDataSearch.DialogResult == true)
            {                
                fillDetails(lstResult[0]);
            }
        }

        private void txtUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtUser.Tag = lstResult[0];
                txtUser.Text = lstResult[1];
            }
        }
        #endregion

        #region Grid Add Button
        private void btnGridAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Tag != null)
            {
                bool bAllowAddIOU = true;

                if (decimal.Parse(txtAmount.Text) > 0)
                {
                    if (SEACC_Form.IsUpdateMode && txtRefundID.Tag != null)
                    {
                        tbl_pcbTxIOURefund oRef = tbl_pcbTxIOURefund.Select(txtRefundID.Tag.ToString());
                        if (decimal.Parse(txtAmount.Text) == oRef.SettledAmount)
                        {
                            bAllowAddIOU = false;
                        }
                    }

                    if (bAllowAddIOU)
                    {
                        List<string> lstParameeters = new List<string>();
                        lstParameeters.Add(sPCAccountID);
                        lstParameeters.Add(txtUser.Tag.ToString());
                        lstParameeters.Add("0");

                        frm_search RowDataSearch = new frm_search(lstParameeters);
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOU);
                        if (RowDataSearch.DialogResult == true)
                        {
                            try
                            {
                                bool bAddItem = false;
                                DataRow[] items = dtIOURefund.Select("IOUNo ='" + lstResult[0] + "'");
                                if (items.Length == 0)
                                    bAddItem = true;
                                else
                                {
                                    string sIOUNo = items[0]["IOUNo"].ToString();
                                }

                                if (bAddItem)
                                {
                                    //dtIOURefund.Rows.Add(lstResult[0], clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2])), clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2]) - decimal.Parse(lstResult[3])), clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[3])));

                                    dtIOURefund.Rows.Add(lstResult[0], clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2])), clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2]) - decimal.Parse(lstResult[3])), 0);
                                    dgr_IOURefund.ItemsSource = dtIOURefund.DefaultView;

                                }
                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                                SEACCExeption.Show(ex);
                            }
                        }
                    }
                    else
                        SEACCMessageBox.Show("", "This Expenditure is already settled", MessageBoxButton.OK);
                }
                else
                    SEACCMessageBox.Show("", "Expenditure amount should be greater than 0", MessageBoxButton.OK);
            }
            else
                SEACCMessageBox.Show("", "Please select the user", MessageBoxButton.OK);
        }
        #endregion

        #region Grid Delete Button
        private void btnGridDelete_Click(object sender, RoutedEventArgs e)
        {
            if (iSelectedRow > -1)
            {
                dtIOURefund.Rows.RemoveAt(iSelectedRow);
                iSelectedRow = -1;
            }
            else
                SEACCMessageBox.Show("", "Please select a IOU to remove", MessageBoxButton.OK);
        } 
        #endregion

        #region Button Close
        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void dgr_IOURefund_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            iSelectedRow = dgr_IOURefund.SelectedIndex;
        }
    }
}