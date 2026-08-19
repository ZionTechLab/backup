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
    /// Interaction logic for UC_NationalityMaster.xaml
    /// </summary>
    public partial class UC_NationalityMaster : UserControl
    {      
        #region Form Load
        public UC_NationalityMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Nationality_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("NationalityID");
            dgr_Main.dt.Columns.Add("NationalityName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click; 
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "NationalityID", 70, false);
            dgr_Main.Add_DatagridColoumn("Name", "NationalityName", 150); 
            #endregion

            clearFileds();
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
            clearFileds();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtNationalityCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasNationality detail = tbl_genMasNationality.Select(txtNationalityCode.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                clearFileds();
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
                            tbl_genMasNationality OladRecord = tbl_genMasNationality.Select(txtNationalityCode.Text);
                            if (OladRecord != null)
                            {
                                tbl_genMasNationality oNationality = new tbl_genMasNationality(txtNationalityCode.Text, txtNationalityName.Text, OladRecord.IsCanceled, OladRecord.UserID_Created, clsSecurity.UserIDLoged, OladRecord.UserID_Canceled, OladRecord.TerminalID_Created, clsSecurity.TerminalID, OladRecord.TerminalID_Canceled, OladRecord.Date_Created, clsSecurity.getServerDateTime(), OladRecord.Date_Canceled);
                                oNationality.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtNationalityCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasNationality oNationality = new tbl_genMasNationality(txtNationalityCode.Text, txtNationalityName.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oNationality.Insert();
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
                    clearFileds();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void clearFileds()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtNationalityCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNationalityName, true, false, false);

            txtNationalityCode.Text = "";
            txtNationalityName.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtNationalityCode.setReadOnlyStatus(true);
                txtNationalityCode.Text = "<Auto Generate>";
            }
            else
                txtNationalityCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasNationality detail in tbl_genMasNationality.SelectAll().Where(p => p.Nationality_ID != "Default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(detail.Nationality_ID, detail.Nationality);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
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

            if (!clsValidation.Validate_EmptyValue(txtNationalityCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtNationalityName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasNationality oDetail = tbl_genMasNationality.Select(txtNationalityCode.Text);
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
            foreach (tbl_genMasNationality detail1 in tbl_genMasNationality.SelectAll().Where(p => p.Nationality == txtNationalityName.Text && p.IsCanceled == false && p.Nationality_ID != txtNationalityCode.Text))
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
                    tbl_genMasNationality ONationality = tbl_genMasNationality.Select(sID);
                    if (ONationality != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtNationalityCode.IsEnabled = false;
                        txtNationalityCode.Text = ONationality.Nationality_ID;
                        txtNationalityCode.Tag = ONationality.Nationality_ID;
                        txtNationalityName.Text = ONationality.Nationality;
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
        private void grd_Nationality_MouseLeftButtonUp1(object sender, EventArgs e)
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
        private void txtNationalityCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void txtNationalityName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Naltonality);
            if (RowDataSearch.DialogResult == true)
            {
                clearFileds();
                txtNationalityCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion


    }
}
