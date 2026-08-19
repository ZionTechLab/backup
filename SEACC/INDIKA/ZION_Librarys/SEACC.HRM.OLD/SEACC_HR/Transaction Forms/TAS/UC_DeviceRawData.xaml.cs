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
using System.Data;
using SEACC_WPFControls;
using Digiteq.DataSets;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_DeviceRawData.xaml
    /// </summary>
    public partial class UC_DeviceRawData : UserControl
    {
        #region Class Variables
        dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();
        dts_TAS glb_dts_TAS = new dts_TAS();
        #endregion
       
        #region FormLoad
        public UC_DeviceRawData()
        {
            #region Initialize User Controls
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Device_Raw_Data;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("indexID");
            dgr_Main.dt.Columns.Add("DeviceID");
            dgr_Main.dt.Columns.Add("DeviceName");
            dgr_Main.dt.Columns.Add("EmpID");
            dgr_Main.dt.Columns.Add("Enpname");
            dgr_Main.dt.Columns.Add("Datetime");
            dgr_Main.dt.Columns.Add("EntryType"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click +=btn_Print_Click;
            //this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("#", "indexID", 0, false);
            dgr_Main.Add_DatagridColoumn("Device", "DeviceID", 75, false);
            dgr_Main.Add_DatagridColoumn("Dev. Name", "DeviceName", 0, false);
            dgr_Main.Add_DatagridColoumn("Emp.No.", "EmpID", 70);
            dgr_Main.Add_DatagridColoumn("Name", "Enpname", 150);
            dgr_Main.Add_DatagridColoumn("Date Time", "Datetime", 150);
            dgr_Main.Add_DatagridColoumn("Entry Type", "EntryType", 100); 
            #endregion

            btn_New_Click(null,null);

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualHeight < 520)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(520);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            dgr_Main.dt.Clear();
        }

        //void btn_Cancel_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btn_Print_Click(object sender, RoutedEventArgs e)
        //{
            //    try
            //    {

            //        Cursor = Cursors.Wait;
            //        glb_dts_ExportReport.Clear();
            //        glb_dts_TAS.Clear();


            //        string sReportTitle = "Device Raw Data";
            //        string sReportPath = string.Empty;
            //        string sDeviceID = string.Empty;
            //        if (chk_Emp.IsChecked == true && chk_Device.IsChecked == true)
            //        {
            //            txtEmpID.Text = "<All Employees>";

            //            txtDeviceID.Text = "<All Employees>";


            //            sReportPath = "Reports\\rpt_tasDeviceRawData.rpt";
            //            foreach (sp_tasDevice_RawData oDRD in sp_tasDevice_RawData.SelectAll("%", "%", Convert.ToDateTime(dtp_FromDate.SelectedDate), Convert.ToDateTime(dtp_ToDate.SelectedDate)).Where(p => p.Device_empID != null))
            //            {
            //                if (oDRD != null)
            //                {
            //                    glb_dts_TAS.dt_rptDeviceRawData.Adddt_rptDeviceRawDataRow(oDRD.Device_DateTime, oDRD.Device_empID, oDRD.EmployeeName, oDRD.Device_ID, oDRD.Device_Name);
            //                }
            //                else
            //                {
            //                    SEACCMessageBox.Show("No Records To Display within Date Range You Selected ", "Error");
            //                }

            //            }

            //            string sDateRange = "From '" + dtp_FromDate.SelectedDate.Value.Date.ToShortDateString() + "' To '" + dtp_ToDate.SelectedDate.Value.Date.ToShortDateString() + "'";
            //            glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), sReportTitle, "", sDateRange, clsSecurity.UserNameLoged, "");

            //            frm_ReportViwer CRViwer = new frm_ReportViwer();
            //            CRViwer.Print(sReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);
            //        }
            //        else
            //        {
            //            if (CheckValidity_EmptyField())
            //            {
            //                sReportPath = "Reports\\rpt_EmployeeWiseDeviceRawData.rpt";
            //                foreach (sp_tasDevice_RawData oDRD in sp_tasDevice_RawData.SelectAll(txtDeviceID.Text, txtEmpID.Text, Convert.ToDateTime(dtp_FromDate.SelectedDate), Convert.ToDateTime(dtp_ToDate.SelectedDate)).Where(p => p.Device_empID != null))
            //                {
            //                    if (oDRD != null)
            //                    {
            //                        glb_dts_TAS.dt_rptDeviceRawData.Adddt_rptDeviceRawDataRow(oDRD.Device_DateTime, oDRD.Device_empID, oDRD.EmployeeName, oDRD.Device_ID, oDRD.Device_Name);
            //                    }
            //                    else
            //                    {
            //                        SEACCMessageBox.Show("Error", "No Records To Display within Date Range You Selected ");
            //                    }

            //                }
            //            }

            //            string sDateRange = "From '" + dtp_FromDate.SelectedDate.Value.Date.ToShortDateString() + "' To '" + dtp_ToDate.SelectedDate.Value.Date.ToShortDateString() + "'";
            //            glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), sReportTitle, "", sDateRange, clsSecurity.UserNameLoged, "");

            //            frm_ReportViwer CRViwer = new frm_ReportViwer();
            //            CRViwer.Print(sReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);
            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        SEACCMessageBox.Show(ex.Message, "Error");

            //    }
            //    finally
            //    {
            //        Cursor = Cursors.Arrow;
            //        glb_dts_ExportReport.Clear();
            //        glb_dts_TAS.Clear();
            //    }
        //}

        //void btn_Save_Click(object sender, RoutedEventArgs e)
        //{
        //    ClearFields();
        //}

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDeviceID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpID, true, false, false);

            txtDeviceID.Tag = null;
            txtEmpID.Tag = null;

            txtDeviceID.Text = "<All Devices>";
            txtEmpID.Text = "<All Employees>";

            dtp_FromDate.SetTime(clsSecurity.getServerDateTime());
            dtp_ToDate.SetTime(clsSecurity.getServerDateTime());
        } 
        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                DateTime fromDate = dtp_FromDate.GetDateTime().Date;
                DateTime toDate = dtp_ToDate.GetDateTime().Date;

                string sEmployeeID = (txtEmpID.Tag == null) ? "%" : txtEmpID.Tag.ToString();
                string sDeviceID = (txtDeviceID.Tag == null) ? "%" : txtDeviceID.Tag.ToString();

                foreach (sp_tasDevice_RawData Detail in sp_tasDevice_RawData.SelectAll(sDeviceID, sEmployeeID, fromDate, toDate))
                {
                    int a = Detail.RawData_Index;
                    dgr_Main.dt.Rows.Add(Detail.RawData_Index, Detail.Device_ID, Detail.Device_Name, Detail.Device_empID, Detail.EmployeeName, Detail.Device_DateTime.ToString(), Detail.RawData_Index);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception)
            { }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtEmpID))
            {
                bStatus = false;
            }
            if (!clsValidation.Validate_EmptyValue(txtDeviceID))
            {
                bStatus = false;
            }

            return bStatus;
        }

        #endregion

        #region Search Event
        private void txtDeviceID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Device_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_hrMasDevice oDevice = tbl_hrMasDevice.Select(lstResult[0]);
                if (oDevice != null)
                {
                    txtDeviceID.Text = oDevice.Device_ID + " - " + oDevice.Device_Name;
                    txtDeviceID.Tag = oDevice.Device_ID;
                }
            }
          
        }
        private void txtEmpID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oEmployee != null)
                {
                    txtEmpID.Text = oEmployee.EpfNo + " - " + oEmployee.SurName + " " + oEmployee.Initails;
                    txtEmpID.Tag = oEmployee.Employee_ID2;
                }
            }
        }
        #endregion 
    }
}
