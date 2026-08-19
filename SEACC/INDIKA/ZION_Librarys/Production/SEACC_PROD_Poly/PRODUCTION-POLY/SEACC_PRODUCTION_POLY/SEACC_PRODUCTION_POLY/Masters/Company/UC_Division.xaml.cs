using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_WPFControls;
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

namespace SEACC_PRODUCTION_POLY.Masters.Company
{
    /// <summary>
    /// Coded by Gayan on 2017-04-20
    /// Audit Trail Not developped in C#
    /// </summary>
    public partial class UC_Division : UserControl
    {
        #region Initialize Form
        public UC_Division()
        {
            #region Initialization Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.CompanyDivitionMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initalize Data Table
            dgr_Main.dt.Columns.Add("DivCode");
            dgr_Main.dt.Columns.Add("DivName");
            dgr_Main.dt.Columns.Add("HeadofDiv");
            #endregion

            #region Initalize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Grid
            dgr_Main.Add_DatagridColoumn("Div. Code", "DivCode", 75 , false);
            dgr_Main.Add_DatagridColoumn("Division Name", "DivName", 150);
            dgr_Main.Add_DatagridColoumn("Head of Division", "HeadofDiv", 300);
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
                            tbl_genDivisionMaster oOldDiv = tbl_genDivisionMaster.Select(txtDivisionCode.Tag.ToString());
                            if (oOldDiv != null)
                            {
                                tbl_genDivisionMaster oDiv = new tbl_genDivisionMaster(txtDivisionCode.Tag.ToString(), txtDivisionName.Text, oOldDiv.CompanyBranch_ID, txtAddress.Text, txtTelephone1.Text, txtFax.Text, txtHeadOfDivision.Text);
                                oDiv.Update();
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
                            tbl_genDivisionMaster oNewDiv = new tbl_genDivisionMaster(txtDivisionCode.Tag.ToString(), txtDivisionName.Text, clsSecurity.BranchID, txtAddress.Text, txtTelephone1.Text, txtFax.Text, txtHeadOfDivision.Text);
                            oNewDiv.Insert();
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
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtDivisionCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDivisionName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtHeadOfDivision, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            txtDivisionCode.Tag = null;

            txtDivisionCode.Text = "";
            txtAddress.Text = "";
            txtDivisionName.Text = "";
            txtFax.Text = "";
            txtHeadOfDivision.Text = "";
            txtTelephone1.Text = "";
            txtHeadOfDivision.Text = "";
            txtRemarks.Text = "";

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
                foreach (tbl_genDivisionMaster oDivision in tbl_genDivisionMaster.SelectAll().Where(p => p.Division_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oDivision.Division_ID, oDivision.DivisionName, oDivision.ContactPerson);
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
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtDivisionCode.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtDivisionCode.Text = txtDivisionCode.Tag.ToString();
                }

                tbl_genDivisionMaster oDiv = tbl_genDivisionMaster.Select(txtDivisionCode.Text);
                if (oDiv != null)
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
            foreach (tbl_genDivisionMaster oDiv in tbl_genDivisionMaster.SelectAll().Where(p => p.DivisionName == txtDivisionName.Text && p.Division_ID != txtDivisionCode.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
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
                    ClearFields();
                    tbl_genDivisionMaster oDivision = tbl_genDivisionMaster.Select(sID);
                    if (oDivision != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtDivisionCode.Tag = oDivision.Division_ID;

                        txtDivisionCode.Text = oDivision.Division_ID;
                        txtDivisionName.Text = oDivision.DivisionName;
                        txtAddress.Text = oDivision.Adress;
                        txtTelephone1.Text = oDivision.Telephone;
                        txtFax.Text = oDivision.Fax;
                        txtHeadOfDivision.Text = oDivision.ContactPerson;
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
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtDivisionCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionDivision);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }
}
