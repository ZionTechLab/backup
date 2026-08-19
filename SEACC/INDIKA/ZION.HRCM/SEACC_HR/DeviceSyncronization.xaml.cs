using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for DeviceSyncronization.xaml
    /// </summary>
    public partial class DeviceSyncronization : Window
    {
        #region Class Variables
        DataTable dt_Main; 
        #endregion

        #region Form Load
        public DeviceSyncronization()
        {
            InitializeComponent();

         //   RefreshGrid();
            Clearfields();
        }
        #endregion

        #region Action Buttons
        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\ACC\\att2000.mdb;";
            DateTime dtmFromDate = dtp_FromDate.GetDateTime();
            dtmFromDate = new DateTime(dtmFromDate.Year, dtmFromDate.Month, dtmFromDate.Day, 0, 0, 0);

            DateTime dtp_ToDate = dtpToDate.GetDateTime();
            dtp_ToDate = new DateTime(dtp_ToDate.Year, dtp_ToDate.Month, dtp_ToDate.Day, 23, 59, 59);

            try
            {
                OleDbConnection cnn = new OleDbConnection(connetionString);
                DataSet ds = new DataSet();
                cnn.Open();
                string sQuary = "SELECT * FROM CHECKINOUT WHERE CHECKTIME >=#" + dtmFromDate + "# AND CHECKTIME <=#" + dtp_ToDate + "#";
                OleDbDataAdapter Da = new OleDbDataAdapter(sQuary, cnn);
                Da.Fill(ds);
                dt_Main = ds.Tables[0];
                dgv_Main.ItemsSource = dt_Main.DefaultView;
                cnn.Close();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            foreach (DataRow item in dt_Main.Rows)
            {
                string EmployeeID = item[0].ToString();
                DateTime DeviceDateTime = DateTime.Parse(item[1].ToString());
                tbl_tasDevice_RawData oDRD = tbl_tasDevice_RawData.Select_By_EmpID_and_Date(EmployeeID, DeviceDateTime);
                if (oDRD == null)
                {
                    tbl_tasDevice_RawData oDevieRowData = new tbl_tasDevice_RawData("Dev/001", DeviceDateTime, EmployeeID);
                    oDevieRowData.Insert_Advance();
                }

            }

            MessageBox.Show("Attendance Downoad Complete !");
        }
        #endregion

        #region Clear Fields
        private void Clearfields()
        {
            txtDeviceID.Text = "";
            txtDeviceDescription.Text = "";

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtDeviceID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDeviceDescription, true, false, false);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtp_FromDate, true);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtpToDate, true);


        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            tbl_hrMasDevice oDevice = tbl_hrMasDevice.Select(sID);
            if (oDevice != null)
            {
                txtDeviceID.Text = oDevice.Device_ID;
                txtDeviceDescription.Text = oDevice.Device_Description;
            }
        }
        #endregion

        #region Search Events
        private void txtDeviceID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Device_Master);
            if (RowDataSearch.DialogResult == true)
            {
                Clearfields();
                txtDeviceID.Text = lstResult[0];
                txtDeviceID.Tag = lstResult[0];
                FillDetails(lstResult[0]);
            }
        } 
        #endregion
    }
}