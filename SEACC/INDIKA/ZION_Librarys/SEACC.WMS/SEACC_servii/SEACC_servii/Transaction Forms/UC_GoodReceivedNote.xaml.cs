using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_servii.Search_Forms;
using SEACC_WPFControls;
using System.Data;
using SEACC_servii.Reports;
using System.ComponentModel;
using digiteq;
//using System.e

namespace SEACC_servii
{
    public partial class UC_GoodReceivedNote : UserControl
    {
        DataTable dt_detail = new DataTable();

        #region User Control Initialize
        public UC_GoodReceivedNote()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.GRN;
            SEACC_Form.Initialize();

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("grn_ID");
            dgr_Main.dt.Columns.Add("grn_Date");
            //dgr_Main.dt.Columns.Add("estimation_ID");
            dgr_Main.dt.Columns.Add("customer_ID");
            dgr_Main.dt.Columns.Add("customerName");
            dgr_Main.dt.Columns.Add("storeID");
            dgr_Main.dt.Columns.Add("storeName");
            dgr_Main.dt.Columns.Add("storagePeriod");
            dgr_Main.dt.Columns.Add("remarks");
            //dgr_Main.dt.Columns.Add("currency_ID");
            //dgr_Main.dt.Columns.Add("currencyRate");
            dgr_Main.dt.Columns.Add("subTotal");
            dgr_Main.dt.Columns.Add("discountPercentage");
            dgr_Main.dt.Columns.Add("discountTotal");
            dgr_Main.dt.Columns.Add("grandTotal");
            #endregion

            #region Initialize Detail Data Table 
            dt_detail.Columns.Add("LineNo");
            dt_detail.Columns.Add("itemID");
            dt_detail.Columns.Add("itemName");
            dt_detail.Columns.Add("Disc");
            dt_detail.Columns.Add("remarks1");
            dt_detail.Columns.Add("remarks2");
            dt_detail.Columns.Add("unitweight");
            dt_detail.Columns.Add("qty");
            dt_detail.Columns.Add("weight");
            dt_detail.Columns.Add("noOfPaletes");
            dt_detail.Columns.Add("damageGoods");
            dt_detail.Columns.Add("ExpDate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("GRN ID", "grn_ID", 80);
            dgr_Main.Add_DatagridColoumn("GRN Date", "grn_Date", 75);
            //dgr_Main.Add_DatagridColoumn("Estimation ID", "estimation_ID", 80);
            dgr_Main.Add_DatagridColoumn("Customer ID", "customer_ID", 80, false);
            dgr_Main.Add_DatagridColoumn("Customer Name", "customerName", 220);
            dgr_Main.Add_DatagridColoumn("Store ID", "storeID", 60, false);
            dgr_Main.Add_DatagridColoumn("Store Name", "storeName", 80);
            dgr_Main.Add_DatagridColoumn("Storage Period", "storagePeriod", 80);
            dgr_Main.Add_DatagridColoumn("Remarks", "remarks", 100);
            //dgr_Main.Add_DatagridColoumn("Currency ID", "currency_ID", 80);
            //dgr_Main.Add_DatagridColoumn("Currency Rate", "currencyRate", 120);
            dgr_Main.Add_DatagridColoumn("Sub Total", "subTotal", 10, false);
            dgr_Main.Add_DatagridColoumn("Discount Percentage", "discountPercentage", 10, false);
            dgr_Main.Add_DatagridColoumn("Discount Total", "discountTotal", 10, false);
            dgr_Main.Add_DatagridColoumn("Grand Total", "grandTotal", 10, false);
            #endregion

            #region Initialize Detail Data Grid
            dgr_details.ItemsSource = dt_detail.DefaultView;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                coloumnA.Width = new GridLength(200);
            else
                coloumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {

                string sGrnId = "";
                try
                {
                    int iPeriod = cmbtoragePeriod.GetSelectedIndex();
                    sGrnId = txtGRNID.Tag.ToString();
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_whTxn_GoodReceivedNote OldRecord = tbl_whTxn_GoodReceivedNote.Select(txtGRNID.Text.Trim());
                            if (OldRecord != null)
                            {

                                tbl_whTxn_GoodReceivedNote oDetail = new tbl_whTxn_GoodReceivedNote(txtGRNID.Text, dtpGRN.GetDateTime(), txtEstimation.Tag.ToString(), txtVehicleTracking.Tag.ToString(), txtCustomer.Tag.ToString(), txtStore.Tag.ToString(), iPeriod, txtRemark.Text, txtCurrency.Text, decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID,
                                    OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled, OldRecord.PrintCount);
                                oDetail.Update();

                                // tbl_whTxn_GoodReceivedNote_Detail.DeleteAllByGoodReceivedNote_ID(OldRecord.GoodReceivedNote_ID);
                                foreach (tbl_whTxn_GoodReceivedNote_Detail delDetails in tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(oDetail.GoodReceivedNote_ID))
                                {
                                    clsHelpMethods.Update_StoreStock(txtStore.Tag.ToString(), delDetails.Item_ID, txtCustomer.Tag.ToString(), -delDetails.Qty, -delDetails.GrossWeight);
                                    delDetails.Delete();
                                }
                                int lineNo = 0;
                                foreach (DataRow row in dt_detail.Rows)
                                {
                                    string sItemId = row["itemID"].ToString();
                                    string sDescription = row["Disc"].ToString();
                                    string sRemark1 = row["remarks1"].ToString();
                                    string sRemark2 = row["remarks2"].ToString();
                                    decimal dQty = decimal.Parse(row["qty"].ToString());
                                    decimal dUnitWeight = decimal.Parse(row["unitweight"].ToString());
                                    decimal dGrossWeight = decimal.Parse(row["weight"].ToString());
                                    decimal dNoOfPalete = decimal.Parse(row["noOfPaletes"].ToString());
                                    decimal dDamageGood = decimal.Parse(row["damageGoods"].ToString());
                                    DateTime dtmExpDate = clsValidation.Validate_DateTime(row["ExpDate"].ToString());

                                    lineNo++;
                                    tbl_whTxn_GoodReceivedNote_Detail details = new tbl_whTxn_GoodReceivedNote_Detail(lineNo.ToString(), txtGRNID.Text, txtStore.Tag.ToString(), sItemId, sDescription, sRemark1, sRemark2, dQty, 0, dUnitWeight, dGrossWeight, dNoOfPalete, dDamageGood, dtmExpDate);
                                    details.Insert();

                                    clsHelpMethods.Update_StoreStock(txtStore.Tag.ToString(), sItemId, txtCustomer.Tag.ToString(), dQty, dGrossWeight);
                                }

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion
                    #region Insert
                    else
                    {
                        tbl_whTxn_VehicleTracker veh_details = tbl_whTxn_VehicleTracker.Select(txtVehicleTracking.Tag.ToString());
                        veh_details.CheckoutTime = dtpOut.GetDateTime();
                        veh_details.Update();

                        tbl_whTxn_GoodReceivedNote est_details = new tbl_whTxn_GoodReceivedNote(txtGRNID.Tag.ToString(), dtpGRN.GetDateTime(), txtEstimation.Tag.ToString(), txtVehicleTracking.Tag.ToString(), txtCustomer.Tag.ToString(), txtStore.Tag.ToString(), iPeriod, txtRemark.Text, txtCurrency.Text, decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime, 0);
                        est_details.Insert();

                        int lineNo = 0;
                        foreach (DataRow row in dt_detail.Rows)
                        {
                            string sItemId = row["itemID"].ToString();
                            string sDescription = row["Disc"].ToString();
                            string sRemark1 = row["remarks1"].ToString();
                            string sRemark2 = row["remarks2"].ToString();
                            decimal dQty = decimal.Parse(row["qty"].ToString());
                            decimal dUnitWeight = decimal.Parse(row["unitweight"].ToString());
                            decimal dGrossWeight = decimal.Parse(row["weight"].ToString());
                            decimal dNoOfPalete = decimal.Parse(row["noOfPaletes"].ToString());
                            decimal dDamageGood = decimal.Parse(row["damageGoods"].ToString());
                            DateTime dtmExpDate = clsValidation.Validate_DateTime(row["ExpDate"].ToString());

                            lineNo++;
                            tbl_whTxn_GoodReceivedNote_Detail details = new tbl_whTxn_GoodReceivedNote_Detail(lineNo.ToString(), txtGRNID.Tag.ToString(), txtStore.Tag.ToString(), sItemId, sDescription, sRemark1, sRemark2, dQty, 0, dUnitWeight, dGrossWeight,dNoOfPalete, dDamageGood, dtmExpDate);
                            details.Insert();

                            clsHelpMethods.Update_StoreStock(txtStore.Tag.ToString(), sItemId, txtCustomer.Tag.ToString(), dQty, dGrossWeight);
                        }

                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

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
                    fillDetails(sGrnId);
                }
            }
        }


        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            dt_detail.Clear();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    bool status = true;
                    if (txtGRNID.Tag != null && txtGRNID.Tag.ToString() != "")
                    {
                        List<tbl_whTxn_GoodIssueNote_Detail> oGin = tbl_whTxn_GoodIssueNote_Detail.SelectAll().Where(r => r.GoodReceivedNote_ID == txtGRNID.Tag.ToString()).ToList();
                        foreach (tbl_whTxn_GoodIssueNote_Detail ogin_Detail in oGin)
                        {
                            if (ogin_Detail != null)
                            {
                                SEACCMessageBox.Show("", "Can not be Delete as already Issued..", MessageBoxButton.OK);
                                status = false;
                                break;
                            }
                        }

                        if (status)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                            if (bMessegeBoxResult)
                            {
                                tbl_whTxn_GoodReceivedNote detail = tbl_whTxn_GoodReceivedNote.Select(txtGRNID.Tag.ToString());
                                if (detail != null)
                                {
                                    detail.IsCanceled = true;
                                    detail.Date_Canceled = clsSecurity.getServerDateTime();
                                    detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                    detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                    detail.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    ClearFields();
                                    dt_detail.Clear();
                                    RefreshGrid();
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

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtGRNID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermisshion_ToUpdate())
                    {
                        //tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.EstimationDetail);
                        //if (oReports != null)
                        {
                            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                            DataSets.dts_GRN dts_GRN = new DataSets.dts_GRN();
                            dts_GRN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), "Good Received Note", "", "", clsSecurity.UserNameLoged, "");

                            tbl_whTxn_GoodReceivedNote details = tbl_whTxn_GoodReceivedNote.Select(txtGRNID.Tag.ToString());
                            if (details != null)
                            {
                                //fill data table
                                foreach (tbl_whTxn_GoodReceivedNote_Detail delDetails in tbl_whTxn_GoodReceivedNote_Detail.SelectAll().Where(p => p.GoodReceivedNote_ID == details.GoodReceivedNote_ID))
                                {
                                    dts_GRN.dt_GRNDetail.Adddt_GRNDetailRow(delDetails.GoodReceivedNote_ID, delDetails.Item_ID, clsRef_Name.get_Item_Name(delDetails.Item_ID), delDetails.Remarks1, clsRef_Name.get_UoM_ID(delDetails.Item_ID), clsRef_Name.get_UoM_Code(clsRef_Name.get_UoM_ID(delDetails.Item_ID)), decimal.Parse(clsRef_Name.get_Item_UnitPriceD15(delDetails.Item_ID)), delDetails.Qty, delDetails.UnitWeight, delDetails.GrossWeight);
                                }

                                dts_GRN.dt_GRN.Adddt_GRNRow(txtGRNID.Tag.ToString(), txtEstimation.Tag.ToString(), txtCustomer.Tag.ToString(), txtCustomer.Text, clsRef_Name.get_Customer_Address(txtCustomer.Tag.ToString()), details.Storage_Period.ToString(), txtRemark.Text, txtVehicleNo.Text, dtpIn.GetDateTime(), dtpOut.GetDateTime(), txtContainerNo.Text, details.UserID_Created);

                                frm_ReportViwer CRViwer = new frm_ReportViwer();
                                CRViwer.Print("\\Reports\\rpt_GRNDetail.rpt", dts_GRN, glb_dts_ExportReport.dt_rptParameter);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGRNID, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpGRN, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEstimation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtStore, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSubTotal, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountPercentage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountTotal, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGrandTotal, false, true, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtVehicleTracking, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtVehicleNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtContainerNo, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDriverNIC, false, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpIn, false, true);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpOut, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDriverName, false, false, false);

            txtGRNID.Tag = null;
            txtVehicleTracking.Tag = null;
            txtEstimation.Tag = "default";
            txtCustomer.Tag = null;
            txtStore.Tag = null;

            txtVehicleNo.Text = "";
            txtContainerNo.Text = "";
            txtDriverNIC.Text = "";
            txtDriverName.Text = "";
            dtpIn.SetTime(DateTime.Now);
            dtpOut.SetTime(DateTime.Now);

            dtpGRN.SetTime(DateTime.Now);
            txtVehicleTracking.Text = "";
            txtEstimation.Text = "";
            txtCustomer.Text = "";
            txtStore.Text = "";
            txtRemark.Text = "";

            txtSubTotal.Text = "0.0";
            txtDiscountPercentage.Text = "0.0";
            txtDiscountTotal.Text = "0.0";
            txtGrandTotal.Text = "0.0";

            txtSubTotal.Tag = 0;
            txtDiscountPercentage.Tag = 0;
            txtDiscountTotal.Tag = 0;
            txtGrandTotal.Tag = 0;
           
            cmbtoragePeriod.comboBox.ItemsSource = clsCommon.getEnumDescription(typeof(StoragePeriod));
            cmbtoragePeriod.SetSelectedIndex(-1);

            //tbl_zCurrency details = tbl_zCurrency.Select(clsConfig.DefaultCurrency);
            //if (details != null)
            //{
            //    txtCurrency.Text = details.Currency_ID;
            //    txtCurrencyRate.Text = details.CurrencyRate.ToString();
            //}
            txtCurrency.Text = "LKR/001";
            txtCurrencyRate.Text = "1.00";

            dt_detail.Clear();

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGRNID.setReadOnlyStatus(true);
                txtGRNID.Text = "<Auto Generate>";
            }
            else
                txtGRNID.setReadOnlyStatus(false);
        }
        #endregion
                
        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_whTxn_GoodReceivedNote item in tbl_whTxn_GoodReceivedNote.SelectAll().Where(p => p.GoodReceivedNote_ID != "default" && !p.IsCanceled))
                {

                    dgr_Main.dt.Rows.Add(item.GoodReceivedNote_ID, clsValidation.GetDisplayValue_Date(item.GoodReceivedNote_Date), item.Customer_ID, clsRef_Name.get_Customer_Name(item.Customer_ID), item.Store_ID, clsRef_Name.get_Store_Name(item.Store_ID), ((StoragePeriod)item.Storage_Period).ToString(), item.Remarks, cls_Formater.FormatDecimal(item.SubTotal, 2), cls_Formater.FormatDecimal(item.DiscountPercentage, 2), cls_Formater.FormatDecimal(item.DiscountTotal, 2), cls_Formater.FormatDecimal(item.GrandTotal, 2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }


        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_Qty())
                {
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (CheckValidity_CheckoutDate())
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtGRNID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomer))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(cmbtoragePeriod))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtVehicleNo))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_Qty()
        {
            bool bStatus = true;

            if (dt_detail.Rows.Count > 0)
            {
                foreach (DataRow row in dt_detail.Rows)
                {
                    decimal qty = decimal.Parse(row["qty"].ToString());
                    if (qty <= 0)
                    {
                        string itemId = row["itemName"].ToString();

                        SEACCMessageBox.Show("Invalid Item QTY..!", itemId, MessageBoxButton.OK);
                        bStatus = false;
                        break;
                    }

                }
            }
            else
            {
                SEACCMessageBox.Show(" - ", "Please Add one or more items..", MessageBoxButton.OK);
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
                    txtGRNID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_whTxn_GoodReceivedNote oDetail = tbl_whTxn_GoodReceivedNote.Select(txtGRNID.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool CheckValidity_CheckoutDate()
        {
            bool bStatus = true;

            if (dtpIn.GetDateTime() > dtpOut.GetDateTime())
            {
                bStatus = false;
                SEACCMessageBox.Show("", "Checkout Date should be greater than Checkin Date", MessageBoxButton.OK);
            }

            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_whTxn_GoodReceivedNote details = tbl_whTxn_GoodReceivedNote.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtGRNID.IsEnabled = false;

                        txtGRNID.Tag = details.GoodReceivedNote_ID;
                        txtCustomer.Tag = details.Customer_ID;
                        txtEstimation.Tag = details.Estimation_ID;
                        txtStore.Tag = details.Store_ID;
                        txtVehicleTracking.Tag = details.VehicleTracking_ID;

                        txtGRNID.Text = details.GoodReceivedNote_ID;
                        dtpGRN.SetTime(details.GoodReceivedNote_Date);
                        txtEstimation.Text = details.Estimation_ID;
                        txtCustomer.Text = clsRef_Name.get_Customer_Name(details.Customer_ID);
                        txtStore.Text = clsRef_Name.get_Store_Name(details.Store_ID);
                        txtRemark.Text = details.Remarks;

                        tbl_whTxn_VehicleTracker veh_details = tbl_whTxn_VehicleTracker.Select(details.VehicleTracking_ID);
                        txtVehicleTracking.Text = details.VehicleTracking_ID;
                        txtVehicleNo.Text = veh_details.Vehicle_No;
                        txtContainerNo.Text = veh_details.Container_No;
                        txtDriverNIC.Text = veh_details.DriverNic;
                        txtDriverName.Text = veh_details.DriverName;
                        dtpIn.SetTime(veh_details.CheckinTime);
                        dtpOut.SetTime(veh_details.CheckoutTime);
                        //txtCurrency.Text = details.Currency_ID;
                        //txtCurrencyRate.Text = cls_Formater.FormatToCurrecyWithThousendSep(decimal.Parse(details.CurrencyRate.ToString()));

                        txtSubTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SubTotal.ToString()), 2);
                        txtDiscountPercentage.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountPercentage.ToString()), 2);
                        txtDiscountTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountTotal.ToString()), 2);
                        txtGrandTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.GrandTotal.ToString()), 2);

                        txtSubTotal.Tag = details.SubTotal;
                        txtDiscountPercentage.Tag = details.DiscountPercentage;
                        txtDiscountTotal.Tag = details.DiscountTotal;
                        txtGrandTotal.Tag = details.GrandTotal;

                        cmbtoragePeriod.SetSelectedIndex((int)details.Storage_Period);

                        int iLineNo = 0;
                        foreach (tbl_whTxn_GoodReceivedNote_Detail oDetails in tbl_whTxn_GoodReceivedNote_Detail.SelectAll().Where(r => r.GoodReceivedNote_ID == details.GoodReceivedNote_ID))
                        {
                            dt_detail.Rows.Add(iLineNo, oDetails.Item_ID, clsRef_Name.get_Item_Name(oDetails.Item_ID), oDetails.Discription, oDetails.Remarks1, oDetails.Remarks2, cls_Formater.FormatDecimal(oDetails.UnitWeight, 2), cls_Formater.FormatDecimal(oDetails.Qty, 0), cls_Formater.FormatDecimal(oDetails.GrossWeight, 2), cls_Formater.FormatDecimal(oDetails.NoOfPaletes, 2), cls_Formater.FormatDecimal(oDetails.DamageGoods, 2), clsValidation.GetDisplayValue_Date(oDetails.DateExpire));
                            iLineNo++;
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

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1_1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    dt_detail.Clear();
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResultIt = RowDataSearch.Show(Search.Items);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(lstResultIt[0]);
                if (detail != null)
                    dt_detail.Rows.Add(dt_detail.Rows.Count + 1, lstResultIt[0], lstResultIt[1], "", "", "", 0, 0, 0, 0, 0, "-");

            }
        }

        private void dgr_details_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColoumn = e.Column.Header.ToString();
            int irowID = dgr_details.SelectedIndex;
            TextBox t = e.EditingElement as TextBox;

            #region Qty And Weight
            if (sColoumn == "Qty" || sColoumn == "Unit Weight")
            {
                try
                {
                    decimal dQty = 0, dUnitWeight = 0, dGrossWeight = 0;

                    dUnitWeight = decimal.Parse(dt_detail.Rows[irowID]["unitweight"].ToString());
                    dQty = clsValidation.Validate_DecimalNumber(dt_detail.Rows[irowID]["QTY"].ToString());

                    switch (sColoumn)
                    {
                        case "Qty":
                            if (t != null)
                                dQty = clsValidation.Validate_DecimalNumber(t.Text);
                            break;
                        case "Unit Weight":
                            if (t != null)
                                dUnitWeight = clsValidation.Validate_DecimalNumber(t.Text);
                            break;
                    }
                    dGrossWeight = dQty * dUnitWeight;

                    dt_detail.Rows[irowID]["QTY"] = cls_Formater.FormatDecimal(dQty, 0);
                    dt_detail.Rows[irowID]["unitweight"] = cls_Formater.FormatDecimal(dUnitWeight, 2);
                    dt_detail.Rows[irowID]["weight"] = cls_Formater.FormatDecimal(dGrossWeight, 2);
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
            #endregion
            #region Exp. Date
            else if (sColoumn == "Product Expiry Date")
            {
                DateTime dtTemp = clsValidation.defaultDateTime;

                if (t.Text.Length == 0)
                    t.Text = "-";

                try
                {
                    dtTemp = DateTime.Parse(t.Text);
                    t.Text = dtTemp.ToString(clsConfig.Format_Date);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format", MessageBoxButton.OK);
                    t.Text = (dtTemp == clsConfig.defaultDateTime) ? "-" : dtTemp.ToString(clsConfig.Format_Date);
                }
            }
            #endregion
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_details.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgr_details.SelectedItem)).Row.Delete();
        }
        #endregion

        #region Search Event
        private void txtGRNID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Grn);
            if (RowDataSearch.DialogResult == true)
            {
                txtGRNID.Text = lstResult[0];
                txtCustomer.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtEstimation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtEstimation.Tag != null && txtEstimation.Text != "")
                lstParameeters.Add(txtEstimation.Tag.ToString());

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.CustomerEstimation);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Text = lstResult[2];
                txtCustomer.Tag = lstResult[3];
                txtEstimation.Text = lstResult[0];
                txtEstimation.Tag = lstResult[0];

                tbl_whTxn_Estimation est = tbl_whTxn_Estimation.Select(lstResult[0]);
                cmbtoragePeriod.SetSelectedIndex((int)est.Storage_Period);

                dt_detail.Clear();

                foreach (tbl_whTxn_Estimation_Detail oDetails in tbl_whTxn_Estimation_Detail.SelectAll().Where(r => r.Estimation_ID == lstResult[0]))
                {
                    dt_detail.Rows.Add(oDetails.Item_ID, clsRef_Name.get_Item_Name(oDetails.Item_ID), oDetails.Remarks, cls_Formater.FormatDecimal(oDetails.Qty, 0), oDetails.Uom_ID, clsRef_Name.get_UoM_Name(oDetails.Uom_ID), cls_Formater.FormatDecimal(oDetails.Weight, 3));
                }
            }
        }

        private void txtStore_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Store);
            if (RowDataSearch.DialogResult == true)
            {
                txtStore.Text = lstResult[1];
                txtStore.Tag = lstResult[0];
            }
        }

        private void txtVehicleNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();

            lstParameeters.Add("1");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.VehicleTracker);

            if (RowDataSearch.DialogResult == true)
            {
                txtVehicleTracking.Text = lstResult[0];
                txtVehicleTracking.Tag = lstResult[0];
                txtVehicleNo.Text = lstResult[1];

                tbl_whTxn_VehicleTracker details = tbl_whTxn_VehicleTracker.Select(lstResult[0]);
                if (details != null)
                {
                    txtContainerNo.Text = details.Container_No;
                    txtDriverNIC.Text = details.DriverNic;
                    dtpIn.SetTime(details.CheckinTime);
                    txtDriverName.Text = details.DriverName;

                }
            }
        }

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Customers);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Text = lstResult[1];
                txtCustomer.Tag = lstResult[0];
            }
        }

        #endregion

        private void dgr_details_KeyUp(object sender, KeyEventArgs e)
        {
            //if (dgr_details.SelectedCells.Count > 0)
            //{
            //    DataRowView dataRow = (DataRowView)dgr_details.SelectedItem;
            //    int index = dgr_details.CurrentCell.Column.DisplayIndex;
            //    string cellValue = dataRow.Row.ItemArray[index].ToString();

            //    frm_ItemDesc oDisc = new frm_ItemDesc(cellValue);
            //    oDisc.ShowDialog();
            //}



        }
    }
}