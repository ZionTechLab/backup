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
    /// Interaction logic for UC_DeviceRawData1.xaml
    /// </summary>
    public partial class UC_DeviceRawData1 : UserControl
    {
        public UC_DeviceRawData1()
        {
            InitializeComponent();

            SEACC_Form_DeviceRawData.enmFormName = FormName.Device_RawData;
            SEACC_Form_DeviceRawData.Initialize();
        }

        #region Variables
        public bool IsUpdate;
        string sFormConfigCode;
        public int iFormID;
        //  bool bNoAccess;

        #endregion

        #region Print Button
        //private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.Wait;
        //        glb_dts_ExportReport.Clear();
        //        glb_dts_TAS.Clear();

        //        string sReportTitle = "Device Raw Data";
        //        string sReportPath = "Reports\\rpt_tasDeviceRawData.rpt";

        //        foreach (sp_tasDevice_RawData oDRD in sp_tasDevice_RawData.SelectAll("%", "%", Convert.ToDateTime(dtp_FromDate.SelectedDate), Convert.ToDateTime(dtp_ToDate.SelectedDate)))
        //        {
        //            glb_dts_TAS.dt_rptDeviceRawData.Adddt_rptDeviceRawDataRow(oDRD.Device_DateTime, oDRD.Device_empID, oDRD.EmployeeName, oDRD.Device_ID, oDRD.Device_Name);
        //        }

        //        string sDateRange = "From '" + dtp_FromDate.SelectedDate.Value.Date.ToShortDateString() + "' To '" + dtp_ToDate.SelectedDate.Value.Date.ToShortDateString() + "'";
        //        glb_dts_TAS.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), sReportTitle, "", sDateRange, clsSecurity.UserNameLoged, "");

        //        frm_ReportViwer CRViwer = new frm_ReportViwer();
        //        CRViwer.Print(sReportPath, glb_dts_TAS, glb_dts_ExportReport.dt_rptParameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        SeaccMessageBox.Show(SEACC_MessegeBox.MessegeboxType.Error, ex.Message, "Error");

        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Arrow;
        //        glb_dts_ExportReport.Clear();
        //        glb_dts_TAS.Clear();
        //    }
        //}
        #endregion

        #region Load Button
        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region New Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clsCommon.SetEnableDisable_DataGrid(grd_DeviceRowData, true, "#FF41B1E1", "#FFFFFF");
            clsCommon.SetEnableDisable_NormalTextbox(txtDeviceID, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtEmpID, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtDeviceName, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtEmployeeName, true, false);


            txtDeviceID.Clear();
            txtEmpID.Clear();
            txtEmployeeName.Clear();
            txtDeviceName.Clear();
            grd_DeviceRowData.ItemsSource = null;
        }
        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("DeviceID");
                dt.Columns.Add("DeviceName");
                dt.Columns.Add("EmpID");
                dt.Columns.Add("Enpname");
                dt.Columns.Add("Datetime");

                foreach (sp_tasDevice_RawData oDetails in sp_tasDevice_RawData.SelectAll(txtDeviceID.Text.Trim(), txtEmpID.Text.Trim(), Convert.ToDateTime(dtp_FromDate.SelectedDate), Convert.ToDateTime(dtp_ToDate.SelectedDate)).Where(p => p.Device_ID != null))
                {
                    dt.Rows.Add(oDetails.Device_ID, oDetails.Device_Name, oDetails.Device_empID, oDetails.EmployeeName, oDetails.Device_DateTime.ToString());
                }
                grd_DeviceRowData.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                SeaccMessageBox.Show(SEACC_MessegeBox.MessegeboxType.Error, ex.Message, "Error");
            }
        }
        #endregion


        #region Grid Formatting
        private void FormatGrid()
        {
            clsCommon.SetEnableDisable_DataGrid(grd_DeviceRowData, true, "#FF41B1E1", "#FFFFFF");

        }

        #endregion

        #region TextBox Formatting
        private void TextboxFormatting()
        {

            clsCommon.SetEnableDisable_NormalTextbox(txtDeviceID, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtEmpID, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtDeviceName, true, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtEmployeeName, true, false);

        }
        #endregion

        #region Mouse Double Click on TextBoxes
        private void txtDeviceID_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Pick("1");
            if (RowDataSearch.DialogResult == true)
            {
                txtDeviceID.Text = lstResult[0];
                txtDeviceName.Text = lstResult[1];
            }
        }

        private void txtEmpID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Pick("2");
            if (RowDataSearch.DialogResult == true)
            {
                txtEmpID.Text = lstResult[0];
                txtEmployeeName.Text = lstResult[1];
            }
        }
        #endregion
    }
}
