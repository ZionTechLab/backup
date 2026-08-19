using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
using SEACC_PCB.UserControls;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZION.PCB.Reports;

namespace ZION.PCB.Transaction_Forms
{
    /// <summary>
    /// Interaction logic for frm_AddExpenditure.xaml
    /// </summary>
    public partial class frm_AddExpenditure : Window
    {
        #region Class Variables  
        public event EventHandler Updated;
        DataTable dtIOUSet = new DataTable();
        DataTable dtCategory = new DataTable();
        public string sPCAccountID;
        public decimal dAvailableBal;
        int iSelectedRow = -1, iSelectedRowCat = -1;
        #endregion

        #region Form Load
        public frm_AddExpenditure(string _PCAccountID, decimal _dAvailableBal,bool isViewMode)
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_AddExpenditure;
            SEACC_Form.Initialize();
            sPCAccountID = _PCAccountID;
            dAvailableBal = _dAvailableBal;
            #endregion

            #region PCB Data Table
            dtIOUSet.Columns.Add("IOUNo");
            dtIOUSet.Columns.Add("Amnt");
            dtIOUSet.Columns.Add("UnSetAmnt");
            dtIOUSet.Columns.Add("AlloAmnt");

            dtCategory.Columns.Add("ExpCatID");
            dtCategory.Columns.Add("ExpCategory");
            dtCategory.Columns.Add("Amount");
            dtCategory.Columns.Add("Remarks");
            #endregion

            #region Initialize Action Buttons
            if (isViewMode)
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
                if (txtExpenditureID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enum_ReportName.pcb_Expenditure);
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.pcb_Expenditure);
                        if (oReports != null)
                        {
                            ZION.PCB.Reports.DataSets.dts_ReportExport glb_dts_ExportReport = new ZION.PCB.Reports.DataSets.dts_ReportExport();
                            ZION.PCB.Reports.DataSets.dts_PettyCash dts_pettyCash = new ZION.PCB.Reports.DataSets.dts_PettyCash();
                            dts_pettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            var details = tbl_pcbTxExpenditure.Select(txtExpenditureID.Text.ToString());
                            if (details != null)
                            {
                                //dts_pettyCash.dt_Expenditure.Adddt_ExpenditureRow(details.Expenditure_ID, details.ExpenditureDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID), details.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpCategory(details.PcbExpenditureCategory_ID), details.SpentUser_ID, clsGenaralName.getName_User(details.SpentUser_ID), details.Cost_Center_ID, "", details.Amount, details.Remarks, "");
                               
                                string s = "";
                                foreach (tbl_pcbTxIOUSettlement oIOUSettlement in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(details.Expenditure_ID))
                                {
                                    s = oIOUSettlement.IouSettlementID;
                                    dts_pettyCash.dt_IOUSettlement.Adddt_IOUSettlementRow(oIOUSettlement.IouSettlementID, "", oIOUSettlement.Expenditure_ID, oIOUSettlement.Refund_ID, oIOUSettlement.Iou_ID, 0, oIOUSettlement.AllocatedAmount);

                                    tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(oIOUSettlement.Iou_ID);
                                    if (oIOU != null)
                                    {
                                        //dts_pettyCash.dt_IOU.Adddt_IOURow(oIOUSettlement.Iou_ID, oIOU.IouDate, "", "", "", "", "default", "", oIOU.IouAmount, 0, oIOU.Remarks, false,
                                        //    oIOU.IouRequest_ID, DateTime.MinValue, "", "", "", "", "", 0, "");
                                        dts_pettyCash.dt_IOU.Adddt_IOURow(oIOUSettlement.Iou_ID, oIOU.IouDate, "", "", "", "", "default", "", oIOU.IouAmount, 0, oIOU.Remarks, false, oIOU.IouRequest_ID);
                                    }
                                }

                                foreach (tbl_pcbTxExpenditure_Detail oTxExpenditureDetail in tbl_pcbTxExpenditure_Detail.SelectAll().Where(p=> p.Expenditure_ID == details.Expenditure_ID))
                                {
                                    dts_pettyCash.dt_ExpenditureDetail.Adddt_ExpenditureDetailRow(oTxExpenditureDetail.Expenditure_ID, oTxExpenditureDetail.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpenditureCategory(oTxExpenditureDetail.PcbExpenditureCategory_ID), oTxExpenditureDetail.Remarks, oTxExpenditureDetail.Amount);
                                }

                                dts_pettyCash.dt_Expenditure.Adddt_ExpenditureRow(details.Expenditure_ID, details.ExpenditureDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID),"","", details.SpentUser_ID, clsGenaralName.getName_User(details.SpentUser_ID), details.Cost_Center_ID, clsGenaralName.getName_CostCenter1(details.Cost_Center_ID), details.TotalAmount, details.Remarks, "");

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
                            tbl_pcbTxExpenditure oOldExp = tbl_pcbTxExpenditure.Select(txtExpenditureID.Tag.ToString());
                            if (oOldExp != null)
                            {
                                if (!oOldExp.IsCanceled)
                                {
                                    if (!oOldExp.IsReimburst)
                                    {
                                        #region Remove Exp. Details
                                        foreach (tbl_pcbTxExpenditure_Detail oDetail in tbl_pcbTxExpenditure_Detail.SelectAll().Where(p => p.Expenditure_ID == txtExpenditureID.Tag.ToString()))
                                        {
                                            oDetail.Delete();
                                        }
                                        #endregion

                                        #region Remove Settlement
                                        foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(txtExpenditureID.Tag.ToString()))
                                        {
                                            #region IOU Update
                                            tbl_pcbTxIOU oOldIOU = tbl_pcbTxIOU.Select(oSet.Iou_ID);
                                            if (oOldIOU != null)
                                            {
                                                oOldIOU.IsSettled = false;
                                                oOldIOU.SettledAmount -= oSet.AllocatedAmount;
                                                oOldIOU.Update();
                                            }
                                            #endregion

                                            oSet.Delete();
                                        }
                                        #endregion

                                        decimal dExpenditureAmount = decimal.Parse(txtAmount.Text);
                                        decimal dTotalAllocation = 0;

                                        #region Add Exp. Detail
                                        if (dtCategory.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in dtCategory.Rows)
                                            {
                                                string sCatID = row["ExpCatID"].ToString();
                                                decimal dCatAmount = decimal.Parse(row["Amount"].ToString());
                                                string sRemarks = row["Remarks"].ToString();

                                                tbl_pcbTxExpenditure_Detail oExpDetail = new tbl_pcbTxExpenditure_Detail(txtExpenditureID.Tag.ToString(), sCatID, sRemarks, dCatAmount);
                                                oExpDetail.Insert();
                                            }
                                        }
                                        #endregion

                                        #region Add IOU Settlement
                                        //if (dtIOUSet.Rows.Count > 0)
                                        //{
                                        //    foreach (DataRow row in dtIOUSet.Rows)
                                        //    {
                                        //        string sIOUID = row["IOUNo"].ToString();
                                        //        decimal dAmountIOU = decimal.Parse(row["Amnt"].ToString());
                                        //                                                  decimal dAllocatedAmount = 0;

                                        //        tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                        //        if (oIOU != null)
                                        //        {
                                        //            decimal dAmountIOU_UnSettled = oIOU.IouAmount - oIOU.SettledAmount;

                                        //            if (dAmount < dAmountIOU_UnSettled)
                                        //            {
                                        //                oIOU.SettledAmount += dAmount;
                                        //                dAllocatedAmount = dAmount;
                                        //            }
                                        //            else
                                        //            {
                                        //                oIOU.SettledAmount = oIOU.IouAmount;
                                        //                oIOU.IsSettled = true;
                                        //                dAmount -= dAmountIOU_UnSettled;
                                        //                dAllocatedAmount = dAmountIOU_UnSettled;
                                        //            }
                                        //            oIOU.Update();

                                        //            SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                        //            tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), txtExpenditureID.Tag.ToString(), sIOUID, "default", dAllocatedAmount);
                                        //            oIOUSet.Insert();

                                        //            dExpAllocateAmnt += dAllocatedAmount;
                                        //            SEACC_Form.enmFormName = FormName.PCB_AddExpenditure;
                                        //        }

                                        //        if (dExpAllocateAmnt == decimal.Parse(txtAmount.Text))
                                        //            break;

                                        //    }
                                        //}

                                        //tbl_pcbTxExpenditure oExpenditure = new tbl_pcbTxExpenditure(txtExpenditureID.Tag.ToString(), dtpExpDate.GetDateTime().Date, sPCAccountID, txtSpentBy.Tag.ToString(), txtCostCentre.Tag.ToString(), txtRemarks.Text, 
                                        //    decimal.Parse(txtAmount.Text), dExpAllocateAmnt, oOldExp.Reimbursment_ID, oOldExp.IsReimburst, oOldExp.IsCanceled, oOldExp.CreateUser_ID, clsSecurity.UserIDLoged, oOldExp.CanceldUser_ID, oOldExp.DateCreate, clsSecurity.getServerDateTime(), oOldExp.DateCanceled, oOldExp.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldExp.CanceledUserTerminal_ID);
                                        //oExpenditure.Update();
                                        #endregion

                                        #region Add IOU Settlement
                                        if (dtIOUSet.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in dtIOUSet.Rows)
                                            {
                                                string sIOUID = row["IOUNo"].ToString();
                                                tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                                if (oIOU != null)
                                                {
                                                    decimal dAmountIOU_UnSettled = oIOU.IouAmount - oIOU.SettledAmount;
                                                    decimal dAllocatedAmount = 0;
                                                    if (dExpenditureAmount < dAmountIOU_UnSettled)
                                                    {
                                                        dAllocatedAmount = dExpenditureAmount;
                                                        oIOU.SettledAmount += dAllocatedAmount;

                                                    }
                                                    else
                                                    {
                                                        dAllocatedAmount = dAmountIOU_UnSettled;
                                                        oIOU.SettledAmount = dAllocatedAmount;
                                                        oIOU.IsSettled = true;

                                                    }
                                                    oIOU.Update();

                                                    SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                                    tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), txtExpenditureID.Tag.ToString(), sIOUID, "default", dAllocatedAmount);
                                                    oIOUSet.Insert();

                                                    dExpenditureAmount -= dAllocatedAmount;
                                                    dTotalAllocation += dAllocatedAmount;
                                                    SEACC_Form.enmFormName = FormName.PCB_AddExpenditure;
                                                }
                                            }

                                            //tbl_pcbTxExpenditure oExpenditure = new tbl_pcbTxExpenditure(txtExpenditureID.Tag.ToString(), dtpExpDate.GetDateTime().Date, sPCAccountID, txtSpentBy.Tag.ToString(), txtCostCentre.Tag.ToString(), txtRemarks.Text,
                                            //    decimal.Parse(txtAmount.Text), dTotalAllocation, oOldExp.Reimbursment_ID, oOldExp.IsReimburst, oOldExp.IsCanceled, oOldExp.CreateUser_ID, clsSecurity.UserIDLoged, oOldExp.CanceldUser_ID, oOldExp.DateCreate, clsSecurity.getServerDateTime(), oOldExp.DateCanceled, oOldExp.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldExp.CanceledUserTerminal_ID);
                                            //oExpenditure.Update();

                                            //tbl_pcbTxExpenditure oEx = tbl_pcbTxExpenditure.Select(txtExpenditureID.Tag.ToString());
                                            //oEx.AllocatedAmount = dTotalAllocation;
                                            //oEx.Update();
                                        }
                                        #endregion

                                        tbl_pcbTxExpenditure oExpenditure = new tbl_pcbTxExpenditure(txtExpenditureID.Tag.ToString(), dtpExpDate.GetDateTime().Date, sPCAccountID, txtSpentBy.Tag.ToString(), txtCostCentre.Tag.ToString(), txtRemarks.Text,
                                               decimal.Parse(txtAmount.Text), dTotalAllocation, oOldExp.Reimbursment_ID, oOldExp.IsReimburst, oOldExp.IsCanceled, oOldExp.CreateUser_ID, clsSecurity.UserIDLoged, oOldExp.CanceldUser_ID, oOldExp.DateCreate, clsSecurity.getServerDateTime(), oOldExp.DateCanceled, oOldExp.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldExp.CanceledUserTerminal_ID);
                                        oExpenditure.Update();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Update..", "This Expenditure is already reimbursed", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Update..", "This Expenditure is already cancelled", MessageBoxButton.OK);
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
                                //txtExpenditureID.Tag = SEACC_Form.getAutoGeneratedCode();
                                txtExpenditureID.Tag = SEACC_PCB.UserControls.clsCommon.getAutoGeneratedCodePCBExpenditure(sPCAccountID);

                            if (txtExpenditureID.Tag.ToString() != "")
                            {
                                decimal dExpenditureAmount = decimal.Parse(txtAmount.Text);
                                decimal dTotalAllocation = 0;

                                tbl_pcbTxExpenditure oNewEx = new tbl_pcbTxExpenditure(txtExpenditureID.Tag.ToString(), dtpExpDate.GetDateTime().Date, sPCAccountID, txtSpentBy.Tag.ToString(), txtCostCentre.Tag.ToString(), txtRemarks.Text, dExpenditureAmount, dTotalAllocation, "default", false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                                //tbl_pcbTxExpenditure oNewEx = new tbl_pcbTxExpenditure(txtExpenditureID.Tag.ToString(), dtpExpDate.GetDateTime().Date, null, txtSpentBy.Tag.ToString(), txtCostCentre.Tag.ToString(), txtRemarks.Text, dExpenditureAmount, dTotalAllocation, "default", false, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                                oNewEx.Insert();

                                #region Add Exp. Detail
                                if (dtCategory.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtCategory.Rows)
                                    {
                                        string sCatID = row["ExpCatID"].ToString();
                                        decimal dCatAmount = decimal.Parse(row["Amount"].ToString());
                                        string sRemarks = row["Remarks"].ToString();

                                        tbl_pcbTxExpenditure_Detail oExpDetail = new tbl_pcbTxExpenditure_Detail(txtExpenditureID.Tag.ToString(), sCatID, sRemarks, dCatAmount);
                                        oExpDetail.Insert();
                                    }
                                }
                                #endregion

                                #region Add IOU Settlement
                                if (dtIOUSet.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtIOUSet.Rows)
                                    {
                                        string sIOUID = row["IOUNo"].ToString();
                                        tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                        if (oIOU != null)
                                        {
                                            decimal dAmountIOU_UnSettled = oIOU.IouAmount - oIOU.SettledAmount;
                                            decimal dAllocatedAmount = 0;
                                            if (dExpenditureAmount < dAmountIOU_UnSettled)
                                            {
                                                dAllocatedAmount = dExpenditureAmount;
                                                oIOU.SettledAmount += dAllocatedAmount;

                                            }
                                            else
                                            {
                                                dAllocatedAmount = dAmountIOU_UnSettled;
                                                oIOU.SettledAmount = dAllocatedAmount;
                                                oIOU.IsSettled = true;

                                            }
                                            oIOU.Update();

                                            SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                            tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), txtExpenditureID.Tag.ToString(), sIOUID, "default", dAllocatedAmount);
                                            oIOUSet.Insert();

                                            dExpenditureAmount -= dAllocatedAmount;
                                            dTotalAllocation += dAllocatedAmount;
                                            SEACC_Form.enmFormName = FormName.PCB_AddExpenditure;
                                        }
                                    }

                                    tbl_pcbTxExpenditure oEx = tbl_pcbTxExpenditure.Select(txtExpenditureID.Tag.ToString());
                                    oEx.AllocatedAmount = dTotalAllocation;
                                    oEx.Update();

                                    //    foreach (DataRow row in dtIOUSet.Rows)
                                    //{
                                    //    string sIOUID = row["IOUNo"].ToString();
                                    //    decimal dAmountIOU = decimal.Parse(row["Amnt"].ToString());
                                    //    decimal dAmountIOU_UnSettled = decimal.Parse(row["UnSetAmnt"].ToString());
                                    //    decimal dAllocatedAmount = 0;

                                    //    tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(sIOUID);
                                    //    if (oIOU != null)
                                    //    {
                                    //        if (dExpenditureAmount < dAmountIOU_UnSettled)
                                    //        {
                                    //            oIOU.SettledAmount += dExpenditureAmount;
                                    //            dAllocatedAmount = dExpenditureAmount;
                                    //        }
                                    //        else
                                    //        {
                                    //            oIOU.SettledAmount = oIOU.IouAmount;
                                    //            oIOU.IsSettled = true;
                                    //            dExpenditureAmount -= dAmountIOU_UnSettled;
                                    //            dAllocatedAmount = dAmountIOU_UnSettled;
                                    //        }
                                    //        oIOU.Update();

                                    //        SEACC_Form.enmFormName = FormName.PCB_IOUSettlement;
                                    //        tbl_pcbTxIOUSettlement oIOUSet = new tbl_pcbTxIOUSettlement(SEACC_Form.getAutoGeneratedCode(), txtExpenditureID.Tag.ToString(), sIOUID, "default", dAllocatedAmount);
                                    //        oIOUSet.Insert();

                                    //        dExpAllocateAmnt += dAllocatedAmount;
                                    //        SEACC_Form.enmFormName = FormName.PCB_AddExpenditure;
                                    //    }
                                    //}
                                }
                                #endregion

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                            {
                                SEACCMessageBox.Show("", "Please add a prefix for this Account ", MessageBoxButton.OK);
                            }
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
                    fillDetails(txtExpenditureID.Tag.ToString());

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
                    if (txtExpenditureID.Tag != null)
                    {                        
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_pcbTxExpenditure Details = tbl_pcbTxExpenditure.Select(txtExpenditureID.Tag.ToString());
                            if (Details != null)
                            {
                                if (!Details.IsCanceled)
                                {
                                    if (!Details.IsReimburst)
                                    {
                                        #region Remove Settlement

                                        decimal dOldAllocatedAmount = 0;
                                        foreach (tbl_pcbTxIOUSettlement oSet in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(txtExpenditureID.Tag.ToString()))
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
                                        Details.AllocatedAmount -= dOldAllocatedAmount;
                                        Details.Update();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Cancel..", "This Expenditure is already reimbursed", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Cancel..", "This Expenditure is already cancelled", MessageBoxButton.OK);
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
                //if (CheckValidity_ExpenditureDate())
                //{
                    if (CheckValidity_TotalAmount())
                    {
                        bStatus = true;
                    }
                //}
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(txtCategory))

            if (dgr_Category.Items.Count <= 0)
            {
                SEACCMessageBox.Show("", "Please select at least one Expenditure Category..", MessageBoxButton.OK);
            }                           
            if (!clsValidation.Validate_EmptyValue(txtSpentBy))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_TotalAmount()
        {
            bool bStatus = true;

            if (txtAmount.Text == "0.00")
            {
                SEACCMessageBox.Show("", "Amount should be greater than 0", MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }

        private bool CheckValidity_ExpCategoryAmount()
        {
            bool bStatus = true;
            string sCategories = "";

            foreach (DataRow row in dtCategory.Rows)
            {
                string sCatID = row["ExpCatID"].ToString();
                string sCatName = row["ExpCategory"].ToString();
                decimal dCatAmount = decimal.Parse(row["Amount"].ToString());

                if (dCatAmount == 0)
                {
                    sCategories += sCatName + ", ";
                    bStatus = false;
                    break;
                }
            }

            if (!bStatus)
                SEACCMessageBox.Show("", "Amount should be greater than 0 for " + sCategories, MessageBoxButton.OK);

            return bStatus;
        }

        private bool CheckValidity_AvailableBalanceVsExpAmount()
        {
            bool bStatus = true;

            if (decimal.Parse(txtAmount.Text) > dAvailableBal)
            {
                SEACCMessageBox.Show("", "Expenditure Amount should be less than Available balance " + clsFormatter.FormatDecimalPlaces_Price(dAvailableBal), MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_ExpenditureDate()
        {
            bool bStatus = true;

            if (dtpExpDate.GetDateTime().Date > clsSecurity.getServerDateTime().Date)
            {
                SEACCMessageBox.Show("", "Expenditure Date should not be a future date..", MessageBoxButton.OK);
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

            //cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtExpenditureID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtExpenditureID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSpentBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCostCentre, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, false, true, false);

            dtpExpDate.SetTime(clsSecurity.getServerDateTime());

            lblCancel.Visibility = Visibility.Collapsed;

            txtExpenditureID.Tag = null;
            //txtCategory.Tag = null;
            txtSpentBy.Tag = null;
            txtCostCentre.Tag = null;

            txtExpenditureID.Text = "";
            //txtCategory.Text = "";
            txtSpentBy.Text = "";
            txtCostCentre.Text = "";
            txtRemarks.Text = "";
            txtAmount.Text = "0.00";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtExpenditureID.setReadOnlyStatus(true);
                txtExpenditureID.Text = "<Auto Generate>";
            }
            else
                txtExpenditureID.setReadOnlyStatus(false);

            dtIOUSet.Rows.Clear();
            dtCategory.Rows.Clear();
        }
        #endregion

        #region FillDetails
        public void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbTxExpenditure detail = tbl_pcbTxExpenditure.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtExpenditureID, false, false, false);

                        txtExpenditureID.Tag = detail.Expenditure_ID;
                        txtExpenditureID.Text = detail.Expenditure_ID;
                        //txtCategory.Tag = detail.PcbExpenditureCategory_ID;
                        //txtCategory.Text = clsGenaralName.getName_ExpenditureCategory(detail.PcbExpenditureCategory_ID);
                        txtSpentBy.Tag = detail.SpentUser_ID;
                        txtSpentBy.Text = clsGenaralName.getName_User(detail.SpentUser_ID);
                        txtCostCentre.Tag = detail.Cost_Center_ID;  
                        txtCostCentre.Text = clsGenaralName.getName_CostCenter1(detail.Cost_Center_ID);                   
                        txtRemarks.Text = detail.Remarks;
                        txtAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount).ToString();
                        dtpExpDate.SetTime(detail.ExpenditureDate);

                        if (detail.IsCanceled)
                            lblCancel.Visibility = Visibility.Visible;
                        else
                            lblCancel.Visibility = Visibility.Collapsed;

                        dtIOUSet.Rows.Clear();
                        dtCategory.Rows.Clear();

                        foreach (tbl_pcbTxIOUSettlement details_Sett in tbl_pcbTxIOUSettlement.SelectAllByExpenditure_ID(detail.Expenditure_ID))
                        {
                            tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(details_Sett.Iou_ID);
                            dtIOUSet.Rows.Add(details_Sett.Iou_ID, clsFormatter.FormatDecimalPlaces_Price(oIOU.IouAmount), clsFormatter.FormatDecimalPlaces_Price(oIOU.IouAmount - oIOU.SettledAmount), clsFormatter.FormatDecimalPlaces_Price(details_Sett.AllocatedAmount));
                            dgr_IOUSet.ItemsSource = dtIOUSet.DefaultView;
                        }

                        foreach (tbl_pcbTxExpenditure_Detail expDetails in tbl_pcbTxExpenditure_Detail.SelectAll().Where(p=> p.Expenditure_ID == detail.Expenditure_ID))
                        {
                            dtCategory.Rows.Add(expDetails.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpenditureCategory(expDetails.PcbExpenditureCategory_ID), clsFormatter.FormatToCurrecyWithThousendSep(expDetails.Amount), expDetails.Remarks);
                            dgr_Category.ItemsSource = dtCategory.DefaultView;
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

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (SEACC_Form.ActualWidth < 850)
            //    coloumnA.Width = new GridLength(210);
            //else
            //    coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Search events
        private void txtSpentBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtSpentBy.Tag = lstResult[0];
                txtSpentBy.Text = lstResult[1];
                txtCostCentre.Tag = "default";
            }
        }

        private void txtCostCentre_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.zCost_Centre1);
            if (RowDataSearch.DialogResult == true)
            {
                txtCostCentre.Tag = lstResult[0];
                txtCostCentre.Text = lstResult[1];
            }
        }

        //private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    frm_search RowDataSearch = new frm_search(false);
        //    RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_ExpCategory);
        //    if (RowDataSearch.DialogResult == true)
        //    {
        //        txtCategory.Tag = lstResult[3];
        //        txtCategory.Text = lstResult[4];
        //    }
        //}

        private void txtExpenditureID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frm_search RowDataSearch = null;
            lstParameeters.Add(sPCAccountID);
            RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_TransactionExpenditure);
            if (RowDataSearch.DialogResult == true)
            {
                //txtExpenditureID.Tag = lstResult[0];
                //txtExpenditureID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Grid Add Button
        private void btnGridAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSpentBy.Tag != null)
            {
                bool bShowIOU = true;
                string sMessage = "";

                if (decimal.Parse(txtAmount.Text) > 0)
                {
                    if (SEACC_Form.IsUpdateMode && txtExpenditureID.Tag != null)
                    {
                        tbl_pcbTxExpenditure oEx = tbl_pcbTxExpenditure.Select(txtExpenditureID.Tag.ToString());
                        if (oEx.IsCanceled)
                        {
                            bShowIOU = false;
                            sMessage = "This Expenditure is already cancelled";
                        }
                        else if (decimal.Parse(txtAmount.Text) == oEx.AllocatedAmount)
                        {
                            bShowIOU = false;
                            sMessage = "This Expenditure is already settled";
                        }                        
                    }

                    #region Show IOUs
                    if (bShowIOU)
                    {
                        List<string> lstParameeters = new List<string>();
                        lstParameeters.Add(sPCAccountID);
                        lstParameeters.Add(txtSpentBy.Tag.ToString());
                        lstParameeters.Add("0");

                        frm_search RowDataSearch = new frm_search(lstParameeters);
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_IOU);
                        if (RowDataSearch.DialogResult == true)
                        {
                            tbl_pcbTxIOU oIOU = tbl_pcbTxIOU.Select(lstResult[0]);
                            if (oIOU != null)
                            {
                                if (!oIOU.IsCanceled)
                                {
                                    if (!oIOU.IsSettled)
                                    {
                                        try
                                        {
                                            bool bAddItem = false;
                                            DataRow[] items = dtIOUSet.Select("IOUNo ='" + lstResult[0] + "'");
                                            if (items.Length == 0)
                                                bAddItem = true;
                                            else
                                            {
                                                string sIOUNo = items[0]["IOUNo"].ToString();
                                            }

                                            #region Fill IOU Grid
                                            if (bAddItem)
                                            {
                                                if (txtExpenditureID.Tag != null)
                                                {
                                                    List<tbl_pcbTxIOUSettlement> oSet = tbl_pcbTxIOUSettlement.SelectAllByIou_ID(lstResult[0]).Where(p => p.Expenditure_ID == txtExpenditureID.Tag.ToString()).ToList();
                                                    if (oSet.Count > 0)
                                                        dtIOUSet.Rows.Add(lstResult[0], clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2])),
                                                            clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2]) - decimal.Parse(lstResult[3])),
                                                            //clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[3])));
                                                            clsFormatter.FormatDecimalPlaces_Price(oSet.FirstOrDefault().AllocatedAmount));

                                                    else
                                                        dtIOUSet.Rows.Add(lstResult[0], clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2])),
                                                                clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2]) - decimal.Parse(lstResult[3])),
                                                            //clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[3])));
                                                                0);
                                                }
                                                else
                                                    dtIOUSet.Rows.Add(lstResult[0], clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2])),
                                                            clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(lstResult[2]) - decimal.Parse(lstResult[3])),
                                                            0);

                                                dgr_IOUSet.ItemsSource = dtIOUSet.DefaultView;

                                            }
                                            #endregion

                                        }
                                        catch (Exception ex)
                                        {
                                            SEACCExeption.Show(ex);
                                        }
                                    }
                                    else
                                        SEACCMessageBox.Show("", "This IOU is already settled", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("", "This IOU is already cancelled", MessageBoxButton.OK);
                            }

                        }
                    }

                    else
                        SEACCMessageBox.Show("Can not Add IOU(s)..", sMessage, MessageBoxButton.OK);
                    #endregion
                }
                else
                    SEACCMessageBox.Show("", "Expenditure amount should be greater than 0", MessageBoxButton.OK);
            }
            else
                SEACCMessageBox.Show("", "Please select the spent by user", MessageBoxButton.OK);
        }

        private void btnGridCatAdd_Click(object sender, RoutedEventArgs e)
        {
            bool bIsDuplicate = false;
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_ExpCategory);
            if (RowDataSearch.DialogResult == true)
            {
                foreach (DataRow row in dtCategory.Rows)
                {
                    if (row["ExpCatID"].ToString() == lstResult[3])
                    {
                        bIsDuplicate = true;
                        break;
                    }
                }

                if (!bIsDuplicate)
                {
                    dtCategory.Rows.Add(lstResult[3], lstResult[4], 0);
                    dgr_Category.ItemsSource = dtCategory.DefaultView;
                }
                else
                    SEACCMessageBox.Show("", "This Category is already added..", MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Delete Button
        private void btnGridDelete_Click(object sender, RoutedEventArgs e)
        {
            if (iSelectedRow > -1)
            {
                dtIOUSet.Rows.RemoveAt(iSelectedRow);
                iSelectedRow = -1;
            }
            else
                SEACCMessageBox.Show("", "Please select a IOU to remove", MessageBoxButton.OK);
        }

        private void btnGridCatDel_Click(object sender, RoutedEventArgs e)
        {
            if (iSelectedRowCat > -1)
            {
                dtCategory.Rows.RemoveAt(iSelectedRowCat);
                iSelectedRowCat = -1;

                CalculateTotalAmount();
            }
            else
                SEACCMessageBox.Show("", "Please select a Expenditure Category to remove", MessageBoxButton.OK);
        }
        #endregion

        #region Button Close
        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();            
        }

        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }

                
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void dgr_IOUSet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            iSelectedRow = dgr_IOUSet.SelectedIndex;
        }

        private void dgr_Category_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            iSelectedRowCat = dgr_Category.SelectedIndex;
        }

        private void dgr_Category_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            CalculateTotalAmount();

            //var editedTextbox = e.EditingElement as TextBox;
            //decimal dTotAmount = decimal.Parse(editedTextbox.Text) + decimal.Parse(txtAmount.Text);
            //txtAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dTotAmount);
        }
               
        private void CalculateTotalAmount()
        {
            decimal dTotalAmount = 0;
            foreach (DataRow row in dtCategory.Rows)
            {
                decimal a = 0;
                decimal.TryParse(row["Amount"].ToString(),out a);
             

                dTotalAmount += a;
            }
            txtAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalAmount);
        }
    }
}