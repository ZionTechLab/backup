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
using Digiteq;
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;
using SEACC_servii.Search_Forms;

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_TownMaster.xaml
    /// </summary>
    public partial class UC_TownMaster : UserControl
    {

        #region Form Load
        public UC_TownMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.TownCreation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("TownCode");
            dgr_Main.dt.Columns.Add("Name");
            dgr_Main.dt.Columns.Add("CityCode");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Town Code", "TownCode", 80);
            dgr_Main.Add_DatagridColoumn("Town Name", "Name", 120);
            dgr_Main.Add_DatagridColoumn("City", "CityCode", 300);
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
                    if (txtTownID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasTown detail = tbl_genMasTown.Select(txtTownID.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
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
                            tbl_genMasTown OldRecord = tbl_genMasTown.Select(txtTownID.Text.Trim());
                            if (OldRecord != null)
                            {
                                tbl_genMasTown deatil = new tbl_genMasTown(txtTownID.Text, txtTownName.Text, txtCityCode.Tag.ToString(), false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Created, OldRecord.Date_Modified, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
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
                            txtTownID.Text = SEACC_Form.getAutoGeneratedCode();
                        tbl_genMasTown InserData = new tbl_genMasTown(txtTownID.Text, txtTownName.Text, txtCityCode.Tag.ToString(), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTownID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTownName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCityCode, true, false, false);

            txtTownID.Text = "";
            txtTownID.Tag = null;
            txtTownName.Text = "";
            txtCityCode.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtTownID.setReadOnlyStatus(true);
                txtTownID.Text = "<Auto Generate>";
            }
            else
                txtTownID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasTown detail in tbl_genMasTown.SelectAll().Where(p => p.Town_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(detail.Town_ID, detail.TownName, clsRef_Name.get_City_Name(detail.City_ID));
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
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtTownID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtTownName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCityCode))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasTown deatil = tbl_genMasTown.Select(txtTownID.Text.Trim());
                if (deatil != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
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
                    tbl_genMasTown detail = tbl_genMasTown.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtTownID.IsEnabled = false;
                        txtTownID.Text = detail.Town_ID;
                        txtTownID.Tag = detail.Town_ID;
                        txtTownName.Text = detail.TownName;
                        txtCityCode.Text = clsRef_Name.get_City_Name(detail.City_ID);
                        txtCityCode.Tag = detail.City_ID;
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
        private void grd_Town_new_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
        private void txtDeviceID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Town);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtTownID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtCityCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {

                txtCityCode.Text = lstResult[2];
                txtCityCode.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
