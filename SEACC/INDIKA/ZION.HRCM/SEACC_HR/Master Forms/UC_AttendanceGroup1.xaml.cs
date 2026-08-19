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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_AttendanceGroup1.xaml
    /// </summary>
    public partial class UC_AttendanceGroup1 : UserControl
    {
        #region Form Load
        public UC_AttendanceGroup1()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.AttendanceGroup1;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("GroupID");
            dgr_Main.dt.Columns.Add("GroupName");
            dgr_Main.dt.Columns.Add("Remark"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Group Code", "GroupID", 100);
            dgr_Main.Add_DatagridColoumn("Group Name", "GroupName", 150);
            dgr_Main.Add_DatagridColoumn("Description", "Remark", 200); 
            #endregion

            ClearFields();
            RefreshGrid();
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

        #region Action Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtGroupID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasEmpAttendanceProcessGroup1 oShiftMaster = tbl_genMasEmpAttendanceProcessGroup1.Select(txtGroupID.Text.Trim());
                            if (oShiftMaster != null)
                            {
                                oShiftMaster.IsCanceled = true;
                                oShiftMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oShiftMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oShiftMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oShiftMaster.Update();

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

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genMasEmpAttendanceProcessGroup1 oCategory = tbl_genMasEmpAttendanceProcessGroup1.Select(txtGroupID.Text.Trim());
                            if (oCategory != null)
                            {
                                tbl_genMasEmpAttendanceProcessGroup1 oEmployeeCategory = new tbl_genMasEmpAttendanceProcessGroup1(txtGroupID.Text, txtGroupName.Text, txtRemarks.Text, false, oCategory.UserID_Created, clsSecurity.UserIDLoged, oCategory.UserID_Canceled, oCategory.TerminalID_Created, clsSecurity.TerminalID, oCategory.TerminalID_Canceled, oCategory.Date_Created, clsSecurity.getServerDateTime(), oCategory.Date_Canceled);
                                oEmployeeCategory.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    } 
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtGroupID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasEmpAttendanceProcessGroup1 oEmployeeCategory = new tbl_genMasEmpAttendanceProcessGroup1(txtGroupID.Text, txtGroupName.Text, txtRemarks.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oEmployeeCategory.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    } 
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show(ex.Message, "Error",MessageBoxButton.OK);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGroupID, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGroupName, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtGroupID.Text = "";
            txtGroupID.Tag = null;
            txtGroupName.Text = "";
            txtRemarks.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGroupID.setReadOnlyStatus(true);
                txtGroupID.Text = "<Auto Generate>";
            }
            else
                txtGroupID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasEmpAttendanceProcessGroup1 item in tbl_genMasEmpAttendanceProcessGroup1.SelectAll().Where(p => p.AttendanceGroup1_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(item.AttendanceGroup1_ID, item.AttendanceGroup1_Name, item.Remarks);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
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

            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtGroupID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtGroupName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasEmpAttendanceProcessGroup1 oDetail = tbl_genMasEmpAttendanceProcessGroup1.Select(txtGroupID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_genMasEmpAttendanceProcessGroup1 detail1 in tbl_genMasEmpAttendanceProcessGroup1.SelectAll().Where(p => p.AttendanceGroup1_Name == txtGroupName.Text && p.IsCanceled == false && p.AttendanceGroup1_ID != txtGroupID.Text))
            {
                if (detail1 != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    break;
                }
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
                    tbl_genMasEmpAttendanceProcessGroup1 FillDetails = tbl_genMasEmpAttendanceProcessGroup1.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtGroupID.IsEnabled = false;
                        txtGroupID.Text = FillDetails.AttendanceGroup1_ID;
                        txtGroupID.Tag = FillDetails.AttendanceGroup1_ID;
                        txtGroupName.Text = FillDetails.AttendanceGroup1_Name;
                        txtRemarks.Text = FillDetails.Remarks;
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion         

        #region Grid Event
        private void grd_EmpCategory_MouseLeftButtonUp1(object sender, EventArgs e)
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
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }

        }
        #endregion

        #region Search Event
        private void txtGroupID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup1);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtGroupID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion

    }
}
