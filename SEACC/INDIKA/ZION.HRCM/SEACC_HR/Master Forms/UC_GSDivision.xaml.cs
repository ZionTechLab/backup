using System;
using System.Collections.Generic;
using System.Data;
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


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_GSDivision.xaml
    /// </summary>
    public partial class UC_GSDivision : UserControl
    {
        #region Form Load
        public UC_GSDivision()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Grama_Niladari_Unit_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("GNUnitID");
            dgr_Main.dt.Columns.Add("provinceID");
            dgr_Main.dt.Columns.Add("DistrictID");
            dgr_Main.dt.Columns.Add("CityID");
            dgr_Main.dt.Columns.Add("GN_DivisionID");
            dgr_Main.dt.Columns.Add("Gn_DivisionName");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click; 
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("ID", "GNUnitID", 0, false);
            dgr_Main.Add_DatagridColoumn("Province", "provinceID", 100);
            dgr_Main.Add_DatagridColoumn("District", "DistrictID", 100);
            dgr_Main.Add_DatagridColoumn("City", "CityID", 100);
            dgr_Main.Add_DatagridColoumn("Gn Div. Code", "GN_DivisionID", 100);
            dgr_Main.Add_DatagridColoumn("Gn Div. Name", "Gn_DivisionName", 200);  
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
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtGN_Division_ID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hr_MasGramaNiladhariUnit detail = tbl_hr_MasGramaNiladhariUnit.Select(txtGN_Division_ID.Tag.ToString());
                            detail.Delete();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                RefreshGrid();
                ClearFields();
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
                            tbl_hr_MasGramaNiladhariUnit oldRecord = tbl_hr_MasGramaNiladhariUnit.Select(txtGN_Division_ID.Text);
                            if (oldRecord != null)
                            {
                                tbl_hr_MasGramaNiladhariUnit oEmployeeCategory = new tbl_hr_MasGramaNiladhariUnit(txtGN_Division_ID.Text, txtProvinceCode.Tag.ToString(), txtDistrictCode.Tag.ToString(), txtcity.Tag.ToString(), txtGNDivisionCode.Text, txtGNDivisionName.Text, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled); 
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
                            txtGN_Division_ID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hr_MasGramaNiladhariUnit oEmployeeCategory = new tbl_hr_MasGramaNiladhariUnit(txtGN_Division_ID.Text, txtProvinceCode.Tag.ToString(), txtDistrictCode.Tag.ToString(), txtcity.Tag.ToString(), txtGNDivisionCode.Text, txtGNDivisionName.Text,false,clsSecurity.UserIDLoged,"default","default",clsSecurity.TerminalID,"default","default",clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime());
                        oEmployeeCategory.Insert();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGN_Division_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProvinceCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDistrictCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtcity, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGNDivisionCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGNDivisionName, true, false, false);

            txtProvinceCode.Text = "";
            txtProvinceCode.Tag = "default";
            txtDistrictCode.Text = "";
            txtDistrictCode.Tag = "default";
            txtcity.Text = "";
            txtcity.Tag = "default";
            txtGNDivisionCode.Text = "";
            txtGNDivisionCode.Tag = "Default";
            txtGNDivisionName.Text = "";
            txtProvinceCode.Tag = null;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGN_Division_ID.setReadOnlyStatus(true);
                txtGN_Division_ID.Text = "<Auto Generate>";
            }
            else
                txtGN_Division_ID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_hr_MasGramaNiladhariUnit detail in tbl_hr_MasGramaNiladhariUnit.SelectAll().Where(p => p.Gn_DivisionCode != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Gn_Division_ID, clsRef_Name.get_Province_Name(detail.Province_ID), clsRef_Name.get_District_Name(detail.District_ID), clsRef_Name.get_City_Name(detail.City_ID), detail.Gn_DivisionCode, detail.Gn_DivisionName);
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
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtGNDivisionCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtGNDivisionName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hr_MasGramaNiladhariUnit oDetail = tbl_hr_MasGramaNiladhariUnit.Select(txtGN_Division_ID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID1)
        {
            try
            {
                if (sID1 != null)
                {
                    tbl_hr_MasGramaNiladhariUnit details = tbl_hr_MasGramaNiladhariUnit.Select(sID1);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtGN_Division_ID.Text = details.Gn_Division_ID;
                        txtGN_Division_ID.Tag = details.Gn_Division_ID;
                        txtProvinceCode.Text = clsRef_Name.get_Province_Name(details.Province_ID);
                        txtProvinceCode.Tag = details.Province_ID;
                        txtDistrictCode.Text =clsRef_Name.get_District_Name(details.District_ID);
                        txtDistrictCode.Tag = details.District_ID;
                        txtcity.Text =clsRef_Name.get_City_Name( details.City_ID);
                        txtcity.Tag = details.City_ID;
                        txtGNDivisionCode.Text = details.Gn_DivisionCode;
                        txtGNDivisionCode.Tag = details.Gn_DivisionCode;
                        txtGNDivisionName.Text = details.Gn_DivisionName;
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
        private void grd_GNDivision_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtProvinceCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ProvinceCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtProvinceCode.Text = clsRef_Name.get_Province_Name(lstResult[0]);
                txtProvinceCode.Tag = lstResult[0];
            }
        }

        private void txtDistrictCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {
                txtDistrictCode.Text = clsRef_Name.get_District_Name(lstResult[0]);
                txtDistrictCode.Tag = lstResult[0];
            }
        }

        private void txtDivisionCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtcity.Text = clsRef_Name.get_City_Name(lstResult[0]);
                txtcity.Tag = lstResult[0];
            }
        }

        private void txtGN_Division_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.GN_Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtGN_Division_ID.Text = lstResult[2];
                txtGN_Division_ID.Tag = lstResult[2];
                fillDetails(lstResult[2]);
            }
        }
        #endregion  
    }
}
