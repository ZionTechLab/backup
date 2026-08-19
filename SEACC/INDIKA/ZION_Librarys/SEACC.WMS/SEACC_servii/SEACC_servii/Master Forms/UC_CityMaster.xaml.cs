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
using SEACC_servii.Search_Forms;

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_CityMaster.xaml
    /// </summary>
    public partial class UC_CityMaster : UserControl
    {
        #region FormLoad
        public UC_CityMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.CityMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("DistrictCode");
            dgr_Main.dt.Columns.Add("DistrictName");
            dgr_Main.dt.Columns.Add("CityCode");
            dgr_Main.dt.Columns.Add("CityName");
            #endregion

            #region  Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Grid Initialize
            dgr_Main.Add_DatagridColoumn("City Code", "CityCode", 60);
            dgr_Main.Add_DatagridColoumn("City Name", "CityName", 150);
            dgr_Main.Add_DatagridColoumn("Distict", "DistrictName", 150);
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

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    enum_ReportName Report = enum_ReportName.CityList;

            //    tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
            //    if (oReports != null)
            //    {
            //        string sFilter = "";

            //        DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();
            //        glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(cls_Formater.getCompanyName()), clsSecurity.decryptPassword(cls_Formater.getCompanyAddress1()), cls_Formater.getCompanyAddress2(), cls_Formater.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

            //        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

            //        foreach (tbl_genMasCity oCity in tbl_genMasCity.SelectAll().Where(p => p.City_ID != "default" && p.IsCanceled == false))
            //        {
            //            glb_dts_Masters.dt_City.Adddt_CityRow(oCity.District_ID, clsRef_Name.get_District_Name(oCity.District_ID), oCity.City_ID, oCity.CityName);
            //        }
            //        frm_ReportViwer CRViwer = new frm_ReportViwer();
            //        CRViwer.Print(oReports.ReportPath, glb_dts_Masters, glb_dts_ExportReport.dt_rptParameter);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtCityCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasCity oCityMaster = tbl_genMasCity.Select(txtCityCode.Text.Trim());
                            if (oCityMaster != null)
                            {
                                oCityMaster.IsCanceled = true;
                                oCityMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oCityMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oCityMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oCityMaster.Update();

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
                            tbl_genMasCity oldRecord = tbl_genMasCity.Select(txtCityCode.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_genMasCity oCity = new tbl_genMasCity(txtCityCode.Text, txtCityName.Text, txtdistrictID.Tag.ToString(), oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
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
                            txtCityCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasCity oCity = new tbl_genMasCity(txtCityCode.Text, txtCityName.Text, txtdistrictID.Tag.ToString(), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCityCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCityName, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtdistrictID, true, false, false);


            txtCityCode.Text = "";
            txtCityCode.Tag = null;
            txtCityName.Text = "";
            txtdistrictID.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCityCode.setReadOnlyStatus(true);
                txtCityCode.Text = "<Auto Generate>";
            }
            else
                txtCityCode.setReadOnlyStatus(false);

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

            if (!clsValidation.Validate_EmptyValue(txtCityCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCityName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtdistrictID))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                foreach (tbl_genMasCity oDetail in tbl_genMasCity.SelectAll().Where(p => p.City_ID == txtCityCode.Text && p.District_ID == txtdistrictID.Text))
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    break;

                }
            }
            return bStatus;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasCity oCity in tbl_genMasCity.SelectAll().Where(p => p.City_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oCity.District_ID, clsRef_Name.get_District_Name(oCity.District_ID), oCity.City_ID, oCity.CityName);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genMasCity FillDetails = tbl_genMasCity.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCityCode.IsEnabled = false;
                        txtCityCode.Text = FillDetails.City_ID;
                        txtCityCode.Tag = FillDetails.City_ID;
                        txtdistrictID.Text = FillDetails.District_ID + " - " + clsRef_Name.get_District_Name(FillDetails.District_ID);
                        txtdistrictID.Tag = FillDetails.District_ID;
                        txtCityName.Text = FillDetails.CityName;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Mosue click
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private void txtCityCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtCityCode.Text = lstResult[0];
                txtCityCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }


        private void txtdistrictID_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {
                txtdistrictID.Text = lstResult[0] + " - "+lstResult[1];
                txtdistrictID.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
