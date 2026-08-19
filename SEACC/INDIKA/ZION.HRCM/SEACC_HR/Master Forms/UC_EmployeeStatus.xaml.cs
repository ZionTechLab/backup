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
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_EmployeeStatus.xaml
    /// </summary>
    public partial class UC_EmployeeStatus : UserControl
    {     
        #region Form Load
        public UC_EmployeeStatus()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            this.SEACC_Form.enmFormName = FormName.Employee_Status_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("StatusID");
            dgr_Main.dt.Columns.Add("SatatusName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Status Code", "StatusID", 80);
            dgr_Main.Add_DatagridColoumn("Name", "SatatusName", 150); 
            #endregion

            clearFields();
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

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtStatusTypeID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hrMasEmployeeStatus detail = tbl_hrMasEmployeeStatus.Select(txtStatusTypeID.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                clearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
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
                            tbl_hrMasEmployeeStatus oldRecord = tbl_hrMasEmployeeStatus.Select(txtStatusTypeID.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_hrMasEmployeeStatus oCity = new tbl_hrMasEmployeeStatus(txtStatusTypeID.Text, txtStatusTypeName.Text, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                oCity.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtStatusTypeID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hrMasEmployeeStatus oCity = new tbl_hrMasEmployeeStatus(txtStatusTypeID.Text, txtStatusTypeName.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oCity.Insert();
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
                    clearFields();
                    RefreshGrid();
                }
            }
        }
        #endregion
        
        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtStatusTypeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtStatusTypeName, true, false, false);

            txtStatusTypeName.Text = "";
            txtStatusTypeID.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtStatusTypeID.setReadOnlyStatus(true);
                txtStatusTypeID.Text = "<Auto Generate>";
            }
            else
                txtStatusTypeID.setReadOnlyStatus(false);
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrMasEmployeeStatus item in tbl_hrMasEmployeeStatus.SelectAll().Where(p => p.Emp_statusID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(item.Emp_statusID, item.Emp_status_Name);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion
      
        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;
                } 
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtStatusTypeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtStatusTypeName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrMasEmployeeStatus detail = tbl_hrMasEmployeeStatus.Select(txtStatusTypeID.Text);
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_hrMasEmployeeStatus detail1 in tbl_hrMasEmployeeStatus.SelectAll().Where(p => p.Emp_status_Name == txtStatusTypeName.Text && p.IsCanceled==false && p.Emp_statusID != txtStatusTypeID.Text))
            {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist,"Employee Satatus Name");
                    break;              
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
                    tbl_hrMasEmployeeStatus oEmpStatus = tbl_hrMasEmployeeStatus.Select(sID);
                    if (oEmpStatus != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtStatusTypeID.IsEnabled = false;
                        txtStatusTypeID.Text = oEmpStatus.Emp_statusID;
                        txtStatusTypeID.Tag = oEmpStatus.Emp_statusID;
                        txtStatusTypeName.Text = oEmpStatus.Emp_status_Name;
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
        private void ddd_MouseLeftButtonUp1(object sender, EventArgs e)
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

        #region Search Event
        private void txtStatusTypeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Status);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                txtStatusTypeID.Text = lstResult[0];
                txtStatusTypeID.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        } 
        #endregion
    }
}
