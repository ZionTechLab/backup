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
using System.Data;
using Digiteq_Logic;
using SEACC_WPFControls;


namespace Digiteq
{
    public partial class UC_HRCalander : UserControl
    {
        #region Class variable
        DataTable dtMain = new DataTable();
        #endregion

        #region Form Load
        public UC_HRCalander()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Company_Calender;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            dtMain.Columns.Add("Code");
            dtMain.Columns.Add("Date");
            dtMain.Columns.Add("Type");
            dtMain.Columns.Add("DurationType");
            dtMain.Columns.Add("Description");
            dtMain.Columns.Add("Status");

            dgr_Entitled.dt.Columns.Add("Status");
            dgr_Entitled.dt.Columns.Add("SectionID");
            dgr_Entitled.dt.Columns.Add("SectionName");
            //dgr_Entitled.Columns.Add("code");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            //this.SEACC_Form.btn_New.Click += btn_New_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            //this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize Data Grid
            dgr_Entitled.Add_DatagridColoumn(ColoumnType.CheckBox, "", "Status", 25, true, true);
            dgr_Entitled.Add_DatagridColoumn("Section ID", "SectionID", 75, false);
            dgr_Entitled.Add_DatagridColoumn("Name", "SectionName", 240);
            #endregion

            txtYearID.Text = DateTime.Now.Year.ToString();

            RefreshYear();
            clearFields();

            RefreshGrid();
            setmenith();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(200);
        }
        #endregion

        #region Action Buttons
        //void btn_New_Click(object sender, RoutedEventArgs e)
        //{
        //    clearFields();
        //}

        //void btn_Cancel_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (SEACC_Form.IsUpdateMode)
        //        {
        //            if (txtHolidayID.Tag != null)
        //            {
        //                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
        //                if (bMessegeBoxResult)
        //                {
        //                    tbl_tasHolidayCalander detail = tbl_tasHolidayCalander.Select(txtHolidayID.Text.Trim());
        //                    if (detail != null)
        //                    {
        //                        detail.IsCanceled = true;
        //                        detail.Date_Canceled = clsSecurity.getServerDateTime();
        //                        detail.TerminalID_Canceled = clsSecurity.TerminalID;
        //                        detail.UserID_Canceled = clsSecurity.UserIDLoged;
        //                        detail.Update();

        //                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
        //                        RefreshGrid();
        //                        clearFields();


        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCExeption.Show(ex);
        //    }
        //}

        //void btn_Save_Click(object sender, RoutedEventArgs e)
        //{

        //}
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHolidayID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHolidayType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, true);
            cls_Formater.SetEnableDisable_TimeSpan(ts_HolidayHours, true);

            txtHolidayID.Text = "<Select a holiday from table>";
            txtHolidayID.Tag = null;
            dtpHoliday.SetTime(DateTime.Now.Date);
            txtHolidayType.Text = "";
            txtHolidayType.Tag = "default";
            txtDescription.Text = "";


            //Add Holiday Popup
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtHoliID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHoliType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtHoliDescription, true, false, true);

            txtHoliID.Text = "";
            txtHoliType.Text = "";
            txtHoliDescription.Text = "";

            txtHoliID.Tag = null;
            txtHoliType.Tag = null;
            txtHoliDescription.Tag = null;
            dtpHolidate.SetTime(DateTime.Now.Date);
            
            cmbHoliDurationTypes.SetValues(typeof(Digiteq_Logic.holidayDurationType));
            cmbHoliDurationTypes.SetSelectedIndex(-1);

            chkHoliStatus.IsChecked = false;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtHoliID.setReadOnlyStatus(true);
                txtHoliID.Text = "<Auto Generated>";
            }
            else
                txtHoliID.setReadOnlyStatus(false);


            pop_Event.IsOpen = false;
        }
        #endregion

        #region Refresh Year
        void RefreshYear()
        {
            int iYear = int.Parse(txtYearID.Text);

            #region Initialize calanders
            cal_1.SetMonth(new DateTime(iYear, 1, 1));
            cal_2.SetMonth(new DateTime(iYear, 2, 1));
            cal_3.SetMonth(new DateTime(iYear, 3, 1));
            cal_4.SetMonth(new DateTime(iYear, 4, 1));
            cal_5.SetMonth(new DateTime(iYear, 5, 1));
            cal_6.SetMonth(new DateTime(iYear, 6, 1));
            cal_7.SetMonth(new DateTime(iYear, 7, 1));
            cal_8.SetMonth(new DateTime(iYear, 8, 1));
            cal_9.SetMonth(new DateTime(iYear, 9, 1));
            cal_10.SetMonth(new DateTime(iYear, 10, 1));
            cal_11.SetMonth(new DateTime(iYear, 11, 1));
            cal_12.SetMonth(new DateTime(iYear, 12, 1));
            #endregion
        }
        #endregion

        #region Refresh Grid
        

        private void RefreshGrid()
        {
            dtMain.Clear();
            DateTime date = dtpHoliday.GetDateTime(); ;

            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            foreach (tbl_tasHolidayCalander detail in tbl_tasHolidayCalander.SelectAll().Where(p => p.IsCanceled == false && p.Holiday_ID != "default" && p.Holiday_Date >= firstDayOfMonth && p.Holiday_Date <= lastDayOfMonth))
            {
                dtMain.Rows.Add(detail.Holiday_ID, detail.Holiday_Date.ToString("dd/MM/yyyy"), (clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID) == "default") ? "-" : clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID), ((holidayDurationType)detail.HolidayDurationType).ToString(), detail.Holiday_Description, (detail.Holiday_Status == true) ? "Active" : "Inactive");
            }
            dgv_Holyday.ItemsSource = dtMain.DefaultView;
        }

        private void RefreshPop_EntitleGrid()
        {
            try
            {
                dgr_Entitled.dt.Clear();

                DateTime dDate = dtpHoliday.GetDateTime().Date;
                foreach (tbl_genMasSection detail in tbl_genMasSection.SelectAll().Where(p => p.IsCanceled == false && p.Section_Name != "default"))
                {
                    dgr_Entitled.dt.Rows.Add(false, detail.SectionID, detail.Section_Name);
                }
                dgr_Entitled.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtHoliID))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtHoliType))
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
                    txtHoliID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_tasHolidayCalander detail = tbl_tasHolidayCalander.Select(txtHoliID.Tag.ToString());
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            RefreshPop_EntitleGrid();
            try
            {
                if (sID != null)
                {
                    tbl_tasHolidayCalander detail = tbl_tasHolidayCalander.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtHolidayID.Text = detail.Holiday_ID.ToString();
                        txtHolidayID.Tag = detail.Holiday_ID.ToString();
                        txtDescription.Text = detail.Holiday_Description;
                        dtpHoliday.SetTime(detail.Holiday_Date);
                        ts_HolidayHours.setMinutes(detail.Holiday_Hours);
                        txtHolidayType.Text = clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID);
                        txtHolidayType.Tag = detail.HolydayType_ID;
                        if (detail.Holiday_Status == true)
                        {
                            chkStatus.IsChecked = false;
                        }
                        else
                        {
                            chkStatus.IsChecked = true;
                        }

                        foreach (tbl_tasHolidayCalander_Entitled oHoliCalEntitles in tbl_tasHolidayCalander_Entitled.SelectAllByHoliday_ID(detail.Holiday_ID.ToString()))
                        {
                            DataRow row = dgr_Entitled.dt.Select("SectionID='" + oHoliCalEntitles.SectionID + "'").FirstOrDefault();
                            row["Status"] = true;
                        }


                        #region Holiday Create Popup
                        txtHoliID.Text = detail.Holiday_ID.ToString();
                        txtHoliType.Text = clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID);
                        txtHoliDescription.Text = detail.Holiday_Description;

                        txtHoliID.Tag = detail.Holiday_ID.ToString();
                        txtHoliType.Tag = detail.HolydayType_ID;

                        dtpHolidate.SetTime(detail.Holiday_Date);
                        cmbHoliDurationTypes.SetSelectedIndex(detail.HolidayDurationType);

                        chkHoliStatus.IsChecked = detail.Holiday_Status;
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

        #region Grid Event
        private void dgv_Holyday_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                pop_Event.IsOpen = false;
                object item = dgv_Holyday.SelectedItem;
                if (item != null)
                {
                    pop_Event.IsOpen = true;
                    string GridID = (dgv_Holyday.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sDate = (dgv_Holyday.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);

                    dgv_HolydayPoP.ItemsSource = null;
                    if (dtMain.Rows.Count > 0)
                    {
                        var rows = dtMain.AsEnumerable().Where(r => (r.Field<string>("date")) == sDate);
                        if (rows.Any())
                        {
                            DataTable dt_holidayPoPup = rows.CopyToDataTable();
                            dgv_HolydayPoP.ItemsSource = dt_holidayPoPup.DefaultView;
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

        #region Search Event
        private void txtHolidayID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.Calender);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    clearFields();
            //    txtHolidayID.Text = lstResult[0];
            //    fillDetails(lstResult[0]);
            //}
        }

        private void txtHolidayType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.Holiday_Type);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtHolidayType.Text = lstResult[1];
            //    txtHolidayType.Tag = lstResult[0];
            //}
        }

        private void SEACC_LableTextBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtYearID.Text = lstResult[0];
                RefreshYear();
            }
        }
        #endregion

        #region Other Events
        private void UC_Calander_MonthSelected(object sender, EventArgs e)
        {
            dtMain.Clear();
            UC_Calander oCalander = sender as UC_Calander;
            cal_Big.SetMonth(oCalander.dtm_FirstdayOfMonth);
            foreach (tbl_tasHolidayCalander detail in tbl_tasHolidayCalander.SelectAll().Where(p => p.IsCanceled == false && p.Holiday_Date.Date >= oCalander.dtm_FirstdayOfMonth && p.Holiday_Date.Date <= oCalander.dtm_FirstdayOfMonth.AddMonths(1).AddDays(-1)))
            {
                dtMain.Rows.Add(detail.Holiday_ID, detail.Holiday_Date.ToString("dd/MM/yyyy"), (clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID) == "default") ? "-" : clsRef_Name.get_HolidayType_Name(detail.HolydayType_ID), ((holidayDurationType)detail.HolidayDurationType).ToString(), detail.Holiday_Description, (detail.Holiday_Status == true) ? "Active" : "Inactive");
            }
            dgv_Holyday.ItemsSource = dtMain.DefaultView;
        }

        private void cal_Big_Date_MouseClick(object sender, EventArgs e)
        {
            clearFields();
            UC_CalanderDate o = sender as UC_CalanderDate;
            dtpHoliday.SetTime(o.Date.Date);
            dtpHolidate.SetTime(o.Date.Date);

            tbl_tasHolidayCalander detail = tbl_tasHolidayCalander.SelectByHolidayDate(dtpHoliday.GetDateTime().Date);
            if (detail != null)
            {
                fillDetails(detail.Holiday_ID);
            }
            

            pop_Event.IsOpen = true;
            RefreshPop_EntitleGrid();

            dgv_HolydayPoP.ItemsSource = null;
            if (dtMain.Rows.Count > 0)
            {
                var rows = dtMain.AsEnumerable().Where(r => (r.Field<string>("date")) == o.Date.Date.ToString("dd/MM/yyyy"));
                if (rows.Any())
                {
                    DataTable dt_holidayPoPup = rows.CopyToDataTable();
                    dgv_HolydayPoP.ItemsSource = dt_holidayPoPup.DefaultView;
                }
            }

            //MessageBox.Show(o.Date.Date.ToString());
        }
        #endregion

        #region Set Month for Big Calender
        private void setmenith()
        {
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, DateTime.Now.Month, 1);
            //DateTime firstDay = new DateTime(year, 1, 1);

            cal_Big.SetMonth(firstDay);
        }
        #endregion

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.IsOpen = false;
        }

        private void btn_Agenda_Click(object sender, RoutedEventArgs e)
        {
            grd_Agenda.Visibility = Visibility.Visible;
            grd_Calander.Visibility = Visibility.Hidden;
        }

        private void btn_month_Click(object sender, RoutedEventArgs e)
        {
            grd_Agenda.Visibility = Visibility.Hidden;
            grd_Calander.Visibility = Visibility.Visible;
        }

        private void cal_Big_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                #region Status Check
                bool bStatus = false;
                if (chkStatus.IsChecked == true)
                {
                    bStatus = false;
                }
                else
                {
                    bStatus = true;
                }
                #endregion

                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_tasHolidayCalander OldRecord = tbl_tasHolidayCalander.Select(txtHolidayID.Text.Trim());
                            if (OldRecord != null)
                            {
                                tbl_tasHolidayCalander detail = new tbl_tasHolidayCalander(txtHolidayID.Text, dtpHoliday.GetDateTime(), txtHolidayType.Tag.ToString(), txtDescription.Text, 1, ts_HolidayHours.GetMinutes(), bStatus, OldRecord.IsCanceled, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Created, OldRecord.Date_Modified, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtHolidayID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_tasHolidayCalander detail = new tbl_tasHolidayCalander(txtHolidayID.Text, dtpHoliday.GetDateTime(), txtHolidayType.Tag.ToString(), txtDescription.Text, 1, ts_HolidayHours.GetMinutes(), bStatus, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        
                        detail.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        pop_Event.IsOpen = false;
                        cal_Big.SetMonth(detail.Holiday_Date);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }

                finally
                {
                    RefreshGrid();
                    clearFields();
                }
            }
        }

        #region PoPup

        #region Event Save
        private void btn_PoPSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (DataRow row in dgr_Entitled.dt.Rows)
                {
                    bool status = bool.Parse(row["Status"].ToString());

                    #region Delete/Insert record
                    tbl_tasHolidayCalander_Entitled oOldRecord = tbl_tasHolidayCalander_Entitled.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtHolidayID.Text.Trim(), row["SectionID"].ToString());
                    if (oOldRecord != null)
                    {
                        if (!status)
                            oOldRecord.Delete();
                    }
                    else
                    {
                        if (status)
                        {
                            tbl_tasHolidayCalander_Entitled nNewRecord = new tbl_tasHolidayCalander_Entitled(clsSecurity.CompanyID, clsSecurity.BranchID, txtHolidayID.Tag.ToString(), row["SectionID"].ToString());
                            nNewRecord.Insert();
                        }
                    }
                    #endregion
                }
                SEACCMessageBox.Show("Succesfully completed...! ", "", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Event Grid events
        private void dgv_HolydayPoP_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgv_HolydayPoP.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgv_HolydayPoP.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region New Holiday Save
        private void btnHoliSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {

                            tbl_tasHolidayCalander oldRecord = tbl_tasHolidayCalander.Select(txtHoliID.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_tasHolidayCalander detail = new tbl_tasHolidayCalander(oldRecord.Holiday_ID, dtpHolidate.GetDateTime().Date, txtHoliType.Tag.ToString(), txtHoliDescription.Text, cmbHoliDurationTypes.GetSelectedIndex(), 0, chkHoliStatus.IsChecked, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, "default", oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            
                        }
                    }


                    else
                    {
                        //tbl_tasHolidayCalander nNewHoliday = new tbl_tasHolidayCalander(txtHoliID.Tag.ToString(), dtpHolidate.GetDateTime().Date, txtHoliType.Tag.ToString(), txtHoliDescription.Text, cmbHoliDurationTypes.GetSelectedIndex(), 0, chkHoliStatus.IsChecked, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime);

                        tbl_tasHolidayCalander oldRec = tbl_tasHolidayCalander.SelectByHolidayDate(dtpHolidate.GetDateTime().Date);
                        if(oldRec == null)
                        {
                            tbl_tasHolidayCalander nNewHoliday = new tbl_tasHolidayCalander(txtHoliID.Tag.ToString(), dtpHolidate.GetDateTime().Date, txtHoliType.Tag.ToString(), txtHoliDescription.Text, cmbHoliDurationTypes.GetSelectedIndex(), 0, chkHoliStatus.IsChecked, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                            nNewHoliday.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                        else
                        {
                            tbl_tasHolidayCalander nNewHoliday = new tbl_tasHolidayCalander(oldRec.Holiday_ID, oldRec.Holiday_Date, txtHoliType.Tag.ToString(), txtHoliDescription.Text, cmbHoliDurationTypes.GetSelectedIndex(), 0, chkHoliStatus.IsChecked, oldRec.IsCanceled, oldRec.UserID_Created, clsSecurity.UserIDLoged, "default", oldRec.TerminalID_Created, clsSecurity.TerminalID, oldRec.TerminalID_Canceled, oldRec.Date_Created, clsSecurity.getServerDateTime(), oldRec.Date_Canceled);
                            nNewHoliday.Update();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        }

                        //nNewHoliday.Insert();
                        //SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    clearFields();
                    RefreshGrid();
                    setmenith();
                }
            }
        }
        #endregion

        #region Search
        private void txtHoliType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Holiday_Type);
            if (RowDataSearch.DialogResult == true)
            {
                txtHoliType.Text = lstResult[1];
                txtHoliType.Tag = lstResult[0];
            }
        }
        #endregion

        #endregion

    }
}