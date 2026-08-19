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
using SEACC_WPFControls;
using DataTire;
using System.Data;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CountryMaster.xaml
    /// </summary>
    public partial class UC_CountryMaster : UserControl
    {
        #region Form Load
        public UC_CountryMaster()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Country_Creation;
            SEACC_Form.Initialize();

            #region Data Tale Inilitiazed
            dgr_Main.dt.Columns.Add("CountryID");
            dgr_Main.dt.Columns.Add("CountryName");
            dgr_Main.dt.Columns.Add("CountryCodeUN");
            dgr_Main.dt.Columns.Add("CountryCodeISO");
            dgr_Main.dt.Columns.Add("DialingCode"); 
            #endregion

            #region Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click +=btn_Print_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion
            
            #region Grid Column Initialize
            dgr_Main.Add_DatagridColoumn("Country Code", "CountryID", 60,false);
            dgr_Main.Add_DatagridColoumn("UN Code", "CountryCodeUN", 70);
            dgr_Main.Add_DatagridColoumn("ISO Code", "CountryCodeISO", 70);
            dgr_Main.Add_DatagridColoumn("Name", "CountryName", 160);
            dgr_Main.Add_DatagridColoumn("Dialing Code", "DialingCode", 80);
            #endregion

            ClearField();
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
            ClearField();
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enum_ReportName Report = enum_ReportName.CountryList;

              //  tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
             //   if (oReports != null)
                {
                    string sFilter = "";

                    DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();
                //    glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                    DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                    foreach (tbl_genMasCountry oCountry in tbl_genMasCountry.SelectAll().Where(p => p.Country_ID != "default" && p.IsCanceled == false))
                    {
                        glb_dts_Masters.dt_Country.Adddt_CountryRow(oCountry.Country_ID, oCountry.CountryName, oCountry.Country_Code_UN, oCountry.Country_Code_ISO, oCountry.DialingCode);
                    }
                    frm_ReportViwer CRViwer = new frm_ReportViwer();
                  //  CRViwer.Print(oReports.ReportPath, glb_dts_Masters, glb_dts_ExportReport.dt_rptParameter);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtCountryID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasCountry oDevice = tbl_genMasCountry.Select(txtCountryID.Text.Trim());
                            if (oDevice != null)
                            {
                                oDevice.IsCanceled = true;
                                oDevice.UserID_Canceled = clsSecurity.UserIDLoged;
                                oDevice.Date_Canceled = clsSecurity.getServerDateTime();
                                oDevice.TerminalID_Canceled = clsSecurity.TerminalID;
                                oDevice.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearField();
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
                            tbl_genMasCountry oCountry = tbl_genMasCountry.Select(txtCountryID.Text.Trim());
                            if (oCountry != null)
                            {
                                tbl_genMasCountry oCountrys = new tbl_genMasCountry(txtCountryID.Text, txtCountryName.Text, txtCountryCodeISO.Text, txtCountryCodeUN.Text, txtDialingCode.Text, true, false, "", "", "", "", "", "", "", "", oCountry.IsCanceled, oCountry.UserID_Created, clsSecurity.UserIDLoged, oCountry.UserID_Canceled, oCountry.TerminalID_Created, clsSecurity.TerminalID, oCountry.TerminalID_Canceled, oCountry.Date_Created, clsSecurity.getServerDateTime(), oCountry.Date_Canceled);
                                oCountrys.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtCountryID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasCountry oCountry = new tbl_genMasCountry(txtCountryID.Text, txtCountryName.Text, txtCountryCodeISO.Text, txtCountryCodeUN.Text, txtDialingCode.Text, true, false, "", "", "", "", "", "", "", "", false, clsSecurity.UserIDLoged, "Dafault", "Defallt", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oCountry.Insert();
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
                    ClearField();
                    RefreshGrid();
                }
            }
        }

        #endregion

        #region Clear Fields
        private void ClearField()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCountryName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCountryCodeUN, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCountryCodeISO, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDialingCode, true, false, false);

            txtCountryID.Text = "";
            txtCountryName.Text = "";
            txtCountryCodeISO.Text = "";
            txtCountryCodeUN.Text = "";
            txtDialingCode.Text = "";
            txtCountryID.Tag = null;
           

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCountryID.setReadOnlyStatus(true);
                txtCountryID.Text = "<Auto Generate>";
            }
            else
                txtCountryID.setReadOnlyStatus(false);
            #endregion
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

            if (!clsValidation.Validate_EmptyValue(txtCountryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCountryName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasCountry oItem = tbl_genMasCountry.Select(txtCountryID.Text);
                if (oItem != null)
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
            foreach (tbl_genMasCountry detail1 in tbl_genMasCountry.SelectAll().Where(p => p.CountryName == txtCountryName.Text && p.Country_ID != txtCountryID.Text && p.IsCanceled==false))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
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
                foreach (tbl_genMasCountry oCountry in tbl_genMasCountry.SelectAll().Where(p => p.Country_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oCountry.Country_ID, oCountry.CountryName, oCountry.Country_Code_UN, oCountry.Country_Code_ISO, oCountry.DialingCode);
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
                    tbl_genMasCountry FillDetails = tbl_genMasCountry.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCountryID.IsEnabled = false;
                        txtCountryID.Text = FillDetails.Country_ID;
                        txtCountryID.Tag = FillDetails.Country_ID;
                        txtCountryName.Text = FillDetails.CountryName;
                        txtCountryCodeISO.Text = FillDetails.Country_Code_ISO;
                        txtCountryCodeUN.Text = FillDetails.Country_Code_UN;
                        txtDialingCode.Text = FillDetails.DialingCode;
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
        private void grd_Country_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtCountryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {
                ClearField();
                txtCountryID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion

    }
}
