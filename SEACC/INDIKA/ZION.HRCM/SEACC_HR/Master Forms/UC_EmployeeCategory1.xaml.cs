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
    /// Interaction logic for UC_EmployeeCategory.xaml
    /// </summary>
    public partial class UC_EmployeeCategory1 : UserControl
    {
        #region Form Load
        public UC_EmployeeCategory1()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Employee_Category_1;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("EmpCategoryID");
            dgr_Main.dt.Columns.Add("EmpCategoryName");
            dgr_Main.dt.Columns.Add("Description"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Category Code", "EmpCategoryID", 100);
            dgr_Main.Add_DatagridColoumn("Name", "EmpCategoryName", 150);
            dgr_Main.Add_DatagridColoumn("Description", "Description", 200); 
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
                    if (txtCategoryID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hrMasEmployeeCategory1 oShiftMaster = tbl_hrMasEmployeeCategory1.Select(txtCategoryID.Text.Trim());
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
                            tbl_hrMasEmployeeCategory1 oCategory = tbl_hrMasEmployeeCategory1.Select(txtCategoryID.Text.Trim());
                            if (oCategory != null)
                            {
                                tbl_hrMasEmployeeCategory1 oEmployeeCategory = new tbl_hrMasEmployeeCategory1(txtCategoryID.Text, txtCategoryName.Text, txtDescription.Text, false, oCategory.UserID_Created, clsSecurity.UserIDLoged, oCategory.UserID_Canceled, oCategory.TerminalID_Created, clsSecurity.TerminalID, oCategory.TerminalID_Canceled, oCategory.Date_Created, clsSecurity.getServerDateTime(), oCategory.Date_Canceled);
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
                            txtCategoryID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hrMasEmployeeCategory1 oEmployeeCategory = new tbl_hrMasEmployeeCategory1(txtCategoryID.Text, txtCategoryName.Text, txtDescription.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategoryID, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCategoryName, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, true);

            txtCategoryID.Text = "";
            txtCategoryID.Tag = null;
            txtCategoryName.Text = "";
            txtDescription.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCategoryID.setReadOnlyStatus(true);
                txtCategoryID.Text = "<Auto Generate>";
            }
            else
                txtCategoryID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrMasEmployeeCategory1 item in tbl_hrMasEmployeeCategory1.SelectAll().Where(p => p.EmpCatagory1_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(item.EmpCatagory1_ID, item.EmpCatagory1_Name, item.Remarks);
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

            if (!clsValidation.Validate_EmptyValue(txtCategoryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCategoryName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrMasEmployeeCategory1 oDetail = tbl_hrMasEmployeeCategory1.Select(txtCategoryID.Text);
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
            foreach (tbl_hrMasEmployeeCategory1 detail1 in tbl_hrMasEmployeeCategory1.SelectAll().Where(p => p.EmpCatagory1_Name == txtCategoryName.Text && p.IsCanceled==false && p.EmpCatagory1_ID != txtCategoryID.Text))
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
                    tbl_hrMasEmployeeCategory1 FillDetails = tbl_hrMasEmployeeCategory1.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCategoryID.IsEnabled = false;
                        txtCategoryID.Text = FillDetails.EmpCatagory1_ID;
                        txtCategoryID.Tag = FillDetails.EmpCatagory1_ID;
                        txtCategoryName.Text = FillDetails.EmpCatagory1_Name;
                        txtDescription.Text = FillDetails.Remarks;
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
        private void txtCategoryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtCategoryID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}
