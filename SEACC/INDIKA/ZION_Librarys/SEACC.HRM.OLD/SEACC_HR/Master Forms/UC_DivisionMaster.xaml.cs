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
    /// Interaction logic for UC_DivisionMaster.xaml
    /// </summary>
    public partial class UC_DivisionMaster : UserControl
    {
        #region Form Load
        public UC_DivisionMaster()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Division_Creation;
            SEACC_Form.Initialize();

            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);

            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;


            dgr_Main.dt.Columns.Add("DivCode");
            dgr_Main.dt.Columns.Add("DivName");
            dgr_Main.dt.Columns.Add("BranchCode");
            dgr_Main.dt.Columns.Add("Address");
            dgr_Main.dt.Columns.Add("Telephone");
            dgr_Main.dt.Columns.Add("Fax");
            dgr_Main.dt.Columns.Add("HeadofDiv");
            dgr_Main.dt.Columns.Add("Remarks");


            #region Grid Initialize
            dgr_Main.Add_DatagridColoumn("Div. Code", "DivCode", 75);
            dgr_Main.Add_DatagridColoumn("Name", "DivName", 75);
            dgr_Main.Add_DatagridColoumn("Branch", "BranchCode", 75);
            dgr_Main.Add_DatagridColoumn("Address", "Address", 70);
            dgr_Main.Add_DatagridColoumn("Telephone", "Telephone", 75);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 75);
            dgr_Main.Add_DatagridColoumn("Head of Div.", "HeadofDiv", 150);
            dgr_Main.Add_DatagridColoumn("Name", "Remarks", 200);
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

        #region Action Button

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
                    if (txtDivisionCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_genMasDivision oDivision = tbl_genMasDivision.Select(txtDivisionCode.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oDivision != null)
                            {
                                oDivision.IsCanceled = true;
                                oDivision.UserID_Canceled = clsSecurity.UserIDLoged;
                                oDivision.Date_Canceled = clsSecurity.getServerDateTime();
                                oDivision.TerminalID_Canceled = clsSecurity.TerminalID;
                                oDivision.Update();
                            }
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            clearFields();
                            RefreshGrid();
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

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genMasDivision OldRecode = tbl_genMasDivision.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtDivisionCode.Text);
                            if (OldRecode != null)
                            {
                                tbl_genMasDivision oDivisionMaster = new tbl_genMasDivision(clsSecurity.CompanyID, clsSecurity.BranchID, txtDivisionCode.Text, txtDivisionName.Text, txtAddress.Text, txtTelephone1.Text, txtTelephone2.Text, txtextention.Text, txtFax.Text, txtHeadOfDivision.Tag.ToString(), txtRemarks.Text, txtRegDetail_ID.Tag != null ? txtRegDetail_ID.Tag.ToString() : "default", OldRecode.IsCanceled, OldRecode.UserID_Created, clsSecurity.UserIDLoged, OldRecode.UserID_Canceled, OldRecode.TerminalID_Created, clsSecurity.TerminalID, OldRecode.TerminalID_Canceled, OldRecode.Date_Created, clsSecurity.getServerDateTime(), OldRecode.Date_Canceled);
                                oDivisionMaster.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

                            }
                        }
                    }
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtDivisionCode.Text = SEACC_Form.getAutoGeneratedCode();
                        tbl_genMasDivision oDivisionMaster = new tbl_genMasDivision(clsSecurity.CompanyID, clsSecurity.BranchID, txtDivisionCode.Text, txtDivisionName.Text, txtAddress.Text, txtTelephone1.Text, txtTelephone2.Text, txtextention.Text, txtFax.Text, txtHeadOfDivision.Text, txtRemarks.Text, txtRegDetail_ID.Tag != null ? txtRegDetail_ID.Tag.ToString() : "default", false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime);
                        oDivisionMaster.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
                }
            }
        }
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtDivisionCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDivisionName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtBranchCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtHeadOfDivision, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtextention, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtextention, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRegDetail_ID, true, false, false);

            txtHeadOfDivision.Tag = "default";
            txtRegDetail_ID.Tag = null;

            txtAddress.Text = "";
            txtBranchCode.Text = "";
            txtDivisionName.Text = "";
            txtFax.Text = "";
            txtHeadOfDivision.Text = "";
            txtTelephone1.Text = "";
            txtTelephone2.Text = "";
            txtextention.Text = "";
            txtHeadOfDivision.Text = "";
            txtRemarks.Text = "";
            txtRegDetail_ID.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtDivisionCode.setReadOnlyStatus(true);
                txtDivisionCode.Text = "<Auto Generate>";
            }
            else
                txtDivisionCode.setReadOnlyStatus(false);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasDivision oDivision in tbl_genMasDivision.SelectAll().Where(p => p.Division_ID != "Default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oDivision.Division_ID, oDivision.DivisionName, oDivision.CompanyBranch_ID == "default" ? "-" : oDivision.CompanyBranch_ID, oDivision.Address, oDivision.Telephone1, oDivision.Fax, clsRef_Name.get_EmployeeName(oDivision.EmployeeID_HoDiv));
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
                    bStatus = true;
            }
            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtDivisionCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDivisionName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasDivision oDetail = tbl_genMasDivision.Select(txtDivisionCode.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
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
            foreach (tbl_genMasDivision detail1 in tbl_genMasDivision.SelectAll().Where(p => p.DivisionName == txtDivisionName.Text && p.IsCanceled == false && p.Division_ID != txtDivisionCode.Text))
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

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    clearFields();
                    tbl_genMasDivision oDivision = tbl_genMasDivision.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (oDivision != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtDivisionCode.Tag = oDivision.Division_ID;
                        txtRegDetail_ID.Tag = oDivision.Reg_ID;

                        txtDivisionCode.IsEnabled = false;
                        txtAddress.Text = oDivision.Address;
                        txtBranchCode.Text = oDivision.CompanyBranch_ID == "default" ? "-" : oDivision.CompanyBranch_ID;
                        txtDivisionCode.Text = oDivision.Division_ID;
                        txtDivisionName.Text = oDivision.DivisionName;
                        txtFax.Text = oDivision.Fax;
                        if (oDivision.EmployeeID_HoDiv != "Default")
                        {
                            txtHeadOfDivision.Tag = oDivision.EmployeeID_HoDiv;
                            txtHeadOfDivision.Text = oDivision.EmployeeID_HoDiv + "-" + clsRef_Name.get_EmployeeName(oDivision.EmployeeID_HoDiv);
                        }
                        txtTelephone1.Text = oDivision.Telephone1;
                        txtTelephone2.Text = oDivision.Telephone2;
                        txtextention.Text = oDivision.Extention;
                        txtRemarks.Text = oDivision.Remarks;
                        txtRegDetail_ID.Text = (oDivision.Reg_ID != null && oDivision.Reg_ID != "default") ? oDivision.Reg_ID + " - " + clsRef_Name.get_RegisterationDetails(oDivision.Reg_ID) : "-";
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
        private void grd_Division_MouseLeftButtonUp1(object sender, EventArgs e)
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

        private void txtDivisionCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                txtDivisionCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtHeadOfDivision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtHeadOfDivision.Text = lstResult[0] + "-" + lstResult[2];
                txtHeadOfDivision.Tag = lstResult[0];
            }
        }

        private void txtRegDetail_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch(true);
            List<string> lstResult = RowDataSearch.Show(Search.RegistrationDetails);
            if (RowDataSearch.DialogResult == true)
            {
                txtRegDetail_ID.Text = lstResult[0] + "-" + lstResult[1];
                txtRegDetail_ID.Tag = lstResult[0];
            }
        }

        #endregion


    }
}
