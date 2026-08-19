using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
using SEACC_WPFControls;
using ZION.PCB.Reports;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SEACC_PCB.Transaction_Forms
{
    public partial class frm_AddIOU : Window
    {
        #region Class Variables 
        public event EventHandler Updated;
        public string sPCAccountID;
        #endregion

        #region Form Load
        public frm_AddIOU(string _PCAccountID,bool isViewMode)
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_AddIOU;
            SEACC_Form.Initialize();
            sPCAccountID = _PCAccountID;
            #endregion

            #region Initialize Action Buttons
            if(isViewMode)
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
            else
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
                if (txtIOUID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enum_ReportName.pcb_IOU);
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.pcb_IOU);
                        if (oReports != null)
                        {
                            ZION.PCB.Reports.DataSets.dts_ReportExport glb_dts_ExportReport = new ZION.PCB.Reports.DataSets.dts_ReportExport();
                            ZION.PCB.Reports.DataSets.dts_PettyCash dts_pettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                            dts_pettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            tbl_pcbTxIOU details = tbl_pcbTxIOU.Select(txtIOUID.Tag.ToString());
                            if (details != null)
                            {
                               
                                //dts_pettyCash.dt_IOU.Adddt_IOURow(details.Iou_ID, details.IouDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID), details.IouUser_ID, clsGenaralName.getName_User(details.IouUser_ID), "default", "", details.IouAmount, details.SettledAmount, details.Remarks, details.IsSettled, 
                                //    details.IouRequest_ID, oIOURequest.IouRequestDate, oIOURequest.IouRequestedUser_ID, clsGenaralName.getName_User(oIOURequest.IouRequestedUser_ID), "default", "", oIOURequest.Remarks, oIOURequest.RequestAmount, oIOURequest.IsSettled ? "Settled" : "UnSettled");
                                dts_pettyCash.dt_IOU.Adddt_IOURow(details.Iou_ID, details.IouDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID), details.IouUser_ID, clsGenaralName.getName_User(details.IouUser_ID), "default", "", details.IouAmount, details.SettledAmount, details.Remarks, details.IsSettled,
                                    details.IouRequest_ID);

                                tbl_pcbTxIOURequest oIOURequest = tbl_pcbTxIOURequest.Select(details.IouRequest_ID);
                                if (oIOURequest != null)
                                {
                                    dts_pettyCash.dt_IOURequest.Adddt_IOURequestRow(oIOURequest.IouRequest_ID, oIOURequest.IouRequestDate, oIOURequest.IouRequestedUser_ID, clsGenaralName.getName_User(oIOURequest.IouRequestedUser_ID), "default", "", oIOURequest.Remarks, oIOURequest.RequestAmount, oIOURequest.IsSettled ? "Settled" : "UnSettled", "");
                                }

                                bool bSettlementFound = false;
                                string sType = "";
                                foreach (tbl_pcbTxIOUSettlement oIOUSet in tbl_pcbTxIOUSettlement.SelectAllByIou_ID(details.Iou_ID))
                                {
                                    bSettlementFound = true;
                                    tbl_pcbTxExpenditure oEx = tbl_pcbTxExpenditure.Select(oIOUSet.Expenditure_ID);
                                    tbl_pcbTxIOURefund oRef = tbl_pcbTxIOURefund.Select(oIOUSet.Refund_ID);

                                    sType = oIOUSet.Expenditure_ID == "default" ? "Refund" : "Expenditure";

                                    dts_pettyCash.dt_IOUSettlement.Adddt_IOUSettlementRow(oIOUSet.IouSettlementID, sType, oIOUSet.Expenditure_ID == "default" ? oIOUSet.Refund_ID : oIOUSet.Expenditure_ID, oIOUSet.Refund_ID, oIOUSet.Iou_ID, oIOUSet.Expenditure_ID == "default" ? oRef.Amount : oEx.TotalAmount, oIOUSet.AllocatedAmount);
                                }
                                if(!bSettlementFound)
                                    dts_pettyCash.dt_IOUSettlement.Adddt_IOUSettlementRow("", "", "", "", "", 0, 0);

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
                 //   if (txtRequestID.Tag != null)
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_pcbTxIOU oOldIOU = tbl_pcbTxIOU.Select(txtIOUID.Tag.ToString());
                                if (oOldIOU != null)
                                {
                                    if (!oOldIOU.IsCanceled)
                                    {
                                        string sSettleIDs = "";
                                        int iNoofSettlements = 0;

                                        foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByIou_ID(txtIOUID.Tag.ToString()))
                                        {
                                            tbl_pcbTxExpenditure oExp = tbl_pcbTxExpenditure.Select(oSet.Expenditure_ID);
                                            if (oExp != null && oExp.Expenditure_ID != "default")
                                            {
                                                sSettleIDs += oSet.Expenditure_ID + ", ";
                                                ++iNoofSettlements;
                                            }

                                            tbl_pcbTxIOURefund oRefund = tbl_pcbTxIOURefund.Select(oSet.Refund_ID);
                                            if (oRefund != null && oRefund.Refund_ID != "default")
                                            {
                                                sSettleIDs += oSet.Refund_ID + ", ";
                                                ++iNoofSettlements;
                                            }
                                        }

                                        if (iNoofSettlements > 0)
                                            SEACCMessageBox.Show("Can not Update..", "This IOU is settled with following Expenditures / Refunds \n" + sSettleIDs, MessageBoxButton.OK);
                                        else
                                        {
                                            tbl_pcbTxIOU oIOU = new tbl_pcbTxIOU(txtIOUID.Tag.ToString(), dtpIOUDate.GetDateTime().Date, sPCAccountID, txtRequestID.Tag.ToString(), lblRequestedByVal.Tag.ToString(), txtRemarks.Text, decimal.Parse(txtAmount.Text), oOldIOU.SettledAmount, oOldIOU.IsSettled, oOldIOU.IsCanceled, oOldIOU.CreateUser_ID, clsSecurity.UserIDLoged, oOldIOU.CanceldUser_ID, oOldIOU.DateCreate, clsSecurity.getServerDateTime(), oOldIOU.DateCanceled, oOldIOU.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldIOU.CanceledUserTerminal_ID);
                                            oIOU.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        }
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Update..", "This IOU is already cancelled", MessageBoxButton.OK);
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
                                    txtIOUID.Tag = SEACC_Form.getAutoGeneratedCode();

                                tbl_pcbTxIOU oNewAcc = new tbl_pcbTxIOU(txtIOUID.Tag.ToString(), dtpIOUDate.GetDateTime().Date, sPCAccountID, txtRequestID.Tag.ToString(), lblRequestedByVal.Tag.ToString(), txtRemarks.Text, decimal.Parse(txtAmount.Text), 0, false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                                oNewAcc.Insert();

                                if (txtRequestID.Tag.ToString() != "default")
                                {
                                    tbl_pcbTxIOURequest oIOUReq = tbl_pcbTxIOURequest.Select(txtRequestID.Tag.ToString());
                                    oIOUReq.IsSettled = true;
                                    oIOUReq.Update();
                                }
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                        }
                        #endregion
                    }
                  //  else
                    //    SEACCMessageBox.Show("", "Please Select a IOU Request..", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                    SEACCExeption.Show(ex);
                }
                finally
                {
                   if( txtIOUID.Tag!= null)
                       fillDetails(txtIOUID.Tag.ToString());
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
                    if (txtIOUID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_pcbTxIOU Details = tbl_pcbTxIOU.Select(txtIOUID.Tag.ToString());
                            if (Details != null)
                            {
                                if (!Details.IsCanceled)
                                {
                                    #region Remove Settlement
                                    foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByIou_ID(txtIOUID.Tag.ToString()))
                                    {
                                        #region Update settle amount Expenditure / IOU Refund
                                        tbl_pcbTxExpenditure oExp = tbl_pcbTxExpenditure.Select(oSet.Expenditure_ID);
                                        if (oExp != null && oExp.Expenditure_ID!="default")
                                        {
                                            oExp.AllocatedAmount -= oSet.AllocatedAmount;
                                            oExp.Update();
                                        }

                                        tbl_pcbTxIOURefund oRefund = tbl_pcbTxIOURefund.Select(oSet.Refund_ID);
                                        if (oRefund != null && oRefund.Refund_ID!="default")
                                        {
                                            oRefund.SettledAmount -= oSet.AllocatedAmount;
                                            oRefund.IsSettled = false;
                                            oRefund.Update();
                                        }
                                        #endregion

                                        oSet.Delete();
                                    }
                                    #endregion

                                    Details.IsCanceled = true;
                                    Details.DateCanceled = clsSecurity.getServerDateTime();
                                    Details.CanceldUser_ID = clsSecurity.UserIDLoged;
                                    Details.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                    Details.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    ClearFields();
                                }
                                else
                                    SEACCMessageBox.Show("Can not Cancel..", "This IOU is already cancelled", MessageBoxButton.OK);
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
                if (CheckValidity_Amount())
                    //{
                    //    if (CheckValidity_DuplicateFiled())
                    //    {
                    //        if (ChekValidity_DuplicateNames())
                    bStatus = true;
            //    }
            //}
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (txtRequestID.Tag == null)
            {
                txtRequestID.Tag = "default";
                lblRequestedByVal.Tag = clsSecurity.UserIDLoged;

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

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                if (txtRequestID.Tag == null)
                    txtRequestID.Tag = "default";
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            //cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtIOUID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtIOUID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRequestID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, true, true, false);
            
            dtpIOUDate.SetTime(clsSecurity.getServerDateTime());
            lblCancel.Visibility = Visibility.Collapsed;

            txtIOUID.Tag = null;
            txtRequestID.Tag = null;

            txtIOUID.Text = "";
            txtRequestID.Text = "";           
            txtRemarks.Text = "";
            txtAmount.Text = "0.00";

            lblDateVal.Text = "";
            lblRequestedByVal.Text = "";
            lblRemarksVal.Text = "";
            lblAmountVal.Text = "0.00";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtIOUID.setReadOnlyStatus(true);
                txtIOUID.Text = "<Auto Generate>";
            }
            else
                txtIOUID.setReadOnlyStatus(false);
        }
        #endregion

        #region FillDetails
        public void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbTxIOU detail = tbl_pcbTxIOU.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtIOUID, false, false, false);

                        txtIOUID.Tag = detail.Iou_ID;
                        txtIOUID.Text = detail.Iou_ID;
                        txtAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.IouAmount).ToString();
                        txtRemarks.Text = detail.Remarks;
                        txtRequestID.Tag = detail.IouRequest_ID;
                        txtRequestID.Text = detail.IouRequest_ID;
                        dtpIOUDate.SetTime(detail.IouDate);

                        tbl_pcbTxIOURequest oIOUReq = tbl_pcbTxIOURequest.Select(detail.IouRequest_ID);
                        lblDateVal.Text = clsFormatter.FormatDate_Short(oIOUReq.IouRequestDate).ToString();
                        lblRequestedByVal.Tag = oIOUReq.IouRequestedUser_ID;
                        lblRequestedByVal.Text = clsGenaralName.getName_User(oIOUReq.IouRequestedUser_ID);
                        lblAmountVal.Text = clsFormatter.FormatDecimalPlaces_Price(oIOUReq.RequestAmount).ToString();
                        lblRemarksVal.Text = oIOUReq.Remarks;

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

        #region Search Events
        private void txtRequestID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClearFields();

            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOURequest);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_pcbTxIOURequest oRequest = tbl_pcbTxIOURequest.Select(lstResult[0]);
                if (oRequest != null)
                {
                    if (!oRequest.IsCanceled)
                    {
                        if (!oRequest.IsSettled)
                        {
                            txtRequestID.Tag = lstResult[0];
                            txtRequestID.Text = lstResult[0];
                            lblDateVal.Text = lstResult[1];
                            lblRequestedByVal.Tag = lstResult[2];
                            lblRequestedByVal.Text = lstResult[3];
                            lblAmountVal.Text = clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[4]));
                            lblRemarksVal.Text = lstResult[5];
                        }
                        else
                            SEACCMessageBox.Show("Please select another request", "Can not add already settled request..", MessageBoxButton.OK);
                    }
                    else
                        SEACCMessageBox.Show("Please select another request", "Can not add already cancelled request..", MessageBoxButton.OK);
                }
            }
        }

        private void txtIOUID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frm_search RowDataSearch = null;
            lstParameeters.Add(sPCAccountID);
            lstParameeters.Add("");
            lstParameeters.Add("");

            RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOU);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
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
    }
}