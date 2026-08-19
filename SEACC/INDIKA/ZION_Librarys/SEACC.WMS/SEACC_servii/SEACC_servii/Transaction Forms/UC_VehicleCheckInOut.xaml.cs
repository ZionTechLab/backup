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

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_VehicleCheckInOut.xaml
    /// </summary>
    public partial class UC_VehicleCheckInOut : UserControl
    {
        public UC_VehicleCheckInOut()
        {
            #region User Control Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.VehicleCheckInOut;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("VehicleID");
            dgr_Main.dt.Columns.Add("VehicleNo");
            dgr_Main.dt.Columns.Add("Type");
            dgr_Main.dt.Columns.Add("CustomerID");
            dgr_Main.dt.Columns.Add("CustomerName");
            dgr_Main.dt.Columns.Add("ContainerNo");
            dgr_Main.dt.Columns.Add("DriverName");
            dgr_Main.dt.Columns.Add("DriverNIC");
            dgr_Main.dt.Columns.Add("ChechInTime");
            dgr_Main.dt.Columns.Add("ChechOutTime");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Tracking ID", "VehicleID", 60, false);
            dgr_Main.Add_DatagridColoumn("Vehicle No", "VehicleNo", 100);
            dgr_Main.Add_DatagridColoumn("Type", "Type", 70);
            dgr_Main.Add_DatagridColoumn("Customer ID", "CustomerID", 80, false);
            dgr_Main.Add_DatagridColoumn("Customer Name", "CustomerName", 190);
            dgr_Main.Add_DatagridColoumn("Container No", "ContainerNo", 80);
            dgr_Main.Add_DatagridColoumn("Driver Name", "DriverName", 80);
            dgr_Main.Add_DatagridColoumn("Driver NIC", "DriverNIC", 90);
            dgr_Main.Add_DatagridColoumn("ChechIn Time", "ChechInTime", 130);
            dgr_Main.Add_DatagridColoumn("ChechOut Time", "ChechOutTime", 130);
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    int chType = cmbType.GetSelectedIndex();

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_whTxn_VehicleTracker OldDetails = tbl_whTxn_VehicleTracker.Select(txtVehicleID.Text.Trim());
                            if (OldDetails != null)
                            {
                                tbl_whTxn_VehicleTracker oDetail = new tbl_whTxn_VehicleTracker(txtVehicleID.Text, txtVehicleNo.Text, chType, txtCustomer.Tag.ToString(), txtContainerNo.Text, txtDriverName.Text, txtDriverNIC.Text, dtpCheckIn.GetDateTime(), dtpCheckOut.GetDateTime(), OldDetails.IsCancelled, OldDetails.UserID_Created, clsSecurity.UserIDLoged, OldDetails.UserID_Cancelled, OldDetails.TerminalID_Created, clsSecurity.TerminalID, OldDetails.TerminalID_Cancelled, OldDetails.Date_Created, clsSecurity.getServerDateTime(), OldDetails.Date_Cancelled);
                                oDetail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {
                        tbl_whTxn_VehicleTracker details = new tbl_whTxn_VehicleTracker(txtVehicleID.Tag.ToString(), txtVehicleNo.Text, chType, txtCustomer.Tag.ToString(), txtContainerNo.Text, txtDriverName.Text, txtDriverNIC.Text, dtpCheckIn.GetDateTime(), clsValidation.defaultDateTime, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(),clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                        details.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
                }
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtVehicleID.Tag != null && txtVehicleID.Tag.ToString() != "" && dtpCheckOut.GetDateTime().ToString() == "1/1/1800 12:00:00 AM")
                    {
                        string dt = dtpCheckOut.GetDateTime().ToString();
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_whTxn_VehicleTracker detail = tbl_whTxn_VehicleTracker.Select(txtVehicleID.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCancelled = true;
                                detail.Date_Cancelled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Cancelled = clsSecurity.TerminalID;
                                detail.UserID_Cancelled = clsSecurity.UserIDLoged;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Sorry..", "This Record Can not be Delete!", MessageBoxButton.OK);
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
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtVehicleID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtVehicleNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtContainerNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDriverName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDriverNIC, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpCheckIn, true, true);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpCheckOut, true, true);

            txtVehicleID.Tag = null;
            txtCustomer.Tag = null;
            
            txtVehicleNo.Text = "";
            txtVehicleNo.Text = "";
            txtCustomer.Text = "";
            txtContainerNo.Text = "";
            txtDriverName.Text = "";
            txtDriverNIC.Text = "";

            dtpCheckIn.SetTime(DateTime.Now);
            dtpCheckOut.SetTime(clsValidation.defaultDateTime);

            cmbType.SetValues(typeof(CheckingType));
            cmbType.SetSelectedIndex(-1);

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtVehicleID.setReadOnlyStatus(true);
                txtVehicleID.Text = "<Auto Generate>";
            }
            else
                txtVehicleID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_whTxn_VehicleTracker item in tbl_whTxn_VehicleTracker.SelectAll().Where(p => p.VehicleTracking_ID != "default" && !p.IsCancelled && p.CheckoutTime.ToString()== "1/1/1800 12:00:00 AM").OrderBy(p => p.CheckinTime))
                {
                    dgr_Main.dt.Rows.Add(item.VehicleTracking_ID, item.Vehicle_No, ((CheckingType)item.Purpose).ToString(), item.Customer_ID, clsRef_Name.get_Customer_Name(item.Customer_ID), item.Container_No, item.DriverName, item.DriverNic, clsValidation.GetDisplayValue_Time(item.CheckinTime), "-");
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
                if (CheckValidity_DuplicateFiled())
                {
                    if (CheckValidity_NIC())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtVehicleNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomer))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(cmbType))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDriverName))
                bStatus = false;


            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtVehicleID.Tag = SEACC_Form.getAutoGeneratedCode();


                tbl_whTxn_VehicleTracker oDetail = tbl_whTxn_VehicleTracker.Select(txtVehicleID.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;

        }

        public bool CheckValidity_NIC()
        {
            bool bStatus = true;

            string str = txtDriverNIC.Text; ;
            if ((str.Count(char.IsDigit) == 9) && // only 9 digits
                (str.EndsWith("X", StringComparison.OrdinalIgnoreCase) || str.EndsWith("V", StringComparison.OrdinalIgnoreCase)) && //a letter at the end 'x' or 'v'
                (str[2] != '4' && str[2] != '9')) //3rd digit can not be equal to 4 or 9
            {
                bStatus = true;
            }
            else
            {
                bStatus = false;
                SEACCMessageBox.Show("Invalid NIC", "", MessageBoxButton.OK);
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
                    tbl_whTxn_VehicleTracker details = tbl_whTxn_VehicleTracker.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtVehicleID.IsEnabled = false;

                        txtVehicleID.Tag = details.VehicleTracking_ID;
                        txtCustomer.Tag = details.Customer_ID;

                        txtVehicleID.Text = details.VehicleTracking_ID;
                        txtVehicleNo.Text = details.Vehicle_No;
                        txtCustomer.Text = clsRef_Name.get_Customer_Name(details.Customer_ID);
                        txtContainerNo.Text = details.Container_No;
                        txtDriverName.Text = details.DriverName;
                        txtDriverNIC.Text = details.DriverNic;
                        dtpCheckIn.SetTime(details.CheckinTime);
                        dtpCheckOut.SetTime(details.CheckoutTime);

                        #region Checking type
                        if (details.Purpose == (int)CheckingType.Loading)
                            cmbType.SetSelectedIndex((int)CheckingType.Loading);
                        else if (details.Purpose == (int)CheckingType.Unloading)
                            cmbType.SetSelectedIndex((int)CheckingType.Unloading);
                        else
                            cmbType.SetSelectedIndex(-1);
                        #endregion
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
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events    
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
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.VehicleTracker);
            if (RowDataSearch.DialogResult == true)
            {
                txtVehicleID.Tag = lstResult[0];
                txtVehicleID.Text = lstResult[0];
                
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}