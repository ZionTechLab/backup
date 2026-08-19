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
using System.Windows.Shapes;
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frmSearch_ShiftAdv.xaml
    /// </summary>
    public partial class frmSearch_ShiftAdv : Window
    {
        #region Class Variables
        public List<string> lstReturn; 
        #endregion

        #region Form Load
        public frmSearch_ShiftAdv()
        {
            #region Initialize UserControl
            InitializeComponent();

            lstReturn = new List<string>();
            chk_infiniteDateTo.IsChecked = false;
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("ShiftID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("ShiftIn");
            dgr_Main.dt.Columns.Add("shiftOut");
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Shift Code", "ShiftID", 80);
            dgr_Main.Add_DatagridColoumn("Name", "ShiftName", 120);
            dgr_Main.Add_DatagridColoumn("ShiftIn", "ShiftIn", 120, false);
            dgr_Main.Add_DatagridColoumn("shiftOut", "shiftOut", 120, false);
            #endregion

            RefreshGrid();
        } 
        #endregion

        #region Action Buttons
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int irowID = dgr_Main.SelectedIndex;
                if (irowID != -1)
                {
                    lstReturn.Add(dgr_Main.dt.Rows[irowID]["ShiftID"].ToString());
                    lstReturn.Add(dgr_Main.dt.Rows[irowID]["ShiftName"].ToString());
                    lstReturn.Add(dgr_Main.dt.Rows[irowID]["ShiftIn"].ToString());
                    lstReturn.Add(dgr_Main.dt.Rows[irowID]["shiftOut"].ToString());
                    lstReturn.Add(dtp_DateTo.GetDateTime().ToString());
                    
                    if (chk_infiniteDateTo.IsChecked)
                        lstReturn.Add("1");
                    else
                        lstReturn.Add("0");
                    
                    this.DialogResult = true;
                }
            }
            catch (Exception)
            {
                this.DialogResult = false;
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_tasShiftMaster detail in tbl_tasShiftMaster.SelectAll().Where(p => p.Shift_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(detail.Shift_ID, detail.Shift_Name, detail.ShiftStartTime.ToString(clsConfig.Format_Time), detail.ShiftStartTime.AddMinutes(detail.ShiftMinutes).ToString(clsConfig.Format_Time));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Grid Event
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        } 
        #endregion

        #region Other Required Methods
        public void Show(DateTime dtmFromDate)
        {
            dtp_DateFrom.SetTime(dtmFromDate);
            dtp_DateTo.SetTime(dtmFromDate);
            this.ShowDialog();
        } 
        #endregion

        private void chk_infiniteDateTo_checkBox_Checked(object sender, EventArgs e)
        {
            dtp_DateTo.IsEnabled = false;
        }

        private void chk_infiniteDateTo_checkBox_Unchecked(object sender, EventArgs e)
        {
            dtp_DateTo.IsEnabled = true;
        }
    }
}