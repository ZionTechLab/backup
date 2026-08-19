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
using SEACC_WPFControls;
using System.Data;
using System.Windows.Controls.Primitives;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_YearEndProcess.xaml
    /// </summary>
    public partial class UC_YearEndProcess : UserControl
    {
        #region Class Variables
        DataTable dt_RivisionDate = new DataTable(); 
        #endregion

        #region Form Load
        public UC_YearEndProcess()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Year_End_Process;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dt_RivisionDate.Columns.Add("EmpID");
            dt_RivisionDate.Columns.Add("EmpName");
            dt_RivisionDate.Columns.Add("AttendaceDate");
            dt_RivisionDate.Columns.Add("InDate");
            dt_RivisionDate.Columns.Add("INTime");
            dt_RivisionDate.Columns.Add("OutDate");
            dt_RivisionDate.Columns.Add("OutTime");
            dt_RivisionDate.Columns.Add("WorkedMinutes");
            dt_RivisionDate.Columns.Add("OTMinutes");
            dt_RivisionDate.Columns.Add("OTMinutesApproved");
            dt_RivisionDate.Columns.Add("NoPauHrs"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false); 
            #endregion

            clearFields();
            RefreshGrid("10001", DateTime.Now.Date);

            grd_AttendaceRivision.SelectionUnit = DataGridSelectionUnit.Cell;
            /* select the second cell (index = 1) of the fourth row (index = 3) */
           // SelectCellByIndex(grd_AttendaceRivision, 0, 0);
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        private void btn_YearEndProcess_Click(object sender, RoutedEventArgs e)
        {
            if (txtYearID.Tag != null)
            {

                foreach (tbl_genMasEmployee oEmployee in tbl_genMasEmployee.SelectAll().Where(p => p.IsCanceled == false))
                {
                    foreach (tbl_hrMasLeaveTypes olEaveType in tbl_hrMasLeaveTypes.SelectAll().Where(p => p.IsCanceled == false && p.LeaveType_ID != "default"))
                    {
                        tbl_tasEmployeeLeave_entitled detail = new tbl_tasEmployeeLeave_entitled(clsSecurity.CompanyID, clsSecurity.BranchID, oEmployee.Employee_ID, int.Parse( txtYearID.Tag.ToString()), olEaveType.LeaveType_ID, olEaveType.Std_NoOfDays, 0.00M, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        detail.Insert();
                    }
                }
            }
            SEACCMessageBox.Show(MessegeBoxType.SuccessfullyProcessed);
        }
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtYearID, true, false, false);
            txtYearID.Text = "";

        }
        #endregion

        #region Refresh Grid
        public void RefreshGrid(string EmpID, DateTime Date)
        {
            try
            {
                dt_RivisionDate.Clear();
                foreach (tbl_tasTxDailyAttendance_revision oAttendanceRivision in tbl_tasTxDailyAttendance_revision.SelectAll().Where(p => p.AttendenceDate.Date >= Date && p.AttendenceDate.Date <= Date && p.Employee_ID == EmpID))
                {
                    dt_RivisionDate.Rows.Add(oAttendanceRivision.Employee_ID, oAttendanceRivision.Employee_ID, oAttendanceRivision.AttendenceDate.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeIn_DateTime.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeIn_DateTime.ToString(clsConfig.Format_Time), oAttendanceRivision.TimeOut_DateTime.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeOut_DateTime.ToString(clsConfig.Format_Time), (oAttendanceRivision.WorkedMinutes / 60).ToString("00.00"), (oAttendanceRivision.OTMinutes / 60).ToString("00.00"), (oAttendanceRivision.OTMinutesApproved / 60).ToString(), (oAttendanceRivision.NoPayMinutes / 60).ToString("00.00"));
                }
                grd_AttendaceRivision.ItemsSource = dt_RivisionDate.DefaultView;

                //DataGridRow firstRow = grd_AttendaceRivision.ItemContainerGenerator.ContainerFromItem(grd_AttendaceRivision.Items[0]) as DataGridRow;
                //DataGridCell firstColumnInFirstRow = grd_AttendaceRivision.Columns[1].GetCellContent(firstRow).Parent as DataGridCell;
                ////set background
                //firstColumnInFirstRow.Background = Brushes.Red;

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtYearID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtYearID.Text = lstResult[1];
                txtYearID.Tag = lstResult[0];
            }
        }
        #endregion

        //public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        //{
        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        //    {
        //        DependencyObject child = VisualTreeHelper.GetChild(obj, i);
        //        if (child != null && child is T)
        //            return (T)child;
        //        else
        //        {
        //            T childOfChild = FindVisualChild<T>(child);
        //            if (childOfChild != null)
        //                return childOfChild;
        //        }
        //    }
        //    return null;
        //}

        //public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        //{
        //    if (rowContainer != null)
        //    {
        //        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        if (presenter == null)
        //        {
                 
        //            rowContainer.ApplyTemplate();
        //            presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        }
        //        if (presenter != null)
        //        {
        //            DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            if (cell == null)
        //            {
        //                /* bring the column into view
        //                 * in case it has been virtualized away */
        //                dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
        //                cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            }
        //            return cell;
        //        }
        //    }
        //    return null;
        //}
        
        //public static void SelectCellByIndex(DataGrid dataGrid, int rowIndex, int columnIndex)
        //{
        //    if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.Cell))
        //        throw new ArgumentException("The SelectionUnit of the DataGrid must be set to Cell.");

        //    if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
        //        throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

        //    if (columnIndex < 0 || columnIndex > (dataGrid.Columns.Count - 1))
        //        throw new ArgumentException(string.Format("{0} is an invalid column index.", columnIndex));

        //    dataGrid.SelectedCells.Clear();

        //    object item = dataGrid.Items[rowIndex]; //=Product X
        //    DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        //    if (row == null)
        //    {
        //        dataGrid.ScrollIntoView(item);
        //        row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        //    }
        //    if (row != null)
        //    {
        //        DataGridCell cell = GetCell(dataGrid, row, columnIndex);
        //        if (cell != null)
        //        {
        //            DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(cell);
        //            dataGrid.SelectedCells.Add(dataGridCellInfo);
        //            cell.Focus();
        //        }
        //    }
        //}

        private void grd_AttendaceRivision_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                for (int j = 0; j < grd_AttendaceRivision.Columns.Count; j++)
                {
                    for (int i = 0; i < grd_AttendaceRivision.Items.Count-1; i++)
                    {
                        string s = (grd_AttendaceRivision.Items[i] as DataRowView).Row.ItemArray[j].ToString();
                        if (s == "10001")
                        {                           
                            DataGridRow firstRow = grd_AttendaceRivision.ItemContainerGenerator.ContainerFromItem(grd_AttendaceRivision.Items[1]) as DataGridRow;
                            DataGridCell firstColumnInFirstRow = grd_AttendaceRivision.Columns[0].GetCellContent(firstRow).Parent as DataGridCell;
                         
                            firstColumnInFirstRow.Background = Brushes.Red;
                        }
                    }
                }

                object item = grd_AttendaceRivision.SelectedItem;
                string ID = (grd_AttendaceRivision.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                string g = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[0].ToString();
                if (g == "10001")
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#2A934B");
                }
                else if (g.Trim() == "Rejected")
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#7B0000");
                }
                else
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#FF34495E"); ;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void grd_AttendaceRivision_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            object item = grd_AttendaceRivision.SelectedItem;
            string ID = (grd_AttendaceRivision.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
        }
    }
}
