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
using System.Text.RegularExpressions;

namespace SEACC_servii
{
    public partial class UC_GoodIssueNote : UserControl
    {
        DataTable dt_detail = new DataTable();

        #region User Control Initialize
        public UC_GoodIssueNote()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.GIN;
            SEACC_Form.Initialize();

            #region Initialize Data table
            dgr_Main.dt.Columns.Add("gin_ID");
            dgr_Main.dt.Columns.Add("gin_Date");
           // dgr_Main.dt.Columns.Add("estimation_ID");
           // dgr_Main.dt.Columns.Add("grn_ID");
            dgr_Main.dt.Columns.Add("customer_ID");
            dgr_Main.dt.Columns.Add("customerName");
            dgr_Main.dt.Columns.Add("vehicleTracking_ID");
            dgr_Main.dt.Columns.Add("vehicle_No");
            dgr_Main.dt.Columns.Add("storeID");
            dgr_Main.dt.Columns.Add("storeName");
            //dgr_Main.dt.Columns.Add("storage_Period");
            dgr_Main.dt.Columns.Add("remarks");
            dgr_Main.dt.Columns.Add("grandTotal");
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("GIN ID", "gin_ID", 80);
            dgr_Main.Add_DatagridColoumn("GIN Date", "gin_Date", 100);
            //dgr_Main.Add_DatagridColoumn("Estimation ID", "estimation_ID", 80, false);
            //dgr_Main.Add_DatagridColoumn("GRN ID", "grn_ID", 100, false);
            dgr_Main.Add_DatagridColoumn("Customer ID", "customer_ID", 40, false);
            dgr_Main.Add_DatagridColoumn("Customer Name", "customerName", 100);
            dgr_Main.Add_DatagridColoumn("vehicle Tracking ID", "vehicleTracking_ID", 80, false);
            dgr_Main.Add_DatagridColoumn("Vehicle No", "vehicle_No", 150);
            dgr_Main.Add_DatagridColoumn("Store ID", "storeID", 150, false);
            dgr_Main.Add_DatagridColoumn("store Name", "storeName", 150);
            //dgr_Main.Add_DatagridColoumn("Storage Period", "storage_Period", 90);
            dgr_Main.Add_DatagridColoumn("Remarks", "remarks", 100);
            dgr_Main.Add_DatagridColoumn("Grand Total", "grandTotal", 100);
            #endregion

            #region Initialize Data Table - Items
            dt_detail.Columns.Add("LineNo");
            dt_detail.Columns.Add("GRN");
            dt_detail.Columns.Add("StoreID");
            dt_detail.Columns.Add("Store");
            dt_detail.Columns.Add("itemID");
            dt_detail.Columns.Add("itemName");
            dt_detail.Columns.Add("remarks");
            dt_detail.Columns.Add("Avil_qty");
            dt_detail.Columns.Add("qtySettle");
            dt_detail.Columns.Add("unitweight");
            dt_detail.Columns.Add("GrossWeight");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            #endregion

            dgr_details.ItemsSource = dt_detail.DefaultView;

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
                    //int iPeriod = cmbtoragePeriod.GetSelectedIndex();
                    sGrnId = txtGINID.Tag.ToString();

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        SEACCMessageBox.Show("GIN Updation is blocked by Administrator", "", MessageBoxButton.OK);
                        //if (SEACC_Form.CheckPermisshion_ToUpdate())
                        //{
                        //    tbl_whTxn_GoodIssueNote OldRecord = tbl_whTxn_GoodIssueNote.Select(txtGINID.Text.Trim());
                        //    if (OldRecord != null)
                        //    {
                        //        tbl_whTxn_VehicleTracker veh_details = tbl_whTxn_VehicleTracker.Select(OldRecord.VehicleTracking_ID);
                        //        veh_details.CheckoutTime = dtpOut.GetDateTime();
                        //        veh_details.Update();

                        //        tbl_whTxn_GoodIssueNote oDetail = new tbl_whTxn_GoodIssueNote(txtGINID.Text, dtpGIN.GetDateTime().Date, txtEstimation.Tag.ToString(), txtGRN.Tag.ToString(), txtCustomer.Tag.ToString(), txtVehicleTracking.Tag.ToString(), txtStore.Tag.ToString(), 0, txtRemark.Text, txtCurrency.Text, decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled, OldRecord.PrintCount);
                        //        oDetail.Update();

                        //        foreach (tbl_whTxn_GoodIssueNote_Detail delDetails in tbl_whTxn_GoodIssueNote_Detail.SelectAllByGoodIssueNote_ID(oDetail.GoodReceivedNote_ID))
                        //        {
                        //            foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(delDetails.GoodReceivedNote_ID).Where(p=>p.Item_ID==delDetails.Item_ID))
                        //            {
                        //                decimal dQtySettle = oGrnDetail.QtySettle;
                        //                oGrnDetail.QtySettle = dQtySettle+ delDetails.Qty;
                        //                //oGrnDetail.QtySettle -= delDetails.Qty;
                        //                oGrnDetail.Update();
                        //            }

                        //            clsHelpMethods. Update_StoreStock(txtStore.Tag.ToString(), delDetails.Item_ID, txtCustomer.Tag.ToString(), delDetails.Qty, delDetails.GrossWeight);
                        //            delDetails.Delete();
                        //        }

                        //      //  tbl_whTxn_GoodIssueNote_Detail.DeleteAllByGoodIssueNote_ID(OldRecord.GoodIssueNote_ID);


                        //        int lineNo = 0;
                        //        foreach (DataRow row in dt_detail.Rows)
                        //        {
                        //            string sGrnNo = row["GRN"].ToString();
                        //            string sItemId = row["itemID"].ToString();
                        //            string sRemark = row["remarks"].ToString();
                        //        //    decimal dQty = decimal.Parse(row["qty"].ToString());
                        //            decimal dQtySettle = decimal.Parse(row["qtySettle"].ToString());
                        //            decimal dUnitWeight = decimal.Parse(row["unitweight"].ToString());
                        //            decimal dGrossWeight = decimal.Parse(row["GrossWeight"].ToString());


                        //            if (dQtySettle > 0)
                        //            {
                        //                lineNo++;
                        //                tbl_whTxn_GoodIssueNote_Detail details = new tbl_whTxn_GoodIssueNote_Detail(lineNo, txtGINID.Tag.ToString(), sGrnNo, txtStore.Tag.ToString(), sItemId, sRemark, dQtySettle, 0, dUnitWeight, dGrossWeight);
                        //                details.Insert();

                        //                foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(sGrnNo).Where(p => p.Item_ID == sItemId))
                        //                {
                        //                    oGrnDetail.QtySettle -= dQtySettle;
                        //                    oGrnDetail.Update();
                        //                }

                        //                clsHelpMethods.Update_StoreStock(txtStore.Tag.ToString(), sItemId, txtCustomer.Tag.ToString(), -dQtySettle, -dGrossWeight);
                        //            }
                        //        }

                        //        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        //    }
                        //}
                    }
                    #endregion
                    #region Insert
                    else
                    {
                        tbl_whTxn_VehicleTracker veh_details = tbl_whTxn_VehicleTracker.Select(txtVehicleTracking.Tag.ToString());
                        veh_details.CheckoutTime = dtpOut.GetDateTime();
                        veh_details.Update();

                        tbl_whTxn_GoodIssueNote oGIN = new tbl_whTxn_GoodIssueNote(txtGINID.Tag.ToString(), dtpGIN.GetDateTime(), txtEstimation.Tag.ToString(), txtGRN.Tag.ToString(), txtCustomer.Tag.ToString(), txtVehicleTracking.Tag.ToString(), txtStore.Tag.ToString(), 0, txtRemark.Text, txtCurrency.Text, decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime, 0);
                        oGIN.Insert();

                        int lineNo = 0;
                        foreach (DataRow row in dt_detail.Rows)
                        {
                            string sGrnNo= row["GRN"].ToString();
                            string sItemId = row["itemID"].ToString();
                            string sRemark = row["remarks"].ToString();
                           // decimal dQty = decimal.Parse(row["qty"].ToString());
                            decimal dQtySettle = decimal.Parse(row["qtySettle"].ToString());
                            decimal dUnitWeight = decimal.Parse(row["unitweight"].ToString());
                            decimal dGrossWeight = decimal.Parse(row["GrossWeight"].ToString());

                            if (dQtySettle > 0)
                            {
                                lineNo++;
                                tbl_whTxn_GoodIssueNote_Detail details = new tbl_whTxn_GoodIssueNote_Detail(lineNo, txtGINID.Tag.ToString(), sGrnNo, txtStore.Tag.ToString(), sItemId, sRemark, dQtySettle, 0, dUnitWeight, dGrossWeight);
                                details.Insert();

                                foreach (tbl_whTxn_GoodReceivedNote_Detail oGrnDetail in tbl_whTxn_GoodReceivedNote_Detail.SelectAllByGoodReceivedNote_ID(sGrnNo).Where(p => p.Item_ID == sItemId))
                                {
                                    oGrnDetail.QtySettle += dQtySettle;
                                    oGrnDetail.Update();
                                }

                                clsHelpMethods.Update_StoreStock(txtStore.Tag.ToString(), sItemId, txtCustomer.Tag.ToString(), -dQtySettle, -dGrossWeight);
                            }
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
                    if (txtGINID.Tag != null && txtGINID.Tag.ToString() != "")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_whTxn_GoodIssueNote detail = tbl_whTxn_GoodIssueNote.Select(txtGINID.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);

                                ClearFields();
                                RefreshGrid();
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
                if (txtGINID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermisshion_ToUpdate())
                    {
                        //tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.EstimationDetail);
                        //if (oReports != null)
                        {
                            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                            DataSets.dts_GIN dts_GIN = new DataSets.dts_GIN();
                            dts_GIN.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), "Good Issue Note", "", "", clsSecurity.UserNameLoged, "");

                            tbl_whTxn_GoodIssueNote details = tbl_whTxn_GoodIssueNote.Select(txtGINID.Tag.ToString());
                            if (details != null)
                            {
                                //fill data table
                                foreach (tbl_whTxn_GoodIssueNote_Detail delDetails in tbl_whTxn_GoodIssueNote_Detail.SelectAll().Where(p => p.GoodIssueNote_ID == details.GoodIssueNote_ID))
                                {
                                    dts_GIN.dt_GINDetail.Adddt_GINDetailRow(delDetails.GoodIssueNote_ID, delDetails.Item_ID, clsRef_Name.get_Item_Name(delDetails.Item_ID), delDetails.Remarks, delDetails.GrossWeight, clsRef_Name.get_UoM_ID(delDetails.Item_ID), clsRef_Name.get_UoM_Code(clsRef_Name.get_UoM_ID(delDetails.Item_ID)), 0, delDetails.Qty);
                                }

                                dts_GIN.dt_GIN.Adddt_GINRow(txtGINID.Tag.ToString(),txtGRN.Text, txtEstimation.Tag.ToString(), txtCustomer.Tag.ToString(), txtCustomer.Text, details.Storage_Period.ToString(), txtRemark.Text, txtVehicleNo.Text, dtpIn.GetDateTime(), dtpOut.GetDateTime(), txtContainerNo.Text);

                                frm_ReportViwer CRViwer = new frm_ReportViwer();
                                CRViwer.Print("\\Reports\\rpt_GINDetail.rpt", dts_GIN, glb_dts_ExportReport.dt_rptParameter);

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
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGINID, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpGIN, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGRN, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEstimation, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtVehicleTracking, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtStore, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSubTotal, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountPercentage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountTotal, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGrandTotal, false, true, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtVehicleNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtContainerNo, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDriverNIC, false, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpIn, false,true);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpOut, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDriverName, false, false, false);

            txtVehicleNo.Text = "";
            txtContainerNo.Text = "";
            txtDriverNIC.Text = "";
            txtDriverName.Text = "";
            dtpIn.SetTime(DateTime.Now);
            dtpOut.SetTime(DateTime.Now);

            txtGINID.Tag = null;
            txtGRN.Tag = "default";
            txtEstimation.Tag = "default";
            txtCustomer.Tag = null;
            txtVehicleTracking.Tag = null;
            txtStore.Tag = null;


            dtpGIN.SetTime(DateTime.Now);
            txtGRN.Text = "";
            txtEstimation.Text = "";
            txtCustomer.Text = "";
            txtVehicleTracking.Text = "";
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

            //cmbtoragePeriod.SetValues(typeof(StoragePeriod));
            //cmbtoragePeriod.SetSelectedIndex(-1);

            txtCurrency.Text = "LKR/001";
            txtCurrencyRate.Text = "1.00";

            dt_detail.Clear();

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGINID.setReadOnlyStatus(true);
                txtGINID.Text = "<Auto Generate>";
            }
            else
                txtGINID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_whTxn_GoodIssueNote item in tbl_whTxn_GoodIssueNote.SelectAll().Where(p => p.GoodIssueNote_ID != "default" && !p.IsCanceled))
                {
                    //dgr_Main.dt.Rows.Add(item.GoodIssueNote_ID, clsValidation.GetDisplayValue_Date(item.GoodIssueNote_Date), item.Estimation_ID, item.GoodReceivedNote_ID, item.Customer_ID, clsRef_Name.get_Customer_Name(item.Customer_ID), item.VehicleTracking_ID, clsRef_Name.get_Vehicle_No(item.VehicleTracking_ID), item.Store_ID, clsRef_Name.get_Store_Name(item.Store_ID), ((StoragePeriod)item.Storage_Period).ToString(), item.Remarks, cls_Formater.FormatDecimal(item.GrandTotal, 3));
                    dgr_Main.dt.Rows.Add(item.GoodIssueNote_ID, clsValidation.GetDisplayValue_Date(item.GoodIssueNote_Date), item.Customer_ID, clsRef_Name.get_Customer_Name(item.Customer_ID), item.VehicleTracking_ID, clsRef_Name.get_Vehicle_No(item.VehicleTracking_ID), item.Store_ID, clsRef_Name.get_Store_Name(item.Store_ID), item.Remarks, cls_Formater.FormatDecimal(item.GrandTotal, 3));
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
                    if (CheckValidity_Available_Qty())
                    {
                        if (CheckValidity_DuplicateFiled())
                        {
                            if (CheckValidity_CheckoutDate())
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

            if (!clsValidation.Validate_EmptyValue(txtGINID))
                bStatus = false;               
            if (!clsValidation.Validate_EmptyValue(txtCustomer))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtVehicleNo))
                bStatus = false;      

            //if (!clsValidation.Validate_LableComboBox_EmptyValue(cmbtoragePeriod))
            //    bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_Qty()
        {
            bool bStatus = true;            

                if (dt_detail.Rows.Count > 0)
                {
                    decimal qty = 0;
                    foreach (DataRow row in dt_detail.Rows)
                    {
                        qty += decimal.Parse(row["qtySettle"].ToString());
                    }

                    if (qty <= 0)
                    {
                        SEACCMessageBox.Show("Total issue Qty cannot be '0'", "", MessageBoxButton.OK);
                        bStatus = false;
                    }
                }
                else
                {
                    SEACCMessageBox.Show(" - ", "Please Add one or more items..", MessageBoxButton.OK);
                    bStatus = false;
                }
            
            return bStatus;
        }

        public bool CheckValidity_Available_Qty()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {

                decimal dAvailableQty = 0;
                decimal dIssuedQty = 0;

                foreach (DataRow row in dt_detail.Rows)
                {
                    dAvailableQty += decimal.Parse(row["Avil_qty"].ToString());
                    dIssuedQty += decimal.Parse(row["qtySettle"].ToString());
                    if (dIssuedQty > dAvailableQty)
                    {
                        SEACCMessageBox.Show("", "Issued Quantity should be less than Available Quantity!", MessageBoxButton.OK);
                        bStatus = false;
                    }
                }
            }
            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtGINID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_whTxn_GoodIssueNote oDetail = tbl_whTxn_GoodIssueNote.Select(txtGINID.Tag.ToString());
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
                    tbl_whTxn_GoodIssueNote details = tbl_whTxn_GoodIssueNote.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtGINID.IsEnabled = false;

                        txtGINID.Tag = details.GoodIssueNote_ID;
                        txtEstimation.Tag = details.Estimation_ID;
                        txtGRN.Tag = details.GoodReceivedNote_ID;
                        txtCustomer.Tag = details.Customer_ID;
                        txtVehicleTracking.Tag = details.VehicleTracking_ID;
                        txtStore.Tag = details.Store_ID;

                        txtGINID.Text = details.GoodIssueNote_ID;
                        dtpGIN.SetTime(details.GoodIssueNote_Date);
                        txtEstimation.Text = details.Estimation_ID;
                        txtGRN.Text = details.GoodReceivedNote_ID;
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

                        txtSubTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SubTotal.ToString()), 2);
                        txtDiscountPercentage.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountPercentage.ToString()), 2);
                        txtDiscountTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountTotal.ToString()), 2);
                        txtGrandTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.GrandTotal.ToString()), 2);

                        txtSubTotal.Tag = details.SubTotal;
                        txtDiscountPercentage.Tag = details.DiscountPercentage;
                        txtDiscountTotal.Tag = details.DiscountTotal;
                        txtGrandTotal.Tag = details.GrandTotal;

                        //cmbtoragePeriod.SetSelectedIndex((int)details.Storage_Period);

                        foreach (tbl_whTxn_GoodIssueNote_Detail oDetails in tbl_whTxn_GoodIssueNote_Detail.SelectAllByGoodIssueNote_ID(sID))
                        {
                            dt_detail.Rows.Add(oDetails.Line_No ,oDetails.GoodReceivedNote_ID,oDetails.Store_ID,"", oDetails.Item_ID, clsRef_Name.get_Item_Name( oDetails.Item_ID), oDetails.Remarks,0, cls_Formater.FormatDecimal(decimal.Parse(oDetails.Qty.ToString()), 0), cls_Formater.FormatDecimal(decimal.Parse(oDetails.UnitWeight.ToString()), 2), cls_Formater.FormatDecimal(decimal.Parse(oDetails.GrossWeight.ToString()), 2));
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
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
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
            if (clsValidation.Validate_EmptyValue(txtCustomer) && clsValidation.Validate_EmptyValue(txtStore))
            {
                List<string> lstParameeters = new List<string>();

                lstParameeters.Add(txtStore.Tag.ToString());
                lstParameeters.Add(txtCustomer.Tag.ToString());

                frmSearch fSearch = new frmSearch(lstParameeters);
                List<string> lstResult = fSearch.Show(Search.Items_StoreStock);
                if (fSearch.DialogResult == true)
                {
                    string strScript = "exec [tbl_getGRNAvailableStock] '" + lstResult[0] + "' , '" + txtCustomer.Tag.ToString() + "' , '" + txtStore.Tag.ToString() + "' ";
                    dt_detail = DBHandling.ExecQuery(strScript).Tables[0];
                    if (dt_detail != null && dt_detail.Rows.Count > 0)
                    {
                        dgr_details.ItemsSource = dt_detail.DefaultView;
                    }
                }
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_details.SelectedItem;
            if (selectedItem != null)
            {
                ((DataRowView)(dgr_details.SelectedItem)).Row.Delete();
            }
        }

        private void dgr_details_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int irowID = dgr_details.SelectedIndex;
                string sColoumn = e.Column.Header.ToString();
                TextBox t = e.EditingElement as TextBox;

                decimal dQty = 0, dUnitWeight = 0, dGrossWeight = 0;

                dUnitWeight = decimal.Parse(dt_detail.Rows[irowID]["unitweight"].ToString());
                dQty = clsValidation.Validate_DecimalNumber(dt_detail.Rows[irowID]["qtySettle"].ToString());

                switch (sColoumn)
                {
                    case "Issued QTY":
                        if (t != null)
                            dQty = clsValidation.Validate_DecimalNumber(t.Text);
                        break;
                    case "Unit Price":
                        if (t != null)
                            dUnitWeight = clsValidation.Validate_DecimalNumber(t.Text);
                        break;
                }
                dGrossWeight = dQty * dUnitWeight;

                dt_detail.Rows[irowID]["qtySettle"] = cls_Formater.FormatDecimal(dQty, 0);
                dt_detail.Rows[irowID]["GrossWeight"] = cls_Formater.FormatDecimal(dGrossWeight, 2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtGINID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Gin);
            if (RowDataSearch.DialogResult == true)
            {
                txtGINID.Text = lstResult[0];
                txtGINID.Tag = lstResult[0];

                fillDetails(lstResult[0]);
            }
        }

        private void txtGRN_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtGRN.Tag != null && txtGRN.Text != "")
            {
                lstParameeters.Add(txtGRN.Tag.ToString());
            }

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Grn);
            if (RowDataSearch.DialogResult == true)
            {
                txtGRN.Text = lstResult[0];
                txtGRN.Tag = lstResult[0];

                //txtEstimation.Text = lstResult[1];
                //txtEstimation.Tag = lstResult[1];

                //txtCustomer.Tag = lstResult[2];
                //txtCustomer.Text = lstResult[3];

                //tbl_whTxn_Estimation est = tbl_whTxn_Estimation.Select(lstResult[1]);
                //cmbtoragePeriod.SetSelectedIndex((int)est.Storage_Period);

                dt_detail.Clear();
                foreach (tbl_whTxn_GoodReceivedNote_Detail oDetails in tbl_whTxn_GoodReceivedNote_Detail.SelectAll().Where(r => r.GoodReceivedNote_ID == lstResult[0]))
                {
                    dt_detail.Rows.Add(oDetails.Item_ID, clsRef_Name.get_Item_Name(oDetails.Item_ID), oDetails.Remarks2, cls_Formater.FormatDecimal(oDetails.Qty, 0), cls_Formater.FormatDecimal(oDetails.QtySettle, 0), cls_Formater.FormatDecimal(decimal.Parse(clsRef_Name.get_Item_UnitWeight(oDetails.Item_ID)), 3), cls_Formater.FormatDecimal(oDetails.GrossWeight, 3), cls_Formater.FormatDecimal(oDetails.GrossWeight, 3));
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

        private void txtVehicleNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();

            lstParameeters.Add("0");

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

        private void txtStore_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Store);
            if (RowDataSearch.DialogResult == true)
            {
                txtStore.Text = lstResult[1];
                txtStore.Tag = lstResult[0];
            }
        }
        #endregion
    }
}