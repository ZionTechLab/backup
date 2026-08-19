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
using SEACC_servii.Search_Forms;

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_Province.xaml
    /// </summary>
    public partial class UC_Province : UserControl
    {
        public UC_Province()
        {
            InitializeComponent();

            
            SEACC_Form.enmFormName = FormName.ProvinceCreation;
            SEACC_Form.Initialize(); 
           

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("ProvinceId");
            dgr_Main.dt.Columns.Add("provinceName");
            dgr_Main.dt.Columns.Add("countryCode");
            #endregion

            #region Initialized Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "ProvinceId", 70);
            dgr_Main.Add_DatagridColoumn("Province Name", "provinceName", 150);
            dgr_Main.Add_DatagridColoumn("Country", "countryCode", 150); 
            #endregion

            ClearFileds();
            RefreshGrid();
        }


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
            ClearFileds();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtProvinceID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasProvince detail = tbl_genMasProvince.Select(txtProvinceID.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFileds();
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
                            tbl_genMasProvince oldRecord = tbl_genMasProvince.Select(txtProvinceID.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_genMasProvince detail = new tbl_genMasProvince(txtProvinceID.Text.Trim(), txtProvinceName.Text, txtCountryID.Tag.ToString(), oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtProvinceID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasProvince detail = new tbl_genMasProvince(txtProvinceID.Text.Trim(), txtProvinceName.Text, txtCountryID.Tag.ToString(), false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime);
                        detail.Insert();
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
                    ClearFileds();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFileds()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProvinceID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtProvinceName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountryID, true, false, false);

            txtProvinceID.Text = "";
            txtProvinceID.Tag = null;
            txtProvinceName.Text = "";
            txtCountryID.Text = "";

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtProvinceID.setReadOnlyStatus(true);
                txtProvinceID.Text = "<Auto Generate>";
            }
            else
                txtProvinceID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasProvince detail in tbl_genMasProvince.SelectAll().Where(p => p.IsCanceled == false && p.Province_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Province_ID, detail.ProvinceName, clsRef_Name.get_Country_Name(detail.Country_ID));
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
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (ChekValidity_DuplicateNames())
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtProvinceID))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtProvinceName))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtCountryID))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasProvince detail = tbl_genMasProvince.Select(txtProvinceID.Text);
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
            foreach (tbl_genMasProvince detail1 in tbl_genMasProvince.SelectAll().Where(p => p.ProvinceName == txtProvinceName.Text && p.IsCanceled == false && p.Province_ID != txtProvinceID.Text))
            {
                if (detail1 != null)
                {
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "Province Name");
                    bStatus = false;
                    break;
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            tbl_genMasProvince detail = tbl_genMasProvince.Select(sID);
            if (detail != null)
            {
                SEACC_Form.IsUpdateMode = true;
                txtProvinceID.Text = detail.Province_ID;
                txtProvinceID.Tag = detail.Province_ID;
                txtProvinceName.Text = detail.ProvinceName;
                txtCountryID.Tag = detail.Country_ID;
                txtCountryID.Text = clsRef_Name.get_Country_Name(detail.Country_ID);
            }
        }
        #endregion

        #region Grid Event
        private void grd_Province_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtProvinceID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ProvinceCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtProvinceID.Text = lstResult[0];
                txtProvinceID.Tag = lstResult[0];
                ClearFileds();
                FillDetails(lstResult[0]);
            }
        }

        private void txtCountryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountryID.Text = lstResult[0] + " - " + lstResult[3];
                txtCountryID.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
