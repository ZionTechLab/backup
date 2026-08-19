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
    /// Interaction logic for UC_PostalCodesMaster.xaml
    /// </summary>
    public partial class UC_PostalCodesMaster : UserControl
    {
        #region Form Load
        public UC_PostalCodesMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Postal_Code_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("PostalID");
            dgr_Main.dt.Columns.Add("PostalCode");
            dgr_Main.dt.Columns.Add("TownName");
            dgr_Main.dt.Columns.Add("District"); 
            #endregion

            #region Initialize Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize GataGrid
            dgr_Main.Add_DatagridColoumn("ID", "PostalID", 0, false);
            dgr_Main.Add_DatagridColoumn("Postal Code", "PostalCode", 75);
            dgr_Main.Add_DatagridColoumn("Town", "TownName", 150);
            dgr_Main.Add_DatagridColoumn("District", "District", 150); 
            #endregion

            clearFields();
            RefresGrid();
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
                    if (txtPostalCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasPostalCode detail = tbl_genMasPostalCode.Select(txtPostalCode.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                clearFields();
                                RefresGrid();
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
                            tbl_genMasPostalCode OldRecord = tbl_genMasPostalCode.Select(txtPostalCode.Text.Trim());
                            if (OldRecord != null)
                            {
                                tbl_genMasPostalCode deatil = new tbl_genMasPostalCode(txtPostalCode.Text, txtOriginalPostalCode.Text, txtTown.Tag.ToString(), txtDistrict.Tag.ToString(), false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Created, OldRecord.Date_Modified, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
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
                        txtPostalCode.Text = SEACC_Form.getAutoGeneratedCode();
                        tbl_genMasPostalCode InserData = new tbl_genMasPostalCode(txtPostalCode.Text, txtOriginalPostalCode.Text, txtTown.Tag.ToString(), txtDistrict.Tag.ToString(), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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
                    clearFields();
                    RefresGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPostalCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDistrict, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOriginalPostalCode, true, false, false);

            txtDistrict.Text = "";
            txtPostalCode.Text = "";
            txtPostalCode.Tag = null;
            txtTown.Text = "";
            txtOriginalPostalCode.Text = "";

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPostalCode.Text = "<Auto Generate>";
                txtPostalCode.setReadOnlyStatus(true);
            }
            else
                txtPostalCode.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefresGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasPostalCode detail in tbl_genMasPostalCode.SelectAll().Where(p => p.PostalCode_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(detail.PostalCode_ID,detail.PostalCode, detail.Town, detail.District);
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

            if (!clsValidation.Validate_EmptyValue(txtPostalCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtTown))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDistrict))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasPostalCode deatil = tbl_genMasPostalCode.Select(txtPostalCode.Text.Trim());
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
                    tbl_genMasPostalCode detail = tbl_genMasPostalCode.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtPostalCode.IsEnabled = false;
                        txtPostalCode.Text = detail.PostalCode_ID;
                        txtPostalCode.Tag = detail.PostalCode_ID;
                        txtOriginalPostalCode.Text = detail.PostalCode;
                        txtPostalCode.Tag = detail.PostalCode;
                        txtTown.Text =detail.Town;
                        txtTown.Tag = detail.Town;
                        txtDistrict.Text =detail.District;
                        txtDistrict.Tag = detail.District;
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
        private void grd_postalCode_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void SEACC_LableTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void txtOriginalPostalCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PostalCode);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                txtPostalCode.Text = lstResult[0];
                txtPostalCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtDistrict_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {
                txtDistrict.Text = lstResult[1];
                txtDistrict.Tag = lstResult[1];
            }
        }

        private void txtTown_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HomeTown);
            if (RowDataSearch.DialogResult == true)
            {
                txtTown.Text = lstResult[1];
                txtTown.Tag = lstResult[1];
            }
        }
        #endregion

        
    }
}
