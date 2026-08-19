using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_PHARMA.Masters.Company
{
    /// <summary>
    /// Coded by Gayan on 2017-04-20
    /// </summary>
    public partial class UC_Department : UserControl
    {
        #region Form Load
        public UC_Department()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CompanyDepartmentMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("DeptID");
            dgr_Main.dt.Columns.Add("DeptName");
            dgr_Main.dt.Columns.Add("ContactPerson");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Dept. Code", "DeptID", 70, false);
            dgr_Main.Add_DatagridColoumn("Dept. Name", "DeptName", 150);
            dgr_Main.Add_DatagridColoumn("Head Of Department", "ContactPerson", 300);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
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
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_genDepartmentMaster oOldDept = tbl_genDepartmentMaster.Select(txtDepartmentID.Tag.ToString());
                            if (oOldDept != null)
                            {
                                tbl_genDepartmentMaster oDept = new tbl_genDepartmentMaster(txtDepartmentID.Tag.ToString(), txtDeptName.Text, txtDivisionID.Tag != null ? txtDivisionID.Tag.ToString() : "default", oOldDept.Store_ID, txtAddress.Text, txtTelephone.Text, txtFax.Text, txtContactPerson.Text);
                                oDept.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_genDepartmentMaster oNewDept = new tbl_genDepartmentMaster(txtDepartmentID.Tag.ToString(), txtDeptName.Text, txtDivisionID.Tag != null ? txtDivisionID.Tag.ToString() : "default", "default", txtAddress.Text, txtTelephone.Text, txtFax.Text, txtContactPerson.Text);
                            oNewDept.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
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

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartmentID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDeptName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivisionID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtExtension, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtContactPerson, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, true);


            txtDepartmentID.Tag = null;
            txtDivisionID.Tag = null;

            txtDepartmentID.Text = "";
            txtDeptName.Text = "";
            txtAddress.Text = "";
            txtDivisionID.Text = "";
            txtFax.Text = "";
            txtTelephone.Text = "";
            txtTelephone1.Text = "";
            txtExtension.Text = "";
            txtContactPerson.Text = "";
            txtDescription.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtDepartmentID.setReadOnlyStatus(true);
                txtDepartmentID.Text = "<Auto Generate>";
            }
            else
                txtDepartmentID.setReadOnlyStatus(false);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genDepartmentMaster detail in tbl_genDepartmentMaster.SelectAll().Where(p => p.Department_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Department_ID, detail.DepartmentName, detail.ContactPerson);
                }
                dgr_Main.RefreshGrid();
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

            if (!clsValidation.Validate_EmptyValue(txtDepartmentID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDeptName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDivisionID))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtDepartmentID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtDepartmentID.Text = txtDepartmentID.Tag.ToString();
                }

                tbl_genDepartmentMaster oDept = tbl_genDepartmentMaster.Select(txtDepartmentID.Text);
                if (oDept != null)
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
            foreach (tbl_genDepartmentMaster oDept in tbl_genDepartmentMaster.SelectAll().Where(p => p.DepartmentName == txtDeptName.Text && p.Department_ID != txtDepartmentID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
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
                    tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtDepartmentID.Text = detail.Department_ID;
                        txtDepartmentID.Tag = detail.Department_ID;
                        txtDeptName.Text = detail.DepartmentName;
                        txtAddress.Text = detail.Adress;
                        if (detail.Division_ID != "default")
                        {
                            txtDivisionID.Tag = detail.Division_ID;
                            txtDivisionID.Text = clsGenaralName.getName_DivisionMaster(detail.Division_ID);
                        }
                        else
                        {
                            txtDivisionID.Text = "-";
                            txtDivisionID.Tag = detail.Division_ID;
                        }

                        txtTelephone.Text = detail.Telephone;
                        txtFax.Text = detail.Fax;

                        if (detail.ContactPerson != "default" && detail.ContactPerson.Length > 0)
                        {
                            txtContactPerson.Text = detail.ContactPerson;
                        }
                        else
                        {
                            txtContactPerson.Text = "-";
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

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
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

        #region Search Events
        private void txtDivisionID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionDivision);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivisionID.Tag = lstResult[0];
                txtDivisionID.Text = lstResult[1];
            }
        }

        private void txtDepartmentID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionDepartment);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        } 
        #endregion
    }
}
