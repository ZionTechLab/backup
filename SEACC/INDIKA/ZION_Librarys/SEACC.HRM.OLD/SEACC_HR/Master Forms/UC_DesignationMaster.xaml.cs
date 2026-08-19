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
    /// Interaction logic for UC_DesignationMaster.xaml
    /// </summary>
    public partial class UC_DesignationMaster : UserControl
    {

        #region Form Load
        public UC_DesignationMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Designation_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("DsignationID");
            dgr_Main.dt.Columns.Add("DsignationName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Code", "DsignationID", 70);
            dgr_Main.Add_DatagridColoumn("Title", "DsignationName", 150); 
            #endregion
           
            RefreshGrid();
            ClearFields();
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
            try
            {
                enum_ReportName Report = enum_ReportName.DesignationList;

               // tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
               // if (oReports != null)
                {
                    string sFilter = "";

                    DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();
                   // glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                    DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                    foreach (tbl_hrMasDesignation detail in tbl_hrMasDesignation.SelectAll().Where(p => p.IsCanceled == false && p.Designation_ID != "default"))
                    {
                        glb_dts_Masters.dt_Designation.Adddt_DesignationRow(detail.Designation_ID, detail.Designation_name);
                    }
                    frm_ReportViwer CRViwer = new frm_ReportViwer();
                    //CRViwer.Print(oReports.ReportPath, glb_dts_Masters, glb_dts_ExportReport.dt_rptParameter);
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
                    if (txtDesignationCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hrMasDesignation detail = tbl_hrMasDesignation.Select(txtDesignationCode.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.UserID_Canceled = clsSecurity.UserGroupIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.Update();
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
                            tbl_hrMasDesignation OldRecord = tbl_hrMasDesignation.Select(txtDesignationCode.Text.Trim());
                            if (OldRecord != null)
                            {
                                tbl_hrMasDesignation deatil = new tbl_hrMasDesignation(txtDesignationCode.Text, txtDesignation.Text, false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                deatil.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }

                        }
                    } 
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtDesignationCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hrMasDesignation InserData = new tbl_hrMasDesignation(txtDesignationCode.Text, txtDesignation.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        InserData.Insert();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignationCode, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDesignation, true, false,false);
    

            txtDesignation.Text = "";
            txtDesignationCode.Tag = null;
            txtDesignationCode.Text = "";


            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtDesignationCode.setReadOnlyStatus(true);
                txtDesignationCode.Text = "<Auto Generate>";
            }
            else
                txtDesignationCode.setReadOnlyStatus(false);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrMasDesignation detail in tbl_hrMasDesignation.SelectAll().Where(p => p.IsCanceled == false && p.Designation_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Designation_ID, detail.Designation_name);
                }
                dgr_Main .RefreshGrid();
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

            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }


        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtDesignationCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDesignation))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrMasDesignation oDetail = tbl_hrMasDesignation.Select(txtDesignationCode.Text);
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
            foreach (tbl_hrMasDesignation detail1 in tbl_hrMasDesignation.SelectAll().Where(p => p.Designation_name == txtDesignation.Text && p.IsCanceled==false && p.Designation_ID != txtDesignationCode.Text))
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
                    tbl_hrMasDesignation detail = tbl_hrMasDesignation.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtDesignationCode.IsEnabled = false;
                        txtDesignationCode.Text = detail.Designation_ID;
                        txtDesignationCode.Tag = detail.Designation_ID;
                        txtDesignation.Text = detail.Designation_name;
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
        private void grd_Designation_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtDesignationCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Designations);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtDesignationCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}
