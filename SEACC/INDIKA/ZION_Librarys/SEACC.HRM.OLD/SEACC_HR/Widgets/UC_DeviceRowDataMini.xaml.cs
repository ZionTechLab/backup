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
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.IO;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_DeviceRowDataMini.xaml
    /// </summary>
    public partial class UC_DeviceRowDataMini : UserControl
    {
        #region Class Variables
        DataTable dt_RowData = new DataTable(); 
        #endregion

        #region Form Load
        public UC_DeviceRowDataMini()
        {
            #region Initialize Usercontrol
            InitializeComponent(); 
            #endregion

            #region Initialize Data Table
            dt_RowData.Columns.Add("DeviceID");
            dt_RowData.Columns.Add("DeviceDate");
            dt_RowData.Columns.Add("DeviceTime");
            #endregion
        } 
        #endregion

        #region Clear Fields
        public void ClearData()
        {
            dt_RowData.Clear();
        } 
        #endregion

        #region Refresh Grid
        public void RefrshGrid(string EmpID, DateTime Date)
        {
            try
            {
                dt_RowData.Clear();

                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(EmpID, clsSecurity.CompanyID, clsSecurity.BranchID);
                foreach (sp_tasDevice_RawData oDRD in sp_tasDevice_RawData.SelectAll("%", oEmployee.Employee_ID2, Date.Date, Date.Date))
                {
                    dt_RowData.Rows.Add(oDRD.Device_ID, oDRD.Device_DateTime.ToString(clsConfig.Format_Date), oDRD.Device_DateTime.ToString(clsConfig.Format_Time));
                }

                //foreach (tbl_tasDevice_RawData oDeviceaRowData in tbl_tasDevice_RawData ().Where(p => p.Device_DateTime.Date >= Date && p.Device_DateTime.Date <= Date))
                //{
                //    dt_RowData.Rows.Add(oDeviceaRowData.Device_ID, oDeviceaRowData.Device_DateTime.ToString(clsConfig.Format_Date), oDeviceaRowData.Device_DateTime.ToString(clsConfig.Format_Time));
                //}
                grd_RowDataDetails.ItemsSource = dt_RowData.DefaultView;


                if (dt_RowData.Rows.Count <= 0)
                    grd_RowDataDetails.Visibility = Visibility.Hidden;
                else
                    grd_RowDataDetails.Visibility = Visibility.Visible; ;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion
    }
}
